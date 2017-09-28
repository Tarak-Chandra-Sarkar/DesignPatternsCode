using Autofac;
using Autofac.Integration.Mvc;
using NoaaWeatherAdapter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApi;
using WeatherApiCache;
using WeatherUndergroundAdapter;
using ZipCodeService;

namespace WeatherPortal
{
    public class AutofacConfig
    {

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
                       
            // Zip Code Service
            ZipCodeReader reader = new ZipCodeReader();
            String filename = Path.Combine(HttpRuntime.BinDirectory, "zipcodes.csv");
            var zipCodeService = new InMemoryZipCodeService(reader.LoadZipCodes(filename));
            builder.RegisterInstance<IZipCodeService>(zipCodeService).As<IZipCodeService>();

            //builder.RegisterType<WeatherUndergroundDriver>().As<IWeatherClient>();
            //builder.RegisterType<NoaaWeatherDriver>().As<IWeatherClient>();


            // For Decorators
            // http://docs.autofac.org/en/latest/advanced/adapters-decorators.html
            // Register the services to be decorated. You have to
            // name them rather than register them As<IWeatherClient>()
            // so the *decorator* can do the registration for As<IWeatherClient>()

            //builder.RegisterType<WeatherUndergroundDriver>().Named<IWeatherClient>("weather");
            builder.RegisterType<NoaaWeatherDriver>().Named<IWeatherClient>("weather");

            // Register the decorator. The decorator uses the named registrations to get the items to wrap.
            builder.RegisterDecorator<IWeatherClient>(
                (c, inner) => new WeatherClientCacheDecorator(inner),
                fromKey: "weather");



            var container = builder.Build();           
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }



    }
}