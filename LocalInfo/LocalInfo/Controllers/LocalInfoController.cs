using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LocalInfo.Models;

namespace LocalInfo.Controllers
{
    [Route("[controller]")]
    public class LocalInfoController : Controller
    {
        public IActionResult Index()
        {
            return View(GetLocalInfoModel());
        }

        private LocalInfoModel GetLocalInfoModel()
        {
            var darkSkyWeather = new DarkSky.Services.DarkSkyService("054cb92e44f2aea1e4bc6333aa7deb3d");
            var forecast = darkSkyWeather.GetForecast(32.959492, -117.265244);
            var todaysData = forecast.Result.Response.Daily.Data.OrderBy(x => x.Time).First();
       
            return new LocalInfoModel()
            {
                CurrentTemperature = Convert.ToInt32(forecast.Result.Response.Currently.Temperature.Value),
                Longitude = forecast.Result.Response.Longitude,
                Lattitude = forecast.Result.Response.Latitude,
                Sunrise = new DateTime(1970, 1, 1).AddSeconds(todaysData.SunriseTime.Value).ToLocalTime().ToString(),
                Sunset = new DateTime(1970, 1, 1).AddSeconds(todaysData.SunsetTime.Value).ToLocalTime().ToString(),
            };
        }
    }
}
