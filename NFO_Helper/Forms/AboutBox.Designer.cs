namespace NFO_Helper
{
    partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxReleaseNotes = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(128, 9);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(72, 13);
            this.labelProductName.TabIndex = 15;
            this.labelProductName.Text = "ProductName";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(244, 9);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(79, 13);
            this.labelVersion.TabIndex = 16;
            this.labelVersion.Text = "ProductVersion";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(128, 26);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(51, 13);
            this.labelCopyright.TabIndex = 17;
            this.labelCopyright.Text = "Copyright";
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.AutoSize = true;
            this.labelCompanyName.Location = new System.Drawing.Point(244, 26);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(79, 13);
            this.labelCompanyName.TabIndex = 18;
            this.labelCompanyName.Text = "CompanyName";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(131, 59);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size(339, 72);
            this.textBoxDescription.TabIndex = 24;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "Description";
            // 
            // textBoxReleaseNotes
            // 
            this.textBoxReleaseNotes.Location = new System.Drawing.Point(131, 137);
            this.textBoxReleaseNotes.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.textBoxReleaseNotes.Multiline = true;
            this.textBoxReleaseNotes.Name = "textBoxReleaseNotes";
            this.textBoxReleaseNotes.ReadOnly = true;
            this.textBoxReleaseNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxReleaseNotes.Size = new System.Drawing.Size(339, 126);
            this.textBoxReleaseNotes.TabIndex = 25;
            this.textBoxReleaseNotes.TabStop = false;
            this.textBoxReleaseNotes.Text = "ReleaseNotes";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(129, 43);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(211, 13);
            this.linkLabel1.TabIndex = 26;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/mdougher/NFO_Helper";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NFO_Helper.Properties.Resources.TMDb;
            this.pictureBox1.Location = new System.Drawing.Point(131, 269);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(1, -1);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(121, 350);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 14;
            this.logoPictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(328, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 46);
            this.label2.TabIndex = 32;
            this.label2.Text = "This product uses the TMDb API but is not endorsed or certified by TMDb.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(395, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 352);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textBoxReleaseNotes);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelCompanyName);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.logoPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutBox1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxReleaseNotes;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}
