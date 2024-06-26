using System.ComponentModel;
using Box.Sdk.Gen.Schemas;

namespace Box.Sdk.Gen.Schemas {
    public enum EventSourceItemTypeField {
        [Description("file")]
        File,
        [Description("folder")]
        Folder
    }
}