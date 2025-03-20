using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Command.AssignUserRole;

public class AssignUserRoleCommandHandler(ILogger<AssignUserRoleCommandHandler> logger,
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignUserRoleCommand>
{
    public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning user role: {@Request}", request);
        var user = await userManager.FindByEmailAsync(request.UserMail);

        if (user == null) throw new NotFoundException(nameof(User), request.UserMail);

        var role = await roleManager.FindByNameAsync(request.Rolename);

        if (role == null) throw new NotFoundException(nameof(IdentityRole), request.Rolename);

        await userManager.AddToRoleAsync(user, role.Name!);

    }
}
