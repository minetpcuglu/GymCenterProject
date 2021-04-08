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
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-RKDCHFH;Initial Catalog=SporDb;Integrated Security=True");
        private void FillName()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select AdıSoyad from TblUye",baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("AdıSoyad", typeof(string));
            dt.Load(rdr);
            adsoyad.ValueMember = "AdıSoyad";
            adsoyad.DataSource = dt;
            baglanti.Close();

        }
        public void müzik()
        {
            System.Media.SoundPlayer ses = new System.Media.SoundPlayer();
            ses.SoundLocation = "dance.wav";   
            ses.Play();

        }
        private void uyeler()
        {
            baglanti.Open();
            string guery = "Select * from TblOdeme";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(guery, baglanti);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
            var ds = new DataSet();
            sqlDataAdapter.Fill(ds);
           ara.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void uyefiltrele()
        {
            baglanti.Open();
            string guery = "Select * from TblOdeme where Uye='"+ara1.Text+"'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(guery, baglanti);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
            var ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            ara.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            adsoyad.Text = "";
            tutar.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void Odeme_Load(object sender, EventArgs e)
        {
            
            FillName();
            uyeler();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int Tutar = Convert.ToInt32(tutar.Text);
                if (adsoyad.Text == "" || tutar.Text == "")
                {
                    MessageBox.Show("Eksik Bilgi Girdiniz Lütfen tekrar deneyiniz");

                }
                else
                {

                    string odemeperiyot = tarih.Value.Day.ToString() + "/"+ tarih.Value.Month.ToString() + "/" + tarih.Value.Year.ToString();
                    baglanti.Open();

                    SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from TblOdeme where Uye='" + adsoyad.SelectedValue.ToString() + "' and Ay='" + odemeperiyot + "'", baglanti);
                    DataTable dataTable = new DataTable();
                    sda.Fill(dataTable);

                    if (dataTable.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show("Bu ayki Ödeme işlemi daha önceden yapılmıştır", " Bilgilendirme Penceresi");
                    }

                    else if (tutar.Text == "0")
                    {
                        MessageBox.Show("Lütfen ödeme yapılcak miktarı giriniz", "Bilgilendirme Penceresi");
                    }
                    
                    else
                    {
                        string guery = "insert into TblOdeme values('" + odemeperiyot + "','" + adsoyad.SelectedValue.ToString() + "'," + tutar.Text + ")";
                        SqlCommand komut = new SqlCommand(guery, baglanti);

                        komut.ExecuteNonQuery();

                        if (MessageBox.Show("Ödeme İşlemini onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            MessageBox.Show("Ödeme işlemi başarılı bir şekilde gercekleştirildi", "Bilgilendirme Penceresi");
                        }
                        else
                        {
                            MessageBox.Show("Ödeme işlemi tarafınızca iptal edilmiştir.", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    baglanti.Close();

                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(" Değerleri dogru ve boşta alan kalmayacak bir şekilde doldurunuz ! " , "Bilgilendirme Penceresi");
            }




        }

        private void button5_Click(object sender, EventArgs e)
        {
            uyefiltrele();
            ara1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uyeler();
        }
    }
}
