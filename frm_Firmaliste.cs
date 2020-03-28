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

namespace agentone
{
    public partial class frm_Firmaliste : Form
    {
        public frm_Firmaliste()
        {
            InitializeComponent();
        }

        public DataSet myDS = new DataSet();
        private void frm_Firmaliste_Load(object sender, EventArgs e)
        {
            //raporu dolduruyor.
            CrystalReport3 rpt = new CrystalReport3();
            try
            {
                //SqlConnection myConn = new SqlConnection("Data Source=(local);uid=sa;pwd=123;Initial Catalog=DOTNETMCY_AO");
                SqlCommand myComm = new SqlCommand();
                myComm.Connection = Connection.baglantim;
                myComm.CommandText = "SELECT * FROM TBL_FIRMA";
                myComm.CommandType = CommandType.Text;
                SqlDataAdapter myDataAdapter = new SqlDataAdapter();
                myDataAdapter.SelectCommand = myComm;

                myDataAdapter.Fill(myDS, "TBL_FIRMA");
                rpt.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (System.Exception HATA)
            {
                MessageBox.Show(this, HATA.ToString());
            }
        }
    }
}
