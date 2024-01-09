using Microsoft.VisualStudio.TestTools.UnitTesting;
using NullableExtensions;
using StringExtensions;
using Box;
using Box.Schemas;

namespace Box.Tests.Integration {
    [TestClass]
    public class StoragePoliciesManagerTests {
        public string userId { get; }

        public StoragePoliciesManagerTests() {
            userId = Utils.GetEnvVar(name: "USER_ID");
        }
        [TestMethod]
        public async System.Threading.Tasks.Task TestGetStoragePolicies() {
            BoxClient client = await new CommonsManager().GetDefaultClientAsUserAsync(userId: userId).ConfigureAwait(false);
            StoragePolicies storagePolicies = await client.StoragePolicies.GetStoragePoliciesAsync().ConfigureAwait(false);
            StoragePolicy storagePolicy = NullableUtils.Unwrap(storagePolicies.Entries)[0];
            Assert.IsTrue(StringUtils.ToStringRepresentation(storagePolicy.Type) == "storage_policy");
            StoragePolicy getStoragePolicy = await client.StoragePolicies.GetStoragePolicyByIdAsync(storagePolicyId: NullableUtils.Unwrap(storagePolicy.Id)).ConfigureAwait(false);
            Assert.IsTrue(getStoragePolicy.Id == storagePolicy.Id);
        }

    }
}