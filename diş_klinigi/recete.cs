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
using static Guna.UI2.Native.WinApi;

namespace diş_klinigi
{
    public partial class recete : Form
    {
        public recete()
        {
            InitializeComponent();
        }
        ConnectionString MyCon = new ConnectionString();//sql baglantı sınıfı kullanıldı.

       

        private void fillHasta()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select HAd from HastaTbl", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("HAd", typeof(string));
            dt.Load(rdr);
            HastaASCb.ValueMember = "Had";
            HastaASCb.DataSource = dt;
            baglanti.Close();
        }
        private void fillTedavi()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from RandevuTbl where Hasta='" + HastaASCb.SelectedValue.ToString() + "'", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                TedaviTb.Text = dr["Tedavi"].ToString();
            }
            baglanti.Close();
        }
        private void fillPrice()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TedaviTbl where TAd='" + TedaviTb.Text + "'", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                IlaclarTb.Text = dr["TUcret"].ToString();
            }
            baglanti.Close();
        }
        private void recete_Load(object sender, EventArgs e)
        {
            fillHasta();
            uyeler();
            Reset();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton11_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            try
            {
                string query = "insert into ReceteTbl (TAd, TUcret, TAciklama) values ('" + HastaASCb.SelectedValue.ToString() + "', '" + TedaviTb.Text + "', '" + IlaclarTb.Text + "'," + MiktarTb.Text + ")";
                Hs.HastaEkle(query);
                MessageBox.Show("Recete Başariyla Eklendi");
                uyeler();
                Reset();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void HastaASCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fillTedavi();
        }
        void uyeler()
        { //hasta silme ve hasta ekleme fonksiyonları daha verimli kullanmak için bu fonksiyon oluşturuldu
            Hastalar Hs = new Hastalar();
            string query = "select * from ReceteTbl";
            DataSet ds = Hs.ShowHasta(query);
            ReceteDGV.DataSource = ds.Tables[0];
        }
        void filter()
        { //hasta silme ve hasta ekleme fonksiyonları daha verimli kullanmak için bu fonksiyon oluşturuldu
            Hastalar Hs = new Hastalar();
            string query = "select * from ReceteTbl where HasAd like '%" + AraTB.Text + "%'";
            DataSet ds = Hs.ShowHasta(query);
            ReceteDGV.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            HastaASCb.SelectedItem = "";
            TutarTb.Text = "";
            IlaclarTb.Text = "";
            MiktarTb.Text = "";
            TedaviTb.Text = "";

        }
        private void label8_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TutarTb_TextChanged(object sender, EventArgs e)
        {
            fillPrice();
        }

        private void TedaviAdiTb_TextChanged(object sender, EventArgs e)
        {
            fillPrice();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ReceteDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int key = 0;
        private void ReceteDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            {//datagrid de tıkladıgımız hastalrın bilgilerini veriyor
                HastaASCb.Text = ReceteDGV.SelectedRows[0].Cells[1].Value.ToString();
                TedaviTb.Text = ReceteDGV.SelectedRows[0].Cells[2].Value.ToString();
                TutarTb.Text = ReceteDGV.SelectedRows[0].Cells[3].Value.ToString();
                IlaclarTb.Text = ReceteDGV.SelectedRows[0].Cells[4].Value.ToString();
                MiktarTb.Text = ReceteDGV.SelectedRows[0].Cells[5].Value.ToString();

                if (TedaviTb.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(ReceteDGV.SelectedRows[0].Cells[0].Value.ToString());


                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Receteyi Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete  from ReceteTbl where RecId=" + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Recete başariyla silindi");
                    uyeler();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void AraTB_TextChanged(object sender, EventArgs e)
        {
            filter();
        }
        Bitmap bitmap;
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            int height = ReceteDGV.Height;
            ReceteDGV.Height = ReceteDGV.RowCount * ReceteDGV.RowTemplate.Height * 2;
            bitmap = new Bitmap(ReceteDGV.Width, ReceteDGV.Height);
            ReceteDGV.DrawToBitmap(bitmap, new Rectangle(0, 10, ReceteDGV.Width, ReceteDGV.Height));
            ReceteDGV.Height = height;
            printPreviewDialog1.ShowDialog();


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
