using System.Threading.Tasks;
using suggestPlaylist.Models;

namespace suggestPlaylist.Services
{
    public interface IOpenWeatherServices
    {

        Task<OpenWeatherModel> GetWeatherBasedOnLocation(string location);
        Task<OpenWeatherModel> GetWeatherBasedOnCoordinates(string lat, string lon);

    }
}
