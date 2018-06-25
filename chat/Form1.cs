using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
          
        }
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private void addContactButton_Click(object sender, EventArgs e)
        {
            Form4 h = new Form4();
            h.Show();
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        protected void addConversationTextBox(object sender, EventArgs e)
        {
            this.listBox1.Items.Add("Me: "+sendMessageText.Text);

        }

      
    }
}
