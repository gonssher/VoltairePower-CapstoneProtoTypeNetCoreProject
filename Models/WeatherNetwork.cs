using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoltairePower.Models
{
    public class WeatherNetwork
    {
        public String City { get; set; }
        public String Country { get; set; }
        public String Timezone { get; set; }
        public String Main { get; set; }
        public String Description { get; set; }
        public String Temperature { get; set; }
        public String FeelsLike { get; set; }
        public String Temp_Min { get; set; }
        public String Temp_Max { get; set; }
        public String Pressure { get; set; }
        public String Humidity { get; set; }
        public String WindSpeed { get; set; }
        public String WindGust { get; set; }
    }
}

