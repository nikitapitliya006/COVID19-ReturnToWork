using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using BackToWorkFunctions.Helper;

namespace BackToWorkFunctions
{
    public static class TriggerTeamsNotification
    {
        [Disable]
        [FunctionName("TriggerTeamsNotification")]
        public static void Run([TimerTrigger("0 8 0 * * *")]TimerInfo myTimer, ILogger log)
        {
            ProgrammaticTrigger.GetTeamsAddressFromSqlAndPostTrigger();            
        }        
    }
}
