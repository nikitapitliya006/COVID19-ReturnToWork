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
    public static class PostRequestStatus
    {
        [FunctionName("PostRequestStatus")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            try
            {
                if (req == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                RequestStatus requestStatus = await req.Content.ReadAsAsync<RequestStatus>().ConfigureAwait(false);
                if (requestStatus == null || String.IsNullOrEmpty(requestStatus.UserId) || String.IsNullOrEmpty(requestStatus.DateOfEntry))
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }

                bool dataRecorded = DbHelper.PostDataAsync(requestStatus, Constants.postRequestStatus);

                if (dataRecorded)
                {
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }
            catch (HttpRequestException httpEx)
            {
                log.LogInformation(httpEx.Message);
                throw new Exception(httpEx.ToString());
            }
            catch (ArgumentNullException argNullEx)
            {
                log.LogInformation(argNullEx.Message);
                throw new ArgumentNullException(argNullEx.ToString());
            }
            catch (Newtonsoft.Json.JsonSerializationException serializeEx)
            {
                log.LogInformation(serializeEx.Message);
                throw new Newtonsoft.Json.JsonSerializationException(serializeEx.ToString());
            }
            catch (System.Exception ex)
            {
                log.LogInformation(ex.Message);
                throw new Exception(ex.ToString());
            }
        }
    }
}
