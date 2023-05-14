using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.Web.Pages.Shop
{
    public class ReceiptModel : PageModel
    {
        public void OnGet()
        {
            var orderId = TempData[Values.OrderId];

        }
    }
}
