using System.ComponentModel.DataAnnotations;

public class ApiConfig
{
    [Required(AllowEmptyStrings=false)]
    public string WeatherApiBaseUrl { get; set; }

    [Required(AllowEmptyStrings=false)]
    public string WeatherApiKey { get; set; }
}