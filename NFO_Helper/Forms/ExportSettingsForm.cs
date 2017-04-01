using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFO_Helper
{
    public partial class ExportSettingsForm : Form
    {
        public string scheme { get; set; }
        public ExportSettingsForm()
        {
            InitializeComponent();

            label_description.Text =  "Define an Export Scheme to streamline the export process. ";
            label_description.Text += "The Scheme controls the path & filenames of the exported objects. ";
            label_description.Text += "Use any combination of the NFO 'tags' listed, placed within braces '{}' and any other text desired.";
            label_example.Text =  "Example Scheme:\r\n";
            label_example.Text += AppConstants.DefaultExportScheme;
            label_example.Text += "\r\nCould result in:\r\nTotal Recall (1990)\\Total Recall (1990).nfo | .jpg";
            // load the scheme currently in use from configuration. if not present, use default.
            if (String.IsNullOrEmpty(global::NFO_Helper.Settings.Default.ExportScheme) == false)
                textBox_scheme.Text = global::NFO_Helper.Settings.Default.ExportScheme;
            else
                textBox_scheme.Text = AppConstants.DefaultExportScheme;

            listBox_tags.Items.Add("{title}");
            listBox_tags.Items.Add("{year}");
            listBox_tags.Items.Add("{id}");
        }

        private void button_default_Click(object sender, EventArgs e)
        {
            textBox_scheme.Text = AppConstants.DefaultExportScheme;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            this.scheme = textBox_scheme.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox_scheme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                button_apply_Click(this, new EventArgs());
            }
        }
    }
}
