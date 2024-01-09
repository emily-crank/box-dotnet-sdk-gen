using System.ComponentModel;
using Serializer;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    [JsonConverter(typeof(StringEnumConverter<CreateShieldInformationBarrierSegmentMemberRequestBodyTypeField>))]
    public enum CreateShieldInformationBarrierSegmentMemberRequestBodyTypeField {
        [Description("shield_information_barrier_segment_member")]
        ShieldInformationBarrierSegmentMember
    }
}