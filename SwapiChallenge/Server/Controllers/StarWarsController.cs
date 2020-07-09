using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwapiChallenge.Shared;
using SwapiChallenge.Shared.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SwapiChallenge.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarWarsController : ControllerBase
    {
        private ISwapiService SwapiService { get; }

        public StarWarsController(ISwapiService swapiService)
        {
            SwapiService = swapiService;
        }


        // GET: api/<StarWarsController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
           var people= await  SwapiService.GetPeopleAsync(1);
            return Ok(people);
           
        }

       
    }
}
