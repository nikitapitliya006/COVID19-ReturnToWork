using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BackToWorkFunctions.Helper;
using BackToWorkFunctions.Model;
using System.Linq;
using System.Globalization;
using System.Threading;

namespace BackToWorkFunctions
{
    public static class TriggerScenarioFunction
    {
        private static GraphServiceClient _graphServiceClient;

        [FunctionName("TriggerScenarioFunction")]
        public static void Run([TimerTrigger("0 8 0 * * *"), Disable()]TimerInfo myTimer, ILogger log)
        {
            ProgrammaticTrigger.GetTeamsAddressFromSqlAndPostTrigger();            
        }        
    }
}
