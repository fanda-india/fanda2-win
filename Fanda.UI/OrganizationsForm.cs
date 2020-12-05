using Fanda2.Backend.Repositories;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Fanda.UI
{
    public partial class OrganizationsForm : Form
    {
        private readonly OrganizationRepository _repository;
        private List<OrganizationListModel> _list;
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
            OrganizationEditForm editForm = new OrganizationEditForm(_repository, 0)
            {
                MdiParent = this.MdiParent
            };
            editForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (organizationListModelBindingSource.Current is OrganizationListModel listModel)
            {
                OrganizationEditForm editForm = new OrganizationEditForm(_repository, listModel.Id)
                {
                    MdiParent = this.MdiParent
                };
                editForm.Show();
            }
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
                    if (organizationListModelBindingSource.Current is OrganizationListModel listModel)
                    {
                        if (_repository.Remove(listModel.Id))
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshList(txtSearch.Text);
        }

        private void dgvOrgs_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = dgvOrgs.Columns[e.ColumnIndex];
            if (column.SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            _isSortAscending = (_sortColumn == null || _isSortAscending == false);
            string direction = _isSortAscending ? "ASC" : "DESC";

            ApplySort(column.DataPropertyName, direction);

            if (_sortColumn != null) _sortColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            column.HeaderCell.SortGlyphDirection = _isSortAscending ? SortOrder.Ascending : SortOrder.Descending;
            _sortColumn = column;
        }

        #region private

        private void ApplySort(string columnName, string direction)
        {
            switch (columnName)
            {
                case "Code":
                    if (direction == "ASC")
                        organizationListModelBindingSource.DataSource = _list.OrderBy(k => k.Code);
                    else
                        organizationListModelBindingSource.DataSource = _list.OrderByDescending(k => k.Code);
                    break;

                case "Name":
                    if (direction == "ASC")
                        organizationListModelBindingSource.DataSource = _list.OrderBy(k => k.OrgName);
                    else
                        organizationListModelBindingSource.DataSource = _list.OrderByDescending(k => k.OrgName);
                    break;

                case "Description":
                    if (direction == "ASC")
                        organizationListModelBindingSource.DataSource = _list.OrderBy(k => k.OrgDesc);
                    else
                        organizationListModelBindingSource.DataSource = _list.OrderByDescending(k => k.OrgDesc);
                    break;
            };
            // _context.MyEntities.OrderBy(
            //string.Format("it.{0} {1}", column.DataPropertyName, direction)).ToList();
        }

        private void RefreshList(string searchTerm = null)
        {
            _list = _repository.GetAll(searchTerm);
            organizationListModelBindingSource.DataSource = _list;
            if (_sortColumn != null)
            {
                string direction = _isSortAscending ? "ASC" : "DESC";
                ApplySort(_sortColumn.DataPropertyName, direction);
                //dgvOrgs_ColumnHeaderMouseClick(this,
                //    new DataGridViewCellMouseEventArgs(_sortColumn.Index, 0, 0, 0,
                //    new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0)));
            }
        }

        #endregion private
    }
}