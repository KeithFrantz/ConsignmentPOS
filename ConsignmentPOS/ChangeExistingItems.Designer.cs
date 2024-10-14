namespace ConsignmentPOS
{
    partial class ChangeExistingItems
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.screenLabel = new System.Windows.Forms.Label();
            this.itemFiltersGroupBox = new System.Windows.Forms.GroupBox();
            this.findItemsButton = new System.Windows.Forms.Button();
            this.itemIDFilterLabel = new System.Windows.Forms.Label();
            this.shortDescriptionFilter = new System.Windows.Forms.TextBox();
            this.itemIDFilter = new System.Windows.Forms.TextBox();
            this.shortDescriptionFilterLabel = new System.Windows.Forms.Label();
            this.sellerFilterLabel = new System.Windows.Forms.Label();
            this.sellerFilter = new System.Windows.Forms.ComboBox();
            this.itemGridViewLabel = new System.Windows.Forms.Label();
            this.longDescTextBoxLabel = new System.Windows.Forms.Label();
            this.longDescTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.locationLabel = new System.Windows.Forms.Label();
            this.priceDataGridViewLabel = new System.Windows.Forms.Label();
            this.locationCB = new System.Windows.Forms.ComboBox();
            this.locationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coStoreDataSet = new ConsignmentPOS.CoStoreDataSet();
            this.priceDataGridView = new System.Windows.Forms.DataGridView();
            this.quantity_break = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellerLabel = new System.Windows.Forms.Label();
            this.seller = new System.Windows.Forms.ComboBox();
            this.qtyForSaleLabel = new System.Windows.Forms.Label();
            this.qtyForSale = new System.Windows.Forms.TextBox();
            this.qtySoldLabel = new System.Windows.Forms.Label();
            this.qtySold = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.locationTableAdapter = new ConsignmentPOS.CoStoreDataSetTableAdapters.locationTableAdapter();
            this.sellerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sellerTableAdapter = new ConsignmentPOS.CoStoreDataSetTableAdapters.sellerTableAdapter();
            this.discardButton = new System.Windows.Forms.Button();
            this.shortDescription = new System.Windows.Forms.TextBox();
            this.shortDescriptionLabel = new System.Windows.Forms.Label();
            this.itemGridViewLabel2 = new System.Windows.Forms.Label();
            this.modifiedPricing = new System.Windows.Forms.Label();
            this.itemGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.short_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seller_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.long_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity_at_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_sold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity_returned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selectitemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coStoreDataSet1 = new ConsignmentPOS.CoStoreDataSet();
            this.select_itemsTableAdapter = new ConsignmentPOS.CoStoreDataSetTableAdapters.select_itemsTableAdapter();
            this.itemFiltersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectitemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // screenLabel
            // 
            this.screenLabel.AutoSize = true;
            this.screenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.screenLabel.Location = new System.Drawing.Point(21, 32);
            this.screenLabel.Name = "screenLabel";
            this.screenLabel.Size = new System.Drawing.Size(207, 25);
            this.screenLabel.TabIndex = 0;
            this.screenLabel.Text = "Change Existing Items";
            // 
            // itemFiltersGroupBox
            // 
            this.itemFiltersGroupBox.Controls.Add(this.findItemsButton);
            this.itemFiltersGroupBox.Controls.Add(this.itemIDFilterLabel);
            this.itemFiltersGroupBox.Controls.Add(this.shortDescriptionFilter);
            this.itemFiltersGroupBox.Controls.Add(this.itemIDFilter);
            this.itemFiltersGroupBox.Controls.Add(this.shortDescriptionFilterLabel);
            this.itemFiltersGroupBox.Controls.Add(this.sellerFilterLabel);
            this.itemFiltersGroupBox.Controls.Add(this.sellerFilter);
            this.itemFiltersGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemFiltersGroupBox.Location = new System.Drawing.Point(249, 32);
            this.itemFiltersGroupBox.Name = "itemFiltersGroupBox";
            this.itemFiltersGroupBox.Size = new System.Drawing.Size(1007, 140);
            this.itemFiltersGroupBox.TabIndex = 1;
            this.itemFiltersGroupBox.TabStop = false;
            this.itemFiltersGroupBox.Text = "Item Filters";
            // 
            // findItemsButton
            // 
            this.findItemsButton.Location = new System.Drawing.Point(868, 93);
            this.findItemsButton.Name = "findItemsButton";
            this.findItemsButton.Size = new System.Drawing.Size(133, 42);
            this.findItemsButton.TabIndex = 43;
            this.findItemsButton.Text = "Find Items";
            this.findItemsButton.UseVisualStyleBackColor = true;
            this.findItemsButton.Click += new System.EventHandler(this.findItemsButton_Click);
            // 
            // itemIDFilterLabel
            // 
            this.itemIDFilterLabel.AutoSize = true;
            this.itemIDFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemIDFilterLabel.Location = new System.Drawing.Point(7, 71);
            this.itemIDFilterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.itemIDFilterLabel.Name = "itemIDFilterLabel";
            this.itemIDFilterLabel.Size = new System.Drawing.Size(73, 25);
            this.itemIDFilterLabel.TabIndex = 42;
            this.itemIDFilterLabel.Text = "Item ID";
            // 
            // shortDescriptionFilter
            // 
            this.shortDescriptionFilter.Location = new System.Drawing.Point(121, 99);
            this.shortDescriptionFilter.Name = "shortDescriptionFilter";
            this.shortDescriptionFilter.Size = new System.Drawing.Size(735, 30);
            this.shortDescriptionFilter.TabIndex = 39;
            // 
            // itemIDFilter
            // 
            this.itemIDFilter.Location = new System.Drawing.Point(6, 97);
            this.itemIDFilter.Name = "itemIDFilter";
            this.itemIDFilter.Size = new System.Drawing.Size(95, 30);
            this.itemIDFilter.TabIndex = 41;
            this.itemIDFilter.Validating += new System.ComponentModel.CancelEventHandler(this.itemIDFilter_Validating);
            // 
            // shortDescriptionFilterLabel
            // 
            this.shortDescriptionFilterLabel.AutoSize = true;
            this.shortDescriptionFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortDescriptionFilterLabel.Location = new System.Drawing.Point(116, 71);
            this.shortDescriptionFilterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.shortDescriptionFilterLabel.Name = "shortDescriptionFilterLabel";
            this.shortDescriptionFilterLabel.Size = new System.Drawing.Size(161, 25);
            this.shortDescriptionFilterLabel.TabIndex = 40;
            this.shortDescriptionFilterLabel.Text = "Short Description";
            // 
            // sellerFilterLabel
            // 
            this.sellerFilterLabel.AutoSize = true;
            this.sellerFilterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sellerFilterLabel.Location = new System.Drawing.Point(116, 0);
            this.sellerFilterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sellerFilterLabel.Name = "sellerFilterLabel";
            this.sellerFilterLabel.Size = new System.Drawing.Size(278, 25);
            this.sellerFilterLabel.TabIndex = 38;
            this.sellerFilterLabel.Text = "Seller\'s Registration and Name";
            // 
            // sellerFilter
            // 
            this.sellerFilter.DisplayMember = "sname";
            this.sellerFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sellerFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sellerFilter.FormattingEnabled = true;
            this.sellerFilter.Location = new System.Drawing.Point(121, 30);
            this.sellerFilter.Margin = new System.Windows.Forms.Padding(4);
            this.sellerFilter.Name = "sellerFilter";
            this.sellerFilter.Size = new System.Drawing.Size(735, 33);
            this.sellerFilter.TabIndex = 37;
            this.sellerFilter.ValueMember = "id";
            // 
            // itemGridViewLabel
            // 
            this.itemGridViewLabel.AutoSize = true;
            this.itemGridViewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemGridViewLabel.Location = new System.Drawing.Point(22, 114);
            this.itemGridViewLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.itemGridViewLabel.Name = "itemGridViewLabel";
            this.itemGridViewLabel.Size = new System.Drawing.Size(138, 25);
            this.itemGridViewLabel.TabIndex = 44;
            this.itemGridViewLabel.Text = "Select Item To";
            // 
            // longDescTextBoxLabel
            // 
            this.longDescTextBoxLabel.AutoSize = true;
            this.longDescTextBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longDescTextBoxLabel.Location = new System.Drawing.Point(21, 549);
            this.longDescTextBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.longDescTextBoxLabel.Name = "longDescTextBoxLabel";
            this.longDescTextBoxLabel.Size = new System.Drawing.Size(452, 25);
            this.longDescTextBoxLabel.TabIndex = 54;
            this.longDescTextBoxLabel.Text = "Long (up to 1000 characters) Description (optional)";
            // 
            // longDescTextBox
            // 
            this.longDescTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longDescTextBox.Location = new System.Drawing.Point(26, 578);
            this.longDescTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.longDescTextBox.MaxLength = 1000;
            this.longDescTextBox.Multiline = true;
            this.longDescTextBox.Name = "longDescTextBox";
            this.longDescTextBox.Size = new System.Drawing.Size(822, 147);
            this.longDescTextBox.TabIndex = 53;
            this.longDescTextBox.TextChanged += new System.EventHandler(this.longDescTextBox_TextChanged);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(866, 607);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(173, 47);
            this.saveButton.TabIndex = 52;
            this.saveButton.Text = "Save Changes";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationLabel.Location = new System.Drawing.Point(21, 486);
            this.locationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(215, 25);
            this.locationLabel.TabIndex = 51;
            this.locationLabel.Text = "Item Location (optional)";
            // 
            // priceDataGridViewLabel
            // 
            this.priceDataGridViewLabel.AutoSize = true;
            this.priceDataGridViewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceDataGridViewLabel.Location = new System.Drawing.Point(870, 355);
            this.priceDataGridViewLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.priceDataGridViewLabel.Name = "priceDataGridViewLabel";
            this.priceDataGridViewLabel.Size = new System.Drawing.Size(343, 25);
            this.priceDataGridViewLabel.TabIndex = 50;
            this.priceDataGridViewLabel.Text = "Price Breaks (ascending order by qty.)";
            // 
            // locationCB
            // 
            this.locationCB.DataSource = this.locationBindingSource;
            this.locationCB.DisplayMember = "description";
            this.locationCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationCB.FormattingEnabled = true;
            this.locationCB.Location = new System.Drawing.Point(26, 512);
            this.locationCB.Margin = new System.Windows.Forms.Padding(4);
            this.locationCB.Name = "locationCB";
            this.locationCB.Size = new System.Drawing.Size(558, 33);
            this.locationCB.TabIndex = 49;
            this.locationCB.ValueMember = "id";
            this.locationCB.SelectedIndexChanged += new System.EventHandler(this.locationCB_SelectedIndexChanged);
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
            // priceDataGridView
            // 
            this.priceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.priceDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.quantity_break,
            this.price});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.priceDataGridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.priceDataGridView.Location = new System.Drawing.Point(875, 383);
            this.priceDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.priceDataGridView.Name = "priceDataGridView";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.priceDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.priceDataGridView.RowHeadersWidth = 51;
            this.priceDataGridView.Size = new System.Drawing.Size(356, 202);
            this.priceDataGridView.TabIndex = 48;
            this.priceDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.priceDataGridView_CellValueChanged);
            this.priceDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.priceDataGridView_RowsRemoved);
            // 
            // quantity_break
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantity_break.DefaultCellStyle = dataGridViewCellStyle5;
            this.quantity_break.HeaderText = "Minimum Qty.";
            this.quantity_break.MinimumWidth = 6;
            this.quantity_break.Name = "quantity_break";
            this.quantity_break.Width = 106;
            // 
            // price
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.DefaultCellStyle = dataGridViewCellStyle6;
            this.price.HeaderText = "Price Each";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            this.price.Width = 106;
            // 
            // sellerLabel
            // 
            this.sellerLabel.AutoSize = true;
            this.sellerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sellerLabel.Location = new System.Drawing.Point(21, 418);
            this.sellerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sellerLabel.Name = "sellerLabel";
            this.sellerLabel.Size = new System.Drawing.Size(278, 25);
            this.sellerLabel.TabIndex = 45;
            this.sellerLabel.Text = "Seller\'s Registration and Name";
            // 
            // seller
            // 
            this.seller.DisplayMember = "sname";
            this.seller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seller.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seller.FormattingEnabled = true;
            this.seller.Location = new System.Drawing.Point(26, 447);
            this.seller.Margin = new System.Windows.Forms.Padding(4);
            this.seller.Name = "seller";
            this.seller.Size = new System.Drawing.Size(822, 33);
            this.seller.TabIndex = 44;
            this.seller.ValueMember = "id";
            this.seller.SelectedIndexChanged += new System.EventHandler(this.seller_SelectedIndexChanged);
            // 
            // qtyForSaleLabel
            // 
            this.qtyForSaleLabel.AutoSize = true;
            this.qtyForSaleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyForSaleLabel.Location = new System.Drawing.Point(600, 484);
            this.qtyForSaleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.qtyForSaleLabel.Name = "qtyForSaleLabel";
            this.qtyForSaleLabel.Size = new System.Drawing.Size(120, 25);
            this.qtyForSaleLabel.TabIndex = 44;
            this.qtyForSaleLabel.Text = "Qty. for Sale";
            // 
            // qtyForSale
            // 
            this.qtyForSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyForSale.Location = new System.Drawing.Point(614, 515);
            this.qtyForSale.Name = "qtyForSale";
            this.qtyForSale.Size = new System.Drawing.Size(94, 30);
            this.qtyForSale.TabIndex = 44;
            this.qtyForSale.TextChanged += new System.EventHandler(this.qtyForSale_TextChanged);
            this.qtyForSale.Validating += new System.ComponentModel.CancelEventHandler(this.qtyForSale_Validating);
            // 
            // qtySoldLabel
            // 
            this.qtySoldLabel.AutoSize = true;
            this.qtySoldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtySoldLabel.Location = new System.Drawing.Point(738, 484);
            this.qtySoldLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.qtySoldLabel.Name = "qtySoldLabel";
            this.qtySoldLabel.Size = new System.Drawing.Size(93, 25);
            this.qtySoldLabel.TabIndex = 55;
            this.qtySoldLabel.Text = "Qty. Sold";
            // 
            // qtySold
            // 
            this.qtySold.AutoSize = true;
            this.qtySold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtySold.Location = new System.Drawing.Point(773, 515);
            this.qtySold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.qtySold.Name = "qtySold";
            this.qtySold.Size = new System.Drawing.Size(23, 25);
            this.qtySold.TabIndex = 56;
            this.qtySold.Text = "0";
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(959, 672);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(171, 47);
            this.deleteButton.TabIndex = 57;
            this.deleteButton.Text = "Delete Item";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // locationTableAdapter
            // 
            this.locationTableAdapter.ClearBeforeFill = true;
            // 
            // sellerBindingSource
            // 
            this.sellerBindingSource.DataMember = "seller";
            this.sellerBindingSource.DataSource = this.coStoreDataSet;
            // 
            // sellerTableAdapter
            // 
            this.sellerTableAdapter.ClearBeforeFill = true;
            // 
            // discardButton
            // 
            this.discardButton.Enabled = false;
            this.discardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discardButton.Location = new System.Drawing.Point(1050, 607);
            this.discardButton.Margin = new System.Windows.Forms.Padding(4);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(186, 47);
            this.discardButton.TabIndex = 58;
            this.discardButton.Text = "Discard Changes";
            this.discardButton.UseVisualStyleBackColor = true;
            this.discardButton.Click += new System.EventHandler(this.discardButton_Click);
            // 
            // shortDescription
            // 
            this.shortDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortDescription.Location = new System.Drawing.Point(26, 381);
            this.shortDescription.Name = "shortDescription";
            this.shortDescription.Size = new System.Drawing.Size(822, 30);
            this.shortDescription.TabIndex = 44;
            this.shortDescription.TextChanged += new System.EventHandler(this.shortDescription_TextChanged);
            // 
            // shortDescriptionLabel
            // 
            this.shortDescriptionLabel.AutoSize = true;
            this.shortDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortDescriptionLabel.Location = new System.Drawing.Point(21, 354);
            this.shortDescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.shortDescriptionLabel.Name = "shortDescriptionLabel";
            this.shortDescriptionLabel.Size = new System.Drawing.Size(161, 25);
            this.shortDescriptionLabel.TabIndex = 44;
            this.shortDescriptionLabel.Text = "Short Description";
            // 
            // itemGridViewLabel2
            // 
            this.itemGridViewLabel2.AutoSize = true;
            this.itemGridViewLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemGridViewLabel2.Location = new System.Drawing.Point(22, 139);
            this.itemGridViewLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.itemGridViewLabel2.Name = "itemGridViewLabel2";
            this.itemGridViewLabel2.Size = new System.Drawing.Size(165, 25);
            this.itemGridViewLabel2.TabIndex = 59;
            this.itemGridViewLabel2.Text = "Change or Delete";
            // 
            // modifiedPricing
            // 
            this.modifiedPricing.AutoSize = true;
            this.modifiedPricing.Location = new System.Drawing.Point(804, 549);
            this.modifiedPricing.Name = "modifiedPricing";
            this.modifiedPricing.Size = new System.Drawing.Size(0, 16);
            this.modifiedPricing.TabIndex = 60;
            this.modifiedPricing.Visible = false;
            // 
            // itemGridView
            // 
            this.itemGridView.AllowUserToAddRows = false;
            this.itemGridView.AllowUserToDeleteRows = false;
            this.itemGridView.AutoGenerateColumns = false;
            this.itemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.short_description,
            this.seller_id,
            this.long_description,
            this.location_id,
            this.description,
            this.quantity_at_start,
            this.num_sold,
            this.quantity_returned,
            this.pricing});
            this.itemGridView.DataSource = this.selectitemsBindingSource;
            this.itemGridView.Location = new System.Drawing.Point(26, 173);
            this.itemGridView.Name = "itemGridView";
            this.itemGridView.ReadOnly = true;
            this.itemGridView.RowHeadersWidth = 51;
            this.itemGridView.RowTemplate.Height = 24;
            this.itemGridView.Size = new System.Drawing.Size(1230, 178);
            this.itemGridView.TabIndex = 2;
            this.itemGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemGridView_RowEnter);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 46;
            // 
            // short_description
            // 
            this.short_description.DataPropertyName = "short_description";
            this.short_description.HeaderText = "Short Description";
            this.short_description.MinimumWidth = 6;
            this.short_description.Name = "short_description";
            this.short_description.ReadOnly = true;
            this.short_description.Width = 420;
            // 
            // seller_id
            // 
            this.seller_id.DataPropertyName = "seller_id";
            this.seller_id.HeaderText = "Seller\'s Reg. #";
            this.seller_id.MinimumWidth = 6;
            this.seller_id.Name = "seller_id";
            this.seller_id.ReadOnly = true;
            this.seller_id.Width = 50;
            // 
            // long_description
            // 
            this.long_description.DataPropertyName = "long_description";
            this.long_description.HeaderText = "long_description";
            this.long_description.MinimumWidth = 6;
            this.long_description.Name = "long_description";
            this.long_description.ReadOnly = true;
            this.long_description.Visible = false;
            this.long_description.Width = 125;
            // 
            // location_id
            // 
            this.location_id.DataPropertyName = "location_id";
            this.location_id.HeaderText = "location_id";
            this.location_id.MinimumWidth = 6;
            this.location_id.Name = "location_id";
            this.location_id.ReadOnly = true;
            this.location_id.Visible = false;
            this.location_id.Width = 125;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "Location";
            this.description.MinimumWidth = 6;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 225;
            // 
            // quantity_at_start
            // 
            this.quantity_at_start.DataPropertyName = "quantity_at_start";
            this.quantity_at_start.HeaderText = "Qty. for Sale";
            this.quantity_at_start.MinimumWidth = 6;
            this.quantity_at_start.Name = "quantity_at_start";
            this.quantity_at_start.ReadOnly = true;
            this.quantity_at_start.Width = 64;
            // 
            // num_sold
            // 
            this.num_sold.DataPropertyName = "num_sold";
            this.num_sold.HeaderText = "Qty. Sold";
            this.num_sold.MinimumWidth = 6;
            this.num_sold.Name = "num_sold";
            this.num_sold.ReadOnly = true;
            this.num_sold.Width = 64;
            // 
            // quantity_returned
            // 
            this.quantity_returned.DataPropertyName = "quantity_returned";
            this.quantity_returned.HeaderText = "quantity_returned";
            this.quantity_returned.MinimumWidth = 6;
            this.quantity_returned.Name = "quantity_returned";
            this.quantity_returned.ReadOnly = true;
            this.quantity_returned.Visible = false;
            this.quantity_returned.Width = 125;
            // 
            // pricing
            // 
            this.pricing.DataPropertyName = "pricing";
            this.pricing.HeaderText = "pricing";
            this.pricing.MinimumWidth = 6;
            this.pricing.Name = "pricing";
            this.pricing.ReadOnly = true;
            this.pricing.Visible = false;
            this.pricing.Width = 125;
            // 
            // selectitemsBindingSource
            // 
            this.selectitemsBindingSource.DataMember = "select_items";
            this.selectitemsBindingSource.DataSource = this.coStoreDataSet1;
            // 
            // coStoreDataSet1
            // 
            this.coStoreDataSet1.DataSetName = "CoStoreDataSet";
            this.coStoreDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // select_itemsTableAdapter
            // 
            this.select_itemsTableAdapter.ClearBeforeFill = true;
            // 
            // ChangeExistingItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.modifiedPricing);
            this.Controls.Add(this.itemGridViewLabel2);
            this.Controls.Add(this.shortDescriptionLabel);
            this.Controls.Add(this.shortDescription);
            this.Controls.Add(this.discardButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.qtySold);
            this.Controls.Add(this.qtySoldLabel);
            this.Controls.Add(this.qtyForSale);
            this.Controls.Add(this.qtyForSaleLabel);
            this.Controls.Add(this.sellerLabel);
            this.Controls.Add(this.longDescTextBoxLabel);
            this.Controls.Add(this.seller);
            this.Controls.Add(this.longDescTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.priceDataGridViewLabel);
            this.Controls.Add(this.locationCB);
            this.Controls.Add(this.priceDataGridView);
            this.Controls.Add(this.itemGridViewLabel);
            this.Controls.Add(this.itemGridView);
            this.Controls.Add(this.itemFiltersGroupBox);
            this.Controls.Add(this.screenLabel);
            this.Name = "ChangeExistingItems";
            this.Size = new System.Drawing.Size(1171, 700);
            this.VisibleChanged += new System.EventHandler(this.ChangeExistingItems_VisibleChanged);
            this.itemFiltersGroupBox.ResumeLayout(false);
            this.itemFiltersGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sellerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectitemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label screenLabel;
        private System.Windows.Forms.GroupBox itemFiltersGroupBox;
        private System.Windows.Forms.Label sellerFilterLabel;
        private System.Windows.Forms.ComboBox sellerFilter;
        private System.Windows.Forms.TextBox shortDescriptionFilter;
        private System.Windows.Forms.Label itemIDFilterLabel;
        private System.Windows.Forms.Label shortDescriptionFilterLabel;
        private System.Windows.Forms.Button findItemsButton;
        private System.Windows.Forms.Label itemGridViewLabel;
        private System.Windows.Forms.Label longDescTextBoxLabel;
        private System.Windows.Forms.TextBox longDescTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Label priceDataGridViewLabel;
        private System.Windows.Forms.ComboBox locationCB;
        private System.Windows.Forms.DataGridView priceDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity_break;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.Label sellerLabel;
        private System.Windows.Forms.ComboBox seller;
        private System.Windows.Forms.Label qtyForSaleLabel;
        private System.Windows.Forms.TextBox qtyForSale;
        private System.Windows.Forms.Label qtySoldLabel;
        private System.Windows.Forms.Label qtySold;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.BindingSource locationBindingSource;
        private CoStoreDataSet coStoreDataSet;
        private CoStoreDataSetTableAdapters.locationTableAdapter locationTableAdapter;
        private System.Windows.Forms.BindingSource sellerBindingSource;
        private CoStoreDataSetTableAdapters.sellerTableAdapter sellerTableAdapter;
        private System.Windows.Forms.Button discardButton;
        private System.Windows.Forms.TextBox itemIDFilter;
        private System.Windows.Forms.TextBox shortDescription;
        private System.Windows.Forms.Label shortDescriptionLabel;
        private System.Windows.Forms.Label itemGridViewLabel2;
        private System.Windows.Forms.Label modifiedPricing;
        private System.Windows.Forms.DataGridView itemGridView;
        private System.Windows.Forms.BindingSource selectitemsBindingSource;
        private CoStoreDataSet coStoreDataSet1;
        private CoStoreDataSetTableAdapters.select_itemsTableAdapter select_itemsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn short_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn seller_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn long_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn location_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity_at_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_sold;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity_returned;
        private System.Windows.Forms.DataGridViewTextBoxColumn pricing;
    }
}
