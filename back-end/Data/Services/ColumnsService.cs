using my_new_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_new_app.Data.Services
{
    public interface IColumnsService
    {
        string getSelectedColumn();
        void SetSelectedColumn(string selectedColumn);
    }

    public class ColumnsService : IColumnsService
    {
        private string selectedColumn;
        public string getSelectedColumn()
        {
            return selectedColumn;
        }

        public void SetSelectedColumn(string selectedColumn)
        {
            this.selectedColumn = selectedColumn;
        }

    }
}
