using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookShop.Application.Models;
using BookShop.Infrastracture.DataModels;
using System.ComponentModel.DataAnnotations;
using BookShop.Application;
using Mapster;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShop.Web.Areas.Admin.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly IBookService _bookService;
        public EditModel(IBookService bookService)
        {
            _bookService = bookService;
        }
        [BindProperty]
        public BookEditInput Input { get; set; }
        public byte[]? CoverImageContent { get; set; }
        public SelectList CategorySelectList{ get; set; }
        public void OnGet(int bookId)
        {
            var categories=_bookService.GetAllCategories();
            CategorySelectList = new SelectList(categories, "Id", "Name");
            var model = _bookService.GetEdit(bookId);
            Input = model.Adapt<BookEditInput>();
            CoverImageContent = model.CoverImage;
        }

        public IActionResult OnPost() 
        {
            var createModel=Input.Adapt<BookEditModel>();

            if(Input.CoverImageFile is not null)
            {
                using var ms=new MemoryStream();
                Input.CoverImageFile.CopyTo(ms);
                ms.Position= 0;
                createModel.CoverImage=ms.ToArray();
            }
            _bookService.update(createModel.Adapt<BookEditModel>());
            return RedirectToPage("./index");
        }
    }

    public class BookEditInput
    {
        public int Id { get; set; }
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
        public IFormFile? CoverImageFile { get; set; }
    }
}
