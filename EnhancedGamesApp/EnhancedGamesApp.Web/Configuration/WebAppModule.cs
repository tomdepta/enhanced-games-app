using Autofac;
using EnhancedGamesApp.DAL.Repositories;

namespace EnhancedGamesApp.Web
{
    internal class WebAppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GameRepository>().As<IGameRepository>();
        }
    }
}