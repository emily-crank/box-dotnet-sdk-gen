using Unions;
using Box.Sdk.Gen;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Serializer;
using Box.Sdk.Gen.Schemas;

namespace Box.Sdk.Gen.Managers {
    public class CreateUserRequestBody {
        /// <summary>
        /// The name of the user
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; }

        /// <summary>
        /// The email address the user uses to log in
        /// 
        /// Required, unless `is_platform_access_only`
        /// is set to `true`.
        /// </summary>
        [JsonPropertyName("login")]
        public string? Login { get; init; }

        /// <summary>
        /// Specifies that the user is an app user.
        /// </summary>
        [JsonPropertyName("is_platform_access_only")]
        public bool? IsPlatformAccessOnly { get; init; }

        /// <summary>
        /// The user’s enterprise role
        /// </summary>
        [JsonPropertyName("role")]
        [JsonConverter(typeof(StringEnumConverter<CreateUserRequestBodyRoleField>))]
        public StringEnum<CreateUserRequestBodyRoleField>? Role { get; init; }

        /// <summary>
        /// The language of the user, formatted in modified version of the
        /// [ISO 639-1](/guides/api-calls/language-codes) format.
        /// </summary>
        [JsonPropertyName("language")]
        public string? Language { get; init; }

        /// <summary>
        /// Whether the user can use Box Sync
        /// </summary>
        [JsonPropertyName("is_sync_enabled")]
        public bool? IsSyncEnabled { get; init; }

        /// <summary>
        /// The user’s job title
        /// </summary>
        [JsonPropertyName("job_title")]
        public string? JobTitle { get; init; }

        /// <summary>
        /// The user’s phone number
        /// </summary>
        [JsonPropertyName("phone")]
        public string? Phone { get; init; }

        /// <summary>
        /// The user’s address
        /// </summary>
        [JsonPropertyName("address")]
        public string? Address { get; init; }

        /// <summary>
        /// The user’s total available space in bytes. Set this to `-1` to
        /// indicate unlimited storage.
        /// </summary>
        [JsonPropertyName("space_amount")]
        public long? SpaceAmount { get; init; }

        /// <summary>
        /// Tracking codes allow an admin to generate reports from the
        /// admin console and assign an attribute to a specific group
        /// of users. This setting must be enabled for an enterprise before it
        /// can be used.
        /// </summary>
        [JsonPropertyName("tracking_codes")]
        public IReadOnlyList<TrackingCode>? TrackingCodes { get; init; }

        /// <summary>
        /// Whether the user can see other enterprise users in their
        /// contact list
        /// </summary>
        [JsonPropertyName("can_see_managed_users")]
        public bool? CanSeeManagedUsers { get; init; }

        /// <summary>
        /// The user's timezone
        /// </summary>
        [JsonPropertyName("timezone")]
        public string? Timezone { get; init; }

        /// <summary>
        /// Whether the user is allowed to collaborate with users outside
        /// their enterprise
        /// </summary>
        [JsonPropertyName("is_external_collab_restricted")]
        public bool? IsExternalCollabRestricted { get; init; }

        /// <summary>
        /// Whether to exempt the user from enterprise device limits
        /// </summary>
        [JsonPropertyName("is_exempt_from_device_limits")]
        public bool? IsExemptFromDeviceLimits { get; init; }

        /// <summary>
        /// Whether the user must use two-factor authentication
        /// </summary>
        [JsonPropertyName("is_exempt_from_login_verification")]
        public bool? IsExemptFromLoginVerification { get; init; }

        /// <summary>
        /// The user's account status
        /// </summary>
        [JsonPropertyName("status")]
        [JsonConverter(typeof(StringEnumConverter<CreateUserRequestBodyStatusField>))]
        public StringEnum<CreateUserRequestBodyStatusField>? Status { get; init; }

        /// <summary>
        /// An external identifier for an app user, which can be used to look
        /// up the user. This can be used to tie user IDs from external
        /// identity providers to Box users.
        /// </summary>
        [JsonPropertyName("external_app_user_id")]
        public string? ExternalAppUserId { get; init; }

        public CreateUserRequestBody(string name) {
            Name = name;
        }
    }
}