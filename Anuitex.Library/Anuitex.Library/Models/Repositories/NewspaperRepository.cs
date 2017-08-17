using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex.Library.Data;
using Anuitex.Library.Data.Entities;

namespace Anuitex.Library.Models.Repositories
{
    public class NewspaperRepository
    {
        public List<Newspaper> GetList()
        {
            DataContext.Context.SqlConnection.Open();
            string sql = "select * from Newspaper";

            DataTable newspapersTable = new DataTable("Newspapers");

            using (SqlCommand cmd = new SqlCommand(sql, DataContext.Context.SqlConnection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                newspapersTable.Load(reader);
                reader.Close();
            }

            List<Newspaper> result = (from DataRow newspapersTableRow in newspapersTable.Rows
                select new Newspaper()
                {
                    Id = (int)newspapersTableRow["Id"],
                    Title = (string)newspapersTableRow["Title"],
                    Periodicity = (string)newspapersTableRow["Periodicity"],                    
                    Date = (string)newspapersTableRow["Date"],
                    Amount = (int)newspapersTableRow["Amount"],
                    Price = (double)newspapersTableRow["Price"]
                }).ToList();

            DataContext.Context.SqlConnection.Close();
            return result;
        }

        public void Add(Newspaper item)
        {
            DataContext.Context.SqlConnection.Open();
            string sql = string.Format("insert into Newspaper "
                                       + "(Title, Periodicity, Date, Amount, Price) values(@Title, @Periodicity, @Date, @Amount, @Price)");
            using (SqlCommand cmd = new SqlCommand(sql, DataContext.Context.SqlConnection))
            {
                cmd.Parameters.AddWithValue("@Title", item.Title);
                cmd.Parameters.AddWithValue("@Periodicity", item.Periodicity);                
                cmd.Parameters.AddWithValue("@Date", item.Date);
                cmd.Parameters.AddWithValue("@Amount", item.Amount);
                cmd.Parameters.AddWithValue("@Price", item.Price);

                cmd.ExecuteNonQuery();
            }

            DataContext.Context.SqlConnection.Close();
        }

        public void Update(Newspaper newItem)
        {
            DataContext.Context.SqlConnection.Open();
            string sql =
                $"update Newspaper set Title = N'{newItem.Title}', Periodicity = N'{newItem.Periodicity}', Date = N'{newItem.Date}', Amount = '{newItem.Amount}', Price = '{newItem.Price}' where Id = '{newItem.Id}'";
            using (SqlCommand cmd = new SqlCommand(sql, DataContext.Context.SqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
            DataContext.Context.SqlConnection.Close();
        }

        public void Delete(Newspaper newspaper)
        {
            DataContext.Context.SqlConnection.Open();
            string sql = $"delete from Newspaper where Id = '{newspaper.Id}'";

            using (SqlCommand cmd = new SqlCommand(sql, DataContext.Context.SqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
            DataContext.Context.SqlConnection.Close();
        }

        public void Add(List<Newspaper> newspapers)
        {
            newspapers.ForEach(Add);
        }
    }
}
