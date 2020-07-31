using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Devices;
using System.Linq;

namespace AzureFunctions
{
    public static class GetDeviceInfo
    {
        private static readonly RegistryManager registryManager = RegistryManager.CreateFromConnectionString(Environment.GetEnvironmentVariable("IotHubConnection"));

        [FunctionName("GetDeviceInfo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            string deviceid = req.Query["deviceid"];
            var result = registryManager.CreateQuery($"SELECT * FROM devices WHERE deviceId = '{deviceid}'");
            var data = await result.GetNextAsTwinAsync();

            if (data.FirstOrDefault() != null)
            {
                var json = JsonConvert.SerializeObject(data.FirstOrDefault());
                return new OkObjectResult(json);
            }
            else
            {
                return new NotFoundResult();
            }
        }
    }
}
