using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models
{
    public class TeamNames
    {
        [JsonPropertyName("abbr")]
        public string? Abbr { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("full_name")]
        public string? FullName { get; set; }
    }
}
