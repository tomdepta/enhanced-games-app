﻿using System.IO;
using Autofac;
using EnhancedGamesApp.Console.Services;
using EnhancedGamesApp.Console.Services.Schedule;
using EnhancedGamesApp.DAL;
using EnhancedGamesApp.DAL.Repositories;
using FluentScheduler;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EnhancedGamesApp.Console.Configuration
{
    public class DiConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var configuration = InitializeConfigurationFile(builder);
            builder.RegisterType<GameRepository>().As<IGameRepository>();
            builder.RegisterType<WebGamesListProvider>().As<IGamesListProvider>();
            builder.RegisterType<UpdateGamesListJob>().As<IJob>();
            builder.RegisterType<ScheduleRegistry>().As<Registry>();

            RegisterDbContext(builder, configuration["EnhancedGamesAppConnectionString"]);
        }

        private IConfigurationRoot InitializeConfigurationFile(ContainerBuilder builder)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = configBuilder.Build();
            builder.RegisterInstance(configuration).As<IConfiguration>();
            return configuration;
        }

        private void RegisterDbContext(ContainerBuilder builder, string connectionString)
        {
            var options = new DbContextOptionsBuilder<EnhancedGamesAppDbContext>()
                .UseSqlServer(connectionString,
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(EnhancedGamesAppDbContext).Assembly.FullName);
                    }).Options;

            builder.Register(c => new EnhancedGamesAppDbContext(options)).As<EnhancedGamesAppDbContext>();
        }
    }
}
