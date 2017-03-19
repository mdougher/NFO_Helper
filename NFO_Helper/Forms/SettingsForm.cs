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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            textBox_min_img_w.Text = global::NFO_Helper.Settings.Default.DesiredMinimumImageWidth.ToString();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            bool needToSaveConfig = false;
            if (String.IsNullOrEmpty(textBox_min_img_w.Text) == false)
            {
                int newVal = 0;
                if (Int32.TryParse(textBox_min_img_w.Text, out newVal) == true)
                {
                    global::NFO_Helper.Settings.Default.DesiredMinimumImageWidth = newVal;
                    needToSaveConfig = true;
                }
            }

            // in the future, additional configuration options can be added here. apply changes to the config file & set flag to save.
            
            if( needToSaveConfig == true )
                global::NFO_Helper.Settings.Default.Save();

            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
