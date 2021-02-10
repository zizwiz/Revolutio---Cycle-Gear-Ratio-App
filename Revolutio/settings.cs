namespace Revolutio
{
    public partial class Form1
    {
        private void InitializeControlValues()
        {
            txtbx_chainring_min.Text = settings.txtbx_chainring_min;
            txtbx_chainring_max.Text = settings.txtbx_chainring_max;
            txtbx_cog_min.Text = settings.txtbx_cog_min;
            txtbx_cog_max.Text = settings.txtbx_cog_max;
            cmbpbx_tyre_size.SelectedIndex = settings.cmbpbx_tyre_size;
            chkbx_1plus.Checked = settings.chkbx_1plus;
        }

        private void SaveSettings()
        {
            settings.txtbx_chainring_min = txtbx_chainring_min.Text;
            settings.txtbx_chainring_max = txtbx_chainring_max.Text;
            settings.txtbx_cog_min = txtbx_cog_min.Text;
            settings.txtbx_cog_max = txtbx_cog_max.Text;
            settings.cmbpbx_tyre_size = cmbpbx_tyre_size.SelectedIndex;

            bool one_plus = false;
            if (chkbx_1plus.Checked) one_plus = true;
            settings.chkbx_1plus = one_plus;

            settings.Save();
        }

    }
}
