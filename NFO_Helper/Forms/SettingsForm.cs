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
            // check if our config file already has an api key. if so, populate the text field with that to start.
            string key = global::NFO_Helper.Settings.Default.TMDb_Api_Key;
            if( String.IsNullOrEmpty(key) == false )
            {
                textBox_tmdb_api_key.Text = key;
            }
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

            if (String.IsNullOrEmpty(textBox_tmdb_api_key.Text) == false)
            {
                // if the entered api key is different than what was in the config file, persist new value to the config file.
                if (String.Compare(textBox_tmdb_api_key.Text, global::NFO_Helper.Settings.Default.TMDb_Api_Key) != 0)
                {
                    this.DialogResult = DialogResult.OK;
                    global::NFO_Helper.Settings.Default.TMDb_Api_Key = textBox_tmdb_api_key.Text;
                    needToSaveConfig = true;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            
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
