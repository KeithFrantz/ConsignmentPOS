namespace ConsignmentPOS
{
    partial class SettleWSellers
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
            this.label1 = new System.Windows.Forms.Label();
            this.sellerFilterGroupBox = new System.Windows.Forms.GroupBox();
            this.findSellersButton = new System.Windows.Forms.Button();
            this.lastNameFilterLabel = new System.Windows.Forms.Label();
            this.registrationNoFilter = new System.Windows.Forms.TextBox();
            this.lastNameFilter = new System.Windows.Forms.TextBox();
            this.registrationNoFilterLabel = new System.Windows.Forms.Label();
            this.firstNameFilterLabel = new System.Windows.Forms.Label();
            this.firstNameFilter = new System.Windows.Forms.TextBox();
            this.sellersGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salutationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middlenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suffixDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectunsettledsellersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coStoreDataSet = new ConsignmentPOS.CoStoreDataSet();
            this.itemsGridView = new System.Windows.Forms.DataGridView();
            this.item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.short_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity_at_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_sold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to_be_returned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sales_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to_be_paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amt_paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settled_returned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settled_amt_paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printRcptButton = new System.Windows.Forms.Button();
            this.itemsGridViewLabel = new System.Windows.Forms.Label();
            this.totalAmountDueLabel = new System.Windows.Forms.Label();
            this.totalAmountDue = new System.Windows.Forms.Label();
            this.amountPaidSellerLabel = new System.Windows.Forms.Label();
            this.amountPaidSeller = new System.Windows.Forms.TextBox();
            this.currencyLabel = new System.Windows.Forms.Label();
            this.settlementButton = new System.Windows.Forms.Button();
            this.totalSalesLabel = new System.Windows.Forms.Label();
            this.totalSales = new System.Windows.Forms.Label();
            this.commissionLabel = new System.Windows.Forms.Label();
            this.commission = new System.Windows.Forms.Label();
            this.nstructions = new System.Windows.Forms.Label();
            this.select_unsettled_sellersTableAdapter = new ConsignmentPOS.CoStoreDataSetTableAdapters.select_unsettled_sellersTableAdapter();
            this.sellerFilterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sellersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectunsettledsellersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settle With Sellers";
            // 
            // sellerFilterGroupBox
            // 
            this.sellerFilterGroupBox.Controls.Add(this.findSellersButton);
            this.sellerFilterGroupBox.Controls.Add(this.lastNameFilterLabel);
            this.sellerFilterGroupBox.Controls.Add(this.registrationNoFilter);
            this.sellerFilterGroupBox.Controls.Add(this.lastNameFilter);
            this.sellerFilterGroupBox.Controls.Add(this.registrationNoFilterLabel);
            this.sellerFilterGroupBox.Controls.Add(this.firstNameFilterLabel);
            this.sellerFilterGroupBox.Controls.Add(this.firstNameFilter);
            this.sellerFilterGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sellerFilterGroupBox.Location = new System.Drawing.Point(248, 40);
            this.sellerFilterGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.sellerFilterGroupBox.Name = "sellerFilterGroupBox";
            this.sellerFilterGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.sellerFilterGroupBox.Size = new System.Drawing.Size(916, 96);
            this.sellerFilterGroupBox.TabIndex = 9;
            this.sellerFilterGroupBox.TabStop = false;
            this.sellerFilterGroupBox.Text = "Seller FIlters";
            // 
            // findSellersButton
            // 
            this.findSellersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findSellersButton.Location = new System.Drawing.Point(772, 43);
            this.findSellersButton.Margin = new System.Windows.Forms.Padding(4);
            this.findSellersButton.Name = "findSellersButton";
            this.findSellersButton.Size = new System.Drawing.Size(136, 46);
            this.findSellersButton.TabIndex = 9;
            this.findSellersButton.Text = "Find Sellers";
            this.findSellersButton.UseVisualStyleBackColor = true;
            this.findSellersButton.Click += new System.EventHandler(this.findSellersButton_Click);
            // 
            // lastNameFilterLabel
            // 
            this.lastNameFilterLabel.AutoSize = true;
            this.lastNameFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameFilterLabel.Location = new System.Drawing.Point(476, 28);
            this.lastNameFilterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastNameFilterLabel.Name = "lastNameFilterLabel";
            this.lastNameFilterLabel.Size = new System.Drawing.Size(106, 25);
            this.lastNameFilterLabel.TabIndex = 7;
            this.lastNameFilterLabel.Text = "Last Name";
            // 
            // registrationNoFilter
            // 
            this.registrationNoFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrationNoFilter.Location = new System.Drawing.Point(20, 57);
            this.registrationNoFilter.Margin = new System.Windows.Forms.Padding(4);
            this.registrationNoFilter.Name = "registrationNoFilter";
            this.registrationNoFilter.Size = new System.Drawing.Size(132, 30);
            this.registrationNoFilter.TabIndex = 2;
            this.registrationNoFilter.Validating += new System.ComponentModel.CancelEventHandler(this.registrationNoFilter_Validating);
            // 
            // lastNameFilter
            // 
            this.lastNameFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameFilter.Location = new System.Drawing.Point(481, 57);
            this.lastNameFilter.Margin = new System.Windows.Forms.Padding(4);
            this.lastNameFilter.Name = "lastNameFilter";
            this.lastNameFilter.Size = new System.Drawing.Size(265, 30);
            this.lastNameFilter.TabIndex = 6;
            // 
            // registrationNoFilterLabel
            // 
            this.registrationNoFilterLabel.AutoSize = true;
            this.registrationNoFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrationNoFilterLabel.Location = new System.Drawing.Point(15, 28);
            this.registrationNoFilterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.registrationNoFilterLabel.Name = "registrationNoFilterLabel";
            this.registrationNoFilterLabel.Size = new System.Drawing.Size(149, 25);
            this.registrationNoFilterLabel.TabIndex = 3;
            this.registrationNoFilterLabel.Text = "Registration No.";
            // 
            // firstNameFilterLabel
            // 
            this.firstNameFilterLabel.AutoSize = true;
            this.firstNameFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameFilterLabel.Location = new System.Drawing.Point(187, 28);
            this.firstNameFilterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.firstNameFilterLabel.Name = "firstNameFilterLabel";
            this.firstNameFilterLabel.Size = new System.Drawing.Size(106, 25);
            this.firstNameFilterLabel.TabIndex = 5;
            this.firstNameFilterLabel.Text = "First Name";
            // 
            // firstNameFilter
            // 
            this.firstNameFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameFilter.Location = new System.Drawing.Point(191, 57);
            this.firstNameFilter.Margin = new System.Windows.Forms.Padding(4);
            this.firstNameFilter.Name = "firstNameFilter";
            this.firstNameFilter.Size = new System.Drawing.Size(265, 30);
            this.firstNameFilter.TabIndex = 4;
            // 
            // sellersGridView
            // 
            this.sellersGridView.AllowUserToAddRows = false;
            this.sellersGridView.AllowUserToDeleteRows = false;
            this.sellersGridView.AutoGenerateColumns = false;
            this.sellersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sellersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.salutationDataGridViewTextBoxColumn,
            this.firstnameDataGridViewTextBoxColumn,
            this.middlenameDataGridViewTextBoxColumn,
            this.lastnameDataGridViewTextBoxColumn,
            this.suffixDataGridViewTextBoxColumn});
            this.sellersGridView.DataSource = this.selectunsettledsellersBindingSource;
            this.sellersGridView.Location = new System.Drawing.Point(22, 144);
            this.sellersGridView.Margin = new System.Windows.Forms.Padding(4);
            this.sellersGridView.MultiSelect = false;
            this.sellersGridView.Name = "sellersGridView";
            this.sellersGridView.ReadOnly = true;
            this.sellersGridView.RowHeadersWidth = 51;
            this.sellersGridView.Size = new System.Drawing.Size(1237, 145);
            this.sellersGridView.TabIndex = 10;
            this.sellersGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.sellersGridView_RowEnter);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Reg. #";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // salutationDataGridViewTextBoxColumn
            // 
            this.salutationDataGridViewTextBoxColumn.DataPropertyName = "salutation";
            this.salutationDataGridViewTextBoxColumn.HeaderText = "Salutation";
            this.salutationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.salutationDataGridViewTextBoxColumn.Name = "salutationDataGridViewTextBoxColumn";
            this.salutationDataGridViewTextBoxColumn.ReadOnly = true;
            this.salutationDataGridViewTextBoxColumn.Width = 125;
            // 
            // firstnameDataGridViewTextBoxColumn
            // 
            this.firstnameDataGridViewTextBoxColumn.DataPropertyName = "first_name";
            this.firstnameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.firstnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.firstnameDataGridViewTextBoxColumn.Name = "firstnameDataGridViewTextBoxColumn";
            this.firstnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.firstnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // middlenameDataGridViewTextBoxColumn
            // 
            this.middlenameDataGridViewTextBoxColumn.DataPropertyName = "middle_name";
            this.middlenameDataGridViewTextBoxColumn.HeaderText = "Middle Name";
            this.middlenameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.middlenameDataGridViewTextBoxColumn.Name = "middlenameDataGridViewTextBoxColumn";
            this.middlenameDataGridViewTextBoxColumn.ReadOnly = true;
            this.middlenameDataGridViewTextBoxColumn.Width = 125;
            // 
            // lastnameDataGridViewTextBoxColumn
            // 
            this.lastnameDataGridViewTextBoxColumn.DataPropertyName = "last_name";
            this.lastnameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.lastnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lastnameDataGridViewTextBoxColumn.Name = "lastnameDataGridViewTextBoxColumn";
            this.lastnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // suffixDataGridViewTextBoxColumn
            // 
            this.suffixDataGridViewTextBoxColumn.DataPropertyName = "suffix";
            this.suffixDataGridViewTextBoxColumn.HeaderText = "Suffix";
            this.suffixDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.suffixDataGridViewTextBoxColumn.Name = "suffixDataGridViewTextBoxColumn";
            this.suffixDataGridViewTextBoxColumn.ReadOnly = true;
            this.suffixDataGridViewTextBoxColumn.Width = 125;
            // 
            // selectunsettledsellersBindingSource
            // 
            this.selectunsettledsellersBindingSource.DataMember = "select_unsettled_sellers";
            this.selectunsettledsellersBindingSource.DataSource = this.coStoreDataSet;
            // 
            // coStoreDataSet
            // 
            this.coStoreDataSet.DataSetName = "CoStoreDataSet";
            this.coStoreDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemsGridView
            // 
            this.itemsGridView.AllowUserToAddRows = false;
            this.itemsGridView.AllowUserToDeleteRows = false;
            this.itemsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item_id,
            this.short_description,
            this.quantity_at_start,
            this.num_sold,
            this.to_be_returned,
            this.returned,
            this.sales_amount,
            this.to_be_paid,
            this.amt_paid,
            this.description,
            this.pricing,
            this.settled_returned,
            this.settled_amt_paid});
            this.itemsGridView.Location = new System.Drawing.Point(22, 332);
            this.itemsGridView.Margin = new System.Windows.Forms.Padding(4);
            this.itemsGridView.MultiSelect = false;
            this.itemsGridView.Name = "itemsGridView";
            this.itemsGridView.RowHeadersWidth = 51;
            this.itemsGridView.Size = new System.Drawing.Size(1237, 228);
            this.itemsGridView.TabIndex = 11;
            this.itemsGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemsGridView_CellMouseEnter);
            this.itemsGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemsGridView_CellMouseLeave);
            this.itemsGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemsGridView_CellValueChanged);
            // 
            // item_id
            // 
            this.item_id.DataPropertyName = "item_id";
            this.item_id.HeaderText = "ID";
            this.item_id.MinimumWidth = 6;
            this.item_id.Name = "item_id";
            this.item_id.ReadOnly = true;
            this.item_id.Width = 54;
            // 
            // short_description
            // 
            this.short_description.DataPropertyName = "short_description";
            this.short_description.HeaderText = "Short Description";
            this.short_description.MinimumWidth = 6;
            this.short_description.Name = "short_description";
            this.short_description.ReadOnly = true;
            this.short_description.Width = 390;
            // 
            // quantity_at_start
            // 
            this.quantity_at_start.DataPropertyName = "quantity_at_start";
            this.quantity_at_start.HeaderText = "Qty. for Sale";
            this.quantity_at_start.MinimumWidth = 6;
            this.quantity_at_start.Name = "quantity_at_start";
            this.quantity_at_start.ReadOnly = true;
            this.quantity_at_start.ToolTipText = "Number of units originally offered for sale";
            this.quantity_at_start.Width = 64;
            // 
            // num_sold
            // 
            this.num_sold.DataPropertyName = "num_sold";
            this.num_sold.HeaderText = "Qty. Sold";
            this.num_sold.MinimumWidth = 6;
            this.num_sold.Name = "num_sold";
            this.num_sold.ReadOnly = true;
            this.num_sold.Width = 56;
            // 
            // to_be_returned
            // 
            this.to_be_returned.HeaderText = "Qty. To Return";
            this.to_be_returned.MinimumWidth = 6;
            this.to_be_returned.Name = "to_be_returned";
            this.to_be_returned.ReadOnly = true;
            this.to_be_returned.Width = 68;
            // 
            // returned
            // 
            this.returned.HeaderText = "Qty. Returned";
            this.returned.MinimumWidth = 6;
            this.returned.Name = "returned";
            this.returned.Width = 62;
            // 
            // sales_amount
            // 
            this.sales_amount.DataPropertyName = "sales_amount";
            this.sales_amount.HeaderText = "Total Sales";
            this.sales_amount.MinimumWidth = 6;
            this.sales_amount.Name = "sales_amount";
            this.sales_amount.ReadOnly = true;
            this.sales_amount.Width = 58;
            // 
            // to_be_paid
            // 
            this.to_be_paid.HeaderText = "Amt. to Pay";
            this.to_be_paid.MinimumWidth = 6;
            this.to_be_paid.Name = "to_be_paid";
            this.to_be_paid.ReadOnly = true;
            this.to_be_paid.Width = 62;
            // 
            // amt_paid
            // 
            this.amt_paid.HeaderText = "Amt. Paid";
            this.amt_paid.MinimumWidth = 6;
            this.amt_paid.Name = "amt_paid";
            this.amt_paid.Width = 58;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "Location";
            this.description.MinimumWidth = 6;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 240;
            // 
            // pricing
            // 
            this.pricing.DataPropertyName = "pricing";
            this.pricing.HeaderText = "pricing";
            this.pricing.MinimumWidth = 6;
            this.pricing.Name = "pricing";
            this.pricing.Visible = false;
            this.pricing.Width = 125;
            // 
            // settled_returned
            // 
            this.settled_returned.HeaderText = "settled_returned";
            this.settled_returned.MinimumWidth = 6;
            this.settled_returned.Name = "settled_returned";
            this.settled_returned.Visible = false;
            this.settled_returned.Width = 125;
            // 
            // settled_amt_paid
            // 
            this.settled_amt_paid.HeaderText = "settled_amt_paid";
            this.settled_amt_paid.MinimumWidth = 6;
            this.settled_amt_paid.Name = "settled_amt_paid";
            this.settled_amt_paid.Visible = false;
            this.settled_amt_paid.Width = 125;
            // 
            // printRcptButton
            // 
            this.printRcptButton.Enabled = false;
            this.printRcptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printRcptButton.Location = new System.Drawing.Point(22, 599);
            this.printRcptButton.Margin = new System.Windows.Forms.Padding(4);
            this.printRcptButton.Name = "printRcptButton";
            this.printRcptButton.Size = new System.Drawing.Size(227, 46);
            this.printRcptButton.TabIndex = 10;
            this.printRcptButton.Text = "Print Receipt to Sign";
            this.printRcptButton.UseVisualStyleBackColor = true;
            this.printRcptButton.Click += new System.EventHandler(this.printRcptButton_Click);
            // 
            // itemsGridViewLabel
            // 
            this.itemsGridViewLabel.AutoSize = true;
            this.itemsGridViewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemsGridViewLabel.Location = new System.Drawing.Point(26, 303);
            this.itemsGridViewLabel.Name = "itemsGridViewLabel";
            this.itemsGridViewLabel.Size = new System.Drawing.Size(981, 25);
            this.itemsGridViewLabel.TabIndex = 12;
            this.itemsGridViewLabel.Text = "Remaining Items to be Settled with Selected Seller (any items with a blue backgro" +
    "und have already been settled)";
            // 
            // totalAmountDueLabel
            // 
            this.totalAmountDueLabel.AutoSize = true;
            this.totalAmountDueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAmountDueLabel.Location = new System.Drawing.Point(565, 599);
            this.totalAmountDueLabel.Name = "totalAmountDueLabel";
            this.totalAmountDueLabel.Size = new System.Drawing.Size(176, 25);
            this.totalAmountDueLabel.TabIndex = 13;
            this.totalAmountDueLabel.Text = "Amount Due Seller";
            // 
            // totalAmountDue
            // 
            this.totalAmountDue.AutoSize = true;
            this.totalAmountDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAmountDue.Location = new System.Drawing.Point(578, 630);
            this.totalAmountDue.Name = "totalAmountDue";
            this.totalAmountDue.Size = new System.Drawing.Size(61, 25);
            this.totalAmountDue.TabIndex = 14;
            this.totalAmountDue.Text = "$0.00";
            // 
            // amountPaidSellerLabel
            // 
            this.amountPaidSellerLabel.AutoSize = true;
            this.amountPaidSellerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountPaidSellerLabel.Location = new System.Drawing.Point(762, 599);
            this.amountPaidSellerLabel.Name = "amountPaidSellerLabel";
            this.amountPaidSellerLabel.Size = new System.Drawing.Size(179, 25);
            this.amountPaidSellerLabel.TabIndex = 15;
            this.amountPaidSellerLabel.Text = "Amount Paid Seller";
            // 
            // amountPaidSeller
            // 
            this.amountPaidSeller.Enabled = false;
            this.amountPaidSeller.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountPaidSeller.Location = new System.Drawing.Point(781, 627);
            this.amountPaidSeller.Margin = new System.Windows.Forms.Padding(4);
            this.amountPaidSeller.Name = "amountPaidSeller";
            this.amountPaidSeller.Size = new System.Drawing.Size(134, 30);
            this.amountPaidSeller.TabIndex = 10;
            this.amountPaidSeller.Validating += new System.ComponentModel.CancelEventHandler(this.amountPaidSeller_Validating);
            // 
            // currencyLabel
            // 
            this.currencyLabel.AutoSize = true;
            this.currencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currencyLabel.Location = new System.Drawing.Point(756, 630);
            this.currencyLabel.Name = "currencyLabel";
            this.currencyLabel.Size = new System.Drawing.Size(23, 25);
            this.currencyLabel.TabIndex = 16;
            this.currencyLabel.Text = "$";
            // 
            // settlementButton
            // 
            this.settlementButton.Enabled = false;
            this.settlementButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settlementButton.Location = new System.Drawing.Point(985, 599);
            this.settlementButton.Margin = new System.Windows.Forms.Padding(4);
            this.settlementButton.Name = "settlementButton";
            this.settlementButton.Size = new System.Drawing.Size(193, 46);
            this.settlementButton.TabIndex = 17;
            this.settlementButton.Text = "Make Settlement";
            this.settlementButton.UseVisualStyleBackColor = true;
            this.settlementButton.Click += new System.EventHandler(this.settlementButton_Click);
            // 
            // totalSalesLabel
            // 
            this.totalSalesLabel.AutoSize = true;
            this.totalSalesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalSalesLabel.Location = new System.Drawing.Point(274, 599);
            this.totalSalesLabel.Name = "totalSalesLabel";
            this.totalSalesLabel.Size = new System.Drawing.Size(111, 25);
            this.totalSalesLabel.TabIndex = 18;
            this.totalSalesLabel.Text = "Total Sales";
            // 
            // totalSales
            // 
            this.totalSales.AutoSize = true;
            this.totalSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalSales.Location = new System.Drawing.Point(281, 630);
            this.totalSales.Name = "totalSales";
            this.totalSales.Size = new System.Drawing.Size(61, 25);
            this.totalSales.TabIndex = 19;
            this.totalSales.Text = "$0.00";
            // 
            // commissionLabel
            // 
            this.commissionLabel.AutoSize = true;
            this.commissionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commissionLabel.Location = new System.Drawing.Point(412, 599);
            this.commissionLabel.Name = "commissionLabel";
            this.commissionLabel.Size = new System.Drawing.Size(120, 25);
            this.commissionLabel.TabIndex = 20;
            this.commissionLabel.Text = "Commission";
            // 
            // commission
            // 
            this.commission.AutoSize = true;
            this.commission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commission.Location = new System.Drawing.Point(422, 630);
            this.commission.Name = "commission";
            this.commission.Size = new System.Drawing.Size(61, 25);
            this.commission.TabIndex = 21;
            this.commission.Text = "$0.00";
            // 
            // nstructions
            // 
            this.nstructions.AutoSize = true;
            this.nstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nstructions.Location = new System.Drawing.Point(17, 564);
            this.nstructions.Name = "nstructions";
            this.nstructions.Size = new System.Drawing.Size(683, 20);
            this.nstructions.TabIndex = 22;
            this.nstructions.Text = "Choose items for which to make settlement by filling in a value for Qty. Returned" +
    ", even if 0.";
            // 
            // select_unsettled_sellersTableAdapter
            // 
            this.select_unsettled_sellersTableAdapter.ClearBeforeFill = true;
            // 
            // SettleWSellers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nstructions);
            this.Controls.Add(this.commission);
            this.Controls.Add(this.commissionLabel);
            this.Controls.Add(this.totalSales);
            this.Controls.Add(this.totalSalesLabel);
            this.Controls.Add(this.settlementButton);
            this.Controls.Add(this.currencyLabel);
            this.Controls.Add(this.amountPaidSeller);
            this.Controls.Add(this.amountPaidSellerLabel);
            this.Controls.Add(this.totalAmountDue);
            this.Controls.Add(this.totalAmountDueLabel);
            this.Controls.Add(this.itemsGridViewLabel);
            this.Controls.Add(this.printRcptButton);
            this.Controls.Add(this.itemsGridView);
            this.Controls.Add(this.sellersGridView);
            this.Controls.Add(this.sellerFilterGroupBox);
            this.Controls.Add(this.label1);
            this.Name = "SettleWSellers";
            this.Size = new System.Drawing.Size(1168, 658);
            this.sellerFilterGroupBox.ResumeLayout(false);
            this.sellerFilterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sellersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectunsettledsellersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox sellerFilterGroupBox;
        private System.Windows.Forms.Button findSellersButton;
        private System.Windows.Forms.Label lastNameFilterLabel;
        private System.Windows.Forms.TextBox registrationNoFilter;
        private System.Windows.Forms.TextBox lastNameFilter;
        private System.Windows.Forms.Label registrationNoFilterLabel;
        private System.Windows.Forms.Label firstNameFilterLabel;
        private System.Windows.Forms.TextBox firstNameFilter;
        private System.Windows.Forms.DataGridView sellersGridView;
        private System.Windows.Forms.DataGridView itemsGridView;
        private System.Windows.Forms.Button printRcptButton;
        private System.Windows.Forms.Label itemsGridViewLabel;
        private System.Windows.Forms.Label totalAmountDueLabel;
        private System.Windows.Forms.Label totalAmountDue;
        private System.Windows.Forms.Label amountPaidSellerLabel;
        private System.Windows.Forms.TextBox amountPaidSeller;
        private System.Windows.Forms.Label currencyLabel;
        private System.Windows.Forms.Button settlementButton;
        private System.Windows.Forms.Label totalSalesLabel;
        private System.Windows.Forms.Label totalSales;
        private System.Windows.Forms.Label commissionLabel;
        private System.Windows.Forms.Label commission;
        private CoStoreDataSet coStoreDataSet;
        private System.Windows.Forms.BindingSource selectunsettledsellersBindingSource;
        private CoStoreDataSetTableAdapters.select_unsettled_sellersTableAdapter select_unsettled_sellersTableAdapter;
        private System.Windows.Forms.Label nstructions;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salutationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middlenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suffixDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn short_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity_at_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_sold;
        private System.Windows.Forms.DataGridViewTextBoxColumn to_be_returned;
        private System.Windows.Forms.DataGridViewTextBoxColumn returned;
        private System.Windows.Forms.DataGridViewTextBoxColumn sales_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn to_be_paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn amt_paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn pricing;
        private System.Windows.Forms.DataGridViewTextBoxColumn settled_returned;
        private System.Windows.Forms.DataGridViewTextBoxColumn settled_amt_paid;
    }
}
