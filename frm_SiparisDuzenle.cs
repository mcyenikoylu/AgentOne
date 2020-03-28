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
    public partial class frm_SiparisDuzenle : Form
    {
        public frm_SiparisDuzenle()
        {
            InitializeComponent();
        }

        private void frm_SiparisDuzenle_Load(object sender, EventArgs e)
        {
            Alanlarִ±Doldur();
            Resim1Doldur();
            Resim2Doldur();
            ParaAlanlarִ±naSִ±fִ±rDoldur();
        }

        private void Alanlarִ±Doldur()
        {
            String vericek = "SELECT * FROM TBL_SIPARIS WHERE S_ID='" + frm_Siparis.siparisid + "'";
            SqlCommand cmd = new SqlCommand(vericek, Connection.baglantim);
            cmd.Parameters.AddWithValue("@S_ID", txt_siparisid.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_T_ID", txt_teklifid.Text).SqlDbType = SqlDbType.NVarChar;
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
            cmd.Parameters.AddWithValue("@S_TUTAR", txt_tutar.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_ONODEME", txt_onodeme.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_KESINTI", txt_kesinti.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_KESINTIYUZDESI", txt_kesintiyuzde.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_EKODEME", txt_ekodeme.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_EKODEMENEDENI", txt_ekodemenedeni.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_PESIN", txt_pesin.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_PESINYUZDESI", txt_pesinyuzde.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_ONODEMEYUZDESI", txt_onodemeyuzde.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_TOPLAM", txt_toplam.Text).SqlDbType = SqlDוווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווו.Text).SqlDbType = SqlDbType.NVarChar;
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
            Connection.baglantim.Open();
            SqlDataReader verioku = cmd.ExecuteReader();
            try
            {
                while (verioku.Read())
                {
                    txt_siparisid.Text = verioku["S_ID"].ToString();
                    txt_teklifid.Text = verioku["S_T_ID"].ToString();
                    txt_alicifirma.Text = verioku["S_ALICIFIRMA"].ToString();
                    txt_imalatcifirma.Text = verioku["S_IMALATCIFIRMA"].ToString();
                    txt_ithalatcifirma.Text = verioku["S_IHRACATCIFIRMA"].ToString();
                    txt_urunadi.Text = verioku["S_URUNADI"].ToString();
                    txt_kalite.Text = verioku["S_KAILTE"].ToString();
                    txt_kumas.Text = verioku["S_KUMAS"].ToString();
                    txt_gramaj.Text = verioku["S_GRAMAJ"].ToString();
                    txt_imalatcisiparisno.Text = verioku["S_IMALATCISIPARISNUMARASI"].ToString();
                    txt_alicisiparisno.Text = verioku["S_ALICISIPARISNUMARASI"].ToString();
                    cb_odemesekli.Text = verioku["S_ODEMESEKLI"].ToString();
                    cb_yuklemesekli.Text = verioku["S_YUKLEMESEKLI"].ToString();
                    txt_paketleme.Text = verioku["S_PAKETLEME"].ToString();
                    dtp_siparistarihi.Text = verioku["S_SIPARISTARIHI"].ToString();
                    dtp_1yuklemetarihi.Text = verioku["S_1YUKLEMETARIHI"].ToString();
                    dtp_2yuklemetarihi.Text = verioku["S_2YUKLEMETARIHI"].ToString();
                    dtp_3yuklemetarihi.Text = verioku["S_3YUKLEMETARIHI"].ToString();
                    dtp_4yuklemetarihi.Text = verioku["S_4YUKLEMETARIHI"].ToString();
                    rtb_aciklama.Text = verioku["S_ACIKLAMA"].ToString();
                    txt_sonfiyat.Text = verioku["S_SONFIYAT"].ToString();
                    txt_miktar.Text = verioku["S_MIKTAR"].ToString();
                    cb_siparisdurumu.Text = verioku["S_SIPARISDURUMU"].ToString();
                    cb_urundurumu.Text = verioku["S_URUNDURUMU"].ToString();
                    txt_tutar.Text = verioku["S_TUTAR"].ToString();
                    txt_onodeme.Text = verioku["S_ONODEME"].ToString();
                    txt_kesinti.Text = verioku["S_KESINTI"].ToString();
                    txt_kesintiyuzde.Text = verioku["S_KESINTIYUZDESI"].ToString();
                    txt_ekodeme.Text = verioku["S_EKODEME"].ToString();
                    txt_ekodemenedeni.Text = verioku["S_EKODEMENEDENI"].ToString();
                    txt_pesin.Text = verioku["S_PESIN"].ToString();
                    txt_pesinyuzde.Text = verioku["S_PESINYUZDESI"].ToString();
                    txt_onodemeyuzde.Text = verioku["S_ONODEMEYUZDESI"].ToString();
                    txt_toplam.Text = verioku["S_TOPLAM"].ToString();
                    txt_toplambirim.Text = verioku["S_TOPLAMPARABIRIMI"].ToString();
                    txt_etbanstk.Text = verioku["S_ETBANSTK"].ToString();
                    txt_3065.Text = verioku["S_3065"].ToString();
                    cb_etiket.Text = verioku["S_ETIKET"].ToString();
                    txt_artiketno.Text = verioku["S_ARTIKELNO"].ToString();
                    txt_almanca.Text = verioku["S_ALMANCA"].ToString();
                    txt_fransizca.Text = verioku["S_FRANSIZCA"].ToString();
                    txt_italyanca.Text = verioku["S_ITALYANCA"].ToString();
                    txt_vp.Text = verioku["S_VP"].ToString();
                    txt_kkp.Text = verioku["S_KKP"].ToString();
                    txt_owpcode.Text = verioku["S_OWPCODE"].ToString();
                    txt_sezon.Text = verioku["S_SEZON"].ToString();
                    cb_sonfiyat.Text = verioku["S_SONFIYATBIRIM"].ToString();
                    cb_miktar.Text = verioku["S_MIKTARBIRIM"].ToString();
                    txt_tutarbirim.Text = verioku["S_TUTARBIRIM"].ToString();
                    tid = Convert.ToInt32(txt_teklifid.Text); //resim id 'sini alִ±p ResimXDoldur dֳ¶ndֳ¼ ile teklif tableִ±ndan alִ±nmasִ± iֳ§in.
                }
            }
            finally
            {
                verioku.Close();
                Connection.baglantim.Close();
            }
        }

        int tid = 0;
        private void Resim1Doldur()
        {
            SqlDataAdapter Da;
            DataTable Dt;
            Da = new SqlDataAdapter("SELECT * FROM TBL_TEKLIF WHERE T_ID='" + tid + "'", Connection.baglantim);
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
            Da = new SqlDataAdapter("SELECT * FROM TBL_TEKLIF WHERE T_ID='" + tid + "'", Connection.baglantim);
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
                System.IO.MemoryStream ms = new System.IO.ווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווprivate void btn_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            SiparisDuzenle();
        }

        private void SiparisDuzenle()
        {
            String VerileriGuncelle = "UPDATE TBL_SIPARIS SET S_T_ID=@S_T_ID, S_ALICIFIRMA=@S_ALICIFIRMA, S_IMALATCIFIRMA=@S_IMALATCIFIRMA, S_IHRACATCIFIRMA=@S_IHRACATCIFIRMA, S_URUNADI=@S_URUNADI, S_KAILTE=@S_KAILTE, S_KUMAS=@S_KUMAS, S_GRAMAJ=@S_GRAMAJ, S_IMALATCISIPARISNUMARASI=@S_IMALATCISIPARISNUMARASI, S_ALICISIPARISNUMARASI=@S_ALICISIPARISNUMARASI, S_ODEMESEKLI=@S_ODEMESEKLI, S_YUKLEMESEKLI=@S_YUKLEMESEKLI, S_PAKETLEME=@S_PAKETLEME, S_SIPARISTARIHI=@S_SIPARISTARIHI, S_1YUKLEMETARIHI=@S_1YUKLEMETARIHI, S_2YUKLEMETARIHI=@S_2YUKLEMETARIHI, S_3YUKLEMETARIHI=@S_3YUKLEMETARIHI, S_4YUKLEMETARIHI=@S_4YUKLEMETARIHI, S_ACIKLAMA=@S_ACIKLAMA, S_SONFIYAT=@S_SONFIYAT, S_MIKTAR=@S_MIKTAR, S_SIPARISDURUMU=@S_SIPARISDURUMU, S_URUNDURUMU=@S_URUNDURUMU, S_TUTAR=@S_TUTAR, S_ONODEME=@S_ONODEME, S_KESINTI=@S_KESINTI, S_KESINTIYUZDESI=@S_KESINTIYUZDESI, S_EKODEME=@S_EKODEME, S_EKODEMENEDENI=@S_EKODEMENEDENI, S_PESIN=@S_PESIN, S_PESINYUZDESI=@S_PESINYUZDESI, S_ONODEMEYUZDESI=@S_ONODEMEYUZDESI, S_TOPLAM=@S_TOPLAM, S_TOPLAMPARABIRIMI=@S_TOPLAMPARABIRIMI, S_ETBANSTK=@S_ETBANSTK, S_3065=@S_3065, S_ETIKET=@S_ETIKET, S_ARTIKELNO=@S_ARTIKELNO, S_ALMANCA=@S_ALMANCA, S_FRANSIZCA=@S_FRANSIZCA, S_ITALYANCA=@S_ITALYANCA, S_VP=@S_VP, S_KKP=@S_KKP, S_OWPCODE=@S_OWPCODE, S_SEZON=@S_SEZON, S_SONFIYATBIRIM=@S_SONFIYATBIRIM, S_MIKTARBIRIM=@S_MIKTARBIRIM, S_TUTARBIRIM=@S_TUTARBIRIM WHERE S_ID=@S_ID";
            SqlCommand cmd = new SqlCommand(VerileriGuncelle, Connection.baglantim);
            cmd.Parameters.AddWithValue("@S_ID", txt_siparisid.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_T_ID", txt_teklifid.Text).SqlDbType = SqlDbType.NVarChar;
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
            cmd.Parameters.AddWithValue("@S_TUTAR", txt_tutar.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_ONODEME", txt_onodeme.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_KESINTI", txt_kesinti.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_KESINTIYUZDESI", txt_kesintiyuzde.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_EKODEME", txt_ekodeme.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_EKODEMENEDENI", txt_ekodemenedeni.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_PESIN", txt_pesin.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_PESINYUZDESI", txt_pesinyuzde.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_ONODEMEYUZDESI", txt_onodemeyuzde.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_TOPLAM", txt_toplam.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_TOPLAMPARABIRIMI", txt_toplambirim.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_ETBANSTK", txt_etbanstk.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@S_3065", txt_3065.Text).SqlDbType = SqlDbType.NVarChar;
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
            try
            {
                Connection.baglantim.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(this, "Sipariֵ Kartִ± baֵarִ±yla gֳ¼ncellenmiֵtir.", "Bilgi Mesajִ±", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void ParaAlanlarִ±naSִ±fִ±rDoldur()
        {
            if(txt_3065.Text == "".Trim())
            {
                txt_3065.Text = "0,00";
            }

            if (txt_tutar.Text == "".Trim())
            {
                txt_tutar.Text = "0,00";
            }

            if (txt_toplam.Text == "".Trim())
            {
                txt_toplam.Text = "0,00";
            }

            if (txt_ekodeme.Text == "".Trim())
            {
                txt_ekodeme.Text = "0,00";
            }

            if (txt_kesinti.Text == "".Trim())
            {
                txt_kesinti.Text = "0,00";
            }

            if (txt_pesin.Text == "".Trim())
            {
                txt_pesin.Text = "0,00";
            }

            if (txt_onodeme.Text == "".Trim())
            {
                txt_onodeme.Text = "0,00";
            }

            if (txt_sonfiyat.Text == "".Trim())
            {
                txt_sonfiyat.Text = "0,00";
            }
            if (txt_alimfiyati.Text == "".Trim())
            {
                txt_alimfiyati.Text = "0,00";
            }
        }

        decimal txt3065;
        decimal txttutar;
        decimal txtonodeme;
        decimal txtkesinti;
        decimal txtpesin;
        decimal txtekodeme;
        decimal txttoplam;
        decimal txtsonfiyat; //sonfiyat = satִ±ֵfiyatִ± aynִ± ֵey... ottos programִ±ndaki ismi son fiyattִ±! ordan gelme bir alִ±ֵkanlִ±k!
        decimal txtalisfiyati;

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
            txt_sonfiyat.Teוווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווווו      {
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

        private void txt_alimfiyati_Leave(object sender, EventArgs e)
        {
            if (txt_alimfiyati.Text == "")
            {
                txt_alimfiyati.Text = "0";
                txtalisfiyati = Convert.ToDecimal(txt_alimfiyati.Text);
                txt_alimfiyati.Text = txtalisfiyati.ToString("N");
            }
            else
                txtalisfiyati = Convert.ToDecimal(txt_alimfiyati.Text);
                txt_alimfiyati.Text = txtalisfiyati.ToString("N");
        }

        private void btn_imalatcifirma_Click(object sender, EventArgs e)
        {
            //FirmaSecerkenHangiButtonaBasti = 1;
            //frm_SiparisFirmaKartiSec ac = new frm_SiparisFirmaKartiSec(this);
            //ac.ShowDialog();
        }

        private void btn_ithalatcifirma_Click(object sender, EventArgs e)
        {
            //FirmaSecerkenHangiButtonaBasti = 2;
            //frm_SiparisFirmaKartiSec ac = new frm_SiparisFirmaKartiSec(this);
            //ac.ShowDialog();
        }

        private void btn_alicifirma_Click(object sender, EventArgs e)
        {
            //FirmaSecerkenHangiButtonaBasti = 3;
            //frm_SiparisFirmaKartiSec ac = new frm_SiparisFirmaKartiSec(this);
            //ac.ShowDialog();
        }

    }
}
