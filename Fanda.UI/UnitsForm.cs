using Fanda2.Backend.Database;
using Fanda2.Backend.Repositories;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Fanda.UI
{
    public partial class UnitsForm : Form
    {
        private readonly UnitRepository _repository;
        private List<UnitListModel> _list;
        private Unit _unit;
        private DataGridViewColumn _sortColumn;
        private bool _isSortAscending;

        public UnitsForm()
        {
            InitializeComponent();
            _repository = new UnitRepository();
        }

        #region Form events

        private void UnitsForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void UnitsForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                return;
            }

            dgvUnits.Columns[0].Width = (int)(Width * 0.1);
            dgvUnits.Columns[1].Width = (int)(Width * 0.3);
            dgvUnits.Columns[2].Width = (int)(Width * 0.3);
            dgvUnits.Columns[3].Width = (int)(Width * 0.1);
        }

        #endregion Form events

        #region DataGridView events

        private void dgvUnits_SelectionChanged(object sender, EventArgs e)
        {
            if (unitListBindingSource.Current is UnitListModel unit)
            {
                _unit = _repository.GetById(unit.Id);
                unitBindingSource.DataSource = _unit;
                tssLabel.Text = "Ready";
            }
        }

        private void dgvUnits_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = dgvUnits.Columns[e.ColumnIndex];
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
            bool success;
            if (_unit.Id == 0)
            {
                success = _repository.Create(AppConfig.CurrentCompany.Id, _unit) != 0;
            }
            else
            {
                success = _repository.Update(_unit.Id, _unit);
            }

            if (success)
            {
                RefreshList();
                tssLabel.Text = "Saved successfully!";
            }
            else
            {
                tssLabel.Text = "Error: Error occured while saving.";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvUnits_SelectionChanged(this, new EventArgs());
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
            _unit = new Unit();
            unitBindingSource.DataSource = _unit;
            txtCode.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UnitListModel unit = unitListBindingSource.Current as UnitListModel;
            if (unit == null)
                return;

            DialogResult result = MessageBox.Show($"Are you sure, you want to delete unit '{unit.Code}'?", "Delete",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                bool success = _repository.Remove(unit.Id);
                if (success)
                {
                    RefreshList();
                    tssLabel.Text = "Ready";
                }
                else
                {
                    tssLabel.Text = "Error occured while deleting.";
                }
            }
        }

        #endregion Other events

        #region Private methods

        private void ApplySort(string columnName, string direction)
        {
            switch (columnName)
            {
                case "Code":
                    if (direction == "ASC")
                    {
                        unitListBindingSource.DataSource = _list.OrderBy(k => k.Code);
                    }
                    else
                    {
                        unitListBindingSource.DataSource = _list.OrderByDescending(k => k.Code);
                    }

                    break;

                case "Name":
                    if (direction == "ASC")
                    {
                        unitListBindingSource.DataSource = _list.OrderBy(k => k.UnitName);
                    }
                    else
                    {
                        unitListBindingSource.DataSource = _list.OrderByDescending(k => k.UnitName);
                    }

                    break;

                case "Description":
                    if (direction == "ASC")
                    {
                        unitListBindingSource.DataSource = _list.OrderBy(k => k.UnitDesc);
                    }
                    else
                    {
                        unitListBindingSource.DataSource = _list.OrderByDescending(k => k.UnitDesc);
                    }

                    break;
            };
            // _context.MyEntities.OrderBy(
            //string.Format("it.{0} {1}", column.DataPropertyName, direction)).ToList();
        }

        private void RefreshList(string searchTerm = null)
        {
            _list = _repository.GetAll(AppConfig.CurrentCompany.Id, true, searchTerm);
            unitListBindingSource.DataSource = _list;
            if (_sortColumn != null)
            {
                string direction = _isSortAscending ? "ASC" : "DESC";
                ApplySort(_sortColumn.DataPropertyName, direction);
            }
        }

        #endregion Private methods
    }
}
