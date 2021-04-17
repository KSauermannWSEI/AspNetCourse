using Domain.Models;
using Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClientHelpers;

namespace HairdressingMVC.Controllers
{
    //[Authorize(Roles = "Employee")] Not OK - Strings in code
    //[Authorize(Roles = ConstValues.EMPLOYEE)]
    [Authorize(Roles = nameof(RoleType.Employee))]
    public class PricesController : Controller
    {
        private WebApiClient<Price> webApiClient;
        public PricesController(IConfiguration configuration)
        {
            webApiClient = new WebApiClient<Price>(configuration.GetConnectionString("ApiBaseUrl"), "Prices");
        }
        public async Task<IActionResult> Index()
        {
            var model = await webApiClient.GetListAsync();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Price item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item jest pusty");
            }
            if (ModelState.IsValid)
            {
                var result = await webApiClient.AddAsync(item);
                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(item);
        }
    }
}
