
namespace Fanda.UI
{
    partial class UnitsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.dgvUnits = new System.Windows.Forms.DataGridView();
            this.unitListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.unitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isEnabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.chkEnabled);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unit Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Code:";
            // 
            // txtCode
            // 
            this.txtCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.unitBindingSource, "Code", true));
            this.txtCode.Location = new System.Drawing.Point(75, 19);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(106, 20);
            this.txtCode.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.unitBindingSource, "UnitName", true));
            this.txtName.Location = new System.Drawing.Point(75, 45);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(457, 20);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "&Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "&Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.unitBindingSource, "UnitDesc", true));
            this.txtDescription.Location = new System.Drawing.Point(75, 71);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(457, 54);
            this.txtDescription.TabIndex = 2;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.unitBindingSource, "IsEnabled", true));
            this.chkEnabled.Location = new System.Drawing.Point(75, 131);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(71, 17);
            this.chkEnabled.TabIndex = 3;
            this.chkEnabled.Text = "Enabled?";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // dgvUnits
            // 
            this.dgvUnits.AllowUserToAddRows = false;
            this.dgvUnits.AllowUserToDeleteRows = false;
            this.dgvUnits.AutoGenerateColumns = false;
            this.dgvUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.unitNameDataGridViewTextBoxColumn,
            this.unitDescDataGridViewTextBoxColumn,
            this.isEnabledDataGridViewCheckBoxColumn});
            this.dgvUnits.DataSource = this.unitListBindingSource;
            this.dgvUnits.Location = new System.Drawing.Point(12, 212);
            this.dgvUnits.Name = "dgvUnits";
            this.dgvUnits.ReadOnly = true;
            this.dgvUnits.Size = new System.Drawing.Size(538, 158);
            this.dgvUnits.TabIndex = 1;
            // 
            // unitListBindingSource
            // 
            this.unitListBindingSource.DataSource = typeof(Fanda2.Backend.ViewModels.UnitListModel);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(376, 131);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(457, 131);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 183);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(143, 185);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(245, 20);
            this.txtSearch.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(394, 183);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(475, 182);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // unitBindingSource
            // 
            this.unitBindingSource.DataSource = typeof(Fanda2.Backend.Database.Unit);
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitNameDataGridViewTextBoxColumn
            // 
            this.unitNameDataGridViewTextBoxColumn.DataPropertyName = "UnitName";
            this.unitNameDataGridViewTextBoxColumn.HeaderText = "Unit Name";
            this.unitNameDataGridViewTextBoxColumn.Name = "unitNameDataGridViewTextBoxColumn";
            this.unitNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitDescDataGridViewTextBoxColumn
            // 
            this.unitDescDataGridViewTextBoxColumn.DataPropertyName = "UnitDesc";
            this.unitDescDataGridViewTextBoxColumn.HeaderText = "Description";
            this.unitDescDataGridViewTextBoxColumn.Name = "unitDescDataGridViewTextBoxColumn";
            this.unitDescDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isEnabledDataGridViewCheckBoxColumn
            // 
            this.isEnabledDataGridViewCheckBoxColumn.DataPropertyName = "IsEnabled";
            this.isEnabledDataGridViewCheckBoxColumn.HeaderText = "IsEnabled";
            this.isEnabledDataGridViewCheckBoxColumn.Name = "isEnabledDataGridViewCheckBoxColumn";
            this.isEnabledDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Search:";
            // 
            // UnitsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 383);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvUnits);
            this.Controls.Add(this.groupBox1);
            this.Name = "UnitsForm";
            this.Text = "Units";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvUnits;
        private System.Windows.Forms.BindingSource unitListBindingSource;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.BindingSource unitBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isEnabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Label label4;
    }
}