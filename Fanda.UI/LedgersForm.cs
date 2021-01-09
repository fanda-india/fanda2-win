using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;
using Fanda2.Backend.Repositories;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Fanda.UI
{
    public partial class LedgersForm : Form
    {
        private readonly LedgerRepository _repository;
        private List<LedgerListModel> _list;
        private Ledger _editItem;
        private DataGridViewColumn _sortColumn;
        private bool _isSortAscending;

        public LedgersForm()
        {
            InitializeComponent();
            _repository = new LedgerRepository();
        }

        #region Form events

        private void ProductCategoriesForm_Load(object sender, EventArgs e)
        {
            LoadGroupList();
            RefreshList(txtSearch.Text);
        }

        private void ProductCategoriesForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                return;
            }

            dgvProductCategories.Columns[0].Width = (int)(Width * 0.1);
            dgvProductCategories.Columns[1].Width = (int)(Width * 0.3);
            dgvProductCategories.Columns[2].Width = (int)(Width * 0.3);
            dgvProductCategories.Columns[3].Width = (int)(Width * 0.1);
        }

        #endregion Form events

        #region DataGridView events

        private void dgvProductCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (ledgerListBindingSource.Current is LedgerListModel currentItem)
            {
                _editItem = _repository.GetById(currentItem.Id);
                ledgerBindingSource.DataSource = _editItem;
                tssLabel.Text = "Ready";
            }
        }

        private void dgvProductCategories_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = dgvProductCategories.Columns[e.ColumnIndex];
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

        #endregion DataGridView events

        #region Save & Cancel button events

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtCode_Validated(this, null);
            txtName_Validated(this, null);
            if (!string.IsNullOrEmpty(itemErrors.GetError(txtCode)) ||
                !string.IsNullOrEmpty(itemErrors.GetError(txtName)))
                return;

            int newItemId = 0;
            bool success;
            if (_editItem.Id == 0)
            {
                newItemId = _repository.Add(AppConfig.CurrentCompany.Id, _editItem);
                success = newItemId != 0;
            }
            else
            {
                success = _repository.Update(_editItem.Id, _editItem);
            }

            if (success)
            {
                RefreshList(txtSearch.Text);

                if (newItemId > 0)
                {
                    var item = (ledgerListBindingSource.DataSource as List<LedgerListModel>).Find(u => u.Id == newItemId);
                    int index = ledgerListBindingSource.IndexOf(item);
                    ledgerListBindingSource.Position = index;
                }
                tssLabel.Text = "Saved successfully!";
            }
            else
            {
                tssLabel.Text = "Error: Error occured while saving.";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            itemErrors.Clear();
            dgvProductCategories_SelectionChanged(this, new EventArgs());
        }

        #endregion Save & Cancel button events

        #region Other events

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshList(txtSearch.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _editItem = new Ledger();
            ledgerBindingSource.DataSource = _editItem;
            txtCode.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!(ledgerListBindingSource.Current is LedgerListModel currentItem))
                return;

            DialogResult result = MessageBox.Show($"Are you sure, you want to delete ledger '{currentItem.Code}'?", "Delete",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                bool success = _repository.Remove(currentItem.Id);
                if (success)
                {
                    RefreshList(txtSearch.Text);
                    tssLabel.Text = "Ready";
                }
                else
                {
                    tssLabel.Text = "Error occured while deleting.";
                }
            }
        }

        #endregion Other events

        #region Validation events

        private void txtCode_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                itemErrors.SetError(txtCode, $"Ledger code is required!");
                return;
            }
            else
                itemErrors.SetError(txtCode, null);

            if (_repository.Exists(KeyField.Code, txtCode.Text, _editItem.Id, AppConfig.CurrentCompany.Id))
                itemErrors.SetError(txtCode, $"Ledger code '{txtCode.Text}' already exists!");
            else
                itemErrors.SetError(txtCode, null);
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                itemErrors.SetError(txtName, $"Ledger name is required!");
                return;
            }
            else
                itemErrors.SetError(txtName, null);

            if (_repository.Exists(KeyField.Name, txtName.Text, _editItem.Id, AppConfig.CurrentCompany.Id))
                itemErrors.SetError(txtName, $"Ledger name '{txtName.Text}' already exists!");
            else
                itemErrors.SetError(txtName, null);
        }

        #endregion Validation events

        #region Private methods

        private void ApplySort(string columnName, string direction)
        {
            switch (columnName)
            {
                case "Code":
                    if (direction == "ASC")
                    {
                        ledgerListBindingSource.DataSource = _list.OrderBy(k => k.Code);
                    }
                    else
                    {
                        ledgerListBindingSource.DataSource = _list.OrderByDescending(k => k.Code);
                    }

                    break;

                case "Name":
                    if (direction == "ASC")
                    {
                        ledgerListBindingSource.DataSource = _list.OrderBy(k => k.LedgerName);
                    }
                    else
                    {
                        ledgerListBindingSource.DataSource = _list.OrderByDescending(k => k.LedgerName);
                    }

                    break;

                case "Description":
                    if (direction == "ASC")
                    {
                        ledgerListBindingSource.DataSource = _list.OrderBy(k => k.LedgerDesc);
                    }
                    else
                    {
                        ledgerListBindingSource.DataSource = _list.OrderByDescending(k => k.LedgerDesc);
                    }

                    break;
            };
            // _context.MyEntities.OrderBy(
            //string.Format("it.{0} {1}", column.DataPropertyName, direction)).ToList();
        }

        private void RefreshList(string searchTerm)
        {
            _list = _repository.GetAll(AppConfig.CurrentCompany.Id, true, searchTerm);
            ledgerListBindingSource.DataSource = _list;
            if (_sortColumn != null)
            {
                string direction = _isSortAscending ? "ASC" : "DESC";
                ApplySort(_sortColumn.DataPropertyName, direction);
            }
        }

        private void LoadGroupList()
        {
            var groupRepo = new LedgerGroupRepository();
            var groupList = groupRepo.GetAll();
            groupBindingSource.DataSource = groupList;
        }

        #endregion Private methods

        private void LedgersForm_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
