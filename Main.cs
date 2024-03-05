using System.Net.Mail;
using System.Net;
using System.Diagnostics;

namespace EMAIL_SENDER
{
    public partial class Main : Form
    {
        public static Email email;

        private Point lastCursorPosition;

        private int delayInSeconds;
        private int minimumDelayInSeconds = 600;

        public Main()
        {
            InitializeComponent();
            
            email = new Email();
            label2.Text = "Minimum: " + minimumDelayInSeconds.ToString() + "s";
        }     

        private void cursorTimer_Tick(object sender, EventArgs e)
        {
            if (lastCursorPosition != Cursor.Position) {
                email.sendEmail("Cursor position has changed \n Time: " + DateTime.Now);
                //this.Close();
            }

            lastCursorPosition = Cursor.Position;
        }

        private void Check_Delay_TextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                delayInSeconds = Int32.Parse(Check_Delay_TextBox.Text);
            }
            catch (Exception) {
                button1.Enabled = false;
            }

            if (delayInSeconds < minimumDelayInSeconds) {
                button1.Enabled = false;
                button1.Cursor = Cursors.No;
            }
            else if(delayInSeconds > minimumDelayInSeconds) {
                button1.Enabled = true;
                button1.Cursor = Cursors.Default;
                cursorTimer.Interval = delayInSeconds * 1000;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Check_Delay_TextBox.Enabled = false;
            cursorTimer.Start();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            if (this.WindowState == FormWindowState.Normal)
            {
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) {
                notifyIcon1.Icon = SystemIcons.Shield;
                notifyIcon1.BalloonTipText = "Minimized To System Tray";
                notifyIcon1.ShowBalloonTip(500);
                notifyIcon1.Visible = true;
                this.ShowInTaskbar = false;
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            email.sendEmail("Test email23");
            Program.loginForm.Show();
        }
    }
}