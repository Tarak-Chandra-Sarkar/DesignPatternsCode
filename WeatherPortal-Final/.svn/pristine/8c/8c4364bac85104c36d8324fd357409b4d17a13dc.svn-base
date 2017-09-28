using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi;

namespace FakeWeatherService
{
    public class FakeWeatherServiceDriver : IWeatherClient
    {


        public CurrentConditions GetCurrentConditions(string zipCode)
        {
            switch (zipCode)
            {
                case "52242":
                    return new CurrentConditions()
                    {
                        LocationName = "Iowa City, IA",
                        Latitide = 0.0,
                        Longitude = 0.0,
                        ConditionsDescription = "Snow",
                        ObservationTime = DateTime.Now,
                        Temperature = 20,
                        Humidity = 30,
                        Dewpoint = null,
                        Windchill = 10,
                        WindDirection = "N",
                        WindDirectionDegrees = 354,
                        WindSpeed = 10,
                        WindSpeedGusts = 15,
                        Source = "Fake Weather Service"
                    };
                case "23005":
                    return new CurrentConditions()
                    {
                        LocationName = "Ashland, VA",
                        Latitide = 0.0,
                        Longitude = 0.0,
                        ConditionsDescription = "Rain",
                        ObservationTime = DateTime.Now,
                        Temperature = 55,
                        Humidity = 100,
                        Dewpoint = 52,
                        Windchill = null,
                        WindDirection = "S",
                        WindDirectionDegrees = 185,
                        WindSpeed = 8,
                        WindSpeedGusts = 12,
                        Source = "Fake Weather Service"
                    };

                case "92903":
                    return new CurrentConditions()
                    {
                        LocationName = "San Diego, CA",
                        Latitide = 0.0,
                        Longitude = 0.0,
                        ConditionsDescription = "Sunny",
                        ObservationTime = DateTime.Now,
                        Temperature = 80,
                        Humidity = 30,
                        Dewpoint = 52,
                        Windchill = null,
                        WindDirection = "N",
                        WindDirectionDegrees = 0,
                        WindSpeed = 10,
                        WindSpeedGusts = 20,
                        Source = "Fake Weather Service"
                    };

                default:
                    return new CurrentConditions()
                    {
                        LocationName = "Your Town, USA",
                        Latitide = 0.0,
                        Longitude = 0.0,
                        ConditionsDescription = "Sunny",
                        ObservationTime = DateTime.Now,
                        Temperature = 75,
                        Humidity = 30,
                        Dewpoint = 0,
                        Windchill = null,
                        WindDirection = "W",
                        WindDirectionDegrees = 270,
                        WindSpeed = 5,
                        WindSpeedGusts = 5,
                        Source = "Fake Weather Service"
                    };

            }
        }
    }
}
