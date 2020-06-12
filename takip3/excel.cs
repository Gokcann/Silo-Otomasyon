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
    public partial class excel : Form
    {
        public excel()
        {
            InitializeComponent();
        }
        Baglanti baglanti = new Baglanti();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            excele_aktar(dataGridView1);
            
        }

        private void excel_Load(object sender, EventArgs e)
        {
            baglanti.Baslat();
            baglanti.komut = new OleDbCommand("SELECT * FROM depobilgi", baglanti.connection);
            OleDbDataReader myDataReader = baglanti.komut.ExecuteReader();
            while (myDataReader.Read())
            {
                comboBox1.Items.Add(myDataReader["depo_id"].ToString());

            }
            baglanti.Kapat();
            comboBox2.Items.Add("giris");
            comboBox2.Items.Add("cikis");
            comboBox2.Items.Add("tumu");
            comboBox2.Items.Add("Depo Aşımı");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet daset = new DataSet();
            DataTable dt = new DataTable();
            baglanti.Baslat();
            if (comboBox2.SelectedIndex == 2)
            {
                baglanti.adaptor = new OleDbDataAdapter("SELECT * FROM depogiriscikis WHERE islem_depo='"+ comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                //baglanti.adaptor = new OleDbDataAdapter("SELECT * FROM depogiriscikis WHERE islem_depo='" + comboBox1.SelectedIndex.ToString() + "'", baglanti.connection);
                //baglanti.adaptor.Fill(dt);
                //dataGridView1.DataSource = dt;
                baglanti.adaptor.Fill(daset, "depogiriscikis");
                dataGridView1.DataSource = daset.Tables["depogiriscikis"];
                baglanti.Kapat();

            }
            if (comboBox2.SelectedIndex ==3)
            {
                baglanti.adaptor = new OleDbDataAdapter("SELECT * FROM depoasim WHERE islem_depo='" + comboBox1.SelectedItem.ToString() + "'", baglanti.connection);
                //baglanti.adaptor = new OleDbDataAdapter("SELECT * FROM depogiriscikis WHERE islem_depo='" + comboBox1.SelectedIndex.ToString() + "'", baglanti.connection);
                //baglanti.adaptor.Fill(dt);
                //dataGridView1.DataSource = dt;
                baglanti.adaptor.Fill(daset, "depoasim");
                dataGridView1.DataSource = daset.Tables["depoasim"];
                baglanti.Kapat();
            }
            else
            {
                baglanti.adaptor = new OleDbDataAdapter("SELECT * FROM depogiriscikis WHERE islem_depo='" + comboBox1.SelectedItem.ToString() + "' AND islem_tipi='" + comboBox2.SelectedItem.ToString() + "'", baglanti.connection);
                //baglanti.adaptor = new OleDbDataAdapter("SELECT * FROM depogiriscikis WHERE islem_depo='" + comboBox1.SelectedIndex.ToString() + "'", baglanti.connection);
                //baglanti.adaptor.Fill(dt);
                //dataGridView1.DataSource = dt;
                baglanti.adaptor.Fill(daset, "depogiriscikis");
                dataGridView1.DataSource = daset.Tables["depogiriscikis"];
                baglanti.Kapat();
                //this.dataGridView1.Columns["islem_depo","firma_gemi","arac_plaka","fabrika_tonaj","urun_sinifi","urun_grubu","tarih"].SortMode = DataGridViewColumnSortMode.Automatic;


            }


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
            objSheet.Range["D:D"].NumberFormat = "#,###,###";

            

            //objSheet.Range["D:D"].NumberFormat.NumberGroupSeperator = ".";
            //Excelver.Quit();
            //objBook.Close();
            //objSheet.ClearArrows();
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //dataGridView1.Rows[dataGridView1.Rows.Count-1].Cells[dataGridView1.Columns.Count-1].Style.BackColor = Color.Yellow;

        }
    }

}
