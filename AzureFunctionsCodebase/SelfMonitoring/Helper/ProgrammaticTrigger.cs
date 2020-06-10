using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BackToWorkFunctions.Model;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net;

namespace BackToWorkFunctions.Helper
{
    public static class ProgrammaticTrigger
    {        
        public static async Task PostTriggerToAllRegisteredTeamsClients(string teamsAddress)
        {
            try
            {
                if (String.IsNullOrEmpty(teamsAddress))
                {
                    return;
                }

                string URL = Environment.GetEnvironmentVariable("Healthbot_Trigger_Call", EnvironmentVariableTarget.Process);
                HttpClient client = new HttpClient();
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 ;
                client.BaseAddress = new Uri(URL);

                //Add an Authorization Bearer token (jwt token)
                string partial_token = GetJwtToken();
                if (String.IsNullOrEmpty(partial_token))
                {
                    throw new Exception("JWT Token is empty");
                }
                string token = "Bearer " + partial_token;
                client.DefaultRequestHeaders.Add("Authorization", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string scenarioId = Environment.GetEnvironmentVariable("Healthbot_ScenarioId", EnvironmentVariableTarget.Process);
                var payload = "{\"address\":" + teamsAddress + ",\"scenario\": \"/scenarios/" + scenarioId + "\"}";
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error in triggering scenario to Teams client");
                }
                content.Dispose();
                client.Dispose();

            }
            catch(ArgumentNullException argNullEx)
            {
                throw new Exception(argNullEx.ToString());
            }
            catch(HttpRequestException httpReqEx)
            {
                throw new Exception(httpReqEx.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static string GetJwtToken()
        {
            try
            {
                var healthbot_API_JWT_SECRET = Environment.GetEnvironmentVariable("Healthbot_API_JWT_SECRET", EnvironmentVariableTarget.Process);
                var healthbot_Tenant_Name = Environment.GetEnvironmentVariable("Healthbot_Tenant_Name", EnvironmentVariableTarget.Process);
                TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
                int secondsSinceEpoch = (int)t.TotalSeconds;

                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(healthbot_API_JWT_SECRET));
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var header = new JwtHeader(signingCredentials);
                var payload = new JwtPayload
                {
                    { "tenantName", "" + healthbot_Tenant_Name + ""},
                    { "iat", secondsSinceEpoch},
                };

                var secToken = new JwtSecurityToken(header, payload);
                var handler = new JwtSecurityTokenHandler();

                var tokenString = handler.WriteToken(secToken);
                return tokenString;
            }
            catch(ArgumentNullException argNullEx)
            {
                throw new Exception(argNullEx.ToString());
            }
            catch(ArgumentOutOfRangeException argOutEx)
            {
                throw new Exception(argOutEx.ToString());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());                
            }
        }
    }    
}
