using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Middleware.Model;

namespace Middleware.DAO
{
    class DecryptedFileDAO : IDecryptedFileDAO
    {
        private const string insertNewDecrypotedFileQuery = "INSERT INTO dbo.DecryptedFiles(name, client, code, plainText, secretInformation) VALUES (@NAME, @CLIENT, @CODE, @PLAIN_TEXT, @SECRET_INFO);";
        private const string findByClientQuery = "Select * from dbo.DecryptedFiles where client like @CLIENT;";

        public bool InsertDecryptedFile(DecryptedFile file)
        {
            using (SqlConnection connexion = SqlConnectionHolder.Instance.Cnn)
            {
                SqlCommand query = new SqlCommand(insertNewDecrypotedFileQuery, connexion);
                query.Parameters.AddWithValue("@NAME", file.Name);
                query.Parameters.AddWithValue("@CLIENT", file.Client);
                query.Parameters.AddWithValue("@CODE", file.Code);
                query.Parameters.AddWithValue("@PLAIN_TEXT", file.Plaintext);
                query.Parameters.AddWithValue("@SECRET_INFO", file.SecretInformation);

                connexion.Open();

                int result = query.ExecuteNonQuery();

                connexion.Close();

                return result > 0;
            }
        }

        public List<DecryptedFile> FindByClient(string client)
        {
            using (SqlConnection connexion = SqlConnectionHolder.Instance.Cnn)
            {
                SqlCommand query = new SqlCommand(findByClientQuery, connexion);
                query.Parameters.AddWithValue("@CLIENT", client);


                connexion.Open();
                SqlDataReader dataReader = query.ExecuteReader();

                List<DecryptedFile> decryptedFiles = new List<DecryptedFile>();

                while (dataReader.Read())
                {
                    DecryptedFile decryptedFile = new DecryptedFile();

                    decryptedFile.ID = dataReader.GetInt32(0);
                    decryptedFile.Name = dataReader.GetString(1);
                    decryptedFile.Client = dataReader.GetString(2);
                    decryptedFile.Code = dataReader.GetString(3);
                    decryptedFile.Plaintext = dataReader.GetString(4);
                    decryptedFile.SecretInformation = dataReader.GetString(5);

                    decryptedFiles.Add(decryptedFile);
                }
                connexion.Close();

                return decryptedFiles;
            }
        }
    }
}
