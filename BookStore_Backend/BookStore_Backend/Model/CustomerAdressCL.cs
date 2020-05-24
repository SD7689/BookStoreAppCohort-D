using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    /// <summary>
    /// Customer Adress Model class
    /// </summary>
   public class CustomerAdressCL
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "FullName required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "PhoneNumber required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Pincode required")]
        public int Pincode { get; set; }
        [Required(ErrorMessage = "Citytown required")]
        public string Citytown { get; set; }
        [Required]
        public string Landmark { get; set; }
        [Required]
        public string AddressType { get; set; }

    }
}
