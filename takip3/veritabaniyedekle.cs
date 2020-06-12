using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace takip3
{
    public partial class veritabaniyedekle : Form
    {
        public veritabaniyedekle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
    }
}
