using System.ComponentModel;
using Serializer;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    [JsonConverter(typeof(StringEnumConverter<UpdateCollaborationByIdRequestBodyStatusField>))]
    public enum UpdateCollaborationByIdRequestBodyStatusField {
        [Description("pending")]
        Pending,
        [Description("accepted")]
        Accepted,
        [Description("rejected")]
        Rejected
    }
}