using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Contact_TracingApp1
{
    internal class ConnectionDB
    {
        //decalre the sql connection (after importing using System.Data and System.Data.SqlClient)
        public static SqlConnection conn;
        //set the connection string
        private static string dbconnect = "  "; //Connection String

        public static void DB()
        {// used try-catch to see the error clearly
            try
            {
                //Assign the declared variables
                conn = new SqlConnection(dbconnect);
                conn.Open();

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }
        public string GetConnection()
        {
            string conn = "";//Connection String
            return conn;
        }
       
    }
}
