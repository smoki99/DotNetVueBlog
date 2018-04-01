using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetVueBlog.Models;
using DotNetVueBlog.Services;
using Microsoft.AspNetCore.Mvc;
using DotNetVueBlog.DomainModel;
namespace DotNetVueBlog.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IWheatherForecastService _wheatherForecastService;

        public SampleDataController(IWheatherForecastService wheatherForecastService)
        {
            _wheatherForecastService = wheatherForecastService;                
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecastModel> WeatherForecasts(string ort)
        {
           if (!String.IsNullOrEmpty(ort) && ort.Equals("Munich", StringComparison.InvariantCultureIgnoreCase)) {

               return _wheatherForecastService.GetForecast("Munich");
           }

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecastModel
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }
    }
}
