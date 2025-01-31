﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Central_Phone.Models.ModelsIcount
{
    public class ClientInfoResponse
    {
        
        [JsonProperty("api")]
        public ApiClientInfo ApiClientInfo { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("client_id")]
        public int ClientId { get; set; }

        [JsonProperty("custom_client_id")]
        public string CustomClientId { get; set; }

        [JsonProperty("client_info")]
        public ClientInfo ClientInfo { get; set; }

    }
}
