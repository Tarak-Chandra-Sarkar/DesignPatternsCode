using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoaaWeatherApi
{
    public class ForecastTimes
    {
        public string layoutKey { get; set; }
        public List<string> startPeriodName { get; set; }
        public List<string> startValidTime { get; set; }
        public List<string> tempLabel { get; set; }
    }
}
