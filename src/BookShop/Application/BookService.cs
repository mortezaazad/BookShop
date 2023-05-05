using BookShop.Application.Models;
using BookShop.Infrastracture;
using BookShop.Infrastracture.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _db;
        public BookService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(BookCreateModel input)
        {
            _db.Books.Add(
                new BookData
                {
                    Author = input.Author,
                    Description = input.Description,
                    Name = input.Name,
                    Pages = input.Pages,
                    Price = input.Price,
                    Year = input.Year,
                    CoverImage = input.CoverImage,
                });
            _db.SaveChanges();
        }

        public BookDetails GetDetails(int bookId)
        {
            var book = _db.Books.Find(bookId);
            var result = new BookDetails
            {
                Author = book.Author,
                Description = book.Description,
                Name = book.Name,
                Pages = book.Pages,
                Price = book.Price,
                Year = book.Year,
                CoverImage = book.CoverImage,
                Id=book.Id
            };
            return result;
        }

        public IList<BookItem> GetAll()
        {
            return _db.Books.Select(b => new BookItem
            {
                Id = b.Id
                ,
                Name = b.Name
                ,
                Price = b.Price
            }).ToList();
        }

    }
}
