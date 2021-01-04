using Fanda2.Backend.Repositories;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Fanda.UI
{
    public partial class OpenCompanyForm : Form
    {
        private readonly OrganizationRepository _repository;
        private List<OrganizationListModel> _list;
        private DataGridViewColumn _sortColumn;
        private bool _isSortAscending;

        private EditCompanyForm editCompanyForm;

        public OpenCompanyForm()
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
            editCompanyForm = FormHelpers.ShowForm(ref editCompanyForm, this.MdiParent);
            editCompanyForm.FormClosed += EditCompanyForm_FormClosed;
            editCompanyForm.Edit(0);
        }

        private void EditCompanyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshList();
        }

        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    if (organizationListModelBindingSource.Current is OrganizationListModel org)
        //    {
        //        OrganizationEditForm editForm = new OrganizationEditForm(_repository, org.Id)
        //        {
        //            MdiParent = this.MdiParent
        //        };
        //        editForm.Show();
        //    }
        //}

        private void dgvOrgs_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = dgvOrgs.Columns[e.ColumnIndex];
            _isSortAscending = (_sortColumn == null || _isSortAscending == false);
            string direction = _isSortAscending ? "ASC" : "DESC";

            ApplySort(column.DataPropertyName, direction);

            if (_sortColumn != null)
            {
                _sortColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            column.HeaderCell.SortGlyphDirection = _isSortAscending ? SortOrder.Ascending : SortOrder.Descending;
            _sortColumn = column;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshList(txtSearch.Text);
        }

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (MessageBox.Show("Are you sure, you want to DELETE?",
        //            "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,
        //            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        //        {
        //            if (organizationListModelBindingSource.Current is OrganizationListModel org)
        //            {
        //                if (_repository.Remove(org.Id))
        //                {
        //                    RefreshList(txtSearch.Text);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (orgListBindingSource.Current is OrganizationListModel org)
            {
                AppConfig.CurrentCompany = _repository.GetById(org.Id);
                Close();
            }
        }

        private void OpenCompanyForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                return;
            }

            dgvOrgs.Columns[0].Width = (int)(Width * 0.1);
            dgvOrgs.Columns[1].Width = (int)(Width * 0.3);
            dgvOrgs.Columns[2].Width = (int)(Width * 0.42);
            dgvOrgs.Columns[3].Width = (int)(Width * 0.1);
        }

        private void dgvOrgs_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOpen.PerformClick();
        }

        private void dgvOrgs_DoubleClick(object sender, EventArgs e)
        {
            btnOpen.PerformClick();
        }

        private void dgvOrgs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOpen.PerformClick();
        }

        private void dgvOrgs_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOpen.PerformClick();
            }
        }

        #region Private methods

        private void ApplySort(string columnName, string direction)
        {
            switch (columnName)
            {
                case "Code":
                    if (direction == "ASC")
                    {
                        orgListBindingSource.DataSource = _list.OrderBy(k => k.Code);
                    }
                    else
                    {
                        orgListBindingSource.DataSource = _list.OrderByDescending(k => k.Code);
                    }

                    break;

                case "Name":
                    if (direction == "ASC")
                    {
                        orgListBindingSource.DataSource = _list.OrderBy(k => k.OrgName);
                    }
                    else
                    {
                        orgListBindingSource.DataSource = _list.OrderByDescending(k => k.OrgName);
                    }

                    break;

                case "Description":
                    if (direction == "ASC")
                    {
                        orgListBindingSource.DataSource = _list.OrderBy(k => k.OrgDesc);
                    }
                    else
                    {
                        orgListBindingSource.DataSource = _list.OrderByDescending(k => k.OrgDesc);
                    }

                    break;
            };
            // _context.MyEntities.OrderBy(
            //string.Format("it.{0} {1}", column.DataPropertyName, direction)).ToList();
        }

        private void RefreshList(string searchTerm = null)
        {
            _list = _repository.GetAll(false, searchTerm);
            orgListBindingSource.DataSource = _list;
            if (_sortColumn != null)
            {
                string direction = _isSortAscending ? "ASC" : "DESC";
                ApplySort(_sortColumn.DataPropertyName, direction);
                //dgvOrgs_ColumnHeaderMouseClick(this,
                //    new DataGridViewCellMouseEventArgs(_sortColumn.Index, 0, 0, 0,
                //    new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0)));
            }
        }

        private void SelectCurrentCompany()
        {
            if (AppConfig.CurrentCompany == null)
            {
                return;
            }

            dgvOrgs.ClearSelection();
            foreach (DataGridViewRow row in dgvOrgs.Rows)
            {
                if (row.Cells[0].Value as string == AppConfig.CurrentCompany.Code)
                {
                    row.Selected = true;
                    dgvOrgs.CurrentCell = row.Cells[0];
                }
            }
        }

        #endregion Private methods

        private void OpenCompanyForm_Shown(object sender, EventArgs e)
        {
            txtSearch.Focus();
            SelectCurrentCompany();
            if (_list.Count == 0)
            {
                btnAdd.PerformClick();
            }
            else if (_list.Count == 1)
            {
                btnOpen.PerformClick();
            }
        }
    }
}
