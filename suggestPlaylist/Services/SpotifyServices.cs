using System;
using System.Threading.Tasks;
using suggestPlaylist.Models;
using suggestPlaylist.Spotify;

namespace suggestPlaylist.Services
{
    public class SpotifyServices: ISpotifyServices
    {
        private static ISpotifyRecommendations _getReco;
        public SpotifyServices(ISpotifyRecommendations getReco)
        {
            _getReco = getReco;
        }
        public async Task<SpotifyModel> SpotifyRecommendation(string countryCode, string genre)
        {   
            return await _getReco.ReturnSpotifyRecommendation(countryCode, genre);
        }
    }
}
