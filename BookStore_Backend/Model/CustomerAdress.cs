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
   public class CustomerAdress
    {
        [Key]
<<<<<<< HEAD
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; }
=======
        public string Email { get; set; }
>>>>>>> 27c0d5b3e85f55f3be70bdfaeda7a57e78cf9e5a
        [Required]
        public string FullName { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
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
