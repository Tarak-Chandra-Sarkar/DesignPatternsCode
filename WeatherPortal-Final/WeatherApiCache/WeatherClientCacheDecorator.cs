using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherApi;
using System.Web;
using System.Web.Caching;

namespace WeatherApiCache
{


    /// <summary>
    /// Simple decorator object that caches results for our weather interface
    /// </summary>
    /// <remarks>
    /// In a real world scenario, a class like this would probably use an enterprise
    /// caching solution like Redis, but to keep dependencies to a minimum, 
    /// </remarks>
    public class WeatherClientCacheDecorator : IWeatherClient
    {
        /// <summary>
        /// Creates the weather client cache decorator object.  You pass in the the 
        /// IWeatherClient object to be decorated (ie wrapped)
        /// </summary>
        /// <param name="weatherClient">Am IWeatherClient object of the object to be decorated</param>
        public WeatherClientCacheDecorator(IWeatherClient weatherClient)
        {
            this.wrappedWeatherClient = weatherClient;
        }

        /// <summary>
        /// This is the decorated (i.e. wrapped) object
        /// </summary>
        private IWeatherClient wrappedWeatherClient;


        /// <summary>
        /// Gets the current conditions for the given zip code
        /// </summary>
        /// <remarks>
        /// This method first checks the cache to see if we already have a cached copy of the current
        /// conditions for the given zip code.  If not, we'll call the object that we are wrapping to
        /// get the current conditions, store the results in the cache and return them.  If we already
        /// have a cached copy, we just return those.
        /// <para>
        /// In this very simple implementation, results are cached for 5 minutes
        /// </para>
        /// </remarks>
        /// <param name="zipCode">A String of the zip code to get the current locations for</param>
        /// <returns>A CurrentConditions object giving the conditions at the specified location</returns>
        public CurrentConditions GetCurrentConditions(string zipCode)
        {
            Cache cache = HttpRuntime.Cache;

            CurrentConditions currentConditions = cache[zipCode] as CurrentConditions;
            if ( currentConditions == null)
            {
                // We don't have the value in the cache, so we need to query it from 
                // the service and store it in the cache
                currentConditions = this.wrappedWeatherClient.GetCurrentConditions(zipCode);

                cache.Add(zipCode, currentConditions, null, DateTime.Now.AddMinutes(5),
                    Cache.NoSlidingExpiration, CacheItemPriority.AboveNormal, null);
            }
            return currentConditions;                       
        }


    }
}
