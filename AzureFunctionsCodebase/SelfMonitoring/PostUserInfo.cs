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
using Microsoft.Extensions.Configuration;
using BackToWorkFunctions.Helper;

namespace BackToWorkFunctions
{
    public static class PostUserInfo
    {
        [FunctionName("PostUserInfo")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestMessage req,
            ILogger log, ExecutionContext context)
        {
            try
            {
                if(req == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                UserInfo userInfo = await req.Content.ReadAsAsync<UserInfo>();
                if (userInfo == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
                bool dataRecorded = DbHelper.PostDataAsync(userInfo, Constants.postUserInfo);

                if (dataRecorded)
                {                    
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
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
