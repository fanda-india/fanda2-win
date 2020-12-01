using Fanda2.Backend.Database;
using Fanda2.Backend.Repositories;

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
    public partial class LedgersForm : Form
    {
        private LedgerRepository _repository;
        private List<Ledger> _list;

        public LedgersForm()
        {
            InitializeComponent();
            _repository = new LedgerRepository();
        }

        private void LedgersForm_Load(object sender, EventArgs e)
        {
            var list = _repository.GetAll();
        }
    }
}
