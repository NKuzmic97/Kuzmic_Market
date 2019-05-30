using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Projekat2_NRT4416
{
    class Baza
    {
            OleDbConnection conn;

            public Baza()
            {
                this.conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='C:\baza\Prodavnica.mdb'";
            //conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = 'C:\Users\pc\Desktop\Kuzmic Market App\Prodavnica.mdb'";
            }
            public void OtvoriKonekciju()
            {
                if (conn != null)
                {
                    conn.Open();
                }
            }
            public void ZatvoriKonekciju()
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            public OleDbConnection Conn
            { get { return conn; } set { conn = value; } }
    }
}
