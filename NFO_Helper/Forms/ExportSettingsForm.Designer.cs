namespace NFO_Helper
{
    partial class ExportSettingsForm
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
            this.label_description = new System.Windows.Forms.Label();
            this.label_example = new System.Windows.Forms.Label();
            this.textBox_scheme = new System.Windows.Forms.TextBox();
            this.listBox_tags = new System.Windows.Forms.ListBox();
            this.button_default = new System.Windows.Forms.Button();
            this.button_apply = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_description
            // 
            this.label_description.Location = new System.Drawing.Point(13, 12);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(382, 69);
            this.label_description.TabIndex = 0;
            this.label_description.Text = "Define an Export Scheme to streamline the export process.";
            // 
            // label_example
            // 
            this.label_example.Location = new System.Drawing.Point(12, 81);
            this.label_example.Name = "label_example";
            this.label_example.Size = new System.Drawing.Size(382, 64);
            this.label_example.TabIndex = 1;
            this.label_example.Text = "Example Scheme:";
            // 
            // textBox_scheme
            // 
            this.textBox_scheme.Location = new System.Drawing.Point(12, 148);
            this.textBox_scheme.Name = "textBox_scheme";
            this.textBox_scheme.Size = new System.Drawing.Size(382, 20);
            this.textBox_scheme.TabIndex = 2;
            this.textBox_scheme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_scheme_KeyPress);
            // 
            // listBox_tags
            // 
            this.listBox_tags.BackColor = System.Drawing.SystemColors.Control;
            this.listBox_tags.Enabled = false;
            this.listBox_tags.FormattingEnabled = true;
            this.listBox_tags.Location = new System.Drawing.Point(401, 33);
            this.listBox_tags.Name = "listBox_tags";
            this.listBox_tags.Size = new System.Drawing.Size(120, 134);
            this.listBox_tags.Sorted = true;
            this.listBox_tags.TabIndex = 3;
            // 
            // button_default
            // 
            this.button_default.Location = new System.Drawing.Point(286, 174);
            this.button_default.Name = "button_default";
            this.button_default.Size = new System.Drawing.Size(75, 23);
            this.button_default.TabIndex = 4;
            this.button_default.Text = "Default";
            this.button_default.UseVisualStyleBackColor = true;
            this.button_default.Click += new System.EventHandler(this.button_default_Click);
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(367, 174);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 5;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(448, 174);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 6;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "List of available tags:";
            // 
            // ExportSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 209);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.button_default);
            this.Controls.Add(this.listBox_tags);
            this.Controls.Add(this.textBox_scheme);
            this.Controls.Add(this.label_example);
            this.Controls.Add(this.label_description);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ExportSettingsForm";
            this.Text = "NFO_Helper Export Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.Label label_example;
        private System.Windows.Forms.TextBox textBox_scheme;
        private System.Windows.Forms.ListBox listBox_tags;
        private System.Windows.Forms.Button button_default;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label3;
    }
}