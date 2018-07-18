using EnhancedGamesApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnhancedGamesApp.DAL
{
    public class EnhancedGamesAppDbContext : DbContext
    {
        public EnhancedGamesAppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Game> Games { get; set; }
    }
}
