using System.IO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Json;
using WeatherWidget.Models.API;
using System;

namespace WeatherWidget.Models
{
    public class Weather
    {
        public int Id { get; set; }

        [Display(Name ="ZIP Code")]
        public int ZipCode { get; set; }

        [Display(Name="Chance of Precipitation")]
        public double PrecipitationChance { get; set; }

        [Display(Name ="Temperature (F)")]
        public int Temperature { get; set; }

        [Display(Name ="Description")]
        public string Description { get; set; }

        public Weather()
        {

        }

        public Weather(int ZipCode, double PrecipitationChance, int Temperature, string Description)
        {
            this.ZipCode = ZipCode;
            this.PrecipitationChance = PrecipitationChance;
            this.Temperature = Temperature;
            this.Description = Description;
        }

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
            }
            else
            {
                // zip code could not be parsed into a number
                isValid = false;
            }

            return isValid;
        }

        public static Weather GetWeatherForZip(string zip)
        {
            Weather weather = null;
            int zipCode;
            try
            {
                // API key can be used only 1 every 10 minutes
                string url = "http://api.openweathermap.org/data/2.5/weather?APPID=256bcf3e5fd68d3261de80f09fe147c6&units=imperial&zip=" + zip;
                var synClient = new WebClient();
                var content = synClient.DownloadString(url);
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(WeatherAPI));
                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
                {
                    var weatherData = (WeatherAPI)serializer.ReadObject(ms);

                    // Parse data from API object to store in DB
                    // TODO: Modify DB to accompany new datatypes from WeatherAPI
                    int.TryParse(zip, out zipCode);
                    weather = new Weather(zipCode, 10, (int)weatherData.main.temp, weatherData.weather[0].description);
                }
            }
            catch(Exception ex)
            {

            }
            return weather;
        }
        
    }
}