using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Contact_TracingApp1.Functions
{
    internal class Functions
    {
        public static string gen = " ";//variable to hold SQL statments
        public static SqlConnection conn;
        public static SqlCommand command;// process the SQL statements and connection
        public static SqlDataReader reader;//retrieve data from the database 

                                //(sql statements, //where to store the data)
        public static void fill(string q, DataGridView dgv)
        {
            try
            {
                ConnectionDB.DB();
                DataTable dt = new DataTable();
                SqlDataAdapter data = null;
                SqlCommand command = new SqlCommand(q,ConnectionDB.conn);
                data = new SqlDataAdapter(command);
                data.Fill(dt);
                dgv.DataSource = dt;//retrieve all the records and display it in the datagridview.
                ConnectionDB.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
