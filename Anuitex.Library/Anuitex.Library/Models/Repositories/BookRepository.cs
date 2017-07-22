using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anuitex.Library.Data;
using Anuitex.Library.Data.Entities;
using DataContext = Anuitex.Library.Data.DataContext;

namespace Anuitex.Library.Models.Repositories
{
    public class BookRepository
    {      
        public List<Book> GetList()
        {
            DataContext.Context.SqlConnection.Open();
            string sql = "select * from Book";

            DataTable booksTable = new DataTable("Books");

            using (SqlCommand cmd = new SqlCommand(sql, DataContext.Context.SqlConnection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                booksTable.Load(reader);
                reader.Close();
            }

            List<Book> result = (from DataRow booksTableRow in booksTable.Rows
                select new Book()
                {
                    Id = (int) booksTableRow["Id"],
                    Title = (string) booksTableRow["Title"],
                    Year = (int) booksTableRow["Year"],
                    Pages = (int) booksTableRow["Pages"],
                    Author = (string) booksTableRow["Author"],
                    Genre = (string) booksTableRow["Genre"],
                    Amount = (int) booksTableRow["Amount"],
                    Price = (double) booksTableRow["Price"]
                }).ToList();
            DataContext.Context.SqlConnection.Close();
            return result;
        }  

        public void Add(Book item)
        {
            DataContext.Context.SqlConnection.Open();
            string sql = string.Format("insert into Book "
                + "(Title, Year, Pages, Author, Genre, Amount, Price) values(@Title, @Year, @Pages, @Author, @Genre, @Amount, @Price)");
            using (SqlCommand cmd = new SqlCommand(sql, DataContext.Context.SqlConnection))
            {
                cmd.Parameters.AddWithValue("@Title", item.Title);
                cmd.Parameters.AddWithValue("@Year", item.Year);
                cmd.Parameters.AddWithValue("@Pages", item.Pages);
                cmd.Parameters.AddWithValue("@Author", item.Author);
                cmd.Parameters.AddWithValue("@Genre", item.Genre);
                cmd.Parameters.AddWithValue("@Amount", item.Amount);
                cmd.Parameters.AddWithValue("@Price", item.Price);

                cmd.ExecuteNonQuery();
            }
            
            DataContext.Context.SqlConnection.Close();
        }

        public void Update(Book newItem)
        {
            DataContext.Context.SqlConnection.Open();
            string sql =
                $"update Book set Title = '{newItem.Title}', Year = '{newItem.Year}', Pages = '{newItem.Pages}', Author = '{newItem.Author}', Genre = '{newItem.Genre}', Amount = '{newItem.Amount}', Price = '{newItem.Price}' where Id = '{newItem.Id}'";
            using (SqlCommand cmd = new SqlCommand(sql, DataContext.Context.SqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
            DataContext.Context.SqlConnection.Close();
        }

        public void Delete(Book book)
        {
            DataContext.Context.SqlConnection.Open();
            string sql = $"delete from Book where Id = '{book.Id}'";

            using (SqlCommand cmd = new SqlCommand(sql, DataContext.Context.SqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
            DataContext.Context.SqlConnection.Close();
        }
    }
}
