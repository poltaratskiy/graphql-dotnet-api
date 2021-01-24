using GraphQLvsRest.Abstractions;
using GraphQLvsRest.Abstractions.Types;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLvsRest.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookStorage _bookStorage;

        public BooksController(IBookStorage bookStorage)
        {
            _bookStorage = bookStorage;
        }

        /// <summary> Find book by identifier. </summary>
        /// <param name="id"> Identifier. </param>
        /// <returns> Book. </returns>
        [HttpGet]
        [Route("getbook")]
        public Task<Book?> GetBook(int id) => _bookStorage.FindBook(id);

        /// <summary> Find all books satisfying filter conditions. </summary>
        /// <param name="filter"> Filter. </param>
        /// <returns> Search result. </returns>
        [HttpPost]
        [Route("findbooks")]
        public Task<IEnumerable<Book>> FindBooks(GetBooksFilter filter) => _bookStorage.FindBooks(filter);

        /// <summary> Add book to storage. </summary>
        /// <param name="author"> New book. </param>
        /// <returns> Added book. </returns>
        [HttpPut]
        [Route("addbook")]
        public Task<Book?> AddBook(AddBookRequest request) => _bookStorage.AddBook(request);
    }
}
