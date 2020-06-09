using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using BackToWorkFunctions.Helper;
using BackToWorkFunctions.Model;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace BackToWorkFunctions
{
    public static class TriggerTeamsNotification
    {
        [Disable]
        [FunctionName("TriggerTeamsNotification")]
        public static void Run([TimerTrigger("0 8 0 * * *")]TimerInfo myTimer, ILogger log)
        {
            List<TeamsAddressQuarantineInfo> teamsAddressQuarantineInfoCollector = new List<TeamsAddressQuarantineInfo>();
            bool userTeamsAddressReceived = DbHelper.GetTeamsAddress(teamsAddressQuarantineInfoCollector);
            if (userTeamsAddressReceived)
            {
                foreach (var element in teamsAddressQuarantineInfoCollector)
                {
                    ProgrammaticTrigger.PostTriggerToAllRegisteredTeamsClients(element.TeamsAddress);
                }
            }            
        }        
    }
}
