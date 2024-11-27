using System;
using System.Data;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace diş_klinigi
{
    public partial class tedavi : Form
    {
        public tedavi()
        {
            InitializeComponent();
        }
        void uyeler()
        { //hasta silme ve hasta ekleme fonksiyonları daha verimli kullanmak için bu fonksiyon oluşturuldu
            Hastalar Hs = new Hastalar();
            string query = "select * from TedaviTbl";
            DataSet ds = Hs.ShowHasta(query);
            TedaviDGV.DataSource = ds.Tables[0];

        }
        void filter()
        { //hasta silme ve hasta ekleme fonksiyonları daha verimli kullanmak için bu fonksiyon oluşturuldu
            Hastalar Hs = new Hastalar();
            string query = "select * from TedaviTbl where TAd like '%" + ARATB.Text + "%'";
            DataSet ds = Hs.ShowHasta(query);
            TedaviDGV.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            TedaviAdiTb.Text = "";
            TutarTb.Text = "";
            AciklamaTb.Text = "";
            
        }
        private void tedavi_Load(object sender, EventArgs e)
        {
            uyeler();
            Reset();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {

            string query = "insert into TedaviTbl (TAd, TUcret, TAciklama) values ('" + TedaviAdiTb.Text + "', '" + TutarTb.Text + "', '" + AciklamaTb.Text + "')";

            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Tedavi Başariyla Eklendi");
                uyeler();
                Reset();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int key = 0;

        public object TAdTb { get; private set; }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Güncelenecek Tedaviyi Seçiniz");
            }
            else
            {
                try
                {//hasta güncelleme
                    string query = "Update TedaviTbl set TAd='" + TedaviAdiTb.Text + "', TUcret='" + TutarTb.Text + "', TAciklama='" + AciklamaTb.Text + "' where TId=" + key + ";";



                    Hs.HastaSil(query);
                    MessageBox.Show("Tedavi başariyla güncellendi");
                    uyeler();
                    Reset();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Tedaviyi Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete  from TedaviTbl where TId=" + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Tedavi başariyla silindi");
                    uyeler();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void TedaviDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TedaviDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TedaviAdiTb.Text = TedaviDGV.SelectedRows[0].Cells[1].Value.ToString();
            TutarTb.Text = TedaviDGV.SelectedRows[0].Cells[2].Value.ToString();
            AciklamaTb.Text = TedaviDGV.SelectedRows[0].Cells[3].Value.ToString();
            
            if (TedaviAdiTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TedaviDGV.SelectedRows[0].Cells[0].Value.ToString());


            }

        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Anasayfa ana= new Anasayfa(); 
            ana.Show();
            this.Hide();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ARATB_TextChanged(object sender, EventArgs e)
        {
            filter();
        }
    }
}
