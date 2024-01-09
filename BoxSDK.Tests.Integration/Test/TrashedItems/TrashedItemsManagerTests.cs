using Microsoft.VisualStudio.TestTools.UnitTesting;
using NullableExtensions;
using Box;
using Box.Schemas;

namespace Box.Tests.Integration {
    [TestClass]
    public class TrashedItemsManagerTests {
        public BoxClient client { get; }

        public TrashedItemsManagerTests() {
            client = new CommonsManager().GetDefaultClient();
        }
        [TestMethod]
        public async System.Threading.Tasks.Task TestListTrashedItems() {
            FileFull file = await new CommonsManager().UploadNewFileAsync().ConfigureAwait(false);
            await client.Files.DeleteFileByIdAsync(fileId: file.Id).ConfigureAwait(false);
            Items trashedItems = await client.TrashedItems.GetTrashedItemsAsync().ConfigureAwait(false);
            Assert.IsTrue(NullableUtils.Unwrap(trashedItems.Entries).Count > 0);
        }

    }
}