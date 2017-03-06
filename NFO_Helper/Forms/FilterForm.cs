using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TBD: want something to display the name of the current filter.
//      display "temporary user filter" when changes have been made and not yet saved.
// TBD: need to define the filter file format.
// TBD: sort the list boxes when making changes, or just the one that has just been added to.
// TBD: also want the filter to be able to define the order in which everything appears in the NFO.
//      need [up] and [down] buttons for the filter list to be able to move each individual item up & down.
//      this also would mean that we would NOT sort the filter list each time something is added!!
//      this will likely require changes in the NFO.toXML method as well.

namespace NFO_Helper
{
    public partial class FilterForm : Form
    {
        public NFO_Filter filter { get; set; }
        private Dictionary<string, FilterItem> filterItems;

        public FilterForm(NFO_Filter currentFilter)
        {
            InitializeComponent();
            filter = null;
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

            displayFilter(currentFilter);
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

            foreach (string s in items)
            {
                FilterItem item;
                if (filterItems.TryGetValue(s, out item) == true)
                {
                    item.makeAvailable();
                }
            }
        }

        private void button_default_Click(object sender, EventArgs e)
        {
            // configure available & filter lists for the default NFO filter.
            DefaultNfoFilter def = new DefaultNfoFilter();
            displayFilter(def);
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            // close window, set return code & data so main form can get the filter.
            filter = new NFO_Filter();
            foreach( object o in listBox_filter.Items )
            {
                if (o == null || String.IsNullOrEmpty(o.ToString()) == true)
                    continue;
                filter.NFO_PropertyList.Add(o.ToString());
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            // close window with cancel return code.
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            // TBD: present user a filename selection prompt, asking for the filter file.
        }

        private void button_saveas_Click(object sender, EventArgs e)
        {
            // TBD prompt user for filename & path where to save the current filter.
        }

        private void displayFilter( NFO_Filter f )
        {
            foreach (string s in f.NFO_PropertyList)
            {
                FilterItem item;
                if (filterItems.TryGetValue(s, out item) == true)
                {
                    item.makeInUse();
                }
            }
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
