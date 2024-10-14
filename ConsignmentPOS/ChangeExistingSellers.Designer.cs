namespace ConsignmentPOS
{
    partial class ChangeExistingSellers
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.selectsellersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coStoreDataSet = new ConsignmentPOS.CoStoreDataSet();
            this.registrationNoFilter = new System.Windows.Forms.TextBox();
            this.registrationNoFilterLabel = new System.Windows.Forms.Label();
            this.firstNameFilter = new System.Windows.Forms.TextBox();
            this.firstNameFilterLabel = new System.Windows.Forms.Label();
            this.lastNameFilterLabel = new System.Windows.Forms.Label();
            this.lastNameFilter = new System.Windows.Forms.TextBox();
            this.sellerFilterGroupBox = new System.Windows.Forms.GroupBox();
            this.findSellersButton = new System.Windows.Forms.Button();
            this.address1 = new System.Windows.Forms.TextBox();
            this.address1Label = new System.Windows.Forms.Label();
            this.address2Label = new System.Windows.Forms.Label();
            this.address2 = new System.Windows.Forms.TextBox();
            this.postOffice = new System.Windows.Forms.TextBox();
            this.postOfficeLabel = new System.Windows.Forms.Label();
            this.state = new System.Windows.Forms.TextBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.countryLabel = new System.Windows.Forms.Label();
            this.country = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.phone2Label = new System.Windows.Forms.Label();
            this.phone2 = new System.Windows.Forms.TextBox();
            this.phone1Label = new System.Windows.Forms.Label();
            this.phone1 = new System.Windows.Forms.TextBox();
            this.postalCodeLabel = new System.Windows.Forms.Label();
            this.postalCode = new System.Windows.Forms.TextBox();
            this.memberIDLabel = new System.Windows.Forms.Label();
            this.memberID = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.changeExistingSellersToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.actualSellersCB = new System.Windows.Forms.CheckBox();
            this.sellerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sellerTableAdapter = new ConsignmentPOS.CoStoreDataSetTableAdapters.sellerTableAdapter();
            this.select_sellersTableAdapter = new ConsignmentPOS.CoStoreDataSetTableAdapters.select_sellersTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salutationDataGridViewTextBoxCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.middlenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suffixDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postofficeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postalcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memberidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lasteditatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lasteditbyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectsellersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet)).BeginInit();
            this.sellerFilterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sellerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change Existing Sellers";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.salutationDataGridViewTextBoxCol,
            this.firstnameDataGridViewTextBoxColumn,
            this.middlenameDataGridViewTextBoxColumn,
            this.lastnameDataGridViewTextBoxColumn,
            this.suffixDataGridViewTextBoxColumn,
            this.address1DataGridViewTextBoxColumn,
            this.address2DataGridViewTextBoxColumn,
            this.postofficeDataGridViewTextBoxColumn,
            this.stateDataGridViewTextBoxColumn,
            this.postalcodeDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.phone1DataGridViewTextBoxColumn,
            this.phone2DataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.memberidDataGridViewTextBoxColumn,
            this.lasteditatDataGridViewTextBoxColumn,
            this.lasteditbyDataGridViewTextBoxColumn,
            this.modDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.selectsellersBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(8, 154);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1237, 288);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // selectsellersBindingSource
            // 
            this.selectsellersBindingSource.DataMember = "select_sellers";
            this.selectsellersBindingSource.DataSource = this.coStoreDataSet;
            // 
            // coStoreDataSet
            // 
            this.coStoreDataSet.DataSetName = "CoStoreDataSet";
            this.coStoreDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // firstNameFilter
            // 
            this.firstNameFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameFilter.Location = new System.Drawing.Point(191, 57);
            this.firstNameFilter.Margin = new System.Windows.Forms.Padding(4);
            this.firstNameFilter.Name = "firstNameFilter";
            this.firstNameFilter.Size = new System.Drawing.Size(265, 30);
            this.firstNameFilter.TabIndex = 4;
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
            this.sellerFilterGroupBox.Location = new System.Drawing.Point(329, 50);
            this.sellerFilterGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.sellerFilterGroupBox.Name = "sellerFilterGroupBox";
            this.sellerFilterGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.sellerFilterGroupBox.Size = new System.Drawing.Size(916, 96);
            this.sellerFilterGroupBox.TabIndex = 8;
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
            // address1
            // 
            this.address1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1.Location = new System.Drawing.Point(8, 481);
            this.address1.Margin = new System.Windows.Forms.Padding(4);
            this.address1.Name = "address1";
            this.address1.Size = new System.Drawing.Size(435, 30);
            this.address1.TabIndex = 9;
            this.address1.Validating += new System.ComponentModel.CancelEventHandler(this.address1_Validating);
            this.address1.Validated += new System.EventHandler(this.address1_Validated);
            // 
            // address1Label
            // 
            this.address1Label.AutoSize = true;
            this.address1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1Label.Location = new System.Drawing.Point(4, 453);
            this.address1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.address1Label.Name = "address1Label";
            this.address1Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.address1Label.Size = new System.Drawing.Size(179, 25);
            this.address1Label.TabIndex = 10;
            this.address1Label.Text = "1st Line of Address";
            // 
            // address2Label
            // 
            this.address2Label.AutoSize = true;
            this.address2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address2Label.Location = new System.Drawing.Point(5, 522);
            this.address2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.address2Label.Name = "address2Label";
            this.address2Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.address2Label.Size = new System.Drawing.Size(186, 25);
            this.address2Label.TabIndex = 12;
            this.address2Label.Text = "2nd Line of Address";
            // 
            // address2
            // 
            this.address2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address2.Location = new System.Drawing.Point(9, 550);
            this.address2.Margin = new System.Windows.Forms.Padding(4);
            this.address2.Name = "address2";
            this.address2.Size = new System.Drawing.Size(433, 30);
            this.address2.TabIndex = 11;
            this.address2.Validating += new System.ComponentModel.CancelEventHandler(this.address2_Validating);
            this.address2.Validated += new System.EventHandler(this.address2_Validated);
            // 
            // postOffice
            // 
            this.postOffice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postOffice.Location = new System.Drawing.Point(11, 619);
            this.postOffice.Margin = new System.Windows.Forms.Padding(4);
            this.postOffice.Name = "postOffice";
            this.postOffice.Size = new System.Drawing.Size(296, 30);
            this.postOffice.TabIndex = 13;
            this.postOffice.Validating += new System.ComponentModel.CancelEventHandler(this.postOffice_Validating);
            this.postOffice.Validated += new System.EventHandler(this.postOffice_Validated);
            // 
            // postOfficeLabel
            // 
            this.postOfficeLabel.AutoSize = true;
            this.postOfficeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postOfficeLabel.Location = new System.Drawing.Point(5, 591);
            this.postOfficeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.postOfficeLabel.Name = "postOfficeLabel";
            this.postOfficeLabel.Size = new System.Drawing.Size(147, 25);
            this.postOfficeLabel.TabIndex = 14;
            this.postOfficeLabel.Text = "City/Post Office";
            // 
            // state
            // 
            this.state.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.state.Location = new System.Drawing.Point(349, 619);
            this.state.Margin = new System.Windows.Forms.Padding(4);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(157, 30);
            this.state.TabIndex = 15;
            this.state.Validating += new System.ComponentModel.CancelEventHandler(this.state_Validating);
            this.state.Validated += new System.EventHandler(this.state_Validated);
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLabel.Location = new System.Drawing.Point(344, 591);
            this.stateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(140, 25);
            this.stateLabel.TabIndex = 16;
            this.stateLabel.Text = "State/Province";
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryLabel.Location = new System.Drawing.Point(719, 591);
            this.countryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(81, 25);
            this.countryLabel.TabIndex = 18;
            this.countryLabel.Text = "Country";
            // 
            // country
            // 
            this.country.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.country.Location = new System.Drawing.Point(725, 619);
            this.country.Margin = new System.Windows.Forms.Padding(4);
            this.country.Name = "country";
            this.country.Size = new System.Drawing.Size(143, 30);
            this.country.TabIndex = 17;
            this.country.Validating += new System.ComponentModel.CancelEventHandler(this.country_Validating);
            this.country.Validated += new System.EventHandler(this.country_Validated);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(497, 453);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.emailLabel.Size = new System.Drawing.Size(138, 25);
            this.emailLabel.TabIndex = 20;
            this.emailLabel.Text = "Email Address";
            // 
            // email
            // 
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(501, 481);
            this.email.Margin = new System.Windows.Forms.Padding(4);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(743, 30);
            this.email.TabIndex = 19;
            this.email.Validating += new System.ComponentModel.CancelEventHandler(this.email_Validating);
            this.email.Validated += new System.EventHandler(this.email_Validated);
            // 
            // phone2Label
            // 
            this.phone2Label.AutoSize = true;
            this.phone2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone2Label.Location = new System.Drawing.Point(720, 522);
            this.phone2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phone2Label.Name = "phone2Label";
            this.phone2Label.Size = new System.Drawing.Size(120, 25);
            this.phone2Label.TabIndex = 24;
            this.phone2Label.Text = "Phone No. 2";
            // 
            // phone2
            // 
            this.phone2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone2.Location = new System.Drawing.Point(725, 550);
            this.phone2.Margin = new System.Windows.Forms.Padding(4);
            this.phone2.Name = "phone2";
            this.phone2.Size = new System.Drawing.Size(180, 30);
            this.phone2.TabIndex = 23;
            this.phone2.MouseHover += new System.EventHandler(this.phone2_MouseHover);
            this.phone2.Validating += new System.ComponentModel.CancelEventHandler(this.phone2_Validating);
            this.phone2.Validated += new System.EventHandler(this.phone2_Validated);
            // 
            // phone1Label
            // 
            this.phone1Label.AutoSize = true;
            this.phone1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone1Label.Location = new System.Drawing.Point(497, 522);
            this.phone1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phone1Label.Name = "phone1Label";
            this.phone1Label.Size = new System.Drawing.Size(120, 25);
            this.phone1Label.TabIndex = 22;
            this.phone1Label.Text = "Phone No. 1";
            // 
            // phone1
            // 
            this.phone1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone1.Location = new System.Drawing.Point(503, 550);
            this.phone1.Margin = new System.Windows.Forms.Padding(4);
            this.phone1.Name = "phone1";
            this.phone1.Size = new System.Drawing.Size(180, 30);
            this.phone1.TabIndex = 21;
            this.phone1.MouseHover += new System.EventHandler(this.phone1_MouseHover);
            this.phone1.Validating += new System.ComponentModel.CancelEventHandler(this.phone1_Validating);
            this.phone1.Validated += new System.EventHandler(this.phone1_Validated);
            // 
            // postalCodeLabel
            // 
            this.postalCodeLabel.AutoSize = true;
            this.postalCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postalCodeLabel.Location = new System.Drawing.Point(541, 591);
            this.postalCodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.postalCodeLabel.Name = "postalCodeLabel";
            this.postalCodeLabel.Size = new System.Drawing.Size(155, 25);
            this.postalCodeLabel.TabIndex = 26;
            this.postalCodeLabel.Text = "ZIP/Postal Code";
            // 
            // postalCode
            // 
            this.postalCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postalCode.Location = new System.Drawing.Point(547, 619);
            this.postalCode.Margin = new System.Windows.Forms.Padding(4);
            this.postalCode.Name = "postalCode";
            this.postalCode.Size = new System.Drawing.Size(143, 30);
            this.postalCode.TabIndex = 25;
            this.postalCode.Validating += new System.ComponentModel.CancelEventHandler(this.postalCode_Validating);
            this.postalCode.Validated += new System.EventHandler(this.postalCode_Validated);
            // 
            // memberIDLabel
            // 
            this.memberIDLabel.AutoSize = true;
            this.memberIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberIDLabel.Location = new System.Drawing.Point(928, 522);
            this.memberIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.memberIDLabel.Name = "memberIDLabel";
            this.memberIDLabel.Size = new System.Drawing.Size(108, 25);
            this.memberIDLabel.TabIndex = 28;
            this.memberIDLabel.Text = "Member ID";
            // 
            // memberID
            // 
            this.memberID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberID.Location = new System.Drawing.Point(933, 550);
            this.memberID.Margin = new System.Windows.Forms.Padding(4);
            this.memberID.Name = "memberID";
            this.memberID.Size = new System.Drawing.Size(143, 30);
            this.memberID.TabIndex = 27;
            this.memberID.Validating += new System.ComponentModel.CancelEventHandler(this.memberID_Validating);
            this.memberID.Validated += new System.EventHandler(this.memberid_Validated);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(1093, 606);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(152, 46);
            this.saveButton.TabIndex = 29;
            this.saveButton.Text = "Save Sellers";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Clicked);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(1093, 544);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(152, 46);
            this.deleteButton.TabIndex = 30;
            this.deleteButton.Text = "Delete Seller";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // actualSellersCB
            // 
            this.actualSellersCB.AutoSize = true;
            this.actualSellersCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualSellersCB.Location = new System.Drawing.Point(9, 98);
            this.actualSellersCB.Name = "actualSellersCB";
            this.actualSellersCB.Size = new System.Drawing.Size(187, 44);
            this.actualSellersCB.TabIndex = 31;
            this.actualSellersCB.Text = "Show only sellers\r\nwith registered items";
            this.actualSellersCB.UseVisualStyleBackColor = true;
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
            // select_sellersTableAdapter
            // 
            this.select_sellersTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Reg. #";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 80;
            // 
            // salutationDataGridViewTextBoxCol
            // 
            this.salutationDataGridViewTextBoxCol.DataPropertyName = "salutation";
            this.salutationDataGridViewTextBoxCol.HeaderText = "Salutation";
            this.salutationDataGridViewTextBoxCol.MinimumWidth = 6;
            this.salutationDataGridViewTextBoxCol.Name = "salutationDataGridViewTextBoxCol";
            this.salutationDataGridViewTextBoxCol.Width = 80;
            // 
            // firstnameDataGridViewTextBoxColumn
            // 
            this.firstnameDataGridViewTextBoxColumn.DataPropertyName = "first_name";
            this.firstnameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.firstnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.firstnameDataGridViewTextBoxColumn.Name = "firstnameDataGridViewTextBoxColumn";
            this.firstnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // middlenameDataGridViewTextBoxColumn
            // 
            this.middlenameDataGridViewTextBoxColumn.DataPropertyName = "middle_name";
            this.middlenameDataGridViewTextBoxColumn.HeaderText = "Middle Name";
            this.middlenameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.middlenameDataGridViewTextBoxColumn.Name = "middlenameDataGridViewTextBoxColumn";
            this.middlenameDataGridViewTextBoxColumn.Width = 125;
            // 
            // lastnameDataGridViewTextBoxColumn
            // 
            this.lastnameDataGridViewTextBoxColumn.DataPropertyName = "last_name";
            this.lastnameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.lastnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lastnameDataGridViewTextBoxColumn.Name = "lastnameDataGridViewTextBoxColumn";
            this.lastnameDataGridViewTextBoxColumn.Width = 125;
            // 
            // suffixDataGridViewTextBoxColumn
            // 
            this.suffixDataGridViewTextBoxColumn.DataPropertyName = "suffix";
            this.suffixDataGridViewTextBoxColumn.HeaderText = "Suffix";
            this.suffixDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.suffixDataGridViewTextBoxColumn.Name = "suffixDataGridViewTextBoxColumn";
            this.suffixDataGridViewTextBoxColumn.Width = 80;
            // 
            // address1DataGridViewTextBoxColumn
            // 
            this.address1DataGridViewTextBoxColumn.DataPropertyName = "address_1";
            this.address1DataGridViewTextBoxColumn.HeaderText = "address_1";
            this.address1DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.address1DataGridViewTextBoxColumn.Name = "address1DataGridViewTextBoxColumn";
            this.address1DataGridViewTextBoxColumn.Visible = false;
            this.address1DataGridViewTextBoxColumn.Width = 125;
            // 
            // address2DataGridViewTextBoxColumn
            // 
            this.address2DataGridViewTextBoxColumn.DataPropertyName = "address_2";
            this.address2DataGridViewTextBoxColumn.HeaderText = "address_2";
            this.address2DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.address2DataGridViewTextBoxColumn.Name = "address2DataGridViewTextBoxColumn";
            this.address2DataGridViewTextBoxColumn.Visible = false;
            this.address2DataGridViewTextBoxColumn.Width = 125;
            // 
            // postofficeDataGridViewTextBoxColumn
            // 
            this.postofficeDataGridViewTextBoxColumn.DataPropertyName = "post_office";
            this.postofficeDataGridViewTextBoxColumn.HeaderText = "post_office";
            this.postofficeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.postofficeDataGridViewTextBoxColumn.Name = "postofficeDataGridViewTextBoxColumn";
            this.postofficeDataGridViewTextBoxColumn.Visible = false;
            this.postofficeDataGridViewTextBoxColumn.Width = 125;
            // 
            // stateDataGridViewTextBoxColumn
            // 
            this.stateDataGridViewTextBoxColumn.DataPropertyName = "state";
            this.stateDataGridViewTextBoxColumn.HeaderText = "state";
            this.stateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            this.stateDataGridViewTextBoxColumn.Visible = false;
            this.stateDataGridViewTextBoxColumn.Width = 125;
            // 
            // postalcodeDataGridViewTextBoxColumn
            // 
            this.postalcodeDataGridViewTextBoxColumn.DataPropertyName = "postal_code";
            this.postalcodeDataGridViewTextBoxColumn.HeaderText = "postal_code";
            this.postalcodeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.postalcodeDataGridViewTextBoxColumn.Name = "postalcodeDataGridViewTextBoxColumn";
            this.postalcodeDataGridViewTextBoxColumn.Visible = false;
            this.postalcodeDataGridViewTextBoxColumn.Width = 125;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "country";
            this.countryDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            this.countryDataGridViewTextBoxColumn.Visible = false;
            this.countryDataGridViewTextBoxColumn.Width = 125;
            // 
            // phone1DataGridViewTextBoxColumn
            // 
            this.phone1DataGridViewTextBoxColumn.DataPropertyName = "phone_1";
            this.phone1DataGridViewTextBoxColumn.HeaderText = "phone_1";
            this.phone1DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phone1DataGridViewTextBoxColumn.Name = "phone1DataGridViewTextBoxColumn";
            this.phone1DataGridViewTextBoxColumn.Visible = false;
            this.phone1DataGridViewTextBoxColumn.Width = 125;
            // 
            // phone2DataGridViewTextBoxColumn
            // 
            this.phone2DataGridViewTextBoxColumn.DataPropertyName = "phone_2";
            this.phone2DataGridViewTextBoxColumn.HeaderText = "phone_2";
            this.phone2DataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phone2DataGridViewTextBoxColumn.Name = "phone2DataGridViewTextBoxColumn";
            this.phone2DataGridViewTextBoxColumn.Visible = false;
            this.phone2DataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "email";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.Visible = false;
            this.emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // memberidDataGridViewTextBoxColumn
            // 
            this.memberidDataGridViewTextBoxColumn.DataPropertyName = "member_id";
            this.memberidDataGridViewTextBoxColumn.HeaderText = "member_id";
            this.memberidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.memberidDataGridViewTextBoxColumn.Name = "memberidDataGridViewTextBoxColumn";
            this.memberidDataGridViewTextBoxColumn.Visible = false;
            this.memberidDataGridViewTextBoxColumn.Width = 125;
            // 
            // lasteditatDataGridViewTextBoxColumn
            // 
            this.lasteditatDataGridViewTextBoxColumn.DataPropertyName = "last_edit_at";
            this.lasteditatDataGridViewTextBoxColumn.HeaderText = "last_edit_at";
            this.lasteditatDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lasteditatDataGridViewTextBoxColumn.Name = "lasteditatDataGridViewTextBoxColumn";
            this.lasteditatDataGridViewTextBoxColumn.Visible = false;
            this.lasteditatDataGridViewTextBoxColumn.Width = 125;
            // 
            // lasteditbyDataGridViewTextBoxColumn
            // 
            this.lasteditbyDataGridViewTextBoxColumn.DataPropertyName = "last_edit_by";
            this.lasteditbyDataGridViewTextBoxColumn.HeaderText = "last_edit_by";
            this.lasteditbyDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lasteditbyDataGridViewTextBoxColumn.Name = "lasteditbyDataGridViewTextBoxColumn";
            this.lasteditbyDataGridViewTextBoxColumn.Visible = false;
            this.lasteditbyDataGridViewTextBoxColumn.Width = 125;
            // 
            // modDataGridViewTextBoxColumn
            // 
            this.modDataGridViewTextBoxColumn.DataPropertyName = "mod";
            this.modDataGridViewTextBoxColumn.HeaderText = "mod";
            this.modDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.modDataGridViewTextBoxColumn.Name = "modDataGridViewTextBoxColumn";
            this.modDataGridViewTextBoxColumn.ReadOnly = true;
            this.modDataGridViewTextBoxColumn.Visible = false;
            this.modDataGridViewTextBoxColumn.Width = 125;
            // 
            // ChangeExistingSellers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.actualSellersCB);
            this.Controls.Add(this.state);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.memberIDLabel);
            this.Controls.Add(this.memberID);
            this.Controls.Add(this.postalCodeLabel);
            this.Controls.Add(this.postalCode);
            this.Controls.Add(this.phone2Label);
            this.Controls.Add(this.phone2);
            this.Controls.Add(this.phone1Label);
            this.Controls.Add(this.phone1);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.email);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.country);
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.postOfficeLabel);
            this.Controls.Add(this.postOffice);
            this.Controls.Add(this.address2Label);
            this.Controls.Add(this.address2);
            this.Controls.Add(this.address1Label);
            this.Controls.Add(this.address1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sellerFilterGroupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChangeExistingSellers";
            this.Size = new System.Drawing.Size(999, 631);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectsellersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coStoreDataSet)).EndInit();
            this.sellerFilterGroupBox.ResumeLayout(false);
            this.sellerFilterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sellerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource sellerBindingSource;
        private CoStoreDataSet coStoreDataSet;
        private CoStoreDataSetTableAdapters.sellerTableAdapter sellerTableAdapter;
        private System.Windows.Forms.TextBox registrationNoFilter;
        private System.Windows.Forms.Label registrationNoFilterLabel;
        private System.Windows.Forms.TextBox firstNameFilter;
        private System.Windows.Forms.Label firstNameFilterLabel;
        private System.Windows.Forms.Label lastNameFilterLabel;
        private System.Windows.Forms.TextBox lastNameFilter;
        private System.Windows.Forms.GroupBox sellerFilterGroupBox;
        private System.Windows.Forms.Button findSellersButton;
        private System.Windows.Forms.TextBox address1;
        private System.Windows.Forms.Label address1Label;
        private System.Windows.Forms.Label address2Label;
        private System.Windows.Forms.TextBox address2;
        private System.Windows.Forms.TextBox postOffice;
        private System.Windows.Forms.Label postOfficeLabel;
        private System.Windows.Forms.TextBox state;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.TextBox country;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label phone2Label;
        private System.Windows.Forms.TextBox phone2;
        private System.Windows.Forms.Label phone1Label;
        private System.Windows.Forms.TextBox phone1;
        private System.Windows.Forms.Label postalCodeLabel;
        private System.Windows.Forms.TextBox postalCode;
        private System.Windows.Forms.Label memberIDLabel;
        private System.Windows.Forms.TextBox memberID;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteButton;
        private CoStoreDataSetTableAdapters.select_sellersTableAdapter select_sellersTableAdapter;
        private System.Windows.Forms.ToolTip changeExistingSellersToolTip;
        private System.Windows.Forms.CheckBox actualSellersCB;
        private System.Windows.Forms.BindingSource selectsellersBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn salutationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salutationDataGridViewTextBoxCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn middlenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suffixDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn address1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn address2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postofficeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postalcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memberidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lasteditatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lasteditbyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modDataGridViewTextBoxColumn;
    }
}
