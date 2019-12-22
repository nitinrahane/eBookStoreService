using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using eBookStoreServices.Controllers;
using eBookStoreServices.Entities.Models;
using eBookStoreServices.Services.Interfaces;
using eBookStoreServices.TestHelpers.Helpers;
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
            var mock = new Mock<IBookService>();
            mock.Setup(x => x.GetAllBooks()).Returns(DataInitializer.GetBooks());
            var mockResult = mock.Object.GetAllBooks();
            var booksController = new BooksController(mock.Object);
            //Act
            var result = booksController.Get();
            //Assert
            Assert.IsTrue(result.Count() == mockResult.Count, "The books are present.");
        }

        [TestMethod]
        public void GetBooks_ShouldReturnBook()
        {
            //Arrange
            var mock = new Mock<IBookService>();
            mock.Setup(x => x.GetBook(It.IsAny<int>())).Returns(DataInitializer.GetBooks().First());
            var booksController = new BooksController(mock.Object);

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
            var mock = new Mock<IBookService>();
            mock.Setup(x => x.AddNewBook(It.IsAny<Book>())).Returns(true);
            var booksController = new BooksController(mock.Object);
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
        }


        [TestMethod]
        public void PutBook_ShouldReturnBook()
        {
            //Arrange
            var mock = new Mock<IBookService>();
            mock.Setup(x => x.UpdateBookDetails(It.IsAny<Book>())).Returns(true);
            var booksController = new BooksController(mock.Object);
            //Act
            IHttpActionResult result = booksController.Put(new Book()
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
        }

        [TestMethod]
        public void DeleteBook_ShouldReturnOk()
        {
            //Arrange
            var mock = new Mock<IBookService>();
            mock.Setup(x => x.DeleteBook(It.IsAny<int>())).Returns(true);
            var booksController = new BooksController(mock.Object);

            IHttpActionResult result = booksController.Delete(1);
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

    }
}
