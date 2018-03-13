using EnhancedGamesApp.DAL.Repositories;
using FluentScheduler;

namespace EnhancedGamesApp.Console.Services.Schedule
{
    internal class UpdateGamesListJob : IJob
    {
        private IGameRepository _gameRepository;

        public UpdateGamesListJob(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}