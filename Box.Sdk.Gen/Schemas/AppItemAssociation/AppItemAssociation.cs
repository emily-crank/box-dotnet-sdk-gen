using Box.Sdk.Gen;
using System.Text.Json.Serialization;
using Box.Sdk.Gen.Internal;
using Box.Sdk.Gen.Schemas;

namespace Box.Sdk.Gen.Schemas {
    public class AppItemAssociation {
        /// <summary>
        /// The unique identifier for this app item association.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; }

        /// <summary>
        /// `app_item_association`
        /// </summary>
        [JsonPropertyName("type")]
        [JsonConverter(typeof(StringEnumConverter<AppItemAssociationTypeField>))]
        public StringEnum<AppItemAssociationTypeField> Type { get; }

        [JsonPropertyName("app_item")]
        public AppItem AppItem { get; }

        [JsonPropertyName("item")]
        public FileBaseOrFolderBaseOrWebLinkBase Item { get; }

        public AppItemAssociation(string id, AppItem appItem, FileBaseOrFolderBaseOrWebLinkBase item, AppItemAssociationTypeField type = AppItemAssociationTypeField.AppItemAssociation) {
            Id = id;
            Type = type;
            AppItem = appItem;
            Item = item;
        }
        
        [JsonConstructorAttribute]
        internal AppItemAssociation(string id, AppItem appItem, FileBaseOrFolderBaseOrWebLinkBase item, StringEnum<AppItemAssociationTypeField> type) {
            Id = id;
            Type = AppItemAssociationTypeField.AppItemAssociation;
            AppItem = appItem;
            Item = item;
        }
    }
}