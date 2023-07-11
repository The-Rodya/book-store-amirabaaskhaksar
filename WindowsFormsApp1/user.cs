using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\imannet\\Documents\\bookshopdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }

            string query = " SELECT  * FROM UserTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];
            conn.Close();

        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || AddTb.Text == "" || PassTb.Text == "" || PhoneTb.Text == ""  ) 
            {
                MessageBox.Show("Missing informatio");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO UserTbl VALUES('" + UnameTb.Text + "' , '" + AddTb.Text + "' , '" + PhoneTb.Text + "' , " + PassTb.Text + " )";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User saved");
                    conn.Close();
                    populate();
                    Reset();
                   


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private void Reset()
        {
            UnameTb.Text = "";
            PassTb.Text = "";
            PhoneTb.Text = "";
            AddTb.Text = "";
        }
            private void RestBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Missing informatio");
            }
            else
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }
                    string query = "DELETE FROM UserTbl WHERE UId = " + key + " ;  ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book deleted");
                    conn.Close();
                    populate();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        int key = 0;
        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (UserDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                UserDGV.CurrentRow.Selected = true;
                UnameTb.Text = UserDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                PhoneTb.Text = UserDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                AddTb.Text = UserDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                PassTb.Text = UserDGV.Rows[e.RowIndex].Cells[4].Value.ToString();

            }
            if (UnameTb.Text == "") 
            {
                key = 0;

            }

            {
                key = Convert.ToInt32(UserDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || AddTb.Text == "" || PassTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing informatio");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE UserTbl SET UName = '" + UnameTb.Text + "' , UPhone = '" + PhoneTb.Text + "' , Uadd = '" + AddTb.Text + "' , Upass = " + PassTb.Text + " WHERE UId =" + key + "; ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User updated");
                    conn.Close();
                    populate();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void UnameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Books obj = new Books();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
           
        }
    }
}
