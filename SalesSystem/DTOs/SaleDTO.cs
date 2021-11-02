using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SalesSystem.DTOs
{
    public class SaleDTO
    {
        public SaleDTO()
        {
            this.Concepts = new List<ConceptDTO>();
        }
        /// <summary>
        /// Id of Client
        /// </summary>
        [Required(ErrorMessage = "The field ClientId is required")]
        //[Range(1, Double.MaxValue, ErrorMessage = "The field ClientId must be greater than 0")]
        public int ClientId { get; set; }
        /// <summary>
        /// Total of Sale
        /// </summary>
        [Required(ErrorMessage = "The field Total is required")]
        //[RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Error")]
        //[Range(0, 99999999999999.99, ErrorMessage = "Error range")]
        public decimal Total { get; set; }
        /// <summary>
        /// Concepts by Sale
        /// </summary>
        [Required]
        [MinLength(1, ErrorMessage = "There must be concepts")]
        public List<ConceptDTO> Concepts {get; set;}
    }

    public class ConceptDTO
    {
        public int Quantity { get; set; }
        public decimal Unitprice { get; set; }
        public decimal Amount { get; set; }
        public int ProductId { get; set; }

    }
}
