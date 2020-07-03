using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.DAO
{
    public class SqlConnectionHolder
    {
        private static SqlConnectionHolder instance = null;
        private const string connectionString = "Data Source = DESKTOP-LGSVM1P; Initial Catalog = middleware_c_projet; User ID = middleware_app; Password=mid123";

        private SqlConnectionHolder() 
        {
        }

        public static SqlConnectionHolder Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SqlConnectionHolder();
                }
                return instance;
            }
        } 

        public SqlConnection Cnn { get => new SqlConnection(connectionString); }
    }
}
