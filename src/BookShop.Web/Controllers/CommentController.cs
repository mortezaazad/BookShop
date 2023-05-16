using BookShop.Application;
using BookShop.Application.Models.Comment;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookShop.Web.Controllers;

public class CommentController : Controller
{
    private readonly ICommentService _commentService;
    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    [Route("api/comments/{bookId}")]
    public IActionResult GetAllByBook(int bookId)
    {
        var comments= _commentService.GetAllByBook(bookId);
        return PartialView("_BookComments",comments);
    }

    [HttpPost]
    [Route("api/comments/{bookId}")]
    public IActionResult PostNewComment(string note,int bookId)
    {
        var userName = User.Identity.Name;
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        var userId = userIdClaim.Value;
        _commentService.Create(userId, userName, bookId, note);

        var output=new CommentOutput
        { 
            Note=note,
            UserId=userId,
            BookId=bookId,
            UserName=userName,
            TimeCreated=DateTime.Now
        };
        return PartialView("_LastComment", output);
    }
}
