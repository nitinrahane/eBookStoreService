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
    public class CartRepository : ICartRepository
    {
        private string connectionString = SiteConfigs.GetDBConnectionString();
        public bool AddItemToCart(CartItem cartItem)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string sql = @"
                                      IF EXISTS(SELECT * 
                                                FROM   dbo.cart c 
                                                WHERE  c.userid = @userId 
                                                       AND c.bookid = @bookID) 
                                        BEGIN 
                                            UPDATE dbo.cart 
                                            SET    quantity = ( quantity + 1 ) 
                                            WHERE  userid = @userId 
                                                   AND bookid = @bookID 
                                        END 
                                      ELSE 
                                        BEGIN 
                                            INSERT INTO dbo.cart 
                                                        (                                             
                                                            userid, 
                                                            bookid, 
                                                            quantity, 
                                                            addeddate, 
                                                            cartstaus
                                                        ) 
                                            VALUES      ( 
                                                            @userId,
                                                            @bookID,
                                                            1,
                                                            @addedDate,
                                                            @cartStaus
                                                            
                                            ) 
                                        END                                        
                                  ";
                    db.Execute(sql, param: new
                    {
                        userId = cartItem.UserID,
                        bookID = cartItem.BookID,
                        addedDate = DateTime.Now,
                        cartStaus = nameof(CartStaus.AddedToCart)
                    });
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteItemFromCart(CartItem cartItem)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string sql = @"
                                    DELETE FROM dbo.cart 
                                    WHERE  userid = @userID 
                                           AND bookid = @bookID 
                                ";
                    db.Execute(sql, param: new { userID = cartItem.UserID, bookID = cartItem.BookID });
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CartItemDetails> GetCartItems(string userID)
        {
            try
            {
                List<CartItemDetails> books = new List<CartItemDetails>();
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string sql = @"                                  
                                    SELECT b.*, 
                                           c.quantity, 
                                           c.addeddate 
                                    FROM   books b 
                                           INNER JOIN cart c 
                                                   ON b.id = c.bookid 
                                    WHERE  c.userid = @userId 
                                           AND c.cartstaus = 'addedtocart'
                                           AND c.quantity > 0
                                ";
                    books = db.Query<CartItemDetails>(sql, param: new { userId = userID }).ToList();
                }
                return books;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateItemQuantity(CartItem cartItem)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string sql = @"
                                            UPDATE dbo.cart 
                                            SET    quantity = @quantity 
                                            WHERE  userid = @userId 
                                                   AND bookid = @bookID 
                                  ";
                    db.Execute(sql, param: new
                    {
                        userId = cartItem.UserID,
                        bookID = cartItem.BookID,
                        quantity = cartItem.Quantity

                    });
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
