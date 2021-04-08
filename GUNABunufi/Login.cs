using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUNABunufi
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonreset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void buttonlogin_Click(object sender, EventArgs e)

        {


            System.Media.SoundPlayer ses = new System.Media.SoundPlayer();
            ses.SoundLocation = "music.wav";   //wav cekmeyi unutma debug klasöre atmayı unutma 
            ses.Play();



            if (textBox1.Text==""||textBox2.Text=="")
            {
                MessageBox.Show("Hatalı veya Eksik Kullanıcı girişi ");
            }
            else if (textBox1.Text=="admin"&&textBox2.Text=="1111")
            {
                AnaSayfa anaSayfa = new AnaSayfa();
                anaSayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı veya Eksik Kullanıcı girişi");
            }
            
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
