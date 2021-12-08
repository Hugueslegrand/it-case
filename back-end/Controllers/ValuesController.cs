using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using my_new_app.Data.Models;
using my_new_app.Data.Services;
using my_new_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_new_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<ValueNames> valueNames = new List<ValueNames>();

        private readonly IConfiguration _configuration;
        private readonly IDatabaseService _databaseService;
        private readonly ITablesService _tablesService;
        private readonly IColumnsService _columnsService;
        private readonly IValuesService _valuesService;

        public ValuesController(IConfiguration configuration, IDatabaseService databaseService, ITablesService tablesService, IColumnsService columnsService, IValuesService valuesService)
        {
            _configuration = configuration;
            _databaseService = databaseService;
            _tablesService = tablesService;
            _columnsService = columnsService;
            _valuesService = valuesService;
            con.ConnectionString = _configuration.GetConnectionString("TestConnectionString");
        }

        private void FetchValueNames()
        {

            // Fetch table names in database
            if (valueNames.Count > 0)
            {
                valueNames.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = $"select \"{_columnsService.getSelectedColumn()}\" from {_tablesService.getSelectedTable()} ";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    valueNames.Add(new ValueNames()
                    {
                        valuesNames = dr[_columnsService.getSelectedColumn()].ToString()

                    });
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [HttpGet("getValueNames")]
        public List<ValueNames> GetValueNames()
        {
            FetchValueNames();
            return valueNames;
        }

        [HttpPost()]
        public IActionResult SelectValue([FromQuery] string valueName)
        {
            //Store value in value services

            _valuesService.SetSelectedValue(valueName);

            if (valueName == null)
            {
                return BadRequest("empty value");
            };

            return Ok("");

        }

    }
}
