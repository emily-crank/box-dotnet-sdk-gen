using System.ComponentModel;
using Box.Sdk.Gen.Schemas;
using Box.Sdk.Gen;

namespace Box.Sdk.Gen.Managers {
    public enum CreateGroupRequestBodyInvitabilityLevelField {
        [Description("admins_only")]
        AdminsOnly,
        [Description("admins_and_members")]
        AdminsAndMembers,
        [Description("all_managed_users")]
        AllManagedUsers
    }
}