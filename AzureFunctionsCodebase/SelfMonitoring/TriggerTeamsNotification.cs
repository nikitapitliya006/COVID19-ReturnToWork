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
            string errorMessage;
            try
            {
                if (myTimer == null)
                {
                    errorMessage = "Null timer argument";
                    throw new ArgumentNullException(errorMessage);
                }

                if (myTimer.IsPastDue)
                {
                    errorMessage = "Timer is running late!";
                    log.LogInformation(errorMessage);
                }
                log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

                List<TeamsAddressQuarantineInfo> teamsAddressQuarantineInfoCollector = new List<TeamsAddressQuarantineInfo>();
                bool userTeamsAddressReceived = DbHelper.GetTeamsAddress(teamsAddressQuarantineInfoCollector);
                if (userTeamsAddressReceived)
                {
                    foreach (var element in teamsAddressQuarantineInfoCollector)
                    {
                        await ProgrammaticTrigger.PostTriggerToAllRegisteredTeamsClients(element.TeamsAddress).ConfigureAwait(false);
                    }
                }
                else
                {
                    errorMessage = "Error in getting User's MS Teams details";
                    throw new Exception(errorMessage);
                }
            }
            catch (ArgumentNullException argNullEx)
            {
                log.LogInformation(argNullEx.Message);
                throw new ArgumentNullException(argNullEx.Message);
            }
            catch (Exception ex)
            {
                log.LogInformation(ex.Message);
                throw new Exception(ex.Message);
            }
        }        
    }
}
