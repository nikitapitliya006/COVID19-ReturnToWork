using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using BackToWorkFunctions.Model;
using System.Data.SqlClient;
using System.Text;
using BackToWorkFunctions.Helper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace BackToWorkFunctions
{
    public static class GetSymptomsInfo
    {
        [FunctionName("GetSymptomsInfo")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetSymptomsInfo/{UserId}")] HttpRequest req, string UserId,
            ILogger log, ExecutionContext context)
        {
            
            if (UserId == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            try
            {
                List<SymptomsInfo> lstsymptomsInfo = await DbHelper.GetDataAsync<List<SymptomsInfo>>(Constants.getSymptomsInfo, UserId);
                if (lstsymptomsInfo == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                log.LogInformation(JsonConvert.SerializeObject(lstsymptomsInfo));

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(lstsymptomsInfo), Encoding.UTF8, "application/json")
                };
            }
            catch(System.Exception ex)
            {
                log.LogInformation(ex.Message);
                return null;
            }
        }
    }
}
