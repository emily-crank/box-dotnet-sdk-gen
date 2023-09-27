using Unions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class GetFileByIdQueryParamsArg {
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
        /// 
        /// Additionally this field can be used to query any metadata
        /// applied to the file by specifying the `metadata` field as well
        /// as the scope and key of the template to retrieve, for example
        /// `?field=metadata.enterprise_12345.contractTemplate`.
        /// </summary>
        public IReadOnlyList<string>? Fields { get; set; } = default;

        public GetFileByIdQueryParamsArg() {
            
        }
    }
}