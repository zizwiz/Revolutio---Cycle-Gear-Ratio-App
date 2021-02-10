using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CenteredMessagebox;
using help_about;
using Revolutio.Properties;
using Tyre;

namespace Revolutio
{
    public partial class Form1 : Form
    {
        private Settings settings = Settings.Default;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeControlValues();

            lbl_chainring_min.Visible = true;
            lbl_chainring_max.Visible = true;
            txtbx_chainring_max.Visible = true;
            chkbx_1plus.Checked = true;

            cmbpbx_tyre_size.SelectedIndex = 0;
            lbl_diameter.Text = "Circumference = " + Sizes.bicycle(cmbpbx_tyre_size.Text) + "mm";
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            var f1 = new Help_Form();
            f1.ShowDialog();
            GC.Collect();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_show_ratios_Click(object sender, EventArgs e)
        {
            //first remove the checkboxes that may already exist.
            RemoveCheckBoxes();
            PopulateData(true);
        }

        private void PopulateData(bool flag)
        {
            int row_count = 20;
            int col_count = 20;
            int row_counter = 0;
            int col_counter = 0;
            int row_num = 0;
            int col_num = 0;


            if (txtbx_chainring_max.Text == "0") txtbx_chainring_max.Text = "1";
            if (txtbx_chainring_min.Text == "0") txtbx_chainring_min.Text = "1";
            if (txtbx_cog_max.Text == "0") txtbx_cog_max.Text = "1";
            if (txtbx_cog_min.Text == "0") txtbx_cog_min.Text = "1";



            int num_cassette = Convert.ToInt32(txtbx_chainring_max.Text) - Convert.ToInt32(txtbx_chainring_min.Text);
            int smallest_cassette = Convert.ToInt32(txtbx_chainring_min.Text);

            int num_chainring = Convert.ToInt32(txtbx_cog_max.Text) - Convert.ToInt32(txtbx_cog_min.Text);
            int smallest_chainring = Convert.ToInt32(txtbx_cog_min.Text);


            if ((Convert.ToInt32(txtbx_chainring_max.Text) < Convert.ToInt32(txtbx_chainring_min.Text)) ||
                (Convert.ToInt32(txtbx_cog_max.Text) < Convert.ToInt32(txtbx_cog_min.Text)))
            {
                MsgBox.Show("Check Max values greater than Min values", "Check Values", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if ((num_cassette > 90) || (num_chainring > 90))
            {
                MsgBox.Show("Check you have correct number of gears max = 90 on front or back", "Too many gears", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }



            dgv_ratio.Columns.Clear();
            dgv_distance.Columns.Clear();

            if ((grpbx_cog.Controls.OfType<CheckBox>().Count() == 0) || (grpbx_cassette.Controls.OfType<CheckBox>().Count() == 0)) flag = true;

            //Add all columns and format
            for (int i = 0; i <= num_chainring; i++)
            {
                dgv_ratio.Columns.Add((smallest_chainring + i).ToString(), (smallest_chainring + i).ToString());
                dgv_ratio.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_ratio.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

                dgv_distance.Columns.Add((smallest_chainring + i).ToString(), (smallest_chainring + i).ToString());
                dgv_distance.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_distance.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;

                if (flag)
                {
                    if (col_counter == 8)
                    {
                        col_count += 40;
                        col_counter = 0;
                    }

                    CheckBox col_cbox = new CheckBox();
                    col_cbox.Tag = col_num; //"cog_" + dgv_distance.Rows[i].HeaderCell.Value;
                    col_cbox.Text = dgv_distance.Columns[i].HeaderCell.Value.ToString();
                    col_cbox.CheckedChanged += new EventHandler(this.CassetteCheckedChange);
                    col_cbox.AutoSize = true;
                    col_cbox.Location = new Point(col_count, col_counter * 20); //vertical
                    //box.Location = new Point(i * 50, 10); //horizontal
                    grpbx_cassette.Controls.Add(col_cbox);
                    col_cbox.Checked = true;
                    col_counter++;
                    col_num++;
                }
            }

            //Add all rows and row headers custom resize the row headers
            for (int i = 0; i <= num_cassette; i++)
            {
                dgv_ratio.RowTemplate.DefaultHeaderCellType = typeof(CustomHeaderCell);
                dgv_ratio.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                dgv_ratio.RowHeadersDefaultCellStyle.Padding = new Padding(2);
                dgv_ratio.Rows.Add();
                dgv_ratio.Rows[i].HeaderCell.Value = (smallest_cassette + i).ToString();

                dgv_distance.RowTemplate.DefaultHeaderCellType = typeof(CustomHeaderCell);
                dgv_distance.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                dgv_distance.RowHeadersDefaultCellStyle.Padding = new Padding(2);
                dgv_distance.Rows.Add();
                dgv_distance.Rows[i].HeaderCell.Value = (smallest_cassette + i).ToString();

                if (flag)
                {
                    if (row_counter == 8)
                    {
                        row_count += 40;
                        row_counter = 0;
                    }

                    CheckBox row_cbox = new CheckBox();
                    row_cbox.Tag = row_num; //"cog_" + dgv_distance.Rows[i].HeaderCell.Value;
                    row_cbox.Text = dgv_distance.Rows[i].HeaderCell.Value.ToString();
                    row_cbox.CheckedChanged += new EventHandler(this.CogCheckedChange);
                    row_cbox.AutoSize = true;
                    row_cbox.Location = new Point(row_count, row_counter * 20); //vertical
                    //box.Location = new Point(i * 50, 10); //horizontal
                    grpbx_cog.Controls.Add(row_cbox);
                    row_cbox.Checked = true;
                    row_counter++;
                    row_num++;
                }
            }

            if (!flag) Refresh();

            //now resize all to fit to one screen
            for (int i = 0; i <= num_chainring; i++)
            {
                dgv_ratio.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv_distance.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dgv_ratio.AutoResizeRowHeadersWidth(0, DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dgv_distance.AutoResizeRowHeadersWidth(0, DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            dgv_ratio.AllowUserToAddRows = false;
            dgv_distance.AllowUserToAddRows = false;

            calculate_ratios(); // Fill in the grid.
        }

        protected void CogCheckedChange(object sender, EventArgs e)
        {
            CheckBox cog = (CheckBox)sender;

            if (cog.Checked)
            {
                dgv_ratio.Rows[Convert.ToInt16(cog.Tag)].Visible = true;
                dgv_distance.Rows[Convert.ToInt16(cog.Tag)].Visible = true;
            }
            else
            {
                dgv_ratio.Rows[Convert.ToInt16(cog.Tag)].Visible = false;
                dgv_distance.Rows[Convert.ToInt16(cog.Tag)].Visible = false;
            }
        }

        protected void CassetteCheckedChange(object sender, EventArgs e)
        {
            CheckBox cassette = (CheckBox)sender;

            if (cassette.Checked)
            {
                dgv_ratio.Columns[Convert.ToInt16(cassette.Tag)].Visible = true;
                dgv_distance.Columns[Convert.ToInt16(cassette.Tag)].Visible = true;
            }
            else
            {
                dgv_ratio.Columns[Convert.ToInt16(cassette.Tag)].Visible = false;
                dgv_distance.Columns[Convert.ToInt16(cassette.Tag)].Visible = false;
            }
        }

        private void chkbx_1plus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbx_1plus.Checked)
            {
                lbl_chainring_min.Visible = true;
                lbl_chainring_max.Visible = true;
                txtbx_chainring_max.Visible = true;
            }
            else
            {
                lbl_chainring_min.Visible = false;
                lbl_chainring_max.Visible = false;
                txtbx_chainring_max.Visible = false;
                txtbx_chainring_max.Text = txtbx_chainring_min.Text;
            }
        }

        private void txtbx_chainring_min_TextChanged(object sender, EventArgs e)
        {
            if (!chkbx_1plus.Checked)
            {
                txtbx_chainring_max.Text = txtbx_chainring_min.Text;
            }
        }


        private void RemoveCheckBoxes()
        {
            // When we are going to refresh the data we first remove the checkboxes
            // we will then replace them.
            int q = grpbx_cog.Controls.OfType<CheckBox>().Count(); //   Where(c => c.Checked).Count();

            for (int i = 0; i <= q; i++)
            {
                foreach (Control c in grpbx_cog.Controls)
                {
                    if (c.GetType().Name == "CheckBox")
                    {
                        grpbx_cog.Controls.Remove(c);
                    }
                }
            }

            q = grpbx_cassette.Controls.OfType<CheckBox>().Count();

            for (int i = 0; i <= q; i++)
            {
                foreach (Control c in grpbx_cassette.Controls)
                {
                    if (c.GetType().Name == "CheckBox")
                    {
                        grpbx_cassette.Controls.Remove(c);
                    }
                }
            }
        }


        private void grpbx_cog_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = (GroupBox)sender;

            e.Graphics.DrawString(box.Text, box.Font, Brushes.Black, 0, 0);
            e.Graphics.Clear(Color.White);
        }

        private void cmbpbx_tyre_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_diameter.Text = "Circumference = " + Sizes.bicycle(cmbpbx_tyre_size.Text) + "mm";

            PopulateData(false);
        }

        private void Refresh()
        {
            //make sure all rows and columns we need are still there and the rest have been removed
            foreach (Control c in grpbx_cog.Controls)
            {
                if (c.GetType().Name == "CheckBox")
                {
                    var checkbox = (CheckBox)c;
                    if (!checkbox.Checked)
                    {
                        dgv_ratio.Rows[Convert.ToInt16(checkbox.Tag.ToString())].Visible = false;
                        dgv_distance.Rows[Convert.ToInt16(checkbox.Tag.ToString())].Visible = false;
                    }

                }
            }

            foreach (Control c in grpbx_cassette.Controls)
            {
                if (c.GetType().Name == "CheckBox")
                {
                    var checkbox = (CheckBox)c;
                    if (!checkbox.Checked)
                    {
                        int abc = Convert.ToInt16(checkbox.Tag.ToString());
                        dgv_ratio.Columns[Convert.ToInt16(checkbox.Tag.ToString())].Visible = false;
                        dgv_distance.Columns[Convert.ToInt16(checkbox.Tag.ToString())].Visible = false;

                    }
                }
            }

        }
    }
}
