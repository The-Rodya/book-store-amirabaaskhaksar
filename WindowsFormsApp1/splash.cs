﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }
        int startpos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos += 1;
            myprogress.Value = startpos;
            percentageLbl.Text = startpos + "%";
            if (myprogress.Value == 100)
            {
                myprogress.Value = 0;
                timer1.Stop();
                Login log = new Login();
                log.Show ();
                this.Hide ();



            }
        }

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Start ();
        }
    }
}
