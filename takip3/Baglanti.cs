using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace takip3
{
    class Baglanti
    {
        public OleDbConnection connection;
        public OleDbDataAdapter adaptor;
        public OleDbCommand komut;
        public OleDbDataReader dr;
        


        public void Baslat()
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=stoktakipdb.accdb");
            connection.Open();
        }

        public void Kapat()
        {
            //connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=stoktakipdb.accdb");
            connection.Close();
        }

    }
}
