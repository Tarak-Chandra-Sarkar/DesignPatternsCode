using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoaaWeatherApi
{
    public class CurrentObservation
    {
        public string id { get; set; }
        public string name { get; set; }
        public string elev { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string Date { get; set; }
        public string Temp { get; set; }
        public string Dewp { get; set; }
        public string Relh { get; set; }
        public string Winds { get; set; }
        public string Windd { get; set; }
        public string Gust { get; set; }
        public string Weather { get; set; }
        public string Weatherimage { get; set; }
        public string Visibility { get; set; }
        public string Altimeter { get; set; }
        public string SLP { get; set; }
        public string timezone { get; set; }
        public string state { get; set; }
        public string WindChill { get; set; }
    }
}
