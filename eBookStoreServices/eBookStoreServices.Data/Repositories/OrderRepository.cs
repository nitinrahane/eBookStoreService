using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eBookStoreServices.Data.Interfaces;
using eBookStoreServices.Entities.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using eBookStoreServices.Config;

namespace eBookStoreServices.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private string connectionString = SiteConfigs.GetDBConnectionString();

        public List<OrderHistroy> GetAllOrdersForUser(string userId)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string sql = @"
                                    SELECT * FROM dbo.Orders o
                                    WHERE o.UserID = @userID   
                                  ";
                    var ordersHistory = db.Query<OrderHistroy>(sql, param: new {userID = userId}).ToList();

                    if (ordersHistory.Count > 0)
                    {
                        foreach (var item in ordersHistory)
                        {
                            string sql1 = @"
                                      SELECT * FROM order_items o 
                                        WHERE o.OrderNumber  = @orderNum
                                  ";
                            item.Order_Items = db.Query<Order_Item>(sql1, param: new { orderNum  = item .ID}).ToList();

                            string sql2 = @"
                                            SELECT b.* FROM Books b 
                                            INNER JOIN 
                                            dbo.Order_Items oi
                                            ON b.ID = oi.BookID
                                            AND oi.OrderNumber = @orderNum
                                  ";
                            item.bookDetailsForOrder = db.Query<Book>(sql2, param: new { orderNum = item.ID }).ToList();
                        }
                    }
                    return ordersHistory;
                }                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddOrderDetails(Order orderDetails)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string sql = @"
                                        INSERT INTO dbo.Orders
                                        (                                            
                                            UserID,
                                            PurchaseDate,
                                            TotalPrice,
                                            OrderStatus
                                        )
                                        VALUES
                                        (                                           
                                            @userID, 
                                            @addedTime,
                                            @totalPrice,
                                            @orderStatus
                                        );                                    
                                        
                                        SELECT CAST(SCOPE_IDENTITY() as int)
                                  ";
                    int orderNo = db.Query<int>(sql, param: new
                    {
                        userID = orderDetails.UserID,
                        addedTime = DateTime.Now,
                        totalPrice = orderDetails.TotalPrice,
                        orderStatus = nameof(OrderStatus.Completed)
                    }).Single();

                    if (orderNo > 0)
                    {
                        foreach (var item in orderDetails.Order_Items)
                        {
                            string sql1 = @"
                                        INSERT INTO dbo.Order_Items
                                            (                                               
                                                OrderNumber,
                                                BookID,
                                                Quantity
                                            )
                                            VALUES
                                            (                                                
                                                @orderNum,
                                                @bookID,
                                                @Quantity
                                            )
                                  ";
                            db.Execute(sql1, param: new
                            {
                                orderNum = orderNo,
                                bookID = item.BookID,
                                Quantity = item.Quantity
                            });
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
