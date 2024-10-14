namespace ConsignmentPOS
{
    partial class ChangeExistingSales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.selectsalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coStoreDataSet = new ConsignmentPOS.CoStoreDataSet();
            this.saleIDFilter = new System.Windows.Forms.TextBox();
            this.earliestSaleDateFilter = new System.Windows.Forms.DateTimePicker();
            this.saleIDFilterLabel = new System.Windows.Forms.Label();
            this.earliestFilterLabel = new System.Windows.Forms.Label();
            this.latestFilterLabel = new System.Windows.Forms.Label();
            this.latestSaleDateFilter = new System.Windows.Forms.DateTimePicker();
            this.minItemsFilter = new System.Windows.Forms.TextBox();
            this.maxItemsFilter = new System.Windows.Forms.TextBox();
            this.minItemsFilterLabel = new System.Windows.Forms.Label();
            this.maxItemsFilterLabel = new System.Windows.Forms.Label();
            this.changeSaleItemGridView = new System.Windows.Forms.DataGridView();
            this.item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.short_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.original_item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.original_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveSalesButton = new System.Windows.Forms.Button();
            this.saleFilterGroupBox = new System.Windows.Forms.GroupBox();
            this.minAmountFilter = new System.Windows.Forms.TextBox();
            this.latestSaleTimeFilter = new System.Windows.Forms.DateTimePicker();
            this.earliestSaleTimeFilter = new System.Windows.Forms.DateTimePicker();
            this.maxAmountFilterLabel = new System.Windows.Forms.Label();
            this.maxAmountFilter = new System.Windows.Forms.TextBox();
            this.minAmountFilterLabel = new System.Windows.Forms.Label();
            this.totalAmountLabel = new System.Windows.Forms.Label();
            this.whenSoldLabel = new System.Windows.Forms.Label();
            this.noOfItemsLabel = new System.Windows.Forms.Label();
            this.findSalesButton = new System.Windows.Forms.Button();
            this.deleteSaleButton = new System.Windows.Forms.Button();
            this.select_salesTableAdapter = new ConsignmentPOS.CoStoreDataSetTableAdapters.select_salesTableAdapter();
            this.deleteItemButton = new System.Windows.Forms.Button();
            this.changeSaleGridView = new System.Windows.Forms.DataGridView();
            this.sale_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.when_sold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sale_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tendered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.original_when_sold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.original_sale_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.original_tendered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.original_items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.selectsalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeSaleItemGridView)).BeginInit();
            this.saleFilterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeSaleGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change Existing\r\nSales";
            // 
            // selectsalesBindingSource
            // 
            this.selectsalesBindingSource.DataMember = "select_sales";
            this.selectsalesBindingSource.DataSource = this.coStoreDataSet;
            // 
            // coStoreDataSet
            // 
            this.coStoreDataSet.DataSetName = "CoStoreDataSet";
            this.coStoreDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // saleIDFilter
            // 
            this.saleIDFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleIDFilter.Location = new System.Drawing.Point(813, 97);
            this.saleIDFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saleIDFilter.Name = "saleIDFilter";
            this.saleIDFilter.Size = new System.Drawing.Size(125, 27);
            this.saleIDFilter.TabIndex = 3;
            this.saleIDFilter.Validating += new System.ComponentModel.CancelEventHandler(this.saleIDFilter_Validating);
            // 
            // earliestSaleDateFilter
            // 
            this.earliestSaleDateFilter.Checked = false;
            this.earliestSaleDateFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.earliestSaleDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.earliestSaleDateFilter.Location = new System.Drawing.Point(85, 58);
            this.earliestSaleDateFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.earliestSaleDateFilter.MaxDate = new System.DateTime(2023, 10, 21, 0, 0, 0, 0);
            this.earliestSaleDateFilter.MinDate = new System.DateTime(2023, 7, 1, 0, 0, 0, 0);
            this.earliestSaleDateFilter.Name = "earliestSaleDateFilter";
            this.earliestSaleDateFilter.ShowCheckBox = true;
            this.earliestSaleDateFilter.Size = new System.Drawing.Size(147, 27);
            this.earliestSaleDateFilter.TabIndex = 4;
            this.earliestSaleDateFilter.Value = new System.DateTime(2023, 10, 19, 0, 0, 0, 0);
            this.earliestSaleDateFilter.ValueChanged += new System.EventHandler(this.earliestSaleDateFilter_ValueChanged);
            this.earliestSaleDateFilter.Validating += new System.ComponentModel.CancelEventHandler(this.earliestSaleDateFilter_Validating);
            // 
            // saleIDFilterLabel
            // 
            this.saleIDFilterLabel.AutoSize = true;
            this.saleIDFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleIDFilterLabel.Location = new System.Drawing.Point(808, 63);
            this.saleIDFilterLabel.Name = "saleIDFilterLabel";
            this.saleIDFilterLabel.Size = new System.Drawing.Size(76, 25);
            this.saleIDFilterLabel.TabIndex = 5;
            this.saleIDFilterLabel.Text = "Sale ID";
            // 
            // earliestFilterLabel
            // 
            this.earliestFilterLabel.AutoSize = true;
            this.earliestFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.earliestFilterLabel.Location = new System.Drawing.Point(5, 62);
            this.earliestFilterLabel.Name = "earliestFilterLabel";
            this.earliestFilterLabel.Size = new System.Drawing.Size(76, 25);
            this.earliestFilterLabel.TabIndex = 6;
            this.earliestFilterLabel.Text = "Earliest";
            // 
            // latestFilterLabel
            // 
            this.latestFilterLabel.AutoSize = true;
            this.latestFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latestFilterLabel.Location = new System.Drawing.Point(16, 98);
            this.latestFilterLabel.Name = "latestFilterLabel";
            this.latestFilterLabel.Size = new System.Drawing.Size(65, 25);
            this.latestFilterLabel.TabIndex = 8;
            this.latestFilterLabel.Text = "Latest";
            // 
            // latestSaleDateFilter
            // 
            this.latestSaleDateFilter.Checked = false;
            this.latestSaleDateFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latestSaleDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.latestSaleDateFilter.Location = new System.Drawing.Point(85, 99);
            this.latestSaleDateFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.latestSaleDateFilter.MaxDate = new System.DateTime(2023, 10, 21, 0, 0, 0, 0);
            this.latestSaleDateFilter.MinDate = new System.DateTime(2023, 7, 1, 0, 0, 0, 0);
            this.latestSaleDateFilter.Name = "latestSaleDateFilter";
            this.latestSaleDateFilter.ShowCheckBox = true;
            this.latestSaleDateFilter.Size = new System.Drawing.Size(147, 27);
            this.latestSaleDateFilter.TabIndex = 7;
            this.latestSaleDateFilter.Value = new System.DateTime(2023, 10, 19, 0, 0, 0, 0);
            this.latestSaleDateFilter.ValueChanged += new System.EventHandler(this.latestSaleDateFilter_ValueChanged);
            this.latestSaleDateFilter.Validating += new System.ComponentModel.CancelEventHandler(this.latestSaleDateFilter_Validating);
            // 
            // minItemsFilter
            // 
            this.minItemsFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minItemsFilter.Location = new System.Drawing.Point(464, 60);
            this.minItemsFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minItemsFilter.Name = "minItemsFilter";
            this.minItemsFilter.Size = new System.Drawing.Size(125, 27);
            this.minItemsFilter.TabIndex = 9;
            this.minItemsFilter.Validating += new System.ComponentModel.CancelEventHandler(this.minItemsFilter_Validating);
            // 
            // maxItemsFilter
            // 
            this.maxItemsFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxItemsFilter.Location = new System.Drawing.Point(464, 97);
            this.maxItemsFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maxItemsFilter.Name = "maxItemsFilter";
            this.maxItemsFilter.Size = new System.Drawing.Size(125, 27);
            this.maxItemsFilter.TabIndex = 10;
            this.maxItemsFilter.Validating += new System.ComponentModel.CancelEventHandler(this.maxItemsFilter_Validating);
            // 
            // minItemsFilterLabel
            // 
            this.minItemsFilterLabel.AutoSize = true;
            this.minItemsFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minItemsFilterLabel.Location = new System.Drawing.Point(408, 62);
            this.minItemsFilterLabel.Name = "minItemsFilterLabel";
            this.minItemsFilterLabel.Size = new System.Drawing.Size(49, 25);
            this.minItemsFilterLabel.TabIndex = 11;
            this.minItemsFilterLabel.Text = "Min.";
            // 
            // maxItemsFilterLabel
            // 
            this.maxItemsFilterLabel.AutoSize = true;
            this.maxItemsFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxItemsFilterLabel.Location = new System.Drawing.Point(403, 102);
            this.maxItemsFilterLabel.Name = "maxItemsFilterLabel";
            this.maxItemsFilterLabel.Size = new System.Drawing.Size(55, 25);
            this.maxItemsFilterLabel.TabIndex = 12;
            this.maxItemsFilterLabel.Text = "Max.";
            // 
            // changeSaleItemGridView
            // 
            this.changeSaleItemGridView.AllowUserToDeleteRows = false;
            this.changeSaleItemGridView.CausesValidation = false;
            this.changeSaleItemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.changeSaleItemGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.item_id,
            this.short_description,
            this.quantity,
            this.price,
            this.amount,
            this.original_item_id,
            this.original_quantity});
            this.changeSaleItemGridView.Location = new System.Drawing.Point(8, 423);
            this.changeSaleItemGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.changeSaleItemGridView.Name = "changeSaleItemGridView";
            this.changeSaleItemGridView.RowHeadersWidth = 51;
            this.changeSaleItemGridView.RowTemplate.Height = 24;
            this.changeSaleItemGridView.Size = new System.Drawing.Size(1117, 336);
            this.changeSaleItemGridView.TabIndex = 13;
            this.changeSaleItemGridView.Visible = false;
            this.changeSaleItemGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.changeSaleItemGridView_CellMouseEnter);
            this.changeSaleItemGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.changeSaleItemGridView_CellMouseLeave);
            this.changeSaleItemGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.changeSaleItemGridView_CellValueChanged);
            this.changeSaleItemGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.changeSaleItemGridView_RowEnter);
            // 
            // item_id
            // 
            this.item_id.HeaderText = "Item ID";
            this.item_id.MaxInputLength = 9;
            this.item_id.MinimumWidth = 6;
            this.item_id.Name = "item_id";
            this.item_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.item_id.Width = 75;
            // 
            // short_description
            // 
            this.short_description.HeaderText = "Short Description";
            this.short_description.MinimumWidth = 6;
            this.short_description.Name = "short_description";
            this.short_description.ReadOnly = true;
            this.short_description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.short_description.Width = 425;
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
            this.price.Width = 125;
            // 
            // amount
            // 
            this.amount.HeaderText = "Ext. Price";
            this.amount.MinimumWidth = 6;
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.amount.Width = 125;
            // 
            // original_item_id
            // 
            this.original_item_id.HeaderText = "original_item_id";
            this.original_item_id.MinimumWidth = 6;
            this.original_item_id.Name = "original_item_id";
            this.original_item_id.Visible = false;
            this.original_item_id.Width = 125;
            // 
            // original_quantity
            // 
            this.original_quantity.HeaderText = "original_quantity";
            this.original_quantity.MinimumWidth = 6;
            this.original_quantity.Name = "original_quantity";
            this.original_quantity.Visible = false;
            this.original_quantity.Width = 125;
            // 
            // saveSalesButton
            // 
            this.saveSalesButton.Enabled = false;
            this.saveSalesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSalesButton.Location = new System.Drawing.Point(876, 299);
            this.saveSalesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveSalesButton.Name = "saveSalesButton";
            this.saveSalesButton.Size = new System.Drawing.Size(249, 51);
            this.saveSalesButton.TabIndex = 15;
            this.saveSalesButton.Text = "Save Sales";
            this.saveSalesButton.UseVisualStyleBackColor = true;
            this.saveSalesButton.Click += new System.EventHandler(this.saveSalesButton_Click);
            // 
            // saleFilterGroupBox
            // 
            this.saleFilterGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saleFilterGroupBox.Controls.Add(this.minAmountFilter);
            this.saleFilterGroupBox.Controls.Add(this.saleIDFilterLabel);
            this.saleFilterGroupBox.Controls.Add(this.latestSaleTimeFilter);
            this.saleFilterGroupBox.Controls.Add(this.earliestSaleTimeFilter);
            this.saleFilterGroupBox.Controls.Add(this.minItemsFilterLabel);
            this.saleFilterGroupBox.Controls.Add(this.maxAmountFilterLabel);
            this.saleFilterGroupBox.Controls.Add(this.saleIDFilter);
            this.saleFilterGroupBox.Controls.Add(this.maxAmountFilter);
            this.saleFilterGroupBox.Controls.Add(this.earliestSaleDateFilter);
            this.saleFilterGroupBox.Controls.Add(this.minAmountFilterLabel);
            this.saleFilterGroupBox.Controls.Add(this.earliestFilterLabel);
            this.saleFilterGroupBox.Controls.Add(this.totalAmountLabel);
            this.saleFilterGroupBox.Controls.Add(this.latestFilterLabel);
            this.saleFilterGroupBox.Controls.Add(this.whenSoldLabel);
            this.saleFilterGroupBox.Controls.Add(this.latestSaleDateFilter);
            this.saleFilterGroupBox.Controls.Add(this.noOfItemsLabel);
            this.saleFilterGroupBox.Controls.Add(this.minItemsFilter);
            this.saleFilterGroupBox.Controls.Add(this.maxItemsFilterLabel);
            this.saleFilterGroupBox.Controls.Add(this.maxItemsFilter);
            this.saleFilterGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleFilterGroupBox.Location = new System.Drawing.Point(175, 45);
            this.saleFilterGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saleFilterGroupBox.Name = "saleFilterGroupBox";
            this.saleFilterGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saleFilterGroupBox.Size = new System.Drawing.Size(954, 133);
            this.saleFilterGroupBox.TabIndex = 16;
            this.saleFilterGroupBox.TabStop = false;
            this.saleFilterGroupBox.Text = "Sale Filters";
            // 
            // minAmountFilter
            // 
            this.minAmountFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minAmountFilter.Location = new System.Drawing.Point(659, 60);
            this.minAmountFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minAmountFilter.Name = "minAmountFilter";
            this.minAmountFilter.Size = new System.Drawing.Size(125, 27);
            this.minAmountFilter.TabIndex = 20;
            this.minAmountFilter.Validating += new System.ComponentModel.CancelEventHandler(this.minAmountFilter_Validating);
            // 
            // latestSaleTimeFilter
            // 
            this.latestSaleTimeFilter.Checked = false;
            this.latestSaleTimeFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latestSaleTimeFilter.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.latestSaleTimeFilter.Location = new System.Drawing.Point(246, 100);
            this.latestSaleTimeFilter.Margin = new System.Windows.Forms.Padding(4);
            this.latestSaleTimeFilter.Name = "latestSaleTimeFilter";
            this.latestSaleTimeFilter.ShowUpDown = true;
            this.latestSaleTimeFilter.Size = new System.Drawing.Size(147, 26);
            this.latestSaleTimeFilter.TabIndex = 25;
            this.latestSaleTimeFilter.Validating += new System.ComponentModel.CancelEventHandler(this.latestSaleTimeFilter_Validating);
            // 
            // earliestSaleTimeFilter
            // 
            this.earliestSaleTimeFilter.Checked = false;
            this.earliestSaleTimeFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.earliestSaleTimeFilter.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.earliestSaleTimeFilter.Location = new System.Drawing.Point(247, 59);
            this.earliestSaleTimeFilter.Margin = new System.Windows.Forms.Padding(4);
            this.earliestSaleTimeFilter.Name = "earliestSaleTimeFilter";
            this.earliestSaleTimeFilter.ShowUpDown = true;
            this.earliestSaleTimeFilter.Size = new System.Drawing.Size(147, 26);
            this.earliestSaleTimeFilter.TabIndex = 24;
            this.earliestSaleTimeFilter.Validating += new System.ComponentModel.CancelEventHandler(this.earliestSaleTimeFilter_Validating);
            // 
            // maxAmountFilterLabel
            // 
            this.maxAmountFilterLabel.AutoSize = true;
            this.maxAmountFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxAmountFilterLabel.Location = new System.Drawing.Point(598, 98);
            this.maxAmountFilterLabel.Name = "maxAmountFilterLabel";
            this.maxAmountFilterLabel.Size = new System.Drawing.Size(55, 25);
            this.maxAmountFilterLabel.TabIndex = 22;
            this.maxAmountFilterLabel.Text = "Max.";
            // 
            // maxAmountFilter
            // 
            this.maxAmountFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxAmountFilter.Location = new System.Drawing.Point(659, 97);
            this.maxAmountFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maxAmountFilter.Name = "maxAmountFilter";
            this.maxAmountFilter.Size = new System.Drawing.Size(125, 27);
            this.maxAmountFilter.TabIndex = 21;
            this.maxAmountFilter.Validating += new System.ComponentModel.CancelEventHandler(this.maxAmountFilter_Validating);
            // 
            // minAmountFilterLabel
            // 
            this.minAmountFilterLabel.AutoSize = true;
            this.minAmountFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minAmountFilterLabel.Location = new System.Drawing.Point(603, 63);
            this.minAmountFilterLabel.Name = "minAmountFilterLabel";
            this.minAmountFilterLabel.Size = new System.Drawing.Size(49, 25);
            this.minAmountFilterLabel.TabIndex = 19;
            this.minAmountFilterLabel.Text = "Min.";
            // 
            // totalAmountLabel
            // 
            this.totalAmountLabel.AutoSize = true;
            this.totalAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAmountLabel.Location = new System.Drawing.Point(654, 28);
            this.totalAmountLabel.Name = "totalAmountLabel";
            this.totalAmountLabel.Size = new System.Drawing.Size(129, 25);
            this.totalAmountLabel.TabIndex = 0;
            this.totalAmountLabel.Text = "Total Amount";
            // 
            // whenSoldLabel
            // 
            this.whenSoldLabel.AutoSize = true;
            this.whenSoldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whenSoldLabel.Location = new System.Drawing.Point(176, 28);
            this.whenSoldLabel.Name = "whenSoldLabel";
            this.whenSoldLabel.Size = new System.Drawing.Size(110, 25);
            this.whenSoldLabel.TabIndex = 18;
            this.whenSoldLabel.Text = "When Sold";
            // 
            // noOfItemsLabel
            // 
            this.noOfItemsLabel.AutoSize = true;
            this.noOfItemsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noOfItemsLabel.Location = new System.Drawing.Point(459, 28);
            this.noOfItemsLabel.Name = "noOfItemsLabel";
            this.noOfItemsLabel.Size = new System.Drawing.Size(115, 25);
            this.noOfItemsLabel.TabIndex = 17;
            this.noOfItemsLabel.Text = "No. of Items";
            // 
            // findSalesButton
            // 
            this.findSalesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findSalesButton.Location = new System.Drawing.Point(876, 188);
            this.findSalesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.findSalesButton.Name = "findSalesButton";
            this.findSalesButton.Size = new System.Drawing.Size(249, 51);
            this.findSalesButton.TabIndex = 23;
            this.findSalesButton.Text = "Find Sales";
            this.findSalesButton.UseVisualStyleBackColor = true;
            this.findSalesButton.Click += new System.EventHandler(this.findSalesButton_Click);
            // 
            // deleteSaleButton
            // 
            this.deleteSaleButton.Enabled = false;
            this.deleteSaleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteSaleButton.Location = new System.Drawing.Point(876, 245);
            this.deleteSaleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteSaleButton.Name = "deleteSaleButton";
            this.deleteSaleButton.Size = new System.Drawing.Size(249, 50);
            this.deleteSaleButton.TabIndex = 24;
            this.deleteSaleButton.Text = "Delete Selected Sale";
            this.deleteSaleButton.UseVisualStyleBackColor = true;
            this.deleteSaleButton.Click += new System.EventHandler(this.deleteSaleButton_Click);
            // 
            // select_salesTableAdapter
            // 
            this.select_salesTableAdapter.ClearBeforeFill = true;
            // 
            // deleteItemButton
            // 
            this.deleteItemButton.Enabled = false;
            this.deleteItemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteItemButton.Location = new System.Drawing.Point(876, 354);
            this.deleteItemButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteItemButton.Name = "deleteItemButton";
            this.deleteItemButton.Size = new System.Drawing.Size(249, 51);
            this.deleteItemButton.TabIndex = 25;
            this.deleteItemButton.Text = "Delete Selected Item";
            this.deleteItemButton.UseVisualStyleBackColor = true;
            this.deleteItemButton.Click += new System.EventHandler(this.deleteItemButton_Click);
            // 
            // changeSaleGridView
            // 
            this.changeSaleGridView.AllowUserToAddRows = false;
            this.changeSaleGridView.AllowUserToDeleteRows = false;
            this.changeSaleGridView.AutoGenerateColumns = false;
            this.changeSaleGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.changeSaleGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sale_id,
            this.when_sold,
            this.num_items,
            this.sale_amount,
            this.tendered,
            this.items,
            this.original_when_sold,
            this.original_sale_amount,
            this.original_tendered,
            this.original_items});
            this.changeSaleGridView.DataSource = this.selectsalesBindingSource;
            this.changeSaleGridView.Location = new System.Drawing.Point(8, 188);
            this.changeSaleGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.changeSaleGridView.Name = "changeSaleGridView";
            this.changeSaleGridView.RowHeadersWidth = 51;
            this.changeSaleGridView.RowTemplate.Height = 24;
            this.changeSaleGridView.Size = new System.Drawing.Size(857, 217);
            this.changeSaleGridView.TabIndex = 1;
            this.changeSaleGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.changeSaleGridView_CellValueChanged);
            this.changeSaleGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.changeSaleGridView_RowEnter);
            // 
            // sale_id
            // 
            this.sale_id.DataPropertyName = "id";
            this.sale_id.HeaderText = "Sale ID";
            this.sale_id.MinimumWidth = 6;
            this.sale_id.Name = "sale_id";
            this.sale_id.ReadOnly = true;
            this.sale_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sale_id.Width = 75;
            // 
            // when_sold
            // 
            this.when_sold.DataPropertyName = "when_sold";
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            this.when_sold.DefaultCellStyle = dataGridViewCellStyle1;
            this.when_sold.HeaderText = "When Sold";
            this.when_sold.MinimumWidth = 6;
            this.when_sold.Name = "when_sold";
            this.when_sold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.when_sold.Width = 145;
            // 
            // num_items
            // 
            this.num_items.DataPropertyName = "num_items";
            this.num_items.HeaderText = "No. of Items";
            this.num_items.MinimumWidth = 6;
            this.num_items.Name = "num_items";
            this.num_items.ReadOnly = true;
            this.num_items.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.num_items.Width = 125;
            // 
            // sale_amount
            // 
            this.sale_amount.DataPropertyName = "sale_amount";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.sale_amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.sale_amount.HeaderText = "Total Amount";
            this.sale_amount.MinimumWidth = 6;
            this.sale_amount.Name = "sale_amount";
            this.sale_amount.ReadOnly = true;
            this.sale_amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sale_amount.Width = 120;
            // 
            // tendered
            // 
            this.tendered.DataPropertyName = "tendered";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.tendered.DefaultCellStyle = dataGridViewCellStyle3;
            this.tendered.HeaderText = "Amt. Tendered";
            this.tendered.MinimumWidth = 6;
            this.tendered.Name = "tendered";
            this.tendered.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tendered.ToolTipText = "How much the buyer gave the clerk";
            this.tendered.Width = 120;
            // 
            // items
            // 
            this.items.DataPropertyName = "items";
            this.items.HeaderText = "items";
            this.items.MinimumWidth = 6;
            this.items.Name = "items";
            this.items.Visible = false;
            this.items.Width = 125;
            // 
            // original_when_sold
            // 
            dataGridViewCellStyle4.Format = "g";
            dataGridViewCellStyle4.NullValue = null;
            this.original_when_sold.DefaultCellStyle = dataGridViewCellStyle4;
            this.original_when_sold.HeaderText = "original_when_sold";
            this.original_when_sold.MinimumWidth = 6;
            this.original_when_sold.Name = "original_when_sold";
            this.original_when_sold.Visible = false;
            this.original_when_sold.Width = 125;
            // 
            // original_sale_amount
            // 
            this.original_sale_amount.HeaderText = "original_sale_amount";
            this.original_sale_amount.MinimumWidth = 6;
            this.original_sale_amount.Name = "original_sale_amount";
            this.original_sale_amount.Visible = false;
            this.original_sale_amount.Width = 125;
            // 
            // original_tendered
            // 
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.original_tendered.DefaultCellStyle = dataGridViewCellStyle5;
            this.original_tendered.HeaderText = "original_tendered";
            this.original_tendered.MinimumWidth = 6;
            this.original_tendered.Name = "original_tendered";
            this.original_tendered.Visible = false;
            this.original_tendered.Width = 125;
            // 
            // original_items
            // 
            this.original_items.HeaderText = "original_items";
            this.original_items.MinimumWidth = 6;
            this.original_items.Name = "original_items";
            this.original_items.Visible = false;
            this.original_items.Width = 125;
            // 
            // printButton
            // 
            this.printButton.Enabled = false;
            this.printButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButton.Location = new System.Drawing.Point(8, 86);
            this.printButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(161, 92);
            this.printButton.TabIndex = 26;
            this.printButton.Text = "Print Rcpt. for Selected Sale as Saved";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // ChangeExistingSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saleFilterGroupBox);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.deleteSaleButton);
            this.Controls.Add(this.deleteItemButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.changeSaleItemGridView);
            this.Controls.Add(this.changeSaleGridView);
            this.Controls.Add(this.saveSalesButton);
            this.Controls.Add(this.findSalesButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChangeExistingSales";
            this.Size = new System.Drawing.Size(1415, 999);
            this.SizeChanged += new System.EventHandler(this.ChangeExistingSales_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.ChangeExistingSales_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.selectsalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeSaleItemGridView)).EndInit();
            this.saleFilterGroupBox.ResumeLayout(false);
            this.saleFilterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeSaleGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource selectsalesBindingSource;
        private CoStoreDataSet coStoreDataSet;
        private CoStoreDataSetTableAdapters.select_salesTableAdapter select_salesTableAdapter;
        private System.Windows.Forms.TextBox saleIDFilter;
        private System.Windows.Forms.DateTimePicker earliestSaleDateFilter;
        private System.Windows.Forms.Label saleIDFilterLabel;
        private System.Windows.Forms.Label earliestFilterLabel;
        private System.Windows.Forms.Label latestFilterLabel;
        private System.Windows.Forms.DateTimePicker latestSaleDateFilter;
        private System.Windows.Forms.TextBox minItemsFilter;
        private System.Windows.Forms.TextBox maxItemsFilter;
        private System.Windows.Forms.Label minItemsFilterLabel;
        private System.Windows.Forms.Label maxItemsFilterLabel;
        private System.Windows.Forms.DataGridView changeSaleItemGridView;
        private System.Windows.Forms.Button saveSalesButton;
        private System.Windows.Forms.GroupBox saleFilterGroupBox;
        private System.Windows.Forms.Label noOfItemsLabel;
        private System.Windows.Forms.Label whenSoldLabel;
        private System.Windows.Forms.Label totalAmountLabel;
        private System.Windows.Forms.Label minAmountFilterLabel;
        private System.Windows.Forms.TextBox minAmountFilter;
        private System.Windows.Forms.TextBox maxAmountFilter;
        private System.Windows.Forms.Label maxAmountFilterLabel;
        private System.Windows.Forms.Button findSalesButton;
        private System.Windows.Forms.DateTimePicker latestSaleTimeFilter;
        private System.Windows.Forms.DateTimePicker earliestSaleTimeFilter;
        private System.Windows.Forms.Button deleteSaleButton;
        private System.Windows.Forms.Button deleteItemButton;
        private System.Windows.Forms.DataGridView changeSaleGridView;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn sale_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn when_sold;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_items;
        private System.Windows.Forms.DataGridViewTextBoxColumn sale_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn tendered;
        private System.Windows.Forms.DataGridViewTextBoxColumn items;
        private System.Windows.Forms.DataGridViewTextBoxColumn original_when_sold;
        private System.Windows.Forms.DataGridViewTextBoxColumn original_sale_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn original_tendered;
        private System.Windows.Forms.DataGridViewTextBoxColumn original_items;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn short_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn original_item_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn original_quantity;
    }
}
