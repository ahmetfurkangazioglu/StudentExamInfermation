﻿using System;
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
    public partial class FrnOgrenciDetay : Form
    {
        public FrnOgrenciDetay()
        {
            InitializeComponent();
        }
        
        Baglanti bgl = new Baglanti();
       public string no;

        public void OrtalamaGetirme()
        {
            SqlCommand command = new SqlCommand("select  avg(Vize) from TblOgrenciBilgi where vize >0", bgl.baglan());
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                lblvizeortalama.Text = dr[0].ToString();

            }
            bgl.baglan().Close();

            SqlCommand command1 = new SqlCommand("select  avg(Final) from TblOgrenciBilgi where Final >0", bgl.baglan());
            SqlDataReader dr1 = command1.ExecuteReader();
            while (dr1.Read())
            {
                lblfinalortalama.Text = dr1[0].ToString();

            }
            bgl.baglan().Close();

            SqlCommand command2 = new SqlCommand("select  avg(But) from TblOgrenciBilgi where But >0", bgl.baglan());
            SqlDataReader dr2 = command2.ExecuteReader();
            while (dr2.Read())
            {
                lblbutortalama.Text = dr2[0].ToString();

            }
            bgl.baglan().Close();
        }

        private void FrnOgrenciDetay_Load(object sender, EventArgs e)
        {
            lblNo.Text = no;
            SqlCommand command = new SqlCommand("select * from TblOgrenciBilgi where NO=@p1", bgl.baglan());
            command.Parameters.AddWithValue("@p1", no);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                lblAd.Text = dr[8].ToString();
                lblSoyad.Text = dr[9].ToString();
                lblvize.Text = dr[2].ToString();
                lblfinal.Text = dr[3].ToString();
                lblbut.Text = dr[4].ToString();
                lblortalama.Text = dr[5].ToString();               
                lblharfnotu.Text = dr[6].ToString();
                lbldurum.Text = dr[7].ToString();             
            }
            bgl.baglan().Close();

            if (Convert.ToDouble(lblortalama.Text) <= 49)
            {
                lblbut.Visible = true;
                label6.Visible = true;
                lblbutortalama.Visible = true;
                label14.Visible = true;
            }
            OrtalamaGetirme();
            /*Büt yeri ortlama yüksek oldugunda kapanıyor ve ogrenci goremiyor veri tabanına büt acık-kapalı verisi ekle ve ortalama yuksek oldugunda acılan but kapanmamalı. */
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label7.Visible = true;
            label8.Visible = true;
            button1.Visible = true;
            txtEskiSifre.Visible = true;
            txtYeniSifre.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Update TblOgrenciBilgi set Sifre=@p1 where sifre=@p2", bgl.baglan());
            command.Parameters.AddWithValue("@p1", txtYeniSifre.Text);
            command.Parameters.AddWithValue("@p2", txtEskiSifre.Text);
            command.ExecuteNonQuery();
            bgl.baglan().Close();
            MessageBox.Show("Şifreniz Güncellendi. Yeni Şifreniz:", txtYeniSifre.Text);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
