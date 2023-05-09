using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Web.Areas.User.Pages
{
    public class IndexModel : PageModel
    {
        //public string? UserName { get; set; }
        //public string UserId { get; set; }
        //public void OnGet()
        //{
        //    UserName = User.Identity!.Name;
        //    var UserIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        //    UserId = UserIdClaim.Value;
        //}
        private readonly UserManager<ApplicationUser> _userManager;
        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public IList<ApplicationUser> UserList { get; set; }
        public async Task<IActionResult> OnGet()
        {
            UserList = await _userManager.Users.ToListAsync();
            return Page();
        }
    }
}
