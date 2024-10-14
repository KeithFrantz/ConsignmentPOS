namespace ConsignmentPOS
{
    partial class EnterNewSellers
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
            this.enterButton = new System.Windows.Forms.Button();
            this.memberIDLabel = new System.Windows.Forms.Label();
            this.memberID = new System.Windows.Forms.TextBox();
            this.postalCodeLabel = new System.Windows.Forms.Label();
            this.postalCode = new System.Windows.Forms.TextBox();
            this.phone2Label = new System.Windows.Forms.Label();
            this.phone2 = new System.Windows.Forms.TextBox();
            this.phone1Label = new System.Windows.Forms.Label();
            this.phone1 = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.countryLabel = new System.Windows.Forms.Label();
            this.country = new System.Windows.Forms.TextBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.state = new System.Windows.Forms.TextBox();
            this.postOfficeLabel = new System.Windows.Forms.Label();
            this.postOffice = new System.Windows.Forms.TextBox();
            this.address2Label = new System.Windows.Forms.Label();
            this.address2 = new System.Windows.Forms.TextBox();
            this.address1Label = new System.Windows.Forms.Label();
            this.address1 = new System.Windows.Forms.TextBox();
            this.salutationLabel = new System.Windows.Forms.Label();
            this.salutation = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.firstName = new System.Windows.Forms.TextBox();
            this.middleName = new System.Windows.Forms.TextBox();
            this.middleNameLabel = new System.Windows.Forms.Label();
            this.lastName = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.suffixLabel = new System.Windows.Forms.Label();
            this.suffix = new System.Windows.Forms.TextBox();
            this.registrationNoLabel = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.enterNewSellersToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.requiredFieldKey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter New Sellers";
            // 
            // enterButton
            // 
            this.enterButton.Enabled = false;
            this.enterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterButton.Location = new System.Drawing.Point(1100, 266);
            this.enterButton.Margin = new System.Windows.Forms.Padding(4);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(152, 46);
            this.enterButton.TabIndex = 33;
            this.enterButton.Text = "Enter Seller";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // memberIDLabel
            // 
            this.memberIDLabel.AutoSize = true;
            this.memberIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberIDLabel.Location = new System.Drawing.Point(935, 182);
            this.memberIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.memberIDLabel.Name = "memberIDLabel";
            this.memberIDLabel.Size = new System.Drawing.Size(108, 25);
            this.memberIDLabel.TabIndex = 29;
            this.memberIDLabel.Text = "Member ID";
            // 
            // memberID
            // 
            this.memberID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberID.Location = new System.Drawing.Point(940, 210);
            this.memberID.Margin = new System.Windows.Forms.Padding(4);
            this.memberID.Name = "memberID";
            this.memberID.Size = new System.Drawing.Size(143, 30);
            this.memberID.TabIndex = 30;
            this.memberID.Validating += new System.ComponentModel.CancelEventHandler(this.memberID_Validating);
            // 
            // postalCodeLabel
            // 
            this.postalCodeLabel.AutoSize = true;
            this.postalCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postalCodeLabel.Location = new System.Drawing.Point(548, 251);
            this.postalCodeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.postalCodeLabel.Name = "postalCodeLabel";
            this.postalCodeLabel.Size = new System.Drawing.Size(155, 25);
            this.postalCodeLabel.TabIndex = 19;
            this.postalCodeLabel.Text = "ZIP/Postal Code";
            // 
            // postalCode
            // 
            this.postalCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postalCode.Location = new System.Drawing.Point(554, 279);
            this.postalCode.Margin = new System.Windows.Forms.Padding(4);
            this.postalCode.Name = "postalCode";
            this.postalCode.Size = new System.Drawing.Size(143, 30);
            this.postalCode.TabIndex = 20;
            this.postalCode.Validating += new System.ComponentModel.CancelEventHandler(this.postalCode_Validating);
            // 
            // phone2Label
            // 
            this.phone2Label.AutoSize = true;
            this.phone2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone2Label.Location = new System.Drawing.Point(727, 182);
            this.phone2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phone2Label.Name = "phone2Label";
            this.phone2Label.Size = new System.Drawing.Size(120, 25);
            this.phone2Label.TabIndex = 27;
            this.phone2Label.Text = "Phone No. 2";
            // 
            // phone2
            // 
            this.phone2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone2.Location = new System.Drawing.Point(732, 210);
            this.phone2.Margin = new System.Windows.Forms.Padding(4);
            this.phone2.Name = "phone2";
            this.phone2.Size = new System.Drawing.Size(180, 30);
            this.phone2.TabIndex = 28;
            this.phone2.MouseHover += new System.EventHandler(this.phone2_MouseHover);
            this.phone2.Validating += new System.ComponentModel.CancelEventHandler(this.phone2_Validating);
            // 
            // phone1Label
            // 
            this.phone1Label.AutoSize = true;
            this.phone1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone1Label.Location = new System.Drawing.Point(504, 182);
            this.phone1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phone1Label.Name = "phone1Label";
            this.phone1Label.Size = new System.Drawing.Size(120, 25);
            this.phone1Label.TabIndex = 25;
            this.phone1Label.Text = "Phone No. 1";
            // 
            // phone1
            // 
            this.phone1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone1.Location = new System.Drawing.Point(510, 210);
            this.phone1.Margin = new System.Windows.Forms.Padding(4);
            this.phone1.Name = "phone1";
            this.phone1.Size = new System.Drawing.Size(180, 30);
            this.phone1.TabIndex = 26;
            this.phone1.MouseHover += new System.EventHandler(this.phone1_MouseHover);
            this.phone1.Validating += new System.ComponentModel.CancelEventHandler(this.phone1_Validating);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(504, 113);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.emailLabel.Size = new System.Drawing.Size(138, 25);
            this.emailLabel.TabIndex = 23;
            this.emailLabel.Text = "Email Address";
            // 
            // email
            // 
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(508, 141);
            this.email.Margin = new System.Windows.Forms.Padding(4);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(743, 30);
            this.email.TabIndex = 24;
            this.email.Validating += new System.ComponentModel.CancelEventHandler(this.email_Validating);
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryLabel.Location = new System.Drawing.Point(726, 251);
            this.countryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(81, 25);
            this.countryLabel.TabIndex = 21;
            this.countryLabel.Text = "Country";
            // 
            // country
            // 
            this.country.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.country.Location = new System.Drawing.Point(732, 279);
            this.country.Margin = new System.Windows.Forms.Padding(4);
            this.country.Name = "country";
            this.country.Size = new System.Drawing.Size(143, 30);
            this.country.TabIndex = 22;
            this.country.Validating += new System.ComponentModel.CancelEventHandler(this.country_Validating);
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateLabel.Location = new System.Drawing.Point(351, 251);
            this.stateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(140, 25);
            this.stateLabel.TabIndex = 17;
            this.stateLabel.Text = "State/Province";
            // 
            // state
            // 
            this.state.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.state.Location = new System.Drawing.Point(356, 279);
            this.state.Margin = new System.Windows.Forms.Padding(4);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(157, 30);
            this.state.TabIndex = 18;
            this.state.Validating += new System.ComponentModel.CancelEventHandler(this.state_Validating);
            // 
            // postOfficeLabel
            // 
            this.postOfficeLabel.AutoSize = true;
            this.postOfficeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postOfficeLabel.Location = new System.Drawing.Point(12, 251);
            this.postOfficeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.postOfficeLabel.Name = "postOfficeLabel";
            this.postOfficeLabel.Size = new System.Drawing.Size(147, 25);
            this.postOfficeLabel.TabIndex = 15;
            this.postOfficeLabel.Text = "City/Post Office";
            // 
            // postOffice
            // 
            this.postOffice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postOffice.Location = new System.Drawing.Point(18, 279);
            this.postOffice.Margin = new System.Windows.Forms.Padding(4);
            this.postOffice.Name = "postOffice";
            this.postOffice.Size = new System.Drawing.Size(296, 30);
            this.postOffice.TabIndex = 16;
            this.postOffice.Validating += new System.ComponentModel.CancelEventHandler(this.postOffice_Validating);
            // 
            // address2Label
            // 
            this.address2Label.AutoSize = true;
            this.address2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address2Label.Location = new System.Drawing.Point(12, 182);
            this.address2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.address2Label.Name = "address2Label";
            this.address2Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.address2Label.Size = new System.Drawing.Size(186, 25);
            this.address2Label.TabIndex = 13;
            this.address2Label.Text = "2nd Line of Address";
            // 
            // address2
            // 
            this.address2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address2.Location = new System.Drawing.Point(16, 210);
            this.address2.Margin = new System.Windows.Forms.Padding(4);
            this.address2.Name = "address2";
            this.address2.Size = new System.Drawing.Size(433, 30);
            this.address2.TabIndex = 14;
            this.address2.Validating += new System.ComponentModel.CancelEventHandler(this.address2_Validating);
            // 
            // address1Label
            // 
            this.address1Label.AutoSize = true;
            this.address1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1Label.Location = new System.Drawing.Point(11, 113);
            this.address1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.address1Label.Name = "address1Label";
            this.address1Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.address1Label.Size = new System.Drawing.Size(179, 25);
            this.address1Label.TabIndex = 11;
            this.address1Label.Text = "1st Line of Address";
            // 
            // address1
            // 
            this.address1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address1.Location = new System.Drawing.Point(15, 141);
            this.address1.Margin = new System.Windows.Forms.Padding(4);
            this.address1.Name = "address1";
            this.address1.Size = new System.Drawing.Size(435, 30);
            this.address1.TabIndex = 12;
            this.address1.Validating += new System.ComponentModel.CancelEventHandler(this.address1_Validating);
            // 
            // salutationLabel
            // 
            this.salutationLabel.AutoSize = true;
            this.salutationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salutationLabel.Location = new System.Drawing.Point(13, 41);
            this.salutationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.salutationLabel.Name = "salutationLabel";
            this.salutationLabel.Size = new System.Drawing.Size(99, 25);
            this.salutationLabel.TabIndex = 1;
            this.salutationLabel.Text = "Salutation";
            // 
            // salutation
            // 
            this.salutation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salutation.Location = new System.Drawing.Point(18, 70);
            this.salutation.Margin = new System.Windows.Forms.Padding(4);
            this.salutation.Name = "salutation";
            this.salutation.Size = new System.Drawing.Size(90, 30);
            this.salutation.TabIndex = 2;
            this.salutation.MouseHover += new System.EventHandler(this.salutation_MouseHover);
            this.salutation.Validating += new System.ComponentModel.CancelEventHandler(this.salutation_Validating);
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(1099, 194);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(152, 46);
            this.clearButton.TabIndex = 34;
            this.clearButton.Text = "Clear Info";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.firstNameLabel.Location = new System.Drawing.Point(136, 41);
            this.firstNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.firstNameLabel.Size = new System.Drawing.Size(106, 25);
            this.firstNameLabel.TabIndex = 3;
            this.firstNameLabel.Text = "First Name";
            // 
            // firstName
            // 
            this.firstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstName.Location = new System.Drawing.Point(141, 70);
            this.firstName.Margin = new System.Windows.Forms.Padding(4);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(304, 30);
            this.firstName.TabIndex = 4;
            this.firstName.Validating += new System.ComponentModel.CancelEventHandler(this.firstName_Validating);
            // 
            // middleName
            // 
            this.middleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.middleName.Location = new System.Drawing.Point(478, 70);
            this.middleName.Margin = new System.Windows.Forms.Padding(4);
            this.middleName.Name = "middleName";
            this.middleName.Size = new System.Drawing.Size(303, 30);
            this.middleName.TabIndex = 6;
            this.middleName.Validating += new System.ComponentModel.CancelEventHandler(this.middleName_Validating);
            // 
            // middleNameLabel
            // 
            this.middleNameLabel.AutoSize = true;
            this.middleNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.middleNameLabel.Location = new System.Drawing.Point(473, 41);
            this.middleNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.middleNameLabel.Name = "middleNameLabel";
            this.middleNameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.middleNameLabel.Size = new System.Drawing.Size(127, 25);
            this.middleNameLabel.TabIndex = 5;
            this.middleNameLabel.Text = "Middle Name";
            // 
            // lastName
            // 
            this.lastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastName.Location = new System.Drawing.Point(816, 70);
            this.lastName.Margin = new System.Windows.Forms.Padding(4);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(304, 30);
            this.lastName.TabIndex = 8;
            this.lastName.Validating += new System.ComponentModel.CancelEventHandler(this.lastName_Validating);
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastNameLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.lastNameLabel.Location = new System.Drawing.Point(811, 41);
            this.lastNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lastNameLabel.Size = new System.Drawing.Size(106, 25);
            this.lastNameLabel.TabIndex = 7;
            this.lastNameLabel.Text = "Last Name";
            // 
            // suffixLabel
            // 
            this.suffixLabel.AutoSize = true;
            this.suffixLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suffixLabel.Location = new System.Drawing.Point(1149, 42);
            this.suffixLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.suffixLabel.Name = "suffixLabel";
            this.suffixLabel.Size = new System.Drawing.Size(61, 25);
            this.suffixLabel.TabIndex = 9;
            this.suffixLabel.Text = "Suffix";
            // 
            // suffix
            // 
            this.suffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suffix.Location = new System.Drawing.Point(1154, 71);
            this.suffix.Margin = new System.Windows.Forms.Padding(4);
            this.suffix.Name = "suffix";
            this.suffix.Size = new System.Drawing.Size(97, 30);
            this.suffix.TabIndex = 10;
            this.suffix.Validating += new System.ComponentModel.CancelEventHandler(this.suffix_Validating);
            // 
            // registrationNoLabel
            // 
            this.registrationNoLabel.AutoSize = true;
            this.registrationNoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrationNoLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.registrationNoLabel.Location = new System.Drawing.Point(935, 251);
            this.registrationNoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.registrationNoLabel.Name = "registrationNoLabel";
            this.registrationNoLabel.Size = new System.Drawing.Size(149, 25);
            this.registrationNoLabel.TabIndex = 31;
            this.registrationNoLabel.Text = "Registration No.";
            // 
            // id
            // 
            this.id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.Location = new System.Drawing.Point(940, 279);
            this.id.Margin = new System.Windows.Forms.Padding(4);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(143, 30);
            this.id.TabIndex = 32;
            this.id.Validating += new System.ComponentModel.CancelEventHandler(this.registrationNo_Validating);
            // 
            // requiredFieldKey
            // 
            this.requiredFieldKey.AutoSize = true;
            this.requiredFieldKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requiredFieldKey.ForeColor = System.Drawing.Color.Firebrick;
            this.requiredFieldKey.Location = new System.Drawing.Point(15, 330);
            this.requiredFieldKey.Name = "requiredFieldKey";
            this.requiredFieldKey.Size = new System.Drawing.Size(235, 18);
            this.requiredFieldKey.TabIndex = 35;
            this.requiredFieldKey.Text = "Labels in red denote required fields";
            // 
            // EnterNewSellers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.requiredFieldKey);
            this.Controls.Add(this.state);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.id);
            this.Controls.Add(this.registrationNoLabel);
            this.Controls.Add(this.suffix);
            this.Controls.Add(this.suffixLabel);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.middleName);
            this.Controls.Add(this.middleNameLabel);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.salutation);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.salutationLabel);
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
            this.Controls.Add(this.lastName);
            this.Name = "EnterNewSellers";
            this.Size = new System.Drawing.Size(1270, 348);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Label memberIDLabel;
        private System.Windows.Forms.TextBox memberID;
        private System.Windows.Forms.Label postalCodeLabel;
        private System.Windows.Forms.TextBox postalCode;
        private System.Windows.Forms.Label phone2Label;
        private System.Windows.Forms.TextBox phone2;
        private System.Windows.Forms.Label phone1Label;
        private System.Windows.Forms.TextBox phone1;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.TextBox country;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.TextBox state;
        private System.Windows.Forms.Label postOfficeLabel;
        private System.Windows.Forms.TextBox postOffice;
        private System.Windows.Forms.Label address2Label;
        private System.Windows.Forms.TextBox address2;
        private System.Windows.Forms.Label address1Label;
        private System.Windows.Forms.TextBox address1;
        private System.Windows.Forms.Label salutationLabel;
        private System.Windows.Forms.TextBox salutation;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.TextBox middleName;
        private System.Windows.Forms.Label middleNameLabel;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label suffixLabel;
        private System.Windows.Forms.TextBox suffix;
        private System.Windows.Forms.Label registrationNoLabel;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.ToolTip enterNewSellersToolTip;
        private System.Windows.Forms.Label requiredFieldKey;
    }
}
