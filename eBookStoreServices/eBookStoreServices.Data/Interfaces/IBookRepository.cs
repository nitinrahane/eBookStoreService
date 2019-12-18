using eBookStoreServices.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStoreServices.Data.Interfaces
{
    public interface IBookRepository
    {
        bool AddNewBook(Book bookDetails);
        List<Book> GetAllBooks();
        Book GetBook(int id);
        bool UpdateBookDetails(Book bookDetails);
        bool DeleteBook(int id);

    }
}
