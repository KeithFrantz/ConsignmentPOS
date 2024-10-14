using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentPOS
{
    public partial class EnterNewSellers : UserControl
    {
        public EnterNewSellers()
        {
            InitializeComponent();
            country.Text = "USA"; // This is the database default but no sense not showing that to the user
        }

        private void setEnterButtonState()
        {
            enterButton.Enabled = (id.Text.Length > 0 && firstName.Text.Length > 0 && lastName.Text.Length > 0);
        }
        private void enterButton_Click(object sender, EventArgs e)
        {
            // Check that at least a first name, last name, and registration number are provided - note this requires these cells already be trimmed
            if (firstName.Text.Length == 0 || lastName.Text.Length == 0 || id.Text.Length == 0)
            {
                MessageBox.Show("Entering a new seller requires at least a first and last name and registration number - please correct this.");
                return;
            }
            using (var command = new SqlCommand())
            {
                string fields = "id";
                string parameters = "@id";
                int rows;
                if (salutation.Text.Length > 0)
                {
                    fields = fields + ", salutation";
                    parameters = parameters + ", @salutation";
                }
                fields = fields + ", first_name";
                parameters = parameters + ", @first_name";
                if (middleName.Text.Length > 0)
                {
                    fields = fields + ", middle_name";
                    parameters = parameters + ", @middle_name";
                }
                fields = fields + ", last_name";
                parameters = parameters + ", @last_name";
                if (suffix.Text.Length > 0)
                {
                    fields = fields + ", suffix";
                    parameters = parameters + ", @suffix";
                }
                if (address1.Text.Length > 0)
                {
                    fields = fields + ", address_1";
                    parameters = parameters + ", @address_1";
                }
                if (address2.Text.Length > 0)
                {
                    fields = fields + ", address_2";
                    parameters = parameters + ", @address_2";
                }
                if (postOffice.Text.Length > 0)
                {
                    fields = fields + ", post_office";
                    parameters = parameters + ", @post_office";
                }
                if (state.Text.Length > 0)
                {
                    fields = fields + ", state";
                    parameters = parameters + ", @state";
                }
                if (postalCode.Text.Length > 0)
                {
                    fields = fields + ", postal_code";
                    parameters = parameters + ", @postal_code";
                }
                if (country.Text.Length > 0)
                {
                    fields = fields + ", country";
                    parameters = parameters + ", @country";
                }
                if (phone1.Text.Length > 0)
                {
                    fields = fields + ", phone_1";
                    parameters = parameters + ", @phone_1";
                }
                if (phone2.Text.Length > 0)
                {
                    fields = fields + ", phone_2";
                    parameters = parameters + ", @phone_2";
                }
                if (email.Text.Length > 0)
                {
                    fields = fields + ", email";
                    parameters = parameters + ", @email";
                }
                if (memberID.Text.Length > 0)
                {
                    fields = fields + ", member_id";
                    parameters = parameters + ", @member_id";
                }
                fields = fields + ", last_edit_at, last_edit_by";
                parameters = parameters + ", @last_edit_at, @last_edit_by";
                command.Connection = DataManager.dbc;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO seller (" + fields + ") VALUES (" + parameters + ")";
                command.Parameters.AddWithValue("@id", Int32.Parse(id.Text)); // This has already been validated
                if (salutation.Text.Length > 0) command.Parameters.AddWithValue("@salutation", salutation.Text);
                command.Parameters.AddWithValue("@first_name", firstName.Text);
                if (middleName.Text.Length > 0) command.Parameters.AddWithValue("@middle_name", middleName.Text);
                command.Parameters.AddWithValue("@last_name", lastName.Text);
                if (suffix.Text.Length > 0) command.Parameters.AddWithValue("@suffix", suffix.Text);
                if (address1.Text.Length > 0) command.Parameters.AddWithValue("@address_1", address1.Text);
                if (address2.Text.Length > 0) command.Parameters.AddWithValue("@address_2", address2.Text);
                if (postOffice.Text.Length > 0) command.Parameters.AddWithValue("@post_office", postOffice.Text);
                if (state.Text.Length > 0) command.Parameters.AddWithValue("@state", state.Text);
                if (postalCode.Text.Length > 0) command.Parameters.AddWithValue("@postal_code", postalCode.Text);
                if (country.Text.Length > 0) command.Parameters.AddWithValue("@country", country.Text);
                if (phone1.Text.Length > 0) command.Parameters.AddWithValue("@phone_1", phone1.Text);
                if (phone2.Text.Length > 0) command.Parameters.AddWithValue("@phone_2", phone2.Text);
                if (email.Text.Length > 0) command.Parameters.AddWithValue("@email", email.Text);
                if (memberID.Text.Length > 0) command.Parameters.AddWithValue("@member_id", memberID.Text);
                command.Parameters.AddWithValue("@last_edit_at", DateTime.Now);
                command.Parameters.AddWithValue("@last_edit_by", "System");
                rows = command.ExecuteNonQuery();
                // If update successful reset the row back to white
                if (rows == 1)
                {
                    MessageBox.Show(String.Format("Successfully added {0} {1} as registrant {2}", firstName.Text, lastName.Text, id.Text));
                    /*
                    object s = new object();
                    EventArgs ev = new EventArgs();
                    clearButton_Click(s, ev);
                    */
                    clearButton.PerformClick();
                }
                else MessageBox.Show("Unable to enter this seller.");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            salutation.Text = "";
            firstName.Text = "";
            middleName.Text = "";
            lastName.Text = "";
            suffix.Text = "";
            address1.Text = "";
            address2.Text = "";
            postOffice.Text = "";
            postalCode.Text = "";
            country.Text = "USA"; // This is the database default but no sense not showing that to the user
            email.Text = "";
            phone1.Text = "";
            phone2.Text = "";
            memberID.Text = "";
            id.Text = "";
            enterButton.Enabled = false;
        }

        private void registrationNo_Validating(object sender, CancelEventArgs e)
        {
            // Make sure the registration number is a positive number 
            int regno;
            string cellContents = id.Text.Trim();
            if (cellContents.Length == 0)
                MessageBox.Show("Registration No. must not be blank - please correct this.");
            else if (!Int32.TryParse(id.Text, out regno) || regno < 1)
            {
                MessageBox.Show("Registration No. must be a positive integer, not '" + cellContents + "' - please correct this.");
                id.Text = "";
            }
            else id.Text = cellContents; // Restore trimmed contents to textbox
            setEnterButtonState();
        }

        private void firstName_Validating(object sender, CancelEventArgs e)
        {
            string cellContents = firstName.Text.Trim();
            if (cellContents.Length == 0) MessageBox.Show("First Name must not be blank - please correct this.");
            else if (cellContents.Length > 50)
            {
                MessageBox.Show("First Name may not be longer than 50 characters - please correct this.");
                cellContents.Remove(50); // Truncate it for the user in case they ignore the message
            }
            firstName.Text = cellContents;
            setEnterButtonState();
        }

        private void lastName_Validating(object sender, CancelEventArgs e)
        {
            string cellContents = lastName.Text.Trim();
            if (cellContents.Length == 0) MessageBox.Show("Last Name must not be blank - please correct this.");
            else if (cellContents.Length > 50)
            {
                MessageBox.Show("Last Name may not be longer than 50 characters - please correct this.");
                cellContents = cellContents.Remove(50); // Truncate it for the user in case they ignore the message
            }
            lastName.Text = cellContents;
            setEnterButtonState();
        }

        private void salutation_Validating(object sender, CancelEventArgs e)
        {
            string cellContents = salutation.Text.Trim();
            if (cellContents.Length > 10)
            {
                MessageBox.Show("Salutation may not be longer than 10 characters - please correct this.");
                cellContents = cellContents.Remove(10); // Truncate it for the user in case they ignore the message
            }
            salutation.Text = cellContents;
        }

        private void middleName_Validating(object sender, CancelEventArgs e)
        {
            string cellContents = middleName.Text.Trim();
            if (cellContents.Length > 50)
            {
                MessageBox.Show("Middle Name may not be longer than 50 characters - please correct this.");
                cellContents = cellContents.Remove(50); // Truncate it for the user in case they ignore the message
            }
            middleName.Text = cellContents;
        }

        private void suffix_Validating(object sender, CancelEventArgs e)
        {
            string cellContents = suffix.Text.Trim();
            if (cellContents.Length > 10)
            {
                MessageBox.Show("Suffix may not be longer than 10 characters - please correct this.");
                cellContents = cellContents.Remove(10); // Truncate it for the user in case they ignore the message
            }
            suffix.Text = cellContents;
        }

        private void salutation_MouseHover(object sender, EventArgs e)
        {
            enterNewSellersToolTip.SetToolTip(salutation, "Mr., Ms., Mrs., Dr., Fr., etc.");
        }

        private void address1_Validating(object sender, CancelEventArgs e)
        {
            string cellContents = address1.Text.Trim();
            if (cellContents.Length > 80)
            {
                MessageBox.Show("1st Line of Address may not be longer than 80 characters - please correct this.");
                cellContents = cellContents.Remove(80); // Truncate it for the user in case they ignore the message
            }
            address1.Text = cellContents;
        }

        private void address2_Validating(object sender, CancelEventArgs e)
        {
            string cellContents = address2.Text.Trim();
            if (cellContents.Length > 80)
            {
                MessageBox.Show("2nd Line of Address may not be longer than 80 characters - please correct this.");
                cellContents = cellContents.Remove(80); // Truncate it for the user in case they ignore the message
            }
            address2.Text = cellContents;
        }

        private void postOffice_Validating(object sender, CancelEventArgs e)
        {
            string cellContents = postOffice.Text.Trim();
            if (cellContents.Length > 40)
            {
                MessageBox.Show("City/Post Office may not be longer than 40 characters - please correct this.");
                cellContents = cellContents.Remove(40); // Truncate it for the user in case they ignore the message
            }
            postOffice.Text = cellContents;
        }

        private void state_Validating(object sender, CancelEventArgs e)
        {
            string cellContents = state.Text.Trim();
            if (cellContents.Length > 20)
            {
                MessageBox.Show("State/Province may not be longer than 20 characters - please correct this.");
                cellContents = cellContents.Remove(20); // Truncate it for the user in case they ignore the message
            }
            state.Text = cellContents;
        }

        private void postalCode_Validating(object sender, CancelEventArgs e)
        {
            string cellContents = postalCode.Text.Trim();
            if (cellContents.Length > 10)
            {
                MessageBox.Show("ZIP/Postal Code may not be longer than 10 characters - please correct this.");
                cellContents = cellContents.Remove(10); // Truncate it for the user in case they ignore the message
            }
            postalCode.Text = cellContents;
        }

        private void country_Validating(object sender, CancelEventArgs e)
        {
            string cellContents = country.Text.Trim();
            if (cellContents.Length > 20)
            {
                MessageBox.Show("Country may not be longer than 20 characters - please correct this.");
                cellContents = cellContents.Remove(20); // Truncate it for the user in case they ignore the message
            }
            country.Text = cellContents;
        }

        private void email_Validating(object sender, CancelEventArgs e)
        {
            string cellContents = email.Text.Trim();
            if (cellContents.Length > 80)
            {
                MessageBox.Show("Email Address may not be longer than 80 characters - please correct this.");
                cellContents = cellContents.Remove(80); // Truncate it for the user in case they ignore the message
            }
            email.Text = cellContents;
        }

        private void phone1_MouseHover(object sender, EventArgs e)
        {
            enterNewSellersToolTip.SetToolTip(phone1, "Digits only, no parentheses, periods, or dashes");
        }

        private void phone1_Validating(object sender, CancelEventArgs e)
        {
            ulong phoneno;
            string cellContents = phone1.Text.Trim();
            if (cellContents.Length > 15)
            {
                MessageBox.Show("Phone No. 1 may not be longer than 15 digits - please correct this.");
                cellContents = cellContents.Remove(15); // Truncate it for the user in case they ignore the message
            }
            else if (cellContents.Length > 0 && !ulong.TryParse(cellContents, out phoneno))
            {
                MessageBox.Show("Phone No. 1 must be a number without formatting characters - please correct this.");
                cellContents = "";
            }
            phone1.Text = cellContents;
        }

        private void phone2_MouseHover(object sender, EventArgs e)
        {
            enterNewSellersToolTip.SetToolTip(phone2, "Digits only, no parentheses, periods, or dashes");
        }

        private void memberID_Validating(object sender, CancelEventArgs e)
        {
            string cellContents = memberID.Text.Trim();
            if (cellContents.Length > 15)
            {
                MessageBox.Show("Member ID may not be longer than 10 characters - please correct this.");
                cellContents = cellContents.Remove(15); // Truncate it for the user in case they ignore the message
            }
            memberID.Text = cellContents;
        }

        private void phone2_Validating(object sender, CancelEventArgs e)
        {
            ulong phoneno;
            string cellContents = phone2.Text.Trim();
            if (cellContents.Length > 15)
            {
                MessageBox.Show("Phone No. 2 may not be longer than 15 digits - please correct this.");
                cellContents = cellContents.Remove(15); // Truncate it for the user in case they ignore the message
            }
            else if (cellContents.Length > 0 && !ulong.TryParse(cellContents, out phoneno))
            {
                MessageBox.Show("Phone No. 2 must be a number without formatting characters - please correct this.");
                cellContents = "";
            }
            phone2.Text = cellContents;
        }
    }
}
