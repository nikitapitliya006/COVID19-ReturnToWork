using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using BackToWorkFunctions.Helper;
using BackToWorkFunctions.Model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BackToWorkFunctions
{
    public static class TriggerNotification
    {
        [Disable]
        [FunctionName("TriggerNotification")]
        public static ActionResult Run([TimerTrigger("0 8 0 * * *")]TimerInfo myTimer, ILogger log)
        {            
            try
            {
                string errorMessage;
                if (myTimer == null)
                {
                    return new BadRequestObjectResult("Error: Timer object missing");
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
                    return new OkObjectResult("Status: OK");
                }
                errorMessage = "Error in getting User details";
                return new BadRequestObjectResult(errorMessage);
            }
            catch (ArgumentNullException argNullEx)
            {
                log.LogInformation(argNullEx.Message);
                return new BadRequestObjectResult("Error: Writing to database was not complete");
            }
            catch (Newtonsoft.Json.JsonSerializationException serializeEx)
            {
                log.LogInformation(serializeEx.Message);
                return new BadRequestObjectResult("Error: Incorrect payload");
            }
            catch (SqlException sqlEx)
            {
                log.LogInformation(sqlEx.Message);
                return new BadRequestObjectResult("Error: Writing to database was not complete");
            }
            catch (Exception ex)
            {
                log.LogInformation(ex.Message);
                return new BadRequestObjectResult("Error: Something went wrong, could not save your details");
            }
        }
    }
}
