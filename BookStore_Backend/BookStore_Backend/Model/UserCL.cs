using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class UserCL
    {
        [Key]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
