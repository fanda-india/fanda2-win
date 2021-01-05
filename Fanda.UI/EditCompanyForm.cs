using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;
using Fanda2.Backend.Repositories;

using System;
using System.Windows.Forms;

namespace Fanda.UI
{
    public partial class EditCompanyForm : Form
    {
        private readonly OrganizationRepository _repository;
        private int _id;
        private Organization _org;

        public EditCompanyForm()
        {
            InitializeComponent();
            _repository = new OrganizationRepository();
        }

        private void EditCompanyForm_Shown(object sender, EventArgs e)
        {
            txtCode.Focus();
        }

        public void Edit(int id)
        {
            _id = id;

            if (_id == 0)
            {
                _org = new Organization();
            }
            else
            {
                _org = _repository.GetById(_id);
            }

            orgBindingSource.DataSource = _org;
            yearBindingSource.DataSource = _org.Year;
            addressBindingSource.DataSource = _org.Address;
            contactBindingSource.DataSource = _org.Contact;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                txtCode_Validated(this, null);
                txtName_Validated(this, null);
                if (!string.IsNullOrEmpty(orgErrors.GetError(txtCode)) ||
                    !string.IsNullOrEmpty(orgErrors.GetError(txtName)))
                    return;

                if (_id == 0)
                {
                    if (_repository.Add(_org) > 0)
                    {
                        //_org = new Organization();
                        //orgBindingSource.DataSource = _org;
                        //yearBindingSource.DataSource = _org.Year;
                        //addressBindingSource.DataSource = _org.Address;
                        //contactBindingSource.DataSource = _org.Contact;
                        //txtCode.Focus();
                        Close();
                    }
                }
                else
                {
                    if (_repository.Update(_id, _org))
                    {
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                orgErrors.SetError(txtCode, $"Company code is required!");
                return;
            }
            else
                orgErrors.SetError(txtCode, null);

            if (_repository.Exists(KeyField.Code, txtCode.Text, _org.Id))
                orgErrors.SetError(txtCode, $"Company code '{txtCode.Text}' already exists!");
            else
                orgErrors.SetError(txtCode, null);
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                orgErrors.SetError(txtName, $"Company name is required!");
                return;
            }
            else
                orgErrors.SetError(txtName, null);

            if (_repository.Exists(KeyField.Name, txtName.Text, _org.Id))
                orgErrors.SetError(txtName, $"Company name '{txtName.Text}' already exists!");
            else
                orgErrors.SetError(txtName, null);
        }
    }
}