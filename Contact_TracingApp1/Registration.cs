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

       //     static MongoClient m_Client;
       //     static IMongoDatabase m_Database = m_Client.GetDatabase("Contact_Tracing");
       //     static IMongoCollection<UserRegistration> m_Collection = m_Database.GetCollection<UserRegistration>("Users");


       // public void Read()
       // {
        /*
          //  List<UserRegistration> list = m_Collection.AsQueryable().ToList<UserRegistration>();
            dgvRegistration.DataSource = list;
            txtFirstname.Text = dgvRegistration.Rows[0].Cells[0].Value.ToString();
            txtLastname.Text = dgvRegistration.Rows[0].Cells[1].Value.ToString();
            txtUsername.Text = dgvRegistration.Rows[0].Cells[2].Value.ToString();
            txtPassword.Text = dgvRegistration.Rows[0].Cells[3].Value.ToString();
            txtEmailaddress.Text = dgvRegistration.Rows[0].Cells[4].Value.ToString();
            txtContactno.Text = dgvRegistration.Rows[0].Cells[5].Value.ToString();
            */
       // }
        /*   public class UserRegistration
          {
            //  public UserRegistration()
             // {
            //  }

             public UserRegistration(string firstname, string lastname, string email, string username, string password, long phonenumber)
              {
                  Firstname = firstname;
                  Lastname = lastname;
                  Email = email;
                  Username = username;
                  Password = password;
                  Phonenumber = phonenumber;
              }

              [BsonRepresentation(BsonType.ObjectId)]
              public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
             public String Firstname { get; set; }
             public String Lastname { get; set; }
             public String Email { get; set; }
             public String Username { get; set; }
             public String Password { get; set; }
             public long Phonenumber { get; set; }
          }


         // MongoClient m_Client;
       //   IMongoDatabase m_Database;
        //  IMongoCollection<Registration> m_Collection;
  */
        public Registration()
        {
            InitializeComponent();
           // Read();
           
           
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
                Functions.Functions.gen = "Insert into users(firstname, lastname, email, contact, username, password, dateregistered, roleid)values('"+txtFirstname.Text+"','"+txtLastname.Text+"','"+txtEmailaddress.Text+"','"+txtContactno.Text+"','"+txtUsername.Text+"','"+txtPassword.Text+"','"+DateTime.Now.ToString()+"',1)";
                Functions.Functions.command = new SqlCommand(Functions.Functions.gen, ConnectionDB.conn);
                Functions.Functions.command.ExecuteNonQuery();
                MessageBox.Show("You can now log in with your account", "Login", MessageBoxButtons.OK);
                ConnectionDB.conn.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);            
            }
            
            
            /*  try
            {
              var  m_Client = new MongoClient("mongodb+srv://root:contactred@maincluster.e4trz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority ");
              var  m_Database = m_Client.GetDatabase("Contact_Tracing");
              var  m_Collection = m_Database.GetCollection<UserRegistration>("Users");
               

                UserRegistration registration = new UserRegistration();
                registration.Firstname = txtFirstname.Text;
                registration.Lastname = txtLastname.Text;
                registration.Email = txtEmailaddress.Text;
                registration.Username = txtUsername.Text;
                registration.Password = txtPassword.Text;
                registration.Phonenumber = Convert.ToInt64(txtContactno.Text);
                
                m_Collection.InsertOneAsync(registration);.

                

                MessageBox.Show("New user added");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvRegistration_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtFirstname.Text = dgvRegistration.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtLastname.Text = dgvRegistration.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtUsername.Text = dgvRegistration.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPassword.Text = dgvRegistration.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtEmailaddress.Text = dgvRegistration.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtContactno.Text = dgvRegistration.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           /* var update = Builders<UserRegistration>.Update.Set("Firstname", txtFirstname.Text)
                .Set("Lastname", txtLastname.Text)
                .Set("Username", txtUsername.Text)
                .Set("Password", txtPassword.Text)
                .Set("Email", txtEmailaddress.Text)
                .Set("Phonenumber", txtContactno.Text);
          //  m_Collection.UpdateOne(s => s.Id == ObjectId.Parse(txtId.Text), update);
            Read();
           */
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // m_Collection.DeleteOne(s => s.Id == ObjectId.Parse(txtId.Text));
           // Read(); 
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
