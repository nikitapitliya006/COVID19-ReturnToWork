using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using BackToWorkFunctions.Helper;
using BackToWorkFunctions.Model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace BackToWorkFunctions
{
    public static class TriggerNotification
    {
        [Disable]
        [FunctionName("TriggerNotification")]
        public static void RunAsync([TimerTrigger("0 8 0 * * *")]TimerInfo myTimer, ILogger log)
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

                List<UserContactInfo> userContactInfoCollector = new List<UserContactInfo>();
                bool userContactsRetrieved = DbHelper.GetUserContactInfo(userContactInfoCollector);
                if (userContactsRetrieved)
                {
                    string sendgridApi = Environment.GetEnvironmentVariable("SendGrid_APIKEY", EnvironmentVariableTarget.Process);
                    string assessmentLink = Environment.GetEnvironmentVariable("AssessmentBotLink", EnvironmentVariableTarget.Process);
                    foreach (UserContactInfo userContact in userContactInfoCollector)
                    {
                        NotificationHelper.SendEmail(userContact.EmailAddress, "admin@contosohealthsystem.onmicrosoft.com", "Contoso Health System Admin",
                            assessmentLink, sendgridApi);
                    }
                }
                errorMessage = "Error in getting User details";
                throw new Exception(errorMessage);
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
