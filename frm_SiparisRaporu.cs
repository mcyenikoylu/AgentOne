using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.SqlClient;
using System.Net.Mail;
using Microsoft.Office.Core;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Outlook;

namespace agentone
{
    public partial class frm_SiparisRaporu : Form
    {
        public frm_SiparisRaporu()
        {
            InitializeComponent();
        }

        public DataSet myDS = new DataSet();
        private void frm_SiparisRaporu_Load(object sender, EventArgs e)
        {
            //raporu dolduruyor.
            CrystalReport2 rpt = new CrystalReport2();
            try
            {
                //SqlConnection myConn = new SqlConnection("Data Source=(local);uid=sa;pwd=123;Initial Catalog=DOTNETMCY_AO");
                SqlCommand myComm = new SqlCommand();
                myComm.Connection = Connection.baglantim;
                myComm.CommandText = "SELECT * FROM TBL_SIPARIS WHERE S_ID='" + frm_Siparis.siparisid + "'";
                myComm.CommandType = CommandType.Text;
                SqlDataAdapter myDataAdapter = new SqlDataAdapter();
                myDataAdapter.SelectCommand = myComm;

                myDataAdapter.Fill(myDS, "TBL_SIPARIS");
                rpt.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (System.Exception HATA)
            {
                MessageBox.Show(this, HATA.ToString());
            }
        }

        private void btn_siparismailgonder_Click(object sender, EventArgs e)
        {
            //crystal reports raporunu word formatına çeviriyor.
            CrystalReport2 reportWord = new CrystalReport2();
            String strExportFile = "C:\\SiparisRaporu.doc";
            reportWord.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            reportWord.ExportOptions.ExportFormatType = ExportFormatType.WordForWindows;
            DiskFileDestinationOptions objOptions = new DiskFileDestinationOptions();
            objOptions.DiskFileName = strExportFile;
            reportWord.ExportOptions.DestinationOptions = objOptions;
            reportWord.SetDataSource(myDS);
            reportWord.Export();
            objOptions = null;
            reportWord = null;

            //wordu yeni bir mail sayfası açarak ekliyor.
            Microsoft.Office.Interop.Outlook.Application outlook = new Microsoft.Office.Interop.Outlook.Application();
            MailItem mailItem = (MailItem)outlook.CreateItem(OlItemType.olMailItem);
            mailItem.To = "Göndereceğiniz kişinin mail adresini yazınız.";
            mailItem.Subject = frm_Teklif.teklifid.ToString();
            mailItem.Attachments.Add("C:\\SiparisRaporu.doc", Microsoft.Office.Interop.Outlook.OlAttachmentType.olEmbeddeditem, 1, "SiparisRaporu");
            mailItem.Display(false); 
        }
    }
}
