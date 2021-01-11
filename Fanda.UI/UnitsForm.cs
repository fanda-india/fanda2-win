using Equin.ApplicationFramework;

using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;
using Fanda2.Backend.Repositories;

using System;
using System.Linq;
using System.Windows.Forms;

namespace Fanda.UI
{
    public partial class UnitsForm : Form
    {
        private readonly UnitRepository _repository;

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
            LoadAndBindList();
        }

        private void UnitsForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                return;
            }

            dgvUnits.Columns[0].Width = (int)(Width * 0.1);
            dgvUnits.Columns[1].Width = (int)(Width * 0.3);
            dgvUnits.Columns[2].Width = (int)(Width * 0.35);
            dgvUnits.Columns[3].Width = (int)(Width * 0.1);
        }

        #endregion Form events

        #region DataGridView events

        private void unitBindingSource_PositionChanged(object sender, EventArgs e)
        {
            tssLabel.Text = "Ready";
            //(unitsBindingSource.DataSource as BindingListView<Unit>)
        }

        private void dgvUnits_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = dgvUnits.Columns[e.ColumnIndex];
            _isSortAscending = (_sortColumn == null || _isSortAscending == false);
            string direction = _isSortAscending ? "ASC" : "DESC";

            unitsBindingSource.Sort = $"{column.DataPropertyName} {direction}";

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

            bool success;
            bool isAdding = false;
            Unit unit = GetCurrent();
            if (unit.Id == 0)
            {
                isAdding = true;
                success = _repository.Add(AppConfig.CurrentCompany.Id, unit) > 0;
            }
            else
            {
                success = _repository.Update(unit.Id, unit);
            }

            if (success)
            {
                unitsBindingSource.EndEdit();

                tssLabel.Text = "Saved successfully!";
                grpUnits.Enabled = true;
                if (isAdding)
                    btnAdd.PerformClick();
            }
            else
            {
                tssLabel.Text = "Error: Error occured while saving.";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            unitErrors.Clear();
            //Unit unit = GetCurrent();
            //if (unit.Id > 0)
            //{
            //    (unitsBindingSource.DataSource as BindingListView<Unit>).Curr = _repository.GetById(unit.Id);
            //}
            ((ObjectView<Unit>)unitsBindingSource.Current).CancelEdit();
            unitsBindingSource.CancelEdit();
            unitsBindingSource.ResetBindings(false);
            grpUnits.Enabled = true;
        }

        #endregion Save & Cancel button events

        #region Other events

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                unitsBindingSource.RemoveFilter();
            }
            else
            {
                string searchTerm = txtSearch.Text.ToLower();
                (unitsBindingSource.DataSource as BindingListView<Unit>).ApplyFilter(
                     u => u.Code.ToLower().Contains(searchTerm) || u.UnitName.ToLower().Contains(searchTerm) ||
                        (u.UnitDesc == null ? false : u.UnitDesc.ToLower().Contains(searchTerm))
                    );
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAndBindList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            unitsBindingSource.AddNew();
            txtCode.Focus();
            grpUnits.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            tssLabel.Text = "Ready";
            Unit unit = GetCurrent();
            if (unit == null)
                return;

            DialogResult result = MessageBox.Show($"Are you sure, you want to delete unit '{unit.Code}'?", "Delete",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                bool success = _repository.Remove(unit.Id);
                if (success)
                {
                    unitsBindingSource.RemoveCurrent();
                    tssLabel.Text = "Deleted successfully!";
                }
                else
                {
                    tssLabel.Text = "Error occured while deleting.";
                }
            }
            else
            {
                tssLabel.Text = "Cancelled!";
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

            Unit unit = GetCurrent();
            if (_repository.Exists(KeyField.Code, txtCode.Text, unit.Id, AppConfig.CurrentCompany.Id))
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

            Unit unit = GetCurrent();
            if (_repository.Exists(KeyField.Name, txtName.Text, unit.Id, AppConfig.CurrentCompany.Id))
                unitErrors.SetError(txtName, $"Unit name '{txtName.Text}' already exists!");
            else
                unitErrors.SetError(txtName, null);
        }

        #endregion Validation events

        #region Private methods

        private void LoadAndBindList()
        {
            var list = _repository.GetAll(AppConfig.CurrentCompany.Id, true);
            unitsBindingSource.DataSource = new BindingListView<Unit>(list);
        }

        private Unit GetCurrent()
        {
            return ((ObjectView<Unit>)unitsBindingSource.Current).Object;
        }

        //private void SetCurrent(Unit unit)
        //{
        //    ((ObjectView<Unit>)unitsBindingSource.Current).CancelEdit();
        //}

        #endregion Private methods
    }
}