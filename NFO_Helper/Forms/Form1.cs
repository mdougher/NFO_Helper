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

        public Form1()
        {
            InitializeComponent();
            provider = new TMDb.TMDbDataProvider();
            nfo = new NFO();
            currentPosterIndex = 0;
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
                    button_export.Focus();
                }
            }
            endProgressIndication();
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
            
            // note: if the NFO contains a 'thumb', we do not need to save the image?
            //      this also means that there is only a single export step, so update the titles of the prompt windows accordingly.
            bool isThumb = String.IsNullOrEmpty((string)nfo.getProperty(NFOConstants.Thumb)) == false;
#if DEBUG
            string initDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
#else
            string initDir = AppDomain.CurrentDomain.BaseDirectory;
#endif

            // save the NFO, be careful to sanitize the output filenames so they do not contain invalid characters. This might not be perfect, but should work for most situations.
            string defaultFileName = (string)nfo.getProperty(NFOConstants.Title) + " (" + (string)nfo.getProperty(NFOConstants.Year) + ")";
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                defaultFileName = defaultFileName.Replace(c, '-');
            }
            SaveFileDialog dlgNfo = new SaveFileDialog();
            dlgNfo.Filter = "nfo files (*.nfo)|*.nfo|All files (*.*)|*.*";
            dlgNfo.FilterIndex = 1;
            dlgNfo.RestoreDirectory = true;
            dlgNfo.AddExtension = true;
            dlgNfo.DefaultExt = "nfo";
            dlgNfo.InitialDirectory = initDir;
            dlgNfo.OverwritePrompt = true;
            dlgNfo.Title = isThumb ? "Save NFO File..." : "Export Step 1 of 2 - Save NFO File...";
            dlgNfo.FileName = defaultFileName;

            if (dlgNfo.ShowDialog() == DialogResult.OK)
            {
                // user has selected a filename to save.
                File.WriteAllText(dlgNfo.FileName, nfo.toXML(true));
            }

            // save the Image
            if (pictureBox_img.Image == null || isThumb == true)
                return;
            
            SaveFileDialog dlgImg = new SaveFileDialog();
            dlgImg.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            dlgImg.FilterIndex = 1;
            dlgImg.RestoreDirectory = true;
            dlgImg.AddExtension = true;
            dlgImg.DefaultExt = "jpg";
            dlgImg.InitialDirectory = initDir;
            dlgImg.OverwritePrompt = true;
            dlgImg.Title = "Export Step 2 of 2 - Save Image File...";
            dlgImg.FileName = defaultFileName;

            if (dlgImg.ShowDialog() == DialogResult.OK)
            {
                // user has selected a filename to save.
                pictureBox_img.Image.Save(dlgImg.FileName);
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
    }
}
