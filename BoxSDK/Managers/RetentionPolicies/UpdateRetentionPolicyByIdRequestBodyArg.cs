using Unions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Text.Json.Serialization;
using Box.Schemas;
using Box;

namespace Box.Managers {
    public class UpdateRetentionPolicyByIdRequestBodyArg {
        /// <summary>
        /// The name for the retention policy
        /// </summary>
        [JsonPropertyName("policy_name")]
        public string? PolicyName { get; set; } = default;

        /// <summary>
        /// The additional text description of the retention policy.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; } = default;

        /// <summary>
        /// The disposition action of the retention policy.
        /// `permanently_delete` deletes the content
        /// retained by the policy permanently.
        /// `remove_retention` lifts retention policy
        /// from the content, allowing it to be deleted
        /// by users once the retention policy has expired.
        /// </summary>
        [JsonPropertyName("disposition_action")]
        public UpdateRetentionPolicyByIdRequestBodyArgDispositionActionField? DispositionAction { get; set; } = default;

        /// <summary>
        /// Specifies the retention type:
        /// 
        /// * `modifiable`: You can modify the retention policy. For example,
        /// you can add or remove folders, shorten or lengthen
        /// the policy duration, or delete the assignment.
        /// Use this type if your retention policy
        /// is not related to any regulatory purposes.
        /// * `non-modifiable`: You can modify the retention policy
        /// only in a limited way: add a folder, lengthen the duration,
        /// retire the policy, change the disposition action
        /// or notification settings. You cannot perform other actions,
        /// such as deleting the assignment or shortening the
        /// policy duration. Use this type to ensure
        /// compliance with regulatory retention policies.
        /// 
        /// When updating a retention policy, you can use
        /// `non-modifiable` type only. You can convert a
        /// `modifiable` policy to `non-modifiable`, but
        /// not the other way around.
        /// </summary>
        [JsonPropertyName("retention_type")]
        public string? RetentionType { get; set; } = default;

        /// <summary>
        /// The length of the retention policy. This value
        /// specifies the duration in days that the retention
        /// policy will be active for after being assigned to
        /// content.  If the policy has a `policy_type` of
        /// `indefinite`, the `retention_length` will also be
        /// `indefinite`.
        /// </summary>
        [JsonPropertyName("retention_length")]
        public string? RetentionLength { get; set; } = default;

        /// <summary>
        /// Used to retire a retention policy.
        /// 
        /// If not retiring a policy, do not include this parameter
        /// or set it to `null`.
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; } = default;

        /// <summary>
        /// Determines if the owner of items under the policy
        /// can extend the retention when the original retention
        /// duration is about to end.
        /// </summary>
        [JsonPropertyName("can_owner_extend_retention")]
        public bool? CanOwnerExtendRetention { get; set; } = default;

        /// <summary>
        /// Determines if owners and co-owners of items
        /// under the policy are notified when
        /// the retention duration is about to end.
        /// </summary>
        [JsonPropertyName("are_owners_notified")]
        public bool? AreOwnersNotified { get; set; } = default;

        /// <summary>
        /// A list of users notified when the retention duration is about to end.
        /// </summary>
        [JsonPropertyName("custom_notification_recipients")]
        public IReadOnlyList<UserMini>? CustomNotificationRecipients { get; set; } = default;

        public UpdateRetentionPolicyByIdRequestBodyArg() {
            
        }
    }
}