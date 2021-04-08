using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GUNABunufi
{
    public partial class AdSoyad : Form
    {
        public AdSoyad()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-RKDCHFH;Initial Catalog=SporDb;Integrated Security=True");

        private void UyeEkle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
            try
            {
              
                int yas = Convert.ToInt32(Yas.Text);
            
               

                if (AD.Text == "" || Telefon.Text == "" || tutar.Text == "" || Yas.Text == "")
                {
                    MessageBox.Show("Eksik Bilgi Girdiniz Tekrar Deneyiniz ! " , "Bilgilendirme Penceresi");
                }
                else
                {
                    if (MessageBox.Show("Kayıt İşlemini onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        baglanti.Open();
                        string guery = "insert into TblUye values('" + AD.Text + "','" + Telefon.Text + "','" + Cınsıyet.SelectedItem.ToString() + "','" + Yas.Text + "','" + tutar.Text + "','" + Saat.SelectedItem.ToString() + "')";
                        SqlCommand komut = new SqlCommand(guery, baglanti);
                        komut.ExecuteNonQuery();
                        MessageBox.Show("Üye Başarıyla Eklendi", "Bilgilendirme Penceresi");
                        baglanti.Close();
                        AD.Text = "";
                        Telefon.Text = "";
                        tutar.Text = "";
                        Yas.Text = "";
                        Cınsıyet.Text = "";
                        Saat.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Kayıt  işlemi tarafınızca iptal edilmiştir.", "Kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                

                MessageBox.Show(" Değerleri dogru ve boşta alan kalmayacak bir şekilde doldurunuz ! "  , "Bilgilendirme Penceresi");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            AD.Text = "";
            Telefon.Text = "";
            tutar.Text = "";
            Yas.Text = "";
            Cınsıyet.Text= "";
            Saat.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void Telefon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
