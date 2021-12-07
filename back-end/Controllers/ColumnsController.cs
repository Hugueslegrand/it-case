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


        private readonly IConfiguration _configuration;
        private readonly IDatabaseService _databaseService;
        private readonly ITablesService _tablesService;

        public ColumnsController(IConfiguration configuration, IDatabaseService databaseService, ITablesService tablesService)
        {
            _configuration = configuration;
            _databaseService = databaseService;
            _tablesService = tablesService;
            con.ConnectionString = _configuration.GetConnectionString("TestConnectionString");
        }



        [HttpPost()]
        public IActionResult SelectColumn([FromQuery] string columnName)
        {
            //TODO: Store selected column in column services

            return Ok();

        }


        private void FetchColumnNames()
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
            FetchColumnNames();
            return columnNames;
        }


    }
}