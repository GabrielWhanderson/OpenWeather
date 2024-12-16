using OpenWeather.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenWeather.Services
{
    internal class AppService
    {
        private HttpClient httpClient;
        private string ApiKey = "f62f1151ce5f0e73bbb03fcde69d956b";
        private string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";
        public WeatherResponse weatherResponse;
        private JsonSerializerOptions jsonSerializerOptions;

        public AppService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
            };
        }
        public async Task<WeatherResponse?> getWeatherbyCity(string cityName)
        {
            var url = $"{BaseUrl}?q={cityName}&appid={ApiKey}&units=metric&lang=pt";
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var weatherResponse = JsonSerializer.Deserialize<WeatherResponse>(content, jsonSerializerOptions);
                    if (weatherResponse == null)
                    {
                        Debug.WriteLine("A deserialização retornou nulo.");
                    }
                    return weatherResponse;
                }
                else
                {
                    Debug.WriteLine($"Falha ao chamar a API. Código de status: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao fazer a chamada da API: {ex.Message}");
            }

            return null;
        }

    }
}
