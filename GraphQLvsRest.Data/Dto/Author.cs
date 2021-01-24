using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace GraphQLvsRest.Data.Dto
{
    [Table("AUTOR")]
    public class Author
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("NAME")]
        public string Name { get; set; }

        [Required]
        [Column("BIRTH_DATE")]
        public DateTime BirthDate { get; set; }

        [InverseProperty("Author")]
        public virtual ICollection<Book> Books { get; set; }
    }
}
