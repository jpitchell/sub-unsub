using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ElectronDotNetTest.Data
{
    public class WeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherForecastService(HttpClient httpClient, IOptions<ApiConfig> options)
        {            
            var apiRootUrl = options.Value?.WeatherApiBaseUrl;
            _apiKey = options.Value?.WeatherApiKey;

            if (string.IsNullOrEmpty(apiRootUrl))
                throw new ArgumentNullException("WeatherApiBaseUrl");
            if (string.IsNullOrEmpty(_apiKey))
                throw new ArgumentNullException("WeatherApiKey");

            httpClient.BaseAddress = new Uri(apiRootUrl);
            httpClient.DefaultRequestHeaders.Add("Accept",
                "application/json");
            _httpClient = httpClient;
        }

        public async Task<WeatherForecastViewModel[]> GetForecastAsync(DateTime startDate)
        {
            var forecastUrl = $"/data/2.5/forecast?zip={95008},us&appid={_apiKey}";

            using var responseMessage = await _httpClient.GetAsync(forecastUrl);
            
            var body = await responseMessage.Content.ReadAsStringAsync();

            var weatherForecast = JsonConvert.DeserializeObject<WeatherResponse>(body);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecastViewModel
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                TemperatureF = rng.Next(40, 99),
                Summary = weatherForecast.Forecasts[index]?.WeatherInfo?.First()?.Description ?? "N/A"                
            }).ToArray();
        }
    }
}
