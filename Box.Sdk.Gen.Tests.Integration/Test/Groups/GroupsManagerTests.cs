using Microsoft.VisualStudio.TestTools.UnitTesting;
using NullableExtensions;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Box.Sdk.Gen;
using Box.Sdk.Gen.Schemas;
using Box.Sdk.Gen.Managers;

namespace Box.Sdk.Gen.Tests.Integration {
    [TestClass]
    public class GroupsManagerTests {
        public BoxClient client { get; }

        public GroupsManagerTests() {
            client = new CommonsManager().GetDefaultClient();
        }
        [TestMethod]
        public async System.Threading.Tasks.Task TestGetGroups() {
            Groups groups = await client.Groups.GetGroupsAsync().ConfigureAwait(false);
            Assert.IsTrue(NullableUtils.Unwrap(groups.TotalCount) >= 0);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestCreateGetDeleteGroup() {
            string groupName = Utils.GetUUID();
            const string groupDescription = "Group description";
            GroupFull group = await client.Groups.CreateGroupAsync(requestBody: new CreateGroupRequestBody(name: groupName) { Description = groupDescription }).ConfigureAwait(false);
            Assert.IsTrue(group.Name == groupName);
            GroupFull groupById = await client.Groups.GetGroupByIdAsync(groupId: group.Id, queryParams: new GetGroupByIdQueryParams() { Fields = Array.AsReadOnly(new [] {"id","name","description","group_type"}) }).ConfigureAwait(false);
            Assert.IsTrue(groupById.Id == group.Id);
            Assert.IsTrue(groupById.Description == groupDescription);
            string updatedGroupName = Utils.GetUUID();
            GroupFull updatedGroup = await client.Groups.UpdateGroupByIdAsync(groupId: group.Id, requestBody: new UpdateGroupByIdRequestBody() { Name = updatedGroupName }).ConfigureAwait(false);
            Assert.IsTrue(updatedGroup.Name == updatedGroupName);
            await client.Groups.DeleteGroupByIdAsync(groupId: group.Id).ConfigureAwait(false);
            await Assert.That.IsExceptionAsync(async() => await client.Groups.GetGroupByIdAsync(groupId: group.Id).ConfigureAwait(false));
        }

    }
}