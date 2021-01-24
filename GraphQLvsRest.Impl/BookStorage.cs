using AutoMapper;
using GraphQLvsRest.Abstractions;
using GraphQLvsRest.Abstractions.Types;
using GraphQLvsRest.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GraphQLvsRest.Impl
{
    public class BookStorage : IBookStorage
    {
        private readonly IMapper _mapper;
        private readonly IDbContextFactory<BooksDbContext> _contextFactory;
        private readonly ILogger<IBookStorage> _logger;

        public BookStorage(IDbContextFactory<BooksDbContext> contextFactory, IMapper mapper, ILogger<IBookStorage> logger)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
            _logger = logger;

            FillData().GetAwaiter().GetResult();
            _logger.LogInformation("Started");
        }

        public async Task<Author?> AddAuthor(AddAuthorRequest author)
        {
            var dbAuthor = _mapper.Map<Data.Dto.Author>(author);

            using var context = _contextFactory.CreateDbContext();
            context.Authors.Add(dbAuthor);
            await context.SaveChangesAsync();

            return await FindAuthor(dbAuthor.Id);
        }

        public async Task<Book?> AddBook(AddBookRequest book)
        {
            var dbBook = _mapper.Map<Data.Dto.Book>(book);

            using var context = _contextFactory.CreateDbContext();
            context.Books.Add(dbBook);
            await context.SaveChangesAsync();

            return await FindBook(dbBook.Id);
        }

        public async Task<Author?> FindAuthor(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var dbAuthor = await context.Authors.FindAsync(id);
            return _mapper.Map<Author?>(dbAuthor);
        }

        public async Task<IEnumerable<Author>> FindAuthors(string name)
        {
            using var context = _contextFactory.CreateDbContext();
            var dbAuthors = await context.Authors.Where(x => EF.Functions.Like(x.Name, $"%{name}%")).ToArrayAsync();
            return _mapper.Map<IEnumerable<Author>>(dbAuthors);
        }

        public async Task<Book?> FindBook(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var dbBook = await context.Books.FindAsync(id);
            return _mapper.Map<Book?>(dbBook);
        }

        public async Task<IEnumerable<Book>> FindBooks(GetBooksFilter filter)
        {
            using var context = _contextFactory.CreateDbContext();
            var query = context.Books.Include(x => x.Author).AsQueryable();

            if (!string.IsNullOrEmpty(filter.Author))
            {
                query = query.Where(x => EF.Functions.Like(x.Author.Name, $"%{filter.Author}%"));
            }

            if (!string.IsNullOrEmpty(filter.BookName))
            {
                query = query.Where(x => EF.Functions.Like(x.Name, $"%{filter.BookName}%"));
            }

            var dbBooks = await query.ToArrayAsync();
            return _mapper.Map<IEnumerable<Book>>(dbBooks);
        }

        private async Task FillData()
        {
            using var context = _contextFactory.CreateDbContext();
            if (await context.Database.EnsureCreatedAsync())
            {
                var pushkin = new Data.Dto.Author { Name = "Alexander Pushkin", BirthDate = DateTime.Parse("1799-06-06") };
                var lermontov = new Data.Dto.Author { Name = "Mikhail Lermontov", BirthDate = DateTime.Parse("1814-10-03") };

                context.Add(pushkin);
                context.Add(lermontov);
                context.Add(new Data.Dto.Book { Author = pushkin, Name = "Ruslan and Ludmila", Year = 1820 });
                context.Add(new Data.Dto.Book { Author = pushkin, Name = "Mozart and Salieri", Year = 1830 });
                context.Add(new Data.Dto.Book { Author = pushkin, Name = "Boris Godunov", Year = 1825 });

                context.Add(new Data.Dto.Book { Author = lermontov, Name = "A hero of our time", Year = 1840 });
                context.Add(new Data.Dto.Book { Author = lermontov, Name = "Borodino", Year = 1837 });
                context.Add(new Data.Dto.Book { Author = lermontov, Name = "Bela", Year = 1839 });

                await context.SaveChangesAsync();
            }
        }
    }
}
