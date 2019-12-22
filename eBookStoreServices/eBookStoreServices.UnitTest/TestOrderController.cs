using eBookStoreServices.Controllers;
using eBookStoreServices.Data.Interfaces;
using eBookStoreServices.Data.Repositories;
using eBookStoreServices.Services.Services;
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
        { //Arrange

            var orderController = new OrderController(new OrderService(new OrderRepository()), new CartService(new CartRepository()));
            //Act
            var result = orderController.Get();
            //Assert
            Assert.IsTrue(result.Count() > 0, "books are presents");

        }
    }
}
