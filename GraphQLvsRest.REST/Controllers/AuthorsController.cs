using GraphQLvsRest.Abstractions;
using GraphQLvsRest.Abstractions.Types;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLvsRest.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController()]
    public class AuthorsController : ControllerBase
    {
        private readonly IBookStorage _bookStorage;

        public AuthorsController(IBookStorage bookStorage)
        {
            _bookStorage = bookStorage;
        }

        /// <summary> Find author by identifier. </summary>
        /// <param name="id"> Author's identifier. </param>
        /// <returns> Search result. </returns>
        [HttpGet]
        [Route("getauthor")]
        public Task<Author?> GetAuthor(int id) => _bookStorage.FindAuthor(id);

        /// <summary> Find all authors by template of author's name. </summary>
        /// <param name="template"> Name template. </param>
        /// <returns> Search result. </returns>
        [HttpGet]
        [Route("getauthors")]
        public Task<IEnumerable<Author>> GetAuthors(string template) => _bookStorage.FindAuthors(template);

        /// <summary> Add author to storage. </summary>
        /// <param name="author"> New author. </param>
        /// <returns> Added author. </returns>
        [HttpPut]
        [Route("addauthor")]
        public Task<Author?> AddAuthor(AddAuthorRequest request) => _bookStorage.AddAuthor(request);
    }
}
