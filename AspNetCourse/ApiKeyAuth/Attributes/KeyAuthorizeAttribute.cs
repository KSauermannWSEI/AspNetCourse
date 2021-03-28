using ApiKeyAuth.Filters;
using Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiKeyAuth.Attributes
{
    public class KeyAuthorizeAttribute : TypeFilterAttribute
    {
        public KeyAuthorizeAttribute(params RoleType[] roles) : base(typeof(AuthorizeMultiplePolicyFilter))
        {
            List<RoleType> list = roles.ToList();
            if (!roles.Contains(RoleType.Employee))
            {                
                list.Add(RoleType.Employee);
            }
            Arguments = new object[] { list.ToArray() };
        }
    }
}
