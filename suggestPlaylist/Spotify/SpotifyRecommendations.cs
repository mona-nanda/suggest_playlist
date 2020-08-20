using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using suggestPlaylist.Models;

namespace suggestPlaylist.Spotify
{
    public class SpotifyRecommendations: ISpotifyRecommendations
    {   const string authCode = "BQBS1gQgD44_-OfTPa2E4zf-S9KZ_3aPWgEBwnG0kC40s2iIi_ehjuvWe9zxrk3b8hjT_34FDW-HRN2pDmy9shb9QuiXynHTTRgblAu59pv0X-wL5LQwy5wi1TTzwzWfP83tSz-WZKilcl7E0aOhwNUCGFU5h3Z_Wekl0MPH6lDxnHazUqnxZZIULjXfsabjf0erv4qFuhan5SKk7Yy-IB5BCYWsGIUbnFoCz43Iq4HI9RsCFOIBxsckAgHd_yuPLXHcbjaK7VAttLo5rfI-lOTfxIiwvA1v";
        public async Task<SpotifyModel> ReturnSpotifyRecommendation(string countryCode, string genre)
        {
            using var client = new HttpClient();
            var url = new Uri($"https://api.spotify.com/v1/recommendations?market={countryCode}&seed_genres={genre}");
            client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", authCode);
            var response = await client.GetAsync(url);
            string json;
            using (var content = response.Content)
            {
                json = await content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject<SpotifyModel>(json);

        }
    }
}
