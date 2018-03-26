using System.Collections.Generic;
using EnhancedGamesApp.DAL.DTO;

namespace EnhancedGamesApp.Console.Services
{
    public interface IGamesListProvider
    {
        IEnumerable<Game> GetGamesList();
    }
}