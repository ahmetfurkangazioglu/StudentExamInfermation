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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Baglanti bgl = new Baglanti();       
        //SqlConnection baglan1 = new SqlConnection(@"Data Source=DESKTOP-GME4UDL\;Initial Catalog=DbOgrenciSınav;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            SekreterGiris frm = new SekreterGiris();
            frm.Show();
            this.Hide();
        }    
        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand commend = new SqlCommand("select  * from TblOgrenciBilgi where NO=@p1 and Sifre=@p2", bgl.baglan());
                         
                commend.Parameters.AddWithValue("@p1", textBox1.Text);
                commend.Parameters.AddWithValue("@p2", textBox2.Text);
                SqlDataReader dr = commend.ExecuteReader();
                if(dr.Read())
                {
                    FrnOgrenciDetay frm = new FrnOgrenciDetay();
                frm.no = textBox1.Text;
                    frm.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Numaranız veya Şifreniz yanlış. Lütfen tekrar deneyiniz","Infermation",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                    bgl.baglan().Close();
            
          
        }
    }
}
