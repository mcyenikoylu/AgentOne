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
    public partial class frm_FirmaDuzenle : Form
    {
        public frm_FirmaDuzenle()
        {
            InitializeComponent();
        }

        private void btn_duzenle_Click(object sender, EventArgs e)
        {
            Duzenle();
            this.Close();
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
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
            ComboBox[] ComboBoxlarim = new ComboBox[3] { cb_grup, cb_durum, cb_ulke };

            String[] Sorgularim = new string[3] {"SELECT FG_DEGER FROM TBL_FIRMAGRUP ORDER BY FG_DEGER",
            "SELECT FD_DEGER FROM TBL_FIRMADURUM ORDER BY FD_DEGER",
            "SELECT U_DEGER FROM TBL_ULKE ORDER BY U_DEGER"};

            String[] TabloAdlarim = new string[3] {"TBL_FIRMAGRUP",
            "TBL_FIRMADURUM",
            "TBL_ULKE"};

            String[] KolonAdlarim = new string[3] {"FG_DEGER",
            "FD_DEGER",
            "U_DEGER"};

            for (int index = 0; index < 3; index++)
                Combolari_Doldur(ComboBoxlarim[index], Sorgularim[index], TabloAdlarim[index], KolonAdlarim[index]);

        }

        private void Duzenle()
        {
            String VerileriGuncelle = "UPDATE TBL_FIRMA SET F_KODU=@F_KODU, F_ACIKADI=@F_ACIKADI, F_ADRES=@F_ADRES, F_TEL1=@F_TEL1, F_TEL2=@F_TEL2, F_FAKS=@F_FAKS, F_IL=@F_IL, F_ILCE=@F_ILCE, F_ULKE=@F_ULKE, F_POSTAKODU=@F_POSTAKODU, F_WEBADRES=@F_WEBADRES, F_FEMAIL=@F_FEMAIL, F_ILGILIKISI=@F_ILGILIKISI, F_ILGILIKISIDAHILI=@F_ILGILIKISIDAHILI, F_ILGILIKISIEMAIL=@F_ILGILIKISIEMAIL, F_GRUP=@F_GRUP, F_DURUM=@F_DURUM, F_NOT=@F_NOT, F_TELCEP=@F_TELCEP, F_ILGILIKISICEPTEL=@F_ILGILIKISICEPTEL WHERE F_ID=@F_ID";
            SqlCommand cmd = new SqlCommand(VerileriGuncelle, Connection.baglantim);
            cmd.Parameters.AddWithValue("@F_ID", frm_Firma.firmaid).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@F_KODU", txt_firmakodu.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_ACIKADI", txt_firmaacikadi.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_ADRES", rtb_adres.Text).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@F_TEL1", txt_tel1.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_TEL2", txt_tel2.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_FAKS", txt_fakstel.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_IL", txt_il.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_ILCE", txt_ilce.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_ULKE", cb_ulke.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_POSTAKODU", txt_postakodu.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_WEBADRES", txt_web.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_FEMAIL", txt_email.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_ILGILIKISI", txt_ilgilikisi.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_ILGILIKISIDAHILI", txt_dahili.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_ILGILIKISIEMAIL", txt_ilgilikisiemail.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_GRUP", cb_grup.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_DURUM", cb_durum.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_NOT", rtb_not.Text).SqlDbType = SqlDbType.Text;
            cmd.Parameters.AddWithValue("@F_TELCEP", txt_ceptel.Text).SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.AddWithValue("@F_ILGILIKISICEPTEL", txt_ilgilikisiceptel.Text).SqlDbType = SqlDbType.NVarChar;
            try
                {
                    Connection.baglantim.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(this, "Firma Kartı başarıyla güncellenmiştir.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            catch
            {
                MessageBox.Show(this, "Veri tabanına bağlanılırken bir hata oluştu.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.baglantim.Close();
            }
        }

        private void frm_FirmaDuzenle_Load(object sender, EventArgs e)
        {
            Combolar_Doldu();
            TextboxlariDoldur();
        }

        private void TextboxlariDoldur()
        {
            String vericek = "SELECT * FROM TBL_FIRMA WHERE F_ID='" + frm_Firma.firmaid + "'";
            SqlCommand comm = new SqlCommand(vericek, Connection.baglantim);
            comm.Parameters.AddWithValue("F_KODU", txt_firmakodu.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_ACIKADI", txt_firmaacikadi.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_ADRES", rtb_adres.Text).SqlDbType = SqlDbType.Text;
            comm.Parameters.AddWithValue("F_TEL1", txt_tel1.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_TEL2", txt_tel2.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_FAKS", txt_fakstel.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_IL", txt_il.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_ILCE", txt_ilce.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_ULKE", cb_ulke.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_POSTAKODU", txt_postakodu.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_WEBADRES", txt_web.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_FEMAIL", txt_email.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_ILGILIKISI", txt_ilgilikisi.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_ILGILIKISIDAHILI", txt_dahili.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_ILGILIKISIEMAIL", txt_ilgilikisiemail.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_GRUP", cb_grup.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_DURUM", cb_durum.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_NOT", rtb_not.Text).SqlDbType = SqlDbType.Text;
            comm.Parameters.AddWithValue("F_TELCEP", txt_ceptel.Text).SqlDbType = SqlDbType.NVarChar;
            comm.Parameters.AddWithValue("F_ILGILIKISICEPTEL", txt_ilgilikisiceptel.Text).SqlDbType = SqlDbType.NVarChar;
            Connection.baglantim.Open();
            SqlDataReader verioku = comm.ExecuteReader();
            try
            {
                while (verioku.Read())
                {
                    txt_firmakodu.Text = verioku["F_KODU"].ToString();
                    txt_firmaacikadi.Text = verioku["F_ACIKADI"].ToString();
                    rtb_adres.Text = verioku["F_ADRES"].ToString();
                    txt_tel1.Text = verioku["F_TEL1"].ToString();
                    txt_tel2.Text = verioku["F_TEL2"].ToString();
                    txt_fakstel.Text = verioku["F_FAKS"].ToString();
                    txt_il.Text = verioku["F_IL"].ToString();
                    txt_ilce.Text = verioku["F_ILCE"].ToString();
                    cb_ulke.Text = verioku["F_ULKE"].ToString();
                    txt_postakodu.Text = verioku["F_POSTAKODU"].ToString();
                    txt_web.Text = verioku["F_WEBADRES"].ToString();
                    txt_email.Text = verioku["F_FEMAIL"].ToString();
                    txt_ilgilikisi.Text = verioku["F_ILGILIKISI"].ToString();
                    txt_dahili.Text = verioku["F_ILGILIKISIDAHILI"].ToString();
                    txt_ilgilikisiemail.Text = verioku["F_ILGILIKISIEMAIL"].ToString();
                    cb_grup.Text = verioku["F_GRUP"].ToString();
                    cb_durum.Text = verioku["F_DURUM"].ToString();
                    rtb_not.Text = verioku["F_NOT"].ToString();
                    txt_ceptel.Text = verioku["F_TELCEP"].ToString();
                    txt_ilgilikisiceptel.Text = verioku["F_ILGILIKISICEPTEL"].ToString();
                }
            }
            finally
            {
                verioku.Close();
                Connection.baglantim.Close();
            }
        }
    }
}
