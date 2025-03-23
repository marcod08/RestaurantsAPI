using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;

namespace Restaurants.Infrastructure.Authorization.Requirements;

public class MinimumAgeRequirementsHandler(ILogger<MinimumAgeRequirementsHandler> logger,
    IUserContext userContext) : AuthorizationHandler<MinimumAgeRequirements>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirements requirement)
    {
        var currentUser = userContext.GetCurrentUser();
        logger.LogInformation("User: {Email}, date of birth {DoB} - Handling MinimumAgeRequirement", 
            currentUser.Email,
            currentUser.DateOfBirth);

        if (currentUser.DateOfBirth == null)
        {
            logger.LogWarning("User date of birth is null");
            context.Fail();
            return Task.CompletedTask;
        }
        
        if(currentUser.DateOfBirth.Value.AddYears(requirement.MinimumAge) <= DateOnly.FromDateTime(DateTime.Today))
        {
            logger.LogInformation("Authorization succeded");
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;
    }
}
