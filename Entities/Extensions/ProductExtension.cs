using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Extensions
{
    public static class ProductExtension
    {
        public static void Map(this Product dbProduct, Product product)
        {
            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Price = product.Price;
            dbProduct.DiscountPrice = product.DiscountPrice;
            dbProduct.Image = product.Image;
            dbProduct.Image2 = product.Image2;
            dbProduct.ThumbNail = product.ThumbNail;
            dbProduct.Display = product.Display;
        }

    }
}
