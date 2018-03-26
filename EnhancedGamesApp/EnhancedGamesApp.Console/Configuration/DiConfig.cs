using Autofac;
using EnhancedGamesApp.Console.Services;
using EnhancedGamesApp.Console.Services.Schedule;
using EnhancedGamesApp.DAL.Repositories;
using FluentScheduler;

namespace EnhancedGamesApp.Console.Configuration
{
    public class DiConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GameRepository>().As<IGameRepository>();
            builder.RegisterType<FakeGamesListProvider>().As<IGamesListProvider>();
            builder.RegisterType<UpdateGamesListJob>().As<IJob>();
            builder.RegisterType<ScheduleRegistry>().As<Registry>();
        }
    }
}
