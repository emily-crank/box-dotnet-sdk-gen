using System.IO;
using Unions;
using System.Text.Json.Serialization;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text.Json;

namespace Box.Schemas {
    [JsonConverter(typeof(CollaborationItemFieldConverter))]
    public class CollaborationItemField : OneOf<File, Folder, WebLink> {
        public File? File => _val0;
        
        public Folder? Folder => _val1;
        
        public WebLink? WebLink => _val2;
        
        public CollaborationItemField(File value) : base(value) {}
        
        public CollaborationItemField(Folder value) : base(value) {}
        
        public CollaborationItemField(WebLink value) : base(value) {}
        
        public static implicit operator CollaborationItemField(File value) => new CollaborationItemField(value);
        
        public static implicit operator CollaborationItemField(Folder value) => new CollaborationItemField(value);
        
        public static implicit operator CollaborationItemField(WebLink value) => new CollaborationItemField(value);
        
        class CollaborationItemFieldConverter : JsonConverter<CollaborationItemField> {

            public override CollaborationItemField Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
                using var document = JsonDocument.ParseValue(ref reader);
                var discriminant0Present = document.RootElement.TryGetProperty("type", out var discriminant0);
                if (discriminant0Present) {
                    switch (discriminant0.ToString()){
                        case "file":
                            return JsonSerializer.Deserialize<File>(document) ?? throw new Exception($"Could not deserialize {document} to File");
                        case "folder":
                            return JsonSerializer.Deserialize<Folder>(document) ?? throw new Exception($"Could not deserialize {document} to Folder");
                        case "web_link":
                            return JsonSerializer.Deserialize<WebLink>(document) ?? throw new Exception($"Could not deserialize {document} to WebLink");
                    }
                }
                throw new Exception($"Discriminant not found in json payload {document.RootElement} while try to converting to type {typeToConvert}");
            }

            public override void Write(Utf8JsonWriter writer, CollaborationItemField? value, JsonSerializerOptions options) {
                if (value?.File != null) {
                    JsonSerializer.Serialize(writer, value.File, options);
                    return;
                }
                if (value?.Folder != null) {
                    JsonSerializer.Serialize(writer, value.Folder, options);
                    return;
                }
                if (value?.WebLink != null) {
                    JsonSerializer.Serialize(writer, value.WebLink, options);
                    return;
                }
            }

        }

    }
}