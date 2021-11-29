using my_new_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_new_app.Data.Services
{
    public class TablesService
    {
        private AppDbContext _context;

        public TablesService(AppDbContext context)
        {
            _context = context;
        }

        //Get all table names from the database
        public List<TableNames> GetAllTableNames() => _context.Tables.ToList();

        //Get a single table name from the database
        //public TableNames GetTableByName(string name) => _context.Tables.FirstOrDefault(n=> n.name ==TableNames);
    }
}
