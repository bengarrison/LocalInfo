using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LocalInfo.Models;
using LocalInfo.DataModels;

namespace LocalInfo.Controllers
{
    [Route("[controller]")]
    public class LocalInfoController : Controller
    {
        public IActionResult Index()
        {
            return View(GetLocalInfo());
        }

        private LocalInfoModel GetLocalInfo()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(
                 "http://api.openweathermap.org/data/2.5/weather?APPID=1b24c4fec1ac428fff1ffce582d102b2&q=San Diego&units=imperial").Result;

            var localWeatherDataModel = JsonConvert.DeserializeObject<LocalWeatherDataModel>(response);

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
