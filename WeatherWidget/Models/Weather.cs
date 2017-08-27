using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
    }
}