using System.IO;
using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class CreateFileMetadataEnterpriseSecurityClassificationRequestBodyArg {
        /// <summary>
        /// The name of the classification to apply to this file.
        /// 
        /// To list the available classifications in an enterprise,
        /// use the classification API to retrieve the
        /// [classification template](e://get_metadata_templates_enterprise_securityClassification-6VMVochwUWo_schema)
        /// which lists all available classification keys.
        /// </summary>
        [JsonPropertyName("Box__Security__Classification__Key")]
        public string? BoxSecurityClassificationKey { get; set; } = default;

        public CreateFileMetadataEnterpriseSecurityClassificationRequestBodyArg() {
            
        }
    }
}