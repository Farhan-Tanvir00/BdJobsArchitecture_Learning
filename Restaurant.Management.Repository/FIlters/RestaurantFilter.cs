using Restaurant.Management.AggregateRoot.Entities;
using Restaurant.Management.DTO.Queries;
using Restaurant.Management.Shared.Interfaces.Filter;
using System.Linq.Expressions;

namespace Restaurant.Management.Repository.FIlters
{
    internal class RestaurantFilter : IFilter<RestaurantDetails, SearchRestaurantQuery>
    {
        public Expression<Func<RestaurantDetails, bool>> Build(SearchRestaurantQuery query)
        {
            return restaurant =>
            (string.IsNullOrWhiteSpace(query.RestaurantName) || restaurant.Name.Contains(query.RestaurantName)) &&

            (string.IsNullOrWhiteSpace(query.Category) || restaurant.Category == query.Category) &&

            (!query.HasDelivery.HasValue || restaurant.HasDelivery == query.HasDelivery.Value);
        }
    }

}
