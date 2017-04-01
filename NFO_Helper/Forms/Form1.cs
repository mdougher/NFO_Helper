using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NFO_Helper
{
    public partial class Form1 : Form
    {
        private NFO nfo { get; set; }
        private IDataProvider provider { get; set; }
        private int currentPosterIndex { get; set; }
        private NFO_Filter filter { get; set; }
        private string exportScheme { get; set; }

        public Form1()
        {
            InitializeComponent();
            provider = new TMDb.TMDbDataProvider();
            nfo = new NFO();
            currentPosterIndex = 0;
            // get scheme from config, if not present, use default.
            if (String.IsNullOrEmpty(global::NFO_Helper.Settings.Default.ExportScheme) == false)
                exportScheme = global::NFO_Helper.Settings.Default.ExportScheme;
            else
                exportScheme = AppConstants.DefaultExportScheme;
            // check configuration if another filter has been used, load that instead.
            if (String.IsNullOrEmpty(global::NFO_Helper.Settings.Default.LastUsedFilterFilename) == false)
            {
                NFO_Filter_File file = new NFO_Filter_File();
                try
                {
                    file.parseFile(global::NFO_Helper.Settings.Default.LastUsedFilterFilename);
                    filter = file.filter;
                }
                catch (NfoReadWriteException)
                {
                    // if we fail to load that one, just go with the default.
                    filter = new DefaultNfoFilter();
                    // clear the 'last used' filter value.
                    global::NFO_Helper.Settings.Default.LastUsedFilterFilename = "";
                    global::NFO_Helper.Settings.Default.Save();
                }                
            }
            else
            {
                // no 'last used' filter, use default.
                filter = new DefaultNfoFilter();
            }

            updateFilterLabel();
            updateMovieIdLabel("");
            this.ActiveControl = textBox_search;
        }

        private async void button_update_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_search.Text) == true)
                return;

            startProgressIndication();

            SearchResults results = null;
            try
            {
                results = await provider.getSearchResultsAsync(textBox_search.Text);
            }
            catch (DataProviderException ex)
            {
                MessageBox.Show(ex.Message, "NFO_Helper Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (results != null)
            {
                SearchResult res = null;
                int numResults = results.results.Count();
                if (numResults == 0 || numResults < 0)
                {
                    MessageBox.Show("No Search results found! Please try again!");
                }
                else if (numResults == 1)
                {
                    // a single result was found, assume to be an exact match. show that result now.
                    res = results.results.First();
                }
                else
                {
                    // many results, show the search results form to let the user pick which one they want.
                    using (SearchResultsForm form = new SearchResultsForm(results))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            res = form.selectedResult;
                        }
                    }
                }

                if (res != null)
                {
                    textBox_search.Text = res.Title + " (" + res.Year + ")";
                    updateMovieIdLabel(res.ID);
                    await updateNfoAsync(res.ID);
                }
            }
            endProgressIndication();
            if (String.IsNullOrEmpty(textBox_nfo.Text) == false)
            {
                button_export.Focus();
            }
        }
        
        private void button_clear_Click(object sender, EventArgs e)
        {
            // clear everything in the GUI.
            clear_nfo_data();
            textBox_search.Clear();
        }

        private void clear_nfo_data()
        {
            // clear everything related to the results of this item.
            nfo.reset();
            textBox_nfo.Clear();
            updateMovieIdLabel("");
            pictureBox_img.Image = null;
            currentPosterIndex = 0;
            label_image_num.Text = "Image 0 of 0";
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            if (nfo == null || String.IsNullOrEmpty((string)nfo.getProperty(NFOConstants.Title)) == true)
                return;
            IList<string> written = Exporter.export(nfo, exportScheme, pictureBox_img.Image);
            if( written.Any() == false )
            {
                MessageBox.Show("Failed to Export!", "NFO_Helper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string msg = "Successfully exported files:";
                foreach( string s in written )
                {
                    msg += "\r\n";
                    msg += s;
                }
                MessageBox.Show(msg, "NFO_Helper", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task updateNfoAsync(string id)
        {
            try
            {
                nfo = await provider.getNFOAsync(id, filter);
                if (nfo == null)
                    return;

                textBox_nfo.Text = nfo.toXML(true);

                object prop = nfo.getProperty(NFOConstants.Posters);
                if (prop == null)
                    return;

                // display the first image result.
                List<String> posterList = (List<String>)prop;
                string url = posterList.FirstOrDefault();
                currentPosterIndex = 0;
                label_image_num.Text = "Image " + (currentPosterIndex + 1) + " of " + posterList.Count();
                Task<bool> fireAndForget = loadImageAsync(url, pictureBox_img); // don't await.
            }
            catch (DataProviderException ex)
            {
                MessageBox.Show(ex.Message, "NFO_Helper Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception e)
            {
                MessageBox.Show("Error while updating display for NFO: " + e.ToString(), "NFO_Helper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private async Task<bool> loadImageAsync(string url, PictureBox picbox)
        {
            try
            {
                Stream s = await HttpHelpers.getHttpUrlResultAsStreamAsync(url);
                picbox.Image = Image.FromStream(s);
            }
            catch (DataProviderException ex)
            {
                MessageBox.Show(ex.Message, "NFO_Helper Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void startProgressIndication()
        {
            toolStripProgressBar.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar.MarqueeAnimationSpeed = 100;
            textBox_search.Enabled = false;
            textBox_nfo.Enabled = false;
            button_update.Enabled = false;
            button_clear.Enabled = false;
            button_export.Enabled = false;
            pictureBox_img.Enabled = false;
        }

        private void endProgressIndication()
        {
            toolStripProgressBar.Style = ProgressBarStyle.Continuous;
            toolStripProgressBar.MarqueeAnimationSpeed = 0;
            textBox_search.Enabled = true;
            textBox_nfo.Enabled = true;
            button_update.Enabled = true;
            button_clear.Enabled = true;
            button_export.Enabled = true;
            pictureBox_img.Enabled = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox aboutBox = new AboutBox())
            {
                aboutBox.ShowDialog();
            }
        }

        private void appSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SettingsForm form = new SettingsForm())
            {
                form.ShowDialog();
            }
        }

        private void NfoFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FilterForm form = new FilterForm(filter))
            {
                DialogResult result = form.ShowDialog();
                if(result == DialogResult.OK)
                {
                    // get the new filter from the dialog.
                    filter = form.filter;
                    updateFilterLabel();

                    // based on the name of the new filter, we either need to update the last used filter filename or clear it.
                    if( String.Compare(filter.name, AppConstants.DefaultNfoFilterName) == 0 ||
                        String.Compare(filter.name, AppConstants.TempNfoFilterName) == 0 )
                    {
                        global::NFO_Helper.Settings.Default.LastUsedFilterFilename = "";
                        global::NFO_Helper.Settings.Default.Save();
                    }
                    else
                    {
                        global::NFO_Helper.Settings.Default.LastUsedFilterFilename = form.filterFileName;
                        global::NFO_Helper.Settings.Default.Save();
                    }
                }
            }
        }

        private void textBox_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                button_update_Click(this, new EventArgs());
            }
        }

        private void button_img_scroll_left_Click(object sender, EventArgs e)
        {
            if (nfo == null )
                return;
            object prop = nfo.getProperty(NFOConstants.Posters);
            if (prop == null)
                return;
            List<String> posterList = (List<String>)prop;

            if (currentPosterIndex == 0)
                currentPosterIndex = posterList.Count() - 1;
            else
                currentPosterIndex--;

            string url = posterList[currentPosterIndex];
            label_image_num.Text = "Image " + (currentPosterIndex+1) + " of " + posterList.Count();
            Task<bool> fireAndForget = loadImageAsync(url, pictureBox_img); // don't await
        }

        private void button_img_scroll_right_Click(object sender, EventArgs e)
        {
            if (nfo == null)
                return;
            object prop = nfo.getProperty(NFOConstants.Posters);
            if (prop == null)
                return;
            List<String> posterList = (List<String>)prop;

            if (currentPosterIndex == posterList.Count() - 1 )
                currentPosterIndex = 0;
            else
                currentPosterIndex++;

            string url = posterList[currentPosterIndex];
            label_image_num.Text = "Image " + (currentPosterIndex+1) + " of " + posterList.Count();
            Task<bool> fireAndForget = loadImageAsync(url, pictureBox_img); // don't await
        }

        private void updateFilterLabel()
        {
            toolStripStatusLabel_filtername.Text = AppConstants.NfoFilterLabelPrefix + filter.name;
        }

        private void updateMovieIdLabel(string id)
        {
            if (string.IsNullOrEmpty(id) == true)
                toolStripStatusLabel_movieid.Text = "";
            else
                toolStripStatusLabel_movieid.Text = AppConstants.MovieIdLabelPrefix + id;
        }

        private void textBox_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                button_update_Click(this, new EventArgs());
            }
        }

        private void exportSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ExportSettingsForm form = new ExportSettingsForm())
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    // got a new scheme, update config.
                    exportScheme = form.scheme;
                    global::NFO_Helper.Settings.Default.ExportScheme = exportScheme;
                    global::NFO_Helper.Settings.Default.Save();
                }
            }
        }
    }
}
