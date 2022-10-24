using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelTakip
{
    public partial class FrmMaasListesi : Form
    {
        public FrmMaasListesi()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtYil_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtMaas_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbAylar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmMaasBilgisi frm = new FrmMaasBilgisi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            FrmMaasBilgisi frm = new FrmMaasBilgisi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
