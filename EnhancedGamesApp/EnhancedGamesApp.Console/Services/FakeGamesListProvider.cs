using System.Collections.Generic;
using EnhancedGamesApp.DAL.DTO;

namespace EnhancedGamesApp.Console.Services
{
    internal class FakeGamesListProvider : IGamesListProvider
    {
        public IEnumerable<Game> GetGamesList()
        {
            return new List<Game>
            {
                new Game{ Title = "Wolfenstein 3D", Publisher = "IdSoftware", FourKConfirmed = true, HdrRenderingAvailable = true, AvailableNow = true},
                new Game{ Title = "FIFA 18", Publisher = "EA Sports", FourKConfirmed = true, HdrRenderingAvailable = false, AvailableNow = false},
                new Game{ Title = "Heroes of Might & Magic 3", Publisher = "3DO", FourKConfirmed = false, HdrRenderingAvailable = true, AvailableNow = true}
            };
        }
    }
}
