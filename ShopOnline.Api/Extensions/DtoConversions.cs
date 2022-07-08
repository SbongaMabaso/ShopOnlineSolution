using ShopOnline.Api.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products,
                                                            IEnumerable<ProductCategory> productCategories)
        {
            //return data from data
            return (from product in products
                    join productCategory in productCategories
                    on product.CategoryId equals productCategory.Id
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Desciption = product.Description,
                        ImageURL = product.ImageURL,
                        Price = product.Price,
                        Qty = product.Qty,
                        CategoryId = product.CategoryId,
                        CategoryName = productCategory.Name
                    }).ToList();
        }

        //Filter by category
        public static ProductDto ConvertToDto(this Product product, ProductCategory productCategory)
        {
            //return data from database
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Desciption = product.Description,
                ImageURL = product.ImageURL,
                Price = product.Price,
                Qty = product.Qty,
                CategoryId = product.CategoryId,
                CategoryName = productCategory.Name
            };
        }

        public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems, IEnumerable<Product> products)
        {
            return (from cartItem in cartItems
                    join product in products
                    on cartItem.ProductId equals product.Id
                    select new CartItemDto
                    {
                        ProductId = cartItem.ProductId,
                        Id = cartItem.Id,
                        ProductName = product.Name,
                        ProductDesciption = product.Description,
                        ProductImageURL = product.ImageURL,
                        Price = product.Price,
                        Qty = cartItem.Qty,
                        CartId = cartItem.CartId,
                        TotalPrice = product.Price * cartItem.Qty
                    }).ToList();
        }

        //
        public static CartItemDto ConvertToDto(this CartItem cartItem, Product product)
        {
            return new CartItemDto
            {
                Id = cartItem.Id,
                ProductId = cartItem.ProductId,
                ProductName = product.Name,
                ProductDesciption = product.Description,
                ProductImageURL = product.ImageURL,
                Price = product.Price,
                Qty = cartItem.Qty,
                CartId = cartItem.CartId,
                TotalPrice = product.Price * cartItem.Qty
            };
        }
    }
}
