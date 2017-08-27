using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

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

        public Weather(double PrecipitationChance, int Temperature, string Description)
        {
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
    }
}