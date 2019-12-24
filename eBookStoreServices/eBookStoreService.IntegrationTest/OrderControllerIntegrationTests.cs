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
    public class OrderControllerIntegrationTests : IntegrationTests
    {
        [TestMethod]
        public void GetOrderIntegrationTest_ShouldReturnOK()
        {
            string token = GetToken();
            var client = new RestClient(ServiceBaseURL + "api/order");
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Bearer " + token);
            request.AddHeader("cache-control", "no-cache");
            var response = client.Execute(request);

            var responseResult = JsonConvert.DeserializeObject<IEnumerable<OrderHistroy>>(response.Content);
            Assert.IsTrue(responseResult.Count() > 0);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);                       
        }

        [TestMethod]
        public void PostOrderIntegrationTest_ShouldReturnOK()
        {
            string token = GetToken();
            var client = new RestClient(ServiceBaseURL + "api/order");
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", "Bearer " + token);
            request.AddHeader("cache-control", "no-cache");
            request.AddJsonBody(JsonConvert.SerializeObject(DataInitializer.GetCartItems().ToList()));
            var response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }
    }
}
