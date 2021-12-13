﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("Connect")]
        public IActionResult Connect([FromQuery] string CountryCode)
        {
            string data = "";
            //Console.WriteLine(CountryCode);
            //this.CountryCode = CountryCode;
            //return Ok(CountryCode);
            if (CountryCode != null) 
            {
                data = CountryCode;
            }
            //databaseService.SetCountryCode(CountryCode);
           
            
            TempData["CountryCode"] = data;
            Console.WriteLine(TempData["CountryCode"]);
            return RedirectToAction("Index", "Tables");
        }
    }
}
