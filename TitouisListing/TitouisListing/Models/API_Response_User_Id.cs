using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TitouisListing.Models
{
    public class API_Response_User_Id
    {
        [JsonProperty("message")]
        public User User { get; set; }
    }
}
