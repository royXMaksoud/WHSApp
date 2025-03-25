using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using WHS.Domain.Constants;
using Xunit;

namespace WHS.Application.UserAuth.Tests
{
    public class UserContextTests
    {
        [Fact()]
        public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
        {
            // arrange
            var dateOfBirth = new DateOnly(1990, 1, 1);

            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var claims = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, "3b4906b9-4ea6-41e8-9ece-edea7dd05d26"),
                new(ClaimTypes.Email, "owner@test.com"),
                new(ClaimTypes.Role, UserRoles.Admin),
                new(ClaimTypes.Role, UserRoles.User),
                new("Nationality", "Spain"),
                new("DateOfBirth", dateOfBirth.ToString("yyyy-MM-dd"))
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
            {
                User = user
            });

            var userContext = new UserContext(httpContextAccessorMock.Object);

            // act
            var currentUser = userContext.GetCurrentUser();

            // asset

            currentUser.Should().NotBeNull();
            currentUser.Id.Should().Be("3b4906b9-4ea6-41e8-9ece-edea7dd05d26");
            currentUser.Email.Should().Be("owner@test.com");
            currentUser.Roles.Should().ContainInOrder(UserRoles.Admin, UserRoles.User);
            currentUser.Nationality.Should().Be("Spain");
            currentUser.DateOfBirth.Should().Be(dateOfBirth);
        }

        [Fact]
        public void GetCurrentUser_WithUserContextNotPresent_ThrowsInvalidOperationException()
        {
            // Arrange
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock.Setup(x => x.HttpContext).Returns((HttpContext)null);

            var userContext = new UserContext(httpContextAccessorMock.Object);

            // act

            Action action = () => userContext.GetCurrentUser();

            // assert

            action.Should()
                .Throw<InvalidOperationException>()
                .WithMessage("User context is not present");
        }
    }
}