using System;
using System.Data;
using System.Windows.Forms;

namespace diş_klinigi
{
    public partial class hasta : Form
    {
        public hasta()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
        void uyeler()
        { //hasta silme ve hasta ekleme fonksiyonları daha verimli kullanmak için bu fonksiyon oluşturuldu
            Hastalar Hs = new Hastalar();
            string query = "select * from HastaTbl";
            DataSet ds = Hs.ShowHasta(query);
            HastaDGV.DataSource = ds.Tables[0];
        }
        void filter()
        { //hasta silme ve hasta ekleme fonksiyonları daha verimli kullanmak için bu fonksiyon oluşturuldu
            Hastalar Hs = new Hastalar();
            string query = "select * from HastaTbl where HAd like '%"+AraTb.Text+"%'";
            DataSet ds = Hs.ShowHasta(query);
            HastaDGV.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            HAdSoyadTb.Text = "";
            HTelefonTb.Text = "";
            AdresTb.Text = "";
            HDogumTarih.Text = "";
            HCinsiyetCb.SelectedItem= "";
            AlerjiTb.Text = "";
        } 

        private void hasta_Load(object sender, EventArgs e)
        {
            uyeler();
            Reset();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            string query = "insert into HastaTbl values('" + HAdSoyadTb.Text + "','" + HTelefonTb.Text + "','" + AdresTb.Text + "','" + HDogumTarih.Text + "','" + HCinsiyetCb.SelectedItem.ToString() + "','" + AlerjiTb.Text + "')";
            Hastalar Hs = new Hastalar();
            try
            {
                Hs.HastaEkle(query);
                MessageBox.Show("Hasta Başariyla Eklendi");
                uyeler();
                Reset();
            }catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HCinsiyetCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int key = 0;    
        private void HastaDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {//datagrid de tıkladıgımız hastalrın bilgilerini veriyor
            HAdSoyadTb.Text = HastaDGV.SelectedRows[0].Cells[1].Value.ToString();
            HTelefonTb.Text= HastaDGV.SelectedRows[0].Cells[2].Value.ToString();
            AdresTb.Text = HastaDGV.SelectedRows[0].Cells[3].Value.ToString();
            HDogumTarih.Text = HastaDGV.SelectedRows[0].Cells[4].Value.ToString();
            HCinsiyetCb.SelectedItem= HastaDGV.SelectedRows[0].Cells[5].Value.ToString();
            AlerjiTb.Text = HastaDGV.SelectedRows[0].Cells[6].Value.ToString();
            if(HAdSoyadTb.Text=="")
            {
                key = 0;
            }else
            {
                key = Convert.ToInt32(HastaDGV.SelectedRows[0].Cells[0].Value.ToString());   
                    
                    
            }


        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Hastayi Seçiniz");
            }else
            {
                try
                {
                    string query = "Delete  from HastaTbl where Hİd=" + key + "";
                   Hs.HastaSil(query);
                    MessageBox.Show("Hasta başariyla silindi");
                    uyeler();
                    Reset();

                }
                catch(Exception Ex)    
                {
                    MessageBox.Show(Ex.Message);    
                }
            }
            
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

            Hastalar Hs = new Hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Hastayi Seçiniz");
            }
            else
            {
                try
                {//hasta güncelleme
                    string query = "Update HastaTbl set HAd='" + HAdSoyadTb.Text + "',HTelefon='" + HTelefonTb.Text + "',HAdres='" + AdresTb.Text + "',HDTarih='" + HDogumTarih.Text + "',HCinsiyet='" + HCinsiyetCb.SelectedItem.ToString() + "',HAlerji='" + AlerjiTb.Text + "' where Hİd=" + key + ";";
                        

                    Hs.HastaSil(query);
                    MessageBox.Show("Hasta başariyla güncellendi");
                    uyeler();
                    Reset();
                        

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();
            this.Hide();
        }

        private void AraTb_TextChanged(object sender, EventArgs e)
        {
            filter();
                
        }
    }
}
