using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TitouisListing.Models
{
    public class API_Response_User
    {
        [JsonProperty("message")]
        public User[] Users { get; set; }
    }
}
