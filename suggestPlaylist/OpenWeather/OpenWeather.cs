using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using suggestPlaylist.Models;

namespace suggestPlaylist.OpenWeather
{
    public class OpenWeather : IOpenWeather
    {
        const string apikey = "b77e07f479efe92156376a8b07640ced";
        public async Task<OpenWeatherModel> ReturnWeatherBasedOnCoordinatesAsync(string lat, string lon)
        {
            using var client = new HttpClient();
            var url = new Uri($"http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apikey}");

            var response = await client.GetAsync(url);

            string json;
            using (var content = response.Content)
            {
                json = await content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<OpenWeatherModel>(json);
        }

        public async Task<OpenWeatherModel> ReturnWeatherBasedOnLocationAsync(string location)
        {
            using var client = new HttpClient();
            var url = new Uri($"http://api.openweathermap.org/data/2.5/weather?q={location}&appid={apikey}");

            var response = await client.GetAsync(url);

            string json;
            using (var content = response.Content)
            {
                json = await content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<OpenWeatherModel>(json);
        }
    }
}
