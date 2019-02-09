namespace FirstBlood
{
    partial class OduncVer
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
            this.ara = new System.Windows.Forms.TextBox();
            this.btn_OduncVer = new System.Windows.Forms.Button();
            this.label_Bilgi = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ara
            // 
            this.ara.AccessibleName = "";
            this.ara.Location = new System.Drawing.Point(32, 40);
            this.ara.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ara.Name = "ara";
            this.ara.Size = new System.Drawing.Size(559, 22);
            this.ara.TabIndex = 3;
            this.ara.Text = "Kitap / Öğrenci Arayınız";
            this.ara.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ara_MouseClick);
            this.ara.TextChanged += new System.EventHandler(this.ara_TextChanged);
            // 
            // btn_OduncVer
            // 
            this.btn_OduncVer.FlatAppearance.BorderSize = 0;
            this.btn_OduncVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OduncVer.Image = global::FirstBlood.Properties.Resources.notebook__6_;
            this.btn_OduncVer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_OduncVer.Location = new System.Drawing.Point(496, 236);
            this.btn_OduncVer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_OduncVer.Name = "btn_OduncVer";
            this.btn_OduncVer.Size = new System.Drawing.Size(95, 111);
            this.btn_OduncVer.TabIndex = 2;
            this.btn_OduncVer.Text = "Ödünç Ver";
            this.btn_OduncVer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_OduncVer.UseVisualStyleBackColor = true;
            this.btn_OduncVer.Click += new System.EventHandler(this.btn_OduncVer_Click);
            // 
            // label_Bilgi
            // 
            this.label_Bilgi.AutoSize = true;
            this.label_Bilgi.Location = new System.Drawing.Point(29, 246);
            this.label_Bilgi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Bilgi.Name = "label_Bilgi";
            this.label_Bilgi.Size = new System.Drawing.Size(46, 17);
            this.label_Bilgi.TabIndex = 4;
            this.label_Bilgi.Text = "label1";
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(32, 78);
            this.listView.Margin = new System.Windows.Forms.Padding(4);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(559, 152);
            this.listView.TabIndex = 5;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView);
            this.groupBox1.Controls.Add(this.btn_OduncVer);
            this.groupBox1.Controls.Add(this.ara);
            this.groupBox1.Controls.Add(this.label_Bilgi);
            this.groupBox1.Location = new System.Drawing.Point(44, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 373);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(39, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 26);
            this.label9.TabIndex = 21;
            this.label9.Text = "Ödünç Ver";
            // 
            // OduncVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 483);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OduncVer";
            this.Text = "OduncVer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ara;
        private System.Windows.Forms.Button btn_OduncVer;
        private System.Windows.Forms.Label label_Bilgi;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
    }
}