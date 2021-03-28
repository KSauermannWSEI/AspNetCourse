using Domain.DAL;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    
    public class ServiceTypesController : SharedController<ServiceType>
    {
        public ServiceTypesController(IRepository<ServiceType> repository) : base(repository)
        {

        }
    }
}
