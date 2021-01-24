using System;
using System.ComponentModel.DataAnnotations;

namespace GraphQLvsRest.Abstractions.Types
{
    /// <summary> Author. </summary>
    public class Author
    {
        public Author(int id, string name, DateTime birthDate)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
        }

        [Required]
        /// <summary> Author's identifier. < /summary>
        public int Id { get; }

        [Required]
        /// <summary> Author's full name. </summary>
        public string Name { get; }

        [Required]
        /// <summary> Birth date. </summary>
        public DateTime BirthDate { get; }
    }
}
