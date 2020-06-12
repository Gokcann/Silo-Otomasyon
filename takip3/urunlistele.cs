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
using Microsoft.Office.Interop;



namespace takip3
{
    public partial class urunlistele : Form
    {
        public urunlistele()
        {
            InitializeComponent();
        }
        Baglanti baglanti = new Baglanti();

        /*SqlConnection baglanti = new SqlConnection(@"Data Source=VAIO26;Initial Catalog=C:\Users\devel\Desktop\takip3-Kopya\takip3-Kopya\takip3\stok_takip.mdf;Integrated Security=True");
        DataSet daset = new DataSet();
        */
        DataSet daset = new DataSet();
        private void Urunlistele_Load(object sender, EventArgs e)
        {
            Kayıt_Göster();
            btnuguncel.Enabled = false;
            button2.Enabled = false;

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
            baglanti.adaptor = new OleDbDataAdapter("SELECT * FROM urunlistesi", baglanti.connection);
            baglanti.adaptor.Fill(daset, "urunlistesi");
            dataGridView1.DataSource = daset.Tables["urunlistesi"];
            baglanti.Kapat();


        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnuguncel.Enabled = true;
            button2.Enabled = true;
            txtid.Text = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            txtiskod.Text = dataGridView1.CurrentRow.Cells["isin"].Value.ToString();
            txtugrubu.Text = dataGridView1.CurrentRow.Cells["urun_grubu"].Value.ToString();
            txtusinifi.Text = dataGridView1.CurrentRow.Cells["urun_sinifi"].Value.ToString();
            txtmyili.Text = dataGridView1.CurrentRow.Cells["m_yil"].Value.ToString();
        }

        private void Btnuguncel_Click(object sender, EventArgs e)
        {
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("UPDATE urunlistesi SET urun_grubu='" + txtugrubu.Text.ToString() + "',urun_sinifi='" + txtusinifi.Text.ToString() + "',m_yil='" + txtmyili.Text.ToString() + "',isin='" + txtiskod.Text.ToString() + "' WHERE id=" + txtid.Text.ToString() + "", baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            //komut.Dispose();
            baglanti.Kapat();
            daset.Tables["urunlistesi"].Clear();
            Kayıt_Göster();
            MessageBox.Show("Ürün Listesi Güncellendi");
            /* baglanti.Open();
             SqlCommand komut = new SqlCommand("update urunlistesi set urungrubu=@urungrubu,urunsinifi=@urunsinifi,mahsul_yili=@mahsul_yili,isinkod=@isinkod where Id=@Id", baglanti);
             komut.Parameters.AddWithValue("@Id", txtid.Text.ToString());
             komut.Parameters.AddWithValue("@urungrubu", txtugrubu.Text.ToString());
             komut.Parameters.AddWithValue("@urunsinifi", txtusinifi.Text.ToString());
             komut.Parameters.AddWithValue("@mahsul_yili", txtmyili.Text.ToString());
             komut.Parameters.AddWithValue("@isinkod", txtiskod.Text.ToString());
             komut.ExecuteNonQuery();
             baglanti.Close();
             daset.Tables["urunlistesi"].Clear();
             Kayıt_Göster();
             MessageBox.Show("Ürün Listesi Güncellendi");
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
            /*baglanti.Baslat();
            SqlCommand komut = new SqlCommand("delete from urunlistesi where Id='" + dataGridView1.CurrentRow.Cells["Id"].Value.ToString() + "'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["urunlistesi"].Clear();
            Kayıt_Göster();
            MessageBox.Show("Ürün Silindi");*/
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("delete from urunlistesi where id=" + dataGridView1.CurrentRow.Cells["Id"].Value.ToString(), baglanti.connection);
            baglanti.komut.ExecuteNonQuery();
            //komut.Dispose();
            baglanti.Kapat();
            daset.Tables["urunlistesi"].Clear();
            Kayıt_Göster();
            MessageBox.Show("Ürün Listesi Güncellendi");
        }

        private void Txtisinara_TextChanged(object sender, EventArgs e)
        {
            /*
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from urunlistesi where isinkod like '%" + txtisinara.Text + "%'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
            */
            DataTable tablo = new DataTable();
            baglanti.Baslat();
            baglanti.adaptor = new OleDbDataAdapter("SELECT * FROM urunlistesi WHERE isin like '%"+ txtisinara.Text + "%'", baglanti.connection);
            baglanti.adaptor.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Kapat();


        }

        private void excelButton_Click(object sender, EventArgs e)
        {
            /*
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
            workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            app.Quit();
            */
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
                objRange.Value2 = dataGridView1.Columns[i].HeaderText;

            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range objRange = (Microsoft.Office.Interop.Excel.Range)objSheet.Cells[j + 2, i + 1];
                    objRange.Value2 = dataGridView1[i, j].Value;
                }
            }
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textbox'a sadece sayi girisi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtmyili_KeyPress(object sender, KeyPressEventArgs e)
        {
            //textbox'a sadece sayi girisi
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
