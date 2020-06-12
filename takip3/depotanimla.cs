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
    public partial class depotanimla : Form
    {
        public depotanimla()
        {
            InitializeComponent();
        }
        Baglanti baglanti = new Baglanti();
        //SqlConnection baglanti = new SqlConnection(@"Data Source=VAIO26;Initial Catalog=C:\Users\devel\Desktop\takip3-Kopya\takip3-Kopya\takip3\stok_takip.mdf;Integrated Security=True");
        private void Depotanimla_Load(object sender, EventArgs e)
        {
            /*DataSet daset = new DataSet();
            baglanti.Open();
            SqlCommand komut = baglanti.CreateCommand();
            komut.CommandText = "select * from depo";

            SqlDataReader myDataReader = komut.ExecuteReader();

            while (myDataReader.Read())
            {
                cmbdepotanimla.Items.Add(myDataReader["depo"].ToString());

            }
            {

                SqlConnection baglanti1 = new SqlConnection(@"Data Source=VAIO26;Initial Catalog=C:\Users\devel\Desktop\takip3-Kopya\takip3-Kopya\takip3\stok_takip.mdf;Integrated Security=True");
                DataSet daset1 = new DataSet();
                baglanti1.Open();
                SqlCommand komut1 = baglanti1.CreateCommand();
                komut1.CommandText = "select * from urunugrubu";

                SqlDataReader myDataReader1 = komut1.ExecuteReader();

                while (myDataReader1.Read())
                {
                    cmbudepotanimla.Items.Add(myDataReader1["urunugrubu"].ToString());


                }
                {
                    SqlConnection baglanti2 = new SqlConnection(@"Data Source=VAIO26;Initial Catalog=C:\Users\devel\Desktop\takip3-Kopya\takip3-Kopya\takip3\stok_takip.mdf;Integrated Security=True");
                    DataSet daset2 = new DataSet();
                    baglanti2.Open();
                    SqlCommand komut2 = baglanti2.CreateCommand();
                    komut2.CommandText = "select * from urunsinifi";

                    SqlDataReader myDataReader2 = komut2.ExecuteReader();

                    while (myDataReader2.Read())
                    {
                        cmburunsinifi.Items.Add(myDataReader2["urunsinifi"].ToString());

                    }
                    {

                        SqlConnection baglanti3 = new SqlConnection(@"Data Source=VAIO26;Initial Catalog=C:\Users\devel\Desktop\takip3-Kopya\takip3-Kopya\takip3\stok_takip.mdf;Integrated Security=True");
                        DataSet daset3 = new DataSet();
                        baglanti3.Open();
                        SqlCommand komut3 = baglanti3.CreateCommand();
                        komut3.CommandText = "select * from mahsulyil";

                        SqlDataReader myDataReader3 = komut3.ExecuteReader();

                        while (myDataReader3.Read())
                        {
                            cmbmyili.Items.Add(myDataReader3["mahsul_yil"].ToString());


                        }
                    }
                }
            } baglanti.Close();
            */

            DataSet daset = new DataSet();
            //baglanti.Open();
            baglanti.Baslat();
            //SqlCommand komut = baglanti.CreateCommand();
            baglanti.komut = new OleDbCommand("SELECT * FROM depo", baglanti.connection);
            //komut.CommandText = "select * from depo";

            OleDbDataReader myDataReader = baglanti.komut.ExecuteReader();

            while (myDataReader.Read())
            {
                cmbdepotanimla.Items.Add(myDataReader["depo_no"].ToString());

            }
            {

                //SqlConnection baglanti1 = new SqlConnection(@"Data Source=VAIO26;Initial Catalog=C:\Users\devel\Desktop\takip3-Kopya\takip3-Kopya\takip3\stok_takip.mdf;Integrated Security=True");
                DataSet daset1 = new DataSet();
                //baglanti1.Open();
                baglanti.komut = new OleDbCommand("SELECT * FROM urungrubu", baglanti.connection);
                //SqlCommand komut1 = baglanti1.CreateCommand();
                //komut1.CommandText = "select * from urunugrubu";

                OleDbDataReader myDataReader1 = baglanti.komut.ExecuteReader();

                while (myDataReader1.Read())
                {
                    cmbudepotanimla.Items.Add(myDataReader1["urun_grubu"]);

                }
                {
                    //SqlConnection baglanti2 = new SqlConnection(@"Data Source=VAIO26;Initial Catalog=C:\Users\devel\Desktop\takip3-Kopya\takip3-Kopya\takip3\stok_takip.mdf;Integrated Security=True");
                    DataSet daset2 = new DataSet();
                    //baglanti2.Open();
                    //SqlCommand komut2 = baglanti2.CreateCommand();
                    //komut2.CommandText = "select * from urunsinifi";
                    baglanti.komut = new OleDbCommand("SELECT * FROM urunsinifi", baglanti.connection);
                    OleDbDataReader myDataReader2 = baglanti.komut.ExecuteReader();

                    while (myDataReader2.Read())
                    {
                        cmburunsinifi.Items.Add(myDataReader2["urun_sinifi"].ToString());

                    }
                    {

                        //SqlConnection baglanti3 = new SqlConnection(@"Data Source=VAIO26;Initial Catalog=C:\Users\devel\Desktop\takip3-Kopya\takip3-Kopya\takip3\stok_takip.mdf;Integrated Security=True");
                        DataSet daset3 = new DataSet();
                        //baglanti3.Open();
                        //SqlCommand komut3 = baglanti3.CreateCommand();
                        //komut3.CommandText = "select * from mahsulyil";
                        baglanti.komut = new OleDbCommand("SELECT * FROM mahsulyil ", baglanti.connection);
                        OleDbDataReader myDataReader3 = baglanti.komut.ExecuteReader();
                        //SqlDataReader myDataReader3 = komut3.ExecuteReader();

                        while (myDataReader3.Read())
                        {
                            cmbmyili.Items.Add(myDataReader3["mahsul_yil"].ToString()); ;
                            
                        }
                    }
                }
            }
            baglanti.Kapat();
        }
        public static string depo;

        public bool SayiMi(string text)
        {
            foreach (char chr in text)
            {
                if (!Char.IsNumber(chr))
                    return false;
            }
            return true;
        }

        public bool SiloBosMu()
        {
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi WHERE depo_id='" + cmbdepotanimla.SelectedItem.ToString() + "'", baglanti.connection);
            OleDbDataReader myDataReader4k = baglanti.komut.ExecuteReader();
            string aa_k = "";
            while (myDataReader4k.Read())
            {
                aa_k = (myDataReader4k["depo_dolu"].ToString()); ;

            }
            if ( aa_k == "" )
            {
                return true;
                
            }else
            {
                Double depodolu = Double.Parse(aa_k);
                baglanti.Kapat();
                if (depodolu == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            //anaekran ae = (anaekran)Application.OpenForms["anaekran"];
            //ae.depolbl1.Text = "merhaba";
            //SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vaio2\Desktop\takip3\takip3\stok_takip.mdf;Integrated Security=True");
            //int id = 1;
            /*if (cmbdepotanimla.SelectedIndex == 0)
            {
                id = 1;
            }
            else if (cmbdepotanimla.SelectedIndex == 1)
            {
                id = 2;
            }*/
            //Double kontrol = Double.Parse(d.Text);
            if ( SiloBosMu() )
            {
                if ( cmbudepotanimla.SelectedIndex != -1 && cmburunsinifi.SelectedIndex != -1 && cmbmyili.SelectedIndex != -1) 
                {
                    if (SayiMi(d.Text) && d.Text != String.Empty && Double.Parse(d.Text) > 0)
                    {
                        Baglanti baglantiup = new Baglanti();
                        baglantiup.Baslat();
                        //SqlCommand komut = baglanti.CreateCommand();
                        //
                        //komut.CommandText = "UPDATE depobilgi set(urun_grubu=@item1,urun_sinifi=@item2,mahsul_yili=@item3,kapasite=@item4) VALUES ('@item1','@item2','@item3','@item4') WHERE Id='" + cmbdepotanimla.SelectedIndex + 1 + "'";
                        //OleDbCommand komut = new OleDbCommand("UPDATE depobilgi SET urun_grubu=@item1,urun_sinifi=@item2,mahsul_yili=@item3,kapasite=@item4 WHERE depo_id=@item5", baglanti.connection);
                        //komut.CommandText = "UPDATE depobilgi SET urun_grubu=@item1,urun_sinifi=@item2,mahsul_yili=@item3,kapasite=@item4 WHERE Id=@item5";
                        /*komut.Parameters.AddWithValue("@item1", cmbudepotanimla.SelectedItem.ToString());
                        komut.Parameters.AddWithValue("@item2", cmburunsinifi.SelectedItem.ToString());
                        komut.Parameters.AddWithValue("@item3", cmbmyili.SelectedItem.ToString());
                        komut.Parameters.AddWithValue("@item4", d.Text.ToString());
                        komut.Parameters.AddWithValue("@item5", cmbdepotanimla.SelectedIndex +1);
                        */
                        int deneme = 0;
                        baglantiup.komut = new OleDbCommand("UPDATE depobilgi SET urun_grubu='" + cmbudepotanimla.SelectedItem.ToString() + "',urun_sinifi='" + cmburunsinifi.SelectedItem.ToString() + "',mahsul_yili='" + cmbmyili.SelectedItem.ToString() + "',kapasite='" + d.Text.ToString() + "',depo_bos='" + d.Text.ToString() + "',depo_dolu='" + deneme.ToString() + "' WHERE depo_id='" + cmbdepotanimla.SelectedItem.ToString() + "'", baglantiup.connection);
                        baglantiup.komut.ExecuteNonQuery();
                        //komut.Dispose();
                        baglantiup.Kapat();
                        MessageBox.Show("Depo Eklendi");

                        anaekran ae = (anaekran)Application.OpenForms["anaekran"];
                        int update_silo = cmbdepotanimla.SelectedIndex + 1;
                        switch (update_silo)
                        {
                            case 1:
                                ae.silo1urungrubu.Text = cmbudepotanimla.SelectedItem.ToString();
                                ae.silo1urunsinifi.Text = cmburunsinifi.SelectedItem.ToString();
                                ae.silo1mahsulyili.Text = cmbmyili.SelectedItem.ToString();
                                ae.silo1kapasite.Text = d.Text.ToString();
                                break;
                            case 2:
                                ae.silo2urungrubu.Text = cmbudepotanimla.SelectedItem.ToString();
                                ae.silo2urunsinifi.Text = cmburunsinifi.SelectedItem.ToString();
                                ae.silo2mahsulyili.Text = cmbmyili.SelectedItem.ToString();
                                ae.silo2kapasite.Text = d.Text.ToString();
                                break;
                            case 3:
                                ae.silo3urungrubu.Text = cmbudepotanimla.SelectedItem.ToString();
                                ae.silo3urunsinifi.Text = cmburunsinifi.SelectedItem.ToString();
                                ae.silo3mahsulyili.Text = cmbmyili.SelectedItem.ToString();
                                ae.silo3kapasite.Text = d.Text.ToString();
                                break;
                            case 4:
                                ae.silo4urungrubu.Text = cmbudepotanimla.SelectedItem.ToString();
                                ae.silo4urunsinifi.Text = cmburunsinifi.SelectedItem.ToString();
                                ae.silo4mahsulyili.Text = cmbmyili.SelectedItem.ToString();
                                ae.silo4kapasite.Text = d.Text.ToString();
                                break;
                            case 5:
                                ae.silo5urungrubu.Text = cmbudepotanimla.SelectedItem.ToString();
                                ae.silo5urunsinifi.Text = cmburunsinifi.SelectedItem.ToString();
                                ae.silo5mahsulyili.Text = cmbmyili.SelectedItem.ToString();
                                ae.silo5kapasite.Text = d.Text.ToString();
                                break;
                            case 6:
                                ae.silo6urungrubu.Text = cmbudepotanimla.SelectedItem.ToString();
                                ae.silo6urunsinifi.Text = cmburunsinifi.SelectedItem.ToString();
                                ae.silo6mahsulyili.Text = cmbmyili.SelectedItem.ToString();
                                ae.silo6kapasite.Text = d.Text.ToString();
                                break;
                            case 7:
                                ae.silo7urungrubu.Text = cmbudepotanimla.SelectedItem.ToString();
                                ae.silo7urunsinifi.Text = cmburunsinifi.SelectedItem.ToString();
                                ae.silo7mahsulyili.Text = cmbmyili.SelectedItem.ToString();
                                ae.silo7kapasite.Text = d.Text.ToString();
                                break;
                            case 8:
                                ae.silo8urungrubu.Text = cmbudepotanimla.SelectedItem.ToString();
                                ae.silo8urunsinifi.Text = cmburunsinifi.SelectedItem.ToString();
                                ae.silo8mahsulyili.Text = cmbmyili.SelectedItem.ToString();
                                ae.silo8kapasite.Text = d.Text.ToString();
                                break;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Depo kapasitesi 0 değerinden küçük olamaz!");
                    }
                }else
                {
                    MessageBox.Show("Lütfen Ürün Grubu/Ürün Sınıfı/Mahsul Yılı seçimlerini yapınız...");
                }
                
            }else
            {
                MessageBox.Show("Lütfen silonun boş olduğundan emin olunuz.");
            }
            
            







        }

        private void d_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textbox'a sadece sayi girisi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
