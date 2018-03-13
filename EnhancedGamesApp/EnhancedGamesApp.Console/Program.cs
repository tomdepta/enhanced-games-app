using Autofac;
using EnhancedGamesApp.Console.Configuration;
using FluentScheduler;

namespace EnhancedGamesApp.Console
{
    class Program
    {
        static void Main()
        {
            SetupApplication();
            System.Console.ReadLine();
        }

        private static void SetupApplication()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<DiConfig>();
            var container = builder.Build();
            JobManager.Initialize(container.Resolve<Registry>());
        }
    }
}
