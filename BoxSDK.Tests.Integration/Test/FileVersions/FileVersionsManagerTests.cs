using Microsoft.VisualStudio.TestTools.UnitTesting;
using Box;
using Box.Schemas;
using Box.Managers;

namespace Box.Tests.Integration {
    [TestClass]
    public class FileVersionsManagerTests {
        public BoxClient client { get; }

        public FileVersionsManagerTests() {
            client = new CommonsManager().GetDefaultClient();
        }
        [TestMethod]
        public async System.Threading.Tasks.Task TestCreateListGetRestoreDeleteFileVersion() {
            string oldName = Utils.GetUUID();
            string newName = Utils.GetUUID();
            Files files = await client.Uploads.UploadFileAsync(new UploadFileRequestBodyArg(attributes: new UploadFileRequestBodyArgAttributesField(name: oldName, parent: new UploadFileRequestBodyArgAttributesFieldParentField(id: "0")), file: Utils.GenerateByteStream(10))).ConfigureAwait(false);
            FileFull file = files.Entries![0];
            Assert.IsTrue(file.Name == oldName);
            Assert.IsTrue(file.Size == 10);
            Files newFiles = await client.Uploads.UploadFileVersionAsync(file.Id, new UploadFileVersionRequestBodyArg(attributes: new UploadFileVersionRequestBodyArgAttributesField(name: newName), file: Utils.GenerateByteStream(20))).ConfigureAwait(false);
            FileFull newFile = newFiles.Entries![0];
            Assert.IsTrue(newFile.Name == newName);
            Assert.IsTrue(newFile.Size == 20);
            FileVersions fileVersions = await client.FileVersions.GetFileVersionsAsync(file.Id).ConfigureAwait(false);
            Assert.IsTrue(fileVersions.TotalCount == 1);
            FileVersionFull fileVersion = await client.FileVersions.GetFileVersionByIdAsync(file.Id, fileVersions.Entries![0].Id).ConfigureAwait(false);
            Assert.IsTrue(fileVersion.Id == fileVersions.Entries![0].Id);
            await client.FileVersions.PromoteFileVersionAsync(file.Id, new PromoteFileVersionRequestBodyArg() { Id = fileVersions.Entries![0].Id, Type = PromoteFileVersionRequestBodyArgTypeField.FileVersion }).ConfigureAwait(false);
            FileFull fileRestored = await client.Files.GetFileByIdAsync(file.Id).ConfigureAwait(false);
            Assert.IsTrue(fileRestored.Name == oldName);
            Assert.IsTrue(fileRestored.Size == 10);
            FileVersions fileVersionsRestored = await client.FileVersions.GetFileVersionsAsync(file.Id).ConfigureAwait(false);
            await client.FileVersions.DeleteFileVersionByIdAsync(file.Id, fileVersionsRestored.Entries![0].Id).ConfigureAwait(false);
            await client.FileVersions.GetFileVersionsAsync(file.Id).ConfigureAwait(false);
            await client.Files.DeleteFileByIdAsync(file.Id).ConfigureAwait(false);
        }

    }
}