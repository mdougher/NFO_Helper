using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFO_Helper
{
    public partial class FilterForm : Form
    {
        public NFO_Filter filter { get; set; }
        public string filterName { get; set; }
        public string filterFileName { get; set; }
        private Dictionary<string, FilterItem> filterItems;
        private Dictionary<string, NFO_Filter_File> filterFiles;

        public FilterForm(NFO_Filter currentFilter)
        {
            InitializeComponent();

            filterFiles = new Dictionary<string, NFO_Filter_File>();
            filterItems = new Dictionary<string, FilterItem>();
            filterItems.Add(NFOConstants.Title, new NFO_Helper.FilterItem(NFOConstants.Title, this.listBox_available, this.listBox_filter));
            filterItems.Add(NFOConstants.OriginalTitle, new NFO_Helper.FilterItem(NFOConstants.OriginalTitle, this.listBox_available, this.listBox_filter));
            filterItems.Add(NFOConstants.Year, new NFO_Helper.FilterItem(NFOConstants.Year, this.listBox_available, this.listBox_filter));
            filterItems.Add(NFOConstants.Tagline, new NFO_Helper.FilterItem(NFOConstants.Tagline, this.listBox_available, this.listBox_filter));
            filterItems.Add(NFOConstants.Rating, new NFO_Helper.FilterItem(NFOConstants.Rating, this.listBox_available, this.listBox_filter));
            filterItems.Add(NFOConstants.Outline, new NFO_Helper.FilterItem(NFOConstants.Outline, this.listBox_available, this.listBox_filter));
            filterItems.Add(NFOConstants.Runtime, new NFO_Helper.FilterItem(NFOConstants.Runtime, this.listBox_available, this.listBox_filter));
            filterItems.Add(NFOConstants.Id, new NFO_Helper.FilterItem(NFOConstants.Id, this.listBox_available, this.listBox_filter));
            filterItems.Add(NFOConstants.Trailer, new NFO_Helper.FilterItem(NFOConstants.Trailer, this.listBox_available, this.listBox_filter));
            filterItems.Add(NFOConstants.Genres, new NFO_Helper.FilterItem(NFOConstants.Genres, this.listBox_available, this.listBox_filter));
            filterItems.Add(NFOConstants.Director, new NFO_Helper.FilterItem(NFOConstants.Director, this.listBox_available, this.listBox_filter));
            filterItems.Add(NFOConstants.Actors, new NFO_Helper.FilterItem(NFOConstants.Actors, this.listBox_available, this.listBox_filter));
            filterItems.Add(NFOConstants.Set, new NFO_Helper.FilterItem(NFOConstants.Set, this.listBox_available, this.listBox_filter));
            filterItems.Add(NFOConstants.Votes, new NFO_Helper.FilterItem(NFOConstants.Votes, this.listBox_available, this.listBox_filter));
            filterItems.Add(NFOConstants.Thumb, new NFO_Helper.FilterItem(NFOConstants.Thumb, this.listBox_available, this.listBox_filter));

            comboBox_filterselect.Items.Insert(0, AppConstants.DefaultNfoFilterName);
            if (String.Compare(currentFilter.name, AppConstants.DefaultNfoFilterName) == 0)
            {
                comboBox_filterselect.SelectedIndex = 0;
            }
            else
            {
                comboBox_filterselect.Items.Insert(1, currentFilter.name);
                comboBox_filterselect.SelectedIndex = 1;
            }
            // Note: setting the combobox selection will trigger the display to be updated.
        }

        private void button_up_Click(object sender, EventArgs e)
        {
            // move item up the list.
            if (listBox_filter.SelectedIndex == -1 || listBox_filter.SelectedIndex == 0)
                return;

            updateDisplay_FilterModified();

            string selected = (string)listBox_filter.SelectedItem;
            int selIdx = listBox_filter.SelectedIndex;
            listBox_filter.Items.Remove(selected);
            listBox_filter.Items.Insert(selIdx - 1, selected);
            listBox_filter.SelectedIndex = selIdx - 1;
        }

        private void button_down_Click(object sender, EventArgs e)
        {
            // move item up the list.
            if (listBox_filter.SelectedIndex == -1 || listBox_filter.Items.Count == 0 || listBox_filter.SelectedIndex == (listBox_filter.Items.Count - 1))
                return;

            updateDisplay_FilterModified();

            string selected = (string)listBox_filter.SelectedItem;
            int selIdx = listBox_filter.SelectedIndex;
            listBox_filter.Items.Remove(selected);
            listBox_filter.Items.Insert(selIdx + 1, selected);
            listBox_filter.SelectedIndex = selIdx + 1;
        }

        private void button_single_left_Click(object sender, EventArgs e)
        {
            // move the selected item from available to filter
            if (listBox_available.SelectedItem == null)
                return;
            string sel = listBox_available.SelectedItem.ToString();
            if (String.IsNullOrEmpty(sel) == true)
                return;

            FilterItem item;
            if (filterItems.TryGetValue(sel, out item) == true)
            {
                updateDisplay_FilterModified();
                item.makeInUse();
            }
        }

        private void button_single_right_Click(object sender, EventArgs e)
        {
            // move the selected item from filter to available
            if (listBox_filter.SelectedItem == null)
                return;
            string sel = listBox_filter.SelectedItem.ToString();
            if (String.IsNullOrEmpty(sel) == true)
                return;

            FilterItem item;
            if (filterItems.TryGetValue(sel, out item) == true)
            {
                updateDisplay_FilterModified();
                item.makeAvailable();
            }
        }

        private void button_all_left_Click(object sender, EventArgs e)
        {
            // move all items from available to filter
            List<string> items = new List<string>();
            foreach( object o in listBox_available.Items )
            {
                if (o == null || String.IsNullOrEmpty(o.ToString()) == true)
                    continue;
                items.Add(o.ToString());
            }

            if (items.Any() == false)
                return;

            updateDisplay_FilterModified();

            foreach (string s in items)
            {
                FilterItem item;
                if (filterItems.TryGetValue(s, out item) == true)
                {
                    item.makeInUse();
                }
            }
        }

        private void button_all_right_Click(object sender, EventArgs e)
        {
            // move all items from filter to available
            if(allItemsAvailable() != 0)
                updateDisplay_FilterModified();
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            // close window, set return code & data so main form can get the filter.
            filter = new NFO_Filter();
            filter.setPropertyList(getFilterProperties());
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            // close window with cancel return code.
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button_saveas_Click(object sender, EventArgs e)
        {
#if DEBUG
            string initDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
#else
            string initDir = AppDomain.CurrentDomain.BaseDirectory;
#endif
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "NFO Filter files (*" + AppConstants.NfoFilterFileExtension + ")| *" + AppConstants.NfoFilterFileExtension + "|All files (*.*)|*.*";
            sv.FilterIndex = 1;
            sv.RestoreDirectory = true;
            sv.AddExtension = true;
            sv.DefaultExt = AppConstants.NfoFilterFileExtension;
            sv.InitialDirectory = initDir;
            sv.OverwritePrompt = true;
            sv.Title = "NFO_Helper - Save NFO Filter File...";

            if (sv.ShowDialog() == DialogResult.OK)
            {
                // user has selected a filename to save.
                string name = Path.GetFileNameWithoutExtension(sv.FileName); // get the 'last part' of the filename before the extension as the filtername.
                NFO_Filter_File temp = null;
                if (filterFiles.TryGetValue(name, out temp) == true)
                {
                    MessageBox.Show("A Filter with this name is already known. Please use a different name.", "NFO_Helper", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NFO_Filter_File file = new NFO_Filter_File();
                file.fileName = sv.FileName;
                file.filter.name = name;
                file.filter.setPropertyList(getFilterProperties());
                try
                {
                    file.writeFile(sv.FileName);
                }
                catch( NfoReadWriteException ex )
                {
                    MessageBox.Show("Failed to write NFO Filter File: " + ex.Message, "NFO_Helper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // save the name of this filter, so it can be pulled by the main form.
                filterName = file.filter.name;
                filterFileName = file.fileName;

                // persist this filename to the app configuration.
                if (String.IsNullOrEmpty(global::NFO_Helper.Settings.Default.KnownFilterFilenames) == false)
                    global::NFO_Helper.Settings.Default.KnownFilterFilenames += ";";
                global::NFO_Helper.Settings.Default.KnownFilterFilenames += filterFileName;
                global::NFO_Helper.Settings.Default.Save();

                // add the filtername to the combobox & set that as the current selection.
                // add to the filterFiles before changing the selection!
                int newIdx = comboBox_filterselect.Items.Add(file.filter.name);
                filterFiles.Add(name, file);
                comboBox_filterselect.SelectedIndex = newIdx;
            }
        }

        private void updateDisplay_FilterModified()
        {
            comboBox_filterselect.SelectedIndex = -1;
            filterName = AppConstants.TempNfoFilterName;
            filterFileName = "";
        }

        private void displayFilter( NFO_Filter f )
        {
            // first move everything to available, so we can then move only what is needed back to the filter.
            allItemsAvailable();
            List<string> properties = f.getPropertyList();
            foreach (string s in properties)
            {
                FilterItem item;
                if (filterItems.TryGetValue(s, out item) == true)
                {
                    item.makeInUse();
                }
            }
        }

        private int allItemsAvailable()
        {
            List<string> items = new List<string>();
            foreach (object o in listBox_filter.Items)
            {
                if (o == null || String.IsNullOrEmpty(o.ToString()) == true)
                    continue;
                items.Add(o.ToString());
            }

            if (items.Any() == false)
                return 0;

            foreach (string s in items)
            {
                FilterItem item;
                if (filterItems.TryGetValue(s, out item) == true)
                {
                    item.makeAvailable();
                }
            }
            return items.Count();
        }

        private void comboBox_filterselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sel = comboBox_filterselect.SelectedIndex;
            if (comboBox_filterselect.SelectedIndex == -1)
            {
                return;
            }
            else if (comboBox_filterselect.SelectedIndex == 0)
            {
                // load defualt filter
                DefaultNfoFilter def = new DefaultNfoFilter();
                displayFilter(def);
            }
            else
            {
                NFO_Filter_File file = null;
                
                string name = (string)comboBox_filterselect.SelectedItem;
                if (filterFiles.TryGetValue(name, out file) == true)
                {
                    displayFilter(file.filter);
                    filterFileName = file.fileName;
                }
                else
                {
                    MessageBox.Show("Failed to find the filter file for '" + name + "'.", "NFO_Helper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            button_up.Text = char.ConvertFromUtf32(708);
            button_down.Text = char.ConvertFromUtf32(709);

            // "reset" the form each time it is loaded.
            filter = null;

            // prepare any filter files that have been previously used.
            string listStr = global::NFO_Helper.Settings.Default.KnownFilterFilenames;
            if (String.IsNullOrEmpty(listStr) == true)
                return;

            string validTokens = "";
            char[] delims = { ';' };
            string[] tokens = listStr.Split(delims);
            foreach (string token in tokens)
            {
                NFO_Filter_File file = new NFO_Filter_File();
                file.fileName = token;
                try
                {
                    file.parseFile(token);
                }
                catch (NfoReadWriteException)
                {
                    continue;
                }

                NFO_Filter_File temp = null;
                if (filterFiles.TryGetValue(file.filter.name, out temp) == true)
                {
                    // skip this one, there is one with this name already present.
                    continue;
                }
                else
                {
                    filterFiles.Add(file.filter.name, file);
                    comboBox_filterselect.Items.Add(file.filter.name);
                    if (String.IsNullOrEmpty(validTokens) == false)
                        validTokens += ";";
                    validTokens += file.fileName;
                }
            }
            if( String.Compare(listStr, validTokens) != 0 )
            {
                // at least one of the tokens was not used! update the config!
                global::NFO_Helper.Settings.Default.KnownFilterFilenames = validTokens;
                global::NFO_Helper.Settings.Default.Save();
            }
        }

        private List<string> getFilterProperties()
        {
            List<string> retList = new List<string>();
            foreach (object o in listBox_filter.Items)
            {
                if (o == null || String.IsNullOrEmpty(o.ToString()) == true)
                    continue;
                retList.Add(o.ToString());
            }
            return retList;
        }
    }
    public class FilterItem
    {
        public string name { get; set; }
        public bool isAvailable { get; set; }

        private ListBox availBox { get; set; }
        private ListBox useBox { get; set; }

        public FilterItem(string nameStr, ListBox availableBox, ListBox inUseBox)
        {
            name = nameStr;
            isAvailable = true;
            availBox = availableBox;
            useBox = inUseBox;

            availBox.Items.Add(name);
        }
        public void makeAvailable()
        {
            if (this.isAvailable == true)
                return;

            useBox.Items.Remove(name);
            availBox.Items.Add(name);
            this.isAvailable = true;
        }
        public void makeInUse()
        {
            if (this.isAvailable == false)
                return;

            availBox.Items.Remove(name);
            useBox.Items.Add(name);
            this.isAvailable = false;
        }
    }
}
