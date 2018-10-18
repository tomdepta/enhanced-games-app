using EnhancedGamesApp.DAL.Entities;
using EnhancedGamesApp.Shared.Extensions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace EnhancedGamesApp.Shared.Services.Providers
{
    public class WebGamesListProvider : IGamesListProvider
    {
        private const string RootPropertyName = "headings";

        private const string GameTitle = "Game Title";
        private const string Publisher = "Publisher";
        private const string FourK = "4K";
        private const string Hdr = "HDR";
        private const string Availability = "Availability";

        private const string KeySuffix = "urlhttp";
        private const char HtmlOpeningTag = '<';

        private readonly IConfiguration _configuration;
        private readonly string _listJsonUrl;

        public WebGamesListProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            _listJsonUrl = _configuration["GameListUrl"];
        }

        public IEnumerable<Game> GetGamesList()
        {
            var client = new RestClient(_listJsonUrl);
            var response = client.Execute(new RestRequest(Method.GET));

            var trimmedContent = TrimResponseContent(response.Content);
            var json = JObject.Parse(trimmedContent);
            
            var keys = JObject.Parse(json[RootPropertyName][GameTitle].ToString())
                .Properties()
                .Select(p => p.Name);

            var gameList = keys.Select(key => new Game
                {
                    Key = TrimKey(key),
                    Title = TrimTitle(json[RootPropertyName][GameTitle][key].ToString()),
                    Publisher = json[RootPropertyName][Publisher][key].ToString(),
                    FourKConfirmed = IsFourK(json[RootPropertyName][FourK][key].ToString()),
                    HdrRenderingAvailable = IsHdr(json[RootPropertyName][Hdr][key].ToString()),
                    Status = GetAvailabilityStatus(json[RootPropertyName][Availability][key].ToString())
                })
                .ToList();

            gameList.ForEach(g => g.Key = $"{g.Key}{g.Publisher}".RemoveSpecialCharacters().ToLower());

            return gameList;
        }

        private static string TrimTitle(string title)
        {
            return title.Contains(HtmlOpeningTag) ? title.Substring(0, title.IndexOf(HtmlOpeningTag)) : title;
        }

        private static string TrimKey(string key)
        {
            return key.Contains(KeySuffix) ? key.Substring(0, key.IndexOf(KeySuffix)) : key;
        }

        private static string TrimResponseContent(string content)
        {
            return content.Substring(content.IndexOf('{'));
        }

        private static bool IsFourK(string description)
        {
            return description == "4";
        }

        private static bool IsHdr(string description)
        {
            return description == "H";
        }

        private static AvailabilityStatus GetAvailabilityStatus(string description)
        {
            switch (description)
            {
                case "1":
                    return AvailabilityStatus.AvailableNow;
                case "2":
                    return AvailabilityStatus.ComingSoon;
                case "3":
                    return AvailabilityStatus.InDevelopment;
                default:
                    return AvailabilityStatus.Unknown;
            }
        }
    }
}
