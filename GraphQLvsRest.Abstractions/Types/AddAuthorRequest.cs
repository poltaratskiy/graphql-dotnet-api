using System;

namespace GraphQLvsRest.Abstractions.Types
{
    /// <summary> Request for adding author to storage. </summary>
    public class AddAuthorRequest
    {
        public AddAuthorRequest(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        /// <summary> Author's full name. </summary>
        public string Name { get; }

        /// <summary> Author's birth date. </summary>
        public DateTime BirthDate { get; }
    }
}
