using my_new_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_new_app.Data.Services
{
    public interface IValuesService
    {
        string getSelectedValue();
        void SetSelectedValue(string selectedValue);
    }
    public class ValuesService : IValuesService
    {

        private string selectedValue;
        public string getSelectedValue()
        {
            return selectedValue;
        }



        public void SetSelectedValue(string selectedValue)
        {
            this.selectedValue = selectedValue;
        }


    }
}
