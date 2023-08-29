using System.IO;
using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class GetShieldInformationBarrierSegmentMembersQueryParamsArg {
        /// <summary>
        /// The ID of the shield information barrier segment.
        /// </summary>
        public string ShieldInformationBarrierSegmentId { get; set; }

        /// <summary>
        /// Defines the position marker at which to begin returning results. This is
        /// used when paginating using marker-based pagination.
        /// 
        /// This requires `usemarker` to be set to `true`.
        /// </summary>
        public string? Marker { get; set; } = default;

        /// <summary>
        /// The maximum number of items to return per page.
        /// </summary>
        public long? Limit { get; set; } = default;

        public GetShieldInformationBarrierSegmentMembersQueryParamsArg(string shieldInformationBarrierSegmentId) {
            ShieldInformationBarrierSegmentId = shieldInformationBarrierSegmentId;
        }
    }
}