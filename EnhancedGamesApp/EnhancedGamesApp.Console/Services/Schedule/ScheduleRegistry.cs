using System.Collections.Generic;
using System.Linq;
using FluentScheduler;

namespace EnhancedGamesApp.Console.Services.Schedule
{
    internal class ScheduleRegistry : Registry
    {
        public ScheduleRegistry(IEnumerable<IJob> jobs)
        {
            jobs.ToList().ForEach(x => Schedule(x).ToRunEvery(10).Seconds());
        }
    }
}