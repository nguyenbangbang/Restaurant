﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class Login: Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(MainClass.IsValidUser(txtUser.Text,txtPassword.Text)==false)
            {
                guna2MessageDialog1.Show("Invalid username and password");
                return;
            }
            else
            {
                this.Hide();
                Main frm = new Main();
                frm.Show(); 
            }
        }
    }
}
