using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace passwordCarrier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string path = @"../../data/";
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string finalPath = path + (Security.GetHash(sha256Hash, textBox1.Text));
                try
                {
                    using (StreamReader sr = File.OpenText(finalPath))
                    {
                        if (sr.ReadLine().Equals(Security.GetHash(sha256Hash, textBox2.Text)))
                        {
                            Form2 newWindows = new Form2(this, finalPath, Security.GetHash(sha256Hash, textBox2.Text));
                            newWindows.Show();
                            this.Visible = false;
                        }
                        else
                        {
                            string message = "Error: Wrong username or password";
                            string caption = "Error";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            // Displays the MessageBox.
                            result = MessageBox.Show(message, caption, buttons);
                        }
                    }
                }
                catch
                {
                    // Initializes the variables to pass to the MessageBox.Show method.
                    string message = "Error: Wrong username or password";
                    string caption = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                }
            }
        }

        private void subscribeButton_Click(object sender, EventArgs e)
        {
            Form3 subscribe = new Form3(this);
            subscribe.Show();
        }

    }
}