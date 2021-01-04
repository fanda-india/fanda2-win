﻿using Fanda2.Backend.Database;
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
            RefreshList(txtSearch.Text);
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
            txtCode_Validated(this, null);
            txtName_Validated(this, null);
            if (!string.IsNullOrEmpty(unitErrors.GetError(txtCode)) ||
                !string.IsNullOrEmpty(unitErrors.GetError(txtName)))
                return;

            int newUnitId = 0;
            bool success;
            if (_unit.Id == 0)
            {
                newUnitId = _repository.Add(AppConfig.CurrentCompany.Id, _unit);
                success = newUnitId != 0;
            }
            else
            {
                success = _repository.Update(_unit.Id, _unit);
            }

            if (success)
            {
                RefreshList(txtSearch.Text);

                if (newUnitId > 0)
                {
                    var item = (unitListBindingSource.DataSource as List<UnitListModel>).Find(u => u.Id == newUnitId);
                    int index = unitListBindingSource.IndexOf(item);
                    //int index = unitListBindingSource.Find("Id", newUnitId);
                    unitListBindingSource.Position = index;
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
            //unitErrors.SetError(txtCode, null);
            //unitErrors.SetError(txtName, null);
            unitErrors.Clear();
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
                unitErrors.SetError(txtCode, $"Unit code is required!");
                return;
            }
            else
                unitErrors.SetError(txtCode, null);

            if (_repository.Exists(KeyField.Code, txtCode.Text, _unit.Id, AppConfig.CurrentCompany.Id))
                unitErrors.SetError(txtCode, $"Unit code '{txtCode.Text}' already exists!");
            else
                unitErrors.SetError(txtCode, null);
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                unitErrors.SetError(txtName, $"Unit name is required!");
                return;
            }
            else
                unitErrors.SetError(txtName, null);

            if (_repository.Exists(KeyField.Name, txtName.Text, _unit.Id, AppConfig.CurrentCompany.Id))
                unitErrors.SetError(txtName, $"Unit name '{txtName.Text}' already exists!");
            else
                unitErrors.SetError(txtName, null);
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

        private void RefreshList(string searchTerm)
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