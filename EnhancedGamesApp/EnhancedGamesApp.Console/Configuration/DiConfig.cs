using Autofac;
using EnhancedGamesApp.Console.Services.Schedule;
using FluentScheduler;

namespace EnhancedGamesApp.Console.Configuration
{
    public class DiConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UpdateGamesListJob>().As<IJob>();
            builder.RegisterType<ScheduleRegistry>().As<Registry>();
        }
    }
}
