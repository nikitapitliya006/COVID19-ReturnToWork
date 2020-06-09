using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using BackToWorkFunctions.Helper;
using BackToWorkFunctions.Model;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace BackToWorkFunctions
{
    public static class TriggerTeamsNotification
    {
        [Disable]
        [FunctionName("TriggerTeamsNotification")]
        public static async Task Run([TimerTrigger("0 8 0 * * *")]TimerInfo myTimer, ILogger log)
        {
            try
            {
                List<TeamsAddressQuarantineInfo> teamsAddressQuarantineInfoCollector = new List<TeamsAddressQuarantineInfo>();
                bool userTeamsAddressReceived = DbHelper.GetTeamsAddress(teamsAddressQuarantineInfoCollector);
                if (userTeamsAddressReceived)
                {
                    foreach (var element in teamsAddressQuarantineInfoCollector)
                    {
                        await ProgrammaticTrigger.PostTriggerToAllRegisteredTeamsClients(element.TeamsAddress);
                    }
                }
                else
                {
                    log.LogInformation("Error executing TriggerTeamsNotification at DbHelper.GetTeamsAddress()\n");
                }
            }
            catch(Exception ex)
            {
                log.LogInformation(ex.Message);
                throw new Exception(ex.ToString());
            }
        }        
    }
}
