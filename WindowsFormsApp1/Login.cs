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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static string UserName = "";
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\imannet\Documents\bookshopdb.mdf;Integrated Security=True;Connect Timeout=30");

            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }

            SqlDataAdapter sda = new SqlDataAdapter("SELECT count (*) FROM UserTbl WHERE Uname = '" + UnameTb.Text + "' and Upass= '" + UpassTb.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                UserName = UnameTb.Text;
                Billing obj = new Billing();
                obj.Show();
                this.Hide();
                conn.Close();

            }
            else
            {
                MessageBox.Show("wrong usename or password");
            }
            conn.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\imannet\Documents\bookshopdb.mdf;Integrated Security=True;Connect Timeout=30");
        public void sign_Click(object sender, EventArgs e)
        {
            if (Usertb.Text == "" || AddrTb.Text == "" || PassWTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing informatio");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO UserTbl VALUES('" + Usertb.Text + "' , '" + PhoneTb.Text + "' , '" + AddrTb.Text + "' , " + PassWTb.Text + " )";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User saved");
                    conn.Close();
                    Billing obj = new Billing();
                    obj.Show();
                    this.Hide();
                    conn.Close();




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Adminlogin obj = new Adminlogin();
            obj.Show();
            this.Hide();
        }
    }
}
