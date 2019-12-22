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
    public class TestOrderController
    {
        [TestMethod]
        public void GetOrders_ShouldReturnOrders()
        {
            //Arrange
            var mockOrderService = new Mock<IOrderService>();
            var mockCartService = new Mock<ICartService>();
            mockOrderService.Setup(x => x.GetAllOrdersForUser(It.IsAny<string>())).Returns(DataInitializer.GetOrderHistory());
                       
            var orderController = new OrderController(mockOrderService.Object, mockCartService.Object);
            //Act
            var result = orderController.Get();
            //Assert
            Assert.IsTrue(result.Count() > 0, "Order Tested.");

        }

        [TestMethod]
        public void PostOrders_ShouldReturnOK()
        {
            //Arrange
            var mockOrderService = new Mock<IOrderService>();
            var mockCartService = new Mock<ICartService>();
            mockOrderService.Setup(x => x.AddOrderDetails(It.IsAny<Order>())).Returns(true);

            var orderController = new OrderController(mockOrderService.Object, mockCartService.Object);
            //Act
            var result = orderController.Post(DataInitializer.GetCartItems());
            //Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));

        }
    }
}
