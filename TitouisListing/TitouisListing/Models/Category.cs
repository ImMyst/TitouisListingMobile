using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TitouisListing.Models
{
    public class Category
    {
        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
