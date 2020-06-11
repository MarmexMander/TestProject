using System;
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
    public partial class AddReprimentForm : Form
    {
        Database.User user;
        public AddReprimentForm(Database.User _user)
        {
            user = _user;
            InitializeComponent();
            label1.Text += user.FullName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 5)
                user.addRepriment(textBox1.Text);
            else
                MessageBox.Show("Repriment text too short");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
