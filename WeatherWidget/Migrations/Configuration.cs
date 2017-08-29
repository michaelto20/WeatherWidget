namespace WeatherWidget.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using WeatherWidget.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WeatherWidget.Models.WeatherDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WeatherWidget.Models.WeatherDbContext";
        }

        protected override void Seed(WeatherWidget.Models.WeatherDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Create admin role if not already in database
            if (!roleManager.RoleExists("Administrator"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Administrator";
                roleManager.Create(role);


                var user = new ApplicationUser();
                user.UserName = "Administrator@gmail.com";
                user.Email = "admin@gmail.com";

                string userPassword = "Password1!";

                var chkUser = UserManager.Create(user, userPassword);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Administrator");

                }
            }

            context.SaveChanges();

            // Seed database with current weather information
            // Get current data for each zip code from weather API and 
            // save it to the DB
            List<string> zips = new List<string>() { "30909", "30907", "30809" };
            WeatherDbContext db = new WeatherDbContext();
            foreach (string zip in zips)
            {
                Weather weather = Weather.GetWeatherForZip(zip);
                db.Weather.Add(weather);
                db.SaveChanges();
            }
            
        }
    
    }
}
