using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LocalInfo.Models;
using LocalInfo.DataModels;
using LocalInfo.DataServices;

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
            var openWeatherMapDataService = new OpenWeatherMapDataService();
            var localWeatherDataModel = openWeatherMapDataService.GetLocalWeather();

            return new LocalInfoModel()
            {
                TodaysTemperature = Convert.ToInt32(localWeatherDataModel.main.temp),
                Longitude = localWeatherDataModel.coord.lon,
                Lattitude = localWeatherDataModel.coord.lat,
                Sunrise = new DateTime(1970, 1, 1).AddSeconds(localWeatherDataModel.sys.sunrise).ToLocalTime().ToString(),
                Sunset = new DateTime(1970, 1, 1).AddSeconds(localWeatherDataModel.sys.sunset).ToLocalTime().ToString()
            };
        }
    }
}
