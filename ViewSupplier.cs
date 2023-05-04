using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHALAQPROOF
{
    public partial class ViewSupplier : Form
    {
        public ViewSupplier()
        {
            InitializeComponent();
            DisplaySup();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainMenu Obj = new MainMenu();
            this.Hide();
            Obj.ShowDialog();
            this.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\POSDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplaySup()
        {
            Con.Open();
            string Query = "Select * from SupplierTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SuppliersDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            SNameTb.Text = "";
            SAddressTb.Text = "";
            SPhoneTb.Text = "";
            SRemarksTb.Text = "";
            Key = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (Key == 0)
            {
                MessageBox.Show("Select The Supplier");

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from SupplierTbl where SupId=@SKey", Con);
                    cmd.Parameters.AddWithValue("@SKey", Key);

                    cmd.ExecuteNonQuery(); ;
                    MessageBox.Show("Supplier Deleted");
                    Con.Close();
                    DisplaySup();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void SuppliersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SNameTb.Text = SuppliersDGV.SelectedRows[0].Cells[1].Value.ToString();
            SAddressTb.Text = SuppliersDGV.SelectedRows[0].Cells[2].Value.ToString();
            SPhoneTb.Text = SuppliersDGV.SelectedRows[0].Cells[3].Value.ToString();
            SRemarksTb.Text = SuppliersDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (SNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(SuppliersDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text == "" || SAddressTb.Text == "" || SPhoneTb.Text == "" || SRemarksTb.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update SupplierTbl set SupName=@SN,SupAddress=@SA,Supphone=@SP,SupRem=@SR where SupId=@SKey", Con);
                    cmd.Parameters.AddWithValue("@SN", SNameTb.Text);
                    cmd.Parameters.AddWithValue("@SA", SAddressTb.Text);
                    cmd.Parameters.AddWithValue("@SP", SPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@SR", SRemarksTb.Text);
                    cmd.Parameters.AddWithValue("@SKey", Key);
                    cmd.ExecuteNonQuery(); ;
                    MessageBox.Show("Supplier Updated");
                    Con.Close();
                    DisplaySup();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
