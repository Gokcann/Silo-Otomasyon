using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace takip3
{
    public partial class depocikis : Form
    {
        public depocikis()
        {
            InitializeComponent();
        }
        Baglanti baglanti = new Baglanti();
        DataSet daset = new DataSet();
        private void depocikis_Load(object sender, EventArgs e)
        {
            daset.Clear();
            //comboBox2.Select
            dataGridView1.ReadOnly = true;
            button3.Enabled = false;
            baglanti.Baslat();
            baglanti.adaptor = new OleDbDataAdapter("SELECT * FROM depogiriscikis WHERE islem_tipi='cikis' ORDER BY islem_no DESC", baglanti.connection);
            baglanti.adaptor.Fill(daset, "depogiriscikis");
            dataGridView1.DataSource = daset.Tables["depogiriscikis"];

            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi ", baglanti.connection);
            OleDbDataReader myDataReader3 = baglanti.komut.ExecuteReader();
            //SqlDataReader myDataReader3 = komut3.ExecuteReader();
            comboBox1.Items.Clear();
            while (myDataReader3.Read())
            {
                comboBox1.Items.Add(myDataReader3["depo_id"].ToString()); ;

            }
            
            baglanti.Kapat();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tonaj=0;
            tonaj = Int32.Parse(textBox2.Text);

            //kapasite kontrolü
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
            OleDbDataReader myDataReader3 = baglanti.komut.ExecuteReader();
            string cc = "";
            string dd = "";
            while (myDataReader3.Read())
            {
                cc = (myDataReader3["depo_dolu"].ToString());
                dd = (myDataReader3["kapasite"].ToString()); ;

            }
            Double depo_dolu = Double.Parse(cc);
            Double kapasite3 = Double.Parse(dd);

            if (textBox1.Text.Length > 1 && textBox4.Text.Length > 1)
            {
                if (tonaj < 50001 && tonaj > 0)
                {

                    if ((depo_dolu - tonaj) > -1)
                    {

                        string date = System.DateTime.Now.ToString();
                        string tip = "cikis";
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("INSERT INTO depogiriscikis (islem_depo,firma_gemi,kantar_fisi,arac_plaka,fabrika_tonaj,urun_sinifi,urun_grubu,tarih,islem_tipi) VALUES (@item1,@item2,@item3,@item4,@item5,@item6,@item7,@item8,@item9)", baglanti.connection);
                        baglanti.komut.Parameters.AddWithValue("@item1", comboBox1.SelectedItem.ToString());
                        baglanti.komut.Parameters.AddWithValue("@item2", textBox4.Text.ToString());
                        baglanti.komut.Parameters.AddWithValue("@item3", textBox6.Text.ToString());
                        baglanti.komut.Parameters.AddWithValue("@item4", textBox1.Text.ToString());
                        baglanti.komut.Parameters.AddWithValue("@item5", textBox2.Text.ToString());
                        baglanti.komut.Parameters.AddWithValue("@item6", comboBox3.SelectedItem.ToString());
                        baglanti.komut.Parameters.AddWithValue("@item7", comboBox2.SelectedItem.ToString());
                        baglanti.komut.Parameters.AddWithValue("@item8", date);
                        baglanti.komut.Parameters.AddWithValue("@item9", tip.ToString());
                        
                        


                        baglanti.komut.ExecuteNonQuery();
                        baglanti.Kapat();
                        
                        //---------------
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        OleDbDataReader myDataReader4 = baglanti.komut.ExecuteReader();
                        string aa = "";
                        while (myDataReader4.Read())
                        {
                            aa = (myDataReader4["depo_bos"].ToString()); ;

                        }
                        Double kapasite = Double.Parse(aa);
                        Double artan = Double.Parse(textBox2.Text);
                        Double sonuc = kapasite + artan;
                        baglanti.Kapat();
                        //---------------
                        //buraya 0dan eksiye dusme ihtimal icin if blogu gelecek
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_bos='" + sonuc.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        baglanti.komut.ExecuteNonQuery();
                        //baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + artan.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        //baglanti.komut.ExecuteNonQuery();
                        //komut.Dispose();
                        baglanti.Kapat();
                        //deneme
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        OleDbDataReader myDataReader5 = baglanti.komut.ExecuteReader();
                        string ab = "";
                        while (myDataReader5.Read())
                        {
                            ab = (myDataReader5["depo_dolu"].ToString()); ;

                        }
                        Double kapasite2 = Double.Parse(ab);
                        Double eksilen = Double.Parse(textBox2.Text);
                        Double sonuc2 = kapasite2 - eksilen;

                        baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + sonuc2.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        baglanti.komut.ExecuteNonQuery();
                        baglanti.Kapat();
                        MessageBox.Show("Ürün Çıkış İşlemi Başarılı");

                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Depo doluluk seviyesi sıfırın altına düşüyor. Yine de devam etmek istiyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);

                        switch (dr)
                        {
                            case DialogResult.Yes:
                                string date = System.DateTime.Now.ToString();
                                string tip = "cikis";
                                baglanti.Baslat();
                                baglanti.komut = new OleDbCommand("INSERT INTO depogiriscikis (islem_depo,firma_gemi,kantar_fisi,arac_plaka,fabrika_tonaj,urun_sinifi,urun_grubu,tarih,islem_tipi) VALUES (@item1,@item2,@item3,@item4,@item5,@item6,@item7,@item8,@item9)", baglanti.connection);
                                baglanti.komut.Parameters.AddWithValue("@item1", comboBox1.SelectedItem.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item2", textBox4.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item3", textBox6.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item4", textBox1.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item5", textBox2.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item6", comboBox3.SelectedItem.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item7", comboBox2.SelectedItem.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item8", date);
                                baglanti.komut.Parameters.AddWithValue("@item9", tip.ToString());
                                baglanti.komut.ExecuteNonQuery();
                                baglanti.Kapat();
                                //depoasima ekleniyor islem
                                baglanti.Baslat();
                                baglanti.komut = new OleDbCommand("INSERT INTO depoasim (islem_depo,firma_gemi,kantar_fisi,arac_plaka,fabrika_tonaj,urun_sinifi,urun_grubu,tarih,asim_miktari) VALUES (@item1,@item2,@item3,@item4,@item5,@item6,@item7,@item8,@item9)", baglanti.connection);
                                baglanti.komut.Parameters.AddWithValue("@item1", comboBox1.SelectedItem.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item2", textBox4.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item3", textBox6.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item4", textBox1.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item5", textBox2.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item6", comboBox3.SelectedItem.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item7", comboBox2.SelectedItem.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item8", date);
                                baglanti.komut.Parameters.AddWithValue("@item9", -1 * (depo_dolu - tonaj));
                                baglanti.Kapat();
                                /*baglanti.Baslat();
                                baglanti.komut = new OleDbCommand("INSERT INTO depoasim (islem_depo,arac_plaka,fabrika_tonaj,urun_grubu,urun_sinifi,tarih,asim_miktari) VALUES (@item1,@item2,@item3,@item4,@item5,@item6,@item7)", baglanti.connection);
                                baglanti.komut.Parameters.AddWithValue("@item1", comboBox1.SelectedItem.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item2", textBox1.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item3", textBox2.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item4", comboBox3.SelectedItem.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item5", comboBox2.SelectedItem.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item6", date);
                                baglanti.komut.Parameters.AddWithValue("@item7", -1 * (depo_dolu - tonaj));
                                //baglanti.komut.Parameters.AddWithValue("@item7", tip.ToString());
                                baglanti.komut.ExecuteNonQuery();
                                baglanti.Kapat();
                                */
                                MessageBox.Show("Ürün Eklendi");
                                //---------------
                                baglanti.Baslat();
                                baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                                OleDbDataReader myDataReader4 = baglanti.komut.ExecuteReader();
                                string aa = "";
                                while (myDataReader4.Read())
                                {
                                    aa = (myDataReader4["kapasite"].ToString()); ;

                                }
                                Double kapasite = Double.Parse(aa);
                                //Double artan = Double.Parse(textBox2.Text);
                                //Double sonuc = kapasite + artan;
                                baglanti.Kapat();
                                //---------------
                                //buraya 0dan eksiye dusme ihtimal icin if blogu gelecek
                                baglanti.Baslat();
                                baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_bos='" + kapasite.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                                baglanti.komut.ExecuteNonQuery();
                                //baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + artan.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                                //baglanti.komut.ExecuteNonQuery();
                                //komut.Dispose();
                                baglanti.Kapat();
                                //deneme
                                /*
                                baglanti.Baslat();
                                baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                                OleDbDataReader myDataReader5 = baglanti.komut.ExecuteReader();
                                string ab = "";
                                while (myDataReader5.Read())
                                {
                                    ab = (myDataReader5["depo_dolu"].ToString()); ;

                                }
                                Double kapasite2 = Double.Parse(ab);
                                Double eksilen = Double.Parse(textBox2.Text);
                                Double sonuc2 = kapasite2 - eksilen;
                                */
                                baglanti.Baslat();
                                Double sonuc2 = 0;
                                baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + sonuc2.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                                baglanti.komut.ExecuteNonQuery();
                                baglanti.Kapat();
                                break;
                            case DialogResult.No:
                                break;
                        }
                    }
                }


                else
                {
                    MessageBox.Show("Tonaj 0 (sıfır) ile 50.000 (ellibin) arası deger alabilir!");
                }
            }
            else
            {
                MessageBox.Show("Plaka veya firma/gemi kısmı boş olamaz!");
            }

        }
        private void Kayıt_Göster()
        {
            /*
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from urunlistesi", baglanti);
            adtr.Fill(daset, "urunlistesi");
            dataGridView1.DataSource = daset.Tables["urunlistesi"];
            baglanti.Close();
            */
            baglanti.Baslat();
            baglanti.adaptor = new OleDbDataAdapter("SELECT * FROM depogiriscikis WHERE islem_tipi='cikis'", baglanti.connection);
            baglanti.adaptor.Fill(daset, "depogiriscikis");
            dataGridView1.DataSource = daset.Tables["depogiriscikis"];
            baglanti.Kapat();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection); ;
            OleDbDataReader myDataReader4 = baglanti.komut.ExecuteReader();
            //SqlDataReader myDataReader3 = komut3.ExecuteReader();

            while (myDataReader4.Read())
            {
                comboBox2.Items.Add(myDataReader4["urun_sinifi"].ToString()); ;

            }
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection); ;
            OleDbDataReader myDataReader5 = baglanti.komut.ExecuteReader();
            //SqlDataReader myDataReader3 = komut3.ExecuteReader();
            
            comboBox2.SelectedIndex = 0;
            while (myDataReader5.Read())
            {
                comboBox3.Items.Add(myDataReader5["urun_grubu"].ToString()); ;

            }
            
            comboBox3.SelectedIndex = 0;
            baglanti.Kapat();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
            string date = System.DateTime.Now.ToString();
            string tip = "cikis";
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("UPDATE depogiriscikis SET islem_depo='" + comboBox1.Text.ToString() + "',firma_gemi='" + textBox4.Text.ToString() + "',arac_plaka='" + textBox1.Text.ToString() + "',fabrika_tonaj='" + textBox2.Text.ToString() + "',urun_sinifi='" + comboBox2.Text.ToString() + "',urun_grubu='" + comboBox3.Text.ToString() + "',tarih='" + date.ToString() + "',islem_tipi='" + tip + "' WHERE islem_no=" + textBox5.Text + "", baglanti.connection); ;
            baglanti.komut.ExecuteNonQuery();
            //komut.Dispose();
            baglanti.Kapat();
            daset.Tables["depogiriscikis"].Clear();
            Kayıt_Göster();
            MessageBox.Show("Giriş işlemi seçilen satıra göre güncellendi!");
            */
            //buraya cikis isleminden once guncellenen cikisin depo dolu boslari dusulecek
            //-----------------------------------------------------------------
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
            OleDbDataReader myDataReader4k = baglanti.komut.ExecuteReader();
            string aa_k = "";
            string bb_k = "";
            string cc_k = "";
            while (myDataReader4k.Read())
            {
                aa_k = (myDataReader4k["depo_bos"].ToString()); ;

            }
            baglanti.Kapat();
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depogiriscikis WHERE islem_no=" + textBox5.Text + "", baglanti.connection);
            OleDbDataReader myDataReader6k = baglanti.komut.ExecuteReader();
            while (myDataReader6k.Read())
            {
                cc_k = (myDataReader6k["fabrika_tonaj"].ToString()); ;

            }
            Double kapasite_k = Double.Parse(aa_k);
            Double eksilen_k = Double.Parse(cc_k);
            Double sonuc_k = kapasite_k - eksilen_k;


            baglanti.Kapat();
            //---------------
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
            OleDbDataReader myDataReader5_k = baglanti.komut.ExecuteReader();
            while (myDataReader5_k.Read())
            {
                bb_k = (myDataReader5_k["depo_dolu"].ToString()); ;

            }
            Double depo_dolu_k = Double.Parse(bb_k);
            Double sonuc2_k = depo_dolu_k + eksilen_k;

            //depo_bos icin update islemi
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_bos='" + sonuc_k.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            //depo_dolu icin update islemi
            baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + sonuc2_k.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            //komut.Dispose();
            baglanti.Kapat();

            //-----------------------------------------------------------------
            int tonaj = 0;
            tonaj = Int32.Parse(textBox2.Text);

            //kapasite kontrolü
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
            OleDbDataReader myDataReader3 = baglanti.komut.ExecuteReader();
            string cc = "";
            string dd = "";
            while (myDataReader3.Read())
            {
                cc = (myDataReader3["depo_dolu"].ToString());
                dd = (myDataReader3["kapasite"].ToString()); ;

            }
            Double depo_dolu = Double.Parse(cc);
            Double kapasite3 = Double.Parse(dd);

            if (textBox1.Text.Length > 3 && textBox3.Text.Length > 3)
            {
                if (tonaj < 50001 && tonaj > 0)
                {

                    if ((depo_dolu - tonaj) > 0)
                    {

                        string date = System.DateTime.Now.ToString();
                        string tip = "cikis";
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("UPDATE depogiriscikis SET islem_depo='" + comboBox1.Text.ToString() + "',firma_gemi='" + textBox4.Text.ToString() + "',arac_plaka='" + textBox1.Text.ToString() + "',fabrika_tonaj='" + textBox2.Text.ToString() + "',urun_sinifi='" + comboBox2.Text.ToString() + "',urun_grubu='" + comboBox3.Text.ToString() + "',tarih='" + date.ToString() + "',islem_tipi='" + tip + "' WHERE islem_no=" + textBox5.Text + "", baglanti.connection); ;
                        baglanti.komut.ExecuteNonQuery();
                        //komut.Dispose();
                        baglanti.Kapat();
                        daset.Tables["depogiriscikis"].Clear();
                        Kayıt_Göster();
                        MessageBox.Show("Giriş işlemi seçilen satıra göre güncellendi!");

                        //---------------
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        OleDbDataReader myDataReader4 = baglanti.komut.ExecuteReader();
                        string aa = "";
                        while (myDataReader4.Read())
                        {
                            aa = (myDataReader4["depo_bos"].ToString()); ;

                        }
                        Double kapasite = Double.Parse(aa);
                        Double artan = Double.Parse(textBox2.Text);
                        Double sonuc = kapasite + artan;
                        baglanti.Kapat();
                        //---------------
                        //buraya 0dan eksiye dusme ihtimal icin if blogu gelecek
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_bos='" + sonuc.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        baglanti.komut.ExecuteNonQuery();
                        //baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + artan.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        //baglanti.komut.ExecuteNonQuery();
                        //komut.Dispose();
                        baglanti.Kapat();
                        //deneme
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        OleDbDataReader myDataReader5 = baglanti.komut.ExecuteReader();
                        string ab = "";
                        while (myDataReader5.Read())
                        {
                            ab = (myDataReader5["depo_dolu"].ToString()); ;

                        }
                        Double kapasite2 = Double.Parse(ab);
                        Double eksilen = Double.Parse(textBox2.Text);
                        Double sonuc2 = kapasite2 - eksilen;

                        baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + sonuc2.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        baglanti.komut.ExecuteNonQuery();
                        baglanti.Kapat();

                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Depo doluluk seviyesi sıfırın altına düşüyor. Yine de devam etmek istiyor musunuz?", "UYARI!", MessageBoxButtons.YesNo);

                        switch (dr)
                        {
                            case DialogResult.Yes:
                                string date = System.DateTime.Now.ToString();
                                string tip = "cikis";
                                baglanti.Baslat();
                                baglanti.Baslat();
                                baglanti.komut = new OleDbCommand("INSERT INTO depogiriscikis (islem_depo,firma_gemi,kantar_fisi,arac_plaka,fabrika_tonaj,urun_sinifi,urun_grubu,tarih,islem_tipi) VALUES (@item1,@item2,@item3,@item4,@item5,@item6,@item7,@item8,@item9)", baglanti.connection);
                                baglanti.komut.Parameters.AddWithValue("@item1", comboBox1.SelectedItem.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item2", textBox4.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item3", textBox6.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item4", textBox1.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item5", textBox2.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item6", comboBox3.SelectedItem.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item7", comboBox2.SelectedItem.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item8", date);
                                baglanti.komut.Parameters.AddWithValue("@item9", tip.ToString());
                                baglanti.komut.ExecuteNonQuery();
                                baglanti.Kapat();
                                //depoasima ekleniyor islem
                                baglanti.Baslat();
                                baglanti.komut = new OleDbCommand("INSERT INTO depoasim (islem_depo,firma_gemi,kantar_fisi,arac_plaka,fabrika_tonaj,urun_sinifi,urun_grubu,tarih,asim_miktari) VALUES (@item1,@item2,@item3,@item4,@item5,@item6,@item7,@item8,@item9)", baglanti.connection);
                                baglanti.komut.Parameters.AddWithValue("@item1", comboBox1.SelectedItem.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item2", textBox4.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item3", textBox6.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item4", textBox1.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item5", textBox2.Text.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item6", comboBox3.SelectedItem.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item7", comboBox2.SelectedItem.ToString());
                                baglanti.komut.Parameters.AddWithValue("@item8", date);
                                baglanti.komut.Parameters.AddWithValue("@item9", -1 * (depo_dolu - tonaj));
                                baglanti.Kapat();

                                MessageBox.Show("Ürün Eklendi");
                                //---------------
                                baglanti.Baslat();
                                baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                                OleDbDataReader myDataReader4 = baglanti.komut.ExecuteReader();
                                string aa = "";
                                while (myDataReader4.Read())
                                {
                                    aa = (myDataReader4["kapasite"].ToString()); ;

                                }
                                Double kapasite = Double.Parse(aa);
                                //Double artan = Double.Parse(textBox2.Text);
                                //Double sonuc = kapasite + artan;
                                baglanti.Kapat();
                                //---------------
                                //buraya 0dan eksiye dusme ihtimal icin if blogu gelecek
                                baglanti.Baslat();
                                baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_bos='" + kapasite.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                                baglanti.komut.ExecuteNonQuery();
                                //baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + artan.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                                //baglanti.komut.ExecuteNonQuery();
                                //komut.Dispose();
                                baglanti.Kapat();
                                //deneme
                                /*
                                baglanti.Baslat();
                                baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                                OleDbDataReader myDataReader5 = baglanti.komut.ExecuteReader();
                                string ab = "";
                                while (myDataReader5.Read())
                                {
                                    ab = (myDataReader5["depo_dolu"].ToString()); ;

                                }
                                Double kapasite2 = Double.Parse(ab);
                                Double eksilen = Double.Parse(textBox2.Text);
                                Double sonuc2 = kapasite2 - eksilen;
                                */
                                baglanti.Baslat();
                                Double sonuc2 = 0;
                                baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + sonuc2.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                                baglanti.komut.ExecuteNonQuery();
                                baglanti.Kapat();
                                break;
                            case DialogResult.No:
                                baglanti.Baslat();
                                baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                                OleDbDataReader myDataReader4k2 = baglanti.komut.ExecuteReader();
                                string aa_k2 = "";
                                string bb_k2 = "";
                                string cc_k2 = "";
                                while (myDataReader4k2.Read())
                                {
                                    aa_k2 = (myDataReader4k2["depo_bos"].ToString()); ;

                                }
                                baglanti.Kapat();
                                baglanti.Baslat();
                                baglanti.komut = new OleDbCommand("SELECT * FROM depogiriscikis WHERE islem_no=" + textBox5.Text + "", baglanti.connection);
                                OleDbDataReader myDataReader6k2 = baglanti.komut.ExecuteReader();
                                while (myDataReader6k2.Read())
                                {
                                    cc_k2 = (myDataReader6k2["fabrika_tonaj"].ToString()); ;

                                }
                                Double kapasite_k2 = Double.Parse(aa_k2);
                                Double eksilen_k2 = Double.Parse(cc_k2);
                                Double sonuc_k2 = kapasite_k2 + eksilen_k2;


                                baglanti.Kapat();
                                //---------------
                                baglanti.Baslat();
                                baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                                OleDbDataReader myDataReader5_k2 = baglanti.komut.ExecuteReader();
                                while (myDataReader5_k2.Read())
                                {
                                    bb_k2 = (myDataReader5_k2["depo_dolu"].ToString()); ;

                                }
                                Double depo_dolu_k2 = Double.Parse(bb_k2);
                                Double sonuc2_k2 = depo_dolu_k2 - eksilen_k2;

                                //depo_bos icin update islemi
                                baglanti.Baslat();
                                baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_bos='" + sonuc_k2.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                                baglanti.komut.ExecuteNonQuery();
                                //depo_dolu icin update islemi
                                baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + sonuc2_k2.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                                baglanti.komut.ExecuteNonQuery();
                                //komut.Dispose();
                                baglanti.Kapat();
                                break;
                        }
                    }
                }


                else
                {
                    MessageBox.Show("Tonaj 0 (sıfır) ile 50.000 (ellibin) arası deger alabilir!");
                }
            }
            else
            {
                MessageBox.Show("Plaka veya firma/gemi kısmı boş olamaz!");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Enabled = true;
            button2.Enabled = false;
            comboBox1.Enabled = false;
            textBox5.Text = dataGridView1.CurrentRow.Cells["islem_no"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["firma_gemi"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["kantar_fisi"].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells["arac_plaka"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["fabrika_tonaj"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["islem_depo"].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells["urun_sinifi"].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells["urun_grubu"].Value.ToString();
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textbox'a sadece sayi girisi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textbox'a sadece sayi girisi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void depocikis_Activated(object sender, EventArgs e)
        {
            //depocikis_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    
    }
}
