using System;
using System.Threading.Tasks;
using suggestPlaylist.Models;

namespace suggestPlaylist.Services
{
    public interface ISpotifyServices
    {
        Task<SpotifyModel> SpotifyRecommendation(string countryCode, string genre);
    }
}
