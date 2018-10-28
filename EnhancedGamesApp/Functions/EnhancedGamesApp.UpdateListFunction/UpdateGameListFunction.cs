using System;
using EnhancedGamesApp.DAL;
using EnhancedGamesApp.DAL.Repositories;
using EnhancedGamesApp.Shared.Services.Jobs;
using EnhancedGamesApp.Shared.Services.Providers;
using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EnhancedGamesApp.UpdateListFunction
{
    public static class UpdateGameListFunction
    {
        private static IConfigurationRoot _config;

        [FunctionName("UpdateGameListFunction")]
        public static void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log, ExecutionContext context)
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(context.FunctionAppDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var repository = CreateRepository();

            var job = new UpdateGamesListJob(
                repository,
                new WebGamesListProvider(_config["GameListUrl"]),
                log
            );

            job.Execute();
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }

        private static GameRepository CreateRepository()
        {
            var options = new DbContextOptionsBuilder<EnhancedGamesAppDbContext>()
                .UseSqlServer(_config.GetConnectionString("EnhancedGamesAppConnectionString"),
                    sqlOptions => { sqlOptions.MigrationsAssembly(typeof(EnhancedGamesAppDbContext).Assembly.FullName); })
                .Options;

            var repository = new GameRepository(new EnhancedGamesAppDbContext(options));
            return repository;
        }
    }
}
