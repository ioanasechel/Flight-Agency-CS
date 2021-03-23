using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace Flight_Agency.repository
{
    public static class DBUtils
    {
        private static IDbConnection instance = null;

        public static IDbConnection getConnection()
        {
            if (instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                instance = getNewConnection();
                instance.Open();
            }
            return instance;
        }

        private static IDbConnection getNewConnection()
        {	
            //return ConnectionUtils.ConnectionFactory.getInstance().createConnection();
            String url = ConfigurationManager.ConnectionStrings["flightagency"].ConnectionString;
            SqliteConnection con = null;
            try
            {
                con = new SqliteConnection(url);
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.ToString());
            }

            return con;
        }
    }
}