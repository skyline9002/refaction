using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RefactionMe.Data.Infrastructure
{
    public static class DbHelpers
    {
        private const string _dbConectionStringPattern = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DataDirectory}\Database.mdf;Integrated Security=True";
        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    //only need to generate connection string once.
                    _connectionString = _dbConectionStringPattern.Replace("{DataDirectory}", HttpContext.Current.Server.MapPath("~/App_Data"));
                }

                return _connectionString;
            }
        }
        
    }
}
