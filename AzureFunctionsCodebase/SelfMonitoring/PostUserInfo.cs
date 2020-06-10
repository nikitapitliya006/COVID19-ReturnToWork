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
using System.Web.Http;
using System.Collections.Generic;
using System;
using System.Data;
using System.Threading.Tasks;
using BackToWorkFunctions.Model;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyModel.Resolution;
using Microsoft.AspNetCore.Mvc;

namespace BackToWorkFunctions
{
    public static class PostUserInfo
    {
        [FunctionName("PostUserInfo")]
        public static async Task<ActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestMessage req, ILogger log)
        {            
            try
            {
                if (req == null)
                {
                    return new BadRequestObjectResult("Error: Request object missing");
                }

                UserInfo userInfo = await req.Content.ReadAsAsync<UserInfo>().ConfigureAwait(false);

                if (checkEmptyOrNull(userInfo))
                {
                    return new BadRequestObjectResult("Error: Incorrect payload");
                }

                bool dataRecorded = DbHelper.PostDataAsync(userInfo, Constants.postUserInfo);

                if (dataRecorded)
                {
                    return new OkObjectResult("Status: OK");
                }
                else
                {
                    return new BadRequestObjectResult("Error: Writing to database was not complete");
                }
            }
            catch (HttpRequestException httpEx)
            {
                log.LogInformation(httpEx.Message);
                return new BadRequestObjectResult("Error: Incorrect Request");
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

        private static bool checkEmptyOrNull(UserInfo userInfo)
        {
            return userInfo == null || String.IsNullOrEmpty(userInfo.UserId) || String.IsNullOrEmpty(userInfo.FullName)
                    || String.IsNullOrEmpty(userInfo.YearOfBirth.ToString()) || String.IsNullOrEmpty(userInfo.EmailAddress); 
        }

    }

}
