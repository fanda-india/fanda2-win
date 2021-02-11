
namespace Fanda.UI
{
    partial class ModernMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonSettings = new FontAwesome.Sharp.IconButton();
            this.buttonJournals = new FontAwesome.Sharp.IconButton();
            this.buttonPayments = new FontAwesome.Sharp.IconButton();
            this.buttonReceipts = new FontAwesome.Sharp.IconButton();
            this.buttonPurchase = new FontAwesome.Sharp.IconButton();
            this.buttonSales = new FontAwesome.Sharp.IconButton();
            this.buttonDashboard = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.buttonHome = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.iconChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.titleChildForm = new System.Windows.Forms.Label();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonHome)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconChildForm)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.panelMenu.Controls.Add(this.buttonSettings);
            this.panelMenu.Controls.Add(this.buttonJournals);
            this.panelMenu.Controls.Add(this.buttonPayments);
            this.panelMenu.Controls.Add(this.buttonReceipts);
            this.panelMenu.Controls.Add(this.buttonPurchase);
            this.panelMenu.Controls.Add(this.buttonSales);
            this.panelMenu.Controls.Add(this.buttonDashboard);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 450);
            this.panelMenu.TabIndex = 0;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.ForeColor = System.Drawing.Color.Indigo;
            this.buttonSettings.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.buttonSettings.IconColor = System.Drawing.Color.Indigo;
            this.buttonSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonSettings.IconSize = 32;
            this.buttonSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.Location = new System.Drawing.Point(0, 340);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.buttonSettings.Size = new System.Drawing.Size(220, 40);
            this.buttonSettings.TabIndex = 7;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonJournals
            // 
            this.buttonJournals.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonJournals.FlatAppearance.BorderSize = 0;
            this.buttonJournals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonJournals.ForeColor = System.Drawing.Color.Indigo;
            this.buttonJournals.IconChar = FontAwesome.Sharp.IconChar.JournalWhills;
            this.buttonJournals.IconColor = System.Drawing.Color.Indigo;
            this.buttonJournals.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonJournals.IconSize = 32;
            this.buttonJournals.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonJournals.Location = new System.Drawing.Point(0, 300);
            this.buttonJournals.Name = "buttonJournals";
            this.buttonJournals.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.buttonJournals.Size = new System.Drawing.Size(220, 40);
            this.buttonJournals.TabIndex = 6;
            this.buttonJournals.Text = "Journals";
            this.buttonJournals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonJournals.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonJournals.UseVisualStyleBackColor = true;
            this.buttonJournals.Click += new System.EventHandler(this.buttonJournals_Click);
            // 
            // buttonPayments
            // 
            this.buttonPayments.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPayments.FlatAppearance.BorderSize = 0;
            this.buttonPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPayments.ForeColor = System.Drawing.Color.Indigo;
            this.buttonPayments.IconChar = FontAwesome.Sharp.IconChar.MoneyBill;
            this.buttonPayments.IconColor = System.Drawing.Color.Indigo;
            this.buttonPayments.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonPayments.IconSize = 32;
            this.buttonPayments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPayments.Location = new System.Drawing.Point(0, 260);
            this.buttonPayments.Name = "buttonPayments";
            this.buttonPayments.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.buttonPayments.Size = new System.Drawing.Size(220, 40);
            this.buttonPayments.TabIndex = 5;
            this.buttonPayments.Text = "Payments";
            this.buttonPayments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPayments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPayments.UseVisualStyleBackColor = true;
            this.buttonPayments.Click += new System.EventHandler(this.buttonPayments_Click);
            // 
            // buttonReceipts
            // 
            this.buttonReceipts.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonReceipts.FlatAppearance.BorderSize = 0;
            this.buttonReceipts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReceipts.ForeColor = System.Drawing.Color.Indigo;
            this.buttonReceipts.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.buttonReceipts.IconColor = System.Drawing.Color.Indigo;
            this.buttonReceipts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonReceipts.IconSize = 32;
            this.buttonReceipts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReceipts.Location = new System.Drawing.Point(0, 220);
            this.buttonReceipts.Name = "buttonReceipts";
            this.buttonReceipts.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.buttonReceipts.Size = new System.Drawing.Size(220, 40);
            this.buttonReceipts.TabIndex = 4;
            this.buttonReceipts.Text = "Receipts";
            this.buttonReceipts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonReceipts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonReceipts.UseVisualStyleBackColor = true;
            this.buttonReceipts.Click += new System.EventHandler(this.buttonReceipts_Click);
            // 
            // buttonPurchase
            // 
            this.buttonPurchase.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPurchase.FlatAppearance.BorderSize = 0;
            this.buttonPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPurchase.ForeColor = System.Drawing.Color.Indigo;
            this.buttonPurchase.IconChar = FontAwesome.Sharp.IconChar.Truck;
            this.buttonPurchase.IconColor = System.Drawing.Color.Indigo;
            this.buttonPurchase.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonPurchase.IconSize = 32;
            this.buttonPurchase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPurchase.Location = new System.Drawing.Point(0, 180);
            this.buttonPurchase.Name = "buttonPurchase";
            this.buttonPurchase.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.buttonPurchase.Size = new System.Drawing.Size(220, 40);
            this.buttonPurchase.TabIndex = 3;
            this.buttonPurchase.Text = "Purchase";
            this.buttonPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPurchase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPurchase.UseVisualStyleBackColor = true;
            this.buttonPurchase.Click += new System.EventHandler(this.buttonPurchase_Click);
            // 
            // buttonSales
            // 
            this.buttonSales.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSales.FlatAppearance.BorderSize = 0;
            this.buttonSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSales.ForeColor = System.Drawing.Color.Indigo;
            this.buttonSales.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.buttonSales.IconColor = System.Drawing.Color.Indigo;
            this.buttonSales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonSales.IconSize = 32;
            this.buttonSales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSales.Location = new System.Drawing.Point(0, 140);
            this.buttonSales.Name = "buttonSales";
            this.buttonSales.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.buttonSales.Size = new System.Drawing.Size(220, 40);
            this.buttonSales.TabIndex = 2;
            this.buttonSales.Text = "Sales";
            this.buttonSales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSales.UseVisualStyleBackColor = true;
            this.buttonSales.Click += new System.EventHandler(this.buttonSales_Click);
            // 
            // buttonDashboard
            // 
            this.buttonDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDashboard.FlatAppearance.BorderSize = 0;
            this.buttonDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDashboard.ForeColor = System.Drawing.Color.Indigo;
            this.buttonDashboard.IconChar = FontAwesome.Sharp.IconChar.TachometerAlt;
            this.buttonDashboard.IconColor = System.Drawing.Color.Indigo;
            this.buttonDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonDashboard.IconSize = 32;
            this.buttonDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDashboard.Location = new System.Drawing.Point(0, 100);
            this.buttonDashboard.Name = "buttonDashboard";
            this.buttonDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.buttonDashboard.Size = new System.Drawing.Size(220, 40);
            this.buttonDashboard.TabIndex = 1;
            this.buttonDashboard.Text = "Dashboard";
            this.buttonDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDashboard.UseVisualStyleBackColor = true;
            this.buttonDashboard.Click += new System.EventHandler(this.buttonDashboard_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.buttonHome);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.Transparent;
            this.buttonHome.Image = global::Fanda.UI.Properties.Resources.FandaLogo1;
            this.buttonHome.Location = new System.Drawing.Point(12, 12);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(194, 82);
            this.buttonHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonHome.TabIndex = 0;
            this.buttonHome.TabStop = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.Indigo;
            this.panelTitleBar.Controls.Add(this.titleChildForm);
            this.panelTitleBar.Controls.Add(this.iconChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(580, 50);
            this.panelTitleBar.TabIndex = 1;
            // 
            // iconChildForm
            // 
            this.iconChildForm.BackColor = System.Drawing.Color.Transparent;
            this.iconChildForm.ForeColor = System.Drawing.Color.DeepPink;
            this.iconChildForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconChildForm.IconColor = System.Drawing.Color.DeepPink;
            this.iconChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconChildForm.Location = new System.Drawing.Point(11, 11);
            this.iconChildForm.Name = "iconChildForm";
            this.iconChildForm.Size = new System.Drawing.Size(32, 32);
            this.iconChildForm.TabIndex = 0;
            this.iconChildForm.TabStop = false;
            // 
            // titleChildForm
            // 
            this.titleChildForm.AutoSize = true;
            this.titleChildForm.ForeColor = System.Drawing.Color.DeepPink;
            this.titleChildForm.Location = new System.Drawing.Point(43, 14);
            this.titleChildForm.Name = "titleChildForm";
            this.titleChildForm.Size = new System.Drawing.Size(52, 21);
            this.titleChildForm.TabIndex = 2;
            this.titleChildForm.Text = "Home";
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.BlueViolet;
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(220, 50);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(580, 7);
            this.panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.Snow;
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 57);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(580, 393);
            this.panelDesktop.TabIndex = 3;
            // 
            // ModernMainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ModernMainForm";
            this.Text = "ModernMainForm";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonHome)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconChildForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton buttonDashboard;
        private FontAwesome.Sharp.IconButton buttonJournals;
        private FontAwesome.Sharp.IconButton buttonPayments;
        private FontAwesome.Sharp.IconButton buttonReceipts;
        private FontAwesome.Sharp.IconButton buttonPurchase;
        private FontAwesome.Sharp.IconButton buttonSales;
        private FontAwesome.Sharp.IconButton buttonSettings;
        private System.Windows.Forms.PictureBox buttonHome;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconChildForm;
        private System.Windows.Forms.Label titleChildForm;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelDesktop;
    }
}