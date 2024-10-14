namespace ConsignmentPOS
{
    partial class EnterNewItems
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.registrationNoFilter = new System.Windows.Forms.TextBox();
            this.registrationNoFilterLabel = new System.Windows.Forms.Label();
            this.sellerFilterGroupBox = new System.Windows.Forms.GroupBox();
            this.findSellersButton = new System.Windows.Forms.Button();
            this.lastNameFilterLabel = new System.Windows.Forms.Label();
            this.lastNameFilter = new System.Windows.Forms.TextBox();
            this.firstNameFilterLabel = new System.Windows.Forms.Label();
            this.firstNameFilter = new System.Windows.Forms.TextBox();
            this.seller = new System.Windows.Forms.ComboBox();
            this.selectsellersasstringsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coStoreDataSet = new ConsignmentPOS.CoStoreDataSet();
            this.select_sellers_as_stringsTableAdapter = new ConsignmentPOS.CoStoreDataSetTableAdapters.select_sellers_as_stringsTableAdapter();
            this.sellerLabel = new System.Windows.Forms.Label();
            this.itemDataGridView = new System.Windows.Forms.DataGridView();
            this.shortDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyAtStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridView = new System.Windows.Forms.DataGridView();
            this.quantity_break = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationCB = new System.Windows.Forms.ComboBox();
            this.locationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.locationTableAdapter = new ConsignmentPOS.CoStoreDataSetTableAdapters.locationTableAdapter();
            this.itemDataGridViewLabel = new System.Windows.Forms.Label();
            this.priceDataGridViewLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.longDescTextBox = new System.Windows.Forms.TextBox();
            this.longDescTextBoxLabel = new System.Windows.Forms.Label();
            this.sellerFilterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectsellersasstringsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 25);
            this.label1.TabIndex = 32;
            this.label1.Text = "Enter New Items";
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
            this.sellerFilterGroupBox.Location = new System.Drawing.Point(329, 52);
            this.sellerFilterGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.sellerFilterGroupBox.Name = "sellerFilterGroupBox";
            this.sellerFilterGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.sellerFilterGroupBox.Size = new System.Drawing.Size(916, 96);
            this.sellerFilterGroupBox.TabIndex = 33;
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
            // lastNameFilter
            // 
            this.lastNameFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameFilter.Location = new System.Drawing.Point(481, 57);
            this.lastNameFilter.Margin = new System.Windows.Forms.Padding(4);
            this.lastNameFilter.Name = "lastNameFilter";
            this.lastNameFilter.Size = new System.Drawing.Size(265, 30);
            this.lastNameFilter.TabIndex = 6;
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
            // seller
            // 
            this.seller.DataSource = this.selectsellersasstringsBindingSource;
            this.seller.DisplayMember = "sname";
            this.seller.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seller.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seller.FormattingEnabled = true;
            this.seller.Location = new System.Drawing.Point(329, 169);
            this.seller.Margin = new System.Windows.Forms.Padding(4);
            this.seller.Name = "seller";
            this.seller.Size = new System.Drawing.Size(747, 33);
            this.seller.TabIndex = 35;
            this.seller.ValueMember = "id";
            // 
            // selectsellersasstringsBindingSource
            // 
            this.selectsellersasstringsBindingSource.DataMember = "select_sellers_as_strings";
            this.selectsellersasstringsBindingSource.DataSource = this.coStoreDataSet;
            // 
            // coStoreDataSet
            // 
            this.coStoreDataSet.DataSetName = "CoStoreDataSet";
            this.coStoreDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // select_sellers_as_stringsTableAdapter
            // 
            this.select_sellers_as_stringsTableAdapter.ClearBeforeFill = true;
            // 
            // sellerLabel
            // 
            this.sellerLabel.AutoSize = true;
            this.sellerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sellerLabel.Location = new System.Drawing.Point(19, 172);
            this.sellerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sellerLabel.Name = "sellerLabel";
            this.sellerLabel.Size = new System.Drawing.Size(278, 25);
            this.sellerLabel.TabIndex = 36;
            this.sellerLabel.Text = "Seller\'s Registration and Name";
            // 
            // itemDataGridView
            // 
            this.itemDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shortDesc,
            this.qtyAtStart,
            this.longDesc,
            this.location,
            this.pricing});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.itemDataGridView.EnableHeadersVisualStyles = false;
            this.itemDataGridView.Location = new System.Drawing.Point(17, 251);
            this.itemDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.itemDataGridView.Name = "itemDataGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.itemDataGridView.RowHeadersWidth = 51;
            this.itemDataGridView.Size = new System.Drawing.Size(835, 290);
            this.itemDataGridView.TabIndex = 37;
            this.itemDataGridView.Visible = false;
            this.itemDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemDataGridView_CellValueChanged);
            this.itemDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemDataGridView_RowEnter);
            // 
            // shortDesc
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shortDesc.DefaultCellStyle = dataGridViewCellStyle1;
            this.shortDesc.HeaderText = "Short (up to 40 characters) Description";
            this.shortDesc.MaxInputLength = 40;
            this.shortDesc.MinimumWidth = 6;
            this.shortDesc.Name = "shortDesc";
            this.shortDesc.ToolTipText = "Enter a description of the item";
            this.shortDesc.Width = 468;
            // 
            // qtyAtStart
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyAtStart.DefaultCellStyle = dataGridViewCellStyle2;
            this.qtyAtStart.HeaderText = "Qty. for Sale";
            this.qtyAtStart.MaxInputLength = 10;
            this.qtyAtStart.MinimumWidth = 6;
            this.qtyAtStart.Name = "qtyAtStart";
            this.qtyAtStart.Width = 90;
            // 
            // longDesc
            // 
            this.longDesc.HeaderText = "Long Description";
            this.longDesc.MinimumWidth = 6;
            this.longDesc.Name = "longDesc";
            this.longDesc.Visible = false;
            this.longDesc.Width = 125;
            // 
            // location
            // 
            this.location.HeaderText = "Location";
            this.location.MinimumWidth = 6;
            this.location.Name = "location";
            this.location.Visible = false;
            this.location.Width = 125;
            // 
            // pricing
            // 
            this.pricing.HeaderText = "Pricing";
            this.pricing.MinimumWidth = 6;
            this.pricing.Name = "pricing";
            this.pricing.Visible = false;
            this.pricing.Width = 125;
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
            this.priceDataGridView.Location = new System.Drawing.Point(879, 251);
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
            this.priceDataGridView.Size = new System.Drawing.Size(356, 198);
            this.priceDataGridView.TabIndex = 38;
            this.priceDataGridView.Visible = false;
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
            // locationCB
            // 
            this.locationCB.DataSource = this.locationBindingSource;
            this.locationCB.DisplayMember = "description";
            this.locationCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationCB.FormattingEnabled = true;
            this.locationCB.Location = new System.Drawing.Point(879, 507);
            this.locationCB.Margin = new System.Windows.Forms.Padding(4);
            this.locationCB.Name = "locationCB";
            this.locationCB.Size = new System.Drawing.Size(357, 33);
            this.locationCB.TabIndex = 39;
            this.locationCB.ValueMember = "id";
            this.locationCB.Visible = false;
            this.locationCB.SelectionChangeCommitted += new System.EventHandler(this.locationCB_SelectionChangeCommitted);
            // 
            // locationBindingSource
            // 
            this.locationBindingSource.DataMember = "location";
            this.locationBindingSource.DataSource = this.coStoreDataSet;
            // 
            // locationTableAdapter
            // 
            this.locationTableAdapter.ClearBeforeFill = true;
            // 
            // itemDataGridViewLabel
            // 
            this.itemDataGridViewLabel.AutoSize = true;
            this.itemDataGridViewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemDataGridViewLabel.Location = new System.Drawing.Point(13, 223);
            this.itemDataGridViewLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.itemDataGridViewLabel.Name = "itemDataGridViewLabel";
            this.itemDataGridViewLabel.Size = new System.Drawing.Size(59, 25);
            this.itemDataGridViewLabel.TabIndex = 40;
            this.itemDataGridViewLabel.Text = "Items";
            this.itemDataGridViewLabel.Visible = false;
            // 
            // priceDataGridViewLabel
            // 
            this.priceDataGridViewLabel.AutoSize = true;
            this.priceDataGridViewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceDataGridViewLabel.Location = new System.Drawing.Point(876, 223);
            this.priceDataGridViewLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.priceDataGridViewLabel.Name = "priceDataGridViewLabel";
            this.priceDataGridViewLabel.Size = new System.Drawing.Size(343, 25);
            this.priceDataGridViewLabel.TabIndex = 41;
            this.priceDataGridViewLabel.Text = "Price Breaks (ascending order by qty.)";
            this.priceDataGridViewLabel.Visible = false;
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationLabel.Location = new System.Drawing.Point(874, 478);
            this.locationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(215, 25);
            this.locationLabel.TabIndex = 42;
            this.locationLabel.Text = "Item Location (optional)";
            this.locationLabel.Visible = false;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(1127, 639);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(108, 47);
            this.saveButton.TabIndex = 43;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(997, 639);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(108, 47);
            this.clearButton.TabIndex = 44;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // printButton
            // 
            this.printButton.Enabled = false;
            this.printButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButton.Location = new System.Drawing.Point(997, 569);
            this.printButton.Margin = new System.Windows.Forms.Padding(4);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(240, 47);
            this.printButton.TabIndex = 45;
            this.printButton.Text = "Print Seller\'s Receipt";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // longDescTextBox
            // 
            this.longDescTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longDescTextBox.Location = new System.Drawing.Point(17, 586);
            this.longDescTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.longDescTextBox.MaxLength = 1000;
            this.longDescTextBox.Multiline = true;
            this.longDescTextBox.Name = "longDescTextBox";
            this.longDescTextBox.Size = new System.Drawing.Size(835, 185);
            this.longDescTextBox.TabIndex = 46;
            this.longDescTextBox.Visible = false;
            this.longDescTextBox.Validated += new System.EventHandler(this.longDescTextBox_Validated);
            // 
            // longDescTextBoxLabel
            // 
            this.longDescTextBoxLabel.AutoSize = true;
            this.longDescTextBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.longDescTextBoxLabel.Location = new System.Drawing.Point(19, 558);
            this.longDescTextBoxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.longDescTextBoxLabel.Name = "longDescTextBoxLabel";
            this.longDescTextBoxLabel.Size = new System.Drawing.Size(452, 25);
            this.longDescTextBoxLabel.TabIndex = 47;
            this.longDescTextBoxLabel.Text = "Long (up to 1000 characters) Description (optional)";
            this.longDescTextBoxLabel.Visible = false;
            // 
            // EnterNewItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.longDescTextBoxLabel);
            this.Controls.Add(this.longDescTextBox);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.priceDataGridViewLabel);
            this.Controls.Add(this.itemDataGridViewLabel);
            this.Controls.Add(this.locationCB);
            this.Controls.Add(this.priceDataGridView);
            this.Controls.Add(this.itemDataGridView);
            this.Controls.Add(this.sellerLabel);
            this.Controls.Add(this.seller);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sellerFilterGroupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EnterNewItems";
            this.Size = new System.Drawing.Size(1249, 791);
            this.VisibleChanged += new System.EventHandler(this.EnterNewItems_VisibleChanged);
            this.sellerFilterGroupBox.ResumeLayout(false);
            this.sellerFilterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectsellersasstringsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox registrationNoFilter;
        private System.Windows.Forms.Label registrationNoFilterLabel;
        private System.Windows.Forms.GroupBox sellerFilterGroupBox;
        private System.Windows.Forms.Button findSellersButton;
        private System.Windows.Forms.Label lastNameFilterLabel;
        private System.Windows.Forms.TextBox lastNameFilter;
        private System.Windows.Forms.Label firstNameFilterLabel;
        private System.Windows.Forms.TextBox firstNameFilter;
        private System.Windows.Forms.ComboBox seller;
        private System.Windows.Forms.BindingSource selectsellersasstringsBindingSource;
        private CoStoreDataSet coStoreDataSet;
        private CoStoreDataSetTableAdapters.select_sellers_as_stringsTableAdapter select_sellers_as_stringsTableAdapter;
        private System.Windows.Forms.Label sellerLabel;
        private System.Windows.Forms.DataGridView itemDataGridView;
        private System.Windows.Forms.DataGridView priceDataGridView;
        private System.Windows.Forms.ComboBox locationCB;
        private System.Windows.Forms.BindingSource locationBindingSource;
        private CoStoreDataSetTableAdapters.locationTableAdapter locationTableAdapter;
        private System.Windows.Forms.Label itemDataGridViewLabel;
        private System.Windows.Forms.Label priceDataGridViewLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.TextBox longDescTextBox;
        private System.Windows.Forms.Label longDescTextBoxLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyAtStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn longDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn pricing;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity_break;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
    }
}
