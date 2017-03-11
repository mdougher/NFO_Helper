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
    public partial class SearchForm : Form
    {
        public IDataProvider provider { get; set; }
        public string ID { get; set; }

        public SearchForm(IDataProvider p)
        {
            provider = p;
            InitializeComponent();
            // need to move the progress bar so that it is in the right place. if i put it there in the designer, it makes it part of the panel...
            progressBar1.Location = new Point(170, 190);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_search.Text) == true)
                return;

            startProgressIndication();

            // clear previous results!
            Control.ControlCollection ctrls = panel_results.Controls;
            foreach (Control c in ctrls)
            {
                c.Dispose();
            }
            panel_results.Controls.Clear();

            SearchResults results = null;
            try
            {
                await Task.Delay(2000);
                results = await provider.getSearchResultsAsync(textBox_search.Text);
            }
            catch (DataProviderException ex )
            {
                MessageBox.Show(ex.Message, "NFO_Helper Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (results == null)
                return;

            label_results.Text = "Results: " + results.results.Count();
            label_results.Show();

            // add controls to the panel. 
            // poster, title (year), id.
            // -----
            // |   | title (year)
            // |   | id: 123
            // |   | outline: blah blah
            // |   | 
            // -----
            // [select] button

            int img_w = 100;
            int img_h = 150;
            panel_results.VerticalScroll.SmallChange = img_h / 4;
            panel_results.VerticalScroll.LargeChange = img_h + 13;
            int y_off = 2;
            foreach (SearchResult res in results.results)
            {
                if (y_off > 2)
                {
                    // add a horizontal dividing line.
                    Label div = new Label();
                    div.Location = new Point(10, y_off);
                    div.BorderStyle = BorderStyle.Fixed3D;
                    div.AutoSize = false;
                    div.Height = 2;
                    div.Width = 350;

                    panel_results.Controls.Add(div);
                    y_off += 4;
                }

                PictureBox img = new PictureBox();
                img.Location = new Point(1, y_off + 1);
                img.Width = img_w;
                img.Height = img_h;
                img.BorderStyle = BorderStyle.FixedSingle;
                img.SizeMode = PictureBoxSizeMode.StretchImage;
                if (String.IsNullOrEmpty(res.Poster) == false)
                {
                    loadImageAsync(res.Poster, img); // do not await!
                }

                Label title = new Label();
                title.AutoSize = false;
                title.Width = 350 - img_w - 3;
                title.AutoEllipsis = true;
                title.Location = new Point(img.Width + 3, y_off + 1);
                title.Text = res.Title;
                if (String.IsNullOrEmpty(res.Year) == false)
                    title.Text += " (" + res.Year + ")";

                Label id = new Label();
                id.Location = new Point(img.Width + 3, y_off + title.Height + 2);
                id.Text = "id: " + res.ID;

                Label outline = new Label();
                outline.AutoSize = false;
                outline.Location = new Point(img.Width + 3, y_off + title.Height + id.Height + 2);
                outline.Text = res.Outline;
                outline.AutoEllipsis = true;
                outline.Width = title.Width;
                outline.Height = img.Height - title.Height - id.Height - 2;

                Button sel = new Button();
                sel.Text = "Select";
                sel.Location = new Point(15, img.Location.Y + img.Height + 2);
                sel.Click += (Sender, EventArgs) => { onUserSelection(Sender, EventArgs, res.ID); };

                panel_results.Controls.Add(id);
                panel_results.Controls.Add(title);
                panel_results.Controls.Add(img);
                panel_results.Controls.Add(outline);
                panel_results.Controls.Add(sel);

                y_off = sel.Location.Y + sel.Height + 2;
            }

            endProgressIndication();
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

        private void onUserSelection(object sender, EventArgs e, string id)
        {
            ID = id;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void startProgressIndication()
        {
            progressBar1.Show();
            textBox_search.Enabled = false;
            button_search.Enabled = false;
        }

        private void endProgressIndication()
        {
            progressBar1.Hide();
            textBox_search.Enabled = true;
            button_search.Enabled = true;
        }

        private void textBox_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                button1_Click(this, new EventArgs());
            }
        }
    }
}
