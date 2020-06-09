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
    public static class PostSymptomsInfo
    {
        [FunctionName("PostSymptomsInfo")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestMessage req,
            ILogger log, ExecutionContext context)
        {
            try
            {
                SymptomsInfo symptomsInfo = await req.Content.ReadAsAsync<SymptomsInfo>();
                if (symptomsInfo == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
                bool dataRecorded = DbHelper.PostDataAsync(symptomsInfo, Constants.postSymptomsInfo);

                //bool qrcodeGenerated = Common.GenerateQRCode(symptomsInfo.GUID);
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
            catch(System.Exception ex)
            {
                log.LogInformation(ex.Message);
                return null;
            }
        }
    }
}
