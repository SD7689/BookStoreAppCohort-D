using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
