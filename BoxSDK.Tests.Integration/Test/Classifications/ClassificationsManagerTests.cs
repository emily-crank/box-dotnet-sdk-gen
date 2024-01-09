using Microsoft.VisualStudio.TestTools.UnitTesting;
using NullableExtensions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Box;
using Box.Schemas;
using Box.Managers;

namespace Box.Tests.Integration {
    [TestClass]
    public class ClassificationsManagerTests {
        public BoxClient client { get; }

        public ClassificationsManagerTests() {
            client = new CommonsManager().GetDefaultClient();
        }
        [TestMethod]
        public async System.Threading.Tasks.Task TestClassifications() {
            ClassificationTemplate classificationTemplate = await new CommonsManager().GetOrCreateClassificationTemplateAsync().ConfigureAwait(false);
            ClassificationTemplateFieldsOptionsField classification = await new CommonsManager().GetOrCreateClassificationAsync(classificationTemplate: classificationTemplate).ConfigureAwait(false);
            Assert.IsTrue(classification.Key != "");
            Assert.IsTrue(NullableUtils.Unwrap(NullableUtils.Unwrap(classification.StaticConfig).Classification).ColorId != 100);
            Assert.IsTrue(NullableUtils.Unwrap(NullableUtils.Unwrap(classification.StaticConfig).Classification).ClassificationDefinition != "");
            string updatedClassificationName = Utils.GetUUID();
            string updatedClassificationDescription = Utils.GetUUID();
            ClassificationTemplate classificationTemplateWithUpdatedClassification = await client.Classifications.UpdateClassificationAsync(requestBody: Array.AsReadOnly(new [] {new UpdateClassificationRequestBody(op: UpdateClassificationRequestBodyOpField.EditEnumOption, fieldKey: UpdateClassificationRequestBodyFieldKeyField.BoxSecurityClassificationKey, enumOptionKey: classification.Key, data: new UpdateClassificationRequestBodyDataField(key: updatedClassificationName) { StaticConfig = new UpdateClassificationRequestBodyDataStaticConfigField() { Classification = new UpdateClassificationRequestBodyDataStaticConfigClassificationField() { ColorId = 2, ClassificationDefinition = updatedClassificationDescription } } })})).ConfigureAwait(false);
            IReadOnlyList<ClassificationTemplateFieldsOptionsField> updatedClassifications = classificationTemplateWithUpdatedClassification.Fields[0].Options;
            ClassificationTemplateFieldsOptionsField updatedClassification = updatedClassifications.ElementAt(0);
            Assert.IsTrue(updatedClassification.Key == updatedClassificationName);
            Assert.IsTrue(NullableUtils.Unwrap(NullableUtils.Unwrap(updatedClassification.StaticConfig).Classification).ColorId == 2);
            Assert.IsTrue(NullableUtils.Unwrap(NullableUtils.Unwrap(updatedClassification.StaticConfig).Classification).ClassificationDefinition == updatedClassificationDescription);
        }

    }
}