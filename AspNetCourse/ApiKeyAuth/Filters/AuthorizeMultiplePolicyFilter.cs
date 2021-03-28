using Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiKeyAuth.Filters
{
    public class AuthorizeMultiplePolicyFilter : IAsyncAuthorizationFilter
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly Repo repo;
        private readonly RoleType[] roles;
        const string API_KEY = "api-key";

        public AuthorizeMultiplePolicyFilter(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, params RoleType[] roles)
        {
            this.httpContextAccessor = httpContextAccessor;
            repo = new Repo(configuration);
            this.roles = roles;

        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context.Filters.Any(item => item is IAllowAnonymousFilter)) //TODO Fix AllowAnonymous
            {
                return;
            }
            var httpContext = httpContextAccessor.HttpContext;
            string key = httpContext.Request.Headers[API_KEY];
            if (key != null)
            {
                string role = repo.CheckApiKey(key) ? repo.GetRole(key) : null;
                if (role != null && roles.Select(r => r.ToString()).Contains(role))
                {
                    return;
                }
                context.Result = new UnauthorizedResult();
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsync("Access denied.");
            }
            else
            {
                context.Result = new UnauthorizedResult();
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsync($"Missing {API_KEY}");
            }
        }
        class Repo
        {
            private readonly IConfiguration configuration;

            internal Repo(IConfiguration configuration)
            {
                this.configuration = configuration;
            }
            //List<ApiKey> allKeys
            //{
            //    get
            //    {
            //        return configuration.GetSection("Keys").GetSection("List").Get<List<ApiKey>>();
            //    }
            //}
            List<ApiKey> allKeys => configuration.GetSection("Keys").GetSection("List").Get<List<ApiKey>>();

            internal bool CheckApiKey(string key)
            {
                return allKeys.Any(k => k.Key == key);
            }
            internal string GetRole(string key)
            {
                return allKeys.Where(k => k.Key == key).Select(r => r.Role).FirstOrDefault();
            }

        }
        class ApiKey
        {
            public string Role { get; set; }
            public string Key { get; set; }
        }
    }
}
