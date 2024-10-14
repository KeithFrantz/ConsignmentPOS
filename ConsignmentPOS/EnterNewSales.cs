using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentPOS
{
    public partial class EnterNewSales : UserControl
    {
        public EnterNewSales()
        {
            InitializeComponent();
        }
        private void recalculateTotalSaleAndChange()
        {
            decimal totalSale = 0;
            foreach (DataGridViewRow row in newSaleItemsGridView.Rows)
            {
                if (row.Cells["amount"].Value != null &&
                    row.Cells["amount"].Value != DBNull.Value &&
                    row.Cells["amount"].Value.ToString() != "")
                    totalSale += Decimal.Parse(row.Cells["amount"].Value.ToString());
            }
            saleAmount.Text = String.Format(totalSale.ToString("F2", CultureInfo.InvariantCulture));
            if (!String.IsNullOrEmpty(tendered.Text))
            {
                if (saleAmount.Text == "0.00")
                {
                    change.Text = "";
                    completeSaleButton.Enabled = false;
                }
                else
                {
                    decimal changeAmt = decimal.Parse(tendered.Text) - totalSale;
                    if (changeAmt < 0)
                    {
                        MessageBox.Show("Entry in Amount Tendered is less than Total Sale Amount - please correct this");
                        tendered.Validating -= tendered_Validating;
                        tendered.Validated -= tendered_Validated;
                        tendered.Text = change.Text = "";
                        completeSaleButton.Enabled = false;
                        tendered.Validating += tendered_Validating;
                        tendered.Validated += tendered_Validated;
                    }
                    else
                    {
                        change.Text = String.Format(changeAmt.ToString("F2", CultureInfo.InvariantCulture));
                        completeSaleButton.Enabled = true;
                    }
                }
            }
        }
        private void newSaleItemsGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // When initializing this event fires with e.RowIndex = -1
            {
                int quantity;
                if (e.ColumnIndex == 0) // The value change was in the Item ID column
                {
                    // Look up the short description from the supplied Item ID if it's a valid number > 1
                    int item_id;
                    if (newSaleItemsGridView.Rows[e.RowIndex].Cells[0].Value != null &&
                        newSaleItemsGridView.Rows[e.RowIndex].Cells[0].Value != DBNull.Value &&
                        int.TryParse(newSaleItemsGridView.Rows[e.RowIndex].Cells[0].Value.ToString(), out item_id) && item_id >= 1)
                    {
                        using (var command = new SqlCommand())
                        {
                            command.Connection = DataManager.dbc;
                            command.CommandType = CommandType.Text;
                            command.CommandText = String.Format(@"SELECT short_description FROM item WHERE id = {0}", item_id);
                            SqlDataReader reader = command.ExecuteReader();
                            newSaleItemsGridView.CellValueChanged -= this.newSaleItemsGridView_CellValueChanged;
                            newSaleItemsGridView.Rows[e.RowIndex].Cells["short_description"].Value = ""; // In case the item ID is wrong, display a blank Short Description
                            while (reader.Read())
                            {
                                newSaleItemsGridView.Rows[e.RowIndex].Cells["short_description"].Value = reader.GetSqlString(0);
                            }
                            newSaleItemsGridView.CellValueChanged += this.newSaleItemsGridView_CellValueChanged;
                            reader.Close();
                        }
                        if (newSaleItemsGridView.Rows[e.RowIndex].Cells["short_description"].Value.ToString() == "")
                        {
                            MessageBox.Show(newSaleItemsGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + " does not match any item ID in the database - please re-enter it");
                            // If there's now no Item ID, the Unit Price and Ext. Price are also invalidated, so clear them too
                            newSaleItemsGridView.CellValueChanged -= this.newSaleItemsGridView_CellValueChanged;
                            newSaleItemsGridView.Rows[e.RowIndex].Cells["price"].Value = "";
                            newSaleItemsGridView.Rows[e.RowIndex].Cells["amount"].Value = "";
                            newSaleItemsGridView.CellValueChanged += this.newSaleItemsGridView_CellValueChanged;
                            recalculateTotalSaleAndChange();
                            return;
                        }
                    }
                    else
                    {
                        if(newSaleItemsGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null &&
                            newSaleItemsGridView.Rows[e.RowIndex].Cells[0].Value != DBNull.Value)
                            MessageBox.Show(newSaleItemsGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + 
                                " is not an integer number greater than 0 and can't be an Item ID - please correct this",
                                "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Turn off event handling temporarily for the following programmatic change
                        newSaleItemsGridView.CellValueChanged -= this.newSaleItemsGridView_CellValueChanged;
                        newSaleItemsGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ""; // Clear the bogus Item ID
                        newSaleItemsGridView.Rows[e.RowIndex].Cells["short_description"].Value = ""; // // Also clear any Short Description previously entered
                        // If there's now no Item ID, the Unit Price and Ext. Price are also invalidated, so clear them too
                        newSaleItemsGridView.Rows[e.RowIndex].Cells["price"].Value = "";
                        newSaleItemsGridView.Rows[e.RowIndex].Cells["amount"].Value = "";
                        recalculateTotalSaleAndChange();
                        newSaleItemsGridView.CellValueChanged += this.newSaleItemsGridView_CellValueChanged;
                        return;
                    }
                }
                // If the value change was in the Qty. column and a legitimate Item ID is already filled in (as indicated by a Short Description being present)
                // or if the Qty. is already filled in with a legitimate value when the Item ID is filled in, get the prices.
                if ((e.ColumnIndex == 2 &&
                    newSaleItemsGridView.Rows[e.RowIndex].Cells["short_description"].Value != null &&
                    newSaleItemsGridView.Rows[e.RowIndex].Cells["short_description"].Value != DBNull.Value &&
                    newSaleItemsGridView.Rows[e.RowIndex].Cells["short_description"].Value.ToString() != "")
                    ||
                    (e.ColumnIndex == 0 &&
                    newSaleItemsGridView.Rows[e.RowIndex].Cells["quantity"].Value != null &&
                    newSaleItemsGridView.Rows[e.RowIndex].Cells["quantity"].Value != DBNull.Value &&
                    int.TryParse(newSaleItemsGridView.Rows[e.RowIndex].Cells["quantity"].Value.ToString(), out quantity) &&
                    quantity >= 1))
                {
                    int qty_left = 0;
                    decimal price = 0;
                    using (var command = new SqlCommand())
                    {
                        command.Connection = DataManager.dbc;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = @"dbo.select_item_price";
                        SqlParameter parameterItemId = new SqlParameter("@item_id", SqlDbType.Int);
                        parameterItemId.Value = int.Parse(newSaleItemsGridView.Rows[e.RowIndex].Cells["item_id"].Value.ToString());
                        command.Parameters.Add(parameterItemId);
                        if (!int.TryParse(newSaleItemsGridView.Rows[e.RowIndex].Cells["quantity"].Value.ToString(), out quantity) || quantity < 1)
                        {
                            MessageBox.Show(newSaleItemsGridView.Rows[e.RowIndex].Cells["quantity"].Value.ToString() + " is not an integer number greater than 0 - please correct this");
                            // Turn off event handling temporarily for the following programmatic change
                            newSaleItemsGridView.CellValueChanged -= newSaleItemsGridView_CellValueChanged;
                            newSaleItemsGridView.Rows[e.RowIndex].Cells["quantity"].Value = ""; // Clear the bogus Qty.
                            // If there's now no Qty, the Unit Price and Ext. Price are also invalidated, so clear them too
                            newSaleItemsGridView.Rows[e.RowIndex].Cells["price"].Value = "";
                            newSaleItemsGridView.Rows[e.RowIndex].Cells["amount"].Value = "";
                            recalculateTotalSaleAndChange();
                            newSaleItemsGridView.CellValueChanged += newSaleItemsGridView_CellValueChanged;
                            return; // Don't try to process this event further
                        }
                        SqlParameter parameterQuantity = new SqlParameter("@quantity", SqlDbType.Int);
                        parameterQuantity.Value = quantity;
                        command.Parameters.Add(parameterQuantity);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            price = reader.GetDecimal(0);
                            qty_left = reader.GetInt32(1);
                        }
                        reader.Close();
                    }
                    if (qty_left < quantity)
                    {
                        if (qty_left > 0)
                            MessageBox.Show(String.Format("The database only shows {0} unit(s) of this item remaining for sale; please check the Item ID and Qty.", qty_left));
                        else
                            MessageBox.Show("The database shows no units of this item remaining for sale; please check the Item ID and Qty.");
                    }
                    newSaleItemsGridView.CellValueChanged -= newSaleItemsGridView_CellValueChanged;
                    newSaleItemsGridView.Rows[e.RowIndex].Cells["price"].Value = price.ToString("0.00");
                    newSaleItemsGridView.Rows[e.RowIndex].Cells["amount"].Value = (price * quantity).ToString("0.00");
                    newSaleItemsGridView.CellValueChanged += newSaleItemsGridView_CellValueChanged;
                    recalculateTotalSaleAndChange();
                }
            // Don't respond to changes in other colunms as they're being made programmatically
            }
        }

        private void tendered_Validating(object sender, CancelEventArgs e)
        {
            // Make sure Amount Tendered is a legitimate number and > Total Sale Amount (which is never blank and always an number)
            decimal amt_tendered;
            tendered.Validating -= tendered_Validating;
            tendered.Validated -= tendered_Validated;
            if (!decimal.TryParse(tendered.Text, out amt_tendered))
            {
                MessageBox.Show("Entry in Amount Tendered is not a number - please correct this");
                tendered.Text = change.Text = "";
                completeSaleButton.Enabled = false;
            }
            else if (amt_tendered < decimal.Parse(saleAmount.Text))
            {
                MessageBox.Show("Entry in Amount Tendered is less than Total Sale Amount - please correct this");
                tendered.Text = change.Text = "";
                completeSaleButton.Enabled = false;
            }
            else
                tendered.Text = String.Format(amt_tendered.ToString("F2", CultureInfo.InvariantCulture));
            tendered.Validating += tendered_Validating;
            tendered.Validated += tendered_Validated;
        }

        private void tendered_Validated(object sender, EventArgs e)
        {
            // If Amount Tendered is not blank (meaning it's a legitimate amount) and Total Sale Amount isn't 0, fill in Change as the difference
            decimal totalSale = decimal.Parse(saleAmount.Text);
            if (tendered.Text.Length > 0 && totalSale > 0)
            {
                change.Text = String.Format((decimal.Parse(tendered.Text) - totalSale).ToString("F2", CultureInfo.InvariantCulture));
                completeSaleButton.Enabled = true;
            }
            else completeSaleButton.Enabled = false;
        }

        private void newSaleItemsGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // If the row removed had an Ext. Price, then removing it should trigger a recalculation of Sale Amount and Change
            recalculateTotalSaleAndChange();
        }

        private void completeSaleButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert_sale", DataManager.dbc);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.Add("@tendered", SqlDbType.Decimal).Value = decimal.Parse(tendered.Text);
            cmd.Parameters.Add("@change", SqlDbType.Decimal).Value = decimal.Parse(change.Text);
            // Assemble the item_id, quantity, and amount information from each row in the grid into a @sale_items string parameter
            string saleItems = "", saleItemsTrimmed;
            int numRows = 0;
            foreach (DataGridViewRow row in newSaleItemsGridView.Rows)
            {
                if (row.Cells["amount"].Value != null &&
                    row.Cells["amount"].Value != DBNull.Value &&
                    row.Cells["amount"].Value.ToString() != "") // If there's an entry in the Ext. Price column, include this row's information
                {
                    saleItems += row.Cells["item_id"].Value.ToString().Trim() + "," +
                        row.Cells["quantity"].Value.ToString().Trim() + "," +
                        row.Cells["amount"].Value.ToString().Trim() + ",";
                    numRows++;
                }
            }
            // Trim off the last comma
            if (numRows > 0) saleItemsTrimmed = saleItems.Remove(saleItems.Length - 1);
            else
            {
                MessageBox.Show("There are no items in this sale yet - please enter at least one before clicking Complete Sale");
                return;
            }
            cmd.Parameters.Add("@sale_items", SqlDbType.NVarChar).Value = saleItemsTrimmed;
            SqlParameter outputIdParam = new SqlParameter("@id", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputIdParam);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.Message.Substring(0, 50).Equals("Violation of UNIQUE KEY constraint 'UK_sale_item'."))
                {
                    int dupItem, comma, closeParenthesis;
                    comma = ex.Message.IndexOf(',', 50);
                    closeParenthesis = ex.Message.IndexOf(')', 50);
                    if (comma > 0 && closeParenthesis > comma && Int32.TryParse(ex.Message.Substring(comma+ 1, closeParenthesis - (comma + 1)),out dupItem))
                    {
                        MessageBox.Show("Item ID " + dupItem.ToString() + " is listed more than once - please combine them all into one line item");
                    }
                    else MessageBox.Show(ex.Message, "Warning", 0);
                }
                else MessageBox.Show(ex.Message, "Warning", 0);
                return;
            }
            // If it didn't work but didn't throw an exception, tell the user
            int newID = outputIdParam.Value as int? ?? 0; // Shouldn't be possible for this to come back null but handle it just in case
            if (newID == 0)
            {
                MessageBox.Show("Sale was not successfully added", "Warning", 0);
                return;
            }
            saleID.Text = newID.ToString();
            reprintButton.Enabled = true;
            // Do the things the clearButton does when clicked but without the confirmation message (that's why you can't just call clearButton.PerformClick)
            newSaleItemsGridView.CellValueChanged -= this.newSaleItemsGridView_CellValueChanged;
            newSaleItemsGridView.Rows.Clear();
            newSaleItemsGridView.CellValueChanged += this.newSaleItemsGridView_CellValueChanged;
            tendered.Validating -= tendered_Validating;
            tendered.Validated -= tendered_Validated;
            tendered.Text = change.Text = "";
            tendered.Validating += tendered_Validating;
            tendered.Validated += tendered_Validated;
            saleAmount.Text = "0.00";
            completeSaleButton.Enabled = false;
            ReceiptPrinting instance = new ReceiptPrinting();
            instance.PrintBuyersReceipt(newID, 1);
        }

        private void reprintButton_Click(object sender, EventArgs e)
        {
            ReceiptPrinting instance = new ReceiptPrinting();
            instance.PrintBuyersReceipt(Int32.Parse(saleID.Text), 1); // Just print 1 copy
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Click OK if you are sure you want to clear this form.",
                "Confirmation required", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                newSaleItemsGridView.CellValueChanged -= this.newSaleItemsGridView_CellValueChanged;
                newSaleItemsGridView.Rows.Clear();
                newSaleItemsGridView.CellValueChanged += this.newSaleItemsGridView_CellValueChanged;
                tendered.Validating -= tendered_Validating;
                tendered.Validated -= tendered_Validated;
                tendered.Text = change.Text = "";
                tendered.Validating += tendered_Validating;
                tendered.Validated += tendered_Validated;
                saleAmount.Text = "0.00";
                completeSaleButton.Enabled = false;
            }
        }
    }
}
