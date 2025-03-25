using FluentAssertions;
using WHS.Domain.Constants;
using Xunit;

namespace WHS.Application.UserAuth.Tests
{
    public class CurrentUserTests
    {
        //TestMethod_Scenario_ExpectResult
        [Theory()]
        [InlineData(UserRoles.Admin)]
        [InlineData(UserRoles.User)]
        public void IsInRole_WithMatchingRole_ShouldReturnTrue(string p)
        {
            //arrange
            var currentUser = new CurrentUser("3b4906b9-4ea6-41e8-9ece-edea7dd05d26", "owner@test.com", [UserRoles.Admin, UserRoles.User], null, null);

            //act
            var isInRole = currentUser.IsInRole(p);

            //assert
            isInRole.Should().BeTrue();
        }

        [Fact()]
        public void IsInRole_WithNoMatchingRole_ShouldReturnFalse()
        {
            //arrange
            var currentUser = new CurrentUser("a5d33e54-599e-4476-8707-6f58d794ac9e", "dim@test.com", [UserRoles.Admin, UserRoles.User], null, null);

            //act
            var isInRole = currentUser.IsInRole(UserRoles.Owner);

            //assert
            isInRole.Should().BeFalse();
        }

        [Fact()]
        public void IsInRole_WithNoMatchingRoleCase_ShouldReturnFalse()
        {
            //arrange
            var currentUser = new CurrentUser("3b4906b9-4ea6-41e8-9ece-edea7dd05d26", "owner@test.com", [UserRoles.Admin, UserRoles.User], null, null);

            //act
            var isInRole = currentUser.IsInRole(UserRoles.Admin.ToLower());

            //assert
            isInRole.Should().BeFalse();
        }
    }
}