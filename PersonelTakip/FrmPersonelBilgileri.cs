﻿using BLL;
using DAL;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PersonelTakip
{
    public partial class FrmPersonelBilgileri : Form
    {
        public FrmPersonelBilgileri()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        PersonelDTO dto = new PersonelDTO();

        private void FrmPersonelBilgileri_Load(object sender, EventArgs e)
        {
            dto = PersonelBLL.GetAll();
            cmbDepartman.DataSource = dto.Departmanlar;
            cmbDepartman.DisplayMember = "DepartmanAd";
            cmbDepartman.ValueMember = "ID";
            cmbDepartman.SelectedIndex = -1;

            cmbPozisyon.DataSource = dto.Pozisyonlar;
            cmbPozisyon.DisplayMember = "PozisyonAd";
            cmbPozisyon.ValueMember = "ID";
            cmbPozisyon.SelectedIndex = -1;

            if (dto.Departmanlar.Count > 0)
                combofull = true;



        }

        bool combofull = false;
        string resimad = "";

        private void cmbDepartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                int departmanID = Convert.ToInt32(cmbDepartman.SelectedValue);
                cmbPozisyon.DataSource = dto.Pozisyonlar.Where(x => x.DepartmanID == departmanID).ToList();
            }
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                txtResim.Text = openFileDialog1.FileName;
                resimad = Guid.NewGuid().ToString();
                resimad += openFileDialog1.SafeFileName;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
                MessageBox.Show("User No");

            else if (PersonelBLL.isUnique(Convert.ToInt32(txtUserNo.Text)))
            {
                MessageBox.Show("Bu User No kullanılabilir");
            }

            else if (txtUserNo.Text.Trim() == "")
                MessageBox.Show("User No");
            else if (txtAd.Text.Trim() == "")
                MessageBox.Show("Ad");
            else if (txtSoyad.Text.Trim() == "")
                MessageBox.Show("Soyad");
            else if (txtMaas.Text.Trim() == "")
                MessageBox.Show("Maaş");
            else if (txtPassword.Text.Trim() == "")
                MessageBox.Show("Şifre");
            else if (txtResim.Text.Trim() == "")
                MessageBox.Show("Resim");
            else if (cmbDepartman.SelectedIndex == -1)
                MessageBox.Show("Departman");
            else if (cmbPozisyon.SelectedIndex == -1)
                MessageBox.Show("Departman");
            else
            {
                PERSONEL pr = new PERSONEL();
                pr.UserNo = Convert.ToInt32(txtUserNo.Text);
                pr.Ad = txtAd.Text;
                pr.Soyad = txtSoyad.Text;
                pr.Maas = Convert.ToInt32(txtMaas.Text);
                pr.IsAdmin = chisAdmin.Checked;
                pr.Password = txtPassword.Text;
                pr.PozisyonID = Convert.ToInt32(cmbPozisyon.SelectedValue);
                pr.DepartmanID = Convert.ToInt32(cmbDepartman.SelectedValue);
                pr.DogumGunu = dateTimePicker1.Value;
                pr.Adres = txtAdres.Text;
                pr.Resim = resimad;
                PersonelBLL.PersonelEkle(pr);
                File.Copy(txtResim.Text, @"resimler\\" + resimad);
                MessageBox.Show("Personel Eklendi");
                txtUserNo.Clear();
                txtAd.Clear();
                txtSoyad.Clear();
                txtMaas.Clear();
                chisAdmin.Checked = false;
                txtPassword.Clear();
                cmbDepartman.SelectedIndex = -1;
                cmbPozisyon.DataSource = dto.Pozisyonlar;
                cmbPozisyon.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Today;
                txtAdres.Clear();
                txtResim.Clear();
                resimad = "";

            }
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
                MessageBox.Show("User No Boş");
            else if (PersonelBLL.isUnique(Convert.ToInt32(txtUserNo.Text)))
            {
                MessageBox.Show("User No kullanılmaktadır, Lütfen User No değiştirin");
            }
            else
            {
                MessageBox.Show("Bu User No kullanılabilir");
            }
        }
    }
}
