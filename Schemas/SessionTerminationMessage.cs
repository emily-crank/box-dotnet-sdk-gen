using System.IO;
using Unions;
using System.Text.Json.Serialization;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Box.Schemas {
    public class SessionTerminationMessage {
        /// <summary>
        /// The unique identifier for the termination job status
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; } = default;

        public SessionTerminationMessage() {
            
        }
    }
}