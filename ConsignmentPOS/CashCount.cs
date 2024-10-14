using ConsignmentPOS.CoStoreDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentPOS
{
    public partial class CashCount : UserControl
    {
        private void RefreshGridAndTotalShouldBe()
        {
            cashGridView.DataSource = cashTableAdapter.GetData();
            using (var command = new SqlCommand())
            {
                command.Connection = DataManager.dbc;
                command.CommandType = CommandType.Text;
                command.CommandText = @"WITH init_count_cte(starting_amount) AS " +
                    "(SELECT TOP 1 COALESCE(amount_in_store + amount_remote, 0) AS starting_amount FROM cash ORDER BY count_at ASC), " +
                    "total_sales_cte(total_sales) AS " +
                    "(SELECT coalesce(sum(amount), 0) AS total_sales FROM sale_item WHERE superseded = 0), " +
                    "total_paid_cte(total_paid) AS " +
                    "(SELECT coalesce(sum(amount_paid), 0) AS total_paid FROM item) " +
                    "SELECT starting_amount + total_sales - total_paid AS total_cash_should_be FROM init_count_cte JOIN total_sales_cte ON 1 = 1 JOIN total_paid_cte ON 1 = 1";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    totalCashShouldBe.Text = reader.GetDecimal(0).ToString("C");
                }
                reader.Close();
            }
        }
        public CashCount()
        {
            InitializeComponent();
            RefreshGridAndTotalShouldBe();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshGridAndTotalShouldBe();
        }

        private void cashGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (cashGridView.Rows[e.RowIndex] != null && cashGridView.Rows[e.RowIndex].Cells["comment"].Value != null)
                existingComments.Text = cashGridView.Rows[e.RowIndex].Cells["comment"].Value.ToString();
            else existingComments.Clear();
        }

        private void CashCount_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) RefreshGridAndTotalShouldBe(); ; // Refresh location grid each time control is made visible
        }

        private void cashInStore_Validating(object sender, CancelEventArgs e)
        {
            if (cashInStore.Text.Length == 0)
            {
                saveButton.Enabled = false;
                return;
            }
            decimal amt;
            if (!Decimal.TryParse(cashInStore.Text, out amt) || amt < 0M)
            {
                MessageBox.Show(cashInStore.Text + " is not a legitimate entry for the amount of cash to be in the cash box - please correct this",
                    "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cashInStore.Text = "";
                saveButton.Enabled = false;
                e.Cancel = true;
            }
            else if (cashRemote.Text.Length > 0)
            {
                totalCashIs.Text = (amt + Decimal.Parse(cashRemote.Text)).ToString("C");
                if (enteredBy.Text.Length > 1) saveButton.Enabled = true;
            }
            else totalCashIs.Text = "$";
        }

        private void cashRemote_Validating(object sender, CancelEventArgs e)
        {
            if (cashRemote.Text.Length == 0)
            {
                saveButton.Enabled = false;
                return;
            }
            decimal amt;
            if (!Decimal.TryParse(cashRemote.Text, out amt) || amt < 0M)
            {
                MessageBox.Show(cashRemote.Text + " is not a legitimate entry for the amount of cash held remotely - please correct this",
                    "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cashRemote.Text = "";
                saveButton.Enabled = false;
                e.Cancel = true;
            }
            else if (cashInStore.Text.Length > 0)
            {
                totalCashIs.Text = (amt + Decimal.Parse(cashInStore.Text)).ToString("C");
                if (enteredBy.Text.Length > 1) saveButton.Enabled = true;
            }
            else totalCashIs.Text = "$";
        }

        private void enteredBy_Validating(object sender, CancelEventArgs e)
        {
            if (enteredBy.Text.Length == 0)
            {
                saveButton.Enabled = false;
                return;
            }
            if (enteredBy.Text.Length == 1) // At least 2 initials are required 
            {
                MessageBox.Show("\"" + enteredBy.Text + "\" is not adequate to identify the user making the entry, at least 2 characters are required - please correct this",
                    "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                saveButton.Enabled = false;
                e.Cancel = true;
            }
            else if (cashInStore.Text.Length > 0 && cashRemote.Text.Length > 0) saveButton.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (cashGridView.RowCount == 0) // This is the first entry 
            {
                if (totalCashShouldBe.Text == "$0.00") // If no sales made yet, any amount is OK
                {
                    if (MessageBox.Show("You have entered " + cashInStore.Text + " for the amount of cash in the store and " + cashRemote.Text +
                    " for the amount of cash held remotely, for a total of " + totalCashIs.Text +
                    " for the starting amount.  Please confirm this is correct, because these entries cannot be changed once saved.", "Confirm entries", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        return;
                }
                else // If there were already sales, warn user to deduct any cash received from sales so far
                {
                    if (MessageBox.Show("You have entered " + cashInStore.Text + " for the amount of cash in the store and " + cashRemote.Text +
                    " for the amount of cash held remotely, for a total of " + totalCashIs.Text +
                    ". Since this is the first count entered, it will be used as the starting amount, AND SHOULD NOT INCLUDE ANY CASH RECEIVED FROM SALES SO FAR. " + 
                    "Please confirm this is correct, because these entries cannot be changed once saved.", "Confirm entries", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        return;
                }
            }
            else // Not the initial entry, so cash should be correct
            { 
            // Ask user to confirm the entries - 2 diffferent messages depending on whether TotalCashIs and TotalCashShouldBe are the same
            if (totalCashIs.Text == totalCashShouldBe.Text)
            {
                if (MessageBox.Show("You have entered " + cashInStore.Text + " for the amount of cash in the store and " + cashRemote.Text +
                    " for the amount of cash held remotely, for a total of " + totalCashIs.Text +
                    " which is the expected amount.  Please confirm this is correct, because these entries cannot be changed once saved.", "Confirm entries", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
            }
            else
            {
                if (MessageBox.Show("You have entered " + cashInStore.Text + " for the amount of cash in the store and " + cashRemote.Text +
                    " for the amount of cash held remotely, for a total of " + totalCashIs.Text +
                    " which is NOT the same as the expected amount of " + totalCashShouldBe.Text +
                    ".  Please confirm this is correct, because these entries cannot be changed once saved.", "Confirm entries", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;
            }
            }
            // Create a new record in the cash table
            using (var command = new SqlCommand())
            {
                command.Connection = DataManager.dbc;
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();
                command.CommandText = "INSERT INTO cash (count_by, amount_in_store, amount_remote, total_should_be, comment) VALUES (" +
                    "@enteredBy, @cashInStore, @cashRemote, @totalCashShouldBe, @newComments)";
                command.Parameters.AddWithValue("@enteredBy", enteredBy.Text);
                command.Parameters.AddWithValue("@cashInStore", Decimal.Parse(cashInStore.Text));
                command.Parameters.AddWithValue("@cashRemote", Decimal.Parse(cashRemote.Text));
                command.Parameters.AddWithValue("@totalCashShouldBe", Decimal.Parse(totalCashShouldBe.Text.Remove(0, 1)));
                string sanitizedComments = newComments.Text;
                command.Parameters.AddWithValue("@newComments", sanitizedComments);
                int rows;
                try
                {
                    rows = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        "Unable to save cash count information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // If insert unsuccessful let the user know
                if (rows != 1)
                {
                    MessageBox.Show("Unable to save cash count information but no error was reported from the database",
                        "Database problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // Since it was successful, clear the entry fields, disable this button, and refresh the screen
            enteredBy.Text = "";
            cashInStore.Text = "";
            cashRemote.Text = "";
            newComments.Text = "";
            saveButton.Enabled = false;
            RefreshGridAndTotalShouldBe();
        } /// End of saveButton_Click
    } // End of partialclass
} // End of naamespace
