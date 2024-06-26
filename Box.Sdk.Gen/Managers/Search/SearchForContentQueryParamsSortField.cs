using System.ComponentModel;
using Box.Sdk.Gen.Schemas;
using Box.Sdk.Gen;

namespace Box.Sdk.Gen.Managers {
    public enum SearchForContentQueryParamsSortField {
        [Description("modified_at")]
        ModifiedAt,
        [Description("relevance")]
        Relevance
    }
}