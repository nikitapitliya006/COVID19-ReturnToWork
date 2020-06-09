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

namespace BackToWorkFunctions.Helper
{
    public class ProgrammaticTrigger
    {
        
        public static void GetTeamsAddressFromSqlAndPostTrigger()
        {
            
        }

        public static async Task<bool> PostTriggerToAllRegisteredTeamsClients(string teamsAddress)
        {
            try
            {

                string URL = Environment.GetEnvironmentVariable("Healthbot_Trigger_Call", EnvironmentVariableTarget.Process);
                string token = "";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);

                //Add an Authorization Bearer token (jwt token)
                string partial_token = GetJwtToken();
                token = "Bearer " + partial_token;
                client.DefaultRequestHeaders.Add("Authorization", token);

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Add body parameter
                string scenarioId = Environment.GetEnvironmentVariable("Healthbot_ScenarioId", EnvironmentVariableTarget.Process);
                var payload = "{\"address\":" + teamsAddress + ",\"scenario\": \"/scenarios/" + scenarioId + "\"}";
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                // List data response.
                HttpResponseMessage response = await client.PostAsync(URL, content);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("{0})", (int)response.StatusCode);
                }
                client.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public static string GetJwtToken()
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
    }    
}
