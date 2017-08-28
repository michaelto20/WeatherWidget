using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherWidget.Models;

namespace WeatherWidget.Controllers
{
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
            zipCode = zipCode.ToLower().Trim();
            int zip;

            if (ModelState.IsValid) {
                if (Weather.ValidateZip(zipCode))
                {
                    // We know zip will parse because of ValidateZip()
                    int.TryParse(zipCode, out zip); 

                    // Get weather data for the given zip code
                    using(WeatherDbContext db = new WeatherDbContext())
                    {
                        // Find weather with zip code using parameters
                        string query = "SELECT * FROM Weathers WHERE ZipCode = @zipCode";
                        SqlParameter zipParameter = new SqlParameter("@zipCode", zip);
                        weather = await db.Database.SqlQuery<Weather>(query, zipParameter).FirstOrDefaultAsync();
                    }
                    if(weather == null)
                    {
                        ViewBag.ZipNotFound = "Sorry, we do not have weather information for that zip code.";
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
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}