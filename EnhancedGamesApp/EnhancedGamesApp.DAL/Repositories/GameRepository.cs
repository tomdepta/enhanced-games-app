using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnhancedGamesApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnhancedGamesApp.DAL.Repositories
{
    public class GameRepository : IGameRepository
    {
        private EnhancedGamesAppDbContext _context;

        public GameRepository(EnhancedGamesAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task AddGamesAsync(IEnumerable<Game> gamesToAdd)
        {
            await _context.Games.AddRangeAsync(gamesToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGamesAsync(IEnumerable<Game> gamesToUpdate)
        {
                _context.UpdateRange(gamesToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task EnsureSaved()
        {
            await _context.SaveChangesAsync();
        }
    }
}
