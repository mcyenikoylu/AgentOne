using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace agentone
{
    public partial class frm_Anasayfa : Form
    {
        public frm_Anasayfa()
        {
            InitializeComponent();
        }

        private void tekliflerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Teklif ac = new frm_Teklif();
            ac.Show();
            this.Close();
        }

        private void firmaKartlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Firma ac = new frm_Firma();
            ac.Show();
            this.Hide();
        }

        private void siparişlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Siparis ac = new frm_Siparis();
            ac.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DialogResult cikis = MessageBox.Show("Programdan cikmak istediginden emin misin ?", "Onay Mesaji", MessageBoxButtons.YesNo);
            //if (cikis == DialogResult.Yes)
            //    Application.Exit();
            //else if (cikis == DialogResult.No)
            //{ }
            System.Windows.Forms.Application.Exit();
        }

        private void frm_Anasayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult cikis = MessageBox.Show("Programdan cikmak istediginden emin misin ?", "Onay Mesaji", MessageBoxButtons.YesNo);
            //if (cikis == DialogResult.Yes)
            //    Application.Exit();
            //else if (cikis == DialogResult.No)
            //    e.Cancel = true;
        }
    }
}
