using Unions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class GetFolderTrashItemsQueryParamsArg {
        /// <summary>
        /// A comma-separated list of attributes to include in the
        /// response. This can be used to request fields that are
        /// not normally returned in a standard response.
        /// 
        /// Be aware that specifying this parameter will have the
        /// effect that none of the standard fields are returned in
        /// the response unless explicitly specified, instead only
        /// fields for the mini representation are returned, additional
        /// to the fields requested.
        /// </summary>
        public IReadOnlyList<string>? Fields { get; set; } = default;

        /// <summary>
        /// The maximum number of items to return per page.
        /// </summary>
        public long? Limit { get; set; } = default;

        /// <summary>
        /// The offset of the item at which to begin the response.
        /// 
        /// Queries with offset parameter value
        /// exceeding 10000 will be rejected
        /// with a 400 response.
        /// </summary>
        public long? Offset { get; set; } = default;

        /// <summary>
        /// Specifies whether to use marker-based pagination instead of
        /// offset-based pagination. Only one pagination method can
        /// be used at a time.
        /// 
        /// By setting this value to true, the API will return a `marker` field
        /// that can be passed as a parameter to this endpoint to get the next
        /// page of the response.
        /// </summary>
        public bool? Usemarker { get; set; } = default;

        /// <summary>
        /// Defines the position marker at which to begin returning results. This is
        /// used when paginating using marker-based pagination.
        /// 
        /// This requires `usemarker` to be set to `true`.
        /// </summary>
        public string? Marker { get; set; } = default;

        /// <summary>
        /// The direction to sort results in. This can be either in alphabetical ascending
        /// (`ASC`) or descending (`DESC`) order.
        /// </summary>
        public GetFolderTrashItemsQueryParamsArgDirectionField? Direction { get; set; } = default;

        /// <summary>
        /// Defines the **second** attribute by which items
        /// are sorted.
        /// 
        /// Items are always sorted by their `type` first, with
        /// folders listed before files, and files listed
        /// before web links.
        /// 
        /// This parameter is not supported when using marker-based pagination.
        /// </summary>
        public GetFolderTrashItemsQueryParamsArgSortField? Sort { get; set; } = default;

        public GetFolderTrashItemsQueryParamsArg() {
            
        }
    }
}