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
            var newGame = new Game {Key = "test2"};

            var cachedGames = new List<Game>
            {
                new Game {Key = "test1"}
            };
            var gamesFromProvider = new List<Game>
            {
                new Game {Key = "test1"},
                newGame
            };

            Automock.Mock<IGameRepository>().Setup(x => x.GetGames()).Returns(cachedGames);
            Automock.Mock<IGamesListProvider>().Setup(x => x.GetGamesList()).Returns(gamesFromProvider);

            // when
            mockJob.Execute();

            // then
            Automock.Mock<IGameRepository>().Verify(x => x.AddGames(It.Is<IEnumerable<Game>>(z => z.All(y => y.Equals(newGame)))));
        }

        [Fact]
        public void ShouldUpdateExistingGames_WhenEnhancementParametersChanged()
        {
            // given
            var mockJob = Automock.Create<UpdateGamesListJob>();
            var changedGames = new List<Game>
            {
                new Game {Title = "test2", FourKConfirmed = true},
                new Game {Title = "test3", HdrRenderingAvailable = true},
                new Game {Title = "test4", Status = AvailabilityStatus.AvailableNow},
            };

            var cachedGames = new List<Game>
            {
                new Game {Title = "test1" },
                new Game {Title = "test2", FourKConfirmed = false},
                new Game {Title = "test3", HdrRenderingAvailable = false},
                new Game {Title = "test4", Status = AvailabilityStatus.ComingSoon},
            };
            var gamesFromProvider = new List<Game>
            {
                new Game {Title = "test1"},
                new Game {Title = "test2", FourKConfirmed = true},
                new Game {Title = "test3", HdrRenderingAvailable = true},
                new Game {Title = "test4", Status = AvailabilityStatus.AvailableNow},
            };

            Automock.Mock<IGameRepository>().Setup(x => x.GetGames()).Returns(cachedGames);
            Automock.Mock<IGamesListProvider>().Setup(x => x.GetGamesList()).Returns(gamesFromProvider);

            // when
            mockJob.Execute();

            // then
            Automock.Mock<IGameRepository>().Verify(x => x.UpdateGames(It.Is<IEnumerable<Game>>(z => z.SequenceEqual(changedGames))));
        }
    }
}
