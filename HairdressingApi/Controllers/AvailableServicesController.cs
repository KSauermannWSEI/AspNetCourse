using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HairdressingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvailableServicesController : SharedController<AvailableService>
    {
        public AvailableServicesController(IRepository<AvailableService> repository, ILogger<AvailableServicesController> logger) : base(repository, logger)
        {
        }        
    }
}
