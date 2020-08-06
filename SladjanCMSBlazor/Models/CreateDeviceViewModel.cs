using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SladjanCMSBlazor.Models
{
    public class CreateDeviceViewModel
    {
        [JsonProperty("deviceid")]
        public string DeviceId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
