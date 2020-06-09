using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using BackToWorkFunctions.Helper;
using BackToWorkFunctions.Model;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Net.Http;
using System.Web.Http;

namespace BackToWorkFunctions
{
    public static class TriggerNotification
    {
        //[Disable]
        [FunctionName("TriggerNotification")]
        public static void Run([TimerTrigger("0 8 0 * * *")]TimerInfo myTimer, ILogger log)
        {
            try
            {
                List<UserContactInfo> userContactInfoCollector = new List<UserContactInfo>();
                bool userContactsRetrieved = DbHelper.GetUserContactInfo(userContactInfoCollector);
                if (userContactsRetrieved)
                {
                    string sendgridApi = Environment.GetEnvironmentVariable("SendGrid_APIKEY", EnvironmentVariableTarget.Process);
                    string assessmentLink = Environment.GetEnvironmentVariable("AssessmentBotLink", EnvironmentVariableTarget.Process);
                    foreach (UserContactInfo userContact in userContactInfoCollector)
                    {
                        Common.SendEmail(userContact.EmailAddress, "admin@contosohealthsystem.onmicrosoft.com", "Contoso Health System Admin",
                            userContact.FullName, assessmentLink, sendgridApi);
                    }
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
