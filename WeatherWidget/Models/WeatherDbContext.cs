namespace WeatherWidget.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WeatherDbContext : DbContext
    {
        // Your context has been configured to use a 'WeatherDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WeatherWidget.Models.WeatherDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'WeatherDbContext' 
        // connection string in the application configuration file.
        public WeatherDbContext()
            : base("name=WeatherDbContext")
        {
            Database.SetInitializer<WeatherDbContext>(
                //new DropCreateDatabaseIfModelChanges<WeatherDbContext>()
                new DropCreateDatabaseAlways<WeatherDbContext>()
           );
        }
        

        public virtual DbSet<Weather> Weather { get; set; }

        public static bool ValidateZip(string zip)
        {
            bool isValid = false;
            int zipCode;

            // Only allow zip codes of length 5
            isValid = zip.Length == 5;


            // Makes sure zip codes contains only 5 numbers
            if (int.TryParse(zip, out zipCode))
            {
                Regex regex = new Regex(@"^[0-9]{5}$");
                isValid &= regex.IsMatch(zip);
            }else
            {
                // zip code could not be parsed into a number
                isValid = false;
            }

            return isValid;
        }
    }
    
}