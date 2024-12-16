using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using OpenWeather.Models;
using OpenWeather.Services;

namespace OpenWeather.ViewModel
{
    internal partial class AppViewModel : ObservableObject
    {
        WeatherResponse weatherResponse;
        AppService appService;

        [ObservableProperty]
        public string cityName;

        [ObservableProperty]
        public double lat;

        [ObservableProperty]
        public double lon;

        [ObservableProperty]
        public double temp;

        [ObservableProperty]
        public string main = null;

        [ObservableProperty]
        public string description = null;

        [ObservableProperty]
        public int humidity;

        [ObservableProperty]
        public string name = null;

        [ObservableProperty]
        public double feelsLike;

        [ObservableProperty]
        public double wind;

        [ObservableProperty]
        public string icone = null;

        [ObservableProperty]
        private bool visible = false;

        public AppViewModel()
        {
            appService = new AppService();
            buscarCommand = new Command(async () =>
            {
                if (!string.IsNullOrWhiteSpace(CityName))
                {
                    await getWeatherByCity();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("ERRO", "DIGITE O NOME DA CIDADE", "OK");
                }

            });
        }

        public ICommand buscarCommand { get; }

        public async Task getWeatherByCity()
        {
            weatherResponse = await appService.getWeatherbyCity(CityName);

            if (weatherResponse is not null)
            {
                Temp = weatherResponse.main.Temp;
                Main = weatherResponse.weather[0].Main;
                Lat = weatherResponse.coords.Lat;
                Lon = weatherResponse.coords.Lon;
                Description = weatherResponse.weather[0].Description;
                Humidity = weatherResponse.main.Humidity;
                Name = weatherResponse.Name;
                Wind = weatherResponse.wind.Speed;
                Visible = true;
            }
            else if (weatherResponse is null)
            {
            }
        }
    }
}
