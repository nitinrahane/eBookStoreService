using eBookStoreServices.Controllers;
using eBookStoreServices.Data.Interfaces;
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
            var mockRepositoryClass = new Mock<ICartRepository>();

            mockRepositoryClass.Setup(x => x.GetCartItems(1)).Returns(new List<Entities.Models.CartItemDetails>() {
                new Entities.Models.CartItemDetails() { ID = 1 }
            });

            var cartController = new CartController(mockRepositoryClass.Object);

            //Act
            var result = cartController.Get(1).First();

            //Assert
            Assert.AreEqual(1, result.ID);
        }
    }
}
