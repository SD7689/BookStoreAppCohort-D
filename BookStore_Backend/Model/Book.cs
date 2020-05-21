using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    /// <summary>
    /// BookModel class
    /// </summary>
   public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookID { get; set; }
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string BookImage { get; set; }
        [Required]
        public double BookPrice { get; set; }
        [Required]
        public string Description { get; set; }

        public int Availability { get; set; }
    }
}
