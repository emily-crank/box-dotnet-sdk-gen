using System.ComponentModel;
using Serializer;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    [JsonConverter(typeof(StringEnumConverter<GetFolderMetadataByIdScopeArg>))]
    public enum GetFolderMetadataByIdScopeArg {
        [Description("global")]
        Global,
        [Description("enterprise")]
        Enterprise
    }
}