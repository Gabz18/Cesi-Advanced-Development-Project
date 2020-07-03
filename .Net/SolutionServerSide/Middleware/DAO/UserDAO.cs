using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Middleware.Model;

namespace Middleware.DAO
{
    class UserDAO : IUserDAO
    {
        private const string findByUserNameQuery = "Select * from dbo.Users where username like @USERNAME;";
        public User FindByUserName(string username)
        {
            using (SqlConnection connexion = SqlConnectionHolder.Instance.Cnn) 
            {
                SqlCommand query = new SqlCommand(findByUserNameQuery, connexion);
                query.Parameters.AddWithValue("@USERNAME", username);

                
                connexion.Open();
                SqlDataReader dataReader = query.ExecuteReader();

                User myUser = null;

                if (dataReader.Read())
                {
                    myUser = new User();
                    myUser.UserID = dataReader.GetInt32(0);
                    myUser.Username = dataReader.GetString(1);
                    myUser.Password = dataReader.GetString(2);
                    myUser.SaltPassword = dataReader.GetString(3);

                }
                connexion.Close();

                return myUser;
            }
        }
    }
}
