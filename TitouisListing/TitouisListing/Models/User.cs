using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TitouisListing.Models
{
    public class User
    {
        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }

    public class Id
    {
        [JsonProperty("$oid")]
        public string Oid { get; set; }
    }
}
