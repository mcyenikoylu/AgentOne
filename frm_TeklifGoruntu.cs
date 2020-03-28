using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;

namespace agentone
{
    public partial class frm_TeklifGoruntu : Form
    {
        public frm_TeklifGoruntu()
        {
            InitializeComponent();
        }

        private void frm_TeklifGoruntu_Load(object sender, EventArgs e)
        {
            TextboxlariDoldur();
            UrunGrubunuDoldur();
            UrunGrubunuAlanlariniIsaretle();
            Resim1Doldur();
            Resim2Doldur();
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

        private void UrunGrubunuDoldur()
        {
            SqlDataAdapter akson = new SqlDataAdapter("SELECT * FROM TBL_URUNGRUP", Connection.baglantim);
            DataSet akson_al = new DataSet();
            akson.Fill(akson_al, "TBL_URUNGRUP");
            DataTable akson_masa = akson_al.Tables["TBL_URUNGRUP"];
            foreach (DataRow akson_dizi in akson_masa.Rows)
            {
                clb_urungrubu.Items.Add(akson_dizi["UG_DEGER"]);
            }
        }

        private void UrunGrubunuAlanlariniIsaretle()
        {
            for (int c1 = 0; c1 < clb_urungrubu.Items.Count; c1++)
            {
                clb_urungrubu.SetItemChecked(c1, false);

            }
            String vericek = "SELECT * FROM TBL_TEKLIF WHERE T_ID='"+frm_Teklif.teklifid+"'";
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
                                clb_urungrubu.SetItemChecked(i, true);
                        }
                    }
                }
            }
            finally
            {
                verioku.Close();
                Connection.baglantim.Close();
            }
        }

        private void TextboxlariDoldur()
        {
            String vericek = "SELECT * FROM TBL_TEKLIF WHERE T_ID='" + frm_Teklif.teklifid + "'";
            SqlCommand comm = new SqlCommand(vericek, Connection.baglantim);
            comm.Parameters.AddWithValue("@T_IMALATCIFIRMA", txt_imalatcifirma.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_IHRACATCIFIRMA", txt_ithalatcifirma.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_ALICISIRKET", txt_alicifirma.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_URUNADI", txt_urunadi.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_KALITE", txt_kalite.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_ACIKLAMA", rtb_aciklama.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_URUNDURUMU", cb_urundurumu.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_YUKLEMESEKLI", cb_yuklemesekli.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_TEKLIFDURUMU", cb_teklifdurumu.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_ODEMESEKLI", cb_odemesekli.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_BIRIMFIYAT", txt_birimfiyat.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_BIRIMFIYATPARABIRIMI", cb_birimfiyat.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_MIKTAR", txt_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_MIKTAROLCUBIRIMI", cb_miktar.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_TOPLAMFIYAT", txt_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_TOPLAMFIYATPARABIRIMI", cb_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_NUMUNEALIMTARIHI", dtp_alimtarihi.Text).SqlDbType = SqlDbType.DateTime;
            comm.Parameters.AddWithValue("@T_NUMUNEGONDERIMTARIHI", dtp_gonderim.Text).SqlDbType = SqlDbType.DateTime;
            comm.Parameters.AddWithValue("@T_NUMUNEIADETARIHI", dtp_iadetarihi.Text).SqlDbType = SqlDbType.DateTime;
            comm.Parameters.AddWithValue("@T_NUMUNEALIMADET", txt_alimadet.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_NUMUNEALIMRENK", txt_alimrenk.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_NUMUNEIADEADET", txt_iadeadet.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_NUMUNEIADERENK", txt_iaderenk.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_NUMUNEGONDERIMADET", txt_gonderimadet.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_NUMUNEGONDERIMRENK", txt_gonderimrenk.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_NUMUNEALIMACIKLAMA", rtb_alimaciklama.Text).SqlDbType = SqlDbType.Text;
            comm.Parameters.AddWithValue("@T_NUMUNEGONDERIMACIKLAMA", rtb_gonderimaciklama.Text).SqlDbType = SqlDbType.Text;
            comm.Parameters.AddWithValue("@T_ALIMFIYATI", txt_alimfiyat.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("@T_ALIMFIYATBIRIMI", cb_alimfiyatbirimi.Text).SqlDbType = SqlDbType.NVarChar;
            Connection.baglantim.Open();
            SqlDataReader verioku = comm.ExecuteReader();
            try
            {
                while (verioku.Read())
                {
                    txt_imalatcifirma.Text = verioku["T_IMALATCIFIRMA"].ToString();
                    txt_ithalatcifirma.Text = verioku["T_IHRACATCIFIRMA"].ToString();
                    txt_alicifirma.Text = verioku["T_ALICISIRKET"].ToString();
                    txt_urunadi.Text = verioku["T_URUNADI"].ToString();
                    txt_kalite.Text = verioku["T_KALITE"].ToString();
                    rtb_aciklama.Text = verioku["T_ACIKLAMA"].ToString();
                    cb_urundurumu.Text = verioku["T_URUNDURUMU"].ToString();
                    cb_yuklemesekli.Text = verioku["T_YUKLEMESEKLI"].ToString();
                    cb_teklifdurumu.Text = verioku["T_TEKLIFDURUMU"].ToString();
                    cb_odemesekli.Text = verioku["T_ODEMESEKLI"].ToString();
                    txt_birimfiyat.Text = verioku["T_BIRIMFIYAT"].ToString();
                    cb_birimfiyat.Text = verioku["T_BIRIMFIYATPARABIRIMI"].ToString();
                    txt_miktar.Text = verioku["T_MIKTAR"].ToString();
                    cb_miktar.Text = verioku["T_MIKTAROLCUBIRIMI"].ToString();
                    txt_toplam.Text = verioku["T_TOPLAMFIYAT"].ToString();
                    cb_toplam.Text = verioku["T_TOPLAMFIYATPARABIRIMI"].ToString();
                    dtp_alimtarihi.Text = verioku["T_NUMUNEALIMTARIHI"].ToString();
                    dtp_gonderim.Text = verioku["T_NUMUNEGONDERIMTARIHI"].ToString();
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
            ComboBox[] ComboBoxlarim = new ComboBox[7] { cb_urundurumu, cb_teklifdurumu, cb_yuklemesekli, cb_odemesekli, cb_birimfiyat, cb_miktar, cb_toplam };

            String[] Sorgularim = new string[7] {"SELECT UD_DEGER FROM TBL_URUNDURUM ORDER BY UD_DEGER",
            "SELECT TD_DEGER FROM TBL_TEKLIFDURUM ORDER BY TD_DEGER",
            "SELECT YS_DEGER FROM TBL_YUKLEMESEKLI ORDER BY YS_DEGER",
            "SELECT OS_DEGER FROM TBL_ODEMESEKLI ORDER BY OS_DEGER",
            "SELECT PB_DEGER FROM TBL_PARABIRIMI ORDER BY PB_DEGER",
            "SELECT MB_DEGER FROM TBL_MIKTARBIRIMI ORDER BY MB_DEGER",
            "SELECT PB_DEGER FROM TBL_PARABIRIMI ORDER BY PB_DEGER"};

            String[] TabloAdlarim = new string[7] {"TBL_URUNDURUM",
            "TBL_TEKLIFDURUM",
            "TBL_YUKLEMESEKLI",
            "TBL_ODEMESEKLI",
            "TBL_PARABIRIMI",
            "TBL_MIKTARBIRIMI",
            "TBL_PARABIRIMI"};

            String[] KolonAdlarim = new string[7] {"UD_DEGER",
            "TD_DEGER",
            "YS_DEGER",
            "OS_DEGER",
            "PB_DEGER",
            "MB_DEGER",
            "PB_DEGER"};

            for (int index = 0; index < 7; index++)
                Combolari_Doldur(ComboBoxlarim[index], Sorgularim[index], TabloAdlarim[index], KolonAdlarim[index]);

        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_yazdır_Click(object sender, EventArgs e)
        {
            frm_TeklifRaporu ac = new frm_TeklifRaporu();
            ac.ShowDialog();
        }

      
    }
}
