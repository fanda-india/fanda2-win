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

        private void EditCompanyForm_Load(object sender, EventArgs e)
        {
            //dtpDateFrom.DataBindings.Add(new Binding("Value", this.orgBindingSource, "Year.YearBegin", true));
            //dtpDateTo.DataBindings.Add(new Binding("Value", this.orgBindingSource, "Year.YearEnd", true));
        }

        public void Edit(int id)
        {
            _id = id;

            if (_id == 0)
            {
                _org = new Organization();
                _repository.UpdateYear(_org, 0);
            }
            else
            {
                _org = _repository.GetById(_id);
                _repository.UpdateYear(_org, 0);
            }

            orgBindingSource.DataSource = _org;
            yearBindingSource.DataSource = _org.Year;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_id == 0)
                {
                    if (_repository.Create(_org) > 0)
                    {
                        _org = new Organization();
                        orgBindingSource.DataSource = _org;
                        txtCode.Focus();
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
