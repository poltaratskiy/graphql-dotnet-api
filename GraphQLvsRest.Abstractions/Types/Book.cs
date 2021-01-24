namespace GraphQLvsRest.Abstractions.Types
{
    public class Book
    {
        public Book(int id, string name, Author author, int? year = null)
        {
            Id = id;
            Name = name;
            Author = author;
            Year = year;
        }

        /// <summary> Identifier of the book. < /summary>
        public int Id { get; }

        /// <summary> Name of the book. </summary>
        public string Name { get; }

        /// <summary> Author. </summary>
        public Author Author { get; }

        /// <summary> Year when book was written. </summary>
        public int? Year { get; }
    }
}
