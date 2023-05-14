using BookShop.Application;
using BookShop.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.Web.Areas.Admin.Pages.Books
{
    public class ReviewModel : PageModel
    {
        private readonly IBookService _bookService;
        public ReviewModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        //[BindProperty]
        public BookDetails Output{ get; set; }
        [BindProperty]
        public int BookId { get; set; }
        public void OnGet(int bookId)
        {
            Output= _bookService.GetDetails(bookId);
        }

        public void OnPost()
        {
            //Add Order to database
            //redirect to receipt page
        }
    }
}
