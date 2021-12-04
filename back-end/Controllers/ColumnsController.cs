using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
    public class ColumnsController : ControllerBase
    {
        public string selectedColumn;
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<ColumnNames> columnNames = new List<ColumnNames>();

        private readonly ILogger<ColumnsController> _logger;

        public ColumnsController(ILogger<ColumnsController> logger)
        {
            _logger = logger;
            con.ConnectionString = "Server=localhost;database=tpnl-test-2021-11-18-15-2;Trusted_Connection=True;";
        }

        private void FetchData()
        {
            // Fetch table names in database
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
                        columnNames = dr[selectedColumn].ToString()

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
        
        /* TODO: Find a way to get data into a variable
        [HttpPost]
        public string Post( )
        {
          
        }*/

        //API end point to get all columns
        //[HttpGet("get-columnsNames")]
        //public IActionResult GetAllColumnNames()
        //{
        //    var allColumnNames = _columnsServive.GetAllColumnNames();
        //    return Ok(allColumnNames);
        //}
    }
}
