using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApi
{
    public class CurrentConditions
    {

        public DateTime ObservationTime { get; set; }

        public String LocationName { get; set; }

        public double Latitide { get; set; }

        public double Longitude { get; set; }

        public String ConditionsDescription { get; set; }

        public double Temperature { get; set; }

        public double Humidity { get; set; }

        public double? Dewpoint { get; set; }

        public double? Windchill { get; set; }

        public double WindSpeed { get; set; }

        public double WindSpeedGusts { get; set; }

        public double WindDirectionDegrees { get; set; }

        public String WindDirection { get; set; }

        /// <summary>
        /// Gets the source of this forecast (i.e. the service it came from)
        /// </summary>
        public String Source { get; set; }

    }
}
