using System;
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
            int id = Database.User.getIdByFullName(listBox1.SelectedItem.ToString());
            Database.Users.remove(id);
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
    }
}
