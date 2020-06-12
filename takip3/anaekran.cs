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
using System.Globalization;

namespace takip3
{
    public partial class anaekran : Form
    {
        public anaekran()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            urunekle mm = new urunekle();
            mm.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            depotanimla mm = new depotanimla();
            mm.Show();
        }

        public void Anaekran_Load(object sender, EventArgs e)
        {

            //SiloRenk();
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //silo1urungrubu.BackColor = Color.Transparent;
            //silo1urungrubu.BackColor = Color.Transparent;
            Baglanti baglanti = new Baglanti();
            DataSet daset = new DataSet();
            //int kapasite,dolu,bos = 0;
            //kapasite = Int32.Parse(textBox2.Text);
            
            //silo1
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi where depo_id='Silo 1'", baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            OleDbDataReader dr = baglanti.komut.ExecuteReader();
            if (dr.Read())
            {
                silo1urungrubu.Text = dr["urun_grubu"].ToString();
                silo1urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo1mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo1kapasite.Text = dr["kapasite"].ToString();
                silo1kapasite.Text = (decimal.Parse(silo1kapasite.Text, NumberStyles.Float).ToString("N0"));
                silo1bos.Text= dr["depo_bos"].ToString();
                silo1bos.Text = (decimal.Parse(silo1bos.Text, NumberStyles.Float).ToString("N0"));
                silo1dolu.Text = dr["depo_dolu"].ToString();
                silo1dolu.Text = (decimal.Parse(silo1dolu.Text, NumberStyles.Float).ToString("N0"));
            }
            baglanti.Kapat();
            //silo2
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi where depo_id='Silo 2'", baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            dr = baglanti.komut.ExecuteReader();
            if (dr.Read())
            {
                silo2urungrubu.Text = dr["urun_grubu"].ToString();
                silo2urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo2mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo2kapasite.Text = dr["kapasite"].ToString();
                //anaekranda gosterilen sayinin virgullu olmasi icin -> System.Globalization; sınıfı eklenecek
                silo2kapasite.Text = (decimal.Parse(silo2kapasite.Text, NumberStyles.Float).ToString("N0"));
                silo2bos.Text = dr["depo_bos"].ToString();
                silo2bos.Text = (decimal.Parse(silo2bos.Text, NumberStyles.Float).ToString("N0"));
                silo2dolu.Text = dr["depo_dolu"].ToString();
                silo2dolu.Text = (decimal.Parse(silo2dolu.Text, NumberStyles.Float).ToString("N0"));
                

            }
            baglanti.Kapat();
            //silo3
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi where depo_id='Silo 3'", baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            dr = baglanti.komut.ExecuteReader();
            if (dr.Read())
            {
                silo3urungrubu.Text = dr["urun_grubu"].ToString();
                silo3urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo3mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo3kapasite.Text = dr["kapasite"].ToString();
                silo3kapasite.Text = (decimal.Parse(silo3kapasite.Text, NumberStyles.Float).ToString("N0"));
                silo3bos.Text = dr["depo_bos"].ToString();
                silo3bos.Text = (decimal.Parse(silo3bos.Text, NumberStyles.Float).ToString("N0"));
                silo3dolu.Text = dr["depo_dolu"].ToString();
                silo3dolu.Text = (decimal.Parse(silo3dolu.Text, NumberStyles.Float).ToString("N0"));
            }
            baglanti.Kapat();
            //silo4
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi where depo_id='Silo 4'", baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            dr = baglanti.komut.ExecuteReader();
            if (dr.Read())
            {
                silo4urungrubu.Text = dr["urun_grubu"].ToString();
                silo4urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo4mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo4kapasite.Text = dr["kapasite"].ToString();
                silo4kapasite.Text = (decimal.Parse(silo4kapasite.Text, NumberStyles.Float).ToString("N0"));
                silo4bos.Text = dr["depo_bos"].ToString();
                silo4bos.Text = (decimal.Parse(silo4bos.Text, NumberStyles.Float).ToString("N0"));
                silo4dolu.Text = dr["depo_dolu"].ToString();
                silo4dolu.Text = (decimal.Parse(silo4dolu.Text, NumberStyles.Float).ToString("N0"));
            }
            baglanti.Kapat();
            //silo5
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi where depo_id='Silo 5'", baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            dr = baglanti.komut.ExecuteReader();
            if (dr.Read())
            {
                silo5urungrubu.Text = dr["urun_grubu"].ToString();
                silo5urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo5mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo5kapasite.Text = dr["kapasite"].ToString();
                silo5kapasite.Text = (decimal.Parse(silo5kapasite.Text, NumberStyles.Float).ToString("N0"));
                silo5bos.Text = dr["depo_bos"].ToString();
                silo5bos.Text = (decimal.Parse(silo5bos.Text, NumberStyles.Float).ToString("N0"));
                silo5dolu.Text = dr["depo_dolu"].ToString();
                silo5dolu.Text = (decimal.Parse(silo5dolu.Text, NumberStyles.Float).ToString("N0"));
            }
            baglanti.Kapat();
            //silo6
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi where depo_id='Silo 6'", baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            dr = baglanti.komut.ExecuteReader();
            if (dr.Read())
            {
                silo6urungrubu.Text = dr["urun_grubu"].ToString();
                silo6urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo6mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo6kapasite.Text = dr["kapasite"].ToString();
                silo6kapasite.Text = (decimal.Parse(silo6kapasite.Text, NumberStyles.Float).ToString("N0"));
                silo6bos.Text = dr["depo_bos"].ToString();
                silo6bos.Text = (decimal.Parse(silo6bos.Text, NumberStyles.Float).ToString("N0"));
                silo6dolu.Text = dr["depo_dolu"].ToString();
                silo6dolu.Text = (decimal.Parse(silo6dolu.Text, NumberStyles.Float).ToString("N0"));
            }
            baglanti.Kapat();
            //silo7
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi where depo_id='Silo 7'", baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            dr = baglanti.komut.ExecuteReader();
            if (dr.Read())
            {
                silo7urungrubu.Text = dr["urun_grubu"].ToString();
                silo7urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo7mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo7kapasite.Text = dr["kapasite"].ToString();
                silo7kapasite.Text = (decimal.Parse(silo7kapasite.Text, NumberStyles.Float).ToString("N0"));
                silo7bos.Text = dr["depo_bos"].ToString();
                silo7bos.Text = (decimal.Parse(silo7bos.Text, NumberStyles.Float).ToString("N0"));
                silo7dolu.Text = dr["depo_dolu"].ToString();
                silo7dolu.Text = (decimal.Parse(silo7dolu.Text, NumberStyles.Float).ToString("N0"));
            }
            baglanti.Kapat();
            //silo8
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi where depo_id='Silo 8'", baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            dr = baglanti.komut.ExecuteReader();
            if (dr.Read())
            {
                silo8urungrubu.Text = dr["urun_grubu"].ToString();
                silo8urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo8mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo8kapasite.Text = dr["kapasite"].ToString();
                silo8kapasite.Text = (decimal.Parse(silo8kapasite.Text, NumberStyles.Float).ToString("N0"));
                silo8bos.Text = dr["depo_bos"].ToString();
                silo8bos.Text = (decimal.Parse(silo8bos.Text, NumberStyles.Float).ToString("N0"));
                silo8dolu.Text = dr["depo_dolu"].ToString();
                silo8dolu.Text = (decimal.Parse(silo8dolu.Text, NumberStyles.Float).ToString("N0"));
            }
            baglanti.Kapat();
            /*SqlConnection baglanti = new SqlConnection(@"Data Source=VAIO26;Initial Catalog=C:\Users\devel\Desktop\takip3-Kopya\takip3-Kopya\takip3\stok_takip.mdf;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = baglanti.CreateCommand();
            //silo1
            komut.CommandText = "Select * from depobilgi where Id = 1";
            komut.ExecuteNonQuery();
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                silo1urungrubu.Text = dr["urun_grubu"].ToString();
                silo1urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo1mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo1kapasite.Text = dr["kapasite"].ToString();
            }
            baglanti.Close();
            //silo2
            baglanti.Open();
            komut.CommandText = "Select * from depobilgi where Id = 2";
            komut.ExecuteNonQuery();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                silo2urungrubu.Text = dr["urun_grubu"].ToString();
                silo2urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo2mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo2kapasite.Text = dr["kapasite"].ToString();
            }
            baglanti.Close();
            //silo3
            baglanti.Open();
            komut.CommandText = "Select * from depobilgi where Id = 3";
            komut.ExecuteNonQuery();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                silo3urungrubu.Text = dr["urun_grubu"].ToString();
                silo3urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo3mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo3kapasite.Text = dr["kapasite"].ToString();
            }
            baglanti.Close();
            //silo4
            baglanti.Open();
            komut.CommandText = "Select * from depobilgi where Id = 4";
            komut.ExecuteNonQuery();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                silo4urungrubu.Text = dr["urun_grubu"].ToString();
                silo4urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo4mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo4kapasite.Text = dr["kapasite"].ToString();
            }
            baglanti.Close();
            //silo5
            baglanti.Open();
            komut.CommandText = "Select * from depobilgi where Id = 5";
            komut.ExecuteNonQuery();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                silo5urungrubu.Text = dr["urun_grubu"].ToString();
                silo5urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo5mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo5kapasite.Text = dr["kapasite"].ToString();
            }
            baglanti.Close();
            //silo6
            baglanti.Open();
            komut.CommandText = "Select * from depobilgi where Id = 6";
            komut.ExecuteNonQuery();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                silo6urungrubu.Text = dr["urun_grubu"].ToString();
                silo6urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo6mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo6kapasite.Text = dr["kapasite"].ToString();
            }
            baglanti.Close();
            //silo7
            baglanti.Open();
            komut.CommandText = "Select * from depobilgi where Id = 7";
            komut.ExecuteNonQuery();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                silo7urungrubu.Text = dr["urun_grubu"].ToString();
                silo7urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo7mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo7kapasite.Text = dr["kapasite"].ToString();
            }
            baglanti.Close();
            //silo8
            baglanti.Open();
            komut.CommandText = "Select * from depobilgi where Id = 8";
            komut.ExecuteNonQuery();
            dr = komut.ExecuteReader();
            if (dr.Read())
            {
                silo8urungrubu.Text = dr["urun_grubu"].ToString();
                silo8urunsinifi.Text = dr["urun_sinifi"].ToString();
                silo8mahsulyili.Text = dr["mahsul_yili"].ToString();
                silo8kapasite.Text = dr["kapasite"].ToString();
            }
            baglanti.Close();
            
            //depolbl1.Text = depotanimla.depo;
            */
            //silo renk
            baglanti.Baslat();
            string depodolu = "";
            string kapasite = "";
            //MessageBox.Show("deneme");
            double depodolusayi, kapasitesayi, islem;
            for (int i = 0; i < 8; i++)
            {
                baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi where depo_id='Silo " + (i+1) + "'", baglanti.connection);
                //baglanti.komut.ExecuteNonQuery();
                OleDbDataReader ddr = baglanti.komut.ExecuteReader();

                if(ddr.Read())
                {
                    kapasite = ddr["kapasite"].ToString();
                    depodolu = ddr["depo_dolu"].ToString();
                    depodolusayi = Double.Parse(depodolu);
                    kapasitesayi = Double.Parse(kapasite);
                    islem = (depodolusayi * 100) / kapasitesayi;
                    islem = Math.Round(islem, 0);
                    switch (i + 1)
                    {
                        case 1:
                            if (islem < 25)
                            {
                                pictureBox1.Image = Image.FromFile("silo25.png");
                            }
                            else if (25 < islem && islem < 50)
                            {
                                pictureBox1.Image = Image.FromFile("silo50.png");
                            }
                            else if (50 < islem && islem < 75)
                            {
                                pictureBox1.Image = Image.FromFile("silo75.png");
                            }
                            else
                            {
                                pictureBox1.Image = Image.FromFile("silo100.png");
                            }
                            break;
                        case 2:
                            if (islem < 25)
                            {
                                pictureBox2.Image = Image.FromFile("silo25.png");
                            }
                            else if (25 < islem && islem < 50)
                            {
                                pictureBox2.Image = Image.FromFile("silo50.png");
                            }
                            else if (50 < islem && islem < 75)
                            {
                                pictureBox2.Image = Image.FromFile("silo75.png");
                            }
                            else
                            {
                                pictureBox2.Image = Image.FromFile("silo100.png");
                            }
                            break;
                        case 3:
                            if (islem < 25)
                            {
                                pictureBox4.Image = Image.FromFile("silo25.png");
                            }
                            else if (25 < islem && islem < 50)
                            {
                                pictureBox4.Image = Image.FromFile("silo50.png");
                            }
                            else if (50 < islem && islem < 75)
                            {
                                pictureBox4.Image = Image.FromFile("silo75.png");
                            }
                            else
                            {
                                pictureBox4.Image = Image.FromFile("silo100.png");
                            }
                            break;
                        case 4:
                            if (islem < 25)
                            {
                                pictureBox3.Image = Image.FromFile("silo25.png");
                            }
                            else if (25 < islem && islem < 50)
                            {
                                pictureBox3.Image = Image.FromFile("silo50.png");
                            }
                            else if (50 < islem && islem < 75)
                            {
                                pictureBox3.Image = Image.FromFile("silo75.png");
                            }
                            else
                            {
                                pictureBox3.Image = Image.FromFile("silo100.png");
                            }
                            break;
                        case 5:
                            if (islem < 25)
                            {
                                pictureBox5.Image = Image.FromFile("silo25.png");
                            }
                            else if (25 < islem && islem < 50)
                            {
                                pictureBox5.Image = Image.FromFile("silo50.png");
                            }
                            else if (50 < islem && islem < 75)
                            {
                                pictureBox5.Image = Image.FromFile("silo75.png");
                            }
                            else
                            {
                                pictureBox5.Image = Image.FromFile("silo100.png");
                            }
                            break;
                        case 6:
                            if (islem < 25)
                            {
                                pictureBox6.Image = Image.FromFile("silo25.png");
                            }
                            else if (25 < islem && islem < 50)
                            {
                                pictureBox6.Image = Image.FromFile("silo50.png");
                            }
                            else if (50 < islem && islem < 75)
                            {
                                pictureBox6.Image = Image.FromFile("silo75.png");
                            }
                            else
                            {
                                pictureBox6.Image = Image.FromFile("silo100.png");
                            }
                            break;
                        case 7:
                            if (islem < 25)
                            {
                                pictureBox7.Image = Image.FromFile("silo25.png");
                            }
                            else if (25 < islem && islem < 50)
                            {
                                pictureBox7.Image = Image.FromFile("silo50.png");
                            }
                            else if (50 < islem && islem < 75)
                            {
                                pictureBox7.Image = Image.FromFile("silo75.png");
                            }
                            else
                            {
                                pictureBox7.Image = Image.FromFile("silo100.png");
                            }
                            break;
                        case 8:
                            if (islem < 25)
                            {
                                pictureBox8.Image = Image.FromFile("silo25.png");
                            }
                            else if (25 < islem && islem < 50)
                            {
                                pictureBox8.Image = Image.FromFile("silo50.png");
                            }
                            else if (50 < islem && islem < 75)
                            {
                                pictureBox8.Image = Image.FromFile("silo75.png");
                            }
                            else
                            {
                                pictureBox8.Image = Image.FromFile("silo100.png");
                            }
                            break;

                    }

                }

            }

            baglanti.Kapat();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            depogiris mm = new depogiris();
            mm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            depocikis mm = new depocikis();
            mm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            aktarma mm = new aktarma();
            mm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            excel mm = new excel();
            mm.Show();
        }

        private void dosyaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            //SiloRenk();
        }

        private void ürünİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ürünTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urunekle mm = new urunekle();
            mm.Show();
        }

        private void depoTanımlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            depotanimla mm = new depotanimla();
            mm.Show();
        }

        private void depoGirişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            depogiris mm = new depogiris();
            mm.Show();
        }

        private void depoÇıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            depocikis mm = new depocikis();
            mm.Show();
        }

        private void depolarArasıAktarmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aktarma mm = new aktarma();
            mm.Show();
        }

        private void veritabanınıSfırlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbsifirla mm = new dbsifirla();
            mm.Show();
        }

        private void veritabanınıYedekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //veritabaniyedekle mm = new veritabaniyedekle();
            //mm.Show();
            string fileToBackup = "stoktakipdb.accdb";
            string initialFilePath = @"C:\";

            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Kaydedilecek yeri seciniz",
                Filter = "Microsoft Access Database|*.accdb",
                InitialDirectory = initialFilePath,
            };

            sfd.ShowDialog();

            try
            {
                System.IO.File.Copy(fileToBackup, sfd.FileName, true);
            }
            catch
            {

            }
        }

        private void anaekran_Activated(object sender, EventArgs e)
        {
            Anaekran_Load(sender,e);
        }

        private void anaekran_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void anaekran_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public void SiloRenk()
        {
            Baglanti baglanti = new Baglanti();
            //DataSet daset = new DataSet();
            //int kapasite,dolu,bos = 0;
            //kapasite = Int32.Parse(textBox2.Text);

            //silo1
            baglanti.Baslat();
            string depodolu, kapasite="";
            double depodolusayi, kapasitesayi, islem;
            for (int i = 0; i == 7; i++)
            {
                baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi where depo_id='Silo " + i+1 + "'", baglanti.connection);
                baglanti.komut.ExecuteNonQuery();
                OleDbDataReader dr = baglanti.komut.ExecuteReader();

                if (dr.Read())
                {
                    depodolu = dr["kapasite"].ToString();
                    kapasite = dr["depo_dolu"].ToString();
                    depodolusayi = Double.Parse(depodolu);
                    kapasitesayi = Double.Parse(kapasite);
                    islem = depodolusayi * (kapasitesayi / 100);
                    islem = Math.Round(islem, 0);
                    switch(i+1)
                    {
                        case 1:
                            if (islem < 25)
                            {
                                pictureBox1.ImageLocation = "silo25";
                            }
                            if (25 < islem && islem < 50)
                            {
                                pictureBox1.ImageLocation = "silo50";
                            }
                            if (50 < islem && islem < 75)
                            {
                                pictureBox1.ImageLocation = "silo75";
                            }
                            else
                            {
                                pictureBox1.ImageLocation = "silo100";
                            }
                            break;
                        case 2:
                            if (islem < 25)
                            {
                                pictureBox2.ImageLocation = "silo25";
                            }
                            if (25 < islem && islem < 50)
                            {
                                pictureBox2.ImageLocation = "silo50";
                            }
                            if (50 < islem && islem < 75)
                            {
                                pictureBox2.ImageLocation = "silo75";
                            }
                            else
                            {
                                pictureBox2.ImageLocation = "silo100";
                            }
                            break;
                        case 3:
                            if (islem < 25)
                            {
                                pictureBox4.ImageLocation = "silo25";
                            }
                            if (25 < islem && islem < 50)
                            {
                                pictureBox4.ImageLocation = "silo50";
                            }
                            if (50 < islem && islem < 75)
                            {
                                pictureBox4.ImageLocation = "silo75";
                            }
                            else
                            {
                                pictureBox4.ImageLocation = "silo100";
                            }
                            break;
                        case 4:
                            if (islem < 25)
                            {
                                pictureBox3.ImageLocation = "silo25";
                            }
                            if (25 < islem && islem < 50)
                            {
                                pictureBox3.ImageLocation = "silo50";
                            }
                            if (50 < islem && islem < 75)
                            {
                                pictureBox3.ImageLocation = "silo75";
                            }
                            else
                            {
                                pictureBox3.ImageLocation = "silo100";
                            }
                            break;
                        case 5:
                            if (islem < 25)
                            {
                                pictureBox5.ImageLocation = "silo25";
                            }
                            if (25 < islem && islem < 50)
                            {
                                pictureBox5.ImageLocation = "silo50";
                            }
                            if (50 < islem && islem < 75)
                            {
                                pictureBox5.ImageLocation = "silo75";
                            }
                            else
                            {
                                pictureBox5.ImageLocation = "silo100";
                            }
                            break;
                        case 6:
                            if (islem < 25)
                            {
                                pictureBox6.ImageLocation = "silo25";
                            }
                            if (25 < islem && islem < 50)
                            {
                                pictureBox6.ImageLocation = "silo50";
                            }
                            if (50 < islem && islem < 75)
                            {
                                pictureBox6.ImageLocation = "silo75";
                            }
                            else
                            {
                                pictureBox6.ImageLocation = "silo100";
                            }
                            break;
                        case 7:
                            if (islem < 25)
                            {
                                pictureBox7.ImageLocation = "silo25";
                            }
                            if (25 < islem && islem < 50)
                            {
                                pictureBox7.ImageLocation = "silo50";
                            }
                            if (50 < islem && islem < 75)
                            {
                                pictureBox7.ImageLocation = "silo75";
                            }
                            else
                            {
                                pictureBox7.ImageLocation = "silo100";
                            }
                            break;
                        case 8:
                            if (islem < 25)
                            {
                                pictureBox8.ImageLocation = "silo25";
                            }
                            if (25 < islem && islem < 50)
                            {
                                pictureBox8.ImageLocation = "silo50";
                            }
                            if (50 < islem && islem < 75)
                            {
                                pictureBox8.ImageLocation = "silo75";
                            }
                            else
                            {
                                pictureBox8.ImageLocation = "silo100";
                            }
                            break;
                        default:
                            pictureBox1.ImageLocation = "silo25";
                            pictureBox2.ImageLocation = "silo25";
                            pictureBox3.ImageLocation = "silo25";
                            pictureBox4.ImageLocation = "silo25";
                            pictureBox5.ImageLocation = "silo25";
                            pictureBox6.ImageLocation = "silo25";
                            pictureBox7.ImageLocation = "silo25";
                            pictureBox8.ImageLocation = "silo25";
                            break;


                    }
                    

                }
                
            }
            
            baglanti.Kapat();
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
