using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ExtendedModels
{
  //  `name` varchar(100) NOT NULL,
  //`description` varchar(1000) NOT NULL,
  //`price` decimal (10,2) NOT NULL,
  //`discounted_price` decimal (10,2) NOT NULL DEFAULT '0.00',
  //`image` varchar(150) DEFAULT NULL,
  //`image_2` varchar(150) DEFAULT NULL,
  //`thumbnail` varchar(150) DEFAULT NULL,
  //`display` smallint(6) NOT NULL DEFAULT '0',

        /// <summary>
        /// Table structure
        /// </summary>
    public  class ProductExtended
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double DiscountedPrice { get; set; }

        public string Image { get; set; }

        public string Image2 { get; set; }

        public string Thumbnail { get; set; }

        public Int16 Display { get; set; }

        public ProductExtended()
        {

        }

        public ProductExtended(Product product)
        {
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            DiscountedPrice = product.DiscountPrice;
            Image = product.Image;
            Image2 = product.Image2;
            Thumbnail = product.ThumbNail;
            Display = product.Display;
        }
    }
}
