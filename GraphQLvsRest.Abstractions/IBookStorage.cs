using GraphQLvsRest.Abstractions.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLvsRest.Abstractions
{
    /// <summary> Books catalog. </summary>
    public interface IBookStorage
    {
        /// <summary> Find book by identifier. </summary>
        /// <param name="id"> Identifier. </param>
        /// <returns> Book. </returns>
        Task<Book?> FindBook(int id);

        /// <summary> Find all books satisfying filter conditions. </summary>
        /// <param name="filter"> Filter. </param>
        /// <returns> Search result. </returns>
        Task<IEnumerable<Book>> FindBooks(GetBooksFilter filter);

        /// <summary> Find author by identifier. </summary>
        /// <param name="id"> Identifier. </param>
        /// <returns> Author. </returns>
        Task<Author?> FindAuthor(int id);

        /// <summary> Find all authors by template of author's name. </summary>
        /// <param name="name"> Name template. </param>
        /// <returns> Search result. </returns>
        Task<IEnumerable<Author>> FindAuthors(string name);

        /// <summary> Add author to storage. </summary>
        /// <param name="author"> New author. </param>
        /// <returns> Added author. </returns>
        Task<Author?> AddAuthor(AddAuthorRequest author);

        /// <summary> Add book to storage. </summary>
        /// <param name="author"> New book. </param>
        /// <returns> Added book. </returns>
        Task<Book?> AddBook(AddBookRequest book);
    }
}
