using my_new_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_new_app.Data.Services
{
    public interface ITablesService
    {
        string getTable();
        void SetSelectedTable(string selectedTable);
    }
    public class TablesService : ITablesService
    {

        public static string selectedTable;
        public string getTable()
        {
            return selectedTable;
        }
        public static string SelectedTable
        {
            get { return selectedTable; }
            set { selectedTable = value; }
        }

        public string GetCountryCode()
        {
            return SelectedTable;
        }

        public void SetSelectedTable(string selectedTable)
        {
            TablesService.SelectedTable = selectedTable;
        }


    }
}