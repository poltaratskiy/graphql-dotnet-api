using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

#nullable disable
namespace GraphQLvsRest.Data.Dto
{
    [Table("BOOK")]
    public class Book
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("NAME")]
        public string Name { get; set; }

        [Column("YEAR")]
        public int? Year { get; set; }

        [Required]
        [Column("AUTHOR_ID")]
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
