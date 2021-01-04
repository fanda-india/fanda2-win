using System;
using System.Windows.Forms;

namespace Fanda.UI
{
    public partial class MainForm : Form
    {
        private const string AppTitle = "Fanda v1.0";
        private OpenCompanyForm openCompanyForm;
        private EditCompanyForm editCompanyForm;
        private UnitsForm unitsForm;
        private ProductCategoriesForm productCategoriesForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = AppTitle;
            EnableMenu(false);
            mnuFileOpenCompany.PerformClick();
        }

        #region File -> Company

        private void mnuFileOpenCompany_Click(object sender, EventArgs e)
        {
            openCompanyForm = FormHelpers.ShowForm(ref openCompanyForm, this);
            openCompanyForm.FormClosed += OpenCompanyForm_FormClosed;
        }

        private void mnuFileNewCompany_Click(object sender, EventArgs e)
        {
            editCompanyForm = FormHelpers.ShowForm(ref editCompanyForm, this);
            editCompanyForm.Edit(0);
        }

        private void mnuFileEditCompany_Click(object sender, EventArgs e)
        {
            if (AppConfig.CurrentCompany != null)
            {
                editCompanyForm = FormHelpers.ShowForm(ref editCompanyForm, this);
                editCompanyForm.Edit(AppConfig.CurrentCompany.Id);
            }
        }

        private void OpenCompanyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (AppConfig.CurrentCompany != null)
            {
                EnableMenu();
            }
            else
            {
                EnableMenu(false);
            }
        }

        #endregion File -> Company

        private void mnuMasterUnits_Click(object sender, EventArgs e)
        {
            unitsForm = FormHelpers.ShowForm(ref unitsForm, this);
        }

        private void mnuMasterCategories_Click(object sender, EventArgs e)
        {
            productCategoriesForm = FormHelpers.ShowForm(ref productCategoriesForm, this);
        }

        private void mnuMasterLedgers_Click(object sender, EventArgs e)
        {
            var form = new LedgersForm
            {
                MdiParent = this
            };
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
            mnuFileCarryForward.Enabled = enable;

            if (AppConfig.CurrentCompany != null)
            {
                Text = $"{AppTitle} - [{AppConfig.CurrentCompany.OrgName}]";
            }
        }

        #endregion Private methods
    }
}