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

// TBD: need to define the filter file format.
//      currently seems to just be a comma separated list of the NFO fields that are 'in use'
//      also - name string.

namespace NFO_Helper
{
    public partial class FilterForm : Form
    {
        public NFO_Filter filter { get; set; }
        public string filterName { get; set; }
        private Dictionary<string, FilterItem> filterItems;

        public FilterForm(NFO_Filter currentFilter)
        {
            InitializeComponent();
            
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
            List<string> items = new List<string>();
            foreach (object o in listBox_filter.Items)
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
                    item.makeAvailable();
                }
            }
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            // close window, set return code & data so main form can get the filter.
            filter = new NFO_Filter();
            filter.NFO_PropertyList = getFilterProperties();
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
            // TBD: have the initial directory be the exe path, not the desktop.
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "NFO Filter files (*" + AppConstants.NfoFilterFileExtension + ")| *" + AppConstants.NfoFilterFileExtension + "|All files (*.*)|*.*";
            sv.FilterIndex = 1;
            sv.RestoreDirectory = true;
            sv.AddExtension = true;
            sv.DefaultExt = AppConstants.NfoFilterFileExtension;
            sv.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sv.OverwritePrompt = true;
            sv.Title = "NFO_Helper - Save NFO Filter File...";

            if (sv.ShowDialog() == DialogResult.OK)
            {
                // user has selected a filename to save.

                // TBD: make sure there is no other filter currently 'saved' with this name in the user's config.

                NFO_Filter_File file = new NFO_Filter_File();
                file.fileName = sv.FileName;
                file.filterName = Path.GetFileNameWithoutExtension(sv.FileName); // get the 'last part' of the filename before the extension as the filtername.
                file.filterProperties = getFilterProperties();
                bool writeRet = file.writeFile(sv.FileName);
                if (writeRet == false)
                {
                    MessageBox.Show("Failed to create new NFO Filter File at '" + sv.FileName + "'.", "NFO_Helper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // add the filtername to the combobox & set that as the current selection.
                int newIdx = comboBox_filterselect.Items.Add(file.filterName);
                comboBox_filterselect.SelectedIndex = newIdx;

                // save the name of this filter, so it can be pulled by the main form.
                filterName = file.filterName;

                // TBD: if a filename is given, persist this filename to the app configuration. want app config user value 'user NFO Filter File List' --> a list of filenames. ';' separated?
            }
        }

        private void updateDisplay_FilterModified()
        {
            comboBox_filterselect.SelectedIndex = -1;
            filterName = "[Temporary User Settings]";
        }

        private void displayFilter( NFO_Filter f )
        {
            // first move everything to available, so we can then move only what is needed back to the filter.
            button_all_right_Click(this, new EventArgs());

            foreach (string s in f.NFO_PropertyList)
            {
                FilterItem item;
                if (filterItems.TryGetValue(s, out item) == true)
                {
                    item.makeInUse();
                }
            }
        }

        private void comboBox_filterselect_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                // TBD: get name of filter from the combobox, load that filter, apply it to the display.
            }
        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            // "reset" the form each time it is loaded.
            filter = null;
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
