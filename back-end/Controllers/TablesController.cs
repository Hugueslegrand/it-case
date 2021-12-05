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
        string database = "";

        private readonly ILogger<TablesController> _logger;
        private readonly IConfiguration _configuration;


        public TablesController(/*ILogger<TablesController> logger*/IConfiguration configuration)
        {
            _configuration = configuration;
            con.ConnectionString = _configuration.GetConnectionString("TestConnectionString");
            // _logger = logger;

            //switch (database)
            //{
            //    case "Be":
            //        con.ConnectionString = _configuration.GetConnectionString("BelgiumConnectionstring");
            //        break;
            //    case "Nl":
            //        con.ConnectionString = _configuration.GetConnectionString("NetherlandsConnectionstring");
            //        break;
            //    case "Pl":
            //        con.ConnectionString = _configuration.GetConnectionString("PolandConnectionstring");
            //        break;
            //    case "Uk":
            //        con.ConnectionString = _configuration.GetConnectionString("UkConnectionstring");
            //        break;
            //    case "Jp":
            //        con.ConnectionString = _configuration.GetConnectionString("JapanConnectionstring");
            //        break;
            //    case "Us":
            //        con.ConnectionString = _configuration.GetConnectionString("USAConnectionstring");
            //        break;
            //    default:
            //        break;
            //}
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {

            Console.WriteLine(TempData["CountryCode"].GetType());

            //string countryCode = TempData["CountryCode"].ToString();
            //Console.WriteLine(countryCode);
            ////if (TempData.ContainsKey("CountryCode"))
            ////{
            ////    countryCode = TempData["CountryCode"].ToString();
            ////}
            //switch (countryCode)
            //{
            //    case "Be":
            //        con.ConnectionString = _configuration.GetConnectionString("BelgiumConnectionstring");
            //        Console.WriteLine(con.ConnectionString);
            //        break;
            //    case "Nl":
            //        con.ConnectionString = _configuration.GetConnectionString("NetherlandsConnectionstring");
            //        Console.WriteLine(con.ConnectionString);
            //        break;
            //    case "Pl":
            //        con.ConnectionString = _configuration.GetConnectionString("PolandConnectionstring");
            //        Console.WriteLine(con.ConnectionString);
            //        break;
            //    case "Uk":
            //        con.ConnectionString = _configuration.GetConnectionString("UkConnectionstring");
            //        Console.WriteLine(con.ConnectionString);
            //        break;
            //    case "Jp":
            //        con.ConnectionString = _configuration.GetConnectionString("JapanConnectionstring");
            //        Console.WriteLine(con.ConnectionString);
            //        break;
            //    case "Us":
            //        con.ConnectionString = _configuration.GetConnectionString("USAConnectionstring");
            //        Console.WriteLine(con.ConnectionString);                   
            //        break;
            //    default:
            //        break;
            //}
            return Ok();
        }

        // 1ste way of retrieving data from the database
        private void FetchData()
        {
            Console.WriteLine(con.ConnectionString);
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

        //public TablesService _tablesServive;

        /* public TablesController(TablesService tablesService)
         {
             _tablesServive = tablesService;
         }*/

        [HttpPost()]
        public IActionResult SelectTable([FromQuery] string tableName)
        {
            string data = "";
            if(tableName != null)
            {
                data = tableName;
            }
            TempData["SelectedTable"] = data;
            Console.WriteLine(TempData["SelectedTable"]);
            return RedirectToAction("Index", "Columns");
        }


        [HttpPost("SelectedTable")]
        public IActionResult Connect([FromQuery] string SelectedTable)
        {
            string data = "";
            
            if (SelectedTable != null)
            {
                data = SelectedTable;
            }
            //databaseService.SetCountryCode(CountryCode);


            TempData["SelectedTable"] = data;
            Console.WriteLine(TempData["SelectedTable"]);
            return RedirectToAction("Index", "Columns");
        }


        // 2nd way of retrieving data from the database
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"Select * from INFORMATION_SCHEMA.TABLES;";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TestConnectionString");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        // 1ste way of retrieving data from the database
        [HttpGet("getTableNames")]
        public List<TableNames> GetTableNames()
        {
            FetchData();
            return tableNames;
        }


        //API end point to get all tableNames
        /*[HttpGet("get-tableNames")]
        public IActionResult GetAllTableNames()
        {
            var allTableNames = _tablesServive.GetAllTableNames();
            return Ok(allTableNames);
        }*/
    }
}