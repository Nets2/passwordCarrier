using System;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace passwordCarrier
{
    public partial class Form2 : Form
    {
        private Form1 FormParent { get; set; }
        public Form2(Form1 parent, string login, string saltedPassword)
        {
            this.FormParent = parent;

            InitializeComponent();
            this.label1.Text = login;
            this.label2.Text = saltedPassword;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FormParent.Visible = true;
            this.Close();
        }
        
    }
}