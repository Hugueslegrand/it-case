using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using my_new_app.Data.Services;
using Microsoft.Data.SqlClient;
using my_new_app.Models;
using Microsoft.Extensions.Logging;
using System.Data;
using Microsoft.Extensions.Configuration;
using my_new_app.Data.Models;

namespace my_new_app.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TablesController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<TableNames> tableNames = new List<TableNames>();

        

       
        private readonly IConfiguration _configuration;
        private readonly IDatabaseService _databaseService;
        private readonly ITablesService _tablesService;


        public TablesController(IConfiguration configuration, IDatabaseService databaseService,ITablesService tablesService)
        {
            _configuration = configuration;
            _databaseService = databaseService;
            _tablesService = tablesService;
            con.ConnectionString = _configuration.GetConnectionString("TestConnectionString");
        }

        // 1ste way of retrieving data from the database
        private void FetchTableNames()
        {
           
            // Fetch table names in database
            if (tableNames.Count > 0)
            {
                tableNames.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "Select * from INFORMATION_SCHEMA.TABLES;";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    tableNames.Add(new TableNames()
                    {
                        tableNames = dr["table_name"].ToString()

                    });
                }
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        
        // Post to request the selected table from angular 
        [HttpPost()]
        public IActionResult SelectTable([FromQuery] string tableName)
        {
            //Store value in table services
            
            _tablesService.SetSelectedTable(tableName);
            
            if (tableName == null)
            {
                return BadRequest("empty value");
            };
            
            return Ok("");
           
        }

        // Request for tablenames
        [HttpGet("getTableNames")]
        public List<TableNames> GetTableNames()
        {
;            FetchTableNames();
            return tableNames;
        }


    }
}