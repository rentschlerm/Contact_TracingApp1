using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System.Data.SqlClient;

namespace Contact_TracingApp1
{
    public partial class Registration : Form
    {


       
        
        public Registration()
        {
            InitializeComponent();
           
           
           
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Close();
            Form2 main = new Form2();
            main.Show();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionDB.DB();
                Functions.Functions.gen = "Insert into users(firstname, lastname, email, contact, username, password, dateregistered, roleid)values('"+txtFirstname.Text+"','"+txtLastname.Text+"','"+txtEmailaddress.Text+"','"+txtContactno.Text+"','"+txtUsername.Text+"','"+txtPassword.Text+"','"+ DateTime.Now.ToString("yyyy-MM-dd") + "','" +cmbroleid.Text + "')";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, ConnectionDB.conn);
                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("You can now log in with your account", "Login", MessageBoxButtons.OK);
                ConnectionDB.conn.Close();

                Filldata2();
                this.Close();
                Form2 main = new Form2();
                main.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);            
            }
            
           
        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvRegistration_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           /* try
            {
                ConnectionDB.DB();
                Functions.Functions.gen = "UPDATE users SET firstname = '" + txtFirstname.Text + "'," +
                    "lastname= '" + txtLastname.Text + "',email'" + txtEmailaddress.Text + "', username= '" + txtUsername.Text + "'," +
                    "password= '" + txtPassword.Text + "'," +
                    "roleid= '" + cmbroleid.Text + "';
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, ConnectionDB.conn);
                Functions.Functions.command.ExecuteNonQuery();
                ConnectionDB.conn.Close();
                MessageBox.Show("It has been updated!", "Update Record", MessageBoxButtons.OK,MessageBoxIcon.Information);
                Filldata2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvRegistration_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {
            Filldata2();
        }
        
        public void Filldata2()
        {
            Functions.Functions.gen = "Select users.userid AS [USER ID], users.firstname AS [FIRST NAME], users.lastname AS [LAST NAME], users.username, users.password, users.dateregistered AS [DATE REGISTERED], role.roleId AS [ROLE] from users INNER JOIN role on role.roleId = users.roleid ";
            Functions.Functions.fill(Functions.Functions.gen, dgvRegistration);
        }
    }
}
