using Demo_ASP_Currency.Models;
using Demo_Mockup_Currency.Entities;

namespace Demo_ASP_Currency.Handlers
{
    internal static class Mapper
    {
        public static ProductListItem ToListItem(this Product entity) {
            if (entity is null) return null;
            return new ProductListItem() { 
                ProductId = entity.ProductId,
                ProductName = entity.ProductName,
                Price = entity.Price
            };
        }

        public static ProductDetails ToDetails(this Product entity)
        {
            if (entity is null) return null;
            return new ProductDetails()
            {
                ProductId = entity.ProductId,
                ProductName = entity.ProductName,
                Price = entity.Price
            };
        }

        public static Product ToProduct(this ProductCreateForm entity)
        {
            if (entity is null) return null;
            return new Product()
            {
                ProductName = entity.ProductName,
                Price = entity.Price
            };
        }
        public static Product ToProduct(this ProductEditForm entity)
        {
            if (entity is null) return null;
            return new Product()
            {
                ProductId = entity.ProductId,
                ProductName = entity.ProductName,
                Price = entity.Price
            };
        }
        public static ProductEditForm ToEditForm(this Product entity)
        {
            if (entity is null) return null;
            return new ProductEditForm()
            {
                ProductId = entity.ProductId,
                ProductName = entity.ProductName,
                Price = entity.Price
            };
        }
    }
}
