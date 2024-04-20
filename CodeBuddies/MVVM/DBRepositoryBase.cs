using CodeBuddies.Resources.Data;
using System.Data;
using System.Data.SqlClient;

namespace CodeBuddies.MVVM
{
    internal abstract class DBRepositoryBase
    {
        protected SqlConnection sqlConnection = new SqlConnection(Constants.CONNECTION_STRING);

        protected SqlDataAdapter dataAdapter;

        protected DBRepositoryBase() { 
            
            OpenConnection();
            dataAdapter = new SqlDataAdapter();
        
        }

        public void OpenConnection()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

    }
}
