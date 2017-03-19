namespace NFO_Helper
{
    partial class SearchResultsForm
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
            this.panel_results = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel_results
            // 
            this.panel_results.AutoScroll = true;
            this.panel_results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_results.Location = new System.Drawing.Point(0, 0);
            this.panel_results.Name = "panel_results";
            this.panel_results.Size = new System.Drawing.Size(729, 261);
            this.panel_results.TabIndex = 0;
            // 
            // SearchResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 261);
            this.Controls.Add(this.panel_results);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchResultsForm";
            this.Text = "SearchResults";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_results;
    }
}