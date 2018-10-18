using EnhancedGamesApp.DAL.Entities;
using System.Collections.Generic;

namespace EnhancedGamesApp.Shared.Services.Providers
{
    public interface IGamesListProvider
    {
        IEnumerable<Game> GetGamesList();
    }
}