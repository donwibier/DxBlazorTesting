using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.MVVM.Shared.Models;
using Blazor.MVVM.Shared.Services;

namespace Blazor.MVVM.Shared.ViewModels
{
    public interface IBasicFetchWeatherViewModel
    {
        string DisplayTemperatureScaleShort { get; }
        IWeatherForecast[] WeatherForecasts { get; set; }
        

        int DisplayTemperature(int temperature);
        void ToggleTemperatureScale();

    }

    public class BasicFetchWeatherViewModel : IBasicFetchWeatherViewModel
    {
        private IWeatherForecast[] _weatherForecasts;
        private bool _displayFahrenheit;

        public BasicFetchWeatherViewModel(){
            _displayFahrenheit = false;
        }        

        public IWeatherForecast[] WeatherForecasts { get => _weatherForecasts; set => _weatherForecasts = value; }

        public string DisplayTemperatureScaleShort { get => _displayFahrenheit ? "F" : "C"; }

        public int DisplayTemperature(int temperature)
        {
            return _displayFahrenheit ? 32 + (int)(temperature / 0.5556) : temperature;
        }

        public void ToggleTemperatureScale()
        {
            _displayFahrenheit = !_displayFahrenheit;
        }
    }
}