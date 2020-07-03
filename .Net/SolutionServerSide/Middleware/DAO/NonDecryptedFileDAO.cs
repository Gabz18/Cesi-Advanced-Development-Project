using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Middleware.Model;

namespace Middleware.DAO
{
    public class NonDecryptedFileDAO
    {
        private const string insertNonDecryptedFileQuery = "INSERT INTO dbo.NonDecryptedFiles(name, client, encryptedText) VALUES (@NAME, @CLIENT, @ENCRYPTED_TEXT);";
        private const string findByClient = "Select * from dbo.NonDecryptedFiles where client like @CLIENT;";
        
        public bool InsertDecryptedFile(NonDecryptedFile file)
        {
            using (SqlConnection connexion = SqlConnectionHolder.Instance.Cnn)
            {
                SqlCommand query = new SqlCommand(insertNonDecryptedFileQuery, connexion);
                query.Parameters.AddWithValue("@NAME", file.Name);
                query.Parameters.AddWithValue("@CLIENT", file.Client);
                query.Parameters.AddWithValue("@ENCRYPTED_TEXT", file.EncryptedText);

                connexion.Open();

                int result = query.ExecuteNonQuery();

                connexion.Close();

                return result > 0;
            }
        }

        public List<NonDecryptedFile> FindByClient(string client)
        {
            using (SqlConnection connexion = SqlConnectionHolder.Instance.Cnn)
            {
                SqlCommand query = new SqlCommand(findByClient, connexion);
                query.Parameters.AddWithValue("@CLIENT", client);

                connexion.Open();

                SqlDataReader dataReader = query.ExecuteReader();

                List<NonDecryptedFile> nonDecryptedFiles = new List<NonDecryptedFile>();

                while (dataReader.Read())
                {
                    NonDecryptedFile nonDecryptedFile = new NonDecryptedFile();

                    nonDecryptedFile.ID = dataReader.GetInt32(0);
                    nonDecryptedFile.Name = dataReader.GetString(1);
                    nonDecryptedFile.Client = dataReader.GetString(2);
                    nonDecryptedFile.EncryptedText = dataReader.GetString(3);

                    nonDecryptedFiles.Add(nonDecryptedFile);
                }
                connexion.Close();

                return nonDecryptedFiles;
            }
        }
    }
}
