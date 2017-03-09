namespace NFO_Helper
{
    partial class Form1
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
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_export = new System.Windows.Forms.Button();
            this.pictureBox_img = new System.Windows.Forms.PictureBox();
            this.textBox_nfo = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button_close = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nFOFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_img_scroll_left = new System.Windows.Forms.Button();
            this.button_img_scroll_right = new System.Windows.Forms.Button();
            this.label_image_num = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_filtername = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_img)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search for Movie, or Enter TMDb Id:";
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(260, 30);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(80, 20);
            this.textBox_id.TabIndex = 1;
            this.textBox_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_id_KeyPress);
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(3, 29);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 2;
            this.button_search.Text = "Search...";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(346, 29);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(75, 23);
            this.button_update.TabIndex = 3;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(427, 29);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 4;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_export
            // 
            this.button_export.Location = new System.Drawing.Point(508, 29);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(75, 23);
            this.button_export.TabIndex = 5;
            this.button_export.Text = "Export";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // pictureBox_img
            // 
            this.pictureBox_img.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_img.Location = new System.Drawing.Point(479, 59);
            this.pictureBox_img.Name = "pictureBox_img";
            this.pictureBox_img.Size = new System.Drawing.Size(185, 278);
            this.pictureBox_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_img.TabIndex = 6;
            this.pictureBox_img.TabStop = false;
            // 
            // textBox_nfo
            // 
            this.textBox_nfo.Location = new System.Drawing.Point(3, 59);
            this.textBox_nfo.Multiline = true;
            this.textBox_nfo.Name = "textBox_nfo";
            this.textBox_nfo.ReadOnly = true;
            this.textBox_nfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_nfo.Size = new System.Drawing.Size(470, 302);
            this.textBox_nfo.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(260, 172);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Visible = false;
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(589, 29);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(75, 23);
            this.button_close.TabIndex = 9;
            this.button_close.Text = "Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(668, 24);
            this.MainMenu.TabIndex = 10;
            this.MainMenu.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appSettingsToolStripMenuItem,
            this.nFOFilterToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // appSettingsToolStripMenuItem
            // 
            this.appSettingsToolStripMenuItem.Name = "appSettingsToolStripMenuItem";
            this.appSettingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.appSettingsToolStripMenuItem.Text = "App Settings";
            this.appSettingsToolStripMenuItem.Click += new System.EventHandler(this.appSettingsToolStripMenuItem_Click);
            // 
            // nFOFilterToolStripMenuItem
            // 
            this.nFOFilterToolStripMenuItem.Name = "nFOFilterToolStripMenuItem";
            this.nFOFilterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nFOFilterToolStripMenuItem.Text = "NFO Filter";
            this.nFOFilterToolStripMenuItem.Click += new System.EventHandler(this.nFOFilterToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // button_img_scroll_left
            // 
            this.button_img_scroll_left.Location = new System.Drawing.Point(479, 338);
            this.button_img_scroll_left.Name = "button_img_scroll_left";
            this.button_img_scroll_left.Size = new System.Drawing.Size(28, 23);
            this.button_img_scroll_left.TabIndex = 11;
            this.button_img_scroll_left.Text = "<<";
            this.button_img_scroll_left.UseVisualStyleBackColor = true;
            this.button_img_scroll_left.Click += new System.EventHandler(this.button_img_scroll_left_Click);
            // 
            // button_img_scroll_right
            // 
            this.button_img_scroll_right.Location = new System.Drawing.Point(636, 338);
            this.button_img_scroll_right.Name = "button_img_scroll_right";
            this.button_img_scroll_right.Size = new System.Drawing.Size(28, 23);
            this.button_img_scroll_right.TabIndex = 12;
            this.button_img_scroll_right.Text = ">>";
            this.button_img_scroll_right.UseVisualStyleBackColor = true;
            this.button_img_scroll_right.Click += new System.EventHandler(this.button_img_scroll_right_Click);
            // 
            // label_image_num
            // 
            this.label_image_num.AutoEllipsis = true;
            this.label_image_num.Location = new System.Drawing.Point(509, 339);
            this.label_image_num.Name = "label_image_num";
            this.label_image_num.Size = new System.Drawing.Size(128, 23);
            this.label_image_num.TabIndex = 13;
            this.label_image_num.Text = "Image 0 of 0";
            this.label_image_num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_filtername});
            this.statusStrip1.Location = new System.Drawing.Point(0, 362);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(668, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_filtername
            // 
            this.toolStripStatusLabel_filtername.Name = "toolStripStatusLabel_filtername";
            this.toolStripStatusLabel_filtername.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel_filtername.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 384);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label_image_num);
            this.Controls.Add(this.button_img_scroll_right);
            this.Controls.Add(this.button_img_scroll_left);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox_nfo);
            this.Controls.Add(this.pictureBox_img);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "NFO_Helper";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_img)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.PictureBox pictureBox_img;
        private System.Windows.Forms.TextBox textBox_nfo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button button_img_scroll_left;
        private System.Windows.Forms.Button button_img_scroll_right;
        private System.Windows.Forms.Label label_image_num;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nFOFilterToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_filtername;
    }
}

