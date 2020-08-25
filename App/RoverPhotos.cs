using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace MarsRover
{
    public class RoverPhotos
    {
        [JsonPropertyName("photos")]
        public List<RoverPhoto> Photos { get; set; }
        
    }
}