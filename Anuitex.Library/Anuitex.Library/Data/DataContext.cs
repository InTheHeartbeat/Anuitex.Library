using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anuitex.Library.Data
{
    public class DataContext
    {

        public static DataContext Context => GetInstance();
        private static DataContext instance;

        private static readonly string DbFilePath = Application.StartupPath + "\\Data\\LibraryDatabase.mdf";
        private static readonly string connectionString =
                "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + DbFilePath + ";Integrated Security=True;Connect Timeout=30;Current Language=Russian"
            ;        

        public readonly SqlConnection SqlConnection = new SqlConnection(connectionString);

        private static DataContext GetInstance()
        {
            if (instance == null)
            {
                instance = new DataContext();
            }

            return instance;
        }
    }
}
