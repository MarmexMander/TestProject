﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fioBox.Text != "" && addressBox.Text != "" && telNumberBox.Text != "" && emailBox.Text != "" && departmentBox.Text != "" && positionBox.Text != "" && salaryBox.Text != "" && passwordBox.Text != "")
            {

                if (Database.Users.register(fioBox.Text, false, addressBox.Text, emailBox.Text, positionBox.Text, departmentBox.Text, telNumberBox.Text, Convert.ToSingle(salaryBox.Text), 0, 0, passwordBox.Text))
                {
                    MessageBox.Show("User registered");
                    this.Close();
                }
                 else
                {
                    MessageBox.Show("Some error in database");
                }
            }
            else
            {
                MessageBox.Show("Все поля обязательны.");
               
            }
        }
    }
}
