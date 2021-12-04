using Microsoft.AspNetCore.Mvc;
using System.Web;
using System;
using Newtonsoft.Json;

namespace my_new_app.Data
{
    [Route("API/[controller]/[action]")]
    [ApiController]
    public class DatabaseController : Controller
    {
        [HttpPost]
        public IActionResult Connect([FromQuery] string CountryCode)
        {
            Console.WriteLine(CountryCode);
            return Ok(CountryCode);
        }
    }
}
