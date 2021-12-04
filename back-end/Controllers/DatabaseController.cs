using Microsoft.AspNetCore.Mvc;
using System.Web;
using System;
using Newtonsoft.Json;
using my_new_app.Data.Services;

namespace my_new_app.Data
{
    [Route("API/[controller]/[action]")]
    [ApiController]
    public class DatabaseController : Controller
    {
        private readonly IDatabaseService databaseService;

        public DatabaseController(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        [HttpPost]
        public IActionResult Connect([FromQuery] string CountryCode)
        {
            //Console.WriteLine(CountryCode);
            //this.CountryCode = CountryCode;
            //return Ok(CountryCode);
            if (CountryCode == null) 
            {
                return BadRequest(); 
            }
            databaseService.SetCountryCode(CountryCode);
            return Ok();
        }
    }
}
