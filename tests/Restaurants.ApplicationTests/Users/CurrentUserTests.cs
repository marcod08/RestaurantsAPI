using FluentAssertions;
using Restaurants.Domain.Constants;
using Xunit;

namespace Restaurants.Application.Users.Tests;

public class CurrentUserTests
{
    // TestMethod_Scenario_ExpectedResult
    [Theory()]
    [InlineData(UserRoles.Admin)]
    [InlineData(UserRoles.User)]
    public void isInRole_WithMatchingRole_ShouldReturnTrue(string roleName)
    {
        // arrange
        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User], null, null);

        // act
        var isInRole = currentUser.isInRole(roleName);

        // assert
        isInRole.Should().BeTrue();
    }

    [Fact()]
    public void isInRole_WithNoMatchingRole_ShouldReturnFalse()
    {
        // arrange
        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User], null, null);

        // act
        var isInRole = currentUser.isInRole(UserRoles.Owner);

        // assert
        isInRole.Should().BeFalse();
    }

    [Fact()]
    public void isInRole_WithNoMatchingRoleCase_ShouldReturnFalse()
    {
        // arrange
        var currentUser = new CurrentUser("1", "test@test.com", [UserRoles.Admin, UserRoles.User], null, null);

        // act
        var isInRole = currentUser.isInRole(UserRoles.Admin.ToLower());

        // assert
        isInRole.Should().BeFalse();
    }
}