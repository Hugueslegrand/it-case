using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using my_new_app.Models;

namespace my_new_app.Data
{
    public class AppDbContext : DbContext
    {
        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }
        public DbSet<TableNames> Tables { get; set; }

        public DbSet<ColumnNames> Columns { get; set; }
    } 
  }

