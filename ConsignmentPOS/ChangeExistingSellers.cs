using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentPOS
{
    public partial class ChangeExistingSellers : UserControl
    {
        public ChangeExistingSellers()
        {
            InitializeComponent();
        }

        private void registrationNoFilter_Validating(object sender, CancelEventArgs e)
        {
            int regNo = 1;
            // If there's a registration number entered
            if (!String.IsNullOrEmpty(registrationNoFilter.Text))
            {
                // If the value entered is not an integer > 0
                if (!int.TryParse(registrationNoFilter.Text, out regNo) || regNo < 1)
                {
                    MessageBox.Show(String.Format("The registration number must be an integer greater than 0."));
                    registrationNoFilter.Text = "";
                }
            }
        }

        private void findSellersButton_Click(object sender, EventArgs e)
        {
            // Ask for confirmation if there are any modified (thus unsaved) rows
            if (dataGridView1.RowCount > 0) for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].DefaultCellStyle.BackColor == Color.LightYellow)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to retrieve the sellers from the database and lose the unsaved changes?",
                        "Warning - changes will be lost!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result.Equals(DialogResult.Cancel)) return;
                    break;
                }
            }
            // Load the grid of sellers by calling select_sellers SP with parameters from filter textboxes
            SqlCommand cmd = new SqlCommand("select_sellers", DataManager.dbc);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // Add parameters from filters (use registration # only if non-null/empty)
            if (!String.IsNullOrEmpty(registrationNoFilter.Text))
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(registrationNoFilter.Text);
            else
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@first_name", SqlDbType.NVarChar).Value = firstNameFilter.Text;
            cmd.Parameters.Add("@last_name", SqlDbType.NVarChar).Value = lastNameFilter.Text;
            cmd.Parameters.Add("@actual_sellers", SqlDbType.Bit).Value = actualSellersCB.Checked;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            for (int i = 0; i < dataGridView1.RowCount; i++) dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;// Reset background color of each row
            // Select the first row if there is one
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // When a seller (row in the grid) is selected, fill in the text boxes with that seller's contact information 
            if (dataGridView1.Rows[e.RowIndex].Cells["address1DataGridViewTextBoxColumn"].Value == DBNull.Value) address1.Text = "";
            else address1.Text = (string)dataGridView1.Rows[e.RowIndex].Cells["address1DataGridViewTextBoxColumn"].Value;
            if (dataGridView1.Rows[e.RowIndex].Cells["address2DataGridViewTextBoxColumn"].Value == DBNull.Value) address2.Text = "";
            else address2.Text = (string)dataGridView1.Rows[e.RowIndex].Cells["address2DataGridViewTextBoxColumn"].Value;
            if (dataGridView1.Rows[e.RowIndex].Cells["postOfficeDataGridViewTextBoxColumn"].Value == DBNull.Value) postOffice.Text = "";
            else postOffice.Text = (string)dataGridView1.Rows[e.RowIndex].Cells["postOfficeDataGridViewTextBoxColumn"].Value;
            if (dataGridView1.Rows[e.RowIndex].Cells["stateDataGridViewTextBoxColumn"].Value == DBNull.Value) state.Text = "";
            else state.Text = (string)dataGridView1.Rows[e.RowIndex].Cells["stateDataGridViewTextBoxColumn"].Value;
            if (dataGridView1.Rows[e.RowIndex].Cells["postalCodeDataGridViewTextBoxColumn"].Value == DBNull.Value) postalCode.Text = "";
            else postalCode.Text = (string)dataGridView1.Rows[e.RowIndex].Cells["postalCodeDataGridViewTextBoxColumn"].Value;
            if (dataGridView1.Rows[e.RowIndex].Cells["countryDataGridViewTextBoxColumn"].Value == DBNull.Value) country.Text = "";
            else country.Text = (string)dataGridView1.Rows[e.RowIndex].Cells["countryDataGridViewTextBoxColumn"].Value;
            if (dataGridView1.Rows[e.RowIndex].Cells["emailDataGridViewTextBoxColumn"].Value == DBNull.Value) email.Text = "";
            else email.Text = (string)dataGridView1.Rows[e.RowIndex].Cells["emailDataGridViewTextBoxColumn"].Value;
            if (dataGridView1.Rows[e.RowIndex].Cells["phone1DataGridViewTextBoxColumn"].Value == DBNull.Value) phone1.Text = "";
            else phone1.Text = (string)dataGridView1.Rows[e.RowIndex].Cells["phone1DataGridViewTextBoxColumn"].Value;
            if (dataGridView1.Rows[e.RowIndex].Cells["phone2DataGridViewTextBoxColumn"].Value == DBNull.Value) phone2.Text = "";
            else phone2.Text = (string)dataGridView1.Rows[e.RowIndex].Cells["phone2DataGridViewTextBoxColumn"].Value;
            if (dataGridView1.Rows[e.RowIndex].Cells["memberidDataGridViewTextBoxColumn"].Value == DBNull.Value) memberID.Text = "";
            else memberID.Text = (string)dataGridView1.Rows[e.RowIndex].Cells["memberidDataGridViewTextBoxColumn"].Value;
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

        private void address1_Validated(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentRow.Index;
            //If the 1st line of the address has been changed, update the hidden cell in the grid and mark the row as being modified
            if (!(dataGridView1.Rows[currentRowIndex].Cells["address1DataGridViewTextBoxColumn"].Value == DBNull.Value && address1.Text.Equals(""))
                ||
                (dataGridView1.Rows[currentRowIndex].Cells["address1DataGridViewTextBoxColumn"].Value != DBNull.Value &&
                !address1.Text.Equals((string)dataGridView1.Rows[currentRowIndex].Cells["address1DataGridViewTextBoxColumn"].Value)))
            {
                dataGridView1.Rows[currentRowIndex].Cells["address1DataGridViewTextBoxColumn"].Value = address1.Text;
                dataGridView1.Rows[currentRowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }
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

        private void address2_Validated(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentRow.Index;
            //If the 2nd line of the address has been changed, update the hidden cell in the grid and mark the row as being modified
            if (!(dataGridView1.Rows[currentRowIndex].Cells["address2DataGridViewTextBoxColumn"].Value == DBNull.Value && !address2.Text.Equals(""))
                ||
                (dataGridView1.Rows[currentRowIndex].Cells["address2DataGridViewTextBoxColumn"].Value != DBNull.Value &&
                !address2.Text.Equals((string)dataGridView1.Rows[currentRowIndex].Cells["address2DataGridViewTextBoxColumn"].Value)))
            {
                dataGridView1.Rows[currentRowIndex].Cells["address2DataGridViewTextBoxColumn"].Value = address1.Text;
                dataGridView1.Rows[currentRowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }
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

        private void postOffice_Validated(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentRow.Index;
            //If the City/Post Office has been changed, update the hidden cell in the grid and mark the row as being modified
            if (!(dataGridView1.Rows[currentRowIndex].Cells["postOfficeDataGridViewTextBoxColumn"].Value == DBNull.Value && postOffice.Text.Equals(""))
                ||
                (dataGridView1.Rows[currentRowIndex].Cells["postOfficeDataGridViewTextBoxColumn"].Value != DBNull.Value &&
                !postOffice.Text.Equals((string)dataGridView1.Rows[currentRowIndex].Cells["postOfficeDataGridViewTextBoxColumn"].Value)))
            {
                dataGridView1.Rows[currentRowIndex].Cells["postOfficeDataGridViewTextBoxColumn"].Value = postOffice.Text;
                dataGridView1.Rows[currentRowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }
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

        private void state_Validated(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentRow.Index;
            //If the State/Prov. has been changed, update the hidden cell in the grid and mark the row as being modified
            if (!(dataGridView1.Rows[currentRowIndex].Cells["stateDataGridViewTextBoxColumn"].Value == DBNull.Value && state.Text.Equals(""))
                || 
                (dataGridView1.Rows[currentRowIndex].Cells["stateDataGridViewTextBoxColumn"].Value != DBNull.Value &&
                !state.Text.Equals((string)dataGridView1.Rows[currentRowIndex].Cells["stateDataGridViewTextBoxColumn"].Value)))
            {
                dataGridView1.Rows[currentRowIndex].Cells["stateDataGridViewTextBoxColumn"].Value = state.Text;
                dataGridView1.Rows[currentRowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }
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

        private void postalCode_Validated(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentRow.Index;
            //If the ZIP/Postal Code has been changed, update the hidden cell in the grid and mark the row as being modified
            if (!(dataGridView1.Rows[currentRowIndex].Cells["postalCodeDataGridViewTextBoxColumn"].Value == DBNull.Value && postalCode.Text.Equals(""))
                || 
                (dataGridView1.Rows[currentRowIndex].Cells["postalCodeDataGridViewTextBoxColumn"].Value != DBNull.Value &&
                !postalCode.Text.Equals((string)dataGridView1.Rows[currentRowIndex].Cells["postalCodeDataGridViewTextBoxColumn"].Value)))
            {
                dataGridView1.Rows[currentRowIndex].Cells["postalCodeDataGridViewTextBoxColumn"].Value = postalCode.Text;
                dataGridView1.Rows[currentRowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }
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

        private void country_Validated(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentRow.Index;
            //If the Country has been changed, update the hidden cell in the grid and mark the row as being modified
            if (!(dataGridView1.Rows[currentRowIndex].Cells["countryDataGridViewTextBoxColumn"].Value == DBNull.Value && country.Text.Equals(""))
                ||
                (dataGridView1.Rows[currentRowIndex].Cells["countryDataGridViewTextBoxColumn"].Value != DBNull.Value &&
                !email.Text.Equals((string)dataGridView1.Rows[currentRowIndex].Cells["countryDataGridViewTextBoxColumn"].Value)))
            {
                dataGridView1.Rows[currentRowIndex].Cells["countryDataGridViewTextBoxColumn"].Value = country.Text;
                dataGridView1.Rows[currentRowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }
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

        private void email_Validated(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentRow.Index;
            //If the Email Address has been changed, update the hidden cell in the grid and mark the row as being modified
            if (!(dataGridView1.Rows[currentRowIndex].Cells["emailDataGridViewTextBoxColumn"].Value == DBNull.Value && email.Text.Equals(""))
                ||
                (dataGridView1.Rows[currentRowIndex].Cells["emailDataGridViewTextBoxColumn"].Value != DBNull.Value &&
                !email.Text.Equals((string)dataGridView1.Rows[currentRowIndex].Cells["emailDataGridViewTextBoxColumn"].Value)))
            {
                dataGridView1.Rows[currentRowIndex].Cells["emailDataGridViewTextBoxColumn"].Value = email.Text;
                dataGridView1.Rows[currentRowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }

        private void phone1_MouseHover(object sender, EventArgs e)
        {
            changeExistingSellersToolTip.SetToolTip(phone1, "Digits only, no parentheses, periods, or dashes");
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

        private void phone1_Validated(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentRow.Index;
            //If the 1st phone number has been changed, update the hidden cell in the grid and mark the row as being modified
            if (!(dataGridView1.Rows[currentRowIndex].Cells["phone1DataGridViewTextBoxColumn"].Value == DBNull.Value && phone1.Text.Equals(""))
                ||
                (dataGridView1.Rows[currentRowIndex].Cells["phone1DataGridViewTextBoxColumn"].Value != DBNull.Value &&
                !phone1.Text.Equals((string)dataGridView1.Rows[currentRowIndex].Cells["phone1DataGridViewTextBoxColumn"].Value)))
            {
                dataGridView1.Rows[currentRowIndex].Cells["phone1DataGridViewTextBoxColumn"].Value = phone1.Text;
                dataGridView1.Rows[currentRowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }

        private void phone2_MouseHover(object sender, EventArgs e)
        {
            changeExistingSellersToolTip.SetToolTip(phone2, "Digits only, no parentheses, periods, or dashes");

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

        private void phone2_Validated(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentRow.Index;
            //If the 2nd phone number has been changed, update the hidden cell in the grid and mark the row as being modified
            if (!(dataGridView1.Rows[currentRowIndex].Cells["phone2DataGridViewTextBoxColumn"].Value == DBNull.Value && phone2.Text.Equals(""))
                ||
                (dataGridView1.Rows[currentRowIndex].Cells["phone2DataGridViewTextBoxColumn"].Value != DBNull.Value &&
                !phone2.Text.Equals((string)dataGridView1.Rows[currentRowIndex].Cells["phone2DataGridViewTextBoxColumn"].Value)))
            {
                dataGridView1.Rows[currentRowIndex].Cells["phone2DataGridViewTextBoxColumn"].Value = phone2.Text;
                dataGridView1.Rows[currentRowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }
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

        private void memberid_Validated(object sender, EventArgs e)
        {
            int currentRowIndex = dataGridView1.CurrentRow.Index;
            //If the Member ID number has been changed, update the hidden cell in the grid and mark the row as being modified
            if (!(dataGridView1.Rows[currentRowIndex].Cells["memberidDataGridViewTextBoxColumn"].Value == DBNull.Value && memberID.Text.Equals(""))
                ||
                (dataGridView1.Rows[currentRowIndex].Cells["memberidDataGridViewTextBoxColumn"].Value != DBNull.Value &&
                !memberID.Text.Equals((string)dataGridView1.Rows[currentRowIndex].Cells["memberidDataGridViewTextBoxColumn"].Value)))
            {
                dataGridView1.Rows[currentRowIndex].Cells["memberidDataGridViewTextBoxColumn"].Value = memberID.Text;
                dataGridView1.Rows[currentRowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0) using (var command = new SqlCommand())
            { 
                command.Connection = DataManager.dbc;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE seller SET "+
                    "salutation = @salutation, " +
                    "first_name = @first_name, " +
                    "middle_name = @middle_name, " +
                    "last_name = @last_name, " +
                    "suffix = @suffix, " +
                    "address_1 = @address_1, " +
                    "address_2 = @address_2, " +
                    "post_office = @post_office, " +
                    "state = @state, " +
                    "postal_code = @postal_code, " +
                    "country = @country, " +
                    "phone_1 = @phone_1, " +
                    "phone_2 = @phone_2, " +
                    "email = @email, " +
                    "member_id = @member_id " +
                    "WHERE id = @id";
                int rows;
                for (int i = 0; i < dataGridView1.RowCount; i++) // For each row in dataGridView1
                {
                    if (dataGridView1.Rows[i].DefaultCellStyle.BackColor == Color.LightYellow) // If the row is light yellow something about that seller may be changed
                    {
                        if (dataGridView1.Rows[i].Cells["salutationDataGridViewTextBoxCol"].Value == DBNull.Value ||
                            dataGridView1.Rows[i].Cells["salutationDataGridViewTextBoxCol"].Value == null)
                                command.Parameters.AddWithValue("@salutation", DBNull.Value);
                            else command.Parameters.AddWithValue("@salutation", (string)dataGridView1.Rows[i].Cells["salutationDataGridViewTextBoxCol"].Value);
                        /* First name is not allowed to be null in the seller table as currently set up - if it were, uncomment the following code
                        if (dataGridView1.Rows[i].Cells["firstnameDataGridViewTextBoxColumn"].Value == DBNull.Value ||
                            dataGridView1.Rows[i].Cells["firstnameDataGridViewTextBoxColumn"].Value == null)
                            command.Parameters.AddWithValue("@first_name", DBNull.Value);
                        else*/ command.Parameters.AddWithValue("@first_name", (string)dataGridView1.Rows[i].Cells["firstnameDataGridViewTextBoxColumn"].Value);
                        if (dataGridView1.Rows[i].Cells["middlenameDataGridViewTextBoxColumn"].Value == DBNull.Value ||
                            dataGridView1.Rows[i].Cells["middlenameDataGridViewTextBoxColumn"].Value == null)
                                command.Parameters.AddWithValue("@middle_name", DBNull.Value);
                            else command.Parameters.AddWithValue("@middle_name", (string)dataGridView1.Rows[i].Cells["middlenameDataGridViewTextBoxColumn"].Value);
                        /* Last name is not allowed to be null in the seller table as currently set up - if it were, uncomment the following code
                        if (dataGridView1.Rows[i].Cells["lastnameDataGridViewTextBoxColumn"].Value == DBNull.Value ||
                            dataGridView1.Rows[i].Cells["lastnameDataGridViewTextBoxColumn"].Value == null)
                            command.Parameters.AddWithValue("@last_name", DBNull.Value);
                            else*/ command.Parameters.AddWithValue("@last_name", (string)dataGridView1.Rows[i].Cells["lastnameDataGridViewTextBoxColumn"].Value);
                        if (dataGridView1.Rows[i].Cells["suffixDataGridViewTextBoxColumn"].Value == DBNull.Value ||
                            dataGridView1.Rows[i].Cells["suffixDataGridViewTextBoxColumn"].Value == null)
                                command.Parameters.AddWithValue("@suffix", DBNull.Value);
                            else command.Parameters.AddWithValue("@suffix", (string)dataGridView1.Rows[i].Cells["suffixDataGridViewTextBoxColumn"].Value);
                        if (dataGridView1.Rows[i].Cells["address1DataGridViewTextBoxColumn"].Value == DBNull.Value ||
                            dataGridView1.Rows[i].Cells["address1DataGridViewTextBoxColumn"].Value == null)
                                command.Parameters.AddWithValue("@address_1", DBNull.Value);
                            else command.Parameters.AddWithValue("@address_1", (string)dataGridView1.Rows[i].Cells["address1DataGridViewTextBoxColumn"].Value);
                        if (dataGridView1.Rows[i].Cells["address2DataGridViewTextBoxColumn"].Value == DBNull.Value ||
                            dataGridView1.Rows[i].Cells["address2DataGridViewTextBoxColumn"].Value == null)
                                command.Parameters.AddWithValue("@address_2", DBNull.Value);
                            else command.Parameters.AddWithValue("@address_2", (string)dataGridView1.Rows[i].Cells["address2DataGridViewTextBoxColumn"].Value);
                        if (dataGridView1.Rows[i].Cells["postofficeDataGridViewTextBoxColumn"].Value == DBNull.Value ||
                            dataGridView1.Rows[i].Cells["postofficeDataGridViewTextBoxColumn"].Value == null)
                                command.Parameters.AddWithValue("@post_office", DBNull.Value);
                            else command.Parameters.AddWithValue("@post_office", (string)dataGridView1.Rows[i].Cells["postofficeDataGridViewTextBoxColumn"].Value);
                        if (dataGridView1.Rows[i].Cells["stateDataGridViewTextBoxColumn"].Value == DBNull.Value ||
                            dataGridView1.Rows[i].Cells["stateDataGridViewTextBoxColumn"].Value == null)
                                command.Parameters.AddWithValue("@state", DBNull.Value);
                            else command.Parameters.AddWithValue("@state", (string)dataGridView1.Rows[i].Cells["stateDataGridViewTextBoxColumn"].Value);
                        if (dataGridView1.Rows[i].Cells["postalcodeDataGridViewTextBoxColumn"].Value == DBNull.Value ||
                            dataGridView1.Rows[i].Cells["postalcodeDataGridViewTextBoxColumn"].Value == null) 
                                command.Parameters.AddWithValue("@postal_code", DBNull.Value);
                            else command.Parameters.AddWithValue("@postal_code", (string)dataGridView1.Rows[i].Cells["postalcodeDataGridViewTextBoxColumn"].Value);
                        if (dataGridView1.Rows[i].Cells["countryDataGridViewTextBoxColumn"].Value == DBNull.Value ||
                            dataGridView1.Rows[i].Cells["countryDataGridViewTextBoxColumn"].Value == null)
                                command.Parameters.AddWithValue("@country", DBNull.Value);
                            else command.Parameters.AddWithValue("@country", (string)dataGridView1.Rows[i].Cells["countryDataGridViewTextBoxColumn"].Value);
                        if (dataGridView1.Rows[i].Cells["phone1DataGridViewTextBoxColumn"].Value == DBNull.Value ||
                            dataGridView1.Rows[i].Cells["phone1DataGridViewTextBoxColumn"].Value ==null)
                                command.Parameters.AddWithValue("@phone_1", DBNull.Value);
                            else command.Parameters.AddWithValue("@phone_1", (string)dataGridView1.Rows[i].Cells["phone1DataGridViewTextBoxColumn"].Value);
                        if (dataGridView1.Rows[i].Cells["phone2DataGridViewTextBoxColumn"].Value == DBNull.Value ||
                            dataGridView1.Rows[i].Cells["phone2DataGridViewTextBoxColumn"].Value == null)
                                command.Parameters.AddWithValue("@phone_2", DBNull.Value);
                            else command.Parameters.AddWithValue("@phone_2", (string)dataGridView1.Rows[i].Cells["phone2DataGridViewTextBoxColumn"].Value);
                        if (dataGridView1.Rows[i].Cells["emailDataGridViewTextBoxColumn"].Value == DBNull.Value ||
                            dataGridView1.Rows[i].Cells["emailDataGridViewTextBoxColumn"].Value == null)
                                command.Parameters.AddWithValue("@email", DBNull.Value);
                            else command.Parameters.AddWithValue("@email", (string)dataGridView1.Rows[i].Cells["emailDataGridViewTextBoxColumn"].Value);
                        if (dataGridView1.Rows[i].Cells["memberidDataGridViewTextBoxColumn"].Value == DBNull.Value ||
                            dataGridView1.Rows[i].Cells["memberidDataGridViewTextBoxColumn"].Value == null)
                                command.Parameters.AddWithValue("@member_id", DBNull.Value);
                            else command.Parameters.AddWithValue("@member_id", (string)dataGridView1.Rows[i].Cells["memberidDataGridViewTextBoxColumn"].Value);
                        // Registration number can never be null - it's the PK of the seller table
                        command.Parameters.AddWithValue("@id", (int)dataGridView1.Rows[i].Cells["idDataGridViewTextBoxColumn"].Value);
                        rows = command.ExecuteNonQuery();
                        // If update successful reset the row back to white
                        if (rows == 1) dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        command.Parameters.Clear();
                    }
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                int currentRowIndex = dataGridView1.CurrentRow.Index;
                string cellContents;
                if (dataGridView1.Rows[currentRowIndex].Cells["salutationDataGridViewTextBoxCol"].Value != DBNull.Value &&
                    dataGridView1.Rows[currentRowIndex].Cells["salutationDataGridViewTextBoxCol"].Value != null)
                {
                    cellContents = ((string)dataGridView1.Rows[currentRowIndex].Cells["salutationDataGridViewTextBoxCol"].Value).Trim();
                    if (cellContents.Length > 10)
                    {
                        MessageBox.Show("Salutation may not be longer than 10 characters - please correct this.");
                        cellContents = cellContents.Remove(10); // Truncate it for the user in case they ignore the message
                    }
                    dataGridView1.Rows[currentRowIndex].Cells["salutationDataGridViewTextBoxCol"].Value = cellContents; 
                }
                if (dataGridView1.Rows[currentRowIndex].Cells["firstnameDataGridViewTextBoxColumn"].Value == DBNull.Value ||
                    dataGridView1.Rows[currentRowIndex].Cells["firstnameDataGridViewTextBoxColumn"].Value == null)
                {
                    MessageBox.Show("First name may not be empty - please correct this.");
                }
                else
                {
                    cellContents = ((string)dataGridView1.Rows[currentRowIndex].Cells["firstnameDataGridViewTextBoxColumn"].Value).Trim();
                    if (cellContents.Length > 50)
                    {
                        MessageBox.Show("First Name may not be longer than 50 characters - please correct this.");
                        cellContents = cellContents.Remove(50); // Truncate it for the user in case they ignore the message
                    }
                    else if (cellContents.Length == 0)
                    {
                        MessageBox.Show("First name may not be empty - please correct this.");
                    }
                    dataGridView1.Rows[currentRowIndex].Cells["firstnameDataGridViewTextBoxColumn"].Value = cellContents;
                }
                if (dataGridView1.Rows[currentRowIndex].Cells["middlenameDataGridViewTextBoxColumn"].Value != DBNull.Value &&
                    dataGridView1.Rows[currentRowIndex].Cells["middlenameDataGridViewTextBoxColumn"].Value != null)
                {
                    cellContents = ((string)dataGridView1.Rows[currentRowIndex].Cells["middlenameDataGridViewTextBoxColumn"].Value).Trim();
                    if (cellContents.Length > 50)
                    {
                        MessageBox.Show("Middle Name may not be longer than 50 characters - please correct this.");
                        cellContents = cellContents.Remove(50); // Truncate it for the user in case they ignore the message
                    }
                    dataGridView1.Rows[currentRowIndex].Cells["middlenameDataGridViewTextBoxColumn"].Value = cellContents;
                }
                if (dataGridView1.Rows[currentRowIndex].Cells["lastnameDataGridViewTextBoxColumn"].Value == DBNull.Value ||
                    dataGridView1.Rows[currentRowIndex].Cells["lastnameDataGridViewTextBoxColumn"].Value == null)
                {
                    MessageBox.Show("Last name may not be empty - please correct this.");
                }
                else
                {
                    cellContents = ((string)dataGridView1.Rows[currentRowIndex].Cells["lastnameDataGridViewTextBoxColumn"].Value).Trim();
                    if (cellContents.Length > 50)
                    {
                        MessageBox.Show("Last Name may not be longer than 50 characters - please correct this.");
                        cellContents = cellContents.Remove(50); // Truncate it for the user in case they ignore the message
                    }
                    else if (cellContents.Length == 0)
                    {
                        MessageBox.Show("Last name may not be empty - please correct this.");
                    }
                    dataGridView1.Rows[currentRowIndex].Cells["lastnameDataGridViewTextBoxColumn"].Value = cellContents;
                }
                if (dataGridView1.Rows[currentRowIndex].Cells["suffixDataGridViewTextBoxColumn"].Value != DBNull.Value &&
                    dataGridView1.Rows[currentRowIndex].Cells["suffixDataGridViewTextBoxColumn"].Value != null)
                {
                    cellContents = ((string)dataGridView1.Rows[currentRowIndex].Cells["suffixDataGridViewTextBoxColumn"].Value).Trim();
                    if (cellContents.Length > 10)
                    {
                        MessageBox.Show("Suffix may not be longer than 10 characters - please correct this.");
                        cellContents = cellContents.Remove(10); // Truncate it for the user in case they ignore the message
                    }
                    dataGridView1.Rows[currentRowIndex].Cells["suffixDataGridViewTextBoxColumn"].Value = cellContents;
                }
            }
            if (e.RowIndex>=0) dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow; // How a changed row is signified
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int currentRowIndex, rows;
            if (dataGridView1.RowCount > 0) currentRowIndex = dataGridView1.CurrentRow.Index;
            else return; // Do nothing if button clicked when grid is empty
            DialogResult result = MessageBox.Show(String.Format("Are you sure you want to delete {0} {1}?",
                dataGridView1.Rows[currentRowIndex].Cells["firstnameDataGridViewTextBoxColumn"].Value,
                dataGridView1.Rows[currentRowIndex].Cells["lastnameDataGridViewTextBoxColumn"].Value
                )  + 
                (dataGridView1.Rows[currentRowIndex].DefaultCellStyle.BackColor == Color.LightYellow ? "  Note that this entry has been modified." : ""),
                "Please confirm deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.Cancel)) return;
            using (var command = new SqlCommand())
            {
                command.Connection = DataManager.dbc;
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM seller WHERE id = @id";
                command.Parameters.AddWithValue("@id", (int)dataGridView1.Rows[currentRowIndex].Cells["idDataGridViewTextBoxColumn"].Value);
                rows = command.ExecuteNonQuery();
                // If command successful, remove the deleted seller from the grid
                if (rows == 1) dataGridView1.Rows.RemoveAt(currentRowIndex);
            }
        }
    }
}
