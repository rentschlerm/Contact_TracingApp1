using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Data.SqlClient;

namespace Contact_TracingApp1
{
    public partial class Form2 : Form
    {
       // MongoClient m_Client;
      // IMongoDatabase m_Database;
       // IMongoCollection<Registration> m_Collection;
       SqlConnection conn;
       SqlCommand cmd;
       SqlDataReader dr;
       ConnectionDB db = new ConnectionDB();
        public Form2()
        {
            InitializeComponent();
            Loadrecords();

            conn = new SqlConnection(db.GetConnection());
            //   m_Client = new MongoClient("mongodb+srv://root:contactred@maincluster.e4trz.mongodb.net/myFirstDatabase?retryWrites=true&w=majority ");
            //   m_Database = m_Client.GetDatabase("Contact_Tracing");
            //   m_Collection = m_Database.GetCollection<Registration>("Contacts");
            //  con = new SqlConnection(db.GetConnection());
        }
        //load database to database grid 2
        public void Loadrecords()
        {

            dgvcontacts.Rows.Clear();
            int i = 0;
            conn.Open();
            cmd = new SqlCommand("SELECT * Contact", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvcontacts.Rows.Add(i,dr["TimeStamp"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(), dr["TimeStamp"].ToString(), dr["Email"].ToString(), dr["Address"].ToString(), dr["PhoneNumber"].ToString());

            }
            dr.Close();
           conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            dgvcontacts.Rows.Clear();
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;
            Microsoft.Office.Interop.Excel.Range xlRange;

            int xlRow;
            string strFileName;

            openFD.Filter = "Excel Office |*.xls'; *xlsx";
            openFD.ShowDialog();
            strFileName = openFD.FileName;

            if (strFileName != "")
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(strFileName);
                xlWorksheet = xlWorkbook.Worksheets["Form Responses 1"];
                xlRange = xlWorksheet.UsedRange;

                //number of rows
                int i = 0;

                for (xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    if (xlRange.Cells[xlRow, 1].Text != "")
                    {
                        i++;
                        dgvcontacts.Rows.Add(i, xlRange.Cells[xlRow, 1].Text, xlRange.Cells[xlRow, 2].Text, xlRange.Cells[xlRow, 3].Text, xlRange.Cells[xlRow, 4].Text, xlRange.Cells[xlRow, 5].Text, xlRange.Cells[xlRow, 6].Text);
                    }
                }
                xlWorkbook.Close();
                xlApp.Quit();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvcontacts.Rows.Count; i++)
            {
                conn.Open();
                cmd = new SqlCommand("INSERT into Contacts (TimeStamp, FirstName, LastName, Email, Address, PhoneNumber) VALUES (@TimeStamp, @FirstName, @LastName, @Email, @Address, @PhoneNumber)", conn);
                cmd.Parameters.AddWithValue("@TimeStamp",dgvcontacts.Rows[i].Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("@FirstName",dgvcontacts.Rows[i].Cells[2].Value.ToString());
                cmd.Parameters.AddWithValue("@LastName",dgvcontacts.Rows[i].Cells[3].Value.ToString());
                cmd.Parameters.AddWithValue("@Email",dgvcontacts.Rows[i].Cells[4].Value.ToString());
                cmd.Parameters.AddWithValue("@Address",dgvcontacts.Rows[i].Cells[5].Value.ToString());
                cmd.Parameters.AddWithValue("@PhoneNumber",dgvcontacts.Rows[i].Cells[6].Value.ToString());
                cmd.ExecuteNonQuery();
               
                conn.Close();
                
            }
            MessageBox.Show("Records Successfully Saved! ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Loadrecords();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Registration registration = new Registration();
            registration.Show();

        }
    }
}
