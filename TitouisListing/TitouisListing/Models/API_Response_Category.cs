using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TitouisListing.Models
{
    public partial class API_Response_Category
    {
        [JsonProperty("message")]
        public Category[] Categories { get; set; }
    }
}
