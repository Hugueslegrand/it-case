using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
    public class ColumnsController : Controller
    {
        public string selectedColumn;
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<ColumnNames> columnNames = new List<ColumnNames>();

        private readonly ILogger<ColumnsController> _logger;
        private readonly IConfiguration _configuration;

        public ColumnsController(IConfiguration configuration)
        {
            _configuration = configuration;
            con.ConnectionString = _configuration.GetConnectionString("TestConnectionString");
        }

        [HttpPost()]
        public IActionResult SelectColumn([FromQuery] string columnName)
        {
            string data = "";
            if (columnName != null)
            {
                data = columnName;
            }
            TempData["SelectedTable"] = data;
            Console.WriteLine(TempData["SelectedTable"]);
            return Ok();
            //return RedirectToAction("Index", "Columns");
        }


        private void FetchData()
        {
            // Fetch column names in database
            if (columnNames.Count > 0)
            {
                columnNames.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "Select * from INFORMATION_SCHEMA.COLUMNS;";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    columnNames.Add(new ColumnNames()
                    {
                        columnNames = dr["column_name"].ToString()

                    });
                }
               
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
       

        [HttpGet("getColumnNames")]
        public List<ColumnNames> GetColumnNames()
        {
            FetchData();
            return columnNames;
        }

        

        //API end point to get all columns
        //[HttpGet("get-columnsNames")]
        //public IActionResult GetAllColumnNames()
        //{
        //    var allColumnNames = _columnsServive.GetAllColumnNames();
        //    return Ok(allColumnNames);
        //}
    }
}
