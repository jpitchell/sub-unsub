using System;
using System.Collections.Generic;
using ElectronDotNetTest.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class WeatherResponse
{
    [JsonProperty("list")]
    public IList<WeatherForecast> Forecasts {get; set;}
}

public class WeatherForecast
{
    [JsonProperty("dt")]
    [JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime Date { get; set; }

    [JsonProperty("weather")]
    public IList<WeatherInfo> WeatherInfo { get; set; }
}

public class WeatherInfo
    {
        [JsonProperty("id")]
        public int Id { get;set; }

        [JsonProperty("main")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; } 
    }