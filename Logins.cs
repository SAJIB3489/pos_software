using KHALAQPROOF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KHALAQPROOF
{
    public partial class Logins : Form
    {
        public Logins()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Billings Billings = new Billings();
            Billings.Show();
            this.Hide();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if(UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Enter UserName and Password");
            }else if(UnameTb.Text == "SAJIB" && PasswordTb.Text == "349058")
            {
                MainMenu Obj = new MainMenu();
                Obj.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Wrong UserName Or Password");
            }
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void PasswordTb_TextChanged(object sender, EventArgs e)
        {
            PasswordTb.PasswordChar = '*';
        }

        private void Logins_Load(object sender, EventArgs e)
        {

        }
    }
}