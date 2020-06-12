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
using Microsoft.Office.Interop;


namespace takip3
{
    public partial class aktarma : Form
    {
        public aktarma()
        {
            InitializeComponent();
        }
        //formdaki textboxlara ctrl+v(copy) yapilmasini engeller
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData & Keys.Control) > 0 && (keyData & Keys.KeyCode) == Keys.V)
            {
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        Baglanti baglanti = new Baglanti();

        private void button1_Click(object sender, EventArgs e)
        {

            //-------------------------------------------------------
            //aktarma yapilirken eksiye düsme kontrolu

            int aktarma_k = 0;
            aktarma_k = Int32.Parse(textBox3.Text);

            //kapasite kontrolü
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
            OleDbDataReader myDataReader3k = baglanti.komut.ExecuteReader();
            string birinciBos = "";
            string birinciDolu = "";
            string birinciKapasite = "";
            string ikinciBos = "";
            string ikinciDolu = "";
            string ikinciKapasite = "";
            while (myDataReader3k.Read())
            {
                birinciBos = (myDataReader3k["depo_bos"].ToString());
                birinciDolu = (myDataReader3k["depo_dolu"].ToString());
                birinciKapasite = (myDataReader3k["kapasite"].ToString());

            }
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox2.SelectedItem.ToString() + "'", baglanti.connection);
            OleDbDataReader myDataReader6k = baglanti.komut.ExecuteReader();
            while (myDataReader6k.Read())
            {
                ikinciBos = (myDataReader6k["depo_bos"].ToString());
                ikinciDolu = (myDataReader6k["depo_dolu"].ToString());
                ikinciKapasite = (myDataReader6k["depo_dolu"].ToString());

            }
            Double birinciBosDepo = Double.Parse(birinciBos);
            Double birinciDoluDepo = Double.Parse(birinciDolu);
            Double birinciKapasiteDepo = Double.Parse(birinciKapasite);
            Double ikinciBosDepo = Double.Parse(ikinciBos);
            Double ikinciDoluDepo = Double.Parse(ikinciDolu);
            Double ikinciKapasiteDepo = Double.Parse(ikinciKapasite);
            //-------------------------------------------------------
            if ((aktarma_k < birinciDoluDepo + 1) && (aktarma_k < ikinciBosDepo + 1))
            {
                if (aktarma_k > 0 && aktarma_k < 100000)
                {


                    baglanti.Baslat();
                    baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi  WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection); ;
                    OleDbDataReader myDataReader1 = baglanti.komut.ExecuteReader();
                    baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi  WHERE depo_id='" + comboBox2.SelectedItem.ToString() + "'", baglanti.connection); ;
                    OleDbDataReader myDataReader2 = baglanti.komut.ExecuteReader();

                    bool control;

                    if (myDataReader1.Read() && myDataReader2.Read())
                    {
                        control = true;
                    }
                    else
                    {
                        control = false;
                    }

                    if (control && myDataReader1["urun_sinifi"].ToString() == myDataReader2["urun_sinifi"].ToString() && myDataReader2["urun_grubu"].ToString() == myDataReader1["urun_grubu"].ToString())
                    {
                        if (textBox3.Text == "0")
                        {
                            MessageBox.Show("Girilen kayit degeri sifir olamaz");
                        }
                        else
                        {
                            Double kapasite = Double.Parse(textBox1.Text);
                            Double ikinci = Double.Parse(textBox3.Text);
                            Double ucuncu = Double.Parse(textBox2.Text);
                            Double sonuc = kapasite - ikinci;
                            Double sonuc2 = ucuncu + ikinci;

                            baglanti.Baslat();
                            baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + sonuc.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                            baglanti.komut.ExecuteNonQuery();

                            baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_dolu='" + sonuc2.ToString() + "' WHERE depo_id='" + comboBox2.SelectedItem.ToString() + "'", baglanti.connection);
                            baglanti.komut.ExecuteNonQuery();
                            baglanti.Kapat();

                            //depo_bos isleminin tamamlanmasi
                            baglanti.Baslat();
                            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                            OleDbDataReader myDataReader3 = baglanti.komut.ExecuteReader();
                            //SqlDataReader myDataReader3 = komut3.ExecuteReader();
                            string aa = "";

                            while (myDataReader3.Read())
                            {
                                aa = myDataReader3["depo_bos"].ToString(); ;
                                //bb = myDataReader3["depo_bos"].ToString(); ;

                            }
                            Double depoBosSonuc = Double.Parse(aa) + Double.Parse(textBox3.Text);
                            baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_bos='" + depoBosSonuc.ToString() + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                            baglanti.komut.ExecuteNonQuery();
                            baglanti.Kapat();

                            baglanti.Baslat();
                            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + comboBox2.SelectedItem.ToString() + "'", baglanti.connection);
                            OleDbDataReader myDataReader4 = baglanti.komut.ExecuteReader();
                            string bb = "";
                            while (myDataReader4.Read())
                            {
                                //aa = myDataReader3["depo_bos"].ToString(); ;
                                bb = myDataReader4["depo_bos"].ToString(); ;

                            }

                            Double depoBosSonuc2 = Double.Parse(bb) - Double.Parse(textBox3.Text);
                            baglanti.komut = new OleDbCommand("UPDATE depobilgi SET depo_bos='" + depoBosSonuc2.ToString() + "' WHERE depo_id='" + comboBox2.SelectedItem.ToString() + "'", baglanti.connection);
                            baglanti.komut.ExecuteNonQuery();
                            baglanti.Kapat();

                            //aktarma islemini veritabanina kaydedilmesi
                            string date = System.DateTime.Now.ToString();
                            string tip = "giris";
                            baglanti.Baslat();
                            baglanti.komut = new OleDbCommand("INSERT INTO aktarma (cikan_depo,aktarilan_depo,tarih,miktar) VALUES (@item1,@item2,@item3,@item4)", baglanti.connection);
                            baglanti.komut.Parameters.AddWithValue("@item1", comboBox1.SelectedItem.ToString());
                            baglanti.komut.Parameters.AddWithValue("@item2", comboBox2.SelectedItem.ToString());
                            baglanti.komut.Parameters.AddWithValue("@item3", date);
                            baglanti.komut.Parameters.AddWithValue("@item4", textBox3.Text.ToString());


                            baglanti.komut.ExecuteNonQuery();
                            baglanti.Kapat();
                            MessageBox.Show("Aktarma İslemi Tamamlandi");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Urun grubu veya urun sinifi uyusmuyor!");
                    }

                    baglanti.Kapat();



                }
                else
                {
                    MessageBox.Show("Aktarma miktarı 0-100000 arasında olmalıdır!");
                }
            }
            else
            {
                MessageBox.Show("Aktarma islemi silo kapasitesi disina cikiyor");
            }


        }

        private void aktarma_Load(object sender, EventArgs e)
        {
            baglanti.Baslat();
            DataSet daset = new DataSet();
            baglanti.adaptor = new OleDbDataAdapter("SELECT * FROM depobilgi", baglanti.connection);
            baglanti.adaptor.Fill(daset, "depobilgi");
            //dataGridView1.DataSource = daset.Tables["depobilgi"];


            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi", baglanti.connection);
            OleDbDataReader myDataReader3 = baglanti.komut.ExecuteReader();
            //SqlDataReader myDataReader3 = komut3.ExecuteReader();

            while (myDataReader3.Read())
            {
                comboBox1.Items.Add(myDataReader3["depo_id"].ToString()); ;
                comboBox2.Items.Add(myDataReader3["depo_id"].ToString()); ;

            }
            baglanti.Kapat();
            /*
            baglanti.komut = new OleDbCommand("SELECT * FROM urungrubu ", baglanti.connection);
            OleDbDataReader myDataReader5 = baglanti.komut.ExecuteReader();
            //SqlDataReader myDataReader3 = komut3.ExecuteReader();
            
            while (myDataReader5.Read())
            {
                comboBox3.Items.Add(myDataReader5["urun_grubu"].ToString()); ;

            }
            baglanti.Kapat();
            */
            dataGridView1.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi  WHERE depo_id='" + comboBox1.SelectedItem.ToString()+"'", baglanti.connection); ;
            OleDbDataReader myDataReader4 = baglanti.komut.ExecuteReader();

            while (myDataReader4.Read())
            {
                textBox1.Text = (myDataReader4["depo_dolu"].ToString()); ;

            }
            baglanti.Kapat();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi  WHERE depo_id='" + comboBox2.SelectedItem.ToString()+"'", baglanti.connection); ;
            OleDbDataReader myDataReader4 = baglanti.komut.ExecuteReader();

            while (myDataReader4.Read())
            {
                textBox2.Text = (myDataReader4["depo_dolu"].ToString()); ;

            }
            baglanti.Kapat();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime t1, t2, t3;
            t1 = dateTimePicker1.Value;
            t2 = dateTimePicker2.Value;
            //eger ikinci tarih birinci tarihten daha kucukse bunun kontrolunu yapiyoruz
            //ve tarihlerin yerlerini degistirerek sorgu icin kullanima hazirliyoruz.
            if ( t2 < t1 )
            {
                t3 = t2;
                t2 = t1;
                t1 = t3;
            }
            
            //string date1 = System.DateTime.Now.ToString();
            //string date2 = System.DateTime.Now.ToString();
            DataSet daset = new DataSet();
            DataTable dt = new DataTable();
            baglanti.Baslat();
            baglanti.adaptor = new OleDbDataAdapter("SELECT * FROM aktarma WHERE tarih between #" + t1.ToString("yyyy-M-dd hh:mm:ss") + "# and #" + t2.ToString("yyyy-M-dd hh:mm:ss") + "#", baglanti.connection);
            //baglanti.adaptor = new OleDbDataAdapter("SELECT * FROM depogiriscikis WHERE islem_depo='" + comboBox1.SelectedIndex.ToString() + "'", baglanti.connection);
            //baglanti.adaptor.Fill(dt);
            //dataGridView1.DataSource = dt;
            baglanti.adaptor.Fill(daset, "aktarma");
            dataGridView1.DataSource = daset.Tables["aktarma"];
            baglanti.Kapat();


            //
            excele_aktar(dataGridView1);
        }

        void excele_aktar(DataGridView dg)
        {
            /*
            dg.AllowUserToAddRows = false;
            System.Globalization.CultureInfo dil = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-us");
            Microsoft.Office.Interop.Excel.Application Tablo = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook kitap = Tablo.Workbooks.Add(true);
            Microsoft.Office.Interop.Excel.Worksheet sayfa = (Microsoft.Office.Interop.Excel.Worksheet)Tablo.ActiveSheet;
            System.Threading.Thread.CurrentThread.CurrentCulture = dil;
            Tablo.Visible = true;
            sayfa = (Worksheet)kitap.ActiveSheet;
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                for (int j = 0; j < dg.ColumnCount; j++)
                {
                    if (i == 0)
                    {
                        Tablo.Cells[1, j + 1] = dg.Columns[j].HeaderText;
                    }
                    Tablo.Cells[i + 2, j + 1] = dg.Rows[i].Cells[j].Value.ToString();
                }
            }
            Tablo.Visible = true;
            Tablo.UserControl = true;
            */
            Microsoft.Office.Interop.Excel.Application Excelver = new Microsoft.Office.Interop.Excel.Application();
            Excelver.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook objBook = Excelver.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet objSheet = (Microsoft.Office.Interop.Excel.Worksheet)objBook.Worksheets.get_Item(1);
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                Microsoft.Office.Interop.Excel.Range objRange = (Microsoft.Office.Interop.Excel.Range)objSheet.Cells[1, i + 1];
                //objRange.Clear();
                objRange.Value2 = dataGridView1.Columns[i].HeaderText;

            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range objRange = (Microsoft.Office.Interop.Excel.Range)objSheet.Cells[j + 2, i + 1];
                    //objRange.Clear();
                    objRange.Value2 = dataGridView1[i, j].Value;
                }
            }
            //objSheet.Range["D:D"].NumberFormat.Number;
            //objSheet.Range["D:D"].NumberFormat = "0";
            objSheet.Range["D:D"].NumberFormat = "dd.mm.yyyy hh:mm:ss";

            //objSheet.Range["D:D"].NumberFormat.NumberGroupSeperator = ".";
            //Excelver.Quit();
            //objBook.Close();
            //objSheet.ClearArrows();

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textbox'a sadece sayi girisi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
