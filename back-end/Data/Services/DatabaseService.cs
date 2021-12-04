namespace my_new_app.Data.Services
{
    public interface IDatabaseService
    {
        string GetCountryCode();
        void SetCountryCode(string countryCode);
        
    }

    public class DatabaseService: IDatabaseService
    {
        private static string countryCode;

        public static string CountryCode
        {
            get { return countryCode; }
            set { countryCode = value; }
        }

        public string GetCountryCode()
        {
            return CountryCode;
        }

        public void SetCountryCode(string countryCode)
        {
            DatabaseService.CountryCode = countryCode;
        }
    }
}
