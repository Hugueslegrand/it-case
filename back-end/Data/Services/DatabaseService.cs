namespace my_new_app.Data.Services
{
    public interface IDatabaseService
    {
        string GetCountryCode();
        void SetCountryCode(string countryCode);
        
    }

    public class DatabaseService: IDatabaseService
    {
        private string countryCode;

       

        public string GetCountryCode()
        {
            return countryCode;
        }

        public void SetCountryCode(string countryCode)
        {
            this.countryCode = countryCode;
        }
    }
}
