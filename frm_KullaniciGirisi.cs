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
    public partial class frm_KullaniciGirisi : Form
    {
        public frm_KullaniciGirisi()
        {
            InitializeComponent();
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            KullaniciGirisi();
        }

        public static string kg_ad;
        public static int kg_id;
        public static string kg_acikad;
        public static string kg_email;
        private void KullaniciGirisi()
        {
            string sorgu = "SELECT * FROM TBL_KULLANICI WHERE K_KULLANICIADI=@K_KULLANICIADI AND K_PAROLA=@K_PAROLA";
            SqlCommand komut = new SqlCommand(sorgu, Connection.baglantim);
            komut.Parameters.AddWithValue("@K_KULLANICIADI", txt_kullanici.Text).SqlDbType = SqlDbType.NVarChar;
            komut.Parameters.AddWithValue("@K_PAROLA", txt_parola.Text).SqlDbType = SqlDbType.NVarChar;
            Connection.baglantim.Open();
            SqlDataReader oku = komut.ExecuteReader();
            bool bayrak1 = false;
            bool bayrak2 = false;
            while (oku.Read())
            {
                if (oku["K_KULLANICIADI"].ToString().Trim() == txt_kullanici.Text && oku["K_PAROLA"].ToString().Trim() == txt_parola.Text)
                {
                    bayrak1 = true;
                    kg_ad = oku["K_KULLANICIADI"].ToString();
                    kg_id = int.Parse(oku["K_ID"].ToString());
                    kg_acikad = oku["K_ISIM"].ToString();
                    kg_email = oku["K_EMAIL"].ToString();
                }
                if (oku["K_KULLANICIADI"].ToString().Trim() == txt_kullanici.Text)
                {
                    bayrak2 = true;
                }
            }
            Connection.baglantim.Close();

            if (bayrak1 == true)
            {
                frm_Anasayfa ac = new frm_Anasayfa();
                ac.Show();
                this.Hide();
            }
            if (bayrak1 == false && bayrak2 == true)
            {
                MessageBox.Show(this, "Geçersiz kullanıcı şifresi.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_parola.Clear();
                txt_parola.Focus();
            }
            if (bayrak1 == false && bayrak2 == false)
            {
                MessageBox.Show(this, "Geçersiz kullanıcı adı.", "Hata Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_kullanici.Clear();
                txt_parola.Clear();
                txt_kullanici.Focus();
            }
        }

        private void frm_KullaniciGirisi_Load(object sender, EventArgs e)
        {
            txt_kullanici.Focus();
            this.AcceptButton = btn_giris;
            ToolTip bilgi_mesaji = new ToolTip();
            bilgi_mesaji.SetToolTip(this.txt_kullanici, "Kullanıcı adınızı giriniz.");
            bilgi_mesaji.SetToolTip(this.txt_parola, "Parolanızı giriniz.");
            bilgi_mesaji.SetToolTip(this.btn_giris, "Giriş için tıklayın.");
            bilgi_mesaji.SetToolTip(this.btn_iptal, "İptal için tıklayın.");
        }
    }
}
