using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore_System.Domain.Entities
{
    [Table("LIVRO")]
    public partial class LIVRO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string NOME { get; set; }

        [Required]
        [StringLength(200)]
        public string AUTOR { get; set; }

        [Required]
        [StringLength(200)]
        public string EDITORA { get; set; }

        public DateTime DATA_LANCAMENTO { get; set; }
    }
}
