using Domain.DAL;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public class PricesController : SharedController<Price>
    {
        public PricesController(IRepository<Price> repository, ILogger<PricesController> logger) : base(repository, logger)
        {
        }
    }
}
