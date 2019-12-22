using eBookStoreServices.Data.Interfaces;
using eBookStoreServices.Entities.Models;
using eBookStoreServices.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStoreServices.Services.Services
{
    public class BookService : IBookService
    {
        private IBookRepository _booksRepo;
        public BookService(IBookRepository bookRepo)
        {
            _booksRepo = bookRepo;
        }
        public bool AddNewBook(Book bookDetails)
        {
            return this._booksRepo.AddNewBook(bookDetails);
        }

        public bool DeleteBook(int id)
        {
            return this._booksRepo.DeleteBook(id);
        }

        public List<Book> GetAllBooks()
        {
            return this._booksRepo.GetAllBooks();
        }

        public Book GetBook(int id)
        {
            return this._booksRepo.GetBook(id);
        }

        public bool UpdateBookDetails(Book bookDetails)
        {
            return this._booksRepo.UpdateBookDetails(bookDetails);
        }
    }
}
