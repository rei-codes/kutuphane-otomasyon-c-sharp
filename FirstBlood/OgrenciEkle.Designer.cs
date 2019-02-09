namespace FirstBlood
{
    partial class OgrenciEkle
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
            this.tel_Textbox = new System.Windows.Forms.TextBox();
            this.eposta_Textbox = new System.Windows.Forms.TextBox();
            this.ad_Textbox = new System.Windows.Forms.TextBox();
            this.soyad_Textbox = new System.Windows.Forms.TextBox();
            this.tc_Textbox = new System.Windows.Forms.TextBox();
            this.ekle_Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tel_Textbox
            // 
            this.tel_Textbox.Location = new System.Drawing.Point(122, 195);
            this.tel_Textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tel_Textbox.Name = "tel_Textbox";
            this.tel_Textbox.Size = new System.Drawing.Size(131, 22);
            this.tel_Textbox.TabIndex = 10;
            // 
            // eposta_Textbox
            // 
            this.eposta_Textbox.Location = new System.Drawing.Point(122, 154);
            this.eposta_Textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eposta_Textbox.Name = "eposta_Textbox";
            this.eposta_Textbox.Size = new System.Drawing.Size(131, 22);
            this.eposta_Textbox.TabIndex = 11;
            // 
            // ad_Textbox
            // 
            this.ad_Textbox.Location = new System.Drawing.Point(122, 75);
            this.ad_Textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ad_Textbox.Name = "ad_Textbox";
            this.ad_Textbox.Size = new System.Drawing.Size(131, 22);
            this.ad_Textbox.TabIndex = 12;
            // 
            // soyad_Textbox
            // 
            this.soyad_Textbox.Location = new System.Drawing.Point(122, 115);
            this.soyad_Textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.soyad_Textbox.Name = "soyad_Textbox";
            this.soyad_Textbox.Size = new System.Drawing.Size(131, 22);
            this.soyad_Textbox.TabIndex = 13;
            // 
            // tc_Textbox
            // 
            this.tc_Textbox.Location = new System.Drawing.Point(122, 35);
            this.tc_Textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tc_Textbox.Name = "tc_Textbox";
            this.tc_Textbox.Size = new System.Drawing.Size(131, 22);
            this.tc_Textbox.TabIndex = 14;
            // 
            // ekle_Button
            // 
            this.ekle_Button.FlatAppearance.BorderSize = 0;
            this.ekle_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ekle_Button.Image = global::FirstBlood.Properties.Resources.notebook__6_;
            this.ekle_Button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ekle_Button.Location = new System.Drawing.Point(154, 239);
            this.ekle_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ekle_Button.Name = "ekle_Button";
            this.ekle_Button.Size = new System.Drawing.Size(99, 110);
            this.ekle_Button.TabIndex = 9;
            this.ekle_Button.Text = "Ekle";
            this.ekle_Button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ekle_Button.UseVisualStyleBackColor = true;
            this.ekle_Button.Click += new System.EventHandler(this.ekle_Button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "E-Posta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Telefon";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "TC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Soyad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ad";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ad_Textbox);
            this.groupBox1.Controls.Add(this.tel_Textbox);
            this.groupBox1.Controls.Add(this.eposta_Textbox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.soyad_Textbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tc_Textbox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ekle_Button);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(54, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 387);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(49, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 26);
            this.label7.TabIndex = 22;
            this.label7.Text = "Öğrenci Ekle";
            // 
            // OgrenciEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 501);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OgrenciEkle";
            this.Text = "PopupScreen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tel_Textbox;
        private System.Windows.Forms.TextBox eposta_Textbox;
        private System.Windows.Forms.TextBox ad_Textbox;
        private System.Windows.Forms.TextBox soyad_Textbox;
        private System.Windows.Forms.TextBox tc_Textbox;
        private System.Windows.Forms.Button ekle_Button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
    }
}