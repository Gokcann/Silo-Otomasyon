using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace takip3
{
    public partial class urunekle : Form
    {
        public urunekle()
        {
            InitializeComponent();
        }
        Baglanti baglanti = new Baglanti();

        private void Button1_Click(object sender, EventArgs e)
        {
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("INSERT INTO urunlistesi (urun_grubu,urun_sinifi,m_yil,isin) VALUES (@item1,@item2,@item3,@item4)", baglanti.connection);
            baglanti.komut.Parameters.AddWithValue("@item1", comboBox1.SelectedItem.ToString());
            baglanti.komut.Parameters.AddWithValue("@item2", comboBox2.SelectedItem.ToString());
            baglanti.komut.Parameters.AddWithValue("@item3", comboBox3.SelectedItem.ToString());
            baglanti.komut.Parameters.AddWithValue("@item4", txtikod.Text.ToString());
            baglanti.komut.ExecuteNonQuery();
            baglanti.Kapat();
            MessageBox.Show("Ürün Eklendi");

            /*foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }*/

            /*SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vaio2\Desktop\takip3\takip3\stok_takip.mdf;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = baglanti.CreateCommand();
            komut.CommandText = "insert urunlistesi(urungrubu,urunsinifi,mahsul_yili,isinkod) VALUES (@urungrubu,@urunsinifi,@mahsul_yili,@isinkod) ";
            komut.Parameters.AddWithValue("@isinkod", txtikod.Text.ToString());
            komut.Parameters.AddWithValue("@urungrubu", comboBox1.Text.ToString());
            komut.Parameters.AddWithValue("@urunsinifi", comboBox2.Text.ToString());
            komut.Parameters.AddWithValue("@mahsul_yili", comboBox3.Text.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün Eklendi");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            */
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            urunlistele mm = new urunlistele();
            mm.Show();
        }

        private void Urunekle_Load(object sender, EventArgs e)
        {

            {
                baglanti.Baslat();
                baglanti.komut = new OleDbCommand("SELECT * FROM urungrubu", baglanti.connection);
                OleDbDataReader myDataReader = baglanti.komut.ExecuteReader();
                while (myDataReader.Read())
                {
                    comboBox1.Items.Add(myDataReader["urun_grubu"].ToString());

                }
            }
            
            {
                baglanti.komut = new OleDbCommand("SELECT * FROM urunsinifi", baglanti.connection);
                OleDbDataReader myDataReader2 = baglanti.komut.ExecuteReader();
                while (myDataReader2.Read())
                {
                    comboBox2.Items.Add(myDataReader2["urun_sinifi"].ToString());

                }
            }
            
            {
                baglanti.komut = new OleDbCommand("SELECT * FROM mahsulyil", baglanti.connection);
                OleDbDataReader myDataReader3 = baglanti.komut.ExecuteReader();
                while (myDataReader3.Read())
                {
                    comboBox3.Items.Add(myDataReader3["mahsul_yil"].ToString());

                }

                baglanti.Kapat();
            }
            


            //Data Source=VAIO26;Initial Catalog=C:\Users\devel\Desktop\takip3-Kopya\takip3-Kopya\takip3\stok_takip.mdf;Integrated Security=True
            /* SqlConnection baglanti = new SqlConnection(@"Data Source=VAIO26;Initial Catalog=C:\Users\devel\Desktop\takip3-Kopya\takip3-Kopya\takip3\stok_takip.mdf;Integrated Security=True");
             DataSet daset = new DataSet();
             baglanti.Open();
             SqlCommand komut = baglanti.CreateCommand();
             komut.CommandText = "select * from urunugrubu";

             SqlDataReader myDataReader = komut.ExecuteReader();

             while (myDataReader.Read())
             {
                 comboBox1.Items.Add(myDataReader["urunugrubu"].ToString());

             }
             {

                 SqlConnection baglanti1 = new SqlConnection(@"Data Source=VAIO26;Initial Catalog=C:\Users\devel\Desktop\takip3-Kopya\takip3-Kopya\takip3\stok_takip.mdf;Integrated Security=True");
                 DataSet daset1 = new DataSet();
                 baglanti1.Open();
                 SqlCommand komut1 = baglanti1.CreateCommand();
                 komut1.CommandText = "select * from urunsinifi";

                 SqlDataReader myDataReader1 = komut1.ExecuteReader();

                 while (myDataReader1.Read())
                 {
                     comboBox2.Items.Add(myDataReader1["urunsinifi"].ToString());


                 }
                 {

                     SqlConnection baglanti2 = new SqlConnection(@"Data Source=VAIO26;Initial Catalog=C:\Users\devel\Desktop\takip3-Kopya\takip3-Kopya\takip3\stok_takip.mdf;Integrated Security=True");
                     DataSet daset2 = new DataSet();
                     baglanti2.Open();
                     SqlCommand komut2 = baglanti2.CreateCommand();
                     komut2.CommandText = "select * from mahsulyil";

                     SqlDataReader myDataReader2 = komut2.ExecuteReader();

                     while (myDataReader2.Read())
                     {
                         comboBox3.Items.Add(myDataReader2["mahsul_yil"].ToString());


                     }
                 }
             }*/
        }
    }
}
