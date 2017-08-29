using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherWidget.Models;

namespace WeatherWidget.Controllers
{
    // For logging purposes use Log4Net, configured in the Web.config
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string zipCode)
        {

            Weather weather = null;
            
            if (ModelState.IsValid) {
                if (Weather.ValidateZip(zipCode))
                {
                    try
                    {
                        zipCode = zipCode.ToLower().Trim();
                        int zip;
                        Weather.GetWeatherForZip(zipCode);
                        // We know zip will parse because of ValidateZip()
                        int.TryParse(zipCode, out zip);

                        // Get weather data for the given zip code
                        using (WeatherDbContext db = new WeatherDbContext())
                        {
                            // Find weather with zip code using parameters
                            string query = "SELECT * FROM Weathers WHERE ZipCode = @zipCode";
                            SqlParameter zipParameter = new SqlParameter("@zipCode", zip);
                            weather = await db.Database.SqlQuery<Weather>(query, zipParameter).FirstOrDefaultAsync();
                        }
                        if (weather == null)
                        {
                            ViewBag.ZipNotFound = "Sorry, we do not have weather information for that zip code.";
                        }
                    }
                    catch(Exception ex)
                    {
                        // log exception

                    }
                }
                else
                {
                    ViewBag.ZipNotFound = "Sorry, we do not have weather information for that zip code.";
                }
            }
            else
            {
                ModelState.AddModelError("zipCode", "Invalid zip code.");
            }
            return View(weather);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "A webpage to find the area for a zip code.  This is part of a skills test for TaxSlayer.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Feel free to contact me.";

            return View();
        }

        
    }
}