using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TitouisListing.Models
{
    public class API_Response_Products
    {
        [JsonProperty("message")]
        public Product[] Products { get; set; }
    }
}
