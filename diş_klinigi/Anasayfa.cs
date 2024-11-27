using System.Windows.Forms;

namespace diş_klinigi
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, System.EventArgs e)
        {
            randevucs rnd = new randevucs();
            rnd.Show();
            this.Hide();
        }

        private void guna2GradientButton3_Click(object sender, System.EventArgs e)
        {
            tedavi tdv= new tedavi();
            tdv.Show();
            this.Hide();
                
        }

        private void guna2GradientButton4_Click(object sender, System.EventArgs e)
        {
            
            recete rct = new recete();
            rct.Show();
            this.Hide();

           
           

        }

        private void guna2GradientButton1_Click(object sender, System.EventArgs e)
        {
            hasta hs = new hasta();
            hs.Show();
            this.Hide();
        }
    }
}
