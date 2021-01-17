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

            UnitsGridView.Columns[0].Width = (int)(Width * 0.1);
            UnitsGridView.Columns[1].Width = (int)(Width * 0.3);
            UnitsGridView.Columns[2].Width = (int)(Width * 0.35);
            UnitsGridView.Columns[3].Width = (int)(Width * 0.1);
        }

        #endregion Form events

        #region DataGridView events

        private void UnitsBindingSource_PositionChanged(object sender, EventArgs e)
        {
            StatusLabel.Text = "Ready";
        }

        private void UnitsGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = UnitsGridView.Columns[e.ColumnIndex];
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
            CodeText_Validated(this, null);
            NameText_Validated(this, null);
            if (!string.IsNullOrEmpty(UnitErrors.GetError(CodeText)) ||
                !string.IsNullOrEmpty(UnitErrors.GetError(NameText)))
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

                StatusLabel.Text = "Saved successfully!";
                UnitsGroupBox.Enabled = true;
                if (isAdding)
                    AddButton.PerformClick();
            }
            else
            {
                StatusLabel.Text = "Error: Error occured while saving.";
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
            UnitsGroupBox.Enabled = true;
        }

        #endregion Save & Cancel button events

        #region Other events

        private void SearchText_TextChanged(object sender, EventArgs e)
        {
            if (SearchText.Text == string.Empty)
            {
                UnitsBindingSource.RemoveFilter();
            }
            else
            {
                string searchTerm = SearchText.Text.ToLower();
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
            CodeText.Focus();
            UnitsGroupBox.Enabled = false;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = "Ready";
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
                    StatusLabel.Text = "Deleted successfully!";
                }
                else
                {
                    StatusLabel.Text = "Error occured while deleting.";
                }
            }
            else
            {
                StatusLabel.Text = "Cancelled!";
            }
        }

        #endregion Other events

        #region Validation events

        private void CodeText_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CodeText.Text))
            {
                UnitErrors.SetError(CodeText, $"Unit code is required!");
                return;
            }
            else
                UnitErrors.SetError(CodeText, null);

            Unit unit = GetCurrent();
            if (_repository.Exists(KeyField.Code, CodeText.Text, unit.Id, AppConfig.CurrentCompany.Id))
                UnitErrors.SetError(CodeText, $"Unit code '{CodeText.Text}' already exists!");
            else
                UnitErrors.SetError(CodeText, null);
        }

        private void NameText_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameText.Text))
            {
                UnitErrors.SetError(NameText, $"Unit name is required!");
                return;
            }
            else
                UnitErrors.SetError(NameText, null);

            Unit unit = GetCurrent();
            if (_repository.Exists(KeyField.Name, NameText.Text, unit.Id, AppConfig.CurrentCompany.Id))
                UnitErrors.SetError(NameText, $"Unit name '{NameText.Text}' already exists!");
            else
                UnitErrors.SetError(NameText, null);
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