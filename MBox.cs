using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHALAQPROOF
{
    public partial class MBox : Form
    {
        public MBox()
        {
            InitializeComponent();
            MessageLbl.Text = Message;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        static string Message;
        public static void Show(string msg)
        {
            Message = msg;
            MBox Obj = new MBox();
            Obj.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MBox_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
