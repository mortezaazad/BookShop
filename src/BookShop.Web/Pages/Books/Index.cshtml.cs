using BookShop.Infrastracture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.Web.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext dbContext)
        {
                _db=dbContext;
        }
        public void OnGet()
        {
            var BookList=_db.Books.ToList();
        }
    }
}
