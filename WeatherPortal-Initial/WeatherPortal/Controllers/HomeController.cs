using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherPortal.Models;
using WeatherUndergroundApi;

namespace WeatherPortal.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(String zipCode = null)
        {
            if (String.IsNullOrWhiteSpace(zipCode))
                zipCode = "54481";


            WeatherUndergroundClient weatherClient = new WeatherUndergroundClient();
            CurrentConditionsResponse currentConditions = weatherClient.GetCurrentConditions(zipCode);

            HomeIndexModel model = new HomeIndexModel() { WeatherData = currentConditions };

            return View(model);
        }


    }
}