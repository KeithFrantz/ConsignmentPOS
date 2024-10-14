namespace ConsignmentPOS
{
    partial class EnterNewSales
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
            this.newSaleItemsGridView = new System.Windows.Forms.DataGridView();
            this.headerLabel = new System.Windows.Forms.Label();
            this.saleID = new System.Windows.Forms.TextBox();
            this.saleIDLabel = new System.Windows.Forms.Label();
            this.saleAmount = new System.Windows.Forms.TextBox();
            this.saleAmountLabel = new System.Windows.Forms.Label();
            this.tendered = new System.Windows.Forms.TextBox();
            this.tenderedLabel = new System.Windows.Forms.Label();
            this.change = new System.Windows.Forms.TextBox();
            this.changeLabel = new System.Windows.Forms.Label();
            this.completeSaleButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.reprintButton = new System.Windows.Forms.Button();
            this.item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.short_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.newSaleItemsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // newSaleItemsGridView
            // 
            this.newSaleItemsGridView.CausesValidation = false;
            this.newSaleItemsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.newSaleItemsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item_id,
            this.short_description,
            this.quantity,
            this.price,
            this.amount});
            this.newSaleItemsGridView.Location = new System.Drawing.Point(8, 63);
            this.newSaleItemsGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newSaleItemsGridView.Name = "newSaleItemsGridView";
            this.newSaleItemsGridView.RowHeadersWidth = 51;
            this.newSaleItemsGridView.RowTemplate.Height = 24;
            this.newSaleItemsGridView.Size = new System.Drawing.Size(1248, 455);
            this.newSaleItemsGridView.TabIndex = 1;
            this.newSaleItemsGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.newSaleItemsGridView_CellValueChanged);
            this.newSaleItemsGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.newSaleItemsGridView_RowsRemoved);
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(3, 34);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(157, 25);
            this.headerLabel.TabIndex = 2;
            this.headerLabel.Text = "Enter New Sales";
            // 
            // saleID
            // 
            this.saleID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleID.Location = new System.Drawing.Point(139, 581);
            this.saleID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saleID.MaxLength = 10;
            this.saleID.Name = "saleID";
            this.saleID.ReadOnly = true;
            this.saleID.Size = new System.Drawing.Size(159, 30);
            this.saleID.TabIndex = 3;
            this.saleID.TabStop = false;
            // 
            // saleIDLabel
            // 
            this.saleIDLabel.AutoSize = true;
            this.saleIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleIDLabel.Location = new System.Drawing.Point(133, 553);
            this.saleIDLabel.Name = "saleIDLabel";
            this.saleIDLabel.Size = new System.Drawing.Size(118, 25);
            this.saleIDLabel.TabIndex = 4;
            this.saleIDLabel.Text = "Last Sale ID";
            // 
            // saleAmount
            // 
            this.saleAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleAmount.Location = new System.Drawing.Point(361, 581);
            this.saleAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saleAmount.Name = "saleAmount";
            this.saleAmount.ReadOnly = true;
            this.saleAmount.Size = new System.Drawing.Size(185, 30);
            this.saleAmount.TabIndex = 5;
            this.saleAmount.TabStop = false;
            this.saleAmount.Text = "0.00";
            // 
            // saleAmountLabel
            // 
            this.saleAmountLabel.AutoSize = true;
            this.saleAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleAmountLabel.Location = new System.Drawing.Point(356, 553);
            this.saleAmountLabel.Name = "saleAmountLabel";
            this.saleAmountLabel.Size = new System.Drawing.Size(174, 25);
            this.saleAmountLabel.TabIndex = 6;
            this.saleAmountLabel.Text = "Total Sale Amount";
            // 
            // tendered
            // 
            this.tendered.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tendered.Location = new System.Drawing.Point(611, 581);
            this.tendered.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tendered.Name = "tendered";
            this.tendered.Size = new System.Drawing.Size(185, 30);
            this.tendered.TabIndex = 7;
            this.tendered.Validating += new System.ComponentModel.CancelEventHandler(this.tendered_Validating);
            this.tendered.Validated += new System.EventHandler(this.tendered_Validated);
            // 
            // tenderedLabel
            // 
            this.tenderedLabel.AutoSize = true;
            this.tenderedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenderedLabel.Location = new System.Drawing.Point(605, 553);
            this.tenderedLabel.Name = "tenderedLabel";
            this.tenderedLabel.Size = new System.Drawing.Size(170, 25);
            this.tenderedLabel.TabIndex = 8;
            this.tenderedLabel.Text = "Amount Tendered";
            // 
            // change
            // 
            this.change.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.change.Location = new System.Drawing.Point(864, 581);
            this.change.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.change.Name = "change";
            this.change.ReadOnly = true;
            this.change.Size = new System.Drawing.Size(185, 30);
            this.change.TabIndex = 9;
            this.change.TabStop = false;
            // 
            // changeLabel
            // 
            this.changeLabel.AutoSize = true;
            this.changeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeLabel.Location = new System.Drawing.Point(859, 553);
            this.changeLabel.Name = "changeLabel";
            this.changeLabel.Size = new System.Drawing.Size(82, 25);
            this.changeLabel.TabIndex = 10;
            this.changeLabel.Text = "Change";
            // 
            // completeSaleButton
            // 
            this.completeSaleButton.Enabled = false;
            this.completeSaleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeSaleButton.Location = new System.Drawing.Point(180, 647);
            this.completeSaleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.completeSaleButton.Name = "completeSaleButton";
            this.completeSaleButton.Size = new System.Drawing.Size(219, 55);
            this.completeSaleButton.TabIndex = 11;
            this.completeSaleButton.Text = "Complete Sale";
            this.completeSaleButton.UseVisualStyleBackColor = true;
            this.completeSaleButton.Click += new System.EventHandler(this.completeSaleButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(469, 647);
            this.clearButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(219, 55);
            this.clearButton.TabIndex = 12;
            this.clearButton.Text = "Clear All Items";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // reprintButton
            // 
            this.reprintButton.Enabled = false;
            this.reprintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reprintButton.Location = new System.Drawing.Point(763, 647);
            this.reprintButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reprintButton.Name = "reprintButton";
            this.reprintButton.Size = new System.Drawing.Size(219, 55);
            this.reprintButton.TabIndex = 13;
            this.reprintButton.Text = "Reprint Last Receipt";
            this.reprintButton.UseVisualStyleBackColor = true;
            this.reprintButton.Click += new System.EventHandler(this.reprintButton_Click);
            // 
            // item_id
            // 
            this.item_id.HeaderText = "Item ID";
            this.item_id.MaxInputLength = 9;
            this.item_id.MinimumWidth = 6;
            this.item_id.Name = "item_id";
            this.item_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.item_id.Width = 125;
            // 
            // short_description
            // 
            this.short_description.HeaderText = "Short Description";
            this.short_description.MinimumWidth = 6;
            this.short_description.Name = "short_description";
            this.short_description.ReadOnly = true;
            this.short_description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.short_description.Width = 475;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Qty.";
            this.quantity.MaxInputLength = 9;
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            this.quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quantity.Width = 50;
            // 
            // price
            // 
            this.price.HeaderText = "Unit Price";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.price.Width = 115;
            // 
            // amount
            // 
            this.amount.HeaderText = "Ext. Price";
            this.amount.MinimumWidth = 6;
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.amount.Width = 115;
            // 
            // EnterNewSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.newSaleItemsGridView);
            this.Controls.Add(this.reprintButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.completeSaleButton);
            this.Controls.Add(this.change);
            this.Controls.Add(this.changeLabel);
            this.Controls.Add(this.tendered);
            this.Controls.Add(this.tenderedLabel);
            this.Controls.Add(this.saleAmountLabel);
            this.Controls.Add(this.saleAmount);
            this.Controls.Add(this.saleIDLabel);
            this.Controls.Add(this.saleID);
            this.Controls.Add(this.headerLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EnterNewSales";
            this.Size = new System.Drawing.Size(1300, 800);
            ((System.ComponentModel.ISupportInitialize)(this.newSaleItemsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView newSaleItemsGridView;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.TextBox saleID;
        private System.Windows.Forms.Label saleIDLabel;
        private System.Windows.Forms.TextBox saleAmount;
        private System.Windows.Forms.Label saleAmountLabel;
        private System.Windows.Forms.TextBox tendered;
        private System.Windows.Forms.Label tenderedLabel;
        private System.Windows.Forms.TextBox change;
        private System.Windows.Forms.Label changeLabel;
        private System.Windows.Forms.Button completeSaleButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button reprintButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn short_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
    }
}
