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
    public partial class Billing : Form
    {
        public Billing()
        {
            
            InitializeComponent();
            populate();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();

        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\imannet\Documents\bookshopdb.mdf;Integrated Security=True;Connect Timeout=30");
        public void populate()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }

            string query = " SELECT  * FROM BookTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookDGV.DataSource = ds.Tables[0];
            conn.Close();

        }
       
         
        private void SvaeBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("successful");


        }
        int key = 0;
        private void BookDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (BookDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                BookDGV.CurrentRow.Selected = true;
                BTitleTb.Text = BookDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                //BautTb.Text = BookDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
               // BCatCb.SelectedItem = BookDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
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

        private void BTitleTb_TextChanged(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            BTitleTb.Text = "";
            PriceTb.Text = "";
            ClientNameTb.Text = "";
        }
        private void RestBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Billing_Load(object sender, EventArgs e)
        {
            UserNameLbl.Text = Login.UserName;
        }
    }
}
