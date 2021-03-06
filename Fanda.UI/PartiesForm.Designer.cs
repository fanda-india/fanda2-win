﻿
namespace Fanda.UI
{
    partial class PartiesForm
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
            this.components = new System.ComponentModel.Container();
            this.grpEdit = new System.Windows.Forms.GroupBox();
            this.cboBalance = new System.Windows.Forms.ComboBox();
            this.ledgersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.cboGroup = new System.Windows.Forms.ComboBox();
            this.groupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.itemStatus = new System.Windows.Forms.StatusStrip();
            this.tssLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpLedgers = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvProductCategories = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledgerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ledgerDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isEnabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.itemErrors = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).BeginInit();
            this.itemStatus.SuspendLayout();
            this.grpLedgers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // grpEdit
            // 
            this.grpEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEdit.Controls.Add(this.cboBalance);
            this.grpEdit.Controls.Add(this.btnSave);
            this.grpEdit.Controls.Add(this.cboGroup);
            this.grpEdit.Controls.Add(this.txtBalance);
            this.grpEdit.Controls.Add(this.btnCancel);
            this.grpEdit.Controls.Add(this.label6);
            this.grpEdit.Controls.Add(this.label5);
            this.grpEdit.Controls.Add(this.chkEnabled);
            this.grpEdit.Controls.Add(this.txtDescription);
            this.grpEdit.Controls.Add(this.txtName);
            this.grpEdit.Controls.Add(this.label3);
            this.grpEdit.Controls.Add(this.txtCode);
            this.grpEdit.Controls.Add(this.label2);
            this.grpEdit.Controls.Add(this.label1);
            this.grpEdit.Location = new System.Drawing.Point(12, 12);
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.Size = new System.Drawing.Size(748, 196);
            this.grpEdit.TabIndex = 0;
            this.grpEdit.TabStop = false;
            this.grpEdit.Text = "Party Details";
            // 
            // cboBalance
            // 
            this.cboBalance.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ledgersBindingSource, "BalanceSign", true));
            this.cboBalance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBalance.FormattingEnabled = true;
            this.cboBalance.Location = new System.Drawing.Point(271, 162);
            this.cboBalance.Name = "cboBalance";
            this.cboBalance.Size = new System.Drawing.Size(98, 23);
            this.cboBalance.TabIndex = 10;
            // 
            // ledgersBindingSource
            // 
            this.ledgersBindingSource.DataSource = typeof(Fanda2.Backend.ViewModels.LedgerListModel);
            this.ledgersBindingSource.PositionChanged += new System.EventHandler(this.LedgersBindingSource_PositionChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(562, 162);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // cboGroup
            // 
            this.cboGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboGroup.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ledgersBindingSource, "LedgerGroupId", true));
            this.cboGroup.DataSource = this.groupBindingSource;
            this.cboGroup.DisplayMember = "GroupName";
            this.cboGroup.FormattingEnabled = true;
            this.cboGroup.Location = new System.Drawing.Point(113, 133);
            this.cboGroup.Name = "cboGroup";
            this.cboGroup.Size = new System.Drawing.Size(629, 23);
            this.cboGroup.TabIndex = 7;
            this.cboGroup.ValueMember = "Id";
            // 
            // groupBindingSource
            // 
            this.groupBindingSource.DataSource = typeof(Fanda2.Backend.ViewModels.LedgerGroupListModel);
            // 
            // txtBalance
            // 
            this.txtBalance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBalance.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ledgersBindingSource, "OpeningBalance", true));
            this.txtBalance.Location = new System.Drawing.Point(113, 162);
            this.txtBalance.MaxLength = 16;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(152, 23);
            this.txtBalance.TabIndex = 9;
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBalance.Validated += new System.EventHandler(this.TxtCode_Validated);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(655, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Opening &Balance:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "&Type:";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.ledgersBindingSource, "IsEnabled", true));
            this.chkEnabled.Location = new System.Drawing.Point(375, 164);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(73, 19);
            this.chkEnabled.TabIndex = 11;
            this.chkEnabled.Text = "Enabled?";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ledgersBindingSource, "LedgerDesc", true));
            this.txtDescription.Location = new System.Drawing.Point(113, 81);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(629, 46);
            this.txtDescription.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ledgersBindingSource, "LedgerName", true));
            this.txtName.Location = new System.Drawing.Point(113, 52);
            this.txtName.MaxLength = 25;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(629, 23);
            this.txtName.TabIndex = 3;
            this.txtName.Validated += new System.EventHandler(this.TxtName_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Description:";
            // 
            // txtCode
            // 
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ledgersBindingSource, "Code", true));
            this.txtCode.Location = new System.Drawing.Point(113, 23);
            this.txtCode.MaxLength = 16;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(152, 23);
            this.txtCode.TabIndex = 1;
            this.txtCode.Validated += new System.EventHandler(this.TxtCode_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Code:";
            // 
            // itemStatus
            // 
            this.itemStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemStatus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.itemStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLabel});
            this.itemStatus.Location = new System.Drawing.Point(0, 519);
            this.itemStatus.Name = "itemStatus";
            this.itemStatus.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.itemStatus.Size = new System.Drawing.Size(772, 22);
            this.itemStatus.TabIndex = 2;
            this.itemStatus.Text = "Ready";
            // 
            // tssLabel
            // 
            this.tssLabel.Name = "tssLabel";
            this.tssLabel.Size = new System.Drawing.Size(755, 17);
            this.tssLabel.Spring = true;
            this.tssLabel.Text = "Ready";
            this.tssLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpLedgers
            // 
            this.grpLedgers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLedgers.Controls.Add(this.label4);
            this.grpLedgers.Controls.Add(this.btnDelete);
            this.grpLedgers.Controls.Add(this.btnAdd);
            this.grpLedgers.Controls.Add(this.txtSearch);
            this.grpLedgers.Controls.Add(this.btnRefresh);
            this.grpLedgers.Controls.Add(this.dgvProductCategories);
            this.grpLedgers.Location = new System.Drawing.Point(12, 214);
            this.grpLedgers.Name = "grpLedgers";
            this.grpLedgers.Size = new System.Drawing.Size(748, 298);
            this.grpLedgers.TabIndex = 1;
            this.grpLedgers.TabStop = false;
            this.grpLedgers.Text = "Parties";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "&Search:";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(654, 22);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 27);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(559, 22);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 27);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(160, 24);
            this.txtSearch.MaxLength = 255;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(392, 23);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(7, 22);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(87, 27);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // dgvProductCategories
            // 
            this.dgvProductCategories.AllowUserToAddRows = false;
            this.dgvProductCategories.AllowUserToDeleteRows = false;
            this.dgvProductCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductCategories.AutoGenerateColumns = false;
            this.dgvProductCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.ledgerNameDataGridViewTextBoxColumn,
            this.ledgerDescDataGridViewTextBoxColumn,
            this.groupNameDataGridViewTextBoxColumn,
            this.isEnabledDataGridViewCheckBoxColumn});
            this.dgvProductCategories.DataSource = this.ledgersBindingSource;
            this.dgvProductCategories.Location = new System.Drawing.Point(7, 55);
            this.dgvProductCategories.Name = "dgvProductCategories";
            this.dgvProductCategories.ReadOnly = true;
            this.dgvProductCategories.RowHeadersWidth = 28;
            this.dgvProductCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductCategories.Size = new System.Drawing.Size(734, 236);
            this.dgvProductCategories.TabIndex = 5;
            this.dgvProductCategories.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvProductCategories_ColumnHeaderMouseClick);
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ledgerNameDataGridViewTextBoxColumn
            // 
            this.ledgerNameDataGridViewTextBoxColumn.DataPropertyName = "LedgerName";
            this.ledgerNameDataGridViewTextBoxColumn.HeaderText = "LedgerName";
            this.ledgerNameDataGridViewTextBoxColumn.Name = "ledgerNameDataGridViewTextBoxColumn";
            this.ledgerNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledgerNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // ledgerDescDataGridViewTextBoxColumn
            // 
            this.ledgerDescDataGridViewTextBoxColumn.DataPropertyName = "LedgerDesc";
            this.ledgerDescDataGridViewTextBoxColumn.HeaderText = "LedgerDesc";
            this.ledgerDescDataGridViewTextBoxColumn.Name = "ledgerDescDataGridViewTextBoxColumn";
            this.ledgerDescDataGridViewTextBoxColumn.ReadOnly = true;
            this.ledgerDescDataGridViewTextBoxColumn.Width = 200;
            // 
            // groupNameDataGridViewTextBoxColumn
            // 
            this.groupNameDataGridViewTextBoxColumn.DataPropertyName = "GroupName";
            this.groupNameDataGridViewTextBoxColumn.HeaderText = "GroupName";
            this.groupNameDataGridViewTextBoxColumn.Name = "groupNameDataGridViewTextBoxColumn";
            this.groupNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.groupNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // isEnabledDataGridViewCheckBoxColumn
            // 
            this.isEnabledDataGridViewCheckBoxColumn.DataPropertyName = "IsEnabled";
            this.isEnabledDataGridViewCheckBoxColumn.HeaderText = "IsEnabled";
            this.isEnabledDataGridViewCheckBoxColumn.Name = "isEnabledDataGridViewCheckBoxColumn";
            this.isEnabledDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // itemErrors
            // 
            this.itemErrors.ContainerControl = this;
            // 
            // PartiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 541);
            this.Controls.Add(this.grpLedgers);
            this.Controls.Add(this.itemStatus);
            this.Controls.Add(this.grpEdit);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "PartiesForm";
            this.Text = "Parties";
            this.Load += new System.EventHandler(this.ProductCategoriesForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LedgersForm_KeyDown);
            this.Resize += new System.EventHandler(this.ProductCategoriesForm_Resize);
            this.grpEdit.ResumeLayout(false);
            this.grpEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledgersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).EndInit();
            this.itemStatus.ResumeLayout(false);
            this.itemStatus.PerformLayout();
            this.grpLedgers.ResumeLayout(false);
            this.grpLedgers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemErrors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEdit;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource ledgersBindingSource;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.StatusStrip itemStatus;
        private System.Windows.Forms.ToolStripStatusLabel tssLabel;
        private System.Windows.Forms.GroupBox grpLedgers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvProductCategories;
        private System.Windows.Forms.ErrorProvider itemErrors;
        private System.Windows.Forms.ComboBox cboGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource groupBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ledgerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ledgerDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isEnabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.ComboBox cboBalance;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label6;
    }
}