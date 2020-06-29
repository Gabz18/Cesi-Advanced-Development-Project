using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware
{
    class Authentifier
    {
        //à modifier pour mettre la chaine de connexion de ta BDD
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
        SqlConnection cnn;

        public bool toLogin(string username, string password)
        {
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader dataReader;
            string sql = "Select * from users"; //ta requête sql

            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            bool authentified = false;
            while (dataReader.Read())
            {
                if (dataReader.GetValue(1).ToString() == username)
                {
                    if (dataReader.GetValue(2).ToString() == password)
                    {
                        authentified = true;
                    }
                }
            }
            if (authentified == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
