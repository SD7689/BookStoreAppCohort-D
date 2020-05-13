﻿using System;
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

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; }

        public string Email { get; set; }

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
