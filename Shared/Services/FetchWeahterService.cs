using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.MVVM.Shared.Models;

namespace Blazor.MVVM.Shared.Services{
    public interface IFetchWeatherService {
        Task RetrieveForecastAsync(); 
        IWeatherForecast[] WeatherForecasts { get; }
    }
}