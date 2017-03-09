namespace NFO_Helper
{
    partial class SettingsForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_tmdb_api_key = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.textBox_min_img_w = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NFO_Helper.Properties.Resources.TMDb;
            this.pictureBox1.Location = new System.Drawing.Point(12, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(178, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 26);
            this.label2.TabIndex = 29;
            this.label2.Text = "This product uses the TMDb API but is not endorsed or certified by TMDb.";
            // 
            // textBox_tmdb_api_key
            // 
            this.textBox_tmdb_api_key.Location = new System.Drawing.Point(181, 60);
            this.textBox_tmdb_api_key.Name = "textBox_tmdb_api_key";
            this.textBox_tmdb_api_key.Size = new System.Drawing.Size(226, 20);
            this.textBox_tmdb_api_key.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "TMDb Developer Api Key";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(356, 172);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 33;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(275, 172);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 34;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // textBox_min_img_w
            // 
            this.textBox_min_img_w.Location = new System.Drawing.Point(158, 88);
            this.textBox_min_img_w.Name = "textBox_min_img_w";
            this.textBox_min_img_w.Size = new System.Drawing.Size(44, 20);
            this.textBox_min_img_w.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Minimum Image Size (Width):";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(12, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(420, 2);
            this.label6.TabIndex = 38;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 198);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_min_img_w);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_tmdb_api_key);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "NFO_Helper Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_tmdb_api_key;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.TextBox textBox_min_img_w;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}