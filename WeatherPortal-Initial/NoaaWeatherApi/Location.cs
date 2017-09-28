using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoaaWeatherApi
{
    public class Location
    {
        public string region { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string elevation { get; set; }
        public string wfo { get; set; }
        public string timezone { get; set; }
        public string areaDescription { get; set; }
        public string radar { get; set; }
        public string zone { get; set; }
        public string county { get; set; }
        public string firezone { get; set; }
        public string metar { get; set; }
    }
}
