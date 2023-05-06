using BookShop.Application.Models;
using BookShop.Infrastracture;
using BookShop.Infrastracture.DataModels;
using Mapster;
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
            //Manual Mapping
            //_db.Books.Add(
            //    new BookData
            //    {
            //        Author = input.Author,
            //        Description = input.Description,
            //        Name = input.Name,
            //        Pages = input.Pages,
            //        Price = input.Price,
            //        Year = input.Year,
            //        CoverImage = input.CoverImage,
            //    });

            //Use Mapster Mapping
            _db.Books.Add(input.Adapt<BookData>());

            _db.SaveChanges();
        }

        public BookDetails GetDetails(int bookId)
        {
            var book = _db.Books.Find(bookId);

            //Manual Mapping
            //var result = new BookDetails
            //{
            //    Author = book.Author,
            //    Description = book.Description,
            //    Name = book.Name,
            //    Pages = book.Pages,
            //    Price = book.Price,
            //    Year = book.Year,
            //    CoverImage = book.CoverImage,
            //    Id=book.Id
            //};
            //return result;

            //Use Mapster Mapping
            return book.Adapt<BookDetails>();
        }

        public IList<BookItem> GetAll()
        {
            //Manual Mapping
            //return _db.Books.Select(b => new BookItem
            //{
            //    Id = b.Id,
            //    Name = b.Name,
            //    Price = b.Price
            //}).ToList();

            //Use Mapster Mapping
            return _db.Books.ProjectToType<BookItem>().ToList();

        }

    }
}
