using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace WeatherWidget.Models.API
{
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public int humidity { get; set; }
        public double pressure { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    [DataContract]
    public class WeatherAPI
    {
        [DataMember]
        public Coord coord { get; set; }

        [DataMember]
        public Sys sys { get; set; }

        [DataMember]
        public List<Weather> weather { get; set; }

        [DataMember]
        public string @base { get; set; }

        [DataMember]
        public Main main { get; set; }

        [DataMember]
        public Wind wind { get; set; }

        [DataMember]
        public Clouds clouds { get; set; }

        [DataMember]
        public int dt { get; set; }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public int cod { get; set; }
    }
}