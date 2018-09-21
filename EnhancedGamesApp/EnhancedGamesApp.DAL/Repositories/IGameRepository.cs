using System.Collections.Generic;
using System.Threading.Tasks;
using EnhancedGamesApp.DAL.Entities;

namespace EnhancedGamesApp.DAL.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetGamesAsync();

        Task AddGamesAsync(IEnumerable<Game> gamesToAdd);

        Task UpdateGamesAsync(IEnumerable<Game> gamesToUpdate);

        Task EnsureSaved();
    }
}
