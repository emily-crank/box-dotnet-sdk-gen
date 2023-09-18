using Unions;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class GetWorkflowsQueryParamsArg {
        /// <summary>
        /// The unique identifier that represent a folder.
        /// 
        /// The ID for any folder can be determined
        /// by visiting this folder in the web application
        /// and copying the ID from the URL. For example,
        /// for the URL `https://*.app.box.com/folder/123`
        /// the `folder_id` is `123`.
        /// 
        /// The root folder of a Box account is
        /// always represented by the ID `0`.
        /// </summary>
        public string FolderId { get; set; }

        /// <summary>
        /// Type of trigger to search for.
        /// </summary>
        public string? TriggerType { get; set; } = default;

        /// <summary>
        /// The maximum number of items to return per page.
        /// </summary>
        public long? Limit { get; set; } = default;

        /// <summary>
        /// Defines the position marker at which to begin returning results. This is
        /// used when paginating using marker-based pagination.
        /// 
        /// This requires `usemarker` to be set to `true`.
        /// </summary>
        public string? Marker { get; set; } = default;

        public GetWorkflowsQueryParamsArg(string folderId) {
            FolderId = folderId;
        }
    }
}