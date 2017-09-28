using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApi;
using WeatherUndergroundApi;

namespace WeatherUndergroundAdapter
{
    public class WeatherUndergroundDriver : IWeatherClient
    {


        public CurrentConditions GetCurrentConditions(string zipCode)
        {
            WeatherUndergroundClient wuClient = new WeatherUndergroundClient();
            CurrentConditionsResponse response = wuClient.GetCurrentConditions(zipCode);

            return this.MapCurrentConditionsResponse(response);
        }




        /// <summary>
        /// A simple mapper method that maps the response we get from WeatherUnderground to our standard response object
        /// for current conditions
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        internal CurrentConditions MapCurrentConditionsResponse(CurrentConditionsResponse response)
        {
            CurrentConditions currentConditions = new CurrentConditions();
            // I took the name and location from the display location.  You could choose to map it from the measurement location
            currentConditions.Source = "Weather Underground";
            currentConditions.LocationName = response.current_observation.display_location.full;
            currentConditions.Latitide = Convert.ToDouble(response.current_observation.display_location.latitude);
            currentConditions.Longitude = Convert.ToDouble(response.current_observation.display_location.longitude);
            currentConditions.ObservationTime = DateTime.Parse(response.current_observation.local_time_rfc822);

            currentConditions.ConditionsDescription = response.current_observation.weather;
            currentConditions.Temperature = response.current_observation.temp_f;
            currentConditions.Humidity = Convert.ToDouble(response.current_observation.relative_humidity.Replace('%', ' '));
            currentConditions.Dewpoint = response.current_observation.dewpoint_f;
            currentConditions.Windchill = this.ConvertWindchillString(response.current_observation.windchill_f);

            currentConditions.WindSpeed = response.current_observation.wind_mph;
            currentConditions.WindDirectionDegrees = response.current_observation.wind_degrees;
            currentConditions.WindDirection = response.current_observation.wind_dir;

            return currentConditions;
        }




        internal double? ConvertWindchillString(String windchillInput)
        {
            if (String.IsNullOrWhiteSpace(windchillInput))
                return null;

            if (windchillInput == "NA")
                return null;

            return Convert.ToDouble(windchillInput);
        }




    }
}
