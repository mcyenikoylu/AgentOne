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
    public partial class frm_SiparisFirmaKartiSec : Form
    {
        frm_SiparisYeniKayit SiparisYeniKayit = null;
        public frm_SiparisFirmaKartiSec(frm_SiparisYeniKayit _SiparisYeniKayit)
        {
            SiparisYeniKayit = _SiparisYeniKayit;
            InitializeComponent();
        }

        private void frm_SiparisFirmaKartiSec_Load(object sender, EventArgs e)
        {
            FirmaKartiDataGridDoldur();
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_sec_Click(object sender, EventArgs e)
        {
            FirmaSec();
            DegiskenleriBosalt();
            this.Close();
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {

        }

        private void FirmaSec()
        {
            ///frm_TeklifYeniKayit sayfasından gelen firma seçerken hangi buttona basti ise o amaç için firma bilgisi textboxa gönderiliyor
            ///imalatcı firma için 1
            ///ithalatci firma için 2
            ///alıcı firma için 3

            if (frm_SiparisYeniKayit.FirmaSecerkenHangiButtonaBasti == 1)
            {
                frm_SiparisYeniKayit.SiparisImalatciFirmaID = SiparisImalatciFirmaIDSec;
                SiparisYeniKayit.txt_imalatcifirma.Text = SiparisImalatciFirmaKoduSec;
                SiparisYeniKayit.txt_imalatciAcikAdi.Text = SiparisImalatciFirmaAcikAdi;
                SiparisYeniKayit.txt_imalatciFaks.Text = SiparisImalatciFirmaFaks;
                SiparisYeniKayit.txt_imalatciIlgiliKisi.Text = SiparisImalatciFirmaIlgiliKisi;
            }
            if (frm_SiparisYeniKayit.FirmaSecerkenHangiButtonaBasti == 2)
            {
                frm_SiparisYeniKayit.SiparisIthalatciFirmaID = SiparisIthalatciFirmaIDSec;
                SiparisYeniKayit.txt_ithalatcifirma.Text = SiparisIthalatciFirmaKoduSec;
            }
            if (frm_SiparisYeniKayit.FirmaSecerkenHangiButtonaBasti == 3)
            {
                frm_SiparisYeniKayit.SiparisAliciFirmaID = SiparisAliciFirmaIDSec;
                SiparisYeniKayit.txt_alicifirma.Text = SiparisAliciFirmaKoduSec;
            }
        }

        private void FirmaKartiDataGridDoldur()
        {
            SqlDataAdapter verigetir = new SqlDataAdapter("SELECT * FROM TBL_FIRMA ORDER BY F_KODU", Connection.baglantim);
            DataSet al = new DataSet();
            verigetir.Fill(al, "TBL_FIRMA");
            dgv_firmakartisec.DataSource = al.Tables[0];
        }

        private void DegiskenleriBosalt()
        {
            SiparisImalatciFirmaIDSec = 0;
            SiparisImalatciFirmaKoduSec = "";
            SiparisIthalatciFirmaIDSec = 0;
            SiparisIthalatciFirmaKoduSec = "";
            SiparisAliciFirmaIDSec = 0;
            SiparisAliciFirmaKoduSec = "";
        }

        public static int SiparisImalatciFirmaIDSec;
        public static string SiparisImalatciFirmaKoduSec;
        public static string SiparisImalatciFirmaIlgiliKisi;
        public static string SiparisImalatciFirmaFaks;
        public static string SiparisImalatciFirmaAcikAdi;

        public static int SiparisIthalatciFirmaIDSec;
        public static string SiparisIthalatciFirmaKoduSec;
        public static int SiparisAliciFirmaIDSec;
        public static string SiparisAliciFirmaKoduSec;
        private void dgv_firmakartisec_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SiparisImalatciFirmaIDSec = Int32.Parse(dgv_firmakartisec.CurrentRow.Cells[0].Value.ToString());
            SiparisIthalatciFirmaIDSec = Int32.Parse(dgv_firmakartisec.CurrentRow.Cells[0].Value.ToString());
            SiparisAliciFirmaIDSec = Int32.Parse(dgv_firmakartisec.CurrentRow.Cells[0].Value.ToString());

            SiparisImalatciFirmaKoduSec = dgv_firmakartisec.CurrentRow.Cells[1].Value.ToString();
            SiparisImalatciFirmaAcikAdi = dgv_firmakartisec.CurrentRow.Cells[2].Value.ToString();
            SiparisImalatciFirmaIlgiliKisi = dgv_firmakartisec.CurrentRow.Cells[13].Value.ToString();
            SiparisImalatciFirmaFaks = dgv_firmakartisec.CurrentRow.Cells[6].Value.ToString();
            SiparisIthalatciFirmaKoduSec = dgv_firmakartisec.CurrentRow.Cells[1].Value.ToString();
            SiparisAliciFirmaKoduSec = dgv_firmakartisec.CurrentRow.Cells[1].Value.ToString();
       

        }

        private void dgv_firmakartisec_DoubleClick(object sender, EventArgs e)
        {
            FirmaSec();
            DegiskenleriBosalt();
            this.Close();
        }

        private void btn_yenifirmakartiac_Click(object sender, EventArgs e)
        {
            frm_FirmaYeniKayit ac = new frm_FirmaYeniKayit();
            ac.ShowDialog();
        }

    
    }
}
