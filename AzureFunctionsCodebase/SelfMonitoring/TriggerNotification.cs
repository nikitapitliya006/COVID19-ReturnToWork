using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using BackToWorkFunctions.Helper;
using BackToWorkFunctions.Model;
using System.Collections.Generic;

namespace BackToWorkFunctions
{
    public static class TriggerNotification
    {
        [FunctionName("TriggerNotification")]
        public static void Run([TimerTrigger("0 8 0 * * *"), Disable()]TimerInfo myTimer, ILogger log)
        {
            SendNotificationToAllRegisteredUsers();            
        }

        public static async void SendNotificationToAllRegisteredUsers()
        {
            List<UserContactInfo> userContactInfoCollector = new List<UserContactInfo>();
            DbHelper.GetUserContactInfo(userContactInfoCollector);

            string sendgridApi = Environment.GetEnvironmentVariable("SendGrid_APIKEY", EnvironmentVariableTarget.Process);
            string assessmentLink = Environment.GetEnvironmentVariable("AssessmentBotLink", EnvironmentVariableTarget.Process);
            foreach (UserContactInfo userContact in userContactInfoCollector)
            {
                try
                {
                    await Common.SendEmail(userContact.EmailAddress, "admin@contosohealthsystem.onmicrosoft.com", "Contoso Health System Admin", userContact.FullName, assessmentLink, sendgridApi);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    continue;
                }
            }
        }
    }
}
