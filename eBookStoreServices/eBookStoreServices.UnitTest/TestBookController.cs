using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using eBookStoreServices.Controllers;
using eBookStoreServices.Data.Interfaces;
using eBookStoreServices.Data.Repositories;
using eBookStoreServices.Entities.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace eBookStoreServices.UnitTest
{
    [TestClass]
    public class TestBookController
    {
        [TestMethod]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            //Arrange

            var booksController = new BooksController(new BookRepository());
            //Act
            var result = booksController.Get();
            //Assert
            Assert.IsTrue(result.Count() > 0, "The books are presents");            
        }

        [TestMethod]
        public void GetBooks_ShouldReturnBook()
        {
            //Arrange
            var booksController = new BooksController(new BookRepository());

            //Act
            IHttpActionResult result = booksController.Get(1);
            var resultBook = result as OkNegotiatedContentResult<Book>;

            //Assert
            Assert.AreEqual(1, resultBook.Content.ID);            
        }

        [TestMethod]
        public void PostBook_ShouldReturnBook()
        {
            //Arrange
            var booksController = new BooksController(new BookRepository());

            //Act
            IHttpActionResult result = booksController.Post(new Book()
            {
                Title = "Testing 1",
                Author = "Testing",
                Description = "Testing",
                PublishedYear = 2020,
                Price = 212,
                Publisher = "Testing"
            });
            var resultBook = result as OkNegotiatedContentResult<Book>;

            //Assert
            Assert.AreEqual(212, resultBook.Content.Price);

            //Arrange
            //var mockRepositoryClass = new Mock<IBookRepository>();
            //mockRepositoryClass.Setup(x => x.AddNewBook(new Book()
            //{
            //    Title = "Testing 1",
            //    Author = "Testing",
            //    Description = "Testing",
            //    PublishedYear = 2020,
            //    Price = 212,
            //    Publisher = "Testing"
            //})).Returns(true); 


            //var booksController = new BooksController(mockRepositoryClass.Object);

            //var result = booksController.Post(new Book()
            //{
            //    Title = "Testing 1",
            //    Author = "Testing",
            //    Description = "Testing",
            //    PublishedYear = 2020,
            //    Price = 212,
            //    Publisher = "Testing"
            //});
            //var resultBookItem = result as NegotiatedContentResult<Book>;
            //Assert.IsNotNull(resultBookItem);
            //Assert.AreEqual(3, resultBookItem.Content.ID);

        }
    }
}
