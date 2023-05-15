using BookShop.Application;
using BookShop.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookShop.Web.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class FileController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IOrderService _orderService;
        public FileController(IBookService bookService,IOrderService orderService ,IWebHostEnvironment webHostEnvironment)
        {
            _bookService = bookService;
            _webHostEnvironment = webHostEnvironment;
            _orderService = orderService;
        }

        [Authorize]
        [Route("api/book/download/{bookid}")]
        public IActionResult Download(int bookId) //REST GET
        {
            var UserIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var CurrentUserId = UserIdClaim.Value;

            var order=_orderService.GetUserBook(CurrentUserId, bookId);

            if (order is not null)
            {
                var book = _bookService.GetDetails(bookId);
                var path = Path.Combine(_webHostEnvironment.ContentRootPath, "Files", book.FileName);
                var content = System.IO.File.ReadAllBytes(path);

                return File(content, "application/pdf", book.FileName);
            }
             return NotFound();
        }
    }
}
