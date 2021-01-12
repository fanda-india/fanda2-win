
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.IsEnabledCheck = new System.Windows.Forms.CheckBox();
            this.UnitsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DescriptionText = new System.Windows.Forms.TextBox();
            this.NameText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CodeText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ItemStatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.UnitsGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.UnitsGridView = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isEnabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UnitErrors = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnitsBindingSource)).BeginInit();
            this.ItemStatusStrip.SuspendLayout();
            this.UnitsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnitsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.CancelButton);
            this.groupBox1.Controls.Add(this.SaveButton);
            this.groupBox1.Controls.Add(this.IsEnabledCheck);
            this.groupBox1.Controls.Add(this.DescriptionText);
            this.groupBox1.Controls.Add(this.NameText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CodeText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Unit Details";
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(651, 138);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(87, 27);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "&Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(556, 138);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(87, 27);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "&Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // IsEnabledCheck
            // 
            this.IsEnabledCheck.AutoSize = true;
            this.IsEnabledCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.UnitsBindingSource, "IsEnabled", true));
            this.IsEnabledCheck.Location = new System.Drawing.Point(88, 138);
            this.IsEnabledCheck.Name = "IsEnabledCheck";
            this.IsEnabledCheck.Size = new System.Drawing.Size(84, 19);
            this.IsEnabledCheck.TabIndex = 6;
            this.IsEnabledCheck.Text = "Is Enabled?";
            this.IsEnabledCheck.UseVisualStyleBackColor = true;
            // 
            // UnitsBindingSource
            // 
            this.UnitsBindingSource.DataSource = typeof(Fanda2.Backend.Database.Unit);
            this.UnitsBindingSource.PositionChanged += new System.EventHandler(this.UnitsBindingSource_PositionChanged);
            // 
            // DescriptionText
            // 
            this.DescriptionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.UnitsBindingSource, "UnitDesc", true));
            this.DescriptionText.Location = new System.Drawing.Point(87, 82);
            this.DescriptionText.MaxLength = 255;
            this.DescriptionText.Multiline = true;
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(650, 50);
            this.DescriptionText.TabIndex = 5;
            // 
            // NameText
            // 
            this.NameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.UnitsBindingSource, "UnitName", true));
            this.NameText.Location = new System.Drawing.Point(87, 52);
            this.NameText.MaxLength = 25;
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(632, 23);
            this.NameText.TabIndex = 3;
            this.NameText.Validated += new System.EventHandler(this.NameText_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Description:";
            // 
            // CodeText
            // 
            this.CodeText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CodeText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.UnitsBindingSource, "Code", true));
            this.CodeText.Location = new System.Drawing.Point(87, 22);
            this.CodeText.MaxLength = 16;
            this.CodeText.Name = "CodeText";
            this.CodeText.Size = new System.Drawing.Size(123, 23);
            this.CodeText.TabIndex = 1;
            this.CodeText.Validated += new System.EventHandler(this.CodeText_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Unit Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Code:";
            // 
            // ItemStatusStrip
            // 
            this.ItemStatusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.ItemStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.ItemStatusStrip.Location = new System.Drawing.Point(0, 519);
            this.ItemStatusStrip.Name = "ItemStatusStrip";
            this.ItemStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.ItemStatusStrip.Size = new System.Drawing.Size(772, 22);
            this.ItemStatusStrip.TabIndex = 2;
            this.ItemStatusStrip.Text = "Ready";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(755, 17);
            this.StatusLabel.Spring = true;
            this.StatusLabel.Text = "Ready";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UnitsGroupBox
            // 
            this.UnitsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UnitsGroupBox.Controls.Add(this.label4);
            this.UnitsGroupBox.Controls.Add(this.DeleteButton);
            this.UnitsGroupBox.Controls.Add(this.AddButton);
            this.UnitsGroupBox.Controls.Add(this.SearchText);
            this.UnitsGroupBox.Controls.Add(this.RefreshButton);
            this.UnitsGroupBox.Controls.Add(this.UnitsGridView);
            this.UnitsGroupBox.Location = new System.Drawing.Point(14, 193);
            this.UnitsGroupBox.Name = "UnitsGroupBox";
            this.UnitsGroupBox.Size = new System.Drawing.Size(744, 319);
            this.UnitsGroupBox.TabIndex = 1;
            this.UnitsGroupBox.TabStop = false;
            this.UnitsGroupBox.Text = "Units";
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
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(650, 22);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(87, 27);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "&Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(555, 22);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(87, 27);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "&Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SearchText
            // 
            this.SearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchText.Location = new System.Drawing.Point(160, 24);
            this.SearchText.MaxLength = 255;
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(388, 23);
            this.SearchText.TabIndex = 2;
            this.SearchText.TextChanged += new System.EventHandler(this.SearchText_TextChanged);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(7, 22);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(87, 27);
            this.RefreshButton.TabIndex = 0;
            this.RefreshButton.Text = "&Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // UnitsGridView
            // 
            this.UnitsGridView.AllowUserToAddRows = false;
            this.UnitsGridView.AllowUserToDeleteRows = false;
            this.UnitsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UnitsGridView.AutoGenerateColumns = false;
            this.UnitsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UnitsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.unitNameDataGridViewTextBoxColumn,
            this.unitDescDataGridViewTextBoxColumn,
            this.isEnabledDataGridViewCheckBoxColumn});
            this.UnitsGridView.DataSource = this.UnitsBindingSource;
            this.UnitsGridView.Location = new System.Drawing.Point(7, 55);
            this.UnitsGridView.Name = "UnitsGridView";
            this.UnitsGridView.ReadOnly = true;
            this.UnitsGridView.RowHeadersWidth = 28;
            this.UnitsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UnitsGridView.Size = new System.Drawing.Size(730, 257);
            this.UnitsGridView.TabIndex = 5;
            this.UnitsGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.UnitsGridView_ColumnHeaderMouseClick);
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.Frozen = true;
            this.codeDataGridViewTextBoxColumn.HeaderText = "Code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 125;
            // 
            // unitNameDataGridViewTextBoxColumn
            // 
            this.unitNameDataGridViewTextBoxColumn.DataPropertyName = "UnitName";
            this.unitNameDataGridViewTextBoxColumn.HeaderText = "Unit Name";
            this.unitNameDataGridViewTextBoxColumn.Name = "unitNameDataGridViewTextBoxColumn";
            this.unitNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // unitDescDataGridViewTextBoxColumn
            // 
            this.unitDescDataGridViewTextBoxColumn.DataPropertyName = "UnitDesc";
            this.unitDescDataGridViewTextBoxColumn.HeaderText = "Description";
            this.unitDescDataGridViewTextBoxColumn.Name = "unitDescDataGridViewTextBoxColumn";
            this.unitDescDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitDescDataGridViewTextBoxColumn.Width = 250;
            // 
            // isEnabledDataGridViewCheckBoxColumn
            // 
            this.isEnabledDataGridViewCheckBoxColumn.DataPropertyName = "IsEnabled";
            this.isEnabledDataGridViewCheckBoxColumn.HeaderText = "Is Enabled?";
            this.isEnabledDataGridViewCheckBoxColumn.Name = "isEnabledDataGridViewCheckBoxColumn";
            this.isEnabledDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // UnitErrors
            // 
            this.UnitErrors.ContainerControl = this;
            // 
            // UnitsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 541);
            this.Controls.Add(this.UnitsGroupBox);
            this.Controls.Add(this.ItemStatusStrip);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UnitsForm";
            this.Text = "Units";
            this.Load += new System.EventHandler(this.UnitsForm_Load);
            this.Resize += new System.EventHandler(this.UnitsForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnitsBindingSource)).EndInit();
            this.ItemStatusStrip.ResumeLayout(false);
            this.ItemStatusStrip.PerformLayout();
            this.UnitsGroupBox.ResumeLayout(false);
            this.UnitsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnitsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitErrors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox IsEnabledCheck;
        private System.Windows.Forms.TextBox DescriptionText;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CodeText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.BindingSource UnitsBindingSource;
        private System.Windows.Forms.StatusStrip ItemStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.GroupBox UnitsGroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.DataGridView UnitsGridView;
        private System.Windows.Forms.ErrorProvider UnitErrors;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isEnabledDataGridViewCheckBoxColumn;
    }
}