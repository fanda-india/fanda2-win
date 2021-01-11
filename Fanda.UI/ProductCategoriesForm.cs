using Equin.ApplicationFramework;

using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;
using Fanda2.Backend.Repositories;

using System;
using System.Windows.Forms;

namespace Fanda.UI
{
    public partial class ProductCategoriesForm : Form
    {
        private readonly ProductCategoryRepository _repository;

        private DataGridViewColumn _sortColumn;
        private bool _isSortAscending;

        public ProductCategoriesForm()
        {
            InitializeComponent();
            _repository = new ProductCategoryRepository();
        }

        #region Form events

        private void ProductCategoriesForm_Load(object sender, EventArgs e)
        {
            LoadAndBindList();
        }

        private void ProductCategoriesForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                return;
            }

            dgvCategories.Columns[0].Width = (int)(Width * 0.1);
            dgvCategories.Columns[1].Width = (int)(Width * 0.3);
            dgvCategories.Columns[2].Width = (int)(Width * 0.35);
            dgvCategories.Columns[3].Width = (int)(Width * 0.1);
        }

        #endregion Form events

        #region DataGridView events

        private void categoriesBindingSource_PositionChanged(object sender, EventArgs e)
        {
            tssLabel.Text = "Ready";
        }

        private void dgvCategories_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = dgvCategories.Columns[e.ColumnIndex];
            _isSortAscending = (_sortColumn == null || _isSortAscending == false);
            string direction = _isSortAscending ? "ASC" : "DESC";

            categoriesBindingSource.Sort = $"{column.DataPropertyName} {direction}";

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
            if (!string.IsNullOrEmpty(categoryErrors.GetError(txtCode)) ||
                !string.IsNullOrEmpty(categoryErrors.GetError(txtName)))
                return;

            bool success;
            bool isAdding = false;
            ProductCategory category = GetCurrent();
            if (category.Id == 0)
            {
                isAdding = true;
                success = _repository.Add(AppConfig.CurrentCompany.Id, category) > 0;
            }
            else
            {
                success = _repository.Update(category.Id, category);
            }

            if (success)
            {
                categoriesBindingSource.EndEdit();

                tssLabel.Text = "Saved successfully!";
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
            categoryErrors.Clear();
            categoriesBindingSource.CancelEdit();
            categoriesBindingSource.ResetBindings(false);
        }

        #endregion Save & Cancel button events

        #region Other events

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                categoriesBindingSource.RemoveFilter();
            }
            else
            {
                string searchTerm = txtSearch.Text.ToLower();
                (categoriesBindingSource.DataSource as BindingListView<ProductCategory>).ApplyFilter(
                     u => u.Code.ToLower().Contains(searchTerm) || u.CategoryName.ToLower().Contains(searchTerm) ||
                        (u.CategoryDesc == null ? false : u.CategoryDesc.ToLower().Contains(searchTerm))
                    );
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAndBindList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            categoriesBindingSource.AddNew();
            txtCode.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            tssLabel.Text = "Ready";
            ProductCategory category = GetCurrent();
            if (category == null)
                return;

            DialogResult result = MessageBox.Show($"Are you sure, you want to delete category '{category.Code}'?", "Delete",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                bool success = _repository.Remove(category.Id);
                if (success)
                {
                    categoriesBindingSource.RemoveCurrent();
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
                categoryErrors.SetError(txtCode, $"Category code is required!");
                return;
            }
            else
                categoryErrors.SetError(txtCode, null);

            ProductCategory category = GetCurrent();
            if (_repository.Exists(KeyField.Code, txtCode.Text, category.Id, AppConfig.CurrentCompany.Id))
                categoryErrors.SetError(txtCode, $"Category code '{txtCode.Text}' already exists!");
            else
                categoryErrors.SetError(txtCode, null);
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                categoryErrors.SetError(txtName, $"Category name is required!");
                return;
            }
            else
                categoryErrors.SetError(txtName, null);

            ProductCategory category = GetCurrent();
            if (_repository.Exists(KeyField.Name, txtName.Text, category.Id, AppConfig.CurrentCompany.Id))
                categoryErrors.SetError(txtName, $"Category name '{txtName.Text}' already exists!");
            else
                categoryErrors.SetError(txtName, null);
        }

        #endregion Validation events

        #region Private methods

        private void LoadAndBindList()
        {
            var list = _repository.GetAll(AppConfig.CurrentCompany.Id, true);
            categoriesBindingSource.DataSource = new BindingListView<ProductCategory>(list);
        }

        private ProductCategory GetCurrent()
        {
            return ((ObjectView<ProductCategory>)categoriesBindingSource.Current).Object;
        }

        #endregion Private methods
    }
}