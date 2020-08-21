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
                string finalPath = path + (GetHash(sha256Hash, textBox1.Text));
                try
                {
                    using (StreamReader sr = File.OpenText(finalPath))
                    {
                        if (sr.ReadLine().Equals(GetHash(sha256Hash, textBox2.Text)))
                        {
                            Form2 newWindows = new Form2(this, finalPath, GetHash(sha256Hash, textBox2.Text));
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
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        
        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetHash(hashAlgorithm, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}