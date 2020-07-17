using System;
using Newtonsoft.Json;

namespace ElectronDotNetTest.Data
{
    public class WeatherForecastViewModel
    {
        public DateTime Date { get; set; }

        public string Summary { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { get;set; }
    }
}
