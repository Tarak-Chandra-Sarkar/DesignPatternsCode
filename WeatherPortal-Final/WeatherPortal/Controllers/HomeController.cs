using FakeWeatherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApi;
using WeatherApiCache;
using WeatherPortal.Models;
using WeatherUndergroundAdapter;
using WeatherUndergroundApi;
using ZipCodeService;

namespace WeatherPortal.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(IZipCodeService zipCodeService)
        {
            this.zipCodeService = zipCodeService;
        }


        private IZipCodeService zipCodeService;

        /// <summary>
        /// Action that calls the Weather Underground library directly
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public ActionResult Index(String zipCode = null)
        {
            if (String.IsNullOrWhiteSpace(zipCode))
                zipCode = "55437";


            WeatherUndergroundClient weatherClient = new WeatherUndergroundClient();
            CurrentConditionsResponse currentConditions = weatherClient.GetCurrentConditions(zipCode);

            HomeIndexModel model = new HomeIndexModel() { WeatherData = currentConditions };

            return View(model);
        }


        /// <summary>
        /// Controller action developed using the the Bridge design pattern to get its data
        /// </summary>
        /// <remarks>
        /// This controller is programmed against the interface IWeatherClient, so it avoids the direct
        /// dependency on a third party interface.
        /// </remarks>
        /// <param name="zipCode">A String of the zip code to get the weather for</param>
        /// <returns></returns>
        public ActionResult BridgePattern(String zipCode = null)
        {
            if (String.IsNullOrWhiteSpace(zipCode))
                zipCode = "54481";

            // IWeatherClient weatherClient = new WeatherUndergroundDriver();

            #region NOAA Weather Client
            IWeatherClient weatherClient = new NoaaWeatherAdapter.NoaaWeatherDriver(this.zipCodeService);
            #endregion

            #region Fake Weather Service
            // IWeatherClient weatherClient = new FakeWeatherServiceDriver();
            #endregion

            #region Caching Decorator
            //IWeatherClient weatherClient = new WeatherClientCacheDecorator(new WeatherUndergroundDriver());
            #endregion

            CurrentConditions currentConditions = weatherClient.GetCurrentConditions(zipCode);

            BridgePatternModel model = new BridgePatternModel() { WeatherData = currentConditions };

            return View(model);
        }


    }
}