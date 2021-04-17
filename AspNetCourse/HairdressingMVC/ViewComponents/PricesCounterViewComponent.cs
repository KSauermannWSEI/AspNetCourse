using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClientHelpers;

namespace HairdressingMVC.ViewComponents
{
    public class PricesCounterViewComponent : ViewComponent
    {
        private WebApiClient<Price> webApiClient;
        public PricesCounterViewComponent(IConfiguration configuration)
        {
            var apiKey = configuration["ApiKeyValue"];
            webApiClient = new WebApiClient<Price>(
                configuration.GetConnectionString("ApiBaseUrl"),
                "Prices",
                apiKey);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = await webApiClient.GetListAsync();
            return View(list.Count);
        }
    }
}
