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
    public partial class frm_SiparisYeniKayit : Form
    {
        public frm_SiparisYeniKayit()
        {
            InitializeComponent();
        }

        private void frm_SiparisYeniKayit_Load(object sender, EventArgs e)
        {
            //txt_toplam.SelectionStart = txt_toplam.Text.Length;
            Combolar_Doldu();
            ParaAlanlarınaSıfırDoldur();
            if (frm_Teklif.TeklifSayfasindanSipariseDonusturuldu == 1)
            {
                TeklifAlanlariniGetir();
                Resim1Doldur();
                Resim2Doldur();
            }
        }

        private void Resim1Doldur()
        {
            SqlDataAdapter Da;
            DataTable Dt;
            Da = new SqlDataAdapter("SELECT * FROM TBL_TEKLIF WHERE T_ID='" + frm_Teklif.teklifid + "'", Connection.baglantim);
            Dt = new DataTable();
            Da.Fill(Dt);

            Binding bdResim = new Binding("Image", Dt, "T_RESIM1");
            bdResim.Format += new ConvertEventHandler(ResimFormat);
            pb_resim1.DataBindings.Add(bdResim);
        }

        private void Resim2Doldur()
        {
            SqlDataAdapter Da;
            DataTable Dt;
            Da = new SqlDataAdapter("SELECT * FROM TBL_TEKLIF WHERE T_ID='" + frm_Teklif.teklifid + "'", Connection.baglantim);
            Dt = new DataTable();
            Da.Fill(Dt);

            Binding bdResim = new Binding("Image", Dt, "T_RESIM2");
            bdResim.Format += new ConvertEventHandler(ResimFormat);
            pb_resim2.DataBindings.Add(bdResim);
        }

        private void ResimFormat(object sender, ConvertEventArgs e)
        {
            // e.Value DB den gelen orjinal value
            try
            {
                Byte[] img = (Byte[])e.Value;
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ms.Write(img, 0, img.Length);
                Bitmap bmp = new Bitmap(ms);
                ms.Close();
                e.Value = bmp;
            }
            catch
            {
                /* Eğer database e resim kaydedilmemiş ise boş bir resim oluşturup value olarak gönderiyoruz. Eğer yapmazsak program hata verecektir
                */
                Bitmap b = new Bitmap(10, 10);
                e.Value = b;
            }

        }

        private void TeklifAlanlariniGetir()
        {
            String vericek = "SELECT * FROM TBL_TEKLIF WHERE T_ID='" + frm_Teklif.teklifid + "'";
            SqlCommand comm = new SqlCommand(vericek, Connection.baglantim);
            comm.Parameters.AddWithValue("@T_ID", frm_Teklif.teklifid).SqlDbType = SqlDbType.Int;
            comm.Parameters.AddWithValue("@T_IMALATCIFIRMA", txt_imalatcifirma.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_IHRACATCIFIRMA", txt_ithalatcifirma.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_ALICISIRKET", txt_alicifirma.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_URUNADI", txt_urunadi.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_KALITE", txt_kalite.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_ACIKLAMA", rtb_aciklama.Text).SqlDbType = SqlDbType.NVarChar;       
            comm.Parameters.AddWithValue("@T_YUKLEMESEKLI", cb_yuklemesekli.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_ODEMESEKLI", cb_odemesekli.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_MIKTAR", txt_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_MIKTAROLCUBIRIMI", cb_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_BIRIMFIYAT", txt_sonfiyat.Text).SqlDbType = SqlDbType.NVarChar;//son fiyat denilen değerin sonradan ismi değişti ve son birim fiyatı oldu.
            comm.Parameters.AddWithValue("@T_BIRIMFIYATPARABIRIMI", cb_sonfiyat.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_ALIMFIYATI", txt_alisfiyati.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_ALIMFIYATBIRIMI", cb_alisfiyatibirimi.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_URUNDURUMU", cb_urundurumu.Text).SqlDbType = SqlDbType.NVarChar;
            
            Connection.baglantim.Open();
            SqlDataReader verioku = comm.ExecuteReader();
            try
            {
                while (verioku.Read())
                {
                    txt_teklifid.Text = verioku["T_ID"].ToString();
                    txt_imalatcifirma.Text = verioku["T_IMALATCIFIRMA"].ToString();
                    txt_ithalatcifirma.Text = verioku["T_IHRACATCIFIRMA"].ToString();
                    txt_alicifirma.Text = verioku["T_ALICISIRKET"].ToString();
                    txt_urunadi.Text = verioku["T_URUNADI"].ToString();
                    txt_kalite.Text = verioku["T_KALITE"].ToString();
                    rtb_aciklama.Text = verioku["T_ACIKLAMA"].ToString();
                    cb_yuklemesekli.Text = verioku["T_YUKLEMESEKLI"].ToString();
                    cb_odemesekli.Text = verioku["T_ODEMESEKLI"].ToString();
                    txt_miktar.Text = verioku["T_MIKTAR"].ToString();
                    cb_miktar.Text = verioku["T_MIKTAROLCUBIRIMI"].ToString();
                    txt_sonfiyat.Text = verioku["T_BIRIMFIYAT"].ToString();//son fiyat denilen değerin sonradan ismi değişti ve satış birim fiyatı oldu.
                    cb_sonfiyat.Text = verioku["T_BIRIMFIYATPARABIRIMI"].ToString();
                    txt_alisfiyati.Text = verioku["T_ALIMFIYATI"].ToString();
                    cb_alisfiyatibirimi.Text = verioku["T_ALIMFIYATBIRIMI"].ToString();
                    cb_urundurumu.Text = verioku["T_URUNDURUMU"].ToString();
                }
            }
            finally
            {
                verioku.Close();
                Connection.baglantim.Close();
            }
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
            ComboBox[] ComboBoxlarim = new ComboBox[8] { cb_etiket, cb_miktar, cb_odemesekli, cb_sonfiyat, cb_yuklemesekli, cb_siparisdurumu, cb_alisfiyatibirimi, cb_urundurumu };

            String[] Sorgularim = new string[8] {"SELECT E_DEGER FROM TBL_ETIKET ORDER BY E_DEGER",
            "SELECT MB_DEGER FROM TBL_MIKTARBIRIMI ORDER BY MB_DEGER",
            "SELECT OS_DEGER FROM TBL_ODEMESEKLI ORDER BY OS_DEGER",
            "SELECT PB_DEGER FROM TBL_PARABIRIMI ORDER BY PB_DEGER",
            "SELECT YS_DEGER FROM TBL_YUKLEMESEKLI ORDER BY YS_DEGER",
            "SELECT SD_DEGER FROM TBL_SIPARISDURUM ORDER BY SD_DEGER",
            "SELECT PB_DEGER FROM TBL_PARABIRIMI ORDER BY PB_DEGER",
            "SELECT UD_DEGER FROM TBL_URUNDURUM ORDER BY UD_DEGER"};
            
            String[] TabloAdlarim = new string[8] {"TBL_ETIKET",
            "TBL_MIKTARBIRIMI",
            "TBL_ODEMESEKLI",
            "TBL_PARABIRIMI",
            "TBL_YUKLEMESEKLI",
            "TBL_SIPARISDURUM",
            "TBL_PARABIRIMI",
            "TBL_URUNDURUM"};

            String[] KolonAdlarim = new string[8] {"E_DEGER",
            "MB_DEGER",
            "OS_DEGER",
            "PB_DEGER",
            "YS_DEGER",
            "SD_DEGER",
            "PB_DEGER",
            "UD_DEGER"};

            for (int index = 0; index < 8; index++)
                Combolari_Doldur(ComboBoxlarim[index], Sorgularim[index], TabloAdlarim[index], KolonAdlarim[index]);

        }

        public static int FirmaSecerkenHangiButtonaBasti = 0;
        /// <summary>
        ///firma seçerken hangi buttona bastığını kontrol eden değişken.
        ///frm_FirmaKartiSec sayfasından firma seçilirken imalatci firma mı, ithalatci firmamı yoksa alıcı firmamı seçmek istediğini bu değişken ile kontrol ediyorum
        ///eğer imalatci firma seçmek istiyorsa 1
        ///eğer ithalatci firma seçmek istiyorsa 2
        ///eğer alıcı firma seçmek istiyorsa 3 veriyorum ve bunu da frm_FirmaKartiSec sayfasında sorgulatarak yeni teklif sayfasının gerekli textboxına yazıyorum
        /// </summary>
        private void btn_imalatcifirma_Click(object sender, EventArgs e)
        {
            FirmaSecerkenHangiButtonaBasti = 1;
            frm_SiparisFirmaKartiSec ac=new frm_SiparisFirmaKartiSec(this);
            ac.ShowDialog();
        }

        private void btn_ithalatcifirma_Click(object sender, EventArgs e)
        {
            FirmaSecerkenHangiButtonaBasti = 2;
            frm_SiparisFirmaKartiSec ac=new frm_SiparisFirmaKartiSec(this);
            ac.ShowDialog();
        }

        private void btn_alicifirma_Click(object sender, EventArgs e)
        {
            FirmaSecerkenHangiButtonaBasti = 3;
            frm_SiparisFirmaKartiSec ac=new frm_SiparisFirmaKartiSec(this);
            ac.ShowDialog();
        }

        public static int SiparisImalatciFirmaID;
        public static int SiparisIthalatciFirmaID;
        public static int SiparisAliciFirmaID;

        byte[] resim1 = null;
        private void btn_resimekle1_Click(object sender, EventArgs e)
        {
            OpenFileDialog resim_gozat = new OpenFileDialog();
            resim_gozat.ShowDialog();
            txt_resim1.Text = resim_gozat.FileName;
            FileStream fsResim1 = new FileStream(txt_resim1.Text, FileMode.Open, FileAccess.Read);
            BinaryReader brResim1 = new BinaryReader(fsResim1);
            resim1 = brResim1.ReadBytes((int)fsResim1.Length);
            pb_resim1.Image = Image.FromStream(fsResim1);
            brResim1.Close();
            fsResim1.Close();
        }
        byte[] resim2 = null;
        private void btn_resimekle2_Click(object sender, EventArgs e)
        {
            OpenFileDialog resim_gozat2 = new OpenFileDialog();
            resim_gozat2.ShowDialog();
            txt_resim2.Text = resim_gozat2.FileName;
            FileStream fsResim2 = new FileStream(txt_resim2.Text, FileMode.Open, FileAccess.Read);
            BinaryReader brResim2 = new BinaryReader(fsResim2);
            resim2 = brResim2.ReadBytes((int)fsResim2.Length);
            pb_resim2.Image = Image.FromStream(fsResim2);
            brResim2.Close();
            fsResim2.Close();
        }

        private void btn_teklifinigoster_Click(object sender, EventArgs e)
        {
            //siparişin teklifini göstericek
        }

        private void btn_renkbedendagilimi_Click(object sender, EventArgs e)
        {
            frm_RenkBedenDagilimi ac = new frm_RenkBedenDagilimi();
            ac.ShowDialog();
        }

        private void btn_olcutablosu_Click(object sender, EventArgs e)
        {
            frm_OlcuTablosu ac = new frm_OlcuTablosu();
            ac.ShowDialog();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            BosAlanKontrolu();
            if (bosalankontrolu == 0)
            {
                SiparisKaydet();
                this.Close();
            }
            else
            {
                bosalankontrolu = 0;
            }
            DegiskenleriBosalt();
        }

        private void SiparisKaydet()
        {
            string textlerikaydet = "INSERT INTO TBL_SIPARIS (S_T_ID,S_F_ID,S_RB_ID,S_OT_ID,S_ALICIFIRMA,S_IMALATCIFIRMA,S_IHRACATCIFIRMA,S_URUNADI,S_KAILTE,S_KUMAS,S_GRAMAJ,S_IMALATCISIPARISNUMARASI,S_ALICISIPARISNUMARASI,S_ODEMESEKLI,S_YUKLEMESEKLI,S_PAKETLEME,S_KAYITTARIHI,S_SIPARISTARIHI,S_1YUKLEMETARIHI,S_2YUKLEMETARIHI,S_3YUKLEMETARIHI,S_4YUKLEMETARIHI,S_ACIKLAMA,S_SONFIYAT,S_MIKTAR,S_SIPARISDURUMU,S_URUNDURUMU,S_TUTAR,S_ONODEME,S_KESINTI,S_KESINTIYUZDESI,S_EKODEME,S_EKODEMENEDENI,S_PESIN,S_PESINYUZDESI,S_ONODEMEYUZDESI,S_TOPLAM,S_TOPLAMPARABIRIMI,S_K_ID,S_KULLANICIADI,S_ETBANSTK,S_3065,S_ETIKET,S_ARTIKELNO,S_ALMANCA,S_FRANSIZCA,S_ITALYANCA,S_VP,S_KKP,S_OWPCODE,S_SEZON,S_SONFIYATBIRIM,S_MIKTARBIRIM,S_TUTARBIRIM,S_IMALATCIACIKADI,S_IMALATCIILGILIKISI,S_KULLANICITAMADI,S_KULLANICIEMAIL,S_IMALATCIFAKS)VALUES(@S_T_ID,@S_F_ID,@S_RB_ID,@S_OT_ID,@S_ALICIFIRMA,@S_IMALATCIFIRMA,@S_IHRACATCIFIRMA,@S_URUNADI,@S_KAILTE,@S_KUMAS,@S_GRAMAJ,@S_IMALATCISIPARISNUMARASI,@S_ALICISIPARISNUMARASI,@S_ODEMESEKLI,@S_YUKLEMESEKLI,@S_PAKETLEME,@S_KAYITTARIHI,@S_SIPARISTARIHI,@S_1YUKLEMETARIHI,@S_2YUKLEMETARIHI,@S_3YUKLEMETARIHI,@S_4YUKLEMETARIHI,@S_ACIKLAMA,@S_SONFIYAT,@S_MIKTAR,@S_SIPARISDURUMU,@S_URUNDURUMU,@S_TUTAR,@S_ONODEME,@S_KESINTI,@S_KESINTIYUZDESI,@S_EKODEME,@S_EKODEMENEDENI,@S_PESIN,@S_PESINYUZDESI,@S_ONODEMEYUZDESI,@S_TOPLAM,@S_TOPLAMPARABIRIMI,@S_K_ID,@S_KULLANICIADI,@S_ETBANSTK,@S_3065,@S_ETIKET,@S_ARTIKELNO,@S_ALMANCA,@S_FRANSIZCA,@S_ITALYANCA,@S_VP,@S_KKP,@S_OWPCODE,@S_SEZON,@S_SONFIYATBIRIM,@S_MIKTARBIRIM,@S_TUTARBIRIM,@S_IMALATCIACIKADI,@S_IMALATCIILGILIKISI,@S_KULLANICITAMADI,@S_KULLANICIEMAIL,@S_IMALATCIFAKS)";
            SqlCommand cmd = new SqlCommand(textlerikaydet, Connection.baglantim);
            cmd.Parameters.AddWithValue("@S_T_ID", frm_Teklif.teklifid).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@S_F_ID", SiparisImalatciFirmaID).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@S_RB_ID", 0).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@S_OT_ID", 0).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@S_ALICIFIRMA", txt_alicifirma.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_IMALATCIFIRMA", txt_imalatcifirma.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_IHRACATCIFIRMA", txt_ithalatcifirma.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_URUNADI", txt_urunadi.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_KAILTE", txt_kalite.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_KUMAS", txt_kumas.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_GRAMAJ", txt_gramaj.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_IMALATCISIPARISNUMARASI", txt_imalatcisiparisno.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_ALICISIPARISNUMARASI", txt_alicisiparisno.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_ODEMESEKLI", cb_odemesekli.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_YUKLEMESEKLI", cb_yuklemesekli.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_PAKETLEME", txt_paketleme.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_KAYITTARIHI", DateTime.Now.ToShortDateString()).SqlDbType = SqlDbType.DateTime;  
            cmd.Parameters.AddWithValue("@S_SIPARISTARIHI", dtp_siparistarihi.Value).SqlDbType = SqlDbType.DateTime;  
            cmd.Parameters.AddWithValue("@S_1YUKLEMETARIHI", dtp_1yuklemetarihi.Value).SqlDbType = SqlDbType.DateTime;  
            cmd.Parameters.AddWithValue("@S_2YUKLEMETARIHI", dtp_2yuklemetarihi.Value).SqlDbType = SqlDbType.DateTime;  
            cmd.Parameters.AddWithValue("@S_3YUKLEMETARIHI", dtp_3yuklemetarihi.Value).SqlDbType = SqlDbType.DateTime;  
            cmd.Parameters.AddWithValue("@S_4YUKLEMETARIHI", dtp_4yuklemetarihi.Value).SqlDbType = SqlDbType.DateTime;  
            cmd.Parameters.AddWithValue("@S_ACIKLAMA", rtb_aciklama.Text).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@S_SONFIYAT", txt_sonfiyat.Text).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@S_MIKTAR", txt_miktar.Text).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@S_SIPARISDURUMU", cb_siparisdurumu.Text).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@S_URUNDURUMU", cb_urundurumu.Text).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@S_TUTAR", txttutar).SqlDbType= SqlDbType.Money;
            cmd.Parameters.AddWithValue("@S_ONODEME", txt_onodeme.Text).SqlDbType = SqlDbType.Money;
            cmd.Parameters.AddWithValue("@S_KESINTI", txt_kesinti.Text).SqlDbType = SqlDbType.Money;
            cmd.Parameters.AddWithValue("@S_KESINTIYUZDESI", txt_kesintiyuzde.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_EKODEME", txt_ekodeme.Text).SqlDbType = SqlDbType.Money;
            cmd.Parameters.AddWithValue("@S_EKODEMENEDENI", txt_ekodemenedeni.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_PESIN", txt_pesin.Text).SqlDbType = SqlDbType.Money;
            cmd.Parameters.AddWithValue("@S_PESINYUZDESI", txt_pesinyuzde.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_ONODEMEYUZDESI", txt_onodemeyuzde.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_TOPLAM", txt_toplam.Text).SqlDbType = SqlDbType.Money;
            cmd.Parameters.AddWithValue("@S_TOPLAMPARABIRIMI", txt_toplambirim.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_K_ID", frm_KullaniciGirisi.kg_id).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@S_KULLANICIADI", frm_KullaniciGirisi.kg_ad).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_ETBANSTK", txt_etbanstk.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_3065", txt_3065.Text).SqlDbType = SqlDbType.Money;
            cmd.Parameters.AddWithValue("@S_ETIKET", cb_etiket.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_ARTIKELNO", txt_artiketno.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_ALMANCA", txt_almanca.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_FRANSIZCA", txt_fransizca.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_ITALYANCA", txt_italyanca.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_VP", txt_vp.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_KKP", txt_kkp.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_OWPCODE", txt_owpcode.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_SEZON", txt_sezon.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_SONFIYATBIRIM", cb_sonfiyat.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_MIKTARBIRIM", cb_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_TUTARBIRIM", txt_tutarbirim.Text).SqlDbType = SqlDbType.NVarChar;
            //rapor için kaydedilen alanlar
            cmd.Parameters.AddWithValue("@S_IMALATCIACIKADI", txt_imalatciAcikAdi.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_IMALATCIILGILIKISI", txt_imalatciIlgiliKisi.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_KULLANICITAMADI", frm_KullaniciGirisi.kg_acikad).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_KULLANICIEMAIL", frm_KullaniciGirisi.kg_email).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_IMALATCIFAKS", txt_imalatciFaks.Text).SqlDbType = SqlDbType.NVarChar;
            try
            {
                Connection.baglantim.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(this, "Yeni Sipariş veri tabanına başarıyla eklenmiştir.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception HATA)
            {

                MessageBox.Show(this, "Veri tabanına bağlanılırken bir hata oluştu.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(this, HATA.ToString());

            }
            finally
            {
                Connection.baglantim.Close();
            }
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            DialogResult dugmesec;
            dugmesec = MessageBox.Show(this, "Sipariş Kaydı Sayfasını kapatırsanız tüm girmiş olduğunuz verileri kaybedeceksiniz! Bunu istediğinizden eminmisiniz?", "Onay Mesajı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dugmesec == DialogResult.Yes)
            {
                DegiskenleriBosalt();
                this.Close();
            }
            else if (dugmesec == DialogResult.No)
            {
                MessageBox.Show(this, "İşleminize Kaldığınız yerden devam edebilirsiniz.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void cb_1yuklemetarihi_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_1yuklemetarihi.Checked == true)
            {
                dtp_1yuklemetarihi.Enabled = true;
            }
            else
                dtp_1yuklemetarihi.Enabled = false;

        }

        private void cb_2yuklemetarihi_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_2yuklemetarihi.Checked == true)
            {
                dtp_2yuklemetarihi.Enabled = true;
            }
            else
                dtp_2yuklemetarihi.Enabled = false;

        }

        private void cb_3yuklemetarihi_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_3yuklemetarihi.Checked == true)
            {
                dtp_3yuklemetarihi.Enabled = true;
            }
            else
                dtp_3yuklemetarihi.Enabled = false;

        }

        private void cb_4yuklemetarihi_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_4yuklemetarihi.Checked == true)
            {
                dtp_4yuklemetarihi.Enabled = true;
            }
            else
                dtp_4yuklemetarihi.Enabled = false;

        }

        int bosalankontrolu = 0;
        private void BosAlanKontrolu()
        {
            ErrorProvider ep = new ErrorProvider();
            if (txt_tutar.Text == "0")
            {
                bosalankontrolu = 1;
                ep.SetError(txt_tutar, "Boş bırakamazsınız.");
            }
        }

        private void ParaAlanlarınaSıfırDoldur()
        {
            txt_3065.Text = "0,00";
            txt_tutar.Text = "0,00";
            txt_toplam.Text = "0,00";
            txt_ekodeme.Text = "0,00";
            txt_kesinti.Text = "0,00";
            txt_pesin.Text = "0,00";
            txt_onodeme.Text = "0,00";
            if (txt_sonfiyat.Text == "")
            {
                txt_sonfiyat.Text = "0,00";
            }
            if (txt_alisfiyati.Text == "")
            {
                txt_alisfiyati.Text = "0,00";
            }
        }

        decimal txt3065;
        decimal txttutar;
        decimal txtonodeme;
        decimal txtkesinti;
        decimal txtpesin;
        decimal txtekodeme;
        decimal txttoplam;
        decimal txtsonfiyat; //sonfiyat = satışfiyatı aynı şey... ottos programındaki ismi son fiyattı! ordan gelme bir alışkanlık!
        decimal txtalisfiyati;
        private void ParaAlanKontrolu()
        { 
            //combobox ları doldurduğum gibi textbox alanı tanımlanacak ve işlem yapılıp para leave
            //yerlerine yazılacak falan felan...
        }
        private void txt_tutar_Leave(object sender, EventArgs e)
        {
            if (txt_tutar.Text == "")
            {
                txt_tutar.Text = "0";
                txttutar = Convert.ToDecimal(txt_tutar.Text);
                txt_tutar.Text = txttutar.ToString("N");
            }
            else
                txttutar = Convert.ToDecimal(txt_tutar.Text);
                txt_tutar.Text = txttutar.ToString("N");
        }

        private void txt_onodeme_Leave(object sender, EventArgs e)
        {
            if (txt_onodeme.Text == "")
            {
                txt_onodeme.Text = "0";
                txtonodeme = Convert.ToDecimal(txt_onodeme.Text);
                txt_onodeme.Text = txtonodeme.ToString("N");
            }
            else
                txtonodeme = Convert.ToDecimal(txt_onodeme.Text);
                txt_onodeme.Text = txtonodeme.ToString("N");
        }

        private void txt_kesinti_Leave(object sender, EventArgs e)
        {
            if (txt_kesinti.Text == "")
            {
                txt_kesinti.Text = "0";
                txtkesinti = Convert.ToDecimal(txt_kesinti.Text);
                txt_kesinti.Text = txtkesinti.ToString("N");
            }
            else
                txtkesinti = Convert.ToDecimal(txt_kesinti.Text);
                txt_kesinti.Text = txtkesinti.ToString("N");
        }

        private void txt_pesin_Leave(object sender, EventArgs e)
        {
            if (txt_pesin.Text == "")
            {
                txt_pesin.Text = "0";
                txtpesin = Convert.ToDecimal(txt_pesin.Text);
                txt_pesin.Text = txtpesin.ToString("N");
            }
            else
                txtpesin = Convert.ToDecimal(txt_pesin.Text);
                txt_pesin.Text = txtpesin.ToString("N");
        }

        private void txt_ekodeme_Leave(object sender, EventArgs e)
        {
            if (txt_ekodeme.Text == "")
            {
                txt_ekodeme.Text = "0";
                txtekodeme = Convert.ToDecimal(txt_ekodeme.Text);
                txt_ekodeme.Text = txtekodeme.ToString("N");
            }
            else
                txtekodeme = Convert.ToDecimal(txt_ekodeme.Text);
                txt_ekodeme.Text = txtekodeme.ToString("N");
        }

        private void txt_toplam_Leave(object sender, EventArgs e)
        {
            if (txt_toplam.Text == "")
            {
                txt_toplam.Text = "0";
                txttoplam = Convert.ToDecimal(txt_toplam.Text);
                txt_toplam.Text = txttoplam.ToString("N");
            }
            else
                txttoplam = Convert.ToDecimal(txt_toplam.Text);
                txt_toplam.Text = txttoplam.ToString("N");
        }

        private void txt_sonfiyat_Leave(object sender, EventArgs e)
        {
             if (txt_sonfiyat.Text == "")
            {
                txt_sonfiyat.Text = "0";
                txtsonfiyat = Convert.ToDecimal(txt_sonfiyat.Text);
                txt_sonfiyat.Text = txtsonfiyat.ToString("N");
            }
            else
                txtsonfiyat = Convert.ToDecimal(txt_sonfiyat.Text);
                txt_sonfiyat.Text = txtsonfiyat.ToString("N");
        }

        private void txt_3065_Leave(object sender, EventArgs e)
        {
             if (txt_3065.Text == "")
            {
                txt_3065.Text = "0";
                txt3065 = Convert.ToDecimal(txt_3065.Text);
                txt_3065.Text = txt3065.ToString("N");
            }
            else
                txt3065 = Convert.ToDecimal(txt_3065.Text);
                txt_3065.Text = txt3065.ToString("N");
        }

        private void txt_alisfiyati_Leave(object sender, EventArgs e)
        {
            if (txt_alisfiyati.Text == "")
            {
                txt_alisfiyati.Text = "0";
                txtalisfiyati = Convert.ToDecimal(txt_alisfiyati.Text);
                txt_alisfiyati.Text = txtalisfiyati.ToString("N");
            }
            else
                txtalisfiyati = Convert.ToDecimal(txt_alisfiyati.Text);
                txt_alisfiyati.Text = txtalisfiyati.ToString("N");
        }

        private void DegiskenleriBosalt()
        {
            frm_Teklif.TeklifSayfasindanSipariseDonusturuldu = 0;
        }

        private void frm_SiparisYeniKayit_FormClosing(object sender, FormClosingEventArgs e)
        {
            DegiskenleriBosalt();
        }
    }
}
