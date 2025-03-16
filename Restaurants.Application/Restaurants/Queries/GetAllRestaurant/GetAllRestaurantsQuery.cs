using MediatR;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurant;

public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
{
}
