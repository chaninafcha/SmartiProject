using Microsoft.AspNetCore.Mvc;
using Smarti.Entites;
using Smarti.Models;
using Smarti.Services.Interfaces;
using System.Net;

namespace Smarti.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {


        private readonly ILogger<PersonController> _logger;
        private IGeneralServices generalServices;

        public PersonController(ILogger<PersonController> logger, IGeneralServices _generalServices)
        {
            _logger = logger;
            generalServices = _generalServices;
        }

        [HttpGet(Name = "GetPerson")]
        public async Task<ActionResult<object>> Get()
        {
            
            var person = generalServices.SetProperties<PersonEntity>();
            return person;
        }


    }
}
