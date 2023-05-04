namespace KHALAQPROOF
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            AddSupplier addSupplier = new AddSupplier();
            this.Hide();
            addSupplier.ShowDialog();
            this.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            AddProducts addProducts = new AddProducts();
            this.Hide();
            addProducts.ShowDialog();
            this.Show();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Logins Obj = new Logins();
            this.Hide();
            Obj.ShowDialog();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewProducts viewProducts = new ViewProducts();
            this.Hide();
            viewProducts.ShowDialog();
            this.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            AddCustomer viewCustomer = new AddCustomer();
            this.Hide();
            viewCustomer.ShowDialog();
            this.Show();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewSupplier viewSupplier = new ViewSupplier();
            this.Hide();
            viewSupplier.ShowDialog();
            this.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ViewCustomer Obj = new ViewCustomer();
            this.Hide();
            Obj.ShowDialog();
            this.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Logins Obj = new Logins();
            this.Hide();
            Obj.ShowDialog();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            ViewProducts viewProducts = new ViewProducts();
            this.Hide();
            viewProducts.ShowDialog();
            this.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Billings Billings = new Billings();
            this.Hide();
            Billings.ShowDialog();
            this.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            ViewCustomer Obj = new ViewCustomer();
            this.Hide();
            Obj.ShowDialog();
            this.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ViewDashboard Obj = new ViewDashboard();
            this.Hide();
            Obj.ShowDialog();
            this.Show();
        }
    }
    
    
}