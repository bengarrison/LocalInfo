using LocalInfo.DataModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LocalInfo.DataServices
{
    public class OpenWeatherMapDataService
    {
        public LocalWeatherDataModel GetLocalWeather()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(
                 "http://api.openweathermap.org/data/2.5/weather?APPID=1b24c4fec1ac428fff1ffce582d102b2&q=San Diego&units=imperial").Result;

            var localWeatherDataModel = JsonConvert.DeserializeObject<LocalWeatherDataModel>(response);

            return localWeatherDataModel;
        }
    }
}
