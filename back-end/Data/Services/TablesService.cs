using my_new_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_new_app.Data.Services
{
    public interface ITablesService
    {
        string getSelectedTable();
        void SetSelectedTable(string selectedTable);
    }
    public class TablesService : ITablesService
    {

        private  string selectedTable;
        public string getSelectedTable()
        {
            return selectedTable;
        }
       
        public void SetSelectedTable(string selectedTable)
        {
            this.selectedTable = selectedTable;
        }
       
     
    }
}
