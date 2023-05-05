using BookShop.Application;
using BookShop.Application.Models;
using BookShop.Infrastracture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Web.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly IBookService _bookService;
        public CreateModel(IBookService bookService)
        {
            _bookService = bookService;
        }
        [BindProperty]
        public BookInput Input { get; set; }

        public IActionResult OnPost()
        {
            if (Input.Year > DateTime.Now.Year)
            {
                ModelState.AddModelError("Year", "Not valid");
            }
            if (ModelState.IsValid == false)
            {
                //baraye mavaredi ke nemitavan ghanoon goash ba estefade az oon Data annotation
                ModelState.AddModelError("", "Can not Create Book.");
                return Page();
            }
            using var ms = new MemoryStream();
            Input.CoverImage.CopyToAsync(ms);
            ms.Position = 0;

            _bookService.Create(new Application.Models.BookCreateModel
            {
                Author = Input.Author,
                Name = Input.Name,
                Description = Input.Description,
                Year = Input.Year,
                Pages = Input.Pages,
                CoverImage = ms.ToArray(),
                Price = Input.Price,
            });
            return RedirectToPage("./Index");
        }
    }

    public class BookInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
        [Range(1, 5000, ErrorMessage = "Pages must be between {1} and {2}")]
        public int Pages { get; set; }

        public IFormFile CoverImage { get; set; }
    }
}
