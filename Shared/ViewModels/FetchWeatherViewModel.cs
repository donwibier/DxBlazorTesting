using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.MVVM.Shared.Models;
using Blazor.MVVM.Shared.Services;

namespace Blazor.MVVM.Shared.ViewModels
{
    public interface IFetchDataViewModel
    {
        //IWeatherForecast[] WeatherForecasts { get; }
        //string DisplayTemperatureShort{ get; }
        string DisplayOtherTemperatureScaleLong { get; }
        string DisplayPremiumToggleMessage { get; }
        IBasicFetchWeatherViewModel BasicForecastViewModel { get; }

        //Action ToggleTemperatureCommand { get; }

        Task RetrieveForecastsAsync();
        void ToggleMembership();

        // int DisplayTemperature(int temperature);
        void ToggleTemperatureScale();
    }
    public class FetchDataViewModel : IFetchDataViewModel
    {
        private bool _displayFahrenheit;
        private bool _isPremiumMember;
        
        private IFetchWeatherService _fetchWeather;                
        public IBasicFetchWeatherViewModel BasicForecastViewModel { get; private set; }
        public FetchDataViewModel(IFetchWeatherService fetchWeather, IBasicFetchWeatherViewModel basicWeatherViewModel)
        {            
            Console.WriteLine("FetchDataViewModel Constructor Executing");
            _fetchWeather = fetchWeather;
            _displayFahrenheit = false;
            _isPremiumMember = false;
            BasicForecastViewModel = basicWeatherViewModel;
        }

        public string DisplayOtherTemperatureScaleLong { get => !_displayFahrenheit ? "Fahrenheit" : "Celsius"; } 
        public string DisplayPremiumToggleMessage {get => _isPremiumMember ? "Change to Basic" : "Change to Premium"; }

        public void ToggleTemperatureScale()
        {
            _displayFahrenheit = !_displayFahrenheit;
            BasicForecastViewModel.ToggleTemperatureScale();
            
        }

        public void ToggleMembership()
        {
            _isPremiumMember = !_isPremiumMember;
        }

        public async Task RetrieveForecastsAsync(){
            Console.WriteLine("FetchDataViewModel.RetrieveForecastsAsync() executing");

            await _fetchWeather.RetrieveForecastAsync();
            List<IWeatherForecast> results = new List<IWeatherForecast>();
            foreach(var forecast in _fetchWeather.WeatherForecasts){
                var item = new WeatherForecast{
                    Date = forecast.Date,
                    Summary = forecast.Summary,
                    TemperatureC = forecast.TemperatureC
                };
                results.Add(item);
            }
            BasicForecastViewModel.WeatherForecasts = results.ToArray();
        }
    }
}