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

namespace OgrenciNotBilgisi
{
    public partial class SekreterGiris : Form
    {
        public SekreterGiris()
        {
            InitializeComponent();
        }
        Baglanti bgl = new Baglanti();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from TblOgrenciIsleri where KullanıciAd=@p1 and Sifre=@p2", bgl.baglan());
            command.Parameters.AddWithValue("@p1", textBox1.Text);
            command.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                FrmOgretmenDetay frm = new FrmOgretmenDetay();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış şifre veya Kullanıcı Adı.");
            }
        }
    }
}
