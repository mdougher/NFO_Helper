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
    public partial class SearchResultsForm : Form
    {
        private class SearchItem
        {
            public static int item_height = 180;
            public static int item_width = 350;
            public static int img_width = 100;
            public static int img_height = 150;
            public SearchItem( SearchResult res, Panel panel, int x_offset, int y_offset, selectionDelgate cb )
            {
                PictureBox img = new PictureBox();
                img.Location = new Point(x_offset, y_offset);
                img.Width = img_width;
                img.Height = img_height;
                img.BorderStyle = BorderStyle.FixedSingle;
                img.SizeMode = PictureBoxSizeMode.StretchImage;
                if (String.IsNullOrEmpty(res.Poster) == false)
                {
                    Task<bool> fireAndForget = loadImageAsync(res.Poster, img); // do not await!
                }

                Label title = new Label();
                title.AutoSize = false; // titles with '&' are taken literally, does not need to be escaped.
                title.UseMnemonic = false;
                title.Width = item_width - img_width - 3;
                title.AutoEllipsis = true;
                title.Location = new Point(x_offset + img.Width + 3, y_offset);
                title.Text = res.Title;
                if (String.IsNullOrEmpty(res.Year) == false)
                    title.Text += " (" + res.Year + ")";

                Label id = new Label();
                id.Location = new Point(x_offset + img.Width + 3, y_offset + title.Height + 2);
                id.Text = "id: " + res.ID;

                Label outline = new Label();
                outline.AutoSize = false;
                outline.Location = new Point(x_offset + img.Width + 3, y_offset + title.Height + id.Height + 2);
                outline.Text = res.Outline;
                outline.AutoEllipsis = true;
                outline.Width = title.Width;
                outline.Height = img.Height - title.Height - id.Height - 2;

                Button sel = new Button();
                sel.Text = "Select";
                sel.Location = new Point(x_offset + 15, img.Location.Y + img.Height + 2);
                sel.Click += (Sender, EventArgs) => { cb(res); };

                panel.Controls.Add(id);
                panel.Controls.Add(title);
                panel.Controls.Add(img);
                panel.Controls.Add(outline);
                panel.Controls.Add(sel);
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
        }

        public SearchResult selectedResult { get; set; }
        private List<SearchItem> items { get; set; }
        private delegate void selectionDelgate(SearchResult res);
        public SearchResultsForm(SearchResults results)
        {
            InitializeComponent();

            // positioning constants. note, initial offsets start AFTER the 
            const int numItemsInRow = 2;
            const int initial_x_offset = 1;
            const int initial_y_offset = 5;
            const int additional_x_off_per_item = 10;
            const int additional_y_off_per_item = 10;
            int x_offset = initial_x_offset;
            int y_offset = initial_y_offset;

            // add a label to say how many results there are.
            Label count = new Label();
            count.AutoSize = true;
            count.Location = new Point(x_offset, y_offset);
            count.Text = "Found " + results.results.Count() + " results from the given search criteria. Please make a selection from the list of results below.";
            panel_results.Controls.Add(count);
            y_offset += count.Height;
            y_offset += 5; // add a little space after this one.
            // also add a horizontal divider after the count label.
            Label div = new Label();
            div.Location = new Point(x_offset, y_offset);
            div.BorderStyle = BorderStyle.Fixed3D;
            div.AutoSize = false;
            div.Height = 2;
            div.Width = SearchItem.item_width * numItemsInRow;
            panel_results.Controls.Add(div);
            y_offset += div.Height;
            
            panel_results.VerticalScroll.SmallChange = SearchItem.item_height / 4;
            panel_results.VerticalScroll.LargeChange = SearchItem.item_height + 13;

            
            int resultNum = 1;
            items = new List<SearchItem>();
            selectionDelgate del = onUserSelection;
            foreach( SearchResult res in results.results)
            {
                items.Add(new SearchItem(res, panel_results, x_offset, y_offset, del));
                if (resultNum % numItemsInRow != 0)
                {
                    Label vert = new Label();
                    vert.Location = new Point(x_offset + SearchItem.item_width, y_offset);
                    vert.BorderStyle = BorderStyle.Fixed3D;
                    vert.AutoSize = false;
                    vert.Height = SearchItem.img_height;
                    vert.Width = 2;
                    panel_results.Controls.Add(vert);

                    // keep adding to row, shift right one.
                    x_offset += SearchItem.item_width + additional_x_off_per_item;
                }
                else
                {
                    // add a horizontal dividing line.
                    Label horiz = new Label();
                    horiz.Location = new Point(initial_x_offset, y_offset + SearchItem.item_height);
                    horiz.BorderStyle = BorderStyle.Fixed3D;
                    horiz.AutoSize = false;
                    horiz.Height = 2;
                    horiz.Width = SearchItem.item_width * numItemsInRow;
                    panel_results.Controls.Add(horiz);

                    // end of row, shift down one.
                    x_offset = initial_x_offset;
                    y_offset += SearchItem.item_height + additional_y_off_per_item;
                }
                resultNum++;
            }
        }

        private void onUserSelection(SearchResult res)
        {
            this.selectedResult = res;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
