using System.Threading.Tasks;
using suggestPlaylist.Models;
using suggestPlaylist.OpenWeather;

namespace suggestPlaylist.Services
{
    public class OpenWeatherServices: IOpenWeatherServices
    {
        private static IOpenWeather _getWeather;
        public OpenWeatherServices(IOpenWeather getWeather)
        {
            _getWeather = getWeather;
        }
        public async Task<OpenWeatherModel> GetWeatherBasedOnLocation(string location)
        {
            return await _getWeather.ReturnWeatherBasedOnLocationAsync(location);
        }
        public async Task<OpenWeatherModel> GetWeatherBasedOnCoordinates(string lat, string lon)
        {
            return await _getWeather.ReturnWeatherBasedOnCoordinatesAsync(lat,lon);
        }
    }
}
