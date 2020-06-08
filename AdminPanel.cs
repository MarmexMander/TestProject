﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//dbhsfihfbihf
namespace TestProject
{
    public partial class Form1 : Form
    {
        Form parent;
        Database.User User;
        public Form1(Database.User user, Form form)
        {
            InitializeComponent();
            List<Database.User> arr = new List<Database.User>();
            arr = Database.Users.GetUsers();
            foreach (Database.User u in arr)
            {
                listBox1.Items.Add(u.FullName);
            }
            listBox1.ContextMenuStrip = contextMenuStrip1;
            contextMenuStrip1.Items[0].Click += Form1_Click;
            contextMenuStrip1.Items[1].Click += Form1_Click1;

            parent = form;
            User = user;
        }

        private void Form1_Click1(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                int id = Database.User.getIdByFullName(listBox1.SelectedItem.ToString());
                Database.Users.remove(id);
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            SignupForm sgf = new SignupForm();
            sgf.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            User.logout();
            parent.Visible = true;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Database.User user = listBox1.SelectedItem as Database.User;
            if (listBox1.SelectedItem != null)
            {
                try { user.ReprimentQuantity++; }
                catch { user.ReprimentQuantity = 1; }
                user.Save();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database.User user = new Database.User(Database.User.getIdByFullName(listBox1.SelectedItem.ToString()));
            if (listBox1.SelectedItem != null)
            {
                MessageBox.Show($"Нараховано зарплату в розмірі {user.calcWage()}UAH.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Database.User user = new Database.User(Database.User.getIdByFullName(listBox1.SelectedItem.ToString()));
                label12.Text = user.FullName;
                label14.Text = user.PhoneNumber;
                label15.Text = user.Addres;
                label16.Text = user.Email;
                label17.Text = user.Position;
                label18.Text = user.Departament;
                label19.Text = user.Wage.ToString();
                label20.Text = user.ReprimentQuantity.ToString();
                label21.Text = user.calcWage().ToString();
            }
        }
    }
}
