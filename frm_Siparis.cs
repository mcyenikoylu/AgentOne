using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace agentone
{
    public partial class frm_Siparis : Form
    {
        public frm_Siparis()
        {
            InitializeComponent();
        }

        private void firmaKartlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Firma ac = new frm_Firma();
            ac.Show();
            this.Hide();
        }

        private void tekliflerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Teklif ac = new frm_Teklif();
            ac.Show();
            this.Hide();
        }

        private void siparişlerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void raporlarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_yenikayit_Click(object sender, EventArgs e)
        {
            frm_SiparisYeniKayit ac = new frm_SiparisYeniKayit();
            ac.ShowDialog();
        }

        private void btn_duzenle_Click(object sender, EventArgs e)
        {
            frm_SiparisDuzenle ac = new frm_SiparisDuzenle();
            ac.ShowDialog();
        }

        private void btn_goruntule_Click(object sender, EventArgs e)
        {
            frm_SiparisGoruntu ac = new frm_SiparisGoruntu();
            ac.ShowDialog();
        }

        private void SiparisGridDoldur()
        {
            SqlDataAdapter verigetir = new SqlDataAdapter("SELECT S_ID AS 'SIPARIS NO', S_ALICIFIRMA AS 'ALICI FIRMA',S_IMALATCIFIRMA AS 'IMALATCI FIRMA',S_IHRACATCIFIRMA AS 'IHRACATCI FIRMA',S_URUNADI AS 'URUN ADI',S_KAYITTARIHI AS 'KAYIT TARIHI',S_KULLANICIADI AS KULLANICI,S_SIPARISDURUMU AS DURUM FROM TBL_SIPARIS ORDER BY S_KAYITTARIHI", Connection.baglantim);
            DataSet al = new DataSet();
            verigetir.Fill(al, "TBL_SIPARIS");
            dgw_siparis.DataSource = al.Tables[0];
            dgw_siparis.CurrentCell = null;
            dgw_siparis.Columns[0].Width = 100;
            dgw_siparis.Columns[1].Width = 150;
            dgw_siparis.Columns[2].Width = 150;
            dgw_siparis.Columns[3].Width = 150;
            dgw_siparis.Columns[4].Width = 310;
            dgw_siparis.Columns[5].Width = 150;
            dgw_siparis.Columns[6].Width = 150;
            dgw_siparis.Columns[7].Width = 150;
        }

        private void frm_Siparis_Load(object sender, EventArgs e)
        {
            SiparisGridDoldur();
        }

        public static int siparisid;
        private void dgw_siparis_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            siparisid = int.Parse(dgw_siparis.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void dgw_siparis_DoubleClick(object sender, EventArgs e)
        {
            frm_SiparisGoruntu ac = new frm_SiparisGoruntu();
            ac.ShowDialog();
        }

        private void btn_ekraniguncelle_Click(object sender, EventArgs e)
        {
            SiparisGridDoldur();
        }

        private void DegiskenleriBosalt()
        {
            frm_Teklif.TeklifSayfasindanSipariseDonusturuldu = 0;
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DegiskenleriBosalt();
            System.Windows.Forms.Application.Exit();
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM TBL_SIPARIS WHERE S_ID LIKE '" + txt_ara.Text + "'", Connection.baglantim);
            DataSet al = new DataSet();
            sda.Fill(al, "TBL_SIPARIS");
            dgw_siparis.DataSource = al.Tables[0];
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            Sil();
            SiparisGridDoldur();
        }

        private void Sil()
        {
            DialogResult dugmesec;
            dugmesec = MessageBox.Show(this, "Sipariş Kartını silmek istediğinizden eminmisiniz?", "Onay Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dugmesec == DialogResult.Yes)
            {
                String VerileriSil = "DELETE FROM TBL_SIPARIS WHERE S_ID=@S_ID";
                SqlCommand cmd = new SqlCommand(VerileriSil, Connection.baglantim);
                cmd.Parameters.AddWithValue("@S_ID", siparisid).SqlDbType = SqlDbType.Int;
                try
                {
                    Connection.baglantim.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Sipariş Kartı veri tabanından başarıyla silinmiştir.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch
                {
                    MessageBox.Show(this, "Veri tabnına bağlanılırken bir hata oluştu.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Connection.baglantim.Close();
                }
            }
            else if (dugmesec == DialogResult.No)
            {
                MessageBox.Show(this, "Silme işlemini iptal ettiniz.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void btn_siparisiyazdir_Click(object sender, EventArgs e)
        {
            frm_SiparisRaporu ac = new frm_SiparisRaporu();
            ac.ShowDialog();
        }

        private void btn_teklifiyazdir_Click(object sender, EventArgs e)
        {
            //teklif IDsini alıp yeni bir rapor sayfasında yazdırmalısın.

        }

        private void frm_Siparis_FormClosing(object sender, FormClosingEventArgs e)
        {
            DegiskenleriBosalt();
        }
    }
}
