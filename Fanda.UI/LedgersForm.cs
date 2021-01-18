using Equin.ApplicationFramework;

using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;
using Fanda2.Backend.Repositories;
using Fanda2.Backend.ViewModels;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fanda.UI
{
    public partial class LedgersForm : Form
    {
        private readonly LedgerRepository _repository;

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
            LoadBalanceSigns();
            LoadAndBindList();
            UpdateLedgerBalances();
        }

        private void ProductCategoriesForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                return;
            }

            dgvProductCategories.Columns[0].Width = (int)(Width * 0.1);
            dgvProductCategories.Columns[1].Width = (int)(Width * 0.2);
            dgvProductCategories.Columns[2].Width = (int)(Width * 0.23);
            dgvProductCategories.Columns[3].Width = (int)(Width * 0.2);
            dgvProductCategories.Columns[4].Width = (int)(Width * 0.1);
        }

        private void LedgersForm_KeyDown(object sender, KeyEventArgs e)
        {
            //Control nextControl;
            ////Checks if the Enter Key was Pressed
            //if (e.KeyCode == Keys.Enter)
            //{
            //    //If so, it gets the next control and applies the focus to it
            //    nextControl = GetNextControl(ActiveControl, !e.Shift);
            //    if (nextControl == null)
            //    {
            //        nextControl = GetNextControl(null, true);
            //    }
            //    nextControl.Focus();
            //    //Finally - it suppresses the Enter Key
            //    e.SuppressKeyPress = true;
            //}
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        #endregion Form events

        #region DataGridView events

        private void LedgersBindingSource_PositionChanged(object sender, EventArgs e)
        {
            LedgerListModel model = GetCurrent();
            //if (model.Balance != null)
            //    balanceBindingSource.DataSource = model.Balance;
            //else
            //    balanceBindingSource.DataSource = typeof(LedgerBalance);
            if (model.IsSystem)
            {
                //grpEdit.Enabled = false;
                DisableEdit(true);
            }
            else
            {
                //grpEdit.Enabled = true;
                DisableEdit(false);
            }
            tssLabel.Text = "Ready";
        }

        private void DgvProductCategories_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = dgvProductCategories.Columns[e.ColumnIndex];
            if (column.SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            _isSortAscending = (_sortColumn == null || _isSortAscending == false);
            string direction = _isSortAscending ? "ASC" : "DESC";

            ledgersBindingSource.Sort = $"{column.DataPropertyName} {direction}";

            if (_sortColumn != null)
            {
                _sortColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            column.HeaderCell.SortGlyphDirection = _isSortAscending ? SortOrder.Ascending : SortOrder.Descending;
            _sortColumn = column;
        }

        #endregion DataGridView events

        #region Save & Cancel button events

        private void BtnSave_Click(object sender, EventArgs e)
        {
            TxtCode_Validated(this, null);
            TxtName_Validated(this, null);
            if (!string.IsNullOrEmpty(itemErrors.GetError(txtCode)) ||
                !string.IsNullOrEmpty(itemErrors.GetError(txtName)))
                return;

            bool success;
            bool isAdding = false;
            Ledger item = GetCurrent().ToLedger(AppConfig.CurrentYear.Id);
            if (item.Id == 0)
            {
                isAdding = true;
                success = _repository.Add(AppConfig.CurrentCompany.Id, item) > 0;
                // RestoreFromDatabase();
            }
            else
            {
                success = _repository.Update(item.Id, item);
            }

            if (success)
            {
                LedgerListModel current = GetCurrent();
                current.Id = item.Id;
                current.GroupName = cboGroup.Text;

                ledgersBindingSource.EndEdit();
                ledgersBindingSource.ResetBindings(false);
                tssLabel.Text = "Saved successfully!";
                grpLedgers.Enabled = true;
                UpdateLedgerBalances();
                if (isAdding)
                    btnAdd.PerformClick();
            }
            else
            {
                tssLabel.Text = "Error: Error occured while saving.";
            }
        }

        private void RestoreFromDatabase()
        {
            LedgerListModel current = GetCurrent();
            if (current == null || current.Id == 0)
                return;
            Ledger item = _repository.GetById(current.Id);

            current.Code = item.Code;
            current.LedgerName = item.LedgerName;
            current.LedgerDesc = item.LedgerDesc;
            current.LedgerGroupId = item.LedgerGroupId;
            current.IsEnabled = item.IsEnabled;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            itemErrors.Clear();
            RestoreFromDatabase();
            ledgersBindingSource.CancelEdit();
            ledgersBindingSource.ResetBindings(false);
            grpLedgers.Enabled = true;
        }

        #endregion Save & Cancel button events

        #region Other events

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                ledgersBindingSource.RemoveFilter();
            }
            else
            {
                string searchTerm = txtSearch.Text.ToLower();
                (ledgersBindingSource.DataSource as BindingListView<LedgerListModel>).ApplyFilter(
                     u => u.Code.ToLower().Contains(searchTerm) || u.LedgerName.ToLower().Contains(searchTerm) ||
                        (u.LedgerDesc == null ? false : u.LedgerDesc.ToLower().Contains(searchTerm))
                    );
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadAndBindList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            grpLedgers.Enabled = false;
            ledgersBindingSource.AddNew();
            txtCode.Focus();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            tssLabel.Text = "Ready";
            LedgerListModel item = GetCurrent();
            if (item == null)
                return;

            DialogResult result = MessageBox.Show($"Are you sure, you want to delete ledger '{item.Code}'?", "Delete",
            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                bool success = _repository.Remove(item.Id, AppConfig.CurrentYear.Id);
                if (success)
                {
                    ledgersBindingSource.RemoveCurrent();
                    tssLabel.Text = "Deleted successfully!";
                    UpdateLedgerBalances();
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

        private void TxtCode_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                itemErrors.SetError(txtCode, $"Ledger code is required!");
                return;
            }
            else
                itemErrors.SetError(txtCode, null);

            LedgerListModel current = GetCurrent();
            if (_repository.Exists(KeyField.Code, txtCode.Text, current.Id, AppConfig.CurrentCompany.Id))
                itemErrors.SetError(txtCode, $"Ledger code '{txtCode.Text}' already exists!");
            else
                itemErrors.SetError(txtCode, null);
        }

        private void TxtName_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                itemErrors.SetError(txtName, $"Ledger name is required!");
                return;
            }
            else
                itemErrors.SetError(txtName, null);

            LedgerListModel current = GetCurrent();
            if (_repository.Exists(KeyField.Name, txtName.Text, current.Id, AppConfig.CurrentCompany.Id))
                itemErrors.SetError(txtName, $"Ledger name '{txtName.Text}' already exists!");
            else
                itemErrors.SetError(txtName, null);
        }

        #endregion Validation events

        #region Private methods

        private void LoadAndBindList()
        {
            var list = _repository.GetAll(AppConfig.CurrentCompany.Id, AppConfig.CurrentYear.Id, true);
            ledgersBindingSource.DataSource = new BindingListView<LedgerListModel>(list);
        }

        private LedgerListModel GetCurrent()
        {
            return ((ObjectView<LedgerListModel>)ledgersBindingSource.Current).Object;
        }

        private void LoadGroupList()
        {
            var groupRepo = new LedgerGroupRepository();
            var groupList = groupRepo.GetAll();
            groupBindingSource.DataSource = groupList;
        }

        private void DisableEdit(bool disable = true)
        {
            txtCode.Enabled = !disable;
            txtName.Enabled = !disable;
            txtDescription.Enabled = !disable;
            cboGroup.Enabled = !disable;
            chkEnabled.Enabled = !disable;
        }

        private void LoadBalanceSigns()
        {
            var signList = new[]
            {
                new { Key ="", DisplayText = ""},
                new { Key ="D", DisplayText = "Debit"},
                new { Key ="C", DisplayText = "Credit"}
            };
            cboBalance.DataSource = signList;
            cboBalance.DisplayMember = "DisplayText";
            cboBalance.ValueMember = "Key";
            // cboBalance.DataBindings.Add("SelectedValue",)
        }

        private void UpdateLedgerBalances()
        {
            var balances = _repository.GetLedgerBalances(AppConfig.CurrentYear.Id);
            tssDebitBalance.Text = $"Total Debit: {balances.DebitBalance:##,##,##,##0.00}";
            tssCreditBalance.Text = $"Total Credit: {balances.CreditBalance:##,##,##,##0.00}";
            tssDiff.Text = $"Diff: {balances.Difference:##,##,##,##0.00}";
            if (balances.Difference != 0)
            {
                tssDiff.BackColor = Color.Red;
                tssDiff.ForeColor = Color.White;
            }
            else
            {
                tssDiff.BackColor = SystemColors.Control;
                tssDiff.ForeColor = SystemColors.ControlText;
            }
        }

        #endregion Private methods
    }
}