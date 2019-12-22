using eBookStoreServices.Controllers;
using eBookStoreServices.Entities.Models;
using eBookStoreServices.Services.Interfaces;
using eBookStoreServices.TestHelpers.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace eBookStoreServices.UnitTest
{
    [TestClass]
    public class TestCartController
    {
        [TestMethod]
        public void GetCartItems_ShouldReturnCartItems()
        {
            //Arrange
            var mock = new Mock<ICartService>();

            mock.Setup(x => x.GetCartItems(It.IsAny<string>())).Returns(DataInitializer.GetCartItems());

            var cartController = new CartController(mock.Object);
            //Act
            var result = cartController.Get();
            //Assert
            Assert.AreEqual(1, result.FirstOrDefault().ID);
        }


        [TestMethod]
        public void PostCartItem_ShouldReturnItem()
        {
            //Arrange
            var mock = new Mock<ICartService>();
            mock.Setup(x => x.AddItemToCart(It.IsAny<CartItem>())).Returns(true);
            var cartController = new CartController(mock.Object);
            var result = cartController.Post(new CartItem()
            {
                BookID = DataInitializer.GetCartItems().FirstOrDefault().ID
            });
            var resultCartItem = result as OkNegotiatedContentResult<CartItem>;
            Assert.IsNotNull(resultCartItem);
            Assert.AreEqual(1, resultCartItem.Content.BookID);
        }

        [TestMethod]
        public void Put_ShouldRetuemItem()
        {
            // Arrange
            var mock = new Mock<ICartService>();

            mock.Setup(x => x.UpdateItemQuantity(It.IsAny<CartItem>())).Returns(true);
            var cartController = new CartController(mock.Object);
            // Act
            IHttpActionResult actionResult = cartController.Put(new CartItem() { BookID = 3, Quantity = 4, UserID = "" });

            // Assert          
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void Delete_ReturnsOk()
        {
            // Arrange
            var mock = new Mock<ICartService>();
            mock.Setup(x => x.DeleteItemFromCart(It.IsAny<CartItem>())).Returns(true);
            var controller = new CartController(mock.Object);

            // Act
            IHttpActionResult actionResult = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }
    }
}
