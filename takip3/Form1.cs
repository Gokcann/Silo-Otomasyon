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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        Baglanti baglanti = new Baglanti();


        public void Baslat()
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //SqlConnection giris = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aLP\source\repos\takip3\takip3\stok_takip.mdf;Integrated Security=True");
            //SqlDataAdapter grs = new SqlDataAdapter("select count(*) from kullanicibilgileri where kullaniciadi ='" + textBox1.Text + "' and kullanicisifre='" + textBox2.Text + "'", giris);
            //DataTable dt = new DataTable();
            //grs.Fill(dt);
            //if (dt.Rows[0][0].ToString() == "1")
            //{
            //this.Hide();
            //  Form mm = new anaekran();
            //  mm.Show();
            //  }
            //  else
            // MessageBox.Show("lütfen kullanıcı adı veya şifre giriniz", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            /*
             Form mm = new anaekran();
            mm.Show();
            */
            /*
            Baglanti baglanti = new Baglanti();
            baglanti.Baslat();
            baglanti.komut.Connection = baglanti.connection;
            baglanti.adaptor = new System.Data.OleDb.OleDbDataAdapter ("select * from kullanici where kullanici_adi ='" + textBox1.Text + "' and kullanici_sifre='" + textBox2.Text + "'", baglanti.connection);
            DataTable dt = new DataTable();
            baglanti.adaptor.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
            this.Hide();
              Form mm = new anaekran();
              mm.Show();
              }
              else
            MessageBox.Show("lütfen kullanıcı adı veya şifre giriniz", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //Form mm = new anaekran();
            //mm.Show();
            */

            //*******************connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=stoktakipdb.accdb");
            /*connection.Open();
            komut.Connection = connection;
            //connection.CreateCommand. = "select * from kullanici where kullanici_adi ='" + textBox1.Text + "' and kullanici_sifre='" + textBox2.Text + "'";
            komut.CommandText = "select * from kullanici where kullanici_adi ='" + textBox1.Text + "' and kullanici_sifre='" + textBox2.Text + "'";
            //adaptor = new System.Data.OleDb.OleDbDataAdapter("select * from kullanici where kullanici_adi ='" + textBox1.Text + "' and kullanici_sifre='" + textBox2.Text + "'",connection);
            //DataTable dt = new DataTable();
            //adaptor.Fill(dt);
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form mm = new anaekran();
                mm.Show();
            }
            else
            {
                MessageBox.Show("lütfen kullanıcı adı veya şifre giriniz", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
            */

            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT COUNT(*) FROM kullanici where kullanici_adi=@item1 and kullanici_sifre=@item2", baglanti.connection);
            baglanti.komut.Parameters.Add("@item1", textBox1.Text);
            baglanti.komut.Parameters.Add("@item2", textBox2.Text);
            int ks;
            ks = int.Parse(baglanti.komut.ExecuteScalar().ToString());
            if (ks == 1)
            {
                this.Hide();
                //this.Close();
                Form mm = new anaekran();
                mm.Show();
                
            }
            else
                MessageBox.Show("Giriş Başarısız");

            baglanti.Kapat();

        }

private void Form1_Load(object sender, EventArgs e)
{
            
}

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
