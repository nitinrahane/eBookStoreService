using eBookStoreServices.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStoreServices.TestHelpers.Helpers
{
    public static class DataInitializer
    {
        public static List<Book> GetBooks()
        {
            List<Book> listOfSampleBooks = new List<Book>();

            listOfSampleBooks.Add(new Book()
            {
                ID = 1,
                Title = "Test 1",
                Author = "Test 1",
                Description = "Testing",
                Price = 200,
                PublishedYear = 2020,
                Publisher = "Test 1"
            });
            listOfSampleBooks.Add(new Book()
            {
                ID = 1,
                Title = "Test 2",
                Author = "Test 2",
                Description = "Testing 2",
                Price = 200,
                PublishedYear = 2021,
                Publisher = "Test 2"
            });

            listOfSampleBooks.Add(new Book()
            {
                ID = 1,
                Title = "Test 3",
                Author = "Test 3",
                Description = "Testing 3",
                Price = 200,
                PublishedYear = 2023,
                Publisher = "Test 3"
            });

            return listOfSampleBooks;

        }

        public static List<OrderHistroy> GetOrderHistory()
        {
            List<OrderHistroy> orderHistroy = new List<OrderHistroy>();

            orderHistroy.Add(new OrderHistroy()
            {
                ID = 1,
                OrderStatus = OrderStatus.Completed,
                TotalPrice = 2,
                PurchaseDate = DateTime.Now,
                UserID = "8ba72045-43b9-441b-868d-f7373bf02859",
                Order_Items = new List<Order_Item>()
                {
                    new Order_Item() {
                                        BookID = 1,
                                        ID = 1,
                                        OrderNumber = 1,
                                        Quantity = 2
                                     },
                     new Order_Item() {
                                         BookID = 2,
                                         ID = 2,
                                         OrderNumber = 1,
                                         Quantity = 1
                                       }
                },
                bookDetailsForOrder = new List<Book>()
                {
                    new Book(){
                                    ID = 1,
                                    Title = "Test 1",
                                    Author = "Test 1",
                                    Description = "Testing",
                                    Price = 200,
                                    PublishedYear = 2020,
                                    Publisher = "Test 1"
                               },
                    new Book(){
                                    ID = 1,
                                    Title = "Test 2",
                                    Author = "Test 2",
                                    Description = "Testing 2",
                                    Price = 200,
                                    PublishedYear = 2021,
                                    Publisher = "Test 2"
                               }
                }
            });
            return orderHistroy;
        }

        public static List<CartItemDetails> GetCartItems()
        {
            List<CartItemDetails> cartDetails = new List<CartItemDetails>();
            cartDetails.Add(new CartItemDetails()
            {
                ID = 1,
                Title = "Test 2",
                Author = "Test 2",
                Description = "Testing 2",
                Price = 200,
                PublishedYear = 2021,
                Publisher = "Test 2",
                AddedDate = DateTime.Now,
                Quantity = 1
            });

            cartDetails.Add(new CartItemDetails()
            {
                ID = 3,
                Title = "Test 1",
                Author = "Test 1",
                Description = "Testing 1",
                Price = 200,
                PublishedYear = 2021,
                Publisher = "Test 1",
                AddedDate = DateTime.Now,
                Quantity = 1
            });

            return cartDetails;
        }


        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User()
            {
                Email= "nitin.rahane11@gmail.com",
                FullName = "Nitin Rahane",
                Password = "Test123!",
                ID = "8ba72045-43b9-441b-868d-f7373bf02859"
            });

            users.Add(new User()
            {
                Email = "test1@test.com",
                FullName = "Test",
                Password = "Test_123",
                ID = "bbac61ad-408f-4fce-9f63-2191a8c27a47"
            });
            return users;

        }
    }
}
