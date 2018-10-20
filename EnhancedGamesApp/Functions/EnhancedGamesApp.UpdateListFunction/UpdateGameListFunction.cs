using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace EnhancedGamesApp.UpdateListFunction
{
    public static class UpdateGameListFunction
    {
        [FunctionName("UpdateGameListFunction")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
