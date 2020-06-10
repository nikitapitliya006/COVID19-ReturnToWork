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
using System.Web.Http;

namespace BackToWorkFunctions
{
    public static class PostSymptomsInfo
    {
        [FunctionName("PostSymptomsInfo")]
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
                SymptomsInfo symptomsInfo = await req.Content.ReadAsAsync<SymptomsInfo>().ConfigureAwait(false);
                if (checkEmptyOrNull(symptomsInfo))
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
                bool dataRecorded = DbHelper.PostDataAsync(symptomsInfo, Constants.postSymptomsInfo);
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
                throw new HttpRequestException(httpEx.ToString());
            }
            catch (ArgumentNullException argNullEx)
            {
                log.LogInformation(argNullEx.Message);
                throw new ArgumentNullException(argNullEx.ToString());
            }
            catch(Newtonsoft.Json.JsonSerializationException serializeEx)
            {
                log.LogInformation(serializeEx.Message);
                throw new Newtonsoft.Json.JsonSerializationException(serializeEx.ToString());
            }
            catch (Exception ex)
            {
                log.LogInformation(ex.Message);
                throw new Exception(ex.ToString());
            }
        }

        private static bool checkEmptyOrNull(SymptomsInfo symptomsInfo)
        {
            return symptomsInfo == null || String.IsNullOrEmpty(symptomsInfo.UserId) || String.IsNullOrEmpty(symptomsInfo.DateOfEntry)
                    || (symptomsInfo.UserIsExposed == null) || String.IsNullOrEmpty(symptomsInfo.IsSymptomatic.ToString())
                    || String.IsNullOrEmpty(symptomsInfo.ClearToWorkToday.ToString());
        }
    }
}
