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
using System.Drawing;

namespace BackToWorkFunctions
{
    public static class GetUserInfo
    {
        [FunctionName("GetUserInfo")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetUserInfo/{UserId}")] HttpRequest req, string UserId,
            ILogger log, ExecutionContext context)
        {
            if (String.IsNullOrEmpty(UserId))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            try
            {
                UserInfo userInfo = await DbHelper.GetDataAsync<UserInfo>(Constants.getUserInfo, UserId);
                if (userInfo == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(userInfo), Encoding.UTF8, "application/json")
                };
            }
            catch(System.Exception ex)
            {
                log.LogInformation(ex.Message);
                throw new Exception(ex.ToString());
            }
        }
    }
}
