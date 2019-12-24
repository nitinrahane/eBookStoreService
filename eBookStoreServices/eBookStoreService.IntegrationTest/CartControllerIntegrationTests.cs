using eBookStoreServices.Entities.Models;
using eBookStoreServices.TestHelpers.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eBookStoreService.IntegrationTest
{
    [TestClass]
    public class CartControllerIntegrationTests : IntegrationTests
    {

        [TestMethod]
        public void GetCartItemsIntegrationTest_ShouldReturnCartItemsIfPresent()
        {
            string token = GetToken();
            var client = new RestClient(ServiceBaseURL + "api/cart");
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Bearer " + token);
            request.AddHeader("cache-control", "no-cache");
            var response = client.Execute(request);

            var responseResult = JsonConvert.DeserializeObject<List<CartItemDetails>>(response.Content);           
            Assert.IsTrue(responseResult.Count > 0, "Cart Items present");
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        
        [TestMethod]
        public void PostCartItemIntegrationTest_ShouldReturnOK()
        {
            string token = GetToken();
            var client = new RestClient(ServiceBaseURL + "api/cart");
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", "Bearer " + token);
            request.AddHeader("cache-control", "no-cache");
            request.AddJsonBody(JsonConvert.SerializeObject(new CartItem() { BookID = 1}));
            var response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void DeleteCartItemIntegrationTest_ShouldReturnOK()
        {
            string token = GetToken();
            var client = new RestClient(ServiceBaseURL + "api/cart/1");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("authorization", "Bearer " + token);
            request.AddHeader("cache-control", "no-cache");
            var response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }
    }
}
