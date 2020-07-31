using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunctions
{
    public static class TimedSaveApiToCosmos
    {
        private static readonly HttpClient httpClient = new HttpClient();

        [FunctionName("TimedSaveApiToCosmos")]
        public static void Run(
            [TimerTrigger("1 * * * * *")]TimerInfo myTimer,
            [CosmosDB(
                    databaseName: "IoT",
                    collectionName: "FridgeMessages",
                    ConnectionStringSetting = "CosmosConnection",
                    CreateIfNotExists = true
            )] out dynamic cosmosdb,
            ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            //var data = httpClient.GetStringAsync("https://lexiconlaboration-functionapp.azurewebsites.net/api/temperature?deviceid=84:f3:eb:5a:9c:c3").GetAwaiter().GetResult();
            //cosmosdb = data;
            var data2 = httpClient.GetStreamAsync("https://lexiconlaboration-functionapp.azurewebsites.net/api/temperature?deviceid=84:f3:eb:5a:9c:c3").GetAwaiter().GetResult();
            cosmosdb = new StreamReader(data2).ReadToEnd();
        }
    }
}
