using eBookStoreServices.Data.Interfaces;
using eBookStoreServices.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;

namespace eBookStoreServices.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["eBookStore"].ConnectionString;

        public bool AddNewBook(Book bookDetails)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string sql = @"
                                        INSERT INTO dbo.Books
                                        (                                            
                                            Title,
                                            Author,
                                            [Description],
                                            Publisher,
                                            PublishedYear,
                                            Price
                                        )
                                        VALUES
                                        (                                          
                                            @title,
                                            @author, 
                                            @description, 
                                            @publisher, 
                                            @publishedYear, 
                                            @price
                                        )
                                  ";
                    db.Execute(sql, param: new
                    {                       
                        title = bookDetails.Title,
                        author = bookDetails.Author,
                        description = bookDetails.Description,
                        publisher = bookDetails.PublishedYear,
                        publishedYear = bookDetails.PublishedYear,
                        price = bookDetails.Price
                    });
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteBook(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string sql = @"DELETE FROM dbo.books 
                                   WHERE  dbo.books.id = @id ";
                    int count = db.Execute(sql, param: new { id = id });
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Book> GetAllBooks()
        {
            try
            {
                List<Book> books = new List<Book>();
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string sql = @"
                                  SELECT * 
                                  FROM books";
                    books = db.Query<Book>(sql).ToList();
                }
                return books;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Book GetBook(int id)
        {
            try
            {
                Book book = new Book();
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string sql = @"
                                    SELECT * 
                                    FROM books 
                                        WHERE 
                                             ID = @id
                                  ";
                    book = db.Query<Book>(sql, param: new { id = id }).FirstOrDefault();
                }
                return book;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdateBookDetails(Book bookDetails)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    string sql = @"
                                        UPDATE dbo.Books
                                        SET                                            
                                            dbo.Books.Title = @title, 
                                            dbo.Books.Author = @author,
                                            dbo.Books.Description = @description,
                                            dbo.Books.Publisher = @publisher,
                                            dbo.Books.PublishedYear = @publishedYear,
                                            dbo.Books.Price = @price
                                        WHERE dbo.Books.ID = @id
                                  ";
                    int count = db.Execute(sql, param: new
                    {
                        id = bookDetails.ID,
                        title = bookDetails.Title,
                        author = bookDetails.Author,
                        description = bookDetails.Description,
                        publisher = bookDetails.PublishedYear,
                        publishedYear = bookDetails.PublishedYear,
                        price = bookDetails.Price
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
