using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;

namespace Contact_TracingApp1
{
    public partial class contactList : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        ConnectionDB db = new ConnectionDB();
        public contactList()
        {
            InitializeComponent();
            conn = new SqlConnection(db.GetConnection());
            Loadrecords();
        }
        public void Loadrecords()
        {

            dgvcontacts.Rows.Clear();
            int i = 0;
            ConnectionDB.DB();
            Functions.Functions.gen = "SELECT * FROM contacts";
            Functions.Functions.command = new SqlCommand(Functions.Functions.gen, ConnectionDB.conn);
            Functions.Functions.reader = Functions.Functions.command.ExecuteReader();

            while (Functions.Functions.reader.Read())
            {
                i++;
                dgvcontacts.Rows.Add(i, Functions.Functions.reader["TimeStamp"].ToString(), Functions.Functions.reader["FirstName"].ToString(), Functions.Functions.reader["LastName"].ToString(), Functions.Functions.reader["TimeStamp"].ToString(), Functions.Functions.reader["Email"].ToString(), Functions.Functions.reader["Address"].ToString(), Functions.Functions.reader["PhoneNumber"].ToString());

            }
            Functions.Functions.reader.Close();

        }
        private void btndashboard_Click(object sender, EventArgs e)
        {
            Form2 main = new Form2();
            main.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
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
                cmd = new SqlCommand("INSERT into contacts (TimeStamp, FirstName, LastName, Email, Address, PhoneNumber) VALUES (@TimeStamp, @FirstName, @LastName, @Email, @Address, @PhoneNumber)", conn);
                cmd.Parameters.AddWithValue("@TimeStamp", dgvcontacts.Rows[i].Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("@FirstName", dgvcontacts.Rows[i].Cells[2].Value.ToString());
                cmd.Parameters.AddWithValue("@LastName", dgvcontacts.Rows[i].Cells[3].Value.ToString());
                cmd.Parameters.AddWithValue("@Email", dgvcontacts.Rows[i].Cells[4].Value.ToString());
                cmd.Parameters.AddWithValue("@Address", dgvcontacts.Rows[i].Cells[5].Value.ToString());
                cmd.Parameters.AddWithValue("@PhoneNumber", dgvcontacts.Rows[i].Cells[6].Value.ToString());
                cmd.ExecuteNonQuery();

                conn.Close();

            }
            MessageBox.Show("Records Successfully Saved! ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Loadrecords();
        }

        private void contactList_Load(object sender, EventArgs e)
        {
            
        }
        
    }
}
