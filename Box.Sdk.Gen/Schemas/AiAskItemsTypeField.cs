using System.ComponentModel;
using Serializer;
using System.Text.Json.Serialization;

namespace Box.Sdk.Gen.Schemas {
    [JsonConverter(typeof(StringEnumConverter<AiAskItemsTypeField>))]
    public enum AiAskItemsTypeField {
        [Description("file")]
        File
    }
}