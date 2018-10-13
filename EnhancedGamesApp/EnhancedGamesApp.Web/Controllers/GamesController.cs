using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnhancedGamesApp.DAL.Entities;
using EnhancedGamesApp.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnhancedGamesApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : Controller
    {
        private IGameRepository _repository;

        public GamesController(IGameRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<Game>> GetGamesListAsync()
        {
            return await _repository.GetGamesAsync();
        }

        // GET api/<controller>/key
        [HttpGet("{key}")]
        public async Task<Game> GetByKeyAsync(string key)
        {
            return (await _repository.GetGamesAsync()).SingleOrDefault(g => g.Key == key);
        }
    }
}
