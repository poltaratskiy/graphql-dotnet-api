namespace GraphQLvsRest.Abstractions.Types
{
    /// <summary> Request for adding book to storage. </summary>
    public class AddBookRequest
    {
        public AddBookRequest(string name, int authorId)
        {
            Name = name;
            AuthorId = authorId;
        }

        public AddBookRequest(string name, int authorId, int? year = null)
        {
            Name = name;
            AuthorId = authorId;
            Year = year;
        }

        /// <summary> Name of the book. </summary>
        public string Name { get; }

        /// <summary> Author identifier. </summary>
        public int AuthorId { get; }

        /// <summary> Year when book was written. </summary>
        public int? Year { get; }
    }
}
