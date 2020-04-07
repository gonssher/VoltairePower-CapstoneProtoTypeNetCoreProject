using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VoltairePower.Models;

namespace VoltairePower.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "Value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        public WeatherNetwork WeatherDetail(string City)
        {
            //Assign API KEY which received from OPENWEATHERMAP.ORG  
            string appId = "3f8852c527927e56dc74df7d2abd5c84";

            //API path with CITY parameter and other parameters.  
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&APPID={1}", City, appId);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            string html = string.Empty;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            WeatherNetwork data = new WeatherNetwork();

            dynamic jsonReader = JsonConvert.DeserializeObject(html);

            data.City = jsonReader.name;
            data.Country = jsonReader.sys.country;
            data.Timezone = jsonReader.timezone;
            data.Main = jsonReader.weather[0].main;
            data.Description = jsonReader.weather[0].description;
            data.Temperature = jsonReader.main.temp;
            data.FeelsLike = jsonReader.main.feels_like;
            data.Temp_Min = jsonReader.main.temp_min;
            data.Temp_Max = jsonReader.main.temp_max;
            data.Pressure = jsonReader.main.pressure;
            data.Humidity = jsonReader.main.humidity;
            data.WindSpeed = jsonReader.wind.speed;
            data.WindGust = jsonReader.wind.gust;

            return data;
        }



    }
}