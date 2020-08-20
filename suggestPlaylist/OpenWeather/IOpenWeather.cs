using System;
using System.Threading.Tasks;
using suggestPlaylist.Models;

namespace suggestPlaylist.OpenWeather
{
    public interface IOpenWeather
    {
        Task<OpenWeatherModel> ReturnWeatherBasedOnLocationAsync(string location);
        Task<OpenWeatherModel> ReturnWeatherBasedOnCoordinatesAsync(string lat, string lon);
    }
}
