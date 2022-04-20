using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_TracingApp1
{
    public partial class Form1 : Form
    {
        public static string setfirstname = "";
        public static string setlastname = "";
        public static int setuserId = 0;

        public Form1()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
           /* var main = new Form2();
            main.Show();
            Hide();*/
            
             int roleid;
             try
             {
                 ConnectionDB.DB();
                 Functions.Functions.gen = "SELECT * FROM users WHERE username = '" + txtUsername.Text + "' AND password = '" + txtPassword.Text + "' "; // static variable for the sql statements
                 Functions.Functions.command = new SqlCommand(Functions.Functions.gen, ConnectionDB.conn);
                 Functions.Functions.reader = Functions.Functions.command.ExecuteReader();

                 if (Functions.Functions.reader.HasRows)
                 {
                     Functions.Functions.reader.Read();

                     roleid = Convert.ToInt32(Functions.Functions.reader["roleId"]);

                     if (roleid == 1)
                     {
                         txtUsername.Text = Functions.Functions.reader["username"].ToString();
                         txtPassword.Text = Functions.Functions.reader["password"].ToString();

                         setfirstname = Functions.Functions.reader["firstname"].ToString();
                         setlastname = Functions.Functions.reader["lastname"].ToString();
                         setuserId = Convert.ToInt32(Functions.Functions.reader["userId"]);

                         var main = new Form2();
                         main.Show();
                         Hide();
                     }
                     else if (roleid == 2)
                     {
                         txtUsername.Text = Functions.Functions.reader["username"].ToString();
                         txtPassword.Text = Functions.Functions.reader["password"].ToString();

                         setfirstname = Functions.Functions.reader["firstname"].ToString();
                         setlastname = Functions.Functions.reader["lastname"].ToString();

                         var main = new Form2();
                         main.Show();
                         Hide();
                     }
                 }
                 else
                 {
                     MessageBox.Show("Incorrect username or password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
             }

             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }

             
        }

        private void label2_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

       
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
