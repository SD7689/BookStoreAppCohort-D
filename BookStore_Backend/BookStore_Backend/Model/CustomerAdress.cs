using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreCommonLayer
{
    /// <summary>
    /// Customer Adress Model class
    /// </summary>
   public class CustomerAdress
    {
        [Key]
        public int CustomerID { get; set; }
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
        public string Landmark { get; set; }
        public string AddressType { get; set; }

    }
}
