using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anuitex.Library.Data;
using Anuitex.Library.Data.Entities;
using Anuitex.Library.Models.Repositories;

namespace Anuitex.Library.Models.Repositories
{
    public class JournalRepository
    {
        public List<Journal> GetList()
        {
            DataContext.Context.SqlConnection.Open();
            string sql = "select * from Journal";

            DataTable journalsTable = new DataTable("Journals");

            using (SqlCommand cmd = new SqlCommand(sql, DataContext.Context.SqlConnection))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                journalsTable.Load(reader);
                reader.Close();
            }

            List<Journal> result = (from DataRow journalsTableRow in journalsTable.Rows
                select new Journal()
                {
                    Id = (int)journalsTableRow["Id"],
                    Title = (string)journalsTableRow["Title"],
                    Periodicity = (string)journalsTableRow["Periodicity"],
                    Subjects = (string)journalsTableRow["Subjects"],
                    Date = (string)journalsTableRow["Date"],                    
                    Amount = (int)journalsTableRow["Amount"],
                    Price = (double)journalsTableRow["Price"]
                }).ToList();

            DataContext.Context.SqlConnection.Close();
            return result;
        }

        public void Add(Journal item)
        {
            DataContext.Context.SqlConnection.Open();
            string sql = string.Format("insert into Journal "
                                       + "(Title, Periodicity, Subjects, Date, Amount, Price) values(@Title, @Periodicity, @Subjects, @Date, @Amount, @Price)");
            using (SqlCommand cmd = new SqlCommand(sql, DataContext.Context.SqlConnection))
            {
                cmd.Parameters.AddWithValue("@Title", item.Title);
                cmd.Parameters.AddWithValue("@Periodicity", item.Periodicity);
                cmd.Parameters.AddWithValue("@Subjects", item.Subjects);
                cmd.Parameters.AddWithValue("@Date", item.Date);                
                cmd.Parameters.AddWithValue("@Amount", item.Amount);
                cmd.Parameters.AddWithValue("@Price", item.Price);

                cmd.ExecuteNonQuery();
            }

            DataContext.Context.SqlConnection.Close();
        }

        public void Update(Journal newItem)
        {
            DataContext.Context.SqlConnection.Open();
            string sql =
                $"update Journal set Title = N'{newItem.Title}', Periodicity = N'{newItem.Periodicity}', Subjects = N'{newItem.Subjects}', Date = N'{newItem.Date}', Amount = '{newItem.Amount}', Price = '{newItem.Price}' where Id = '{newItem.Id}'";
            using (SqlCommand cmd = new SqlCommand(sql, DataContext.Context.SqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
            DataContext.Context.SqlConnection.Close();
        }

        public void Delete(Journal journal)
        {
            DataContext.Context.SqlConnection.Open();
            string sql = $"delete from Journal where Id = '{journal.Id}'";

            using (SqlCommand cmd = new SqlCommand(sql, DataContext.Context.SqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
            DataContext.Context.SqlConnection.Close();
        }
    }
}
