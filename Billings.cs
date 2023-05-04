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
using System.Drawing;
using System.Drawing.Printing;

namespace KHALAQPROOF
{
    public partial class Billings : Form
    {
        public Billings()
        {
            InitializeComponent();
            DisplayProducts();
            GetCustomer();
        }

        private void CPhoneTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Logins Obj = new Logins();
            Obj.Show();
            this.Hide();    
        }
        private void GetCustName()
        {
            Con.Open();
            string Query = "Select * from CustomerTbl where CustId=" + CustIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CustNameTb.Text = dr["CustName"].ToString();
            }
            Con.Close();
        }
        private void GetCustomer()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CustId from CustomerTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(int));
            dt.Load(rdr);
            CustIdCb.ValueMember = "CustId";
            CustIdCb.DataSource = dt;
            Con.Close();

        }
        private void Reset()
        {
            Pname = "";
            QtyTb.Text = "";
            Key = 0;
        }
        
        int Key = 0;
        string Pname;
        int Pprice, PStock;
        int n = 1, total = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Pname = ProductsDGV.SelectedRows[0].Cells[1].Value.ToString();
          //  PCatCb.SelectedItem = ProductsDGV.SelectedRows[0].Cells[2].Value.ToString();
            Pprice = Convert.ToInt32(ProductsDGV.SelectedRows[0].Cells[3].Value.ToString());
                PStock = Convert.ToInt32(ProductsDGV.SelectedRows[0].Cells[4].Value.ToString());
            if (Pname == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ProductsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\POSDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void DisplayProducts()
        {
            Con.Open();
            string Query = "Select * from ProductTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void SearchProducts()
        {
            Con.Open();
            string Query = "Select * from ProductTbl where PName= '" + SearchTb.Text + "'"; ;
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SearchProducts();
            SearchTb.Text = "";
        }

        private void UpdateQty()
        {
            int newQty = PStock - Convert.ToInt32(QtyTb.Text);
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("Update ProductTbl set PQty=@PQ where PId=@PKey", Con);

                cmd.Parameters.AddWithValue("@PQ", newQty);
                cmd.Parameters.AddWithValue("PKey", Key);

                cmd.ExecuteNonQuery(); ;
                //  MessageBox.Show("Product Updated");
                Con.Close();
                DisplayProducts();
                //  Reset();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void AddToBill_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select A Product");
            }
            else if (QtyTb.Text == "")
            {
                MessageBox.Show("Enter The Quantity");
            }
            else if (Convert.ToInt32(QtyTb.Text) > PStock)
            {
                MessageBox.Show("No Enough Stock");
            }
            else
            {
                int Subtotal = Convert.ToInt32(QtyTb.Text) * Pprice;
                total = total + Subtotal;
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BillDGV);
                newRow.Cells[0].Value = n;
                newRow.Cells[1].Value = Pname;
                newRow.Cells[2].Value = QtyTb.Text;
                newRow.Cells[3].Value = Pprice;
                newRow.Cells[4].Value = Subtotal;
                BillDGV.Rows.Add(newRow);
                n++;
                SubTotalTb.Text = "" + total;
                UpdateQty();
                Reset();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Logins Obj = new Logins();
            this.Hide();
            Obj.ShowDialog();
            this.Hide();
        }

        private void VATTb_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void VATTb_KeyUp(object sender, KeyEventArgs e)
        {
            if(VATTb.Text == "")
            {

            }else if(SubTotalTb.Text == "")
            {
                MessageBox.Show("Add Products To Cart");
                VATTb.Text = "";
            }else
            {
                try
                {
                    double VAT = (Convert.ToDouble(VATTb.Text) / 100) * Convert.ToInt32(SubTotalTb.Text);
                    TotalTaxTb.Text = "" + VAT;
                    GrdTotalTb.Text = ""+(Convert.ToInt32(SubTotalTb.Text) + Convert.ToDouble(TotalTaxTb.Text));
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (DiscountTb.Text == "")
            {

            }
            else if (SubTotalTb.Text == "")
            {
                MessageBox.Show("Add Products To Cart");
                DiscountTb.Text = "";
            }
            else
            {
                try
                {
                    double Disc = (Convert.ToDouble(DiscountTb.Text) / 100) * Convert.ToInt32(SubTotalTb.Text);
                    DiscTotTb.Text = "" + Disc;
                    GrdTotalTb.Text = "" + (Convert.ToInt32(SubTotalTb.Text) -Convert.ToDouble(TotalTaxTb.Text)+Convert.ToDouble(DiscTotTb.Text));
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void InsertBill()
        {
            if (CustIdCb.SelectedIndex == -1 || PaymentMtdCb.SelectedIndex == -1 || GrdTotalTb.Text == "" )
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into BillTbl(BDate,CustId,CustName,PMethod,Amt)values(@BD,@CI,@CN,@PM,@Am)", Con);
                    cmd.Parameters.AddWithValue("@BD", BDate.Value.Date);
                    cmd.Parameters.AddWithValue("@CI", CustIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@CN", CustNameTb.Text);
                    cmd.Parameters.AddWithValue("@PM", PaymentMtdCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Am", Convert.ToDouble(GrdTotalTb.Text));
                    cmd.ExecuteNonQuery(); ;
                    MessageBox.Show("Bill Saved");
                    Con.Close();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int flag = 0;
        private void button3_Click(object sender, EventArgs e)
        {
        InsertBill();
            if (flag == 0)
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
        }


        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
        int prodid, prodqty, prodprice, tottal, pos = 60;

        private void SubTotalTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void BillDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            ViewBills Obj = new ViewBills();
            Obj.Show();
        }

        string prodname;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("KHALAQ PROOF SHOP", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("ID PRODUCT PRICE QUANTITY TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26, 40));
            foreach (DataGridViewRow row in BillDGV.Rows)
            {

                prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                prodname = "" + row.Cells["Column2"].Value;
                prodprice = Convert.ToInt32(row.Cells["Column4"].Value);
                prodqty = Convert.ToInt32(row.Cells["Column3"].Value);
                tottal = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(26, pos));
                e.Graphics.DrawString("" + prodname, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(45, pos));
                e.Graphics.DrawString("" + prodprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(120, pos));
                e.Graphics.DrawString("" + prodqty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(170, pos));
                e.Graphics.DrawString("" + tottal, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Black, new Point(235, pos));
                pos = pos + 20;
            }
            e.Graphics.DrawString("Grand Total: EUR " + GrdTotalTb.Text, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(50, pos + 50));
            e.Graphics.DrawString("---THANK YOU FOR SHOPPING---", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(10, pos + 85));
            BillDGV.Rows.Clear();
            BillDGV.Refresh();
            pos = 100;
            GrdTotalTb.Text = "";
            n = 0;
        }
        private void CustIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCustName();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DisplayProducts();
            SearchTb.Text = "";
        }
    }
}
