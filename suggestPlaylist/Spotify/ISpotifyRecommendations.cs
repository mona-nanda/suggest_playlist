using System;
using System.Threading.Tasks;
using suggestPlaylist.Models;

namespace suggestPlaylist.Spotify
{
    public interface ISpotifyRecommendations
    {
        Task<SpotifyModel> ReturnSpotifyRecommendation(string countryCode, string genre);
    }
}
