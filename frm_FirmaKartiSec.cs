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
    public partial class frm_FirmaKartiSec : Form
    {
        frm_TeklifYeniKayit TeklifYeniKayit = null;
        public frm_FirmaKartiSec(frm_TeklifYeniKayit _TeklifYeniKayit)
        {
            TeklifYeniKayit = _TeklifYeniKayit;
            InitializeComponent();
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

        private void frm_FirmaKartiSec_Load(object sender, EventArgs e)
        {
            FirmaKartiDataGridDoldur();
        }

        private void btn_ara_Click(object sender, EventArgs e)
        {

        }

        public static int ImalatciFirmaIDSec;
        public static string ImalatciFirmaKoduSec;
        public static int IthalatciFirmaIDSec;
        public static string IthalatciFirmaKoduSec;
        public static int AliciFirmaIDSec;
        public static string AliciFirmaKoduSec;

        private void dgv_firmakartisec_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ImalatciFirmaIDSec = Int32.Parse(dgv_firmakartisec.CurrentRow.Cells[0].Value.ToString());
            IthalatciFirmaIDSec = Int32.Parse(dgv_firmakartisec.CurrentRow.Cells[0].Value.ToString());
            AliciFirmaIDSec = Int32.Parse(dgv_firmakartisec.CurrentRow.Cells[0].Value.ToString());

            ImalatciFirmaKoduSec = dgv_firmakartisec.CurrentRow.Cells[1].Value.ToString();
            IthalatciFirmaKoduSec = dgv_firmakartisec.CurrentRow.Cells[1].Value.ToString();
            AliciFirmaKoduSec = dgv_firmakartisec.CurrentRow.Cells[1].Value.ToString();
        }

        private void dgv_firmakartisec_DoubleClick(object sender, EventArgs e)
        {
            FirmaSec();
            DegiskenleriBosalt();
            this.Close();
        }

        private void FirmaSec()
        {
            ///frm_TeklifYeniKayit sayfasından gelen firma seçerken hangi buttona basti ise o amaç için firma bilgisi textboxa gönderiliyor
            ///imalatcı firma için 1
            ///ithalatci firma için 2
            ///alıcı firma için 3

            if (frm_TeklifYeniKayit.FirmaSecerkenHangiButtonaBasti == 1)
            {
                frm_TeklifYeniKayit.ImalatciFirmaID = ImalatciFirmaIDSec;
                TeklifYeniKayit.txt_imalatcifirma.Text = ImalatciFirmaKoduSec;
            }
            if (frm_TeklifYeniKayit.FirmaSecerkenHangiButtonaBasti == 2)
            {
                frm_TeklifYeniKayit.IthalatciFirmaID = IthalatciFirmaIDSec;
                TeklifYeniKayit.txt_ithalatcifirma.Text = IthalatciFirmaKoduSec;
            }
            if (frm_TeklifYeniKayit.FirmaSecerkenHangiButtonaBasti == 3)
            {
                frm_TeklifYeniKayit.AliciFirmaID = AliciFirmaIDSec;
                TeklifYeniKayit.txt_alicifirma.Text = AliciFirmaKoduSec;
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
            ImalatciFirmaIDSec=0;
            ImalatciFirmaKoduSec="";
            IthalatciFirmaIDSec=0;
            IthalatciFirmaKoduSec="";
            AliciFirmaIDSec=0;
            AliciFirmaKoduSec="";
        }

        private void btn_yenifirmakartiac_Click(object sender, EventArgs e)
        {
            frm_FirmaYeniKayit ac = new frm_FirmaYeniKayit();
            ac.ShowDialog();
        }
    }
}
