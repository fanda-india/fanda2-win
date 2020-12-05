using Fanda2.Backend.Repositories;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fanda.UI
{
    public partial class LedgersForm : Form
    {
        private readonly LedgerRepository _repository;
        private List<LedgerListModel> _list;

        public LedgersForm()
        {
            InitializeComponent();
            _repository = new LedgerRepository();
        }

        private void LedgersForm_Load(object sender, EventArgs e)
        {
            _list = _repository.GetAll(1);
            //var ledger = _repository.GetById();
        }
    }
}
