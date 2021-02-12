
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
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.buttonUser = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.titleChildForm = new System.Windows.Forms.Label();
            this.iconChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panelCompany = new System.Windows.Forms.Panel();
            this.buttonCompany = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.buttonHome = new System.Windows.Forms.PictureBox();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.logoDesktop = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconChildForm)).BeginInit();
            this.panelCompany.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonHome)).BeginInit();
            this.panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoDesktop)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.panelMenu.Controls.Add(this.buttonSettings);
            this.panelMenu.Controls.Add(this.buttonJournals);
            this.panelMenu.Controls.Add(this.buttonPayments);
            this.panelMenu.Controls.Add(this.buttonReceipts);
            this.panelMenu.Controls.Add(this.buttonPurchase);
            this.panelMenu.Controls.Add(this.buttonSales);
            this.panelMenu.Controls.Add(this.buttonDashboard);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 481);
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
            this.buttonSettings.Location = new System.Drawing.Point(0, 240);
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
            this.buttonJournals.Location = new System.Drawing.Point(0, 200);
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
            this.buttonPayments.Location = new System.Drawing.Point(0, 160);
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
            this.buttonReceipts.Location = new System.Drawing.Point(0, 120);
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
            this.buttonPurchase.Location = new System.Drawing.Point(0, 80);
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
            this.buttonSales.Location = new System.Drawing.Point(0, 40);
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
            this.buttonDashboard.Location = new System.Drawing.Point(0, 0);
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
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.Indigo;
            this.panelTitleBar.Controls.Add(this.buttonUser);
            this.panelTitleBar.Controls.Add(this.panel1);
            this.panelTitleBar.Controls.Add(this.panelRight);
            this.panelTitleBar.Controls.Add(this.panelCompany);
            this.panelTitleBar.Controls.Add(this.panelLogo);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(884, 70);
            this.panelTitleBar.TabIndex = 1;
            // 
            // buttonUser
            // 
            this.buttonUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUser.BackColor = System.Drawing.Color.Indigo;
            this.buttonUser.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonUser.FlatAppearance.BorderSize = 0;
            this.buttonUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUser.ForeColor = System.Drawing.Color.LavenderBlush;
            this.buttonUser.IconChar = FontAwesome.Sharp.IconChar.User;
            this.buttonUser.IconColor = System.Drawing.Color.LavenderBlush;
            this.buttonUser.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonUser.IconSize = 24;
            this.buttonUser.Location = new System.Drawing.Point(848, 21);
            this.buttonUser.Name = "buttonUser";
            this.buttonUser.Size = new System.Drawing.Size(32, 32);
            this.buttonUser.TabIndex = 4;
            this.buttonUser.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BlueViolet;
            this.panel1.Location = new System.Drawing.Point(688, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 70);
            this.panel1.TabIndex = 6;
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.Controls.Add(this.titleChildForm);
            this.panelRight.Controls.Add(this.iconChildForm);
            this.panelRight.Location = new System.Drawing.Point(692, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(150, 70);
            this.panelRight.TabIndex = 5;
            // 
            // titleChildForm
            // 
            this.titleChildForm.AutoSize = true;
            this.titleChildForm.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleChildForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.titleChildForm.Location = new System.Drawing.Point(41, 19);
            this.titleChildForm.Name = "titleChildForm";
            this.titleChildForm.Size = new System.Drawing.Size(71, 30);
            this.titleChildForm.TabIndex = 2;
            this.titleChildForm.Text = "Home";
            // 
            // iconChildForm
            // 
            this.iconChildForm.BackColor = System.Drawing.Color.Indigo;
            this.iconChildForm.ForeColor = System.Drawing.Color.LavenderBlush;
            this.iconChildForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconChildForm.IconColor = System.Drawing.Color.LavenderBlush;
            this.iconChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconChildForm.IconSize = 40;
            this.iconChildForm.Location = new System.Drawing.Point(3, 17);
            this.iconChildForm.Name = "iconChildForm";
            this.iconChildForm.Size = new System.Drawing.Size(40, 40);
            this.iconChildForm.TabIndex = 0;
            this.iconChildForm.TabStop = false;
            // 
            // panelCompany
            // 
            this.panelCompany.Controls.Add(this.buttonCompany);
            this.panelCompany.Location = new System.Drawing.Point(220, 3);
            this.panelCompany.Name = "panelCompany";
            this.panelCompany.Size = new System.Drawing.Size(462, 64);
            this.panelCompany.TabIndex = 4;
            // 
            // buttonCompany
            // 
            this.buttonCompany.BackColor = System.Drawing.Color.Indigo;
            this.buttonCompany.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.buttonCompany.FlatAppearance.BorderSize = 0;
            this.buttonCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompany.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCompany.ForeColor = System.Drawing.Color.LavenderBlush;
            this.buttonCompany.IconChar = FontAwesome.Sharp.IconChar.University;
            this.buttonCompany.IconColor = System.Drawing.Color.LavenderBlush;
            this.buttonCompany.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buttonCompany.IconSize = 40;
            this.buttonCompany.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCompany.Location = new System.Drawing.Point(6, 9);
            this.buttonCompany.Name = "buttonCompany";
            this.buttonCompany.Size = new System.Drawing.Size(453, 46);
            this.buttonCompany.TabIndex = 4;
            this.buttonCompany.Text = "Sri Santhalakshmi Silks and Sarees";
            this.buttonCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCompany.UseVisualStyleBackColor = false;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.buttonHome);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 70);
            this.panelLogo.TabIndex = 3;
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.Transparent;
            this.buttonHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHome.Image = global::Fanda.UI.Properties.Resources.FandaLogo1;
            this.buttonHome.Location = new System.Drawing.Point(0, 0);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(220, 70);
            this.buttonHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonHome.TabIndex = 0;
            this.buttonHome.TabStop = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.BlueViolet;
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(0, 70);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(884, 10);
            this.panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.Snow;
            this.panelDesktop.Controls.Add(this.panelBorder);
            this.panelDesktop.Controls.Add(this.panelMenu);
            this.panelDesktop.Controls.Add(this.logoDesktop);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.ForeColor = System.Drawing.Color.Indigo;
            this.panelDesktop.Location = new System.Drawing.Point(0, 80);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(884, 481);
            this.panelDesktop.TabIndex = 3;
            // 
            // panelBorder
            // 
            this.panelBorder.BackColor = System.Drawing.Color.Indigo;
            this.panelBorder.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBorder.Location = new System.Drawing.Point(220, 0);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(1, 481);
            this.panelBorder.TabIndex = 2;
            // 
            // logoDesktop
            // 
            this.logoDesktop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logoDesktop.BackColor = System.Drawing.Color.Transparent;
            this.logoDesktop.Image = global::Fanda.UI.Properties.Resources.FandaLogo1;
            this.logoDesktop.Location = new System.Drawing.Point(385, 175);
            this.logoDesktop.Name = "logoDesktop";
            this.logoDesktop.Size = new System.Drawing.Size(354, 106);
            this.logoDesktop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoDesktop.TabIndex = 1;
            this.logoDesktop.TabStop = false;
            // 
            // ModernMainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "ModernMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fanda v2.0";
            this.Load += new System.EventHandler(this.ModernMainForm_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconChildForm)).EndInit();
            this.panelCompany.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonHome)).EndInit();
            this.panelDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoDesktop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton buttonDashboard;
        private FontAwesome.Sharp.IconButton buttonJournals;
        private FontAwesome.Sharp.IconButton buttonPayments;
        private FontAwesome.Sharp.IconButton buttonReceipts;
        private FontAwesome.Sharp.IconButton buttonPurchase;
        private FontAwesome.Sharp.IconButton buttonSales;
        private FontAwesome.Sharp.IconButton buttonSettings;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconChildForm;
        private System.Windows.Forms.Label titleChildForm;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.PictureBox logoDesktop;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox buttonHome;
        private FontAwesome.Sharp.IconButton buttonUser;
        private FontAwesome.Sharp.IconButton buttonCompany;
        private System.Windows.Forms.Panel panelCompany;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelBorder;
    }
}