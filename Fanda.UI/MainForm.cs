using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fanda.UI
{
    public partial class MainForm : Form
    {
        private const string AppTitle = "Fanda v1.0";
        private OpenCompanyForm openCompanyForm;
        private EditCompanyForm editCompanyForm;

        private readonly FormsCollection forms = new FormsCollection();

        //private UnitsForm unitsForm;
        //private ProductCategoriesForm productCategoriesForm;
        //private LedgersForm ledgersForm;

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
            TypeForm formType = forms["units"];
            UnitsForm unitsForm = (UnitsForm)Activator.CreateInstance(.FormType);

            unitsForm = FormHelpers.ShowForm(ref unitsForm, this);
        }

        private void mnuMasterCategories_Click(object sender, EventArgs e)
        {
            productCategoriesForm = FormHelpers.ShowForm(ref productCategoriesForm, this);
        }

        private void mnuMasterLedgers_Click(object sender, EventArgs e)
        {
            ledgersForm = FormHelpers.ShowForm(ref ledgersForm, this);
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

    internal class FormsCollection : Dictionary<string, TypeForm>
    {
        public FormsCollection()
        {
            AddForm("Units", new TypeForm(typeof(UnitsForm)));
            AddForm("ProductCategories", new TypeForm(typeof(ProductCategoriesForm)));
            AddForm("Ledgers", new TypeForm(typeof(LedgersForm)));
        }

        private void AddForm(string formKey, TypeForm form = null)
        {
            Add(formKey, form);
        }
    }

    internal class TypeForm
    {
        public TypeForm(Type formType, Form form = null)
        {
            FormType = formType;
            Form = form;
        }

        public Type FormType { get; set; }
        public Form Form { get; set; }
    }
}