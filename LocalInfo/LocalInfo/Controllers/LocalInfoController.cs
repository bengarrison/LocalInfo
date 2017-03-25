using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LocalInfo.Controllers
{
    [Route("api/[controller]")]
    public class LocalInfoController : Controller
    {
        // GET api/values
        [HttpGet]
        public LocalInfoModel Get()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(
                 "http://api.openweathermap.org/data/2.5/weather?APPID=1b24c4fec1ac428fff1ffce582d102b2&q=San Diego&units=imperial").Result;

            var localWeatherDataModel = JsonConvert.DeserializeObject<LocalWeatherDataModel>(response);

            return new LocalInfoModel()
            {
                TodaysTemperature = Convert.ToInt32(localWeatherDataModel.main.temp)
            };
        }
    }


    public class LocalInfoModel
    {
        public int TodaysTemperature { get; set; }
    }






    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public double temp_min { get; set; }
        public int temp_max { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class LocalWeatherDataModel
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
