namespace NFO_Helper
{
    partial class FilterForm
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
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_apply = new System.Windows.Forms.Button();
            this.listBox_filter = new System.Windows.Forms.ListBox();
            this.button_single_left = new System.Windows.Forms.Button();
            this.button_single_right = new System.Windows.Forms.Button();
            this.button_all_left = new System.Windows.Forms.Button();
            this.button_all_right = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_saveas = new System.Windows.Forms.Button();
            this.comboBox_filterselect = new System.Windows.Forms.ComboBox();
            this.listBox_available = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(454, 270);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 0;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(374, 270);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 1;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // listBox_filter
            // 
            this.listBox_filter.FormattingEnabled = true;
            this.listBox_filter.Location = new System.Drawing.Point(12, 23);
            this.listBox_filter.Name = "listBox_filter";
            this.listBox_filter.Size = new System.Drawing.Size(235, 238);
            this.listBox_filter.TabIndex = 4;
            // 
            // button_single_left
            // 
            this.button_single_left.Location = new System.Drawing.Point(253, 79);
            this.button_single_left.Name = "button_single_left";
            this.button_single_left.Size = new System.Drawing.Size(35, 23);
            this.button_single_left.TabIndex = 6;
            this.button_single_left.Text = "<";
            this.button_single_left.UseVisualStyleBackColor = true;
            this.button_single_left.Click += new System.EventHandler(this.button_single_left_Click);
            // 
            // button_single_right
            // 
            this.button_single_right.Location = new System.Drawing.Point(253, 108);
            this.button_single_right.Name = "button_single_right";
            this.button_single_right.Size = new System.Drawing.Size(35, 23);
            this.button_single_right.TabIndex = 7;
            this.button_single_right.Text = ">";
            this.button_single_right.UseVisualStyleBackColor = true;
            this.button_single_right.Click += new System.EventHandler(this.button_single_right_Click);
            // 
            // button_all_left
            // 
            this.button_all_left.Location = new System.Drawing.Point(253, 156);
            this.button_all_left.Name = "button_all_left";
            this.button_all_left.Size = new System.Drawing.Size(35, 23);
            this.button_all_left.TabIndex = 8;
            this.button_all_left.Text = "<<";
            this.button_all_left.UseVisualStyleBackColor = true;
            this.button_all_left.Click += new System.EventHandler(this.button_all_left_Click);
            // 
            // button_all_right
            // 
            this.button_all_right.Location = new System.Drawing.Point(253, 185);
            this.button_all_right.Name = "button_all_right";
            this.button_all_right.Size = new System.Drawing.Size(35, 23);
            this.button_all_right.TabIndex = 9;
            this.button_all_right.Text = ">>";
            this.button_all_right.UseVisualStyleBackColor = true;
            this.button_all_right.Click += new System.EventHandler(this.button_all_right_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Available NFO Fields:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "NFO Fields Applied to This Filter:";
            // 
            // button_saveas
            // 
            this.button_saveas.Location = new System.Drawing.Point(294, 270);
            this.button_saveas.Name = "button_saveas";
            this.button_saveas.Size = new System.Drawing.Size(75, 23);
            this.button_saveas.TabIndex = 12;
            this.button_saveas.Text = "Save As...";
            this.button_saveas.UseVisualStyleBackColor = true;
            this.button_saveas.Click += new System.EventHandler(this.button_saveas_Click);
            // 
            // comboBox_filterselect
            // 
            this.comboBox_filterselect.FormattingEnabled = true;
            this.comboBox_filterselect.Location = new System.Drawing.Point(85, 267);
            this.comboBox_filterselect.Name = "comboBox_filterselect";
            this.comboBox_filterselect.Size = new System.Drawing.Size(162, 21);
            this.comboBox_filterselect.TabIndex = 15;
            this.comboBox_filterselect.SelectedIndexChanged += new System.EventHandler(this.comboBox_filterselect_SelectedIndexChanged);
            // 
            // listBox_available
            // 
            this.listBox_available.FormattingEnabled = true;
            this.listBox_available.Location = new System.Drawing.Point(294, 26);
            this.listBox_available.Name = "listBox_available";
            this.listBox_available.Size = new System.Drawing.Size(235, 238);
            this.listBox_available.Sorted = true;
            this.listBox_available.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Current Filter:";
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 300);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_filterselect);
            this.Controls.Add(this.button_saveas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_all_right);
            this.Controls.Add(this.button_all_left);
            this.Controls.Add(this.button_single_right);
            this.Controls.Add(this.button_single_left);
            this.Controls.Add(this.listBox_available);
            this.Controls.Add(this.listBox_filter);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.button_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterForm";
            this.Text = "NFO_Helper Filter";
            this.Load += new System.EventHandler(this.FilterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.ListBox listBox_filter;
        private System.Windows.Forms.Button button_single_left;
        private System.Windows.Forms.Button button_single_right;
        private System.Windows.Forms.Button button_all_left;
        private System.Windows.Forms.Button button_all_right;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_saveas;
        private System.Windows.Forms.ComboBox comboBox_filterselect;
        private System.Windows.Forms.ListBox listBox_available;
        private System.Windows.Forms.Label label4;
    }
}