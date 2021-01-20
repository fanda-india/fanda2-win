using Equin.ApplicationFramework;

using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;
using Fanda2.Backend.Repositories;

using System;
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

            gridUnits.Columns[0].Width = (int)(Width * 0.1);
            gridUnits.Columns[1].Width = (int)(Width * 0.3);
            gridUnits.Columns[2].Width = (int)(Width * 0.35);
            gridUnits.Columns[3].Width = (int)(Width * 0.1);
        }

        #endregion Form events

        #region DataGridView events

        private void UnitsBindingSource_PositionChanged(object sender, EventArgs e)
        {
            tssStatus.Text = "Ready";
        }

        private void UnitsGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = gridUnits.Columns[e.ColumnIndex];
            if (column.SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            _isSortAscending = (_sortColumn == null || _isSortAscending == false);
            string direction = _isSortAscending ? "ASC" : "DESC";

            UnitsBindingSource.Sort = $"{column.DataPropertyName} {direction}";

            if (_sortColumn != null)
            {
                _sortColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            column.HeaderCell.SortGlyphDirection = _isSortAscending ? SortOrder.Ascending : SortOrder.Descending;
            _sortColumn = column;
        }

        #endregion DataGridView events

        #region Save & Cancel button events

        private void SaveButton_Click(object sender, EventArgs e)
        {
            txtCode_Validated(this, null);
            txtName_Validated(this, null);
            if (!string.IsNullOrEmpty(UnitErrors.GetError(txtCode)) ||
                !string.IsNullOrEmpty(UnitErrors.GetError(txtName)))
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
                UnitsBindingSource.EndEdit();

                tssStatus.Text = "Saved successfully!";
                grpUnits.Enabled = true;
                if (isAdding)
                    btnAdd.PerformClick();
            }
            else
            {
                tssStatus.Text = "Error: Error occured while saving.";
            }
        }

        private void RestoreFromDatabase()
        {
            Unit current = GetCurrent();
            if (current == null || current.Id == 0)
                return;
            Unit unit = _repository.GetById(current.Id);

            current.Code = unit.Code;
            current.UnitName = unit.UnitName;
            current.UnitDesc = unit.UnitDesc;
            current.IsEnabled = unit.IsEnabled;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            UnitErrors.Clear();
            RestoreFromDatabase();
            UnitsBindingSource.CancelEdit();
            UnitsBindingSource.ResetBindings(false);
            grpUnits.Enabled = true;
        }

        #endregion Save & Cancel button events

        #region Other events

        private void SearchText_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                UnitsBindingSource.RemoveFilter();
            }
            else
            {
                string searchTerm = txtSearch.Text.ToLower();
                (UnitsBindingSource.DataSource as BindingListView<Unit>).ApplyFilter(
                     u => u.Code.ToLower().Contains(searchTerm) || u.UnitName.ToLower().Contains(searchTerm) ||
                        (u.UnitDesc == null ? false : u.UnitDesc.ToLower().Contains(searchTerm))
                    );
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadAndBindList();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            UnitsBindingSource.AddNew();
            txtCode.Focus();
            grpUnits.Enabled = false;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            tssStatus.Text = "Ready";
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
                    UnitsBindingSource.RemoveCurrent();
                    tssStatus.Text = "Deleted successfully!";
                }
                else
                {
                    tssStatus.Text = "Error occured while deleting.";
                }
            }
            else
            {
                tssStatus.Text = "Cancelled!";
            }
        }

        #endregion Other events

        #region Validation events

        private void txtCode_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                UnitErrors.SetError(txtCode, $"Unit code is required!");
                return;
            }
            else
                UnitErrors.SetError(txtCode, null);

            Unit unit = GetCurrent();
            if (_repository.Exists(KeyField.Code, txtCode.Text, unit.Id, AppConfig.CurrentCompany.Id))
                UnitErrors.SetError(txtCode, $"Unit code '{txtCode.Text}' already exists!");
            else
                UnitErrors.SetError(txtCode, null);
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                UnitErrors.SetError(txtName, $"Unit name is required!");
                return;
            }
            else
                UnitErrors.SetError(txtName, null);

            Unit unit = GetCurrent();
            if (_repository.Exists(KeyField.Name, txtName.Text, unit.Id, AppConfig.CurrentCompany.Id))
                UnitErrors.SetError(txtName, $"Unit name '{txtName.Text}' already exists!");
            else
                UnitErrors.SetError(txtName, null);
        }

        #endregion Validation events

        #region Private methods

        private void LoadAndBindList()
        {
            var list = _repository.GetAll(AppConfig.CurrentCompany.Id, true);
            UnitsBindingSource.DataSource = new BindingListView<Unit>(list);
        }

        private Unit GetCurrent()
        {
            return ((ObjectView<Unit>)UnitsBindingSource.Current).Object;
        }

        #endregion Private methods
    }
}
