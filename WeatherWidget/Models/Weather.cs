using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherWidget.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public double PrecipitationChance { get; set; }
        public int Temperature { get; set; }
        public string Description { get; set; }

        public Weather()
        {

        }

        public Weather(double PrecipitationChange, int Temperature, string Description)
        {
            this.PrecipitationChance = PrecipitationChance;
            this.Temperature = Temperature;
            this.Description = Description;
        }
    }
}