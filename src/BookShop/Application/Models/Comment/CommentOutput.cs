using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Models.Comment
{
    public class CommentOutput
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public required string UserName { get; set; }
        public required string Note { get; set; }
        public int BookId { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
