using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SalesSystem.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "The field Name is required")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field Unitprice is required")]
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage ="xxxxxxxxxx")]
        [Range(0, 99999999999999.99, ErrorMessage ="xxxxxxxxxxxx")]
        public decimal Unitprice { get; set; }
        [Required(ErrorMessage = "The field Unitprice is required")]
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "xxxxxxxxxx")]
        [Range(0, 99999999999999.99, ErrorMessage = "xxxxxxxxxxxx")]
        public decimal Cost { get; set; }
    }
}
