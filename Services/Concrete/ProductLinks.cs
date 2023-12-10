using Entities.DataTransferObjects.Product;
using Entities.LinkModels;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using Services.Contracts;

namespace Services.Concrete
{
    public class ProductLinks : IProductLinks
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IDataShaper<ProductDto> _dataShaper;

        public ProductLinks(LinkGenerator linkGenerator, IDataShaper<ProductDto> dataShaper)
        {
            _linkGenerator = linkGenerator;
            _dataShaper = dataShaper;
        }

        public LinkResponse TryGenerateLinks(IEnumerable<ProductDto> productDtos, string fields, HttpContext httpContext)
        {
            var shapedProducts = ShapeData(productDtos, fields);

            if (ShouldGenerateLinks(httpContext))
                return ReturnLinkdedProducts(productDtos, fields, httpContext, shapedProducts);

            return ReturnShapedProducts(shapedProducts);

        }

        private LinkResponse ReturnLinkdedProducts(IEnumerable<ProductDto> productDtos, string fields, HttpContext httpContext, List<Entity> shapedProducts)
        {
            var productDtoList = productDtos.ToList();

            for (var index = 0; index < productDtoList.Count; index++)
            {
                var productLinks = CreateLinksForProduct(httpContext, productDtoList[index].Id, fields);
                shapedProducts[index].Add("Links", productLinks);
            }

            var productCollection = new LinkCollectionWrapper<Entity>(shapedProducts);
            CreateLinkForProducts(httpContext, productCollection);
            return new LinkResponse { HasLinks = true, LinkedEntities = productCollection };
        }

        private List<Link> CreateLinksForProduct(HttpContext httpContext, int id, string fields)
        {
            var links = new List<Link>()
            {
                new Link
                {
                    Href=$"/api/{httpContext.GetRouteData().Values["controller"].ToString().ToLower()}"
                    + $"/{id}",
                    Rel="self",
                    Method="GET"
                },
                new Link
                {
                    Href =$"/api/{httpContext.GetRouteData().Values["controller"].ToString().ToLower()}",
                    Rel="create",
                    Method="POST"
                },

            };
            return links;
        }
        private LinkCollectionWrapper<Entity> CreateLinkForProducts(HttpContext httpContext, LinkCollectionWrapper<Entity> productCollectionWrapper)
        {
            productCollectionWrapper.Links.Add(new Link
            {
                Href = $"/api/{httpContext.GetRouteData().Values["controller"].ToString().ToLower()}",
                Rel = "self",
                Method = "GET"
            });
            return productCollectionWrapper;
        }

        private LinkResponse ReturnShapedProducts(List<Entity> shapedProducts)
        {
            return new LinkResponse { ShapedEntities = shapedProducts };
        }

        private bool ShouldGenerateLinks(HttpContext httpContext)
        {
            var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];
            return mediaType
                .SubTypeWithoutSuffix
                .EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
        }

        private List<Entity> ShapeData(IEnumerable<ProductDto> productDtos, string fields)
        {
            return _dataShaper
                .ShapeData(productDtos, fields)
                .Select(e => e.Entity)
                .ToList();
        }
    }
}
