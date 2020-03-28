using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace agentone
{
    public partial class frm_Teklif : Form
    {
        public frm_Teklif()
        {
            InitializeComponent();
        }

        private void btn_yenikayit_Click(object sender, EventArgs e)
        {
            frm_TeklifYeniKayit ac = new frm_TeklifYeniKayit();
            ac.ShowDialog();
        }

        private void frm_Teklif_Load(object sender, EventArgs e)
        {
            TeklifSayfasindanSipariseDonusturuldu = 0;
            Combolar_Doldu();
            TeklifGridDoldur();
        }

        private void Combolari_Doldur(ComboBox combobox, String Sorgum, String Tablom, String KolonAdim)
        {
            combobox.Text = "Seçiniz";
            combobox.Items.Add("Seçiniz");

            SqlDataAdapter sqlvericek = new SqlDataAdapter(Sorgum, Connection.baglantim);
            DataSet veri_al = new DataSet();
            sqlvericek.Fill(veri_al, Tablom);
            DataTable veri_masa = veri_al.Tables[Tablom];
            foreach (DataRow veri_dizi in veri_masa.Rows)
            {
                combobox.Items.Add(veri_dizi[KolonAdim]);
            }
        }

        private void Combolar_Doldu()
        {
            //comboboxları dolduruyorum.
            ComboBox[] ComboBoxlarim = new ComboBox[2] { cb_kullanici, cb_teklifdurumu };

            String[] Sorgularim = new string[2] {"SELECT K_KULLANICIADI FROM TBL_KULLANICI ORDER BY K_KULLANICIADI",
            "SELECT TD_DEGER FROM TBL_TEKLIFDURUM ORDER BY TD_DEGER"};

            String[] TabloAdlarim = new string[2] {"TBL_KULLANICI",
            "TBL_TEKLIFDURUM"};

            String[] KolonAdlarim = new string[2] {"K_KULLANICIADI",
            "TD_DEGER"};

            for (int index = 0; index < 2; index++)
                Combolari_Doldur(ComboBoxlarim[index], Sorgularim[index], TabloAdlarim[index], KolonAdlarim[index]);

        }

        private void cb_kullanici_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_teklifdurumu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TeklifGridDoldur()
        {
            SqlDataAdapter verigetir = new SqlDataAdapter("SELECT T_ID AS 'TEKLIF NO',T_IMALATCIFIRMA AS IMALATCI,T_IHRACATCIFIRMA AS IHRACATCI,T_ALICISIRKET AS ALICI,T_URUNADI AS URUN,T_KALITE AS KALITE,T_KAYITTARIHI AS TARIH,T_KULLANICIADI AS KULLANICI,T_TEKLIFDURUMU AS DURUM FROM TBL_TEKLIF ORDER BY T_KAYITTARIHI", Connection.baglantim);
            DataSet al = new DataSet();
            verigetir.Fill(al, "TBL_TEKLIF");
            dgw_teklif.DataSource = al.Tables[0];
            dgw_teklif.CurrentCell = null;
            dgw_teklif.Columns[0].Width = 100;
            dgw_teklif.Columns[1].Width = 150;
            dgw_teklif.Columns[2].Width = 150;
            dgw_teklif.Columns[3].Width = 150;
            dgw_teklif.Columns[4].Width = 300;
            dgw_teklif.Columns[5].Width = 150;
            dgw_teklif.Columns[6].Width = 150;
            dgw_teklif.Columns[7].Width = 150;
            dgw_teklif.Columns[8].Width = 150;
        }

        public static int TeklifSayfasindanSipariseDonusturuldu = 0;
        private void btn_siparisedonustur_Click(object sender, EventArgs e)
        {
            TeklifSayfasindanSipariseDonusturuldu = 1;
            frm_SiparisYeniKayit ac = new frm_SiparisYeniKayit();
            ac.ShowDialog();
        }

        public static int teklifid;
        private void dgw_teklif_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            teklifid = int.Parse(dgw_teklif.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void btn_goruntule_Click(object sender, EventArgs e)
        {
            frm_TeklifGoruntu ac = new frm_TeklifGoruntu();
            ac.ShowDialog();
        }

        private void btn_duzenle_Click(object sender, EventArgs e)
        {
            frm_TeklifDuzenle ac = new frm_TeklifDuzenle();
            ac.ShowDialog();
        }

        private void siparişlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Siparis ac = new frm_Siparis();
            ac.Show();
            this.Hide();
        }

        private void tekliflerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void firmaKartlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Firma ac = new frm_Firma();
            ac.Show();
            this.Hide();
        }

        private void raporlarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            DialogResult dugmesec;
            dugmesec = MessageBox.Show(this, "Teklif kartını silmek istediğinizden eminmisiniz?", "Onay Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dugmesec == DialogResult.Yes)
            {
                String VerileriSil = "DELETE FROM TBL_TEKLIF WHERE T_ID=@T_ID";
                SqlCommand cmd = new SqlCommand(VerileriSil, Connection.baglantim);
                cmd.Parameters.AddWithValue("@T_ID", teklifid).SqlDbType = SqlDbType.Int;
                try
                {
                    Connection.baglantim.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Teklif Kartı veri tabanından başarıyla silinmiştir.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    TeklifGridDoldur();
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

        private void btn_teklifiyazdir_Click(object sender, EventArgs e)
        {
            //Teklif Raporu
            frm_TeklifRaporu ac = new frm_TeklifRaporu();
            ac.ShowDialog();
        }

        private void btn_liste_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgw_teklif_DoubleClick(object sender, EventArgs e)
        {
            //teklifid = int.Parse(dgw_teklif.Rows[e.RowIndex].Cells[0].Value.ToString());
            frm_TeklifGoruntu ac = new frm_TeklifGoruntu();
            ac.ShowDialog();
        }

        private void btn_ekraniguncelle_Click(object sender, EventArgs e)
        {
            TeklifGridDoldur();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM TBL_TEKLIF WHERE T_ID LIKE '" + txt_ara.Text + "'", Connection.baglantim);
            DataSet al = new DataSet();
            sda.Fill(al, "TBL_TEKLIF");
            dgw_teklif.DataSource = al.Tables[0];
        }

        private void btn_ekraniguncelle_Click_1(object sender, EventArgs e)
        {
            TeklifGridDoldur();
        }
    }
}
