using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DotNetVueBlog.DomainModel;
using DotNetVueBlog.Models;
using DotNetVueBlog.Repositories;

namespace DotNetVueBlog.Services {
    public class WheatherForecastService : IWheatherForecastService
    {
        private readonly IGenericRepository<Wheather> _wheatherRepository;

        
        public WheatherForecastService(IGenericRepository<Wheather> wheatherRepository)
        {
            _wheatherRepository = wheatherRepository;                
        }
        public IList<WeatherForecastModel> GetForecast(string city) {
            return _wheatherRepository.Get().Select(x => MapToWeatherForecastModel(x)).ToList();
        }

        private WeatherForecastModel MapToWeatherForecastModel(Wheather wheather) {
            return new WeatherForecastModel
            {
                DateFormatted = wheather.DateFormatted.ToString("dd.MM.yyyy"),
                TemperatureC = wheather.TemperatureC,
                Summary = wheather.Summary,
                TemperatureF = CalculateF(wheather.TemperatureC)
            };
        }

        private int CalculateF(int temperatureC)
        {
            return 32 + (int)(temperatureC / 0.5556);
        }
    }
}