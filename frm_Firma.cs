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
    public partial class frm_Firma : Form
    {
        public frm_Firma()
        {
            InitializeComponent();
        }

        private void btn_yenikayit_Click(object sender, EventArgs e)
        {
            frm_FirmaYeniKayit ac = new frm_FirmaYeniKayit();
            ac.ShowDialog();       
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            Sil();
            FirmaGridDoldur();
        }

         private void Sil()
        {
            DialogResult dugmesec;
            dugmesec = MessageBox.Show(this, "Firma kartını silmek istediğinizden eminmisiniz?", "Onay Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dugmesec == DialogResult.Yes)
            {
                String VerileriSil = "DELETE FROM TBL_FIRMA WHERE F_ID=@F_ID";
                SqlCommand cmd = new SqlCommand(VerileriSil, Connection.baglantim);
                cmd.Parameters.AddWithValue("@F_ID", firmaid).SqlDbType = SqlDbType.Int;
                try
                {
                    Connection.baglantim.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Firma Kartı veri tabanından başarıyla silinmiştir.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    FirmaGridDoldur();
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

         private void frm_Firma_Load(object sender, EventArgs e)
         {
             FirmaGridDoldur();
             Combolar_Doldu();
         }

         private void FirmaGridDoldur()
         {
             SqlDataAdapter verigetir = new SqlDataAdapter("SELECT F_ID AS 'MÜSTERI NO',F_GRUP AS GRUP,F_KODU AS 'FIRMA KODU',F_ACIKADI AS 'FIRMA ACIK ADI',F_TEL1 AS TEL1,F_TEL2 AS TEL2,F_FAKS AS FAKS,F_ILGILIKISI AS 'ILGILI KISI',F_DURUM AS DURUM FROM TBL_FIRMA ORDER BY F_KODU", Connection.baglantim);
             DataSet al = new DataSet();
             verigetir.Fill(al, "TBL_FIRMA");
             dgw_firma.DataSource = al.Tables[0];
             dgw_firma.Columns[0].Width = 100;
             dgw_firma.Columns[1].Width = 90;
             dgw_firma.Columns[2].Width = 200;
             dgw_firma.Columns[3].Width = 300;
             dgw_firma.Columns[4].Width = 150;
             dgw_firma.Columns[5].Width = 150;
             dgw_firma.Columns[6].Width = 150;
             dgw_firma.Columns[7].Width = 150;
             dgw_firma.Columns[8].Width = 150;
         }

         public static int firmaid;
         private void dgw_firma_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
         {
             firmaid = int.Parse(dgw_firma.Rows[e.RowIndex].Cells[0].Value.ToString());
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
             ComboBox[] ComboBoxlarim = new ComboBox[2] {cb_kullanici, cb_firmadurumu};

             String[] Sorgularim = new string[2] {"SELECT K_KULLANICIADI FROM TBL_KULLANICI ORDER BY K_KULLANICIADI",
            "SELECT FD_DEGER FROM TBL_FIRMADURUM ORDER BY FD_DEGER"};

             String[] TabloAdlarim = new string[2] {"TBL_KULLANICI",
            "TBL_FIRMADURUM"};

             String[] KolonAdlarim = new string[2] {"K_KULLANICIADI",
            "FD_DEGER"};

             for (int index = 0; index < 2; index++)
                 Combolari_Doldur(ComboBoxlarim[index], Sorgularim[index], TabloAdlarim[index], KolonAdlarim[index]);

         }

         private void dgw_firma_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
         {
             frm_FirmaGoruntu ac = new frm_FirmaGoruntu();
             ac.ShowDialog();
         }

         private void btn_duzenle_Click(object sender, EventArgs e)
         {
             frm_FirmaDuzenle ac = new frm_FirmaDuzenle();
             ac.ShowDialog();
         }

         private void btn_goruntule_Click(object sender, EventArgs e)
         {
             frm_FirmaGoruntu ac = new frm_FirmaGoruntu();
             ac.ShowDialog();
         }

         private void btn_ekraniguncelle_Click(object sender, EventArgs e)
         {
             FirmaGridDoldur();
         }

         private void tekliflerToolStripMenuItem_Click(object sender, EventArgs e)
         {
             frm_Teklif ac = new frm_Teklif();
             ac.Show();
             this.Hide();
         }

         private void firmaKartlarıToolStripMenuItem_Click(object sender, EventArgs e)
         {

         }

         private void siparişlerToolStripMenuItem_Click(object sender, EventArgs e)
         {
             frm_Siparis ac = new frm_Siparis();
             ac.Show();
             this.Hide();
         }

         private void raporlarToolStripMenuItem_Click(object sender, EventArgs e)
         {

         }

         private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
         {
             System.Windows.Forms.Application.Exit();
         }

         private void frm_ara_Click(object sender, EventArgs e)
         {
             SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM TBL_FIRMA WHERE F_KODU LIKE '" + txt_ara.Text + "'", Connection.baglantim);
             DataSet al = new DataSet();
             sda.Fill(al, "TBL_FIRMA");
             dgw_firma.DataSource = al.Tables[0];
         }

         private void btn_liste_Click(object sender, EventArgs e)
         {
             frm_Firmaliste ac = new frm_Firmaliste();
             ac.ShowDialog();
         }
    }
}
