using System;
using System.Windows.Forms;

namespace Fanda.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mnuMaster.Enabled = false;
            mnuTransations.Enabled = false;
            mnuGeneralReports.Enabled = false;
            mnuInventoryReports.Enabled = false;
            mnuAnnualReports.Enabled = false;

            mnuFileEditCompany.Enabled = false;
            mnuFileCloseCompany.Enabled = false;
            mnuFileCarryForward.Enabled = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OpenCompanyForm();
            form.MdiParent = this;
            form.Show();
        }

        private void mnuMasterLedgers_Click(object sender, EventArgs e)
        {
            var form = new LedgersForm();
            form.MdiParent = this;
            form.Show();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}