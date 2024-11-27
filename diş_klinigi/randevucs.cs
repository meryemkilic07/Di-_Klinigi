using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using static Guna.UI2.Native.WinApi;

namespace diş_klinigi
{
    public partial class randevucs : Form
    {
        public randevucs()
        {
            InitializeComponent();
        }
        ConnectionString MyCon=new ConnectionString();//sql baglantı sınıfı kullanıldı.
        private void fillHasta()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut=new SqlCommand("select HAd from HastaTbl",baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("HAd", typeof(string));
            dt.Load(rdr);
            RadCb.ValueMember = "Had";
            RadCb.DataSource = dt;
            baglanti.Close();
        }
        private void fillTedavi()
        {
            SqlConnection baglanti = MyCon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select TAd from TedaviTbl", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TAd", typeof(string));
            dt.Load(rdr);
            RtedaviCb.ValueMember = "Tad";
            RtedaviCb.DataSource = dt;
            baglanti.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void randevucs_Load(object sender, EventArgs e)
        {
            fillHasta();
            fillTedavi();
            uyeler();
            Reset();    
                
        }
        void uyeler()
        { //hasta silme ve hasta ekleme fonksiyonları daha verimli kullanmak için bu fonksiyon oluşturuldu
            Hastalar Hs = new Hastalar();
            string query = "select * from RandevuTbl";
            DataSet ds = Hs.ShowHasta(query);
            RandevuDgv.DataSource = ds.Tables[0];
        }
        void filter()
        { //hasta silme ve hasta ekleme fonksiyonları daha verimli kullanmak için bu fonksiyon oluşturuldu
            Hastalar Hs = new Hastalar();
            string query = "select * from RandevuTbl where Hasta like '%" + araTb.Text + "%'";
            DataSet ds = Hs.ShowHasta(query);
            RandevuDgv.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            RadCb.SelectedIndex = -1;
            RtedaviCb.SelectedIndex = -1;
            RtedaviCb.Text = "";
            SaatCb.Text = "";



        }
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            string query = "insert into RandevuTbl values ('" + RadCb.SelectedValue.ToString() + "', '" + RtedaviCb.SelectedValue.ToString() + "', '" +Rtarih.Text + "','"+SaatCb.Text+"')";
          
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Randevu Başariyla Eklendi");
                uyeler();
                Reset();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int key = 0;
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Güncelenecek Randevuyu Seçiniz");
            }
            else
            {
                try
                {//hasta güncelleme
                    string query = "Update RandevuTbl set Hasta='" + RadCb.SelectedValue.ToString() + "', Tedavi='" + RtedaviCb.SelectedValue.ToString() + "', Rtarih='" + Rtarih.Text + "',Rsaat='"+SaatCb.Text+"'where RId=" + key + ";";



                    Hs.HastaSil(query);
                    MessageBox.Show("Randevu başariyla güncellendi");
                    uyeler();                     
                    Reset();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void RandevuDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RadCb.SelectedValue= RandevuDgv.SelectedRows[0].Cells[1].Value.ToString();
            RtedaviCb.SelectedValue = RandevuDgv.SelectedRows[0].Cells[2].Value.ToString();
           Rtarih.Text = RandevuDgv.SelectedRows[0].Cells[3].Value.ToString();
           SaatCb.Text = RandevuDgv.SelectedRows[0].Cells[4].Value.ToString();
            if (RadCb.SelectedIndex == -1)
            {
                key = 0;
            }else
            {
                key = Convert.ToInt32(RandevuDgv.SelectedRows[0].Cells [0].Value.ToString());
            }
                

         
        
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Randevuyu  Seçiniz");
            }
            else
            {
                try
                {
                    string query = "Delete  from RandevuTbl where RId=" + key + "";
                    Hs.HastaSil(query);
                    MessageBox.Show("Randevu başariyla silindi");
                    uyeler();
                   // Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            filter();
        }
    }
}
