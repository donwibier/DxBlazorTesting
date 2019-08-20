using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazor.MVVM.Shared.ViewModels;
using Blazor.MVVM.Shared.Services;
using Blazor.MVVM.Client.Services;

namespace Blazor.MVVM.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IFetchDataViewModel, FetchDataViewModel>();
            services.AddTransient<IFetchWeatherService, FetchWeatherService>();
            services.AddTransient<IBasicFetchWeatherViewModel, BasicFetchWeatherViewModel>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
