using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringExtensions;
using System;
using Box;
using Box.Schemas;
using Box.Managers;

namespace Box.Tests.Integration {
    [TestClass]
    public class MembershipsManagerTests {
        public BoxClient client { get; }

        public MembershipsManagerTests() {
            client = new CommonsManager().GetDefaultClient();
        }
        [TestMethod]
        public async System.Threading.Tasks.Task TestMemberships() {
            UserFull user = await client.Users.CreateUserAsync(new CreateUserRequestBodyArg(name: Utils.GetUUID()) { Login = string.Concat(Utils.GetUUID(), "@boxdemo.com") }).ConfigureAwait(false);
            GroupMemberships userMemberships = await client.Memberships.GetUserMembershipsAsync(user.Id).ConfigureAwait(false);
            Assert.IsTrue(userMemberships.TotalCount == 0);
            GroupFull group = await client.Groups.CreateGroupAsync(new CreateGroupRequestBodyArg(name: Utils.GetUUID())).ConfigureAwait(false);
            GroupMemberships groupMemberships = await client.Memberships.GetGroupMembershipsAsync(group.Id).ConfigureAwait(false);
            Assert.IsTrue(groupMemberships.TotalCount == 0);
            GroupMembership groupMembership = await client.Memberships.CreateGroupMembershipAsync(new CreateGroupMembershipRequestBodyArg(user: new CreateGroupMembershipRequestBodyArgUserField(id: user.Id), group: new CreateGroupMembershipRequestBodyArgGroupField(id: group.Id))).ConfigureAwait(false);
            Assert.IsTrue(groupMembership.User!.Id == user.Id);
            Assert.IsTrue(groupMembership.Group!.Id == group.Id);
            Assert.IsTrue(StringUtils.ToStringRepresentation(groupMembership.Role) == "member");
            GroupMembership getGroupMembership = await client.Memberships.GetGroupMembershipByIdAsync(groupMembership.Id!).ConfigureAwait(false);
            Assert.IsTrue(getGroupMembership.Id == groupMembership.Id);
            GroupMembership updatedGroupMembership = await client.Memberships.UpdateGroupMembershipByIdAsync(groupMembership.Id!, new UpdateGroupMembershipByIdRequestBodyArg() { Role = UpdateGroupMembershipByIdRequestBodyArgRoleField.Admin }).ConfigureAwait(false);
            Assert.IsTrue(updatedGroupMembership.Id == groupMembership.Id);
            Assert.IsTrue(StringUtils.ToStringRepresentation(updatedGroupMembership.Role) == "admin");
            await client.Memberships.DeleteGroupMembershipByIdAsync(groupMembership.Id!).ConfigureAwait(false);
            await Assert.That.IsExceptionAsync(async() => await client.Memberships.GetGroupMembershipByIdAsync(groupMembership.Id!).ConfigureAwait(false));
            await client.Groups.DeleteGroupByIdAsync(group.Id).ConfigureAwait(false);
            await client.Users.DeleteUserByIdAsync(user.Id).ConfigureAwait(false);
        }

    }
}