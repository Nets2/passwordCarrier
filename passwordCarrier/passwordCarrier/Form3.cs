using System.Windows.Forms;

namespace passwordCarrier
{
    public partial class Form3 : Form
    {
        private Form1 Parent { get; set; }
        public Form3( Form1 parent)
        {
            this.Parent = parent;
            InitializeComponent();
        }
    }
}