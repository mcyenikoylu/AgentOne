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
    public partial class frm_TeklifDuzenle : Form
    {
        public frm_TeklifDuzenle()
        {
            InitializeComponent();
        }

        private void frm_TeklifDuzenle_Load(object sender, EventArgs e)
        {
            TextboxlariDoldur();
            Combolar_Doldu();
            UrunGrubuCheckList();
            UrunGrubunuAlanlariniIsaretle();
            Resim1Doldur();
            Resim2Doldur();
            ParaAlanlarִ±naSִ±fִ±rDoldur();
        }

        private void Combolari_Doldur(ComboBox combobox, String Sorgum, String Tablom, String KolonAdim)
        {
            combobox.Text = "Seֳ§iniz";
            combobox.Items.Add("Seֳ§iniz");

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
            //comboboxlarִ± dolduruyorum.
            ComboBox[] ComboBoxlarim = new ComboBox[8] { cb_urundurumu, cb_teklifdurumu, cb_yuklemesekli, cb_odemesekli, cb_birimfiyat, cb_miktar, cb_toplam, cb_alimfiyatbirimi };

            String[] Sorgularim = new string[8] {"SELECT UD_DEGER FROM TBL_URUNDURUM ORDER BY UD_DEGER",
            "SELECT TD_DEGER FROM TBL_TEKLIFDURUM ORDER BY TD_DEGER",
            "SELECT YS_DEGER FROM TBL_YUKLEMESEKLI ORDER BY YS_DEGER",
            "SELECT OS_DEGER FROM TBL_ODEMESEKLI ORDER BY OS_DEGER",
            "SELECT PB_DEGER FROM TBL_PARABIRIMI ORDER BY PB_DEGER",
            "SELECT MB_DEGER FROM TBL_MIKTARBIRIMI ORDER BY MB_DEGER",
            "SELECT PB_DEGER FROM TBL_PARABIRIMI ORDER BY PB_DEGER",
            "SELECT PB_DEGER FROM TBL_PARABIRIMI ORDER BY PB_DEGER",};

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

        private void UrunGrubunuAlanlariniIsaretle()
        {
            for (int c1 = 0; c1 < clb_urungrubu.Items.Count; c1++)
            {
                clb_urungrubu.SetItemChecked(c1, false);

            }
            String vericek = "SELECT * FROM TBL_TEKLIF WHERE T_ID='" + frm_Teklif.teklifid + "'";
            SqlCommand comm = new SqlCommand(vericek, Connection.baglantim);
            string foo1 = "";
            comm.Parameters.AddWithValue("@T_URUNGRUBU", foo1).SqlDbType = SqlDbType.Text;

            Connection.baglantim.Open();
            SqlDataReader verioku = comm.ExecuteReader();
            try
            {
                while (verioku.Read())
                {
                    foo1 = verioku["T_URUNGRUBU"].ToString();
                    string[] items1 = foo1.Split(',');
                    for (int i = 0; i < clb_urungrubu.Items.Count; i++)
                    {
                        for (int j = 0; j < items1.Length; j++)
                        {
                            if (clb_urungrubu.Items[i].ToString() == items1[j])
                          ווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווeckedItems.Count; virgul++)
                {
                    selectedlists += clb_urungrubu.CheckedItems[virgul].ToString();
                    if (virgul < clb_urungrubu.CheckedItems.Count - 1)
                        selectedlists += ",";
                }
            }
        }

        private void Resim1Doldur()
        {
            SqlDataAdapter Da;
            DataTable Dt;
            Da = new SqlDataAdapter("SELECT * FROM TBL_TEKLIF WHERE T_ID='" + frm_Teklif.teklifid + "'", Cווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווglantim);
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
                System.IO.MווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווIMI", cb_birimfiyat.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("T_MIKTAR", txt_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("T_MIKTAROLCUBIRIMI", cb_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("T_TOPLAMFIYAT", txt_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("T_TOPLAMFIYATPARABIRIMI", cb_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("T_NUMUNEALIMTARIHI", dtp_alimtarihi.Text).SqlDbType = SqlDbType.DateTime;
            comm.Parameters.AddWithValue("T_NUMUNEGONDERIMTARIHI", dtp_gonderim.Text).SqlDbType = SqlDbType.DateTime;
            comm.Parameters.AddWithValue("T_NUMUNEIADETARIHI", dtp_iadetarihi.Text).SqlDbType = SqlDbType.DateTime;
            comm.Parameters.AddWithValue("T_NUMUNEALIMADET", txt_alimadet.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("T_NUMUNEALIMRENK", txt_alimrenk.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("T_NUMUNEIADEADET", txt_iadeadet.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("T_NUMUNEIADERENK", txt_iaderenk.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("T_NUMUNEGONDERIMADET", txt_gonderimadet.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("T_NUMUNEGONDERIMRENK", txt_gonderimrenk.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("T_NUMUNEALIMACIKLAMA", rtb_alimaciklama.Text).SqlDbType = SqlDbType.Text;
            comm.Parameters.AddWithValue("T_NUMUNEGONDERIMACIKLAMA", rtb_gonderimaciklama.Text).SqlDbType = SqlDbType.Text;
            comm.Parameters.AddWithValue("T_ALIMFIYATI", txt_alimfiyat.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("T_ALIMFIYATBIRIMI", cb_alimfiyatbirimi.Text).SqlDbType = SqlDbType.NVarChar;
            
            Connוווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווו         txt_kalite.Text = verioku["T_KALITE"].ToString();
                    rtb_aciklama.Text = verioku["T_ACIKLAMA"].ToString();
                    cb_urundurumu.Text = verioku["T_URUNDURUMU"].ToString();
                    cb_yuklemesekli.Text = verioku["T_YUKLEMESEKLI"].ToString();
                    cb_teklifdurumu.Text = verioku["T_TEKLIFDURUMU"].ToString();
                    cb_odemesekli.Text = verioku["T_ODEMESEKLI"].ToString();
                    txt_birimfiyat.Text = verioku["T_BIRIוווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווו               dtp_gonderim.Text = verioku["T_NUMUNEGONDERIMTARIHI"].ToString();
                    dtp_iadetarihi.Text = verioku["T_NUMUNEIADETARIHI"].ToString();
                    txt_alimadet.Text = verioku["T_NUMUNEALIMADET"].ToString();
                    txt_alimrenk.Text = verioku["T_NUMUNEALIMRENK"].ToString();
                    txt_iadeadet.Text = verioku["T_NUMUNEIADEADET"].ToString();
                    txt_iaderenk.Text = verioku["T_NUMUNEIADERENK"].ToString();
                    txt_gonderimadet.Text = verioku["T_NUMUNEGONDERIMADET"].ToString();
                    txt_gonderimrenk.Text = verioku["T_NUMUNEGONDERIMRENK"].ToString();
                    rtb_alimaciklama.Text = verioku["T_NUMUNEALIMACIKLAMA"].ToString();
                    rtb_gonderimaciklama.Text = verioku["T_NUMUNEGONDERIMACIKLAMA"].ToString();
                    txt_alimfiyat.Text = verioku["T_ALIMFIYATI"].ToString();
                    cb_alimfiyatbirimi.Text = verioku["T_ALIMFIYATBIRIMI"].ToString();
                }
            }
            finally
            {
                verioku.Close();
                Connection.baglantim.Close();
            }
        }
        
        private void btn_resimekle1_Click(object sender, EventArgs e)
        {
            ResimEkle1();
        }

        private void btn_resimekle2_Click(object sender, EventArgs e)
        {
            ResimEkle2();
        }

        int resim1eklendi = 0; //resim gֳ¼ncellemesi yapִ±lmadִ±.
        byte[] resim1 = null; //resim byte tipine ֳ§evrilerek sql e yazִ±lִ±yor.
        private void ResimEkle1()
        {
            //RESִ°M1
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
                resim1eklendi = 1; //birinci resim gֳ¼ncellendi.
            }
            else
            {
                MessageBox.Show("Resim1 dosyasִ± seֳ§mediniz!");
            }
        }

        int resim2eklendi = 0; //resim gֳ¼ncellemesi yapִ±ldִ±mִ±.
        byte[] resim2 = null; //resim byte tipine ֳ§evrilerek sql e yazִ±lִ±yor.
        private void ResimEkle2()
        {
            //RESִ°M2
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
                resim2eklendi = 1; //ikinci resim gֳ¼ncellendi.
            }
            else
            {
                MessageBox.Show("Resim2 dosyasִ± seֳ§mediniz!");
            } 
        }

        private void Duzenle()
        {
            if (resim1eklendi == 1 && resim2eklendi == 1) //1. ve 2. resimler gֳ¼ncellenmek iֳ§in seֳ§ildiler.
            {
                ResimlerGuncellenmekIcִ±nEklendi();
            }
            else if (resim1eklendi == 1) //sadece resim1 eklendiyse
            {
                Resim1Eklendi();
            }
            else if (resim2eklendi == 1) //sadece resim2 eklendiyse
            {
                Resim2Eklendi();
            }

            if (resim1eklendi == 0 && resim2eklendi == 0) //1. ve 2. resimler seֳ§ilmediler.
            {
                ResimlerEklenmedi();
            }
        } //gֳ¼ncelleme iֵlemi

        //Resimlerin eklenmesi ve eklenmemesi yֳ¼zֳ¼nden verilen hatalar sebebi ile farklִ± farklִ± INTO sorgusu yapmak zorunda kaldִ±m.
        private void ResimlerGuncellenmekIcִ±nEklendi()
        {
            UrunGrubuCheckListAralarinaVirgul();
            String VerileriGuncelle = "UPDATE TBL_TEKLIF SET T_K_ID=@T_K_ID, T_KULLANICIADI=@T_KULLANICIADI, T_URUNGRUBU=@T_URUNGRUBU, T_URUNDURUMU=@T_URUNDURUMU, T_TEKLIFDURUMU=@T_TEKLIFDURUMU, T_ALICISIRKET=@T_ALICISIRKET, T_IMALATCIFIRMA=@T_IMALATCIFIRMA, T_IHRACATCIFIRMA=@T_IHRACATCIFIRMA, T_URUNADI=@T_URUNADI, T_KALITE=@T_KALITE, T_YUKLEMESEKLI=@T_YUKLEMESEKLI, T_ODEMESEKLI=@T_ODEMESEKLI, T_ACIKLAMA=@T_ACIKLAMA, T_BIRIMFIYAT=@T_BIRIMFIYAT, T_TOPLAMFIYAT=@T_TOPLAMFIYAT, T_MIKTAR=@T_MIKTAR, T_RESIM1=@T_RESIM1, T_RESIM2=@T_RESIM2, T_ALIMFIYATI=@T_ALIMFIYATI, T_ALIMFIYATBIRIMI=@T_ALIMFIYATBIRIMI, T_BIRIMFIYATPARABIRIMI=@T_BIRIMFIYATPARABIRIMI, T_MIKTAROLCUBIRIMI=@T_MIKTAROLCUBIRIMI, T_TOPLAMFIYATPARABIRIMI=@T_TOPLAMFIYATPARABIRIMI, T_NUMUNEALIMTARIHI=@T_NUMUNEALIMTARIHI, T_NUMUNEGONDERIMTARIHI=@T_NUMUNEGONDERIMTARIHI, T_NUMUNEIADETARIHI=@T_NUMUNEIADETARIHI, T_NUMUNEALIMADET=@T_NUMUNEALIMADET, T_NUMUNEALIMRENK=@T_NUMUNEALIMRENK, T_NUMUNEIADEADET=@T_NUMUNEIADEADET, T_NUMUNEIADERENK=@T_NUMUNEIADERENK, T_NUMUNEGONDERIMADET=@T_NUMUNEGONDERIMADET, T_NUMUNEGONDERIMRENK=@T_NUMUNEGONDERIMRENK, T_NUMUNEALIMACIKLAMA=@T_NUMUNEALIMACIKLAMA, T_NUMUNEGONDERIMACIKLAMA=@T_NUMUNEGONDERIMACIKLAMA WHERE T_ID=@T_ID";
            SqlCommand cmd = new SqlCommand(VerileriGuncelle, Connection.baglantim);
            cmd.Parameters.AddWithValue("@T_ID", frm_Teklif.teklifid).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_K_ID", frm_KullaniciGirisi.kg_id).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_KULLANICIADI", frm_KullaniciGirisi.kg_ad).SqlDbType = SqlDbType.NVarChar;
            //cmd.Parameters.AddWithValue("@T_RB_ID", 0).SqlDbType = SqlDbType.Int;
            //cmd.Parameters.AddWithValue("@T_OT_ID", 0).SqlDbType = SqlDbType.Int;
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
            cmd.Parameters.AddWithValue("@T_BIRIMFIYAT", txt_birimfiyat.Text).SqlDbType = SqlDbType.NVarChar;//son fiyat denilen deִerin sonradan ismi deִiֵti ve satִ±ֵ birim fiyatִ± oldu.
            cmd.Parameters.AddWithValue("@T_TOPLAMFIYAT", txt_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_MIKTAR", txt_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_RESIM1", SqlDbType.Image).Value = resim1;
            cmd.Parameters.AddWithValue("@T_RESIM2", SqlDbType.Image).Value = resim2;
            cmd.Parameters.AddWithValue("@T_ALIMFIYATI", txt_alimfiyat.Text).SqlDbType = SqlDbType.NVarChar;
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
                MessageBox.Show(this, "Teklif Kartִ± baֵarִ±yla gֳ¼ncellenmiֵtir.", "Bilgi Mesajִ±", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            catch (Exception HATA)
            {
                MessageBox.Show(this, "Veri tabanִ±na baִlanִ±lִ±rken bir hata oluֵtu.", "Hata Mesajִ±", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(this, HATA.ToString());
            }
            finally
            {
                Connection.baglantim.Close();
            }
        }
        private void ResimlerEklenmedi()
        {
            UrunGrubuCheckListAralarinaVirgul();
            String VerileriGuncelle = "UPDATE TBL_TEKLIF SET T_K_ID=@T_K_ID, T_KULLANICIADI=@T_KULLANICIADI, T_URUNGRUBU=@T_URUNGRUBU, T_URUNDURUMU=@T_URUNDURUMU, T_TEKLIFDURUMU=@T_TEKLIFDURUMU, T_ALICISIRKET=@T_ALICISIRKET, T_IMALATCIFIRMA=@T_IMALATCIFIRMA, T_IHRACATCIFIRMA=@T_IHRACATCIFIRMA, T_URUNADI=@T_URUNADI, T_KALITE=@T_KALITE, T_YUKLEMESEKLI=@T_YUKLEMESEKLI, T_ODEMESEKLI=@T_ODEMESEKLI, T_ACIKLAMA=@T_ACIKLAMA, T_BIRIMFIYAT=@T_BIRIMFIYAT, T_TOPLAMFIYAT=@T_TOPLAMFIYAT, T_MIKTAR=@T_MIKTAR, T_ALIMFIYATI=@T_ALIMFIYATI, T_ALIMFIYATBIRIMI=@T_ALIMFIYATBIRIMI, T_BIRIMFIYATPARABIRIMI=@T_BIRIMFIYATPARABIRIMI, T_MIKTAROLCUBIRIMI=@T_MIKTAROLCUBIRIMI, T_TOPLAMFIYATPARABIRIMI=@T_TOPLAMFIYATPARABIRIMI, T_NUMUNEALIMTARIHI=@T_NUMUNEALIMTARIHI, T_NUMUNEGONDERIMTARIHI=@T_NUMUNEGONDERIMTARIHI, T_NUMUNEIADETARIHI=@T_NUMUNEIADETARIHI, T_NUMUNEALIMADET=@T_NUMUNEALIMADET, T_NUMUNEALIMRENK=@T_NUMUNEALIMRENK, T_NUMUNEIADEADET=@T_NUMUNEIADEADET, T_NUMUNEIADERENK=@T_NUMUNEIADERENK, T_NUMUNEGONDERIMADET=@T_NUMUNEGONDERIMADET, T_NUMUNEGONDERIMRENK=@T_NUMUNEGONDERIMRENK, T_NUMUNEALIMACIKLAMA=@T_NUMUNEALIMACIKLAMA, T_NUMUNEGONDERIMACIKLAMA=@T_NUMUNEGONDERIMACIKLAMA WHERE T_ID=@T_ID";
            SqlCommand cmd = new SqlCommand(VerileriGuncelle, Connection.baglantim);
            cmd.Parameters.AddWithValue("@T_ID", frm_Teklif.teklifid).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_K_ID", frm_KullaniciGirisi.kg_id).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_KULLANICIADI", frm_KullaniciGirisi.kg_ad).SqlDbType = SqlDbType.NVarChar;
            //cmd.Parameters.AddWithValue("@T_RB_ID", 0).SqlDbType = SqlDbType.Int;
            //cmd.Parameters.AddWithValue("@T_OT_ID", 0).SqlDbType = SqlDbType.Int;
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
            cmd.Parameters.AddWithValue("@T_BIRIMFIYAT", txt_birimfiyat.Text).SqlDbType = SqlDbType.NVarChar;//son fiyat denilen deִerin sonradan ismi deִiֵti ve satִ±ֵ birim fiyatִ± oldu.
            cmd.Parameters.AddWithValue("@T_TOPLAMFIYAT", txt_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_MIKTAR", txt_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_ALIMFIYATI", txt_alimfiyat.Text).SqlDbType = SqlDbType.NVarChar;
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
                MessageBox.Show(this, "Teklif Kartִ± baֵarִ±yla gֳ¼ncellenmiֵtir.", "Bilgi Mesajִ±", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            catch (Exception HATA)
            {
                MessageBox.Show(this, "Veri tabanִ±na baִlanִ±lִ±rken bir hata oluֵtu.", "Hata Mesajִ±", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            String VerileriGuncelle = "UPDATE TBL_TEKLIF SET T_K_ID=@T_K_ID, T_KULLANICIADI=@T_KULLANICIADI, T_URUNGRUBU=@T_URUNGRUBU, T_URUNDURUMU=@T_URUNDURUMU, T_TEKLIFDURUMU=@T_TEKLIFDURUMU, T_ALICISIRKET=@T_ALICISIRKET, T_IMALATCIFIRMA=@T_IMALATCIFIRMA, T_IHRACATCIFIRMA=@T_IHRACATCIFIRMA, T_URUNADI=@T_URUNADI, T_KALITE=@T_KALITE, T_YUKLEMESEKLI=@T_YUKLEMESEKLI, T_ODEMESEKLI=@T_ODEMESEKLI, T_ACIKLAMA=@T_ACIKLAMA, T_BIRIMFIYAT=@T_BIRIMFIYAT, T_TOPLAMFIYAT=@T_TOPLAMFIYAT, T_MIKTAR=@T_MIKTAR, T_RESIM1=@T_RESIM1, T_ALIMFIYATI=@T_ALIMFIYATI, T_ALIMFIYATBIRIMI=@T_ALIMFIYATBIRIMI, T_BIRIMFIYATPARABIRIMI=@T_BIRIMFIYATPARABIRIMI, T_MIKTAROLCUBIRIMI=@T_MIKTAROLCUBIRIMI, T_TOPLAMFIYATPARABIRIMI=@T_TOPLAMFIYATPARABIRIMI, T_NUMUNEALIMTARIHI=@T_NUMUNEALIMTARIHI, T_NUMUNEGONDERIMTARIHI=@T_NUMUNEGONDERIMTARIHI, T_NUMUNEIADETARIHI=@T_NUMUNEIADETARIHI, T_NUMUNEALIMADET=@T_NUMUNEALIMADET, T_NUMUNEALIMRENK=@T_NUMUNEALIMRENK, T_NUMUNEIADEADET=@T_NUMUNEIADEADET, T_NUMUNEIADERENK=@T_NUMUNEIADERENK, T_NUMUNEGONDERIMADET=@T_NUMUNEGONDERIMADET, T_NUMUNEGONDERIMRENK=@T_NUMUNEGONDERIMRENK, T_NUMUNEALIMACIKLAMA=@T_NUMUNEALIMACIKLAMA, T_NUMUNEGONDERIMACIKLAMA=@T_NUMUNEGONDERIMACIKLAMA WHERE T_ID=@T_ID";
            SqlCommand cmd = new SqlCommand(VerileriGuncelle, Connection.baglantim);
            cmd.Parameters.AddWithValue("@T_ID", frm_Teklif.teklifid).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_K_ID", frm_KullaniciGirisi.kg_id).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_KULLANICIADI", frm_KullaniciGirisi.kg_ad).SqlDbType = SqlDbType.NVarChar;
            //cmd.Parameters.AddWithValue("@T_RB_ID", 0).SqlDbType = SqlDbType.Int;
            //cmd.Parameters.AddWithValue("@T_OT_ID", 0).SqlDbType = SqlDbType.Int;
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
            cmd.Parameters.AddWithValue("@T_BIRIMFIYAT", txt_birimfiyat.Text).SqlDbType = SqlDbType.NVarChar;//son fiyat denilen deִerin sonradan ismi deִiֵti ve satִ±ֵ birim fiyatִ± oldu.
            cmd.Parameters.AddWithValue("@T_TOPLAMFIYAT", txt_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_MIKTAR", txt_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_RESIM1", SqlDbType.Image).Value = resim1;
            cmd.Parameters.AddWithValue("@T_ALIMFIYATI", txt_alimfiyat.Text).SqlDbType = SqlDbType.NVarChar;
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
                MessageBox.Show(this, "Teklif Kartִ± baֵarִ±yla gֳ¼ncellenmiֵtir.", "Bilgi Mesajִ±", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            catch (Exception HATA)
            {
                MessageBox.Show(this, "Veri tabanִ±na baִlanִ±lִ±rken bir hata oluֵtu.", "Hata Mesajִ±", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            String VerileriGuncelle = "UPDATE TBL_TEKLIF SET T_K_ID=@T_K_ID, T_KULLANICIADI=@T_KULLANICIADI, T_URUNGRUBU=@T_URUNGRUBU, T_URUNDURUMU=@T_URUNDURUMU, T_TEKLIFDURUMU=@T_TEKLIFDURUMU, T_ALICISIRKET=@T_ALICISIRKET, T_IMALATCIFIRMA=@T_IMALATCIFIRMA, T_IHRACATCIFIRMA=@T_IHRACATCIFIRMA, T_URUNADI=@T_URUNADI, T_KALITE=@T_KALITE, T_YUKLEMESEKLI=@T_YUKLEMESEKLI, T_ODEMESEKLI=@T_ODEMESEKLI, T_ACIKLAMA=@T_ACIKLAMA, T_BIRIMFIYAT=@T_BIRIMFIYAT, T_TOPLAMFIYAT=@T_TOPLAMFIYAT, T_MIKTAR=@T_MIKTAR, T_RESIM2=@T_RESIM2, T_ALIMFIYATI=@T_ALIMFIYATI, T_ALIMFIYATBIRIMI=@T_ALIMFIYATBIRIMI, T_BIRIMFIYATPARABIRIMI=@T_BIRIMFIYATPARABIRIMI, T_MIKTAROLCUBIRIMI=@T_MIKTAROLCUBIRIMI, T_TOPLAMFIYATPARABIRIMI=@T_TOPLAMFIYATPARABIRIMI, T_NUMUNEALIMTARIHI=@T_NUMUNEALIMTARIHI, T_NUMUNEGONDERIMTARIHI=@T_NUMUNEGONDERIMTARIHI, T_NUMUNEIADETARIHI=@T_NUMUNEIADETARIHI, T_NUMUNEALIMADET=@T_NUMUNEALIMADET, T_NUMUNEALIMRENK=@T_NUMUNEALIMRENK, T_NUMUNEIADEADET=@T_NUMUNEIADEADET, T_NUMUNEIADERENK=@T_NUMUNEIADERENK, T_NUMUNEGONDERIMADET=@T_NUMUNEGONDERIMADET, T_NUMUNEGONDERIMRENK=@T_NUMUNEGONDERIMRENK, T_NUMUNEALIMACIKLAMA=@T_NUMUNEALIMACIKLAMA, T_NUMUNEGONDERIMACIKLAMA=@T_NUMUNEGONDERIMACIKLAMA WHERE T_ID=@T_ID";
            SqlCommand cmd = new SqlCommand(VerileriGuncelle, Connection.baglantim);
            cmd.Parameters.AddWithValue("@T_ID", frm_Teklif.teklifid).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_K_ID", frm_KullaniciGirisi.kg_id).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@T_KULLANICIADI", frm_KullaniciGirisi.kg_ad).SqlDbType = SqlDbType.NVarChar;
            //cmd.Parameters.AddWithValue("@T_RB_ID", 0).SqlDbType = SqlDbType.Int;
            //cmd.Parameters.AddWithValue("@T_OT_ID", 0).SqlDbType = SqlDbType.Int;
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
            cmd.Parameters.AddWithValue("@T_BIRIMFIYAT", txt_birimfiyat.Text).SqlDbType = SqlDbType.NVarChar;//son fiyat denilen deִerin sonradan ismi deִiֵti ve satִ±ֵ birim fiyatִ± oldu.
            cmd.Parameters.AddWithValue("@T_TOPLAMFIYAT", txt_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_MIKTAR", txt_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@T_RESIM2", SqlDbType.Image).Value = resim2;
            cmd.Parameters.AddWithValue("@T_ALIMFIYATI", txt_alimfiyat.Text).SqlDbType = SqlDbType.NVarChar;
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
                MessageBox.Show(this, "Teklif Kartִ± baֵarִ±yla gֳ¼ncellenmiֵtir.", "Bilgi Mesajִ±", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
            }
            catch (Exception HATA)
            {
                MessageBox.Show(this, "Veri tabanִ±na baִlanִ±lִ±rken bir hata oluֵtu.", "Hata Mesajִ±", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(this, HATA.ToString());
            }
            finally
            {
                Connection.baglantim.Close();
            }
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            Duzenle();
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_yazdִ±r_Click(object sender, EventArgs e)
        {
            //YAZDIR
        }

        private void btn_siparisinigoster_Click(object sender, EventArgs e)
        {
            //sipariֵi yok ise mesajbox olarak bildir. bunu iֳ§inde if ile bir sorgu yap.
        }

        private void btn_renkbedendagilimi_Click(object sender, EventArgs e)
        {
            //RENK BEDEN DAִILIMI   
        }

        private void btn_olcutablosu_Click(object sender, EventArgs e)
        {
            //OLCU TABLOSU
        }

        private void ParaAlanlarִ±naSִ±fִ±rDoldur()
        {
            if (txt_alimfiyat.Text == "")
            {
                txt_alimfiyat.Text = "0,00";
            }
            if (txt_birimfiyat.Text == "")
            {
                txt_birimfiyat.Text = "0,00";
            }
            if (txt_toplam.Text == "")
            {
                txt_toplam.Text = "0,00";
            }
        }

        decimal alimfiyatִ±;
        decimal satisbirimfiyati;
        decimal toplamfiyat;
        private void txt_alimfiyat_Leave(object sender, EventArgs e)
        {
            if (txt_alimfiyat.Text == "")
            {
                txt_alimfiyat.Text = "0";
                alimfiyatִ± = Convert.ToDecimal(txt_alimfiyat.Text);
                txt_alimfiyat.Text = alimfiyatִ±.ToString("N");
            }
            else
                alimfiyatִ± = Convert.ToDecimal(txt_alimfiyat.Text);
                txt_alimfiyat.Text = alimfiyatִ±.ToString("N");
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
    }
}
