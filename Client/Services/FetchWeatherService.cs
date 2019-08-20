using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Blazor.MVVM.Shared.Models;
using Blazor.MVVM.Shared.Services;

namespace Blazor.MVVM.Client.Services
{
    public class FetchWeatherService : IFetchWeatherService
    {
        private HttpClient _http;
        
        public IWeatherForecast[] WeatherForecasts { get; private set; }

        public FetchWeatherService(HttpClient http)
        {
            _http = http;
        }

        public async Task RetrieveForecastAsync()
        {
            this.WeatherForecasts = await _http.GetJsonAsync<WeatherForecast[]>("api/WeatherForecasts");
        }
    }
}