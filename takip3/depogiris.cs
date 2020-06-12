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
using System.Text.RegularExpressions;

namespace takip3
{
    public partial class depogiris : Form
    {
        public depogiris()
        {
            InitializeComponent();
        }
        Baglanti baglanti = new Baglanti();
        DataSet daset = new DataSet();
        private void depogiris_Load(object sender, EventArgs e)
        {
            daset.Clear();
            dataGridView1.ReadOnly = true;
            button2.Enabled = false;
            baglanti.Baslat(); 
            baglanti.adaptor = new OleDbDataAdapter("SELECT * FROM depogiriscikis WHERE islem_tipi='giris' ORDER BY islem_no DESC", baglanti.connection);
            baglanti.adaptor.Fill(daset, "depogiriscikis");
            dataGridView1.DataSource = daset.Tables["depogiriscikis"];
            //dataGridView1.Columns["islem_no"].SortMode = DataGridViewColumnSortMode.Automatic();
            baglanti.Kapat();
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi", baglanti.connection);
            OleDbDataReader myDataReader3 = baglanti.komut.ExecuteReader();
            //SqlDataReader myDataReader3 = komut3.ExecuteReader();
            comboBox1.Items.Clear();
            while (myDataReader3.Read())
            {
                comboBox1.Items.Add(myDataReader3["depo_id"].ToString()); ;

            }
            /*
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi ", baglanti.connection);
            
            OleDbDataReader myDataReader4 = baglanti.komut.ExecuteReader();
            //SqlDataReader myDataReader3 = komut3.ExecuteReader();

            while (myDataReader4.Read())
            {
                comboBox2.Items.Add(myDataReader4["urun_sinifi"].ToString()); ;

            }
            baglanti.komut = new OleDbCommand("SELECT * FROM depogiriscikis ", baglanti.connection);
            OleDbDataReader myDataReader5 = baglanti.komut.ExecuteReader();
            //SqlDataReader myDataReader3 = komut3.ExecuteReader();
            
            while (myDataReader5.Read())
            {
                comboBox3.Items.Add(myDataReader5["urun_grubu"].ToString()); ;

            }
            */
            baglanti.Kapat();

        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            Double depo_dolu2 = Double.Parse(cc);
            Double kapasite2 = Double.Parse(dd);

            if ( textBox1.Text.Length > 3 && textBox3.Text.Length > 3 )
            {
                if (tonaj < 50001 && tonaj > 0)
                {
                    if (depo_dolu2 + tonaj <= kapasite2)
                    {
                        string date = System.DateTime.Now.ToString();
                        string tip = "giris";
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("INSERT INTO depogiriscikis (islem_depo,firma_gemi,kantar_fisi,arac_plaka,fabrika_tonaj,urun_sinifi,urun_grubu,tarih,islem_tipi) VALUES (@item1,@item2,@item3,@item4,@item5,@item6,@item7,@item8,@item9)", baglanti.connection);
                        baglanti.komut.Parameters.AddWithValue("@item1", comboBox1.SelectedItem.ToString());
                        baglanti.komut.Parameters.AddWithValue("@item2", textBox3.Text.ToString());
                        baglanti.komut.Parameters.AddWithValue("@item3", textBox6.Text.ToString());
                        baglanti.komut.Parameters.AddWithValue("@item4", textBox1.Text.ToString());
                        baglanti.komut.Parameters.AddWithValue("@item5", textBox2.Text.ToString());
                        baglanti.komut.Parameters.AddWithValue("@item6", comboBox2.SelectedItem.ToString());
                        baglanti.komut.Parameters.AddWithValue("@item7", comboBox3.SelectedItem.ToString());
                        baglanti.komut.Parameters.AddWithValue("@item8", date);
                        baglanti.komut.Parameters.AddWithValue("@item9", tip.ToString());
                        baglanti.komut.ExecuteNonQuery();
                        baglanti.Kapat();
                        
                        //---------------
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        OleDbDataReader myDataReader4 = baglanti.komut.ExecuteReader();
                        string aa = "";
                        string bb = "";
                        while (myDataReader4.Read())
                        {
                            aa = (myDataReader4["depo_bos"].ToString()); ;

                        }
                        Double kapasite = Double.Parse(aa);
                        Double eksilen = Double.Parse(textBox2.Text);
                        Double sonuc = kapasite - eksilen;


                        baglanti.Kapat();
                        //---------------
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        OleDbDataReader myDataReader5 = baglanti.komut.ExecuteReader();
                        while (myDataReader5.Read())
                        {
                            bb = (myDataReader5["depo_dolu"].ToString()); ;

                        }
                        Double depo_dolu = Double.Parse(bb);
                        Double sonuc2 = depo_dolu + eksilen;
                        //depo_bos icin update islemi
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_bos='" + sonuc.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        baglanti.komut.ExecuteNonQuery();
                        //depo_dolu icin update islemi
                        baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + sonuc2.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        baglanti.komut.ExecuteNonQuery();
                        //komut.Dispose();
                        baglanti.Kapat();
                        MessageBox.Show("Ürün Eklendi");
                    }
                    else
                    {
                        MessageBox.Show("Toplam silo kapasitesi aşıldı!");
                    }

                }

                else
                {
                    MessageBox.Show("Tonaj 0 (sıfır) ile 50.000 (ellibin) arası deger alabilir!");
                }
            }else 
            {
                MessageBox.Show("Plaka, firma/gemi veya kantar fişi kısmı boş olamaz!");
            }
            /*
            anaekran ekran = new anaekran();
            ekran.Anaekran_Load(sender,e);
            */
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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

            while (myDataReader5.Read())
            {
                comboBox3.Items.Add(myDataReader5["urun_grubu"].ToString()); ;

            }
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            baglanti.Kapat();
        }

        //DataSet daset = new DataSet();

        /*
        private string id_Al(string s)
        {
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depogiriscikis ", baglanti.connection);
            OleDbDataReader myDataReader3 = baglanti.komut.ExecuteReader();
            //SqlDataReader myDataReader3 = komut3.ExecuteReader();
            string a = "";
            while (myDataReader3.Read())
            {
                a = (myDataReader3["islem_no"].ToString()); ;
                a = (myDataReader3["islem_no"].ToString()); ;

            }
            
            baglanti.Kapat();
            return a;
        }
        */
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
            baglanti.adaptor = new OleDbDataAdapter("SELECT * FROM depogiriscikis WHERE islem_tipi='giris'", baglanti.connection);
            baglanti.adaptor.Fill(daset, "depogiriscikis");
            dataGridView1.DataSource = daset.Tables["depogiriscikis"];
            baglanti.Kapat();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //button1_Click(sender,e);
            //guncellemeden once eklenen kayidin tonaji silinecek

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
            Double sonuc_k = kapasite_k + eksilen_k;


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
            Double sonuc2_k = depo_dolu_k - eksilen_k;

            //depo_bos icin update islemi
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_bos='" + sonuc_k.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            //depo_dolu icin update islemi
            baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + sonuc2_k.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            //komut.Dispose();
            baglanti.Kapat();


            //----------------------------------------------------------------------
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
            Double depo_dolu2 = Double.Parse(cc);
            Double kapasite2 = Double.Parse(dd);
            if ( textBox1.Text.Length > 3 && textBox3.Text.Length > 3 )
            {


                if (tonaj < 50001 && tonaj > 0)
                {
                    if (depo_dolu2 + tonaj <= kapasite2)
                    {
                        string date = System.DateTime.Now.ToString();
                        string tip = "giris";
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("UPDATE depogiriscikis SET islem_depo='" + comboBox1.Text.ToString() + "',firma_gemi='" + textBox3.Text.ToString() + "',kantar_fisi='" + textBox6.Text.ToString() + "',arac_plaka='" + textBox1.Text.ToString().ToUpper() + "',fabrika_tonaj='" + textBox2.Text.ToString() + "',urun_sinifi='" + comboBox2.Text.ToString() + "',urun_grubu='" + comboBox3.Text.ToString() + "',tarih='" + date.ToString() + "',islem_tipi='" + tip + "' WHERE islem_no=" + textBox5.Text + "", baglanti.connection); ;
                        baglanti.komut.ExecuteNonQuery();
                        //komut.Dispose();
                        baglanti.Kapat();
                        daset.Tables["depogiriscikis"].Clear();
                        Kayıt_Göster();
                        

                        //---------------
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        OleDbDataReader myDataReader4 = baglanti.komut.ExecuteReader();
                        string aa = "";
                        string bb = "";
                        while (myDataReader4.Read())
                        {
                            aa = (myDataReader4["depo_bos"].ToString()); ;

                        }
                        Double kapasite = Double.Parse(aa);
                        Double eksilen = Double.Parse(textBox2.Text);
                        Double sonuc = kapasite - eksilen;


                        baglanti.Kapat();
                        //---------------
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        OleDbDataReader myDataReader5 = baglanti.komut.ExecuteReader();
                        while (myDataReader5.Read())
                        {
                            bb = (myDataReader5["depo_dolu"].ToString()); ;

                        }
                        Double depo_dolu = Double.Parse(bb);
                        Double sonuc2 = depo_dolu + eksilen;
                        //depo_bos icin update islemi
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_bos='" + sonuc.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        baglanti.komut.ExecuteNonQuery();
                        //depo_dolu icin update islemi
                        baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + sonuc2.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        baglanti.komut.ExecuteNonQuery();
                        //komut.Dispose();
                        baglanti.Kapat();
                        MessageBox.Show("Giriş işlemi seçilen satıra göre güncellendi!");
                    }
                    else
                    {
                        MessageBox.Show("Toplam silo kapasitesi aşıldı!");
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
            /*
            anaekran ekran = new anaekran();
            ekran.Anaekran_Load(sender,e);
            */

            //----------------------
            //string id = id_Al("");

            /*
            string date = System.DateTime.Now.ToString();
            string tip = "giris";
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("UPDATE depogiriscikis SET islem_depo='" + comboBox1.Text.ToString() + "',firma_gemi='" + textBox3.Text.ToString() + "',arac_plaka='" + textBox1.Text.ToString() + "',fabrika_tonaj='" + textBox2.Text.ToString() + "',urun_sinifi='" + comboBox2.Text.ToString() + "',urun_grubu='" + comboBox3.Text.ToString() + "',tarih='" + date.ToString() + "',islem_tipi='" + tip + "' WHERE islem_no=" + textBox5.Text + "", baglanti.connection); ;
            baglanti.komut.ExecuteNonQuery();
            //komut.Dispose();
            baglanti.Kapat();
            daset.Tables["depogiriscikis"].Clear();
            Kayıt_Göster();
            MessageBox.Show("Giriş işlemi seçilen satıra göre güncellendi!");

            */
            
        }

        

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = false;
            comboBox1.Enabled = false;
            textBox5.Text = dataGridView1.CurrentRow.Cells["islem_no"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["islem_depo"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["firma_gemi"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["kantar_fisi"].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells["arac_plaka"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["fabrika_tonaj"].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells["urun_sinifi"].Value.ToString();//urun_grubu
            comboBox3.Text = dataGridView1.CurrentRow.Cells["urun_grubu"].Value.ToString();
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        /*
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        */

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //kontroller eklenecek buraya
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        public bool PlakaKontrol(string plaka)
        {
            Regex regex = new Regex("(0[1-9]|[1-7][0-9]|8[01])(([A-Z])(\\d{4,5})|([A-Z]{2})(\\d{3,4})|([A-Z]{3})(\\d{2}))");
            return regex.IsMatch(plaka);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void depogiris_Activated(object sender, EventArgs e)
        {
            depogiris_Load(sender, e);
        }

        private void depogiris_Deactivate(object sender, EventArgs e)
        {
            //comboBox1.Items.Clear();
            //comboBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
            Double sonuc_k = kapasite_k + eksilen_k;


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
            Double sonuc2_k = depo_dolu_k - eksilen_k;

            //depo_bos icin update islemi
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_bos='" + sonuc_k.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            //depo_dolu icin update islemi
            baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + sonuc2_k.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            //komut.Dispose();
            baglanti.Kapat();


            //----------------------------------------------------------------------
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
            Double depo_dolu2 = Double.Parse(cc);
            Double kapasite2 = Double.Parse(dd);
            if (textBox1.Text.Length > 3 && textBox3.Text.Length > 3)
            {


                if (tonaj < 50001 && tonaj > 0)
                {
                    if (depo_dolu2 + tonaj <= kapasite2)
                    {
                        


                        //---------------
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        OleDbDataReader myDataReader4 = baglanti.komut.ExecuteReader();
                        string aa = "";
                        string bb = "";
                        while (myDataReader4.Read())
                        {
                            aa = (myDataReader4["depo_bos"].ToString()); ;

                        }
                        Double kapasite = Double.Parse(aa);
                        Double eksilen = Double.Parse(textBox2.Text);
                        Double sonuc = kapasite - eksilen;


                        baglanti.Kapat();
                        //---------------
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        OleDbDataReader myDataReader5 = baglanti.komut.ExecuteReader();
                        while (myDataReader5.Read())
                        {
                            bb = (myDataReader5["depo_dolu"].ToString()); ;

                        }
                        /*
                        Double depo_dolu = Double.Parse(bb);
                        Double sonuc2 = depo_dolu + eksilen;
                        //depo_bos icin update islemi
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_bos='" + sonuc.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        baglanti.komut.ExecuteNonQuery();
                        //depo_dolu icin update islemi
                        baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + sonuc2.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                        baglanti.komut.ExecuteNonQuery();
                        //komut.Dispose();
                        baglanti.Kapat();
                        */
                        string date = System.DateTime.Now.ToString();
                        string tip = "giris";
                        baglanti.Baslat();
                        baglanti.komut = new OleDbCommand("DELETE from depogiriscikis WHERE islem_no=" + textBox5.Text + "", baglanti.connection); ;
                        baglanti.komut.ExecuteNonQuery();
                        //komut.Dispose();
                        baglanti.Kapat();
                        daset.Tables["depogiriscikis"].Clear();
                        Kayıt_Göster();

                        MessageBox.Show("Giriş işlemi seçilen satıra göre güncellendi!");
                    }
                    else
                    {
                        MessageBox.Show("Toplam silo kapasitesi aşıldı!");
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
    }
}
