using System.Collections.Generic;
using System.Linq;
using EnhancedGamesApp.Console.Services;
using EnhancedGamesApp.Console.Services.Schedule;
using EnhancedGamesApp.DAL.DTO;
using EnhancedGamesApp.DAL.Repositories;
using Moq;
using Xunit;

namespace EnhancedGamesApp.Tests.ConsoleAppTests.UpdateGamesListJobTest
{
    public class ExecuteTests : TestClass
    {
        [Fact]
        public void ShouldCallGamesListProviderForListOfGames_WhenIsExecuting()
        {
            // given
            var mockJob = Automock.Create<UpdateGamesListJob>();

            // when
            mockJob.Execute();

            // then
            Automock.Mock<IGamesListProvider>().Verify(x => x.GetGamesList());
        }

        [Fact]
        public void ShouldGetCachedGamesListFromRepository_WhenIsExecuting()
        {
            // given
            var mockJob = Automock.Create<UpdateGamesListJob>();

            // when
            mockJob.Execute();

            // then
            Automock.Mock<IGameRepository>().Verify(x => x.GetGames());
        }

        [Fact]
        public void ShouldInsertGamesToRepository_WhenProviderReturnsNewGames()
        {
            // given
            var mockJob = Automock.Create<UpdateGamesListJob>();
            var newGame = new Game {Title = "test2"};

            var cachedGames = new List<Game>
            {
                new Game {Title = "test1"}
            };
            var gamesFromProvider = new List<Game>
            {
                new Game {Title = "test1"},
                newGame
            };

            Automock.Mock<IGameRepository>().Setup(x => x.GetGames()).Returns(cachedGames);
            Automock.Mock<IGamesListProvider>().Setup(x => x.GetGamesList()).Returns(gamesFromProvider);

            // when
            mockJob.Execute();

            // then
            Automock.Mock<IGameRepository>().Verify(x => x.AddGames(It.Is<IEnumerable<Game>>(z => z.All(y => y.Equals(newGame)))));
        }
    }
}
