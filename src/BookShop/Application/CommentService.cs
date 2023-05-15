using BookShop.Application.Models.Comment;
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

    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _db;
        public CommentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(string userId, string UserName, int bookId, string note)
        {
            _db.Comments.Add(new CommentData
            {
                Note = note,
                UserId = userId,
                UserName = UserName,
                BookId = bookId,
                TimeCreated = DateTime.Now
            });
            _db.SaveChanges();
        }

        public IList<CommentOutput> GetAllByBook(int bookId)
        {
            return _db.Comments
                .OrderByDescending(x => x.TimeCreated)
                .ProjectToType<CommentOutput>().ToList();
        }
    }
}
