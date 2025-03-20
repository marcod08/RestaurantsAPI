using MediatR;

namespace Restaurants.Application.Users.Command.UnassignUserRole;

public class UnassignUserRoleCommand : IRequest
{
    public string UserMail { get; set; } = default!;
    public string Rolename { get; set; } = default!;
}
