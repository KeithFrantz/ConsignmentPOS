using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentPOS
{
    public partial class SettleWSellers : UserControl
    {
        private Font printFont;
        private StreamReader streamToPrint;

        public SettleWSellers()
        {
            InitializeComponent();
        }

        private void UpdateTotals()
        {
            decimal totalSalesAmount = 0M;
            foreach (DataGridViewRow row in itemsGridView.Rows)
                if (row.Cells["returned"].Value != null && row.Cells["returned"].Value.ToString() != "" && row.DefaultCellStyle.BackColor!=Color.LightBlue) // If settlement is being made on this item
                    totalSalesAmount += (decimal)(row.Cells["sales_amount"].Value); // Include this item's Total Sales in the overall Total Sales
            totalSales.Text = totalSalesAmount.ToString("C");
            commission.Text = (Properties.Settings.Default.CommissionRate * totalSalesAmount).ToString("C"); // Properties.Settings.Default.CommissionRate was 0.15M - changed in V. 0.6
            totalAmountDue.Text = ((1.0M - Properties.Settings.Default.CommissionRate) * totalSalesAmount).ToString("C"); // (1.0M - Properties.Settings.Default.CommissionRate) was 0.85M - changed in V. 0.6 
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
            // Start by clearing items grid in case no sellers are found
            while (itemsGridView.Rows.Count > 0)
            {
                itemsGridView.Rows.Remove(itemsGridView.Rows[0]);
            }
            // Load the grid of sellers by calling select_unsettled_sellers SP with parameters from filter textboxes
            SqlCommand cmd = new SqlCommand("select_unsettled_sellers", DataManager.dbc);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // Add parameters from filters (use registration # only if non-null/empty)
            if (!String.IsNullOrEmpty(registrationNoFilter.Text))
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(registrationNoFilter.Text);
            else
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@first_name", SqlDbType.NVarChar).Value = firstNameFilter.Text;
            cmd.Parameters.Add("@last_name", SqlDbType.NVarChar).Value = lastNameFilter.Text;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adap.Fill(dt);
                sellersGridView.DataSource = dt;
            }
            // Select the first row if there is one
            if (sellersGridView.RowCount > 0)
            {
                sellersGridView.Rows[0].Selected = true;
                sellersGridView.CurrentCell = sellersGridView.Rows[0].Cells[0];
            }
            // Fill in totalSales, commission, and totalAmountDue - at this point all 0 because no items are yet marked for settlement
            totalSales.Text = 0M.ToString("C");
            commission.Text = 0M.ToString("C");
            totalAmountDue.Text = 0M.ToString("C");
            amountPaidSeller.Text = "";
            amountPaidSeller.Enabled = false;
            printRcptButton.Enabled = false;
            settlementButton.Enabled = false;
        }

        private void sellersGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            itemsGridView.CellValueChanged -= itemsGridView_CellValueChanged;
            // Load the grid of unsettled items by calling select_unsettled_items SP with the seller ID for the selected row in the grid as its parameter
            SqlCommand cmd = new SqlCommand("select_unsettled_items", DataManager.dbc);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // Add parameter
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(sellersGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adap.Fill(dt);
                itemsGridView.DataSource = dt;
            }
            foreach (DataGridViewRow row in itemsGridView.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White; // If any row backgrounds were previously light blue, clear them
                // Calculate values for columns not returned from select_unsettled_items
                row.Cells["to_be_returned"].Value = (int)row.Cells["quantity_at_start"].Value - (int)row.Cells["num_sold"].Value;
                row.Cells["to_be_paid"].Value = ((decimal)row.Cells["sales_amount"].Value * 0.85M).ToString("F2");
            }
            // Fill in totalSales, commission, and totalAmountDue - at this point all 0 because no items are yet marked for settlement
            totalSales.Text = 0M.ToString("C");
            commission.Text = 0M.ToString("C");
            totalAmountDue.Text = 0M.ToString("C");
            amountPaidSeller.Text = ""; // Clear this entry as there's no reason this would be the same for another seller
            amountPaidSeller.Enabled = false;
            printRcptButton.Enabled = false;
            settlementButton.Enabled = false;
            // V. 1.0 - Reset the settlement button to its normal text
            settlementButton.Text = "Make Settlement";
            itemsGridView.CellValueChanged += itemsGridView_CellValueChanged;
        }

        private void itemsGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Try to keep user from trying to change the Qty. Returned or Amt. Paid of an item for which settlement has already been made
            if ((e.ColumnIndex == 1 || e.ColumnIndex == 3) && e.RowIndex >= 0 && itemsGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.LightBlue)
                itemsGridView.Cursor = Cursors.No;
            else itemsGridView.Cursor = Cursors.Default;
        }

        private void itemsGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            itemsGridView.Cursor = Cursors.Default;
        }

        private void itemsGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (itemsGridView.CurrentRow.DefaultCellStyle.BackColor == Color.LightBlue)
            {
                MessageBox.Show("You may not change the Quantity Returned or Amount Paid for an item for which settlement has been made.", "Disallowed entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Reset the Qty. Returned cell's value
                itemsGridView.CellValueChanged -= itemsGridView_CellValueChanged;
                itemsGridView.CurrentRow.Cells["returned"].Value = itemsGridView.CurrentRow.Cells["settled_returned"].Value;
                itemsGridView.CurrentRow.Cells["amt_paid"].Value = itemsGridView.CurrentRow.Cells["settled_amt_paid"].Value;
                itemsGridView.CellValueChanged += itemsGridView_CellValueChanged;
                return;
            }
            if (e.ColumnIndex == 1) // The Qty. Returned cell's value has changed
            {
                // Make sure it's an integer >= 0
                int qtyReturned, qtyToBeReturned = int.Parse(itemsGridView.CurrentRow.Cells["to_be_returned"].Value.ToString());
                if (itemsGridView.CurrentRow.Cells["returned"].Value == null || itemsGridView.CurrentRow.Cells["returned"].Value.ToString() == "")
                {
                    // If no other Qty. Returned values are specified, disable the two buttons and clear any Amt. Paid for this item
                    itemsGridView.CellValueChanged -= itemsGridView_CellValueChanged;
                    itemsGridView.CurrentRow.Cells["amt_paid"].Value = "";
                    itemsGridView.CellValueChanged += itemsGridView_CellValueChanged;
                    bool foundAnotherQtyReturned = false;
                    foreach (DataGridViewRow row in itemsGridView.Rows)
                    {
                        if (row.Cells["returned"].Value != null && row.Cells["returned"].Value.ToString() != "")
                        {
                            foundAnotherQtyReturned = true;
                            break;
                        }
                    }
                    if (!foundAnotherQtyReturned) // There are no items for which settlement is being made
                    {
                        printRcptButton.Enabled = false;
                        settlementButton.Enabled = false;
                        amountPaidSeller.Enabled = false;
                    }
                    UpdateTotals();
                    return;
                }
                if (!int.TryParse(itemsGridView.CurrentRow.Cells["returned"].Value.ToString(), out qtyReturned) || qtyReturned < 0)
                {
                    MessageBox.Show(itemsGridView.CurrentRow.Cells["returned"].Value.ToString() +
                        " is not a valid value for the number of items being returned to the seller - please correct this.",
                        "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Clear the cell
                    itemsGridView.CurrentRow.Cells["returned"].Value = null;
                    /*
                    // Disable the two buttons - note that if an item that wasn't to be settled had gotten a non-positive integer entered,
                    // it would be OK for these to be enabled, but the program doesn't know the user's intent, and it's unlikely they'd do that.
                    printRcptButton.Enabled = false;
                    settlementButton.Enabled = false;
                    return;
                    */
                }
                else
                {
                    amountPaidSeller.Enabled = true; // Only enable Amount Paid Seller if there's at least one item to be settled
                    if (qtyReturned != qtyToBeReturned)
                    {
                        if (MessageBox.Show("Note that the number of items being returned (" + itemsGridView.CurrentRow.Cells["returned"].Value.ToString() +
                            ") is not the same as the number of items to be returned to the seller (" + itemsGridView.CurrentRow.Cells["to_be_returned"].Value.ToString() +
                            ") - please verify that this is OK.",
                            "Inconsistent entry", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                        {
                            // Clear the cell
                            itemsGridView.CurrentRow.Cells["returned"].Value = null;
                            // If this were the only returned value that had been specified, then ideally amountPaidSeller would again be disabled, but it's not worth checking
                            /*
                            // Disable the two buttons - see note above 
                            printRcptButton.Enabled = false;
                            settlementButton.Enabled = false;
                            return;
                            */
                        }
                    }
                }
                UpdateTotals();
                // If Amount Paid Seller equals Amount Due Seller, fill in this row's Amt. Paid if it's empty
                // Note that if this point is reached Qty. Returned is specified, so this item is being settled
                // If something is in Amount Paid Seller, it's a legit. amount, so TryParse isn't needed
                if (amountPaidSeller.Text != null && amountPaidSeller.Text != "" && Decimal.Parse(amountPaidSeller.Text) == Decimal.Parse(totalAmountDue.Text.Remove(0, 1)) &&
                    (itemsGridView.CurrentRow.Cells["amt_paid"].Value == null || itemsGridView.CurrentRow.Cells["amt_paid"].Value.ToString() == ""))
                {
                    itemsGridView.CurrentRow.Cells["amt_paid"].Value = itemsGridView.CurrentRow.Cells["to_be_paid"].Value;
                }
            } // End of handling a change to a Qty. Returned cell
            else // It was an Amt. Paid cell that was changed, make sure it's a positive decimal value (which includes 0)
            {
                if (itemsGridView.CurrentRow.Cells["amt_paid"].Value != null && itemsGridView.CurrentRow.Cells["amt_paid"].Value.ToString() != "")
                {
                    decimal amtPd = 0M;
                    if (!Decimal.TryParse(itemsGridView.CurrentRow.Cells["amt_paid"].Value.ToString(), out amtPd) || amtPd < 0M)
                    {
                        MessageBox.Show(itemsGridView.CurrentRow.Cells["amt_paid"].Value.ToString() +
                            " is not a valid value for the amount being paid to a seller for an item - please correct this.",
                            "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Clear the cell
                        itemsGridView.CurrentRow.Cells["amt_paid"].Value = null;
                    }
                }
            }
            // Now whether it was an Amt. Paid or a Qty.Returned cell that was changed, see whether the buttons can be enabled.
            // They can if the sum of the Amt. Paid values for all the rows being settled add up to the Amount Paid Seller
            if (amountPaidSeller.Text != null && amountPaidSeller.Text != "") // If Amount Paid Seller is specified
            {
                // If all the rows with a non-null/blank Qty. Returned value have non-null/blank Amt. Paid value, check the sum of them against the Amount Paid Seller
                bool allSettlementRowsHaveAmtPaid = true;
                decimal totalAmtPaid = 0M;
                foreach (DataGridViewRow row in itemsGridView.Rows)
                {
                    if (row.Cells["returned"].Value != null && row.Cells["returned"].Value.ToString() != "") // If this item is being settled
                    {
                        if (row.Cells["amt_paid"].Value == null || row.Cells["amt_paid"].Value.ToString() == "")
                        {
                            allSettlementRowsHaveAmtPaid = false;
                            break;
                        }
                        else
                            totalAmtPaid += Decimal.Parse(row.Cells["amt_paid"].Value.ToString());
                    }
                    else // Item is not being settled
                        if (row.Cells["returned"].Value != null && row.Cells["returned"].Value.ToString() != "") // If it nevertheless has Amt. Paid filled in
                        MessageBox.Show("Items for which settlement is not being made do not need to have Amt. Paid specified; such values will be ignored",
                            "Extraneous entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } // End of foreach
                if (allSettlementRowsHaveAmtPaid)
                {
                    decimal amtPdSeller;
                    // If they're not equal, disable the two buttons and complain (once)
                    if (!Decimal.TryParse(amountPaidSeller.Text, out amtPdSeller) || totalAmtPaid != amtPdSeller)
                    {
                        printRcptButton.Enabled = false;
                        settlementButton.Enabled = false;
                        if (e.ColumnIndex == 3) MessageBox.Show("Settlement cannot be made until the amount paid to the seller is properly allocated to all items for which settlement is being made");
                    }
                    else // They are equal, so enable the two buttons
                    {
                        printRcptButton.Enabled = true;
                        settlementButton.Enabled = true;
                    }
                }
            } // End of "If Amount Paid Seller is specified"
            else // Amount Paid Seller isn't specified so disable both buttons
            {
                printRcptButton.Enabled = false;
                settlementButton.Enabled = false;
            }
        }

        private void amountPaidSeller_Validating(object sender, CancelEventArgs e)
        {
            decimal amtPdSeller;
            string trimmedAmountPaidSeller = amountPaidSeller.Text.Trim();
            if (trimmedAmountPaidSeller.Length == 0)
            {
                printRcptButton.Enabled = false;
                settlementButton.Enabled = false;
                return;
            }
            if (!Decimal.TryParse(trimmedAmountPaidSeller, out amtPdSeller) || amtPdSeller < 0)
            {
                MessageBox.Show(trimmedAmountPaidSeller +
                    " is not a valid value for the amount being paid to the seller - please correct this.",
                    "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                amountPaidSeller.Text = "";
                e.Cancel = true;
                return;
            }
            // If the Amount Paid Seller is the same as Amount Due Seller, set a flag to indicate the the Amt. Paid values for each item for which
            // settlement is being made will be set to the corresponding Amt. To Pay
            bool resetAmtPaid = true;
            if (amtPdSeller != Decimal.Parse(totalAmountDue.Text.Remove(0, 1))) // Need to get rid of the initial currency sign before parsing
            {
                MessageBox.Show("Note that the amount being paid to the seller (" + trimmedAmountPaidSeller +
                    ") is not the same as the amount due the seller (" + totalAmountDue.Text +
                    ") - either change this or allocate the amount being paid to the seller to the Amt. Paid cells of all the items for which settlement is being made.",
                    "Inconsistent entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                resetAmtPaid = false;
            }
            // Now that there's an acceptable value in the Amount Paid Seller text edit, see if there are any items with a Qty. Returned value
            bool foundAQtyReturned = false;
            bool foundAllAmtsPaid = true; // If resetAmtPaid is false, then every item being settled needs a value in Amt. Paid
            itemsGridView.CellValueChanged -= itemsGridView_CellValueChanged; // This would only actually need to be done if resetAmtPaid is true
            foreach (DataGridViewRow row in itemsGridView.Rows)
            {
                if (row.Cells["returned"].Value != null && row.Cells["returned"].Value.ToString() != "")
                {
                    foundAQtyReturned = true;
                    // If Amount Paid Seller is the expected value set the Amt. Paid to the Amt. To Pay (i.e. allocate the Amount Paid Seller as expected to each item for which settlement is being made)
                    if (resetAmtPaid) row.Cells["amt_paid"].Value = row.Cells["to_be_paid"].Value;
                    else if (row.Cells["amt_paid"].Value == null || row.Cells["amt_paid"].Value.ToString() == "") foundAllAmtsPaid = false;
                }
            }
            itemsGridView.CellValueChanged += itemsGridView_CellValueChanged;
            // If any items have a a Qty. Returned value (i.e. are being settled) and all of these have an Amt. Paid value, enable the two buttons; if not, disable them
            printRcptButton.Enabled = settlementButton.Enabled = foundAQtyReturned && foundAllAmtsPaid;
            // V. 1.0 - Need to reset settlementButton.Text if enabling it for an additional settlement
            if (settlementButton.Enabled == true) settlementButton.Text = "Make Settlement"; 
        }

        // The PrintPage event is raised for each page to be printed.
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            String line = null;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            // Iterate over the file, printing each line.
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }

        private void printRcptButton_Click(object sender, EventArgs e)
        {
            // Create a temporary file to hold the receipt text
            string tempFilePath;
            StreamWriter tempFileStream;
            try
            {
                tempFilePath = Path.GetTempFileName();
            }
            catch
            {
                MessageBox.Show("Could not create a temporary file " + Path.GetTempPath() + " in which to place the receipt text");
                return;
            }
            // Get the heading for the report from the ReceiptHeading property, append " Seller's Receipt " and the current date and time
            string heading = Properties.Settings.Default.ReceiptHeading + " Seller's Receipt " + DateTime.Now.ToString("MM/dd HH:mm");
            try
            {
                using (tempFileStream = File.CreateText(tempFilePath))
                {
                    // Write this as the first line of the file, with a blank second line
                    tempFileStream.WriteLine(heading + "\n");
                    // Write the "Seller" label and the seller's ID and name as the third line, and another blank line foillowing
                    tempFileStream.WriteLine("Seller: {0} - {1} {2} {3}\n",
                        sellersGridView.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value.ToString(),
                        sellersGridView.CurrentRow.Cells["firstnameDataGridViewTextBoxColumn"].Value.ToString(),
                        sellersGridView.CurrentRow.Cells["lastnameDataGridViewTextBoxColumn"].Value.ToString(),
                        sellersGridView.CurrentRow.Cells["suffixDataGridViewTextBoxColumn"].Value.ToString());
                    // Write the header for the items list
                    tempFileStream.WriteLine("Item ID & Description                       Returned Sold  Price @    Sales");
                    // Get the information for each item for which settlement is being made, adding up the # of items actually returned in the process
                    int totalReturnedToSeller = 0;
                    foreach (DataGridViewRow row in itemsGridView.Rows)
                    {
                        // Skip rows not having a value in the returned field, since settlement is not being made for these items
                        // and rows having a light blue background (since settleement was already made for these items) 
                        // or a beige background (since the settlement data could not be recorded for these items)
                        if (row.DefaultCellStyle.BackColor == Color.LightBlue || row.DefaultCellStyle.BackColor == Color.Beige ||
                            row.Cells["returned"].Value == null || row.Cells["returned"].Value.ToString() == "") continue;
                        totalReturnedToSeller += Int32.Parse(row.Cells["returned"].Value.ToString());
                        // Get the first (and maybe the only) pair of price/quantity from the pricing field
                        string priceString, quantityString, pricingContents = row.Cells["pricing"].Value.ToString();
                        int startingPoint = 0, nextComma = pricingContents.IndexOf(',', startingPoint);
                        bool firstRowForItem = true;
                        do
                        {
                            priceString = pricingContents.Substring(startingPoint, nextComma - startingPoint);
                            startingPoint = nextComma + 1;
                            nextComma = pricingContents.IndexOf(',', startingPoint);
                            quantityString = pricingContents.Substring(startingPoint, (nextComma == -1 ? pricingContents.Length : nextComma) - startingPoint);
                            if (nextComma != -1)
                            {
                                startingPoint = nextComma + 1;
                                nextComma = pricingContents.IndexOf(',', startingPoint);
                            }
                            if (firstRowForItem)
                            {
                                tempFileStream.WriteLine("{0,5}: {1,-40} {2,4} {3,4} {4,8} {5,8}",
                                    row.Cells["item_id"].Value.ToString(),
                                    row.Cells["short_description"].Value.ToString(),
                                    row.Cells["returned"].Value.ToString(),
                                    quantityString,
                                    priceString,
                                    (Int32.Parse(quantityString) * Decimal.Parse(priceString)).ToString("F2"));
                                firstRowForItem = false;
                            }
                            else
                                tempFileStream.WriteLine("                                                     {0,4} {1,8} {2,8}",
                                    quantityString,
                                    priceString,
                                    (Int32.Parse(quantityString) * Decimal.Parse(priceString)).ToString("F2"));
                        } while (nextComma > 0);
                    }
                    // Write a blank line, monetary units statement, and total sales, removing leading currency symbol (e.g. $)
                    string monetaryStatement = Properties.Settings.Default.MonetaryUnits;
                    tempFileStream.WriteLine("\n" + monetaryStatement.PadRight(45) + "Total Sales           {0,8}", totalSales.Text.Remove(0, 1));
                    // Write the commmission line
                    tempFileStream.WriteLine("                                             Less {0,2:F0}% Commission   {1,8}", Properties.Settings.Default.CommissionRate * 100,commission.Text.Remove(0, 1));
                    // Write the actual amount paid
                    tempFileStream.WriteLine("                                             Amount Paid           {0,8:F2}", Decimal.Parse(amountPaidSeller.Text));
                    // Write the total number of unsold items returned
                    tempFileStream.WriteLine("                                       Number of Unsold Items Returned {0,4}", totalReturnedToSeller);
                    // Write a blank line and then the 4 release lines
                    tempFileStream.WriteLine("\n" + Properties.Settings.Default.SellersRelease1);
                    tempFileStream.WriteLine(Properties.Settings.Default.SellersRelease2);
                    tempFileStream.WriteLine(Properties.Settings.Default.SellersRelease3);
                    tempFileStream.WriteLine(Properties.Settings.Default.SellersRelease4);
                    // Then 3 blank lines, a line with underscores, and a line with "Seller's signature"
                    tempFileStream.WriteLine("\n\n\n______________________________");
                    tempFileStream.WriteLine("Seller's signature");
                } // End of using
            } // End of try
            catch
            {
                MessageBox.Show("Error writing the receipt text to the temporary file " + tempFilePath);
                return;
            }
            // Print the temp file
            try
            {
                streamToPrint = new StreamReader(tempFilePath);
                try
                {
                    printFont = new Font("Courier New", 10);
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                    // Print the document.
                    pd.Print();
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // Delete the temp file
            File.Delete(tempFilePath);
        }

        private void settlementButton_Click(object sender, EventArgs e)
        {
            int numItemsSuccessUpdate = 0, numItemsFailedUpdate = 0, numRowsAffected;
            // V. 1.0 - Add a branch to handle undoing the settlement of the items in blue
            if (settlementButton.Text == "Make Settlement")
            {
                foreach (DataGridViewRow row in itemsGridView.Rows)
                {
                    // Skip rows not having a value in the returned field,since settlement is not being made for these items
                    // and rows having a blue background, since settlement was already made for these items
                    if (row.Cells["returned"].Value == null || row.Cells["returned"].Value.ToString() == "" ||
                        row.DefaultCellStyle.BackColor == Color.LightBlue) continue;
                    // Update the quantity_returned, amount_paid, and commission fields of the item_records - 
                    // commission being the differnce between sales_amount and amt_paid
                    SqlCommand command = new SqlCommand();
                    command.Connection = DataManager.dbc;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = @"UPDATE item SET quantity_returned = " + row.Cells["returned"].Value.ToString() +
                        ", amount_paid  = " + row.Cells["amt_paid"].Value.ToString() +
                        ", commission = " + (Decimal.Parse(row.Cells["sales_amount"].Value.ToString()) - Decimal.Parse(row.Cells["amt_paid"].Value.ToString())).ToString() +
                        " WHERE id = " + row.Cells["item_id"].Value.ToString();
                    try
                    {
                        numRowsAffected = command.ExecuteNonQuery();
                        // If successful, temporarily give the row a green background and save the settlement values
                        // This is so that the newly-settled items print on the final seller's receipt (if light blue, it wouldn't print)
                        if (numRowsAffected == 1)
                        {
                            row.DefaultCellStyle.BackColor = Color.Green;
                            numItemsSuccessUpdate++;
                            itemsGridView.CellValueChanged -= itemsGridView_CellValueChanged; // Updating the invisible fields would be seen as a change to the Amt. Paid field asthis handled is currently coded
                            row.Cells["settled_returned"].Value = row.Cells["returned"].Value;
                            row.Cells["settled_amt_paid"].Value = row.Cells["amt_paid"].Value;
                            itemsGridView.CellValueChanged += itemsGridView_CellValueChanged;
                        }
                        else
                        {
                            MessageBox.Show("Unable to save settlement information for item " + row.Cells["item_id"].Value.ToString() + " but no error was reported",
                                "Database problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            row.DefaultCellStyle.BackColor = Color.Beige;
                            numItemsFailedUpdate++;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,
                            "Unable to save settlement information for item " + row.Cells["item_id"].Value.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        numItemsFailedUpdate++;
                    }
                }
                // Print a copy of the settlement receipt for the seller (if any items were successfully settled) - this ignores rows with a light blue or orange background, thus the need for temporary colors
                if (numItemsSuccessUpdate > 0) printRcptButton.PerformClick();
                // Change the background of any green rows to light blue
                foreach (DataGridViewRow row in itemsGridView.Rows)
                {
                    if (row.DefaultCellStyle.BackColor == Color.Green) row.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                // Clear the Amount Paid Seller and thus also disable the two buttons if there were any successful updates, as that amount wouldn't be appropriate for a retry
                // Change for V. 1.0 - Don't disable the settlementButton, make it into an Undo instead
                if (numItemsSuccessUpdate > 0)
                {
                    amountPaidSeller.Validating -= amountPaidSeller_Validating;
                    amountPaidSeller.Text = "";
                    amountPaidSeller.Validating += amountPaidSeller_Validating;
                    printRcptButton.Enabled = false;
                    // settlementButton.Enabled = false;
                    settlementButton.Text = "Undo Settlement";
                }
                // Disable the Amount Paid Seller if there were no errors
                if (numItemsFailedUpdate == 0)
                {
                    amountPaidSeller.Enabled = false;
                }
            }
            else // settlementButton.Text is Undo Settlement
            {
                // Ask for confirmation of this action
                if (MessageBox.Show("Click OK if you are sure you want to undo the settlement of all the items with a light blue background",
                    "Confirmation required", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel) return;
                foreach (DataGridViewRow row in itemsGridView.Rows)
                    if (row.DefaultCellStyle.BackColor == Color.LightBlue)
                    {
                        // Revert the quantity_returned, amount_paid, and commission fields of the item_records to nulls 
                        SqlCommand command = new SqlCommand();
                        command.Connection = DataManager.dbc;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = @"UPDATE item SET quantity_returned = null, amount_paid  = null, commission = null" +
                            " WHERE id = " + row.Cells["item_id"].Value.ToString();
                        try
                        {
                            numRowsAffected = command.ExecuteNonQuery();
                            // If successful,  give the row a white background and update the values in the grid
                            if (numRowsAffected == 1)
                            {
                                row.DefaultCellStyle.BackColor = Color.White;
                                numItemsSuccessUpdate++;
                                itemsGridView.CellValueChanged -= itemsGridView_CellValueChanged; // Updating the invisible fields would be seen as a change to the Amt. Paid field asthis handled is currently coded
                                row.Cells["settled_returned"].Value = row.Cells["returned"].Value = null;
                                row.Cells["settled_amt_paid"].Value = row.Cells["amt_paid"].Value = null;
                                itemsGridView.CellValueChanged += itemsGridView_CellValueChanged;
                            }
                            else
                            {
                                MessageBox.Show("Unable to undo settlement information for item " + row.Cells["item_id"].Value.ToString() + " but no error was reported",
                                    "Database problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                // Leave the background light blue
                                numItemsFailedUpdate++;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message,
                                "Unable to undo settlement information for item " + row.Cells["item_id"].Value.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            numItemsFailedUpdate++;
                        }
                    }
                // If any items had their settlement successfully undone, re-enable Amount Paid Seller
                if (numItemsSuccessUpdate > 0) amountPaidSeller.Enabled = true;
                // If there were no errors, revert Undo Settlement to Make Settlement and disable it
                if (numItemsFailedUpdate == 0)
                {
                    settlementButton.Text = "Make Settlement";
                    settlementButton.Enabled = false;
                }
            }
        }
    }
}
