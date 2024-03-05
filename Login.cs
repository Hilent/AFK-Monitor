using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMAIL_SENDER
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Main main = new Main();

            Main.email.address = emailTextBox.Text;
            Main.email.password = passTextBox.Text;

            main.Show();

            this.Hide();
        }
    }
}
