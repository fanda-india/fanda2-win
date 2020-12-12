using Fanda2.Backend.Database;
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
                if (_id == 0)
                {
                    if (_repository.Create(_org) > 0)
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
    }
}
