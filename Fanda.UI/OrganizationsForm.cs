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
    public partial class OrganizationsForm : Form
    {
        private OrganizationRepository _repository;
        private List<Organization> _list;
        private DataGridViewColumn _sortColumn;
        private bool _isSortAscending;

        public OrganizationsForm()
        {
            InitializeComponent();
            _repository = new OrganizationRepository();
        }

        private void OrganizationsForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrganizationEditForm editForm = new OrganizationEditForm(_repository, string.Empty);
            editForm.MdiParent = this.MdiParent;
            editForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var org = organizationBindingSource.Current as Organization;
            if (org != null)
            {
                OrganizationEditForm editForm = new OrganizationEditForm(_repository, org.Id);
                editForm.MdiParent = this.MdiParent;
                editForm.Show();
            }
        }

        private void dgvOrgs_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = dgvOrgs.Columns[e.ColumnIndex];
            _isSortAscending = (_sortColumn == null || _isSortAscending == false);
            string direction = _isSortAscending ? "ASC" : "DESC";

            ApplySort(column.DataPropertyName, direction);

            if (_sortColumn != null) _sortColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            column.HeaderCell.SortGlyphDirection = _isSortAscending ? SortOrder.Ascending : SortOrder.Descending;
            _sortColumn = column;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList(txtSearch.Text);
        }

        private void ApplySort(string columnName, string direction)
        {
            switch (columnName)
            {
                case "Code":
                    if (direction == "ASC")
                        organizationBindingSource.DataSource = _list.OrderBy(k => k.Code);
                    else
                        organizationBindingSource.DataSource = _list.OrderByDescending(k => k.Code);
                    break;

                case "Name":
                    if (direction == "ASC")
                        organizationBindingSource.DataSource = _list.OrderBy(k => k.Name);
                    else
                        organizationBindingSource.DataSource = _list.OrderByDescending(k => k.Name);
                    break;

                case "Description":
                    if (direction == "ASC")
                        organizationBindingSource.DataSource = _list.OrderBy(k => k.Description);
                    else
                        organizationBindingSource.DataSource = _list.OrderByDescending(k => k.Description);
                    break;
            };
            // _context.MyEntities.OrderBy(
            //string.Format("it.{0} {1}", column.DataPropertyName, direction)).ToList();
        }

        private void RefreshList(string searchTerm = null)
        {
            _list = _repository.GetAll(searchTerm);
            organizationBindingSource.DataSource = _list;
            if (_sortColumn != null)
            {
                string direction = _isSortAscending ? "ASC" : "DESC";
                ApplySort(_sortColumn.DataPropertyName, direction);
                //dgvOrgs_ColumnHeaderMouseClick(this,
                //    new DataGridViewCellMouseEventArgs(_sortColumn.Index, 0, 0, 0,
                //    new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0)));
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshList(txtSearch.Text);
        }

        private void dgvOrgs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure, you want to DELETE?",
                    "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    var org = organizationBindingSource.Current as Organization;
                    if (org != null)
                    {
                        if (_repository.Remove(org.Id))
                        {
                            RefreshList(txtSearch.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}