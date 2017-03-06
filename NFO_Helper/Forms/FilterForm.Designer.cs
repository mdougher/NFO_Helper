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
            this.button_default = new System.Windows.Forms.Button();
            this.listBox_filter = new System.Windows.Forms.ListBox();
            this.listBox_available = new System.Windows.Forms.ListBox();
            this.button_single_left = new System.Windows.Forms.Button();
            this.button_single_right = new System.Windows.Forms.Button();
            this.button_all_left = new System.Windows.Forms.Button();
            this.button_all_right = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_saveas = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(492, 283);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 0;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(411, 283);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 1;
            this.button_apply.Text = "Apply";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // button_default
            // 
            this.button_default.Location = new System.Drawing.Point(254, 251);
            this.button_default.Name = "button_default";
            this.button_default.Size = new System.Drawing.Size(75, 23);
            this.button_default.TabIndex = 3;
            this.button_default.Text = "Default";
            this.button_default.UseVisualStyleBackColor = true;
            this.button_default.Click += new System.EventHandler(this.button_default_Click);
            // 
            // listBox_filter
            // 
            this.listBox_filter.FormattingEnabled = true;
            this.listBox_filter.Location = new System.Drawing.Point(12, 23);
            this.listBox_filter.Name = "listBox_filter";
            this.listBox_filter.Size = new System.Drawing.Size(226, 251);
            this.listBox_filter.TabIndex = 4;
            // 
            // listBox_available
            // 
            this.listBox_available.FormattingEnabled = true;
            this.listBox_available.Location = new System.Drawing.Point(341, 23);
            this.listBox_available.Name = "listBox_available";
            this.listBox_available.Size = new System.Drawing.Size(226, 251);
            this.listBox_available.TabIndex = 5;
            // 
            // button_single_left
            // 
            this.button_single_left.Location = new System.Drawing.Point(254, 79);
            this.button_single_left.Name = "button_single_left";
            this.button_single_left.Size = new System.Drawing.Size(75, 23);
            this.button_single_left.TabIndex = 6;
            this.button_single_left.Text = "<";
            this.button_single_left.UseVisualStyleBackColor = true;
            this.button_single_left.Click += new System.EventHandler(this.button_single_left_Click);
            // 
            // button_single_right
            // 
            this.button_single_right.Location = new System.Drawing.Point(254, 108);
            this.button_single_right.Name = "button_single_right";
            this.button_single_right.Size = new System.Drawing.Size(75, 23);
            this.button_single_right.TabIndex = 7;
            this.button_single_right.Text = ">";
            this.button_single_right.UseVisualStyleBackColor = true;
            this.button_single_right.Click += new System.EventHandler(this.button_single_right_Click);
            // 
            // button_all_left
            // 
            this.button_all_left.Location = new System.Drawing.Point(254, 156);
            this.button_all_left.Name = "button_all_left";
            this.button_all_left.Size = new System.Drawing.Size(75, 23);
            this.button_all_left.TabIndex = 8;
            this.button_all_left.Text = "<<";
            this.button_all_left.UseVisualStyleBackColor = true;
            this.button_all_left.Click += new System.EventHandler(this.button_all_left_Click);
            // 
            // button_all_right
            // 
            this.button_all_right.Location = new System.Drawing.Point(254, 185);
            this.button_all_right.Name = "button_all_right";
            this.button_all_right.Size = new System.Drawing.Size(75, 23);
            this.button_all_right.TabIndex = 9;
            this.button_all_right.Text = ">>";
            this.button_all_right.UseVisualStyleBackColor = true;
            this.button_all_right.Click += new System.EventHandler(this.button_all_right_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 5);
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
            this.button_saveas.Location = new System.Drawing.Point(330, 283);
            this.button_saveas.Name = "button_saveas";
            this.button_saveas.Size = new System.Drawing.Size(75, 23);
            this.button_saveas.TabIndex = 12;
            this.button_saveas.Text = "Save As...";
            this.button_saveas.UseVisualStyleBackColor = true;
            this.button_saveas.Click += new System.EventHandler(this.button_saveas_Click);
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(249, 283);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 23);
            this.button_load.TabIndex = 13;
            this.button_load.Text = "Load ...";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 314);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.button_saveas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_all_right);
            this.Controls.Add(this.button_all_left);
            this.Controls.Add(this.button_single_right);
            this.Controls.Add(this.button_single_left);
            this.Controls.Add(this.listBox_available);
            this.Controls.Add(this.listBox_filter);
            this.Controls.Add(this.button_default);
            this.Controls.Add(this.button_apply);
            this.Controls.Add(this.button_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterForm";
            this.Text = "NFO_Helper Filter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_default;
        private System.Windows.Forms.ListBox listBox_filter;
        private System.Windows.Forms.ListBox listBox_available;
        private System.Windows.Forms.Button button_single_left;
        private System.Windows.Forms.Button button_single_right;
        private System.Windows.Forms.Button button_all_left;
        private System.Windows.Forms.Button button_all_right;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_saveas;
        private System.Windows.Forms.Button button_load;
    }
}