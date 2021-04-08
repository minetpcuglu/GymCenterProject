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

namespace GUNABunufi
{
    public partial class Guncelle : Form
    {
        public Guncelle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-RKDCHFH;Initial Catalog=SporDb;Integrated Security=True");
        private void uyeler()
        {
            baglanti.Open();
            string guery = "Select * from TblUye";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(guery, baglanti);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
            var ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void Guncelle_Load(object sender, EventArgs e)
        {
            uyeler();
        }
        int key = 0;

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            adsoayd.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
           tel.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
           cinsiyet.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            yas.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            odeme.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            zamanlama.Text = guna2DataGridView1.SelectedRows[0].Cells[6].Value.ToString();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adsoayd.Text = "";
            tel.Text = "";
            cinsiyet.Text = "";
            yas.Text = "";
            odeme.Text = "";
            zamanlama.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show("Silinecek Üyeyi Seçiniz","Bilgilendirme Penceresi");
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Silme İşlemini onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        baglanti.Open();
                        string guery = "delete from TblUye where Id=" + key + ";";
                        SqlCommand sqlCommand = new SqlCommand(guery, baglanti);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show(+key + " Numaraları Üye basarıyla silindi" , "Bilgilendirme Penceresi");
                        baglanti.Close();
                        uyeler();
                    }
                    

                    else
                    {
                        MessageBox.Show("Kayıt işlemi tarafınızca iptal edilmiştir.", "Kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      
                    }
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Güncelle_Click(object sender, EventArgs e)
        {
            if (key == 0 || adsoayd.Text == "" || tel.Text == "" || yas.Text == "" || cinsiyet.Text == "" || odeme.Text == "" || zamanlama.Text == "") 
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                
                    if (MessageBox.Show("Güncelleme İşlemini onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        baglanti.Open();
                        string guery = "update TblUye set AdıSoyad='" + adsoayd.Text + "',Telefon='" + tel.Text + "',Cinsiyet='" + cinsiyet.Text + "',Yas='" + yas.Text + "',Odeme='" + odeme.Text + "',Zamanlama='" + zamanlama.Text + "' where Id =" + key + ";";
                        SqlCommand sqlCommand = new SqlCommand(guery, baglanti);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show(+key + " Numaralı Üye basarıyla Güncellendi" , "Bilgilendirme Penceresi");
                        baglanti.Close();
                        uyeler();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt güncelleme işlemi tarafınızca iptal edilmiştir.", "Kayıt İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                
              
            }
        }
    }
}
