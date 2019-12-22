using eBookStoreServices.Controllers;
using eBookStoreServices.Entities.Models;
using eBookStoreServices.Services.Interfaces;
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
            //MOQ testing
            //Arrange
            var mockRepositoryClass = new Mock<ICartService>();

            mockRepositoryClass.Setup(x => x.GetCartItems("xyz")).Returns(new List<Entities.Models.CartItemDetails>() {
                new Entities.Models.CartItemDetails() { ID = 1 }
            });

            var cartController = new CartController(mockRepositoryClass.Object);

            //Act
            var result = cartController.Get().First();
            
            //Assert
            Assert.AreEqual(1, result.ID);
        }


        //[TestMethod]
        //public void PostCartItem_ShouldReturnItem()
        //{
        //    //Arrange
        //    var mockRepositoryClass = new Mock<ICartRepository>();
        //    mockRepositoryClass.Setup(x => x.AddItemToCart(new CartItem() { BookID = 3, UserID = 1 })).Returns(true);
        //    var cartController = new CartController(mockRepositoryClass.Object);


        //    var result = cartController.Post(new Entities.Models.CartItem() { BookID = 3, UserID = 1 });
        //    var resultCartItem = result as NegotiatedContentResult<CartItem>;
        //    Assert.IsNotNull(resultCartItem);
        //    Assert.AreEqual(3, resultCartItem.Content.BookID);
        //}

        //[TestMethod]
        //public void Put_ShouldRetuemItem()
        //{
        //    // Arrange
        //    var mockRepositoryClass = new Mock<ICartRepository>();

        //     mockRepositoryClass.Setup(x => x.UpdateItemQuantity(new CartItem() { BookID = 3, UserID = 1 }));
        //    var cartController = new CartController(mockRepositoryClass.Object);
        //    // Act
        //    IHttpActionResult actionResult = cartController.Put(new CartItem() { BookID = 3, Quantity = 4, UserID = 1});
        //    var result = actionResult as NegotiatedContentResult<CartItem>;

        //    // Assert
        //    Assert.IsNotNull(result);           
        //    Assert.IsNotNull(result.Content);
        //    Assert.AreEqual(3, result.Content.BookID);
        //}

        //[TestMethod]
        //public void Delete_ReturnsOk()
        //{
        //    // Arrange
        //    var mockRepository = new Mock<ICartRepository>();

        //    mockRepository.Setup(x => x.DeleteItemFromCart(new CartItem() { BookID = 3, UserID = 1 })).Returns(true);

        //    var controller = new CartController(mockRepository.Object);
            
        //    // Act
        //    IHttpActionResult actionResult = controller.Delete(1, 3);

        //    // Assert
        //    Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        //}
    }
}
