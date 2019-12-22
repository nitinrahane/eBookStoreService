using eBookStoreServices.Entities.Models;
using eBookStoreServices.TestHelpers.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;


namespace eBookStoreService.IntegrationTest
{
    [TestClass]
    public class BookControllerIntegrationTests
    {
        private const string ServiceBaseURL = "https://localhost:44371/";

        public string GetToken()
        {
            var client = new RestClient(ServiceBaseURL + "token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=password&username=nitin.rahane11@gmail.com&password=Test123!", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            var result = JsonConvert.DeserializeObject<TokenDetails>(response.Content);
            String token = result.access_token;
            return token;
        }


        [TestMethod]
        public void GetAllBooksIntegrationTest_ShouldReturnTheOK()
        {
            string token = GetToken();
            var client = new RestClient(ServiceBaseURL + "api/books");
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Bearer " + token);
            request.AddHeader("cache-control", "no-cache");
            var response = client.Execute(request);

            var responseResult = JsonConvert.DeserializeObject<List<Book>>(response.Content);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(responseResult.Any(), true);
            Assert.IsTrue(responseResult.Count > 0);
        }

        [TestMethod]
        public void GetBookIntegrationTest_ShouldReturnOK()
        {
            string token = GetToken();
            var client = new RestClient(ServiceBaseURL + "api/books/1");
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "Bearer " + token);
            request.AddHeader("cache-control", "no-cache");
            var response = client.Execute(request);            
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);          
        }

        [TestMethod]
        public void PostBookIntegrationTest_ShouldReturnOK()
        {
            string token = GetToken();
            var client = new RestClient(ServiceBaseURL + "api/books");
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", "Bearer " + token);
            request.AddHeader("cache-control", "no-cache");
            request.AddJsonBody(JsonConvert.SerializeObject(DataInitializer.GetBooks().First()));
            var response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void PutBookIntegrationTest_ShouldReturnOK()
        {
            string token = GetToken();
            var client = new RestClient(ServiceBaseURL + "api/books");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("authorization", "Bearer " + token);
            request.AddHeader("cache-control", "no-cache");
            request.AddJsonBody(JsonConvert.SerializeObject(DataInitializer.GetBooks().First()));
            var response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        //[TestMethod]
        //public void DeleteBookIntegrationTest_ShouldReturnOK()
        //{
        //    string token = GetToken();
        //    var client = new RestClient(ServiceBaseURL + "api/books/1");
        //    var request = new RestRequest(Method.DELETE);
        //    request.AddHeader("authorization", "Bearer " + token);
        //    request.AddHeader("cache-control", "no-cache");          
        //    var response = client.Execute(request);
        //    Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        //}

    }
}
