using NoaaWeatherApi;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeatherApi;
using ZipCodeService;

namespace NoaaWeatherAdapter
{

    /// <summary>
    /// Class that adapts the NOAA weather interface to our standard interface.  This class is effectively
    /// a "driver" for the NOAA solution much like a database driver that conforms to a standard interface
    /// </summary>
    public class NoaaWeatherDriver : IWeatherClient
    {


        public NoaaWeatherDriver(IZipCodeService zipCodeService)
        {
            this.zipCodeService = zipCodeService;
        }



        /// <summary>
        /// Service to look up the lat/long of a zip code, since zip code is our input and the NOAA service needs
        /// a lat/long.
        /// </summary>
        private IZipCodeService zipCodeService;



        /// <summary>
        /// Gets the current weather conditions for the given zip code
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public CurrentConditions GetCurrentConditions(string zipCode)
        {
            ZipCodeInfo zipCodeObject = this.zipCodeService.GetZipCode(zipCode);


            NoaaWeatherClient noaaClient = new NoaaWeatherClient();
            NoaaResponse response = noaaClient.GetWeatherConditions(zipCodeObject.Latitude.Value, zipCodeObject.Longitude.Value);

            return this.MapResponseObject(response);
        }



        #region Helper Methods

        /// <summary>
        /// Maps the NOAA response object to our standard response object
        /// </summary>
        /// <param name="response">A NoaaResponse object of the response received from the NOAA service</param>
        /// <returns></returns>
        internal CurrentConditions MapResponseObject(NoaaResponse response)
        {
            CurrentConditions currentConditions = new CurrentConditions();
            currentConditions.Source = "NOAA";
            currentConditions.LocationName = response.location.areaDescription;
            currentConditions.Latitide = Convert.ToDouble(response.location.latitude);
            currentConditions.Longitude = Convert.ToDouble(response.location.longitude);
            //currentConditions.ObservationTime = DateTime.ParseExact(response.currentobservation.Date, "dd MMM HH:mm", CultureInfo.InvariantCulture);

            currentConditions.ConditionsDescription = response.currentobservation.Weather;
            currentConditions.Temperature = Convert.ToDouble(response.currentobservation.Temp);
            currentConditions.Humidity = Convert.ToDouble(response.currentobservation.Relh);
            currentConditions.Dewpoint = Convert.ToDouble(response.currentobservation.Dewp);
            currentConditions.Windchill = ConvertWindchillString(response.currentobservation.WindChill);
            currentConditions.WindSpeed = Convert.ToDouble(response.currentobservation.Winds);
            currentConditions.WindSpeedGusts = Convert.ToDouble(response.currentobservation.Gust);
            currentConditions.WindDirectionDegrees = Convert.ToDouble(response.currentobservation.Windd);
            currentConditions.WindDirection = this.MapWindDirection(response.currentobservation.Windd);

            return currentConditions;
        }


        /// <summary>
        /// Converts the Windchill string to a value suitable for our standard response object
        /// </summary>
        /// <remarks>
        /// If there is no windchill value available (like during summer), the NOAA service 
        /// returns a string of "NA", so in these cases, we return a null.  
        /// </remarks>
        /// <param name="windchillInput">A String of the windchill value from the NOAA service</param>
        /// <returns>A nullable double value, where the value will be null if no windchill measurement is available</returns>
        internal double? ConvertWindchillString(String windchillInput)
        {
            if (String.IsNullOrWhiteSpace(windchillInput))
                return null;

            if (windchillInput == "NA")
                return null;

            return Convert.ToDouble(windchillInput);
        }


        /// <summary>
        /// Maps the wind direction in degrees string to a compass value like N, S, E or W
        /// </summary>
        /// <remarks>
        /// This method will map to a point on a 16 point compass
        /// </remarks>
        /// <param name="degreesValue">A String of the value in degrees the wind is coming from</param>
        /// <returns>A String of the compass heading of where the wind is coming from</returns>
        internal String MapWindDirection(String degreesValue)
        {
            if (String.IsNullOrEmpty(degreesValue))
                return String.Empty;

            if (!Regex.IsMatch(degreesValue, "^//d{1-3}$"))
                return String.Empty;

            int degrees = Convert.ToInt32(degreesValue);

            if (degrees > 348.75 && degrees <= 360 || degrees >= 0 && degrees <= 11.25)
                return "N";
            else if (degrees > 11.25 && degrees <= 33.75)
                return "NNE";
            else if (degrees > 33.75 && degrees <= 56.25)
                return "NE";
            else if (degrees > 56.25 && degrees <= 78.75)
                return "ENE";
            else if (degrees > 78.75 && degrees <= 101.25)
                return "E";
            else if (degrees > 101.25 && degrees <= 123.75)
                return "ESE";
            else if (degrees > 123.75 && degrees <= 146.25)
                return "SE";
            else if (degrees > 146.25 && degrees <= 168.75)
                return "SSE";
            else if (degrees > 168.75 && degrees <= 191.25)
                return "S";
            else if (degrees > 191.75 && degrees <= 213.75)
                return "SSW";
            else if (degrees > 213.75 && degrees <= 236.25)
                return "SW";
            else if (degrees > 236.25 && degrees <= 258.75)
                return "WSW";
            else if (degrees > 258.75 && degrees <= 281.25)
                return "W";
            else if (degrees > 281.25 && degrees <= 303.75)
                return "WNW";
            else if (degrees > 303.75 && degrees <= 326.25)
                return "NW";
            else if (degrees > 326.25 && degrees <= 348.75)
                return "NNW";
            else
                return String.Empty;
        }

        #endregion


    }
}
