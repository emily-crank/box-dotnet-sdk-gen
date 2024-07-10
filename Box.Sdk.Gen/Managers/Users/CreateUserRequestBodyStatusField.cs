using System.ComponentModel;
using Box.Sdk.Gen.Schemas;
using Box.Sdk.Gen.Internal;

namespace Box.Sdk.Gen.Managers {
    public enum CreateUserRequestBodyStatusField {
        [Description("active")]
        Active,
        [Description("inactive")]
        Inactive,
        [Description("cannot_delete_edit")]
        CannotDeleteEdit,
        [Description("cannot_delete_edit_upload")]
        CannotDeleteEditUpload
    }
}