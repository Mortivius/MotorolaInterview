using System;
using System.Text.Json.Serialization;

namespace MarsRover
{
    public class RoverPhoto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("sol")]
        public int Sol { get; set; }
        [JsonPropertyName("img_src")]
        public string ImageURL { get; set; }
        [JsonPropertyName("earth_date")]
        public string EarthDate { get; set; }
    }
}