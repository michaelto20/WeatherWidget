namespace WeatherWidget.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    

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
                new DropCreateDatabaseIfModelChanges<WeatherDbContext>()
                //new DropCreateDatabaseAlways<WeatherDbContext>()
           );
        }
        

        public virtual DbSet<Weather> Weather { get; set; }
        
    }
    
}