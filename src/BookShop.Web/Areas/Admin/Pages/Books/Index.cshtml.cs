using BookShop.Infrastracture;
using BookShop.Infrastracture.DataModels;
using BookShop.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookShop.Application.Models;

namespace BookShop.Web.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly IBookService _bookService;
        public IndexModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IList<BookItem>  BookList { get; set; }
        public void OnGet()
        {
            BookList = _bookService.GetAll();
        }
    }
}

