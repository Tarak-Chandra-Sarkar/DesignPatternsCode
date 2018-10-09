using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApi;
using WeatherPortal.Models;

namespace WeatherPortal.Controllers
{
    public class DependencyInjectionController : Controller
    {

        public DependencyInjectionController(IWeatherClient weatherClient)
        {
            this.weatherClient = weatherClient;
        }


        private IWeatherClient weatherClient;


        public ActionResult Index(String zipCode = null)
        {
            if (String.IsNullOrWhiteSpace(zipCode))
                zipCode = "54481";

            CurrentConditions currentConditions = this.weatherClient.GetCurrentConditions(zipCode);

            DependencyInjectionIndexModel model = new DependencyInjectionIndexModel() { WeatherData = currentConditions };

            return View(model);
        }
    }
}