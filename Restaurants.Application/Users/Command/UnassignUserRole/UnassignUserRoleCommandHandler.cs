﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Command.UnassignUserRole;

public class UnassignUserRoleCommandHandler(ILogger<UnassignUserRoleCommandHandler> logger,
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager) : IRequestHandler<UnassignUserRoleCommand>
{
    public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Unassigning user role: {@Request}", request);
        var user = await userManager.FindByEmailAsync(request.UserMail);

        if (user == null) throw new NotFoundException(nameof(User), request.UserMail);

        var role = await roleManager.FindByNameAsync(request.Rolename);

        if (role == null) throw new NotFoundException(nameof(IdentityRole), request.Rolename);

        await userManager.RemoveFromRoleAsync(user, role.Name!);

    }
}
