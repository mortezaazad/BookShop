using BookShop.Application;
using BookShop.Application.Models;
using BookShop.Infrastracture;
using BookShop.Infrastracture.DataModels;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public SelectList CategorySelectList { get; set; }
        [BindProperty]
        public BookInput Input { get; set; }
        public void OnGet()
        {
            var categories = _bookService.GetAllCategories();
            CategorySelectList = new SelectList(categories, "Id", "Name");
        }

        public IActionResult OnPost()
        {
            if (Input.Year > DateTime.Now.Year)
            {
                ModelState.AddModelError("Year", "Not valid");
            }
            if (ModelState.IsValid == false)
            {
                //baraye mavaredi ke nemitavan ghanoon goash ba estefade az oon Data annotation
                ModelState.AddModelError(nameof(Pages), "Can not Create Book.");
                return Page();
            }
            using var ms = new MemoryStream();
            Input.CoverImageFile.CopyTo(ms);
            ms.Position = 0;


            //Manual Mapping
            //_bookService.Create(new Application.Models.BookCreateModel
            //{
            //    Author = Input.Author,
            //    Name = Input.Name,
            //    Description = Input.Description,
            //    Year = Input.Year,
            //    Pages = Input.Pages,
            //    CoverImage = ms.ToArray(),
            //    Price = Input.Price,
            //});

            //Use Mapster Mapping
            var model = Input.Adapt<BookCreateModel>();
            model.CoverImage = ms.ToArray();
            //FileStream fs = ms as FileStream;
            //model.FileName = fs.Name;
            _bookService.Create(model);

            return RedirectToPage("./Index");
        }
    }

    public class BookInput
    {
        public string Name { get; set; }
        public string? FileName { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
        [Range(1, 5000, ErrorMessage = "Pages must be between {1} and {2}")]
        public int Pages { get; set; }
        public LanguageType Language { get; set; }
        public int CategoryId { get; set; }
        public IFormFile CoverImageFile { get; set; }
    }
}
