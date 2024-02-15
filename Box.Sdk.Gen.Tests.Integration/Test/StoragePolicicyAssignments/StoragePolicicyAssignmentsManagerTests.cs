using NullableExtensions;
using StringExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Box.Sdk.Gen.Schemas;
using Box.Sdk.Gen.Managers;
using Box.Sdk.Gen;

namespace Box.Sdk.Gen.Tests.Integration {
    [TestClass]
    public class StoragePolicicyAssignmentsManagerTests {
        public string adminUserId { get; }

        public StoragePolicicyAssignmentsManagerTests() {
            adminUserId = Utils.GetEnvVar(name: "USER_ID");
        }
        public async System.Threading.Tasks.Task<StoragePolicyAssignment> GetOrCreateStoragePolicyAssignmentAsync(BoxClient client, string policyId, string userId) {
            StoragePolicyAssignments storagePolicyAssignments = await client.StoragePolicyAssignments.GetStoragePolicyAssignmentsAsync(queryParams: new GetStoragePolicyAssignmentsQueryParams(resolvedForType: GetStoragePolicyAssignmentsQueryParamsResolvedForTypeField.User, resolvedForId: userId)).ConfigureAwait(false);
            if (NullableUtils.Unwrap(storagePolicyAssignments.Entries).Count > 0) {
                if (StringUtils.ToStringRepresentation(NullableUtils.Unwrap(NullableUtils.Unwrap(storagePolicyAssignments.Entries)[0].AssignedTo).Type) == "user") {
                    return NullableUtils.Unwrap(storagePolicyAssignments.Entries)[0];
                }
            }
            StoragePolicyAssignment storagePolicyAssignment = await client.StoragePolicyAssignments.CreateStoragePolicyAssignmentAsync(requestBody: new CreateStoragePolicyAssignmentRequestBody(storagePolicy: new CreateStoragePolicyAssignmentRequestBodyStoragePolicyField(id: policyId, type: CreateStoragePolicyAssignmentRequestBodyStoragePolicyTypeField.StoragePolicy), assignedTo: new CreateStoragePolicyAssignmentRequestBodyAssignedToField(id: userId, type: CreateStoragePolicyAssignmentRequestBodyAssignedToTypeField.User))).ConfigureAwait(false);
            return storagePolicyAssignment;
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestGetStoragePolicyAssignments() {
            BoxClient client = new CommonsManager().GetDefaultClientAsUser(userId: adminUserId);
            string userName = Utils.GetUUID();
            UserFull newUser = await client.Users.CreateUserAsync(requestBody: new CreateUserRequestBody(name: userName) { IsPlatformAccessOnly = true }).ConfigureAwait(false);
            StoragePolicies storagePolicies = await client.StoragePolicies.GetStoragePoliciesAsync().ConfigureAwait(false);
            StoragePolicy storagePolicy1 = NullableUtils.Unwrap(storagePolicies.Entries)[0];
            StoragePolicy storagePolicy2 = NullableUtils.Unwrap(storagePolicies.Entries)[1];
            StoragePolicyAssignment storagePolicyAssignment = await GetOrCreateStoragePolicyAssignmentAsync(client: client, policyId: storagePolicy1.Id, userId: newUser.Id).ConfigureAwait(false);
            Assert.IsTrue(StringUtils.ToStringRepresentation(storagePolicyAssignment.Type) == "storage_policy_assignment");
            Assert.IsTrue(StringUtils.ToStringRepresentation(NullableUtils.Unwrap(storagePolicyAssignment.AssignedTo).Type) == "user");
            Assert.IsTrue(NullableUtils.Unwrap(storagePolicyAssignment.AssignedTo).Id == newUser.Id);
            StoragePolicyAssignment getStoragePolicyAssignment = await client.StoragePolicyAssignments.GetStoragePolicyAssignmentByIdAsync(storagePolicyAssignmentId: storagePolicyAssignment.Id).ConfigureAwait(false);
            Assert.IsTrue(getStoragePolicyAssignment.Id == storagePolicyAssignment.Id);
            StoragePolicyAssignment updatedStoragePolicyAssignment = await client.StoragePolicyAssignments.UpdateStoragePolicyAssignmentByIdAsync(storagePolicyAssignmentId: storagePolicyAssignment.Id, requestBody: new UpdateStoragePolicyAssignmentByIdRequestBody(storagePolicy: new UpdateStoragePolicyAssignmentByIdRequestBodyStoragePolicyField(id: storagePolicy2.Id, type: UpdateStoragePolicyAssignmentByIdRequestBodyStoragePolicyTypeField.StoragePolicy))).ConfigureAwait(false);
            Assert.IsTrue(NullableUtils.Unwrap(updatedStoragePolicyAssignment.StoragePolicy).Id == storagePolicy2.Id);
            await client.StoragePolicyAssignments.DeleteStoragePolicyAssignmentByIdAsync(storagePolicyAssignmentId: storagePolicyAssignment.Id).ConfigureAwait(false);
            await client.Users.DeleteUserByIdAsync(userId: newUser.Id).ConfigureAwait(false);
        }

    }
}