using System;
using System.ComponentModel.DataAnnotations;

namespace Bookstore_System.MVC.DataTransferObject
{
    public class LivroDataTransferObject
    {        
        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string nome { get; set; }

        [Required]
        [StringLength(200)]
        public string autor { get; set; }

        [Required]
        [StringLength(200)]
        public string editora { get; set; }

        [Required]
        public DateTime data_lancamento { get; set; }
    }
}