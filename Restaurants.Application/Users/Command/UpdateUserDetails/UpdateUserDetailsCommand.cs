using MediatR;

namespace Restaurants.Application.Users.Command.UpdateUserDetails;

public class UpdateUserDetailsCommand : IRequest
{
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
}
