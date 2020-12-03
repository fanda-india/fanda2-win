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
        private readonly OrganizationRepository _repository;
        private readonly int _id;
        private Organization _org;

        public OrganizationEditForm(OrganizationRepository repository,
            int id)
        {
            InitializeComponent();

            _repository = repository;
            _id = id;

            if (id == 0)
            {
                _org = new Organization();
            }
            else
            {
                _org = _repository.GetById(id);
            }
            orgBindingSource.DataSource = _org;
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