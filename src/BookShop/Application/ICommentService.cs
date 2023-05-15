using BookShop.Application.Models.Comment;

namespace BookShop.Application
{
    public interface ICommentService
    {
        void Create(string userId, string UserName, int bookId, string note);
        IList<CommentOutput> GetAllByBook(int bookId);
    }
}