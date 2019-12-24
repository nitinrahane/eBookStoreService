using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using eBookStoreServices.Entities.Models;
using Newtonsoft.Json;

namespace eBookStoreService.IntegrationTest
{
    public class IntegrationTests
    {
        public const string ServiceBaseURL = "https://localhost:44371/";

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
    }
}
