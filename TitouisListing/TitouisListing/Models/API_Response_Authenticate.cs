using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TitouisListing.Models
{
    public partial class API_Response_Authenticate
    {
        [JsonProperty("auth_token")]
        public string AuthToken { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
