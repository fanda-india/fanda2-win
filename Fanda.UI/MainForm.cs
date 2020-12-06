using System;
using System.Windows.Forms;

namespace Fanda.UI
{
    public partial class MainForm : Form
    {
        private OpenCompanyForm openCompanyForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            EnableMenu(false);
        }

        private void OpenCompanyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (AppConfig.CurrentCompany != null)
                EnableMenu();
        }

        private void mnuFileOpenCompany_Click(object sender, EventArgs e)
        {
            openCompanyForm = FormHelpers.ShowForm(ref openCompanyForm, this);
            openCompanyForm.FormClosed += OpenCompanyForm_FormClosed;
        }

        private void mnuMasterLedgers_Click(object sender, EventArgs e)
        {
            var form = new LedgersForm();
            form.MdiParent = this;
            form.Show();
            form.BringToFront();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Private methods

        private void EnableMenu(bool enable = true)
        {
            mnuMaster.Enabled = enable;
            mnuTransations.Enabled = enable;
            mnuGeneralReports.Enabled = enable;
            mnuInventoryReports.Enabled = enable;
            mnuAnnualReports.Enabled = enable;

            mnuFileEditCompany.Enabled = enable;
            mnuFileCloseCompany.Enabled = enable;
            mnuFileCarryForward.Enabled = enable;
        }

        #endregion Private methods
    }
}