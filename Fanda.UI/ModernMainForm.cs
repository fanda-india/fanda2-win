using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FontAwesome.Sharp;

namespace Fanda.UI
{
    public partial class ModernMainForm : Form
    {
        private IconButton currentButton;
        private Panel leftBorderButton;
        private Form currentChildForm;

        public ModernMainForm()
        {
            InitializeComponent();

            leftBorderButton = new Panel { Size = new Size(7, 40) };
            panelMenu.Controls.Add(leftBorderButton);
        }

        private bool ActivateButton(object senderButton, Color color)
        {
            if (senderButton != null && !senderButton.Equals(currentButton))
            {
                DisableButton();

                currentButton = (IconButton)senderButton;
                currentButton.BackColor = color;
                currentButton.ForeColor = Color.FromArgb(247, 245, 251);
                currentButton.IconColor = Color.DeepPink;//Color.FromArgb(247, 245, 251);

                // Left border
                leftBorderButton.BackColor = Color.DeepPink;
                leftBorderButton.Location = new Point(0, currentButton.Location.Y);
                leftBorderButton.Visible = true;
                leftBorderButton.BringToFront();

                // Icon current child form
                iconChildForm.IconChar = currentButton.IconChar;
                titleChildForm.Text = currentButton.Text;
                return true;
            }
            return false;
        }

        private void DisableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(247, 245, 251);
                currentButton.ForeColor = Color.Indigo;
                currentButton.IconColor = Color.Indigo;
            }
        }

        private void ResetActivateButton()
        {
            DisableButton();
            leftBorderButton.Visible = false;
            iconChildForm.IconChar = IconChar.Home;
            titleChildForm.Text = "Home";

            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
                currentChildForm = null;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                currentChildForm.Dispose();
                currentChildForm = null;
            }
            if (currentChildForm != null && currentChildForm.Equals(childForm))
                return;

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //titleChildForm.Text = childForm.Text;
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            if (ActivateButton(sender, Color.Indigo))
                OpenChildForm(new EditCompanyForm());
        }

        private void buttonSales_Click(object sender, EventArgs e)
        {
            if (ActivateButton(sender, Color.Indigo))
                OpenChildForm(new OpenCompanyForm());
        }

        private void buttonPurchase_Click(object sender, EventArgs e)
        {
            if (ActivateButton(sender, Color.Indigo))
                OpenChildForm(new EditCompanyForm());
        }

        private void buttonReceipts_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Indigo);
        }

        private void buttonPayments_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Indigo);
        }

        private void buttonJournals_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Indigo);
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Indigo);
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            ResetActivateButton();
        }
    }
}