﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace PersonelTakip
{
    public partial class FrmDepartmanListesi : Form
    {
        public FrmDepartmanListesi()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmDepartmanBilgileri frm = new FrmDepartmanBilgileri();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            liste = DepartmanBLL.DepartmanGetir();
            dataGridView1.DataSource = liste;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            FrmDepartmanBilgileri frm = new FrmDepartmanBilgileri();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        List<DEPARTMAN> liste = new List<DEPARTMAN>();

        private void FrmDepartmanListesi_Load(object sender, EventArgs e)
        {
            liste = DepartmanBLL.DepartmanGetir();
            dataGridView1.DataSource = liste;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Departman Adı";
        }
    }
}
