using Unions;
using System.Text.Json.Serialization;

namespace Box.Sdk.Gen.Schemas {
    public class UserBase {
        /// <summary>
        /// The unique identifier for this user
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// `user`
        /// </summary>
        [JsonPropertyName("type")]
        public UserBaseTypeField Type { get; set; }

        public UserBase(string id, UserBaseTypeField type = UserBaseTypeField.User) {
            Id = id;
            Type = type;
        }
    }
}