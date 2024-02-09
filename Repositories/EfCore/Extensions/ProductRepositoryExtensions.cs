using Entities.Models;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace Repositories.EfCore.Extensions;
public static class ProductRepositoryExtensions
{
    public static IQueryable<Product> FilterProducts(this IQueryable<Product> products, uint minPrice, uint maxPrice) =>
        products
        .Where(product =>
        product.Price >= minPrice &&
        product.Price <= maxPrice);

    public static IQueryable<Product> Search(this IQueryable<Product> products, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return products;

        var lowerCaseTerm = searchTerm.Trim().ToLower();
        return products.Where(product => product.Name.ToLower().Contains(lowerCaseTerm) || product.Model.ToLower().Contains(lowerCaseTerm));
    }

    public static IQueryable<Product> Sort(this IQueryable<Product> products, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString)) return products.OrderBy(product => product.Id);

        var orderParams = orderByQueryString.Trim().Split(',');

        var propertyInfos = typeof(Product).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var orderQuery = OrderQueryBuilder.CreateOrderQuery<Product>(orderByQueryString);

        if (string.IsNullOrWhiteSpace(orderQuery))
            return products.OrderBy(product => product.Id);

        return products.OrderBy(orderQuery);
    }

}

