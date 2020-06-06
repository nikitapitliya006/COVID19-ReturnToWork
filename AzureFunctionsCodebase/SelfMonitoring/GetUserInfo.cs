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

namespace BackToWorkFunctions
{
    public static class GetUserInfo
    {
        [FunctionName("GetUserInfo")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetUserInfo/{UserId}")] HttpRequest req, string UserId,
            ILogger log, ExecutionContext context)
        {
            if (UserId == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            
  
            /*Common.GenerateQRCodeAsync("fa6ee320-0986-4e0c-86f0-19cd6d50d23c");*/

            try
            {

                UserInfo userInfo = await DbHelper.GetDataAsync<UserInfo>(Constants.getUserInfo, UserId);

                log.LogInformation(JsonConvert.SerializeObject(userInfo));

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(userInfo), Encoding.UTF8, "application/json")
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
