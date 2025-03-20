using MediatR;

namespace Restaurants.Application.Users.Command.AssignUserRole;

public class AssignUserRoleCommand : IRequest
{
    public string UserMail { get; set; } = default!;
    public string Rolename { get; set; } = default!;
}
