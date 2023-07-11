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
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
            populate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\imannet\Documents\bookshopdb.mdf;Integrated Security=True;Connect Timeout=30");
       public void populate()
        {
            
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\imannet\Documents\bookshopdb.mdf;Integrated Security=True;Connect Timeout=30");
           if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }
            string query = " SELECT  * FROM BookTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query , conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds =new DataSet();
            sda.Fill(ds);
            BookDGV.DataSource = ds.Tables[0];
            conn.Close();

        }
        private void Filter()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            string query = " select  * from BookTbl WHERE BCat ='"+CatCbSearchCb.SelectedItem.ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookDGV.DataSource = ds.Tables[0];
            conn.Close();


        }
        private void SvaeBtn_Click(object sender, EventArgs e)
        {
            if (BTitleTb.Text == "" || BautTb.Text == "" || PriceTb.Text == "" || BCatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing informatio");
            }
             else
            {
                try 
                {
                    if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }
                    string query = "INSERT INTO BookTbl VALUES('" + BTitleTb.Text + "' , '" + BautTb.Text + "' , '" + BCatCb.SelectedItem.ToString() + "' , " + PriceTb.Text + " )";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book saved");
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

        private void CatCbSearchCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filter();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            populate();
            CatCbSearchCb.SelectedIndex = -1;
        }
        private void Reset ()
        {
            BTitleTb.Text = "";
            BautTb.Text = "";
            BCatCb.SelectedIndex = -1;
            PriceTb.Text = "";
        }
        private void RestBtn_Click(object sender, EventArgs e)
        {
            Reset();
           
        }
        int key = 0 ;    
        private void BookDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (BookDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                BookDGV.CurrentRow.Selected = true;
                BTitleTb.Text = BookDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                BautTb.Text = BookDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                BCatCb.SelectedItem = BookDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                PriceTb.Text = BookDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
                
            }
            if (BTitleTb.Text == "") 
            {
                key = 0;

            }

            {
                key = Convert.ToInt32(BookDGV.SelectedRows[0].Cells[0].Value.ToString());
            }


        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key ==0)
            {
                MessageBox.Show("Missing informatio");
            }
            else
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }
                    string query = "DELETE FROM BookTbl WHERE BId = "+ key +" ;  ";
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

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (BTitleTb.Text == "" || BautTb.Text == "" || PriceTb.Text == "" || BCatCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing informatio");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE BookTbl SET Btitle = '"+BTitleTb.Text+"' , BAuthor = '"+ BautTb.Text +"' , BCat = '"+BCatCb.SelectedItem.ToString()+"' , BPrice = "+ PriceTb.Text +" WHERE BId ="+key+"; " ;
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book updated");
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

        private void BTitleTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            user obj = new user();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
