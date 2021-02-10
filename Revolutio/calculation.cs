using System;
using System.Drawing;
using System.Windows.Forms;

namespace Revolutio
{
    public partial class Form1 : Form
    {
        //We need to have this as a function so when we redraw without surplus columns we can refresh data
        private void calculate_ratios()
        {
            int circumference = Tyre.Sizes.bicycle(cmbpbx_tyre_size.Text);
            int num_chainring = Convert.ToInt32(txtbx_chainring_max.Text) - Convert.ToInt32(txtbx_chainring_min.Text);
            int num_cassette = Convert.ToInt32(txtbx_cog_max.Text) - Convert.ToInt32(txtbx_cog_min.Text);
            
            string value = "";

            for (int j = 0; j <= num_chainring; j++)
            {
                for (int i = 0; i <= num_cassette; i++)
                {
                    double ratio = Convert.ToDouble(dgv_ratio.Rows[j].HeaderCell.Value) / Convert.ToDouble(dgv_ratio.Columns[i].HeaderCell.Value);

                    dgv_ratio.Rows[j].Cells[i].Value = ratio.ToString("###0.00");
                    dgv_distance.Rows[j].Cells[i].Value = ((ratio * circumference) / 1000).ToString("###0.00") + "m";
                }
            }
            


        }
    }

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////
    //This class will allow us to size the row headers to just the text.
    //DataGridView calculates the preferred size of the row header by applying text width,
    //row icon width and padding.
    // To change the way which preferred size is calculated and also to prevent drawing icons,
    // you need to create a custom row header cell inheriting DataGridViewRowHeaderCell and
    // override GetPreferredSize and Paint methods
    /// //////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    public class CustomHeaderCell : DataGridViewRowHeaderCell
    {
        protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
        {
            var size1 = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
            var value = string.Format("{0}", this.DataGridView.Rows[rowIndex].HeaderCell.FormattedValue);
            var size2 = TextRenderer.MeasureText(value, cellStyle.Font);
            var padding = cellStyle.Padding;
            return new Size(size2.Width + padding.Left + padding.Right, size1.Height);
        }
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, DataGridViewPaintParts.Background);
            base.PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);
            TextRenderer.DrawText(graphics, string.Format("{0}", formattedValue), cellStyle.Font, cellBounds, cellStyle.ForeColor);
        }
    }
}
