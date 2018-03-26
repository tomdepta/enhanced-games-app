using System;
using Autofac.Extras.Moq;

namespace EnhancedGamesApp.Tests
{
    public class TestClass : IDisposable
    {
        public TestClass()
        {
            Automock = AutoMock.GetLoose();
        }

        protected AutoMock Automock;

        public void Dispose()
        {
            Automock?.Dispose();
        }
    }
}
