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
        [Required]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Pincode { get; set; }
        [Required]
        public string Citytown { get; set; }
        [Required]
        public string Landmark { get; set; }
        [Required]
        public string AddressType { get; set; }

    }
}
