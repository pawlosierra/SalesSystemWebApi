using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SalesSystem.DTOs
{
    public class ClientDTO
    {
        /// <summary>
        /// Name of the client
        /// </summary>
        //public int Id { get; set; }
        [Required(ErrorMessage = "The field Name is required")]
        [StringLength(50)]
        
        public string Name { get; set; }
    }
}
