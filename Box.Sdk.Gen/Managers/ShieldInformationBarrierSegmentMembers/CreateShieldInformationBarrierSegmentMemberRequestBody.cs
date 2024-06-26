using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Box.Sdk.Gen;
using System.Text.Json.Serialization;
using Serializer;
using Box.Sdk.Gen.Schemas;

namespace Box.Sdk.Gen.Managers {
    public class CreateShieldInformationBarrierSegmentMemberRequestBody {
        /// <summary>
        /// -| A type of the shield barrier segment member.
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(StringEnumConverter<CreateShieldInformationBarrierSegmentMemberRequestBodyTypeField>))]
        public StringEnum<CreateShieldInformationBarrierSegmentMemberRequestBodyTypeField>? Type { get; init; }

        [JsonPropertyName("shield_information_barrier")]
        public ShieldInformationBarrierBase? ShieldInformationBarrier { get; init; }

        /// <summary>
        /// The `type` and `id` of the
        /// requested shield information barrier segment.
        /// </summary>
        [JsonPropertyName("shield_information_barrier_segment")]
        public CreateShieldInformationBarrierSegmentMemberRequestBodyShieldInformationBarrierSegmentField ShieldInformationBarrierSegment { get; }

        /// <summary>
        /// User to which restriction will be applied.
        /// </summary>
        [JsonPropertyName("user")]
        public UserBase User { get; }

        public CreateShieldInformationBarrierSegmentMemberRequestBody(CreateShieldInformationBarrierSegmentMemberRequestBodyShieldInformationBarrierSegmentField shieldInformationBarrierSegment, UserBase user) {
            ShieldInformationBarrierSegment = shieldInformationBarrierSegment;
            User = user;
        }
    }
}