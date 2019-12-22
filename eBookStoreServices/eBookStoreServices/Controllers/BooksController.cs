using eBookStoreServices.Entities.Models;
using eBookStoreServices.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eBookStoreServices.Controllers
{
    [Authorize]
    public class BooksController : ApiController
    {
        private IBookService _booksService;
        public BooksController(IBookService bookService) {
            _booksService = bookService;
        }

        // GET api/<controller>
        public IEnumerable<Book> Get()
        {
            return _booksService.GetAllBooks();            
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)        {
            var bookDetails = _booksService.GetBook(id);
            if (bookDetails == null)
            {
                return NotFound();
            }
            return Ok(bookDetails);
        }
        


        // POST api/<controller>
        public IHttpActionResult Post(Book book)
        {
            bool result = _booksService.AddNewBook(book);
            if (result)
            {
                return Ok(book);
            }
            return BadRequest();
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(Book book)
        {
            bool result = _booksService.UpdateBookDetails(book);
            if (result)
            {
                return Ok(book);
            }
            return BadRequest();
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            bool result = _booksService.DeleteBook(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}