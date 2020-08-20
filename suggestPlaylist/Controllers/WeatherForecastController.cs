using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using suggestPlaylist.Models;
using suggestPlaylist.Services;

namespace suggestPlaylist.Controllers
{
    [ApiController]
    [Route("v1/suggest/playlist/{location}")]
    [Route("v1/suggest/playlist/{lat}/{lon}")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IOpenWeatherServices _openWeatherServices;
        private readonly ISpotifyServices _spotifyServices;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOpenWeatherServices openWeatherServices, ISpotifyServices spotifyServices)
        {
            _logger = logger;
            _openWeatherServices = openWeatherServices;
            _spotifyServices = spotifyServices;

        }

        [HttpGet]
        public async Task<WeatherForecast> Get(string location=null, string lat=null, string lon=null)
        {
            var weatherResult = (OpenWeatherModel)null;
            var reco = (SpotifyModel)null;
            List<string> tracks = new List<string>();

            if (location != null)
            {
                weatherResult = await _openWeatherServices.GetWeatherBasedOnLocation(location);
            }
            else
            {
                weatherResult = await _openWeatherServices.GetWeatherBasedOnCoordinates(lat, lon);
            }
            var TemperatureC = (int)((int)weatherResult.Main.Temp - 273.15);
            if (TemperatureC < 10)
            {
                reco = await _spotifyServices.SpotifyRecommendation(weatherResult.Sys.Country, "Classical");
            }
            else if ((TemperatureC >= 10) && (TemperatureC <= 14))
            {
                reco = await _spotifyServices.SpotifyRecommendation(weatherResult.Sys.Country, "rock");
            }
            else if ((TemperatureC >= 15) && (TemperatureC <= 30))
            {
                reco = await _spotifyServices.SpotifyRecommendation(weatherResult.Sys.Country, "pop");
            }
            else
            {
                reco = await _spotifyServices.SpotifyRecommendation(weatherResult.Sys.Country, "party");
            }
            foreach (var recommendation in reco.tracks)
            {
                tracks.Add(recommendation.name);
            }
            return new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = TemperatureC,
                Tracks = tracks,
            };
        }

    }
}
