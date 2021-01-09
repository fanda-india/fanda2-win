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
            CloseAllForms();
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
            FormHelpers.ShowForm(CreateForm("Units"));
        }

        private void mnuMasterCategories_Click(object sender, EventArgs e)
        {
            FormHelpers.ShowForm(CreateForm("ProductCategories"));
        }

        private void mnuMasterLedgers_Click(object sender, EventArgs e)
        {
            FormHelpers.ShowForm(CreateForm("Ledgers"));
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CloseAllForms()
        {
            foreach (var form in forms)
            {
                if (!(form.Value is BaseForm baseForm))
                    continue;
                if (baseForm.Form != null)
                {
                    baseForm.Form.Close();
                    baseForm.Form = null;
                }
            }
        }

        private Form CreateForm(string formKey)
        {
            BaseForm baseForm = forms[formKey];
            Form form;
            if (baseForm.Form == null)
            {
                form = (Form)Activator.CreateInstance(baseForm.FormType);
                form.MdiParent = this;
                form.FormClosing += HideOnFormClosing;
                baseForm.Form = form;
            }
            else
            {
                form = baseForm.Form;
            }
            return form;
        }

        private void HideOnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ((Form)sender).Hide();
            }
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

    internal class FormsCollection : Dictionary<string, BaseForm>
    {
        public FormsCollection()
        {
            AddForm("Units", new BaseForm(typeof(UnitsForm)));
            AddForm("ProductCategories", new BaseForm(typeof(ProductCategoriesForm)));
            AddForm("Ledgers", new BaseForm(typeof(LedgersForm)));
        }

        private void AddForm(string formKey, BaseForm form = null)
        {
            Add(formKey, form);
        }
    }

    internal class BaseForm
    {
        public BaseForm(Type formType, Form form = null)
        {
            FormType = formType;
            Form = form;
        }

        public Type FormType { get; set; }
        public Form Form { get; set; }
    }
}