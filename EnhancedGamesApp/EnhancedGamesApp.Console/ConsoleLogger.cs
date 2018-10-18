using System;
using Microsoft.Extensions.Logging;

namespace EnhancedGamesApp.Console
{
    class ConsoleLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            System.Console.WriteLine($"{logLevel.ToString().ToUpper()}: {formatter(state, exception)}");
        }
    }
}
