namespace takip3
{
    partial class urunlistele
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtmyili = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtusinifi = new System.Windows.Forms.TextBox();
            this.txtugrubu = new System.Windows.Forms.TextBox();
            this.txtiskod = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnuguncel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtisinara = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.excelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtmyili
            // 
            this.txtmyili.Location = new System.Drawing.Point(97, 160);
            this.txtmyili.Name = "txtmyili";
            this.txtmyili.Size = new System.Drawing.Size(66, 20);
            this.txtmyili.TabIndex = 17;
            this.txtmyili.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmyili_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Mahsul Yılı";
            // 
            // txtusinifi
            // 
            this.txtusinifi.Location = new System.Drawing.Point(97, 131);
            this.txtusinifi.Name = "txtusinifi";
            this.txtusinifi.Size = new System.Drawing.Size(170, 20);
            this.txtusinifi.TabIndex = 15;
            // 
            // txtugrubu
            // 
            this.txtugrubu.Location = new System.Drawing.Point(97, 107);
            this.txtugrubu.Name = "txtugrubu";
            this.txtugrubu.Size = new System.Drawing.Size(170, 20);
            this.txtugrubu.TabIndex = 14;
            // 
            // txtiskod
            // 
            this.txtiskod.Location = new System.Drawing.Point(97, 79);
            this.txtiskod.Name = "txtiskod";
            this.txtiskod.Size = new System.Drawing.Size(170, 20);
            this.txtiskod.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ürün Sınıfı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "ISIN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ürün Grubu";
            // 
            // btnuguncel
            // 
            this.btnuguncel.Location = new System.Drawing.Point(22, 205);
            this.btnuguncel.Name = "btnuguncel";
            this.btnuguncel.Size = new System.Drawing.Size(75, 23);
            this.btnuguncel.TabIndex = 18;
            this.btnuguncel.Text = "Güncelle";
            this.btnuguncel.UseVisualStyleBackColor = true;
            this.btnuguncel.Click += new System.EventHandler(this.Btnuguncel_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(171, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Sil";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(287, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(456, 192);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(538, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "ISIN";
            // 
            // txtisinara
            // 
            this.txtisinara.Location = new System.Drawing.Point(572, 12);
            this.txtisinara.Name = "txtisinara";
            this.txtisinara.Size = new System.Drawing.Size(100, 20);
            this.txtisinara.TabIndex = 22;
            this.txtisinara.TextChanged += new System.EventHandler(this.Txtisinara_TextChanged);
            // 
            // txtid
            // 
            this.txtid.Enabled = false;
            this.txtid.Location = new System.Drawing.Point(97, 53);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(170, 20);
            this.txtid.TabIndex = 24;
            this.txtid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtid_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "ID";
            // 
            // excelButton
            // 
            this.excelButton.Location = new System.Drawing.Point(61, 243);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(141, 23);
            this.excelButton.TabIndex = 25;
            this.excelButton.Text = "Excel\'e aktar";
            this.excelButton.UseVisualStyleBackColor = true;
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // urunlistele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 278);
            this.Controls.Add(this.excelButton);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtisinara);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnuguncel);
            this.Controls.Add(this.txtmyili);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtusinifi);
            this.Controls.Add(this.txtugrubu);
            this.Controls.Add(this.txtiskod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "urunlistele";
            this.Text = "urunlistele";
            this.Load += new System.EventHandler(this.Urunlistele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtmyili;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtusinifi;
        private System.Windows.Forms.TextBox txtugrubu;
        private System.Windows.Forms.TextBox txtiskod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnuguncel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtisinara;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button excelButton;
    }
}