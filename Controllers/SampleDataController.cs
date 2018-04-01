using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetVueBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetVueBlog.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly WheatherContext _context;
        

        public SampleDataController(WheatherContext context)
        {
            _context = context;                
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts(string ort)
        {
           if (!String.IsNullOrEmpty(ort) && ort.Equals("Munich", StringComparison.InvariantCultureIgnoreCase)) {

               return _context.Wheather.Select(x => new WeatherForecast
               {
                   DateFormatted = x.DateFormatted.ToString("dd.MM.yyyy")                 ,
                   TemperatureC = x.TemperatureC,
                   Summary = x.Summary
               }).ToList();
               
           }

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
