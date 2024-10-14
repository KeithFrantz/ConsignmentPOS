namespace ConsignmentPOS
{
    partial class CashCount
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
            this.screenLabel = new System.Windows.Forms.Label();
            this.existingComments = new System.Windows.Forms.TextBox();
            this.existingCommentsLabel = new System.Windows.Forms.Label();
            this.newComments = new System.Windows.Forms.TextBox();
            this.newCommentsLabel = new System.Windows.Forms.Label();
            this.cashInStore = new System.Windows.Forms.TextBox();
            this.cashInStoreCurrency = new System.Windows.Forms.Label();
            this.cashInStoreLabel = new System.Windows.Forms.Label();
            this.newEntryGroupBox = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.enteredBy = new System.Windows.Forms.TextBox();
            this.enteredByLabel = new System.Windows.Forms.Label();
            this.totalCashShouldBe = new System.Windows.Forms.Label();
            this.totalCashShouldBeLabel = new System.Windows.Forms.Label();
            this.totalCashIs = new System.Windows.Forms.Label();
            this.totalCashIsLabel = new System.Windows.Forms.Label();
            this.cashRemoteCurrency = new System.Windows.Forms.Label();
            this.cashRemote = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.cashRemoteLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.cashGridView = new System.Windows.Forms.DataGridView();
            this.cashBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coStoreDataSet = new ConsignmentPOS.CoStoreDataSet();
            this.cashTableAdapter = new ConsignmentPOS.CoStoreDataSetTableAdapters.cashTableAdapter();
            this.amount_in_store = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount_remote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_should_be = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newEntryGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // screenLabel
            // 
            this.screenLabel.AutoSize = true;
            this.screenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screenLabel.Location = new System.Drawing.Point(17, 40);
            this.screenLabel.Name = "screenLabel";
            this.screenLabel.Size = new System.Drawing.Size(117, 25);
            this.screenLabel.TabIndex = 0;
            this.screenLabel.Text = "Cash Count";
            // 
            // existingComments
            // 
            this.existingComments.Location = new System.Drawing.Point(844, 112);
            this.existingComments.Multiline = true;
            this.existingComments.Name = "existingComments";
            this.existingComments.ReadOnly = true;
            this.existingComments.Size = new System.Drawing.Size(363, 178);
            this.existingComments.TabIndex = 4;
            this.existingComments.TabStop = false;
            // 
            // existingCommentsLabel
            // 
            this.existingCommentsLabel.AutoSize = true;
            this.existingCommentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.existingCommentsLabel.Location = new System.Drawing.Point(839, 84);
            this.existingCommentsLabel.Name = "existingCommentsLabel";
            this.existingCommentsLabel.Size = new System.Drawing.Size(266, 25);
            this.existingCommentsLabel.TabIndex = 3;
            this.existingCommentsLabel.Text = "Comments for Selected Entry";
            // 
            // newComments
            // 
            this.newComments.Location = new System.Drawing.Point(844, 350);
            this.newComments.MaxLength = 1000;
            this.newComments.Multiline = true;
            this.newComments.Name = "newComments";
            this.newComments.Size = new System.Drawing.Size(363, 178);
            this.newComments.TabIndex = 6;
            // 
            // newCommentsLabel
            // 
            this.newCommentsLabel.AutoSize = true;
            this.newCommentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCommentsLabel.Location = new System.Drawing.Point(841, 322);
            this.newCommentsLabel.Name = "newCommentsLabel";
            this.newCommentsLabel.Size = new System.Drawing.Size(228, 25);
            this.newCommentsLabel.TabIndex = 5;
            this.newCommentsLabel.Text = "Comments for New Entry";
            // 
            // cashInStore
            // 
            this.cashInStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashInStore.Location = new System.Drawing.Point(42, 65);
            this.cashInStore.Name = "cashInStore";
            this.cashInStore.Size = new System.Drawing.Size(120, 30);
            this.cashInStore.TabIndex = 10;
            this.cashInStore.Validating += new System.ComponentModel.CancelEventHandler(this.cashInStore_Validating);
            // 
            // cashInStoreCurrency
            // 
            this.cashInStoreCurrency.AutoSize = true;
            this.cashInStoreCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashInStoreCurrency.Location = new System.Drawing.Point(16, 70);
            this.cashInStoreCurrency.Name = "cashInStoreCurrency";
            this.cashInStoreCurrency.Size = new System.Drawing.Size(23, 25);
            this.cashInStoreCurrency.TabIndex = 9;
            this.cashInStoreCurrency.Text = "$";
            // 
            // cashInStoreLabel
            // 
            this.cashInStoreLabel.AutoSize = true;
            this.cashInStoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashInStoreLabel.Location = new System.Drawing.Point(37, 39);
            this.cashInStoreLabel.Name = "cashInStoreLabel";
            this.cashInStoreLabel.Size = new System.Drawing.Size(132, 25);
            this.cashInStoreLabel.TabIndex = 8;
            this.cashInStoreLabel.Text = "Cash In Store";
            // 
            // newEntryGroupBox
            // 
            this.newEntryGroupBox.Controls.Add(this.saveButton);
            this.newEntryGroupBox.Controls.Add(this.enteredBy);
            this.newEntryGroupBox.Controls.Add(this.cashInStoreCurrency);
            this.newEntryGroupBox.Controls.Add(this.enteredByLabel);
            this.newEntryGroupBox.Controls.Add(this.totalCashShouldBe);
            this.newEntryGroupBox.Controls.Add(this.totalCashShouldBeLabel);
            this.newEntryGroupBox.Controls.Add(this.totalCashIs);
            this.newEntryGroupBox.Controls.Add(this.totalCashIsLabel);
            this.newEntryGroupBox.Controls.Add(this.cashRemoteCurrency);
            this.newEntryGroupBox.Controls.Add(this.cashRemote);
            this.newEntryGroupBox.Controls.Add(this.cashInStore);
            this.newEntryGroupBox.Controls.Add(this.label7);
            this.newEntryGroupBox.Controls.Add(this.textBox4);
            this.newEntryGroupBox.Controls.Add(this.cashRemoteLabel);
            this.newEntryGroupBox.Controls.Add(this.label5);
            this.newEntryGroupBox.Controls.Add(this.textBox3);
            this.newEntryGroupBox.Controls.Add(this.label6);
            this.newEntryGroupBox.Controls.Add(this.cashInStoreLabel);
            this.newEntryGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newEntryGroupBox.Location = new System.Drawing.Point(22, 539);
            this.newEntryGroupBox.Name = "newEntryGroupBox";
            this.newEntryGroupBox.Size = new System.Drawing.Size(1063, 117);
            this.newEntryGroupBox.TabIndex = 7;
            this.newEntryGroupBox.TabStop = false;
            this.newEntryGroupBox.Text = "New Entry";
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(972, 61);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 39);
            this.saveButton.TabIndex = 20;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // enteredBy
            // 
            this.enteredBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enteredBy.Location = new System.Drawing.Point(721, 65);
            this.enteredBy.Name = "enteredBy";
            this.enteredBy.Size = new System.Drawing.Size(229, 30);
            this.enteredBy.TabIndex = 19;
            this.enteredBy.Validating += new System.ComponentModel.CancelEventHandler(this.enteredBy_Validating);
            // 
            // enteredByLabel
            // 
            this.enteredByLabel.AutoSize = true;
            this.enteredByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enteredByLabel.Location = new System.Drawing.Point(725, 39);
            this.enteredByLabel.Name = "enteredByLabel";
            this.enteredByLabel.Size = new System.Drawing.Size(115, 25);
            this.enteredByLabel.TabIndex = 18;
            this.enteredByLabel.Text = "Counted By";
            // 
            // totalCashShouldBe
            // 
            this.totalCashShouldBe.AutoSize = true;
            this.totalCashShouldBe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCashShouldBe.Location = new System.Drawing.Point(556, 70);
            this.totalCashShouldBe.Name = "totalCashShouldBe";
            this.totalCashShouldBe.Size = new System.Drawing.Size(61, 25);
            this.totalCashShouldBe.TabIndex = 17;
            this.totalCashShouldBe.Text = "$0.00";
            // 
            // totalCashShouldBeLabel
            // 
            this.totalCashShouldBeLabel.AutoSize = true;
            this.totalCashShouldBeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCashShouldBeLabel.Location = new System.Drawing.Point(510, 39);
            this.totalCashShouldBeLabel.Name = "totalCashShouldBeLabel";
            this.totalCashShouldBeLabel.Size = new System.Drawing.Size(204, 25);
            this.totalCashShouldBeLabel.TabIndex = 16;
            this.totalCashShouldBeLabel.Text = "Total Cash Should Be";
            // 
            // totalCashIs
            // 
            this.totalCashIs.AutoSize = true;
            this.totalCashIs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCashIs.Location = new System.Drawing.Point(411, 70);
            this.totalCashIs.Name = "totalCashIs";
            this.totalCashIs.Size = new System.Drawing.Size(23, 25);
            this.totalCashIs.TabIndex = 15;
            this.totalCashIs.Text = "$";
            // 
            // totalCashIsLabel
            // 
            this.totalCashIsLabel.AutoSize = true;
            this.totalCashIsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCashIsLabel.Location = new System.Drawing.Point(365, 39);
            this.totalCashIsLabel.Name = "totalCashIsLabel";
            this.totalCashIsLabel.Size = new System.Drawing.Size(128, 25);
            this.totalCashIsLabel.TabIndex = 14;
            this.totalCashIsLabel.Text = "Total Cash Is";
            // 
            // cashRemoteCurrency
            // 
            this.cashRemoteCurrency.AutoSize = true;
            this.cashRemoteCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashRemoteCurrency.Location = new System.Drawing.Point(192, 68);
            this.cashRemoteCurrency.Name = "cashRemoteCurrency";
            this.cashRemoteCurrency.Size = new System.Drawing.Size(23, 25);
            this.cashRemoteCurrency.TabIndex = 12;
            this.cashRemoteCurrency.Text = "$";
            // 
            // cashRemote
            // 
            this.cashRemote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashRemote.Location = new System.Drawing.Point(218, 65);
            this.cashRemote.Name = "cashRemote";
            this.cashRemote.Size = new System.Drawing.Size(120, 30);
            this.cashRemote.TabIndex = 13;
            this.cashRemote.Validating += new System.ComponentModel.CancelEventHandler(this.cashRemote_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(192, 573);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "$";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(218, 570);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(120, 30);
            this.textBox4.TabIndex = 12;
            // 
            // cashRemoteLabel
            // 
            this.cashRemoteLabel.AutoSize = true;
            this.cashRemoteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashRemoteLabel.Location = new System.Drawing.Point(213, 39);
            this.cashRemoteLabel.Name = "cashRemoteLabel";
            this.cashRemoteLabel.Size = new System.Drawing.Size(131, 25);
            this.cashRemoteLabel.TabIndex = 11;
            this.cashRemoteLabel.Text = "Cash Remote";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(510, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "$";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(536, 327);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(120, 30);
            this.textBox3.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(509, -204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cash In Store";
            // 
            // refreshButton
            // 
            this.refreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshButton.Location = new System.Drawing.Point(1109, 600);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(98, 39);
            this.refreshButton.TabIndex = 21;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // cashGridView
            // 
            this.cashGridView.AllowUserToAddRows = false;
            this.cashGridView.AllowUserToDeleteRows = false;
            this.cashGridView.AutoGenerateColumns = false;
            this.cashGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cashGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.amount_in_store,
            this.amount_remote,
            this.total_should_be,
            this.count_at,
            this.count_by,
            this.comment});
            this.cashGridView.DataSource = this.cashBindingSource;
            this.cashGridView.Location = new System.Drawing.Point(24, 68);
            this.cashGridView.Name = "cashGridView";
            this.cashGridView.ReadOnly = true;
            this.cashGridView.RowHeadersWidth = 51;
            this.cashGridView.RowTemplate.Height = 24;
            this.cashGridView.Size = new System.Drawing.Size(811, 460);
            this.cashGridView.TabIndex = 2;
            this.cashGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.cashGridView_RowEnter);
            // 
            // cashBindingSource
            // 
            this.cashBindingSource.DataMember = "cash";
            this.cashBindingSource.DataSource = this.coStoreDataSet;
            // 
            // coStoreDataSet
            // 
            this.coStoreDataSet.DataSetName = "CoStoreDataSet";
            this.coStoreDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cashTableAdapter
            // 
            this.cashTableAdapter.ClearBeforeFill = true;
            // 
            // amount_in_store
            // 
            this.amount_in_store.DataPropertyName = "amount_in_store";
            this.amount_in_store.HeaderText = "Cash In Store";
            this.amount_in_store.MinimumWidth = 6;
            this.amount_in_store.Name = "amount_in_store";
            this.amount_in_store.ReadOnly = true;
            this.amount_in_store.Width = 70;
            // 
            // amount_remote
            // 
            this.amount_remote.DataPropertyName = "amount_remote";
            this.amount_remote.HeaderText = "Cash Remote";
            this.amount_remote.MinimumWidth = 6;
            this.amount_remote.Name = "amount_remote";
            this.amount_remote.ReadOnly = true;
            this.amount_remote.Width = 70;
            // 
            // total_should_be
            // 
            this.total_should_be.DataPropertyName = "total_should_be";
            this.total_should_be.HeaderText = "Total Should Be";
            this.total_should_be.MinimumWidth = 6;
            this.total_should_be.Name = "total_should_be";
            this.total_should_be.ReadOnly = true;
            this.total_should_be.Width = 85;
            // 
            // count_at
            // 
            this.count_at.DataPropertyName = "count_at";
            this.count_at.HeaderText = "When Counted";
            this.count_at.MinimumWidth = 6;
            this.count_at.Name = "count_at";
            this.count_at.ReadOnly = true;
            this.count_at.Width = 120;
            // 
            // count_by
            // 
            this.count_by.DataPropertyName = "count_by";
            this.count_by.HeaderText = "Counted By";
            this.count_by.MinimumWidth = 6;
            this.count_by.Name = "count_by";
            this.count_by.ReadOnly = true;
            this.count_by.Width = 446;
            // 
            // comment
            // 
            this.comment.DataPropertyName = "comment";
            this.comment.HeaderText = "comment";
            this.comment.MinimumWidth = 6;
            this.comment.Name = "comment";
            this.comment.ReadOnly = true;
            this.comment.Visible = false;
            this.comment.Width = 125;
            // 
            // CashCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.newComments);
            this.Controls.Add(this.newCommentsLabel);
            this.Controls.Add(this.existingCommentsLabel);
            this.Controls.Add(this.existingComments);
            this.Controls.Add(this.screenLabel);
            this.Controls.Add(this.newEntryGroupBox);
            this.Controls.Add(this.cashGridView);
            this.Name = "CashCount";
            this.Size = new System.Drawing.Size(1223, 679);
            this.VisibleChanged += new System.EventHandler(this.CashCount_VisibleChanged);
            this.newEntryGroupBox.ResumeLayout(false);
            this.newEntryGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label screenLabel;
        private System.Windows.Forms.TextBox existingComments;
        private System.Windows.Forms.Label existingCommentsLabel;
        private System.Windows.Forms.TextBox newComments;
        private System.Windows.Forms.Label newCommentsLabel;
        private System.Windows.Forms.TextBox cashInStore;
        private System.Windows.Forms.Label cashInStoreCurrency;
        private System.Windows.Forms.Label cashInStoreLabel;
        private System.Windows.Forms.GroupBox newEntryGroupBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label cashRemoteLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label totalCashIsLabel;
        private System.Windows.Forms.Label cashRemoteCurrency;
        private System.Windows.Forms.TextBox cashRemote;
        private System.Windows.Forms.Label totalCashIs;
        private System.Windows.Forms.TextBox enteredBy;
        private System.Windows.Forms.Label enteredByLabel;
        private System.Windows.Forms.Label totalCashShouldBe;
        private System.Windows.Forms.Label totalCashShouldBeLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.DataGridView cashGridView;
        private System.Windows.Forms.BindingSource cashBindingSource;
        private CoStoreDataSet coStoreDataSet;
        private CoStoreDataSetTableAdapters.cashTableAdapter cashTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount_in_store;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount_remote;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_should_be;
        private System.Windows.Forms.DataGridViewTextBoxColumn count_at;
        private System.Windows.Forms.DataGridViewTextBoxColumn count_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
    }
}
