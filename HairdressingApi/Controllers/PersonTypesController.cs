using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdressingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonTypesController : SharedController<PersonType>
    {
        public PersonTypesController(IRepository<PersonType> repository) : base(repository)
        {
        }
    }
}
