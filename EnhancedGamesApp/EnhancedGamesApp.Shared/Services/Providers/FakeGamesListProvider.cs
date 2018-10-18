using EnhancedGamesApp.DAL.Entities;
using System.Collections.Generic;

namespace EnhancedGamesApp.Shared.Services.Providers
{
    internal class FakeGamesListProvider : IGamesListProvider
    {
        public IEnumerable<Game> GetGamesList()
        {
            return new List<Game>
            {
                new Game
                {
                    Title = "Wolfenstein 3D",
                    Publisher = "IdSoftware",
                    FourKConfirmed = true,
                    HdrRenderingAvailable = true,
                    Status = AvailabilityStatus.AvailableNow
                },
                new Game
                {
                    Title = "FIFA 18",
                    Publisher = "EA Sports",
                    FourKConfirmed = true,
                    HdrRenderingAvailable = false,
                    Status = AvailabilityStatus.ComingSoon
                },
                new Game
                {
                    Title = "Heroes of Might & Magic 3",
                    Publisher = "3DO",
                    FourKConfirmed = false,
                    HdrRenderingAvailable = true,
                    Status = AvailabilityStatus.InDevelopment
                }
            };
        }
    }
}
