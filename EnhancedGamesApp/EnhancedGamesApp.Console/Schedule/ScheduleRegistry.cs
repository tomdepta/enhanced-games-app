using FluentScheduler;
using System.Collections.Generic;
using System.Linq;

namespace EnhancedGamesApp.Console.Schedule
{
    internal class ScheduleRegistry : Registry
    {
        public ScheduleRegistry(IEnumerable<IJob> jobs)
        {
            jobs.ToList().ForEach(x => Schedule(x).ToRunNow().AndEvery(600).Seconds());
        }
    }
}