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
    public partial class frm_RenkBedenDagilimi : Form
    {
        public frm_RenkBedenDagilimi()
        {
            InitializeComponent();
        }

        private void frm_RenkBedenDagilimi_Load(object sender, EventArgs e)
        {
            BedenDagilimi();
            RenkDagilimi();
        }

        private void BedenDagilimi()
        {
            SqlDataAdapter ugcl = new SqlDataAdapter("SELECT B_DEGER FROM TBL_BEDEN ORDER BY B_DEGER", Connection.baglantim);
            DataSet ugcl_al = new DataSet();
            ugcl.Fill(ugcl_al, "TBL_BEDEN");
            DataTable ugcl_table = ugcl_al.Tables["TBL_BEDEN"];
            foreach (DataRow ugcl_dizi in ugcl_table.Rows)
            {
                cbl_beden.Items.Add(ugcl_dizi["B_DEGER"]);
            }
        }

        private void RenkDagilimi()
        {
            SqlDataAdapter ugcl = new SqlDataAdapter("SELECT R_DEGER FROM TBL_RENK ORDER BY R_DEGER", Connection.baglantim);
            DataSet ugcl_al = new DataSet();
            ugcl.Fill(ugcl_al, "TBL_RENK");
            DataTable ugcl_table = ugcl_al.Tables["TBL_RENK"];
            foreach (DataRow ugcl_dizi in ugcl_table.Rows)
            {
                cbl_renk.Items.Add(ugcl_dizi["R_DEGER"]);
            }
        }
    }
}
