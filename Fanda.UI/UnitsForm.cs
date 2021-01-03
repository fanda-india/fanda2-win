using Fanda2.Backend.Repositories;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fanda.UI
{
    public partial class UnitsForm : Form
    {
        private readonly UnitRepository _repository;
        private List<UnitListModel> _list;
        private DataGridViewColumn _sortColumn;
        private bool _isSortAscending;

        public UnitsForm()
        {
            InitializeComponent();
            _repository = new UnitRepository();
        }

        private void UnitsForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void dgvUnits_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = dgvUnits.Columns[e.ColumnIndex];
            _isSortAscending = (_sortColumn == null || _isSortAscending == false);
            string direction = _isSortAscending ? "ASC" : "DESC";

            ApplySort(column.DataPropertyName, direction);

            if (_sortColumn != null) _sortColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
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

        private void UnitsForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                return;

            dgvUnits.Columns[0].Width = (int)(Width * 0.1);
            dgvUnits.Columns[1].Width = (int)(Width * 0.3);
            dgvUnits.Columns[2].Width = (int)(Width * 0.42);
            dgvUnits.Columns[3].Width = (int)(Width * 0.1);
        }

        #region Private methods

        private void ApplySort(string columnName, string direction)
        {
            switch (columnName)
            {
                case "Code":
                    if (direction == "ASC")
                        unitListBindingSource.DataSource = _list.OrderBy(k => k.Code);
                    else
                        unitListBindingSource.DataSource = _list.OrderByDescending(k => k.Code);
                    break;

                case "Name":
                    if (direction == "ASC")
                        unitListBindingSource.DataSource = _list.OrderBy(k => k.UnitName);
                    else
                        unitListBindingSource.DataSource = _list.OrderByDescending(k => k.UnitName);
                    break;

                case "Description":
                    if (direction == "ASC")
                        unitListBindingSource.DataSource = _list.OrderBy(k => k.UnitDesc);
                    else
                        unitListBindingSource.DataSource = _list.OrderByDescending(k => k.UnitDesc);
                    break;
            };
            // _context.MyEntities.OrderBy(
            //string.Format("it.{0} {1}", column.DataPropertyName, direction)).ToList();
        }

        private void RefreshList(string searchTerm = null)
        {
            _list = _repository.GetAll(AppConfig.CurrentCompany.Id, false, searchTerm);
            unitListBindingSource.DataSource = _list;
            if (_sortColumn != null)
            {
                string direction = _isSortAscending ? "ASC" : "DESC";
                ApplySort(_sortColumn.DataPropertyName, direction);
                //dgvOrgs_ColumnHeaderMouseClick(this,
                //    new DataGridViewCellMouseEventArgs(_sortColumn.Index, 0, 0, 0,
                //    new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0)));
            }
        }

        #endregion Private methods
    }
}