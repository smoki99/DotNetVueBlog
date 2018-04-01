using System.Collections.Generic;
using DotNetVueBlog.DomainModel;

namespace DotNetVueBlog.Services {
    public interface IWheatherForecastService
    {
        IList<WeatherForecastModel> GetForecast(string city);
    }
}