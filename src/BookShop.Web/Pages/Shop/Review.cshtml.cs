using BookShop.Application;
using BookShop.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BookShop.Web.Areas.Admin.Pages.Books
{
    [Authorize]
    public class ReviewModel : PageModel
    {
        private readonly IBookService _bookService;
        private readonly IOrderService _orderService;
        public ReviewModel(IBookService bookService, IOrderService orderService)
        {
            _bookService = bookService;
            _orderService = orderService;
        }

        //[BindProperty]
        public BookDetails Output{ get; set; }
        [BindProperty]
        public int BookId { get; set; }
        public void OnGet(int bookId)
        {
            Output= _bookService.GetDetails(bookId);
            BookId=bookId;
        }

        public IActionResult OnPost()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim.Value;

            var book = _bookService.GetDetails(BookId);
            var orderId= _orderService.Create(new Application.Models.Order.OrderCreateModel
            {
                BookId = BookId,
                Amount = book.Price,
                UserId = userId
            });


            //Send to Bank/Peyment system!
            _orderService.Confirm(orderId);

            TempData[Values.OrderId] = orderId;

            //redirect to receipt page
            return RedirectToPage("./receipt");
        }
    }
}
