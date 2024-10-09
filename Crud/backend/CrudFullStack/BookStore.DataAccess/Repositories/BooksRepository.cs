using BookStore.Core.Models;
using BookStore.Core.Repositories;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace BookStore.DataAccess.Repositories
{
    public class BooksRepository: IBooksRepository
    {
        private readonly BookStoreDbContext _context;

        public BooksRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> Get()
        {
            var bookEntities = await _context.Books
                .AsNoTracking()
                .ToListAsync();

            var books = bookEntities
                .Select(x => Book.Create(x.Id, x.Title, x.Description, x.Price).Book)
                .ToList();

            return books;
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price
            };

            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, decimal price)
        {
            await _context.Books
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(t => t.Title, t => title)
                    .SetProperty(d => d.Description, d => description)
                    .SetProperty(p => p.Price, p => price));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Books
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            return id;
                
        }
    }
}
