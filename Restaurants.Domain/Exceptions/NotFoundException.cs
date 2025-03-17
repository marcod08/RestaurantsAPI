namespace Restaurants.Domain.Exceptions;

public class NotFoundException(string resourceType, string resourceIdentity) 
    : Exception($"{resourceType} with id: {resourceIdentity} doesn't exist")
{
}
