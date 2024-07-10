using Box.Sdk.Gen;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Box.Sdk.Gen.Schemas;
using Box.Sdk.Gen.Internal;

namespace Box.Sdk.Gen.Managers {
    public class GetEnterpriseDevicePinnersQueryParams {
        /// <summary>
        /// Defines the position marker at which to begin returning results. This is
        /// used when paginating using marker-based pagination.
        /// 
        /// This requires `usemarker` to be set to `true`.
        /// </summary>
        public string? Marker { get; init; }

        /// <summary>
        /// The maximum number of items to return per page.
        /// </summary>
        public long? Limit { get; init; }

        /// <summary>
        /// The direction to sort results in. This can be either in alphabetical ascending
        /// (`ASC`) or descending (`DESC`) order.
        /// </summary>
        public StringEnum<GetEnterpriseDevicePinnersQueryParamsDirectionField>? Direction { get; init; }

        public GetEnterpriseDevicePinnersQueryParams() {
            
        }
    }
}