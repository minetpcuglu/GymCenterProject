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
    public partial class UyeleriGoruntule : Form
    {
        public UyeleriGoruntule()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-RKDCHFH;Initial Catalog=SporDb;Integrated Security=True");
        private void uyeler()
        {
            baglanti.Open();
            string guery = "Select * from TblUye";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(guery,baglanti);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
            var ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void uyefiltrele()
        {
            baglanti.Open();
            string guery = "Select * from TblUye where AdıSoyad='" + ara.Text + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(guery, baglanti);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
            var ds = new DataSet();
            sqlDataAdapter.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void UyeleriGoruntule_Load(object sender, EventArgs e)
        {
            uyeler();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uyefiltrele();
            ara.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uyeler();
        }
    }
}
