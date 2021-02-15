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
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }
        Baglanti bgl = new Baglanti();
        public void Liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TblOgrenciBilgi", bgl.baglan());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            Liste();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand command = new SqlCommand("insert into TblOgrenciBilgi (no,Sifre,Ad,Soyad) values (@p1,@p2,@p3,@p4)", bgl.baglan());
                command.Parameters.AddWithValue("@p1", txtNumara.Text);
                command.Parameters.AddWithValue("@p2", txtSifre.Text);
                command.Parameters.AddWithValue("@p3", txtAd.Text);
                command.Parameters.AddWithValue("@p4", txtSoyadı.Text);
                command.ExecuteNonQuery();
                bgl.baglan().Close();
                MessageBox.Show("Öğrenci Eklendi");
                Liste();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen tüm değerleri Doğru Ve boş bırakmadan giriniz");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int select = dataGridView1.SelectedCells[0].RowIndex;
            txtNumara.Text = dataGridView1.Rows[select].Cells[0].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[select].Cells[1].Value.ToString();
            txtvize.Text = dataGridView1.Rows[select].Cells[2].Value.ToString();
            txtfinal.Text = dataGridView1.Rows[select].Cells[3].Value.ToString();
            txtbüt.Text = dataGridView1.Rows[select].Cells[4].Value.ToString();
            lblOrtalama.Text = dataGridView1.Rows[select].Cells[5].Value.ToString();
            lblHarfNotu.Text = dataGridView1.Rows[select].Cells[6].Value.ToString();
            lblDurum.Text = dataGridView1.Rows[select].Cells[7].Value.ToString();
            txtAd.Text = dataGridView1.Rows[select].Cells[8].Value.ToString();
            txtSoyadı.Text = dataGridView1.Rows[select].Cells[9].Value.ToString();
        }
        int ortalama, vize = 0, final = 0, büt = 0;

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TblOgrenciBilgi where Ad  like '%"+ textBox4.Text  + "%' or no like  '%" + textBox4.Text + "%' " , bgl.baglan());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtfinal.Text=="")
            {
                 SqlCommand command3 = new SqlCommand("Update TblOgrenciBilgi set vize = @p1 where NO = @p7", bgl.baglan());
            command3.Parameters.AddWithValue("@p1", txtvize.Text);                   
            command3.Parameters.AddWithValue("@p7", txtNumara.Text);
            command3.ExecuteNonQuery();
            MessageBox.Show("Güncellendi");
            Liste();
            }
            else if (txtbüt.Text == "")
            {
                SqlCommand command = new SqlCommand("Update TblOgrenciBilgi set vize = @p1,final = @p2,Ortalama = @p4,HarfNotu = @p5,Durum = @p6 where NO = @p7", bgl.baglan());
                command.Parameters.AddWithValue("@p1", txtvize.Text);
                command.Parameters.AddWithValue("@p2", txtfinal.Text);
                command.Parameters.AddWithValue("@p4", lblOrtalama.Text);
                command.Parameters.AddWithValue("@p5", lblHarfNotu.Text);
                command.Parameters.AddWithValue("@p6", lblDurum.Text);
                command.Parameters.AddWithValue("@p7", txtNumara.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Güncellendi");
                Liste();
            }
            else
            {
                SqlCommand command2 = new SqlCommand("Update TblOgrenciBilgi set vize = @p1,final = @p2,But = @p3,Ortalama = @p4,HarfNotu = @p5,Durum = @p6 where NO = @p7", bgl.baglan());
                command2.Parameters.AddWithValue("@p1", txtvize.Text);
                command2.Parameters.AddWithValue("@p2", txtfinal.Text);
                command2.Parameters.AddWithValue("@p3", txtbüt.Text);
                command2.Parameters.AddWithValue("@p4", lblOrtalama.Text);
                command2.Parameters.AddWithValue("@p5", lblHarfNotu.Text);
                command2.Parameters.AddWithValue("@p6", lblDurum.Text);
                command2.Parameters.AddWithValue("@p7", txtNumara.Text);
                command2.ExecuteNonQuery();
                MessageBox.Show("Güncellendi");
                Liste();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtfinal.Text=="")
            {
                vize = Convert.ToInt32(txtvize.Text);
                ortalama = vize;
                lblOrtalama.Text = ortalama.ToString();
            }
            else if (txtbüt.Text == "" )
            {
                vize = Convert.ToInt32(txtvize.Text);
                final = Convert.ToInt32(txtfinal.Text);
                ortalama = (vize+final)/2;
                lblOrtalama.Text = ortalama.ToString();
            }
            else
            {
                vize = Convert.ToInt32(txtvize.Text);
                final = Convert.ToInt32(txtfinal.Text);
                büt = Convert.ToInt32(txtbüt.Text);
                ortalama = (vize + final + büt) / 3;
                lblOrtalama.Text = ortalama.ToString();
            }

            if (ortalama<=100 && ortalama>=85)
            {
                lblHarfNotu.Text = "AA";
                lblDurum.Text = "Geçti";
            }
            else if (ortalama<=84.99 && ortalama>=70)
            {
                lblHarfNotu.Text = "BB";
                lblDurum.Text = "Geçti";
            }
            else if (ortalama <= 69.99 && ortalama >=50)
            {
                lblHarfNotu.Text = "CC";
                lblDurum.Text = "Geçti";
            }
            else if (ortalama <= 49.99 && ortalama >=30)
            {
                 lblHarfNotu.Text = "DC";
                lblDurum.Text = "Belirsiz";
            }
            else
            {
                lblHarfNotu.Text = "FD";
                lblDurum.Text = "Kaldı";
            }

        }
    }
}
