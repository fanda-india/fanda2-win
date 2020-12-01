using Fanda2.Backend.Database;
using Fanda2.Backend.Repositories;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fanda.UI
{
    public partial class OrganizationEditForm : Form
    {
        private OrganizationRepository _repository;
        private string _id;
        private Organization _org;

        public OrganizationEditForm(OrganizationRepository repository,
            string id)
        {
            InitializeComponent();

            _repository = repository;
            _id = id;

            if (!string.IsNullOrEmpty(id))
            {
                _org = _repository.GetById(id);
            }
            else
            {
                _org = new Organization();
            }
            orgBindingSource.DataSource = _org;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_id))
                {
                    if (_repository.Create(_org))
                    {
                        _org = new Organization();
                        orgBindingSource.DataSource = _org;
                        txtCode.Focus();
                    }
                }
                else
                {
                    _repository.Update(_id, _org);
                    Close();
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
