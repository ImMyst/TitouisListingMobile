using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TitouisListing.Models
{
    public class Product
    {
        [JsonProperty("_id")]
        public Id Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("photo_data")]
        public string PhotoData { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }
    }
}
