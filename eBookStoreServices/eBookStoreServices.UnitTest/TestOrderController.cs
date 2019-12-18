using eBookStoreServices.Controllers;
using eBookStoreServices.Data.Interfaces;
using eBookStoreServices.Data.Repositories;
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
        public void GetOrders_SouldReturnOrders()
        { //Arrange

            var orderController = new OrderController(new OrderRepository(), new CartRepository());
            //Act
            var result = orderController.Get(1);
            //Assert
            Assert.IsTrue(result.Count() > 0, "The books are presents");

        }
    }
}
