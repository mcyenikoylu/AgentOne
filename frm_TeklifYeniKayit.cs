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
    public partial class frm_TeklifYeniKayit : Form
    {
        public frm_TeklifYeniKayit()
        {
            InitializeComponent();
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
            ComboBox[] ComboBoxlarim = new ComboBox[8] { cb_urundurumu, cb_teklifdurumu, cb_yuklemesekli, cb_odemesekli, cb_birimfiyat, cb_miktar, cb_toplam, cb_alimfiyatbirimi};

            String[] Sorgularim = new string[8] {"SELECT UD_DEGER FROM TBL_URUNDURUM ORDER BY UD_DEGER",
            "SELECT TD_DEGER FROM TBL_TEKLIFDURUM ORDER BY TD_DEGER",
            "SELECT YS_DEGER FROM TBL_YUKLEMESEKLI ORDER BY YS_DEGER",
            "SELECT OS_DEGER FROM TBL_ODEMESEKLI ORDER BY OS_DEGER",
            "SELECT PB_DEGER FROM TBL_PARABIRIMI ORDER BY PB_DEGER",
            "SELECT MB_DEGER FROM TBL_MIKTARBIRIMI ORDER BY MB_DEGER",
            "SELECT PB_DEGER FROM TBL_PARABIRIMI ORDER BY PB_DEGER",
            "SELECT PB_DEGER FROM TBL_PARABIRIMI ORDER BY PB_DEGER"};

            String[] TabloAdlarim = new string[8] {"TBL_URUNDURUM",
            "TBL_TEKLIFDURUM",
            "TBL_YUKLEMESEKLI",
            "TBL_ODEMESEKLI",
            "TBL_PARABIRIMI",
            "TBL_MIKTARBIRIMI",
            "TBL_PARABIRIMI",
            "TBL_PARABIRIMI"};

            String[] KolonAdlarim = new string[8] {"UD_DEGER",
            "TD_DEGER",
            "YS_DEGER",
            "OS_DEGER",
            "PB_DEGER",
            "MB_DEGER",
            "PB_DEGER",
            "PB_DEGER"};

            for (int index = 0; index < 8; index++)
                Combolari_Doldur(ComboBoxlarim[index], Sorgularim[index], TabloAdlarim[index], KolonAdlarim[index]);

        }

        private void frm_TeklifYeniKayit_Load(object sender, EventArgs e)
        {
            Combolar_Doldu();
            UrunGrubuCheckList();
            ParaAlanlarınaSıfırDoldur();
        }

        private void UrunGrubuCheckList()
        {
            SqlDataAdapter ugcl = new SqlDataAdapter("SELECT UG_DEGER FROM TBL_URUNGRUP ORDER BY UG_DEGER", Connection.baglantim);
            DataSet ugcl_al = new DataSet();
            ugcl.Fill(ugcl_al, "TBL_URUNGRUP");
            DataTable ugcl_table = ugcl_al.Tables["TBL_URUNGRUP"];
            foreach (DataRow ugcl_dizi in ugcl_table.Rows)
            {
                clb_urungrubu.Items.Add(ugcl_dizi["UG_DEGER"]);
            }
        }

        string selectedlists = "";
        private void UrunGrubuCheckListAralarinaVirgul()
        { 
            if (clb_urungrubu.CheckedItems.Count > 0)
            {
                for (int virgul = 0; virgul < clb_urungrubu.CheckedItems.Count; virgul++)
                {
                    selectedlists += clb_urungrubu.CheckedItems[virgul].ToString();
                    if (virgul < clb_urungrubu.CheckedItems.Count - 1)
                        selectedlists += ",";
                }
            }
        }

        public static int FirmaSecerkenHangiButtonaBasti=0;
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
            frm_FirmaKartiSec ac = new frm_FirmaKartiSec(this);
            ac.ShowDialog();
        }

        private void btn_ithalatcifirma_Click(object sender, EventArgs e)
        {
            //aslında ithalat diye birşey yok. ihracatcı yazacağıma ithalatcı yazmışım.
            //bir çok yerde olduğu içinde düzeltme işlemine girmedim. zaten bu proje tekrar yazılacak
            FirmaSecerkenHangiButtonaBasti = 2;
            frm_FirmaKartiSec ac = new frm_FirmaKartiSec(this);
            ac.ShowDialog();
        }

        private void btn_alicifirma_Click(object sender, EventArgs e)
        {
            FirmaSecerkenHangiButtonaBasti = 3;
            frm_FirmaKartiSec ac = new frm_FirmaKartiSec(this);
            ac.ShowDialog();
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static int ImalatciFirmaID;
        public static int IthalatciFirmaID;
        public static int AliciFirmaID;
        private void TeklifKaydet()
        {
            if (resim1eklendi == 1 && resim2eklendi == 1) //1. ve 2. resimler eklemek için seçildiler.
            {
                Resim1ve2Ekle();
            }
            else if (resim1eklendi == 1) //sadece resim1 eklendiyse
            {
                Resim1Eklendi();
            }
            else if (resim2eklendi == 1) //sadece resim2 eklendiyse
            {
                Resim2Eklendi();
            }

            if (resim1eklendi == 0 && resim2eklendi == 0) //1. ve 2. resimler seçilmediler.
            {
                ResimEklenmedi();
            }
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

        private void btn_resimekle1_Click(object sender, EventArgs e)
        {
            Resim1Ekle();
        }
        
        private void btn_resimekle2_Click(object sender, EventArgs e)
        {
            Resim2Ekle();
        }

        int resim1eklendi = 0; //resim güncellemesi yapılmadı.
        byte[] resim1 = null; //resim byte tipine çevrilerek sql e yazılıyor.
        private void Resim1Ekle()
        { //RESİM1
            resim1 = null;
            OpenFileDialog resim_gozat = new OpenFileDialog();
            resim_gozat.ShowDialog();
            txt_resim.Text = resim_gozat.FileName;
            if (!string.IsNullOrEmpty(txt_resim.Text) || File.Exists(txt_resim.Text))
            {
                FileStream fsResim1 = new FileStream(txt_resim.Text, FileMode.Open, FileAccess.Read);
                BinaryReader brResim1 = new BinaryReader(fsResim1);
                resim1 = brResim1.ReadBytes((int)fsResim1.Length);
                pb_resim1.Image = Image.FromStream(fsResim1);
                brResim1.Close();
                fsResim1.Close();
                resim1eklendi = 1; //birinci resim güncellendi.
            }
            else
            {
                MessageBox.Show("Resim1 dosyası seçmediniz!");
            }
        }

        int resim2eklendi = 0; //resim güncellemesi yapıldımı.
        byte[] resim2 = null; //resim byte tipine çevrilerek sql e yazılıyor.
        private void Resim2Ekle()
        { //RESİM2
            resim2 = null;
            OpenFileDialog resim_gozat2 = new OpenFileDialog();
            resim_gozat2.ShowDialog();
            txt_resim2.Text = resim_gozat2.FileName;
            if (!string.IsNullOrEmpty(txt_resim2.Text) || File.Exists(txt_resim2.Text))
            {
                FileStream fsResim2 = new FileStream(txt_resim2.Text, FileMode.Open, FileAccess.Read);
                BinaryReader brResim2 = new BinaryReader(fsResim2);
                resim2 = brResim2.ReadBytes((int)fsResim2.Length);
                pb_resim2.Image = Image.FromStream(fsResim2);
                brResim2.Close();
                fsResim2.Close();
                resim2eklendi = 1; //ikinci resim güncellendi.
            }
            else
            {
                MessageBox.Show("Resim2 dosyası seçmediniz!");
            }
        }

        private void Resim1ve2Ekle()
        {
            UrunGrubuCheckListAralarinaVirgul();
            string textlerikaydet = "INSERT INTO TBL_TEKLIF (T_K_ID,T_KULLANICIADI,T_RB_ID,T_OT_ID,T_URUNGRUBU,T_URUNDURUMU,T_TEKLIFDURUMU,T_ALICISIRKET,T_IMALATCIFIRMA,T_IHRACATCIFIRMA,T_URUNADI,T_KALITE,T_YUKLEMESEKLI,T_ODEMESEKLI,T_ACIKLAMA,T_BIRIMFIYAT,T_TOPLAMFIYAT,T_MIKTAR,T_RESIM1,T_RESIM2,T_KAYITTARIHI,T_ALIMFIYATI,T_ALIMFIYATBIRIMI,T_BIRIMFIYATPARABIRIMI,T_MIKTAROLCUBIRIMI,T_TOPLAMFIYATPARABIRIMI,T_NUMUNEALIMTARIHI,T_NUMUNEGONDERIMTARIHI,T_NUMUNEIADETARIHI,T_NUMUNEALIMADET,T_NUMUNEALIMRENK,T_NUMUNEIADEADET,T_NUMUNEIADERENK,T_NUMUNEGONDERIMADET,T_NUMUNEGONDERIMRENK,T_NUMUNEALIMACIKLAMA,T_NUMUNEGONDERIMACIKLAMA)VALUES(@T_K_ID,@T_KULLANICIADI,@T_RB_ID,@T_OT_ID,@T_URUNGRUBU,@T_URUNDURUMU,@T_TEKLIFDURUMU,@T_ALICISIRKET,@T_IMALATCIFIRMA,@T_IHRACATCIFIRMA,@T_URUNADI,@T_KALITE,@T_YUKLEMESEKLI,@T_ODEMESEKLI,@T_ACIKLAMA,@T_BIRIMFIYAT,@T_TOPLAMFIYAT,@T_MIKTAR,@T_RESIM1,@T_RESIM2,@T_KAYITTARIHI,@T_ALIMFIYATI,@T_ALIMFIYATBIRIMI,@T_BIRIMFIYATPARABIRIMI,@T_MIKTAROLCUBIRIMI,@T_TOPLAMFIYATPARABIRIMI,@T_NUMUNEALIMTARIHI,@T_NUMUNEGONDERIMTARIHI,@T_NUMUNEIADETARIHI,@T_NUMUNEALIMADET,@T_NUMUNEALIMRENK,@T_NUMUNEIADEADET,@T_NUMUNEIADERENK,@T_NUMUNEGONDERIMADET,@T_NUMUNEGONDERIMRENK,@T_NUMUNEALIMACIKLAMA,@T_NUMUNEGONDERIMACIKLAMA)";
            SqlCommand cmd = new SqlCommand(textlerikaydet, Connection.baglantim);
            cmd.Parameters.AddWithValue("@T_K_ID", frm_KullaniciGirisi.kg_id).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_KULLANICIADI", frm_KullaniciGirisi.kg_ad).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_RB_ID", 0).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_OT_ID", 0).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_URUNGRUBU", selectedlists).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@T_URUNDURUMU", cb_urundurumu.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_TEKLIFDURUMU", cb_teklifdurumu.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_ALICISIRKET", txt_alicifirma.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_IMALATCIFIRMA", txt_imalatcifirma.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_IHRACATCIFIRMA", txt_ithalatcifirma.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_URUNADI", txt_urunadi.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_KALITE", txt_kalite.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_YUKLEMESEKLI", cb_yuklemesekli.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_ODEMESEKLI", cb_odemesekli.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_ACIKLAMA", rtb_aciklama.Text).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@T_BIRIMFIYAT", txt_birimfiyat.Text).SqlDbType = SqlDbType.NVarChar;//son fiyat denilen değerin sonradan ismi değişti ve satış birim fiyatı oldu.
            cmd.Parameters.AddWithValue("@T_TOPLAMFIYAT", txt_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_MIKTAR", txt_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_RESIM1", SqlDbType.Image).Value = resim1;
            cmd.Parameters.AddWithValue("@T_RESIM2", SqlDbType.Image).Value = resim2;
            cmd.Parameters.AddWithValue("@T_KAYITTARIHI", DateTime.Now.ToShortDateString()).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_ALIMFIYATI", txt_alimfiyat.Text).SqlDbType = SqlDbType.Money;
            cmd.Parameters.AddWithValue("@T_ALIMFIYATBIRIMI", cb_alimfiyatbirimi.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_BIRIMFIYATPARABIRIMI", cb_birimfiyat.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_MIKTAROLCUBIRIMI", cb_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_TOPLAMFIYATPARABIRIMI", cb_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMTARIHI", dtp_alimtarihi.Value).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMTARIHI", dtp_gonderim.Value).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_NUMUNEIADETARIHI", dtp_iadetarihi.Value).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMADET", txt_alimadet.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMRENK", txt_alimrenk.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEIADEADET", txt_iadeadet.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEIADERENK", txt_iaderenk.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMADET", txt_gonderimadet.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMRENK", txt_gonderimrenk.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMACIKLAMA", rtb_alimaciklama.Text).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMACIKLAMA", rtb_gonderimaciklama.Text).SqlDbType = SqlDbType.Text;
            try
            {
                Connection.baglantim.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(this, "Yeni Teklif veri tabanına başarıyla eklenmiştir.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        private void ResimEklenmedi()
        {
            UrunGrubuCheckListAralarinaVirgul();
            string textlerikaydet = "INSERT INTO TBL_TEKLIF (T_K_ID,T_KULLANICIADI,T_RB_ID,T_OT_ID,T_URUNGRUBU,T_URUNDURUMU,T_TEKLIFDURUMU,T_ALICISIRKET,T_IMALATCIFIRMA,T_IHRACATCIFIRMA,T_URUNADI,T_KALITE,T_YUKLEMESEKLI,T_ODEMESEKLI,T_ACIKLAMA,T_BIRIMFIYAT,T_TOPLAMFIYAT,T_MIKTAR,T_KAYITTARIHI,T_ALIMFIYATI,T_ALIMFIYATBIRIMI,T_BIRIMFIYATPARABIRIMI,T_MIKTAROLCUBIRIMI,T_TOPLAMFIYATPARABIRIMI,T_NUMUNEALIMTARIHI,T_NUMUNEGONDERIMTARIHI,T_NUMUNEIADETARIHI,T_NUMUNEALIMADET,T_NUMUNEALIMRENK,T_NUMUNEIADEADET,T_NUMUNEIADERENK,T_NUMUNEGONDERIMADET,T_NUMUNEGONDERIMRENK,T_NUMUNEALIMACIKLAMA,T_NUMUNEGONDERIMACIKLAMA)VALUES(@T_K_ID,@T_KULLANICIADI,@T_RB_ID,@T_OT_ID,@T_URUNGRUBU,@T_URUNDURUMU,@T_TEKLIFDURUMU,@T_ALICISIRKET,@T_IMALATCIFIRMA,@T_IHRACATCIFIRMA,@T_URUNADI,@T_KALITE,@T_YUKLEMESEKLI,@T_ODEMESEKLI,@T_ACIKLAMA,@T_BIRIMFIYAT,@T_TOPLAMFIYAT,@T_MIKTAR,@T_KAYITTARIHI,@T_ALIMFIYATI,@T_ALIMFIYATBIRIMI,@T_BIRIMFIYATPARABIRIMI,@T_MIKTAROLCUBIRIMI,@T_TOPLAMFIYATPARABIRIMI,@T_NUMUNEALIMTARIHI,@T_NUMUNEGONDERIMTARIHI,@T_NUMUNEIADETARIHI,@T_NUMUNEALIMADET,@T_NUMUNEALIMRENK,@T_NUMUNEIADEADET,@T_NUMUNEIADERENK,@T_NUMUNEGONDERIMADET,@T_NUMUNEGONDERIMRENK,@T_NUMUNEALIMACIKLAMA,@T_NUMUNEGONDERIMACIKLAMA)";
            SqlCommand cmd = new SqlCommand(textlerikaydet, Connection.baglantim);
            cmd.Parameters.AddWithValue("@T_K_ID", frm_KullaniciGirisi.kg_id).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_KULLANICIADI", frm_KullaniciGirisi.kg_ad).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_RB_ID", 0).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_OT_ID", 0).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_URUNGRUBU", selectedlists).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@T_URUNDURUMU", cb_urundurumu.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_TEKLIFDURUMU", cb_teklifdurumu.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_ALICISIRKET", txt_alicifirma.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_IMALATCIFIRMA", txt_imalatcifirma.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_IHRACATCIFIRMA", txt_ithalatcifirma.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_URUNADI", txt_urunadi.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_KALITE", txt_kalite.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_YUKLEMESEKLI", cb_yuklemesekli.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_ODEMESEKLI", cb_odemesekli.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_ACIKLAMA", rtb_aciklama.Text).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@T_BIRIMFIYAT", txt_birimfiyat.Text).SqlDbType = SqlDbType.NVarChar;//son fiyat denilen değerin sonradan ismi değişti ve satış birim fiyatı oldu.
            cmd.Parameters.AddWithValue("@T_TOPLAMFIYAT", txt_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_MIKTAR", txt_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_KAYITTARIHI", DateTime.Now.ToShortDateString()).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_ALIMFIYATI", txt_alimfiyat.Text).SqlDbType = SqlDbType.Money;
            cmd.Parameters.AddWithValue("@T_ALIMFIYATBIRIMI", cb_alimfiyatbirimi.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_BIRIMFIYATPARABIRIMI", cb_birimfiyat.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_MIKTAROLCUBIRIMI", cb_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_TOPLAMFIYATPARABIRIMI", cb_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMTARIHI", dtp_alimtarihi.Value).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMTARIHI", dtp_gonderim.Value).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_NUMUNEIADETARIHI", dtp_iadetarihi.Value).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMADET", txt_alimadet.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMRENK", txt_alimrenk.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEIADEADET", txt_iadeadet.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEIADERENK", txt_iaderenk.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMADET", txt_gonderimadet.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMRENK", txt_gonderimrenk.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMACIKLAMA", rtb_alimaciklama.Text).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMACIKLAMA", rtb_gonderimaciklama.Text).SqlDbType = SqlDbType.Text;
            try
            {
                Connection.baglantim.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(this, "Yeni Teklif veri tabanına başarıyla eklenmiştir.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        private void Resim1Eklendi()
        {
            UrunGrubuCheckListAralarinaVirgul();
            string textlerikaydet = "INSERT INTO TBL_TEKLIF (T_K_ID,T_KULLANICIADI,T_RB_ID,T_OT_ID,T_URUNGRUBU,T_URUNDURUMU,T_TEKLIFDURUMU,T_ALICISIRKET,T_IMALATCIFIRMA,T_IHRACATCIFIRMA,T_URUNADI,T_KALITE,T_YUKLEMESEKLI,T_ODEMESEKLI,T_ACIKLAMA,T_BIRIMFIYAT,T_TOPLAMFIYAT,T_MIKTAR,T_RESIM1,T_KAYITTARIHI,T_ALIMFIYATI,T_ALIMFIYATBIRIMI,T_BIRIMFIYATPARABIRIMI,T_MIKTAROLCUBIRIMI,T_TOPLAMFIYATPARABIRIMI,T_NUMUNEALIMTARIHI,T_NUMUNEGONDERIMTARIHI,T_NUMUNEIADETARIHI,T_NUMUNEALIMADET,T_NUMUNEALIMRENK,T_NUMUNEIADEADET,T_NUMUNEIADERENK,T_NUMUNEGONDERIMADET,T_NUMUNEGONDERIMRENK,T_NUMUNEALIMACIKLAMA,T_NUMUNEGONDERIMACIKLAMA)VALUES(@T_K_ID,@T_KULLANICIADI,@T_RB_ID,@T_OT_ID,@T_URUNGRUBU,@T_URUNDURUMU,@T_TEKLIFDURUMU,@T_ALICISIRKET,@T_IMALATCIFIRMA,@T_IHRACATCIFIRMA,@T_URUNADI,@T_KALITE,@T_YUKLEMESEKLI,@T_ODEMESEKLI,@T_ACIKLAMA,@T_BIRIMFIYAT,@T_TOPLAMFIYAT,@T_MIKTAR,@T_RESIM1,@T_KAYITTARIHI,@T_ALIMFIYATI,@T_ALIMFIYATBIRIMI,@T_BIRIMFIYATPARABIRIMI,@T_MIKTAROLCUBIRIMI,@T_TOPLAMFIYATPARABIRIMI,@T_NUMUNEALIMTARIHI,@T_NUMUNEGONDERIMTARIHI,@T_NUMUNEIADETARIHI,@T_NUMUNEALIMADET,@T_NUMUNEALIMRENK,@T_NUMUNEIADEADET,@T_NUMUNEIADERENK,@T_NUMUNEGONDERIMADET,@T_NUMUNEGONDERIMRENK,@T_NUMUNEALIMACIKLAMA,@T_NUMUNEGONDERIMACIKLAMA)";
            SqlCommand cmd = new SqlCommand(textlerikaydet, Connection.baglantim);
            cmd.Parameters.AddWithValue("@T_K_ID", frm_KullaniciGirisi.kg_id).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_KULLANICIADI", frm_KullaniciGirisi.kg_ad).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_RB_ID", 0).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_OT_ID", 0).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_URUNGRUBU", selectedlists).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@T_URUNDURUMU", cb_urundurumu.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_TEKLIFDURUMU", cb_teklifdurumu.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_ALICISIRKET", txt_alicifirma.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_IMALATCIFIRMA", txt_imalatcifirma.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_IHRACATCIFIRMA", txt_ithalatcifirma.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_URUNADI", txt_urunadi.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_KALITE", txt_kalite.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_YUKLEMESEKLI", cb_yuklemesekli.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_ODEMESEKLI", cb_odemesekli.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_ACIKLAMA", rtb_aciklama.Text).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@T_BIRIMFIYAT", txt_birimfiyat.Text).SqlDbType = SqlDbType.NVarChar;//son fiyat denilen değerin sonradan ismi değişti ve satış birim fiyatı oldu.
            cmd.Parameters.AddWithValue("@T_TOPLAMFIYAT", txt_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_MIKTAR", txt_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_RESIM1", SqlDbType.Image).Value = resim1;
            cmd.Parameters.AddWithValue("@T_KAYITTARIHI", DateTime.Now.ToShortDateString()).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_ALIMFIYATI", txt_alimfiyat.Text).SqlDbType = SqlDbType.Money;
            cmd.Parameters.AddWithValue("@T_ALIMFIYATBIRIMI", cb_alimfiyatbirimi.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_BIRIMFIYATPARABIRIMI", cb_birimfiyat.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_MIKTAROLCUBIRIMI", cb_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_TOPLAMFIYATPARABIRIMI", cb_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMTARIHI", dtp_alimtarihi.Value).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMTARIHI", dtp_gonderim.Value).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_NUMUNEIADETARIHI", dtp_iadetarihi.Value).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMADET", txt_alimadet.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMRENK", txt_alimrenk.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEIADEADET", txt_iadeadet.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEIADERENK", txt_iaderenk.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMADET", txt_gonderimadet.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMRENK", txt_gonderimrenk.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMACIKLAMA", rtb_alimaciklama.Text).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMACIKLAMA", rtb_gonderimaciklama.Text).SqlDbType = SqlDbType.Text;
            try
            {
                Connection.baglantim.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(this, "Yeni Teklif veri tabanına başarıyla eklenmiştir.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
        private void Resim2Eklendi()
        {
            UrunGrubuCheckListAralarinaVirgul();
            string textlerikaydet = "INSERT INTO TBL_TEKLIF (T_K_ID,T_KULLANICIADI,T_RB_ID,T_OT_ID,T_URUNGRUBU,T_URUNDURUMU,T_TEKLIFDURUMU,T_ALICISIRKET,T_IMALATCIFIRMA,T_IHRACATCIFIRMA,T_URUNADI,T_KALITE,T_YUKLEMESEKLI,T_ODEMESEKLI,T_ACIKLAMA,T_BIRIMFIYAT,T_TOPLAMFIYAT,T_MIKTAR,T_RESIM2,T_KAYITTARIHI,T_ALIMFIYATI,T_ALIMFIYATBIRIMI,T_BIRIMFIYATPARABIRIMI,T_MIKTAROLCUBIRIMI,T_TOPLAMFIYATPARABIRIMI,T_NUMUNEALIMTARIHI,T_NUMUNEGONDERIMTARIHI,T_NUMUNEIADETARIHI,T_NUMUNEALIMADET,T_NUMUNEALIMRENK,T_NUMUNEIADEADET,T_NUMUNEIADERENK,T_NUMUNEGONDERIMADET,T_NUMUNEGONDERIMRENK,T_NUMUNEALIMACIKLAMA,T_NUMUNEGONDERIMACIKLAMA)VALUES(@T_K_ID,@T_KULLANICIADI,@T_RB_ID,@T_OT_ID,@T_URUNGRUBU,@T_URUNDURUMU,@T_TEKLIFDURUMU,@T_ALICISIRKET,@T_IMALATCIFIRMA,@T_IHRACATCIFIRMA,@T_URUNADI,@T_KALITE,@T_YUKLEMESEKLI,@T_ODEMESEKLI,@T_ACIKLAMA,@T_BIRIMFIYAT,@T_TOPLAMFIYAT,@T_MIKTAR,@T_RESIM2,@T_KAYITTARIHI,@T_ALIMFIYATI,@T_ALIMFIYATBIRIMI,@T_BIRIMFIYATPARABIRIMI,@T_MIKTAROLCUBIRIMI,@T_TOPLAMFIYATPARABIRIMI,@T_NUMUNEALIMTARIHI,@T_NUMUNEGONDERIMTARIHI,@T_NUMUNEIADETARIHI,@T_NUMUNEALIMADET,@T_NUMUNEALIMRENK,@T_NUMUNEIADEADET,@T_NUMUNEIADERENK,@T_NUMUNEGONDERIMADET,@T_NUMUNEGONDERIMRENK,@T_NUMUNEALIMACIKLAMA,@T_NUMUNEGONDERIMACIKLAMA)";
            SqlCommand cmd = new SqlCommand(textlerikaydet, Connection.baglantim);
            cmd.Parameters.AddWithValue("@T_K_ID", frm_KullaniciGirisi.kg_id).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_KULLANICIADI", frm_KullaniciGirisi.kg_ad).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_RB_ID", 0).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_OT_ID", 0).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_URUNGRUBU", selectedlists).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@T_URUNDURUMU", cb_urundurumu.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_TEKLIFDURUMU", cb_teklifdurumu.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_ALICISIRKET", txt_alicifirma.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_IMALATCIFIRMA", txt_imalatcifirma.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_IHRACATCIFIRMA", txt_ithalatcifirma.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_URUNADI", txt_urunadi.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_KALITE", txt_kalite.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_YUKLEMESEKLI", cb_yuklemesekli.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_ODEMESEKLI", cb_odemesekli.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_ACIKLAMA", rtb_aciklama.Text).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@T_BIRIMFIYAT", txt_birimfiyat.Text).SqlDbType = SqlDbType.NVarChar;//son fiyat denilen değerin sonradan ismi değişti ve satış birim fiyatı oldu.
            cmd.Parameters.AddWithValue("@T_TOPLAMFIYAT", txt_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_MIKTAR", txt_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_RESIM2", SqlDbType.Image).Value = resim2;
            cmd.Parameters.AddWithValue("@T_KAYITTARIHI", DateTime.Now.ToShortDateString()).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_ALIMFIYATI", txt_alimfiyat.Text).SqlDbType = SqlDbType.Money;
            cmd.Parameters.AddWithValue("@T_ALIMFIYATBIRIMI", cb_alimfiyatbirimi.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_BIRIMFIYATPARABIRIMI", cb_birimfiyat.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_MIKTAROLCUBIRIMI", cb_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_TOPLAMFIYATPARABIRIMI", cb_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMTARIHI", dtp_alimtarihi.Value).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMTARIHI", dtp_gonderim.Value).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_NUMUNEIADETARIHI", dtp_iadetarihi.Value).SqlDbType = SqlDbType.DateTime;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMADET", txt_alimadet.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMRENK", txt_alimrenk.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEIADEADET", txt_iadeadet.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEIADERENK", txt_iaderenk.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMADET", txt_gonderimadet.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMRENK", txt_gonderimrenk.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_NUMUNEALIMACIKLAMA", rtb_alimaciklama.Text).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@T_NUMUNEGONDERIMACIKLAMA", rtb_gonderimaciklama.Text).SqlDbType = SqlDbType.Text;
            try
            {
                Connection.baglantim.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(this, "Yeni Teklif veri tabanına başarıyla eklenmiştir.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            TeklifKaydet();
            this.Close();
        }

        private void ParaAlanlarınaSıfırDoldur()
        {
            txt_alimfiyat.Text = "0,00";
            txt_birimfiyat.Text = "0,00";
            txt_toplam.Text = "0,00";
        }

        decimal alimfiyatı;
        decimal satisbirimfiyati;
        decimal toplamfiyat;

        private void txt_alimfiyat_Leave(object sender, EventArgs e)
        {
            if (txt_alimfiyat.Text == "")
            {
                txt_alimfiyat.Text = "0";
                alimfiyatı = Convert.ToDecimal(txt_alimfiyat.Text);
                txt_alimfiyat.Text = alimfiyatı.ToString("N");
            }
            else
                alimfiyatı = Convert.ToDecimal(txt_alimfiyat.Text);
                txt_alimfiyat.Text = alimfiyatı.ToString("N");
        }

        private void txt_birimfiyat_Leave(object sender, EventArgs e)
        {
            if (txt_birimfiyat.Text == "")
            {
                txt_birimfiyat.Text = "0";
                satisbirimfiyati = Convert.ToDecimal(txt_birimfiyat.Text);
                txt_birimfiyat.Text = satisbirimfiyati.ToString("N");
            }
            else
                satisbirimfiyati = Convert.ToDecimal(txt_birimfiyat.Text);
                txt_birimfiyat.Text = satisbirimfiyati.ToString("N");
           
        }

        private void txt_toplam_Leave(object sender, EventArgs e)
        {
            if (txt_toplam.Text == "")
            {
                txt_toplam.Text = "0";
                toplamfiyat = Convert.ToDecimal(txt_toplam.Text);
                txt_toplam.Text = toplamfiyat.ToString("N");
            }
            else
                toplamfiyat = Convert.ToDecimal(txt_toplam.Text);
                txt_toplam.Text = toplamfiyat.ToString("N");
        }

        private void txt_alimfiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
           //sadece rakkam ve virgül nokta falan girilmesi gerekiyor.

        }
    }
}
