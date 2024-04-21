using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBuddies.Repositories
{
    internal class SessionProjectRepository : DBRepositoryBase
    {
        public SessionProjectRepository() : base()
        {

        }

        public string GetTextFromId(int id)
        {
            string text = null;

            string query = "SELECT text FROM Files WHERE id = @Id";

            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@Id", id);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    text = result.ToString();
                }
            }

            return text;
        }

        public void Save(int id, string text)
        {
            if (id == 0)
            {
                id = GetFreeFilesId();
            }

            string saveQuery = @"
                INSERT INTO Files (id, text)
                VALUES (@Id, @Text)";

            using (SqlCommand saveCommand = new SqlCommand(saveQuery, sqlConnection))
            {
                saveCommand.Parameters.AddWithValue("@Id", id);
                saveCommand.Parameters.AddWithValue("@Text", text);

                saveCommand.ExecuteNonQuery();
            }
        }

        public int GetFreeFilesId()
        {
            int maxId = 0;
            string maxIdQuery = "SELECT MAX(id) FROM Files";

            using (SqlCommand command = new SqlCommand(maxIdQuery, sqlConnection))
            {
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    maxId = Convert.ToInt32(result);
                }
            }


            // Increment the maximum ID to get a free ID
            return maxId + 1;
        }

        public List<FileType> GetAllFiles()
        {
            List<FileType> files = new List<FileType>();

            DataSet fileDataSet = new DataSet();
            string selectAll = "SELECT * FROM Files";
            SqlCommand selectAllNotifications = new SqlCommand(selectAll, sqlConnection);
            dataAdapter.SelectCommand = selectAllNotifications;
            fileDataSet.Clear();
            dataAdapter.Fill(fileDataSet, "Files");

            foreach (DataRow fileRow in fileDataSet.Tables["Files"].Rows)
            {

                FileType currentFile;

                currentFile = new FileType(Convert.ToInt32(fileRow["id"]), fileRow["text"].ToString());
          
                files.Add(currentFile);

            }

            return files;
        }
    }
}