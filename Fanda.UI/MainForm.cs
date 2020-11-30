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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OrganizationsForm();
            form.MdiParent = this;
            form.Show();
        }

        private void mnuMasterLedgers_Click(object sender, EventArgs e)
        {
            var form = new LedgersForm();
            form.MdiParent = this;
            form.Show();
        }
    }
}
