using BookShop.Application.Models;
using BookShop.Infrastracture;
using BookShop.Infrastracture.DataModels;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var book = _db.Books.Include(o=>o.Ratings)
                .ProjectToType<BookDetails>()
                .First(b=>b.Id==bookId);

            return book;

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

        }

        public IList<BookItem> GetAll(string term="")
        {
            var q = _db.Books;
            if (string.IsNullOrEmpty(term))
            {
                return q
                .Include(b => b.Category)
                .ProjectToType<BookItem>().ToList();
            }
            else
            {
                return q
                .Where(b => b.Name.ToLower().Contains(term))
                .Include(b => b.Category)
                .ProjectToType<BookItem>().ToList();
            }
            //Manual Mapping
            //return _db.Books.Select(b => new BookItem
            //{
            //    Id = b.Id,
            //    Name = b.Name,
            //    Price = b.Price
            //}).ToList();

            //Use Mapster Mapping
            

        }

        public BookEditModel GetEdit(int bookId)
        {
            var book = _db.Books.Find(bookId);
            return book.Adapt<BookEditModel>();
        }

        public void update(BookEditModel input)
        {
            var book = _db.Books.Find(input.Id);
            book.Name=input.Name;
            book.Description=input.Description;
            book.Author=input.Author;
            book.Price=input.Price;
            book.Language=input.Language;
            book.CategoryId=input.CategoryId;
            book.FileName = input.FileName;
            if (input.CoverImage is not null)
            {
                book.CoverImage = input.CoverImage;
            }
            _db.SaveChanges();
        }

        public ICollection<BookCategory> GetAllCategories()
        {
            return _db.Categories.ToList();
        }
    }
}
