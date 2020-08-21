using System;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace passwordCarrier
{
    public partial class Form2 : Form
    {
        private Form1 Parent { get; set; }
        public Form2(Form1 parent, string login, string saltedPassword)
        {
            this.Parent = parent;

            InitializeComponent();
            this.label1.Text = login;
            this.label2.Text = saltedPassword;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Parent.Visible = true;
            this.Close();
        }
        
    }
}