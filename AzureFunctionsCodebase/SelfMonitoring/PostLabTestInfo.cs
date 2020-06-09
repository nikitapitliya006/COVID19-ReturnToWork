using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using BackToWorkFunctions.Model;
using System.Data.SqlClient;
using BackToWorkFunctions.Helper;

namespace BackToWorkFunctions
{
    public static class PostLabTestInfo
    {
        [FunctionName("PostLabTestInfo")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestMessage req,
            ILogger log, ExecutionContext context)
        {
            try
            {
                LabTestInfo labTestInfo = await req.Content.ReadAsAsync<LabTestInfo>();
                if (labTestInfo == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                bool dataRecorded = DbHelper.PostDataAsync(labTestInfo, Constants.postLabTestInfo);

                if (dataRecorded)
                {
                    log.LogInformation("Data recorded");
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                log.LogInformation(ex.Message);
                throw new Exception(ex.ToString());
            }            
        }
    }
}
