using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmallWebApp.Data;

[ApiController]
[Route("/weather")]
public class WeatherForcastController : ControllerBase{
    private static readonly string[] summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForcastController> _logger;
    public WeatherForcastController(ILogger<WeatherForcastController> _service){
        _logger = _service;
    }

    [HttpGet]
    public IEnumerable<WeatherForcast> GetForcasts(){
        return Enumerable.Range(1, 5).Select(index => new WeatherForcast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        })
        .ToArray();
    }
}
