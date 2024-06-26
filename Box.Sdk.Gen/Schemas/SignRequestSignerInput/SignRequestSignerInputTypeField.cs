using System.ComponentModel;
using Box.Sdk.Gen.Schemas;

namespace Box.Sdk.Gen.Schemas {
    public enum SignRequestSignerInputTypeField {
        [Description("signature")]
        Signature,
        [Description("date")]
        Date,
        [Description("text")]
        Text,
        [Description("checkbox")]
        Checkbox,
        [Description("radio")]
        Radio,
        [Description("dropdown")]
        Dropdown
    }
}