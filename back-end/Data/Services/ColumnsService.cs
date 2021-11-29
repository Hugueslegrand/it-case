using my_new_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_new_app.Data.Services
{
    public class ColumnsService
    {
        private AppDbContext _context;

        public ColumnsService(AppDbContext context)
        {
            _context = context;
        }

        //Get all column names from the database
        public List<ColumnNames> GetAllColumnNames() => _context.Columns.ToList();
    }
}
