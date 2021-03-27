using Domain.DAL;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly IPricesRepository repository;

        public PricesController(IPricesRepository repository)
        {          
            this.repository = repository;
        }

        [HttpGet]
        //public async Task<List<Price>> Get()
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await repository.GetListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
