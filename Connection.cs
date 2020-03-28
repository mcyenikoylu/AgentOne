using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace agentone
{
    class Connection
    {
        public static SqlConnection baglantim = new SqlConnection(@"Server=79.171.16.13;Database=DOTNETMCY_AO;User ID=limagao;Password=EssEAGAO09;");
        //public static SqlConnection baglantim = new SqlConnection("Data Source=(local);uid=sa;pwd=123;Initial Catalog=DOTNETMCY_AO");
        
    }
}
