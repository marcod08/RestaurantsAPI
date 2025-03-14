using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;

public class TemperatureRequest
{
    public required int Min { get; set; }
    public required int Max { get; set; }
}

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    [HttpPost("generate")]
    public IActionResult Generate([FromQuery] int count, [FromBody] TemperatureRequest request)
    {
        if (count < 0 || request.Max < request.Min) 
        {
            return BadRequest("Count has to be a positive number and max must be greater than the min value");
        }

        var result = _weatherForecastService.Get(count, request.Min, request.Max);
        return Ok(result);
    }

    
}
