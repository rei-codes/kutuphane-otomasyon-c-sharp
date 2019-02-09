using System;

namespace FirstBlood
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ara_TextBox = new System.Windows.Forms.TextBox();
            this.aramaTur_ComboBox = new System.Windows.Forms.ComboBox();
            this.listView = new System.Windows.Forms.ListView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ogrenciEkle_Button = new System.Windows.Forms.Button();
            this.kitapEkle_Button = new System.Windows.Forms.Button();
            this.iade_Button = new System.Windows.Forms.Button();
            this.odunc_Button = new System.Windows.Forms.Button();
            this.ara_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // ara_TextBox
            // 
            this.ara_TextBox.AccessibleName = "";
            this.ara_TextBox.Location = new System.Drawing.Point(21, 135);
            this.ara_TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ara_TextBox.Name = "ara_TextBox";
            this.ara_TextBox.Size = new System.Drawing.Size(523, 22);
            this.ara_TextBox.TabIndex = 1;
            this.ara_TextBox.Text = "Kitap / Öğrenci Arayınız";
            this.ara_TextBox.Click += new System.EventHandler(this.ara_TextBox_Click);
            // 
            // aramaTur_ComboBox
            // 
            this.aramaTur_ComboBox.FormattingEnabled = true;
            this.aramaTur_ComboBox.IntegralHeight = false;
            this.aramaTur_ComboBox.Items.AddRange(new object[] {
            "Kitap adı",
            "Öğrenci adı",
            "Barkod",
            "Yazar"});
            this.aramaTur_ComboBox.Location = new System.Drawing.Point(561, 134);
            this.aramaTur_ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.aramaTur_ComboBox.Name = "aramaTur_ComboBox";
            this.aramaTur_ComboBox.Size = new System.Drawing.Size(163, 24);
            this.aramaTur_ComboBox.TabIndex = 3;
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(21, 171);
            this.listView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(769, 217);
            this.listView.TabIndex = 4;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(21, 403);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Light;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(769, 348);
            this.chart1.TabIndex = 22;
            this.chart1.Text = "chart1";
            // 
            // ogrenciEkle_Button
            // 
            this.ogrenciEkle_Button.FlatAppearance.BorderSize = 0;
            this.ogrenciEkle_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ogrenciEkle_Button.Image = global::FirstBlood.Properties.Resources.add_user;
            this.ogrenciEkle_Button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ogrenciEkle_Button.Location = new System.Drawing.Point(135, 9);
            this.ogrenciEkle_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ogrenciEkle_Button.Name = "ogrenciEkle_Button";
            this.ogrenciEkle_Button.Size = new System.Drawing.Size(103, 111);
            this.ogrenciEkle_Button.TabIndex = 21;
            this.ogrenciEkle_Button.Text = "Öğrenci Ekle";
            this.ogrenciEkle_Button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ogrenciEkle_Button.UseVisualStyleBackColor = true;
            this.ogrenciEkle_Button.Click += new System.EventHandler(this.ogrenciEkle_Button_Click);
            // 
            // kitapEkle_Button
            // 
            this.kitapEkle_Button.FlatAppearance.BorderSize = 0;
            this.kitapEkle_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kitapEkle_Button.Image = global::FirstBlood.Properties.Resources.notebook3;
            this.kitapEkle_Button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.kitapEkle_Button.Location = new System.Drawing.Point(21, 7);
            this.kitapEkle_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kitapEkle_Button.Name = "kitapEkle_Button";
            this.kitapEkle_Button.Size = new System.Drawing.Size(99, 113);
            this.kitapEkle_Button.TabIndex = 21;
            this.kitapEkle_Button.Text = "Kitap Ekle";
            this.kitapEkle_Button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.kitapEkle_Button.UseVisualStyleBackColor = true;
            this.kitapEkle_Button.Click += new System.EventHandler(this.kitapEkle_Button_Click);
            // 
            // iade_Button
            // 
            this.iade_Button.FlatAppearance.BorderSize = 0;
            this.iade_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iade_Button.Image = global::FirstBlood.Properties.Resources.notebook__2_;
            this.iade_Button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iade_Button.Location = new System.Drawing.Point(350, 7);
            this.iade_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iade_Button.Name = "iade_Button";
            this.iade_Button.Size = new System.Drawing.Size(98, 113);
            this.iade_Button.TabIndex = 21;
            this.iade_Button.Text = "İade Al";
            this.iade_Button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iade_Button.UseVisualStyleBackColor = true;
            this.iade_Button.Click += new System.EventHandler(this.iade_Button_Click);
            // 
            // odunc_Button
            // 
            this.odunc_Button.FlatAppearance.BorderSize = 0;
            this.odunc_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.odunc_Button.Image = global::FirstBlood.Properties.Resources.notebook__1_;
            this.odunc_Button.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.odunc_Button.Location = new System.Drawing.Point(247, 7);
            this.odunc_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.odunc_Button.Name = "odunc_Button";
            this.odunc_Button.Size = new System.Drawing.Size(97, 113);
            this.odunc_Button.TabIndex = 21;
            this.odunc_Button.Text = "Ödünç Ver";
            this.odunc_Button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.odunc_Button.UseVisualStyleBackColor = true;
            this.odunc_Button.Click += new System.EventHandler(this.odunc_Button_Click);
            // 
            // ara_Button
            // 
            this.ara_Button.FlatAppearance.BorderSize = 0;
            this.ara_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ara_Button.Image = global::FirstBlood.Properties.Resources.search;
            this.ara_Button.Location = new System.Drawing.Point(731, 124);
            this.ara_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ara_Button.Name = "ara_Button";
            this.ara_Button.Size = new System.Drawing.Size(59, 42);
            this.ara_Button.TabIndex = 0;
            this.ara_Button.UseVisualStyleBackColor = true;
            this.ara_Button.Click += new System.EventHandler(this.ara_Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 763);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.ogrenciEkle_Button);
            this.Controls.Add(this.kitapEkle_Button);
            this.Controls.Add(this.iade_Button);
            this.Controls.Add(this.odunc_Button);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.aramaTur_ComboBox);
            this.Controls.Add(this.ara_TextBox);
            this.Controls.Add(this.ara_Button);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion
        private System.Windows.Forms.Button ara_Button;
        private System.Windows.Forms.TextBox ara_TextBox;
        private System.Windows.Forms.ComboBox aramaTur_ComboBox;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button kitapEkle_Button;
        private System.Windows.Forms.Button ogrenciEkle_Button;
        private System.Windows.Forms.Button odunc_Button;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button iade_Button;
    }
}

