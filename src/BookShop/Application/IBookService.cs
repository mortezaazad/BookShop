using BookShop.Application.Models;
using BookShop.Infrastracture.DataModels;

namespace BookShop.Application
{
    public interface IBookService
    {
        IList<BookItem> GetAll(string term="");
        void Create(BookCreateModel input);
        BookDetails GetDetails(int bookId);
        BookEditModel GetEdit(int bookId);
        void update(BookEditModel input);
        ICollection<BookCategory> GetAllCategories();
    }
}