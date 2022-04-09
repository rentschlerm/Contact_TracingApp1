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
        public class Service 
        {
           
            public String Password { get; set; }
            public String Username { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            int roleid;
            try
            {
                ConnectionDB.DB();
                Functions.Functions.gen = "SELECT * FROM Users WHERE Username = '" + txtUsername.Text + "' AND Password = '" + txtPassword.Text + "' "; // static variable for the sql statements
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, ConnectionDB.conn);
                Functions.Functions.reader = Functions.Functions.command.ExecuteReader();

                if (Functions.Functions.reader.HasRows)
                {
                    Functions.Functions.reader.Read();

                    roleid = Convert.ToInt32(Functions.Functions.reader["RoleId"]);

                    if (roleid == 1)
                    {
                        txtUsername.Text = Functions.Functions.reader["Username"].ToString();
                        txtPassword.Text = Functions.Functions.reader["Password"].ToString();

                        setfirstname = Functions.Functions.reader["FirstName"].ToString();
                        setlastname = Functions.Functions.reader["LastName"].ToString();
                        setuserId = Convert.ToInt32(Functions.Functions.reader["UserId"]);

                        var main = new Form2();
                        main.Show();
                        Hide();
                    }
                    else if (roleid == 2)
                    {
                        txtUsername.Text = Functions.Functions.reader["Username"].ToString();
                        txtPassword.Text = Functions.Functions.reader["Password"].ToString();

                        setfirstname = Functions.Functions.reader["FirstName"].ToString();
                        setlastname = Functions.Functions.reader["LastName"].ToString();

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
    }
}
