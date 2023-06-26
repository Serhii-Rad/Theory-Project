using Newtonsoft.Json;
using System.Collections.Generic;

namespace API
{
    public class RootObject
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("folder")]
        public string Folder { get; set; }

        public List<Results> Results { get; set; }
    }

    public class Results
    {
        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("t0.DeviceName")]
        public string DeviceName { get; set; }
        [JsonProperty("t0.UploadDateTime")]
        public string UploadDaetTime { get; set; }
        [JsonProperty("t0.DeviceId")]
        public string DeviceID { get; set; }
        [JsonProperty("OS.OStype")]
        public string OSType { get; set; }
        [JsonProperty("ComputerHealth.Severity")]
        public string Severity { get; set; }
        [JsonProperty("ComputerHealth.SeverityDelayed")]
        public string SeverityDelayed { get; set; }
        [JsonProperty("ComputerHealth.SeverityCombined")]
        public string SeverityCombined { get; set; }
        [JsonProperty("ComputerDeviceName")]
        public string ComputerDeviceName { get; set; }

        //tc25188
        [JsonProperty("UPPERlower")]
        public string UPPERlower { get; set; }
        [JsonProperty("_1_")]
        public string _1_ { get; set; }
        [JsonProperty("_1")]
        public string _1 { get; set; }
    }
}
