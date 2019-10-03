using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    
        [Table("Product")]
        public class Product : IEntity
        {
            [Key]
            [Column("product_id")]
            public Guid Id { get; set; }

            [Required(ErrorMessage = "Name is required")]
            [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
            public string Name { get; set; }

            [Required(ErrorMessage ="Description is required")]
            public string Description { get; set; }

            [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
            public double Price { get; set; }

            [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Discounted price")]
            public double DiscountPrice { get; set; }

            public string Image { get; set; }

            public string Image2 { get; set; }

            public string ThumbNail { get; set; }

            public Int16 Display { get; set; }


        }
}
