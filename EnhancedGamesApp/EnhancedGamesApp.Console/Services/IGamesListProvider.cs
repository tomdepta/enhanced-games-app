using System.Collections.Generic;
using EnhancedGamesApp.DAL.Entities;

namespace EnhancedGamesApp.Console.Services
{
    public interface IGamesListProvider
    {
        IEnumerable<Game> GetGamesList();
    }
}