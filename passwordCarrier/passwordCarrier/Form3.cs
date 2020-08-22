using System;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace passwordCarrier
{
    public partial class Form3 : Form
    {
        private Form1 FormParent { get; set; }
        private bool FileExistFlag { get; set; }
        public Form3( Form1 parent)
        {
            this.FormParent = parent;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            FormParent.WindowState = FormWindowState.Minimized;
            this.BringToFront();
            this.Activate();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.FormParent.Visible = true;
            this.FormParent.WindowState = FormWindowState.Normal;
            this.FormParent.BringToFront();
            this.Close();
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            string login = this.loginTextArea.Text;
            string password = this.passwordTextArea.Text;
            string path = @"../../data/";
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string finalPath = path + Security.GetHash(sha256Hash, login);
                try
                {
                    //on vérifie que le fichier existe
                    //s'il existe on passe le flag a true;
                    StreamReader sr = File.OpenText(finalPath);
                    FileExistFlag = true;
                }
                catch
                {
                    //si ce n'est pas le cas on le créer et on passe le flag a false
                    using (FileStream fs = File.Create(finalPath))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(Security.GetHash(sha256Hash,password));
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                    FileExistFlag = false;
                }
                finally
                {                    
                    //dans tout les cas
                    if (FileExistFlag)
                    {
                        string message = "Error: username already in use";
                        string caption = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;

                        // Displays the MessageBox.
                        result = MessageBox.Show(message, caption, buttons);
                    }
                    else
                    {
                        cancelButton_Click(this, EventArgs.Empty);
                    }
                }
            }
        }
    }
}