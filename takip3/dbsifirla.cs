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
    public partial class dbsifirla : Form
    {
        public dbsifirla()
        {
            InitializeComponent();
        }
        DataSet daset = new DataSet();
        Baglanti baglanti = new Baglanti();
        string blank = "";
        string zero = "0";
        private void button1_Click(object sender, EventArgs e)
        {
            if ( radioButton2.Checked == true )
            {
                if (securitycode.Text == "xcq19a733b")
                {
                    baglanti.Baslat();
                    //baglanti.komut = new OleDbCommand("DELETE FROM depobilgi ", baglanti.connection);
                    //baglanti.komut.ExecuteNonQuery();
                    //baglanti.komut = new OleDbCommand("DELETE FROM depo ", baglanti.connection);
                    //baglanti.komut.ExecuteNonQuery();
                    baglanti.komut = new OleDbCommand("UPDATE depobilgi SET urun_grubu='" + blank + "' ,urun_sinifi='" + blank + "' ,mahsul_yili='" + blank + "' ,kapasite='" + zero + "' ,depo_bos='" + zero + "' ,depo_dolu='" + zero + "' WHERE depo_id='Silo 1'", baglanti.connection);
                    baglanti.komut.ExecuteNonQuery();
                    baglanti.komut = new OleDbCommand("UPDATE depobilgi SET urun_grubu='" + blank + "' ,urun_sinifi='" + blank + "' ,mahsul_yili='" + blank + "' ,kapasite='" + zero + "' ,depo_bos='" + zero + "' ,depo_dolu='" + zero + "' WHERE depo_id='Silo 2'", baglanti.connection);
                    baglanti.komut.ExecuteNonQuery();
                    baglanti.komut = new OleDbCommand("UPDATE depobilgi SET urun_grubu='" + blank + "' ,urun_sinifi='" + blank + "' ,mahsul_yili='" + blank + "' ,kapasite='" + zero + "' ,depo_bos='" + zero + "' ,depo_dolu='" + zero + "' WHERE depo_id='Silo 3'", baglanti.connection);
                    baglanti.komut.ExecuteNonQuery();
                    baglanti.komut = new OleDbCommand("UPDATE depobilgi SET urun_grubu='" + blank + "' ,urun_sinifi='" + blank + "' ,mahsul_yili='" + blank + "' ,kapasite='" + zero + "' ,depo_bos='" + zero + "' ,depo_dolu='" + zero + "' WHERE depo_id='Silo 4'", baglanti.connection);
                    baglanti.komut.ExecuteNonQuery();
                    baglanti.komut = new OleDbCommand("UPDATE depobilgi SET urun_grubu='" + blank + "' ,urun_sinifi='" + blank + "' ,mahsul_yili='" + blank + "' ,kapasite='" + zero + "' ,depo_bos='" + zero + "' ,depo_dolu='" + zero + "' WHERE depo_id='Silo 5'", baglanti.connection);
                    baglanti.komut.ExecuteNonQuery();
                    baglanti.komut = new OleDbCommand("UPDATE depobilgi SET urun_grubu='" + blank + "' ,urun_sinifi='" + blank + "' ,mahsul_yili='" + blank + "' ,kapasite='" + zero + "' ,depo_bos='" + zero + "' ,depo_dolu='" + zero + "' WHERE depo_id='Silo 6'", baglanti.connection);
                    baglanti.komut.ExecuteNonQuery();
                    baglanti.komut = new OleDbCommand("UPDATE depobilgi SET urun_grubu='" + blank + "' ,urun_sinifi='" + blank + "' ,mahsul_yili='" + blank + "' ,kapasite='" + zero + "' ,depo_bos='" + zero + "' ,depo_dolu='" + zero + "' WHERE depo_id='Silo 7'", baglanti.connection);
                    baglanti.komut.ExecuteNonQuery();
                    baglanti.komut = new OleDbCommand("UPDATE depobilgi SET urun_grubu='" + blank + "' ,urun_sinifi='" + blank + "' ,mahsul_yili='" + blank + "' ,kapasite='" + zero + "' ,depo_bos='" + zero + "' ,depo_dolu='" + zero + "' WHERE depo_id='Silo 8'", baglanti.connection);
                    baglanti.komut.ExecuteNonQuery();
                    baglanti.komut = new OleDbCommand("DELETE FROM depogiriscikis ", baglanti.connection);
                    baglanti.komut.ExecuteNonQuery();
                    baglanti.komut = new OleDbCommand("DELETE FROM urunlistesi ", baglanti.connection);
                    baglanti.komut.ExecuteNonQuery();
                    baglanti.Kapat();
                }
                else
                {
                    MessageBox.Show("Sifre hatali!");
                }
            }else
            {
                baglanti.Baslat();
                string free = "";
                string zero = "0";
                baglanti.komut = new OleDbCommand("UPDATE depobilgi SET urun_grubu='" + free + "',urun_sinifi='" + free + "',mahsul_yili='"+ free + "',kapasite='" + zero + "',depo_bos='" + zero + "',depo_dolu='" + zero + "' WHERE depo_id='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                baglanti.komut.ExecuteNonQuery();
                //baglanti.komut = new OleDbCommand("DELETE FROM depo ", baglanti.connection);
                //baglanti.komut.ExecuteNonQuery();
                baglanti.komut = new OleDbCommand("DELETE FROM depogiriscikis WHERE islem_depo='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                baglanti.komut.ExecuteNonQuery();
                baglanti.komut = new OleDbCommand("DELETE FROM depoasim WHERE islem_depo='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                baglanti.komut.ExecuteNonQuery();
                //baglanti.komut = new OleDbCommand("DELETE FROM aktarma WHERE islem_depo='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                //baglanti.komut.ExecuteNonQuery();
                baglanti.Kapat();
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
        }

        private void dbsifirla_Load(object sender, EventArgs e)
        {
            Form aecontrol = new anaekran();
            
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi ", baglanti.connection);
            //baglanti.adaptor.Fill(daset, "depobilgi");
            OleDbDataReader myDataReader1 = baglanti.komut.ExecuteReader();
            while (myDataReader1.Read())
            {
                comboBox1.Items.Add(myDataReader1["depo_id"].ToString()); ;

            }
            baglanti.Kapat();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
        }
    }
}
