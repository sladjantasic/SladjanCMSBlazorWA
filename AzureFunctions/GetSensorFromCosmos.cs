using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AzureFunctions
{
    public static class GetSensorFromCosmos
    {
        [FunctionName("GetSensorFromCosmos")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [CosmosDB(
                    databaseName: "IoT",
                    collectionName: "FridgeMessages",
                    ConnectionStringSetting = "CosmosConnection",
                    SqlQuery = "SELECT TOP 30 * FROM c ORDER BY c.timestamp DESC"
            )] IEnumerable<dynamic> cosmosdb,
            ILogger log)
        {
            log.LogInformation("Requested items found");
            return new OkObjectResult(cosmosdb);
        }
    }
}
