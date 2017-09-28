using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoaaWeatherApi
{
    public class NoaaResponse
    {
        public string operationalMode { get; set; }
        public string srsName { get; set; }
        public string creationDate { get; set; }
        public string creationDateLocal { get; set; }
        public string productionCenter { get; set; }
        public string credit { get; set; }
        public string moreInformation { get; set; }
        public Location location { get; set; }
        public ForecastTimes time { get; set; }
        public ForecastData data { get; set; }
        public CurrentObservation currentobservation { get; set; }
    }
}
