namespace ConsignmentPOS
{
    partial class MaintainLocations
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerLabel = new System.Windows.Forms.Label();
            this.saveLocations = new System.Windows.Forms.Button();
            this.locationGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coStoreDataSet = new ConsignmentPOS.CoStoreDataSet();
            this.deleteInstruction = new System.Windows.Forms.Label();
            this.insertInstruction = new System.Windows.Forms.Label();
            this.locationTableAdapter = new ConsignmentPOS.CoStoreDataSetTableAdapters.locationTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.locationGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(20, 20);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(175, 25);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Maintain Locations";
            // 
            // saveLocations
            // 
            this.saveLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveLocations.Location = new System.Drawing.Point(22, 499);
            this.saveLocations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveLocations.Name = "saveLocations";
            this.saveLocations.Size = new System.Drawing.Size(173, 44);
            this.saveLocations.TabIndex = 2;
            this.saveLocations.Text = "Save";
            this.saveLocations.UseVisualStyleBackColor = true;
            this.saveLocations.Click += new System.EventHandler(this.saveLocations_Click);
            // 
            // locationGridView
            // 
            this.locationGridView.AutoGenerateColumns = false;
            this.locationGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.locationGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.locationGridView.DataSource = this.locationBindingSource;
            this.locationGridView.Location = new System.Drawing.Point(20, 65);
            this.locationGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.locationGridView.Name = "locationGridView";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.locationGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.locationGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.locationGridView.RowTemplate.Height = 24;
            this.locationGridView.Size = new System.Drawing.Size(901, 369);
            this.locationGridView.TabIndex = 3;
            this.locationGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.locationGridView_CellMouseEnter);
            this.locationGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.locationGridView_CellMouseLeave);
            this.locationGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.locationGridView_CellValueChanged);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 600;
            // 
            // locationBindingSource
            // 
            this.locationBindingSource.DataMember = "location";
            this.locationBindingSource.DataSource = this.coStoreDataSet;
            // 
            // coStoreDataSet
            // 
            this.coStoreDataSet.DataSetName = "CoStoreDataSet";
            this.coStoreDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // deleteInstruction
            // 
            this.deleteInstruction.AutoSize = true;
            this.deleteInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteInstruction.Location = new System.Drawing.Point(20, 464);
            this.deleteInstruction.Name = "deleteInstruction";
            this.deleteInstruction.Size = new System.Drawing.Size(616, 20);
            this.deleteInstruction.TabIndex = 4;
            this.deleteInstruction.Text = "To delete a location, click in the first column of that row and press the Delete " +
    "key.";
            // 
            // insertInstruction
            // 
            this.insertInstruction.AutoSize = true;
            this.insertInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertInstruction.Location = new System.Drawing.Point(20, 439);
            this.insertInstruction.Name = "insertInstruction";
            this.insertInstruction.Size = new System.Drawing.Size(466, 20);
            this.insertInstruction.TabIndex = 5;
            this.insertInstruction.Text = "To insert a location, type its description in the empty last row.";
            // 
            // locationTableAdapter
            // 
            this.locationTableAdapter.ClearBeforeFill = true;
            // 
            // MaintainLocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.insertInstruction);
            this.Controls.Add(this.deleteInstruction);
            this.Controls.Add(this.locationGridView);
            this.Controls.Add(this.saveLocations);
            this.Controls.Add(this.headerLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MaintainLocations";
            this.Size = new System.Drawing.Size(1251, 788);
            this.VisibleChanged += new System.EventHandler(this.MaintainLocations_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.locationGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button saveLocations;
        private System.Windows.Forms.DataGridView locationGridView;
        private System.Windows.Forms.BindingSource locationBindingSource;
        private CoStoreDataSet coStoreDataSet;
        private CoStoreDataSetTableAdapters.locationTableAdapter locationTableAdapter;
        private System.Windows.Forms.Label deleteInstruction;
        private System.Windows.Forms.Label insertInstruction;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
    }
}
