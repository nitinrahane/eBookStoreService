using eBookStoreServices.Data.Interfaces;
using eBookStoreServices.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eBookStoreServices.Controllers
{
    public class BooksController : ApiController
    {
        private IBookRepository books;
        public BooksController(IBookRepository _book) {
            books = _book;
        }

        // GET api/<controller>
        public IEnumerable<Book> Get()
        {
            return books.GetAllBooks();            
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)        {
            var bookDetails = books.GetBook(id);
            if (bookDetails == null)
            {
                return NotFound();
            }
            return Ok(bookDetails);
        }
        


        // POST api/<controller>
        public IHttpActionResult Post(Book book)
        {
            bool result = books.AddNewBook(book);
            if (result)
            {
                return Ok(book);
            }
            return BadRequest();
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(Book book)
        {
            bool result = books.UpdateBookDetails(book);
            if (result)
            {
                return Ok(book);
            }
            return BadRequest();
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            bool result = books.DeleteBook(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}