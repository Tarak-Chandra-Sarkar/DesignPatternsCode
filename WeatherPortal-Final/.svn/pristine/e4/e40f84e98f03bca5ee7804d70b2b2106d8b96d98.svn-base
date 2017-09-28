using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NoaaWeatherApi
{
    /// <summary>
    /// Class that calls an NOAA page to get the weather results for a location in JSON format
    /// </summary>
    public class NoaaWeatherClient
    {



        public NoaaResponse GetWeatherConditions(double latitude, double longitude)
        {
            String uri = $"http://forecast.weather.gov/MapClick.php?lat={latitude}&lon={longitude}&FcstType=json";

            HttpClient httpClient = new HttpClient();
            // If you don't have a user agent, NOAA gives you a 403 error
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36");
            String responseJson = httpClient.GetStringAsync(uri).Result;

            NoaaResponse response = JsonConvert.DeserializeObject<NoaaResponse>(responseJson);
            return response;
        }



    }
}
