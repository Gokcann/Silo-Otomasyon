namespace takip3
{
    partial class depotanimla
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbdepotanimla = new System.Windows.Forms.ComboBox();
            this.cmbudepotanimla = new System.Windows.Forms.ComboBox();
            this.cmburunsinifi = new System.Windows.Forms.ComboBox();
            this.cmbmyili = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.d = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Depo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ürün Grubu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ürün Sınıfı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mahsul Yılı";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(147, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "KAYDET";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // cmbdepotanimla
            // 
            this.cmbdepotanimla.BackColor = System.Drawing.SystemColors.Window;
            this.cmbdepotanimla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdepotanimla.FormattingEnabled = true;
            this.cmbdepotanimla.Location = new System.Drawing.Point(109, 9);
            this.cmbdepotanimla.Name = "cmbdepotanimla";
            this.cmbdepotanimla.Size = new System.Drawing.Size(208, 21);
            this.cmbdepotanimla.TabIndex = 5;
            // 
            // cmbudepotanimla
            // 
            this.cmbudepotanimla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbudepotanimla.FormattingEnabled = true;
            this.cmbudepotanimla.Location = new System.Drawing.Point(109, 39);
            this.cmbudepotanimla.Name = "cmbudepotanimla";
            this.cmbudepotanimla.Size = new System.Drawing.Size(208, 21);
            this.cmbudepotanimla.TabIndex = 6;
            // 
            // cmburunsinifi
            // 
            this.cmburunsinifi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmburunsinifi.FormattingEnabled = true;
            this.cmburunsinifi.Location = new System.Drawing.Point(109, 66);
            this.cmburunsinifi.Name = "cmburunsinifi";
            this.cmburunsinifi.Size = new System.Drawing.Size(208, 21);
            this.cmburunsinifi.TabIndex = 7;
            // 
            // cmbmyili
            // 
            this.cmbmyili.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmyili.FormattingEnabled = true;
            this.cmbmyili.Location = new System.Drawing.Point(109, 93);
            this.cmbmyili.Name = "cmbmyili";
            this.cmbmyili.Size = new System.Drawing.Size(208, 21);
            this.cmbmyili.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Depo Kapasite";
            // 
            // d
            // 
            this.d.Location = new System.Drawing.Point(109, 122);
            this.d.Name = "d";
            this.d.Size = new System.Drawing.Size(208, 20);
            this.d.TabIndex = 10;
            this.d.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.d_KeyPress);
            // 
            // depotanimla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(349, 188);
            this.Controls.Add(this.d);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbmyili);
            this.Controls.Add(this.cmburunsinifi);
            this.Controls.Add(this.cmbudepotanimla);
            this.Controls.Add(this.cmbdepotanimla);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "depotanimla";
            this.Text = "depotanimla";
            this.Load += new System.EventHandler(this.Depotanimla_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbudepotanimla;
        private System.Windows.Forms.ComboBox cmburunsinifi;
        private System.Windows.Forms.ComboBox cmbmyili;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox d;
        public System.Windows.Forms.ComboBox cmbdepotanimla;
    }
}