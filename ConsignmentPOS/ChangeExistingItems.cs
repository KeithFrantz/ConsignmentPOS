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
    public partial class ChangeExistingItems : UserControl
    {
        public ChangeExistingItems()
        {
            InitializeComponent();
        }

        private void ChangeExistingItems_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) // Refresh dropdowns each time control is made visible, as their contents don't depend on which item is selected
            {
                locationCB.SelectedIndexChanged -= locationCB_SelectedIndexChanged;
                seller.SelectedIndexChanged -= seller_SelectedIndexChanged;
                // Preserve the current item choices so they can be re-selected, assuming they still exist, which the DB constraints should guarantee
                int sellerFilterValue = 0, locationValue = 0, sellerValue = 0;
                if (sellerFilter.SelectedValue != null) sellerFilterValue = (int)sellerFilter.SelectedValue;
                if (locationCB.SelectedValue != null) locationValue = (int)locationCB.SelectedValue;
                if (seller.SelectedValue != null) sellerValue = (int)seller.SelectedValue;
                locationCB.DataSource = locationTableAdapter.GetData();
                locationCB.SelectedValue = locationValue; // There is always a location 0
                // Load the sellerFilter dropdown by calling select_actual_sellers_as_string SP 
                SqlCommand cmd2 = new SqlCommand("select_actual_sellers_as_strings", DataManager.dbc);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                // This SP has no filters thus the command has no parameters
                cmd2.ExecuteNonQuery();
                using (SqlDataAdapter adap2 = new SqlDataAdapter(cmd2))
                {
                    DataTable dt2 = new DataTable();
                    adap2.Fill(dt2);
                    sellerFilter.DataSource = dt2;
                }
                sellerFilter.SelectedValue = sellerFilterValue;
                // Load the seller dropdown by calling select_sellers_as_string SP with null/blank parameters
                SqlCommand cmd = new SqlCommand("select_sellers_as_strings", DataManager.dbc);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                // No filters
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = DBNull.Value;
                cmd.Parameters.Add("@first_name", SqlDbType.NVarChar).Value = "";
                cmd.Parameters.Add("@last_name", SqlDbType.NVarChar).Value = "";
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    seller.DataSource = dt;
                }
                seller.SelectedValue = sellerValue;
                locationCB.SelectedIndexChanged += locationCB_SelectedIndexChanged;
                seller.SelectedIndexChanged += seller_SelectedIndexChanged;
            }
        }

        private void itemIDFilter_Validating(object sender, CancelEventArgs e)
        {
            if (itemIDFilter.Text == null || itemIDFilter.Text.Length == 0) return;
            int itemID;
            if (!Int32.TryParse(itemIDFilter.Text, out itemID) || itemID < 1)
            {
                MessageBox.Show(itemIDFilter.Text + " is not a valid ID for an item - please correct this.", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                itemIDFilter.Text = "";
                e.Cancel = true;
            }
        }

        private void findItemsButton_Click(object sender, EventArgs e)
        {
            // If there are pending changes, ask the user whether to save them
            if (saveButton.Enabled && MessageBox.Show("There are unsaved changes for item " + itemGridView.CurrentRow.Cells["id"].Value.ToString() +
                " - do you want to reload the items grid, which will lose these changes?", "Confirm action", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) return;
            // Call select_items SP to populate the itemGridView
            SqlCommand cmd = new SqlCommand("select_items", DataManager.dbc);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // Add filters if any
            if (itemIDFilter.Text != null && itemIDFilter.Text.Length > 0)
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = Int32.Parse(itemIDFilter.Text);
            else
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = DBNull.Value;
            cmd.Parameters.Add("@short_description", SqlDbType.NVarChar).Value = shortDescriptionFilter.Text;
            if ((int)sellerFilter.SelectedValue == 0)
                cmd.Parameters.Add("@seller_id", SqlDbType.Int).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@seller_id", SqlDbType.Int).Value = (int)sellerFilter.SelectedValue;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adap.Fill(dt);
                itemGridView.DataSource = dt;
            }
            // Disable the Save and Discard buttons, enable the item grid
            saveButton.Enabled = false;
            discardButton.Enabled = false;
            itemGridView.Enabled = true;
            itemGridView.DefaultCellStyle.BackColor = Color.White;
            // Mark items for which settlement has been made
            foreach (DataGridViewRow row in itemGridView.Rows)
            { 
                if (row.Cells["quantity_returned"].Value != DBNull.Value)
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
//                else
//                    row.DefaultCellStyle.BackColor = Color.White;
            }
            int numItems = itemGridView.Rows.Count;
            shortDescription.Enabled = (numItems > 0);
            seller.Enabled = (numItems > 0);
            locationCB.Enabled = (numItems > 0);
            qtyForSale.Enabled = (numItems > 0);
            longDescTextBox.Enabled = (numItems > 0);
            priceDataGridView.Enabled = (numItems > 0);
        }

        private void itemGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Disable event handling for programmatic changes to the editable controls below the item grid
            shortDescription.TextChanged -= shortDescription_TextChanged;
            seller.SelectedIndexChanged -= seller_SelectedIndexChanged;
            locationCB.SelectedIndexChanged -= locationCB_SelectedIndexChanged;
            qtyForSale.TextChanged -= qtyForSale_TextChanged;
            qtyForSale.Validating -= qtyForSale_Validating;
            longDescTextBox.TextChanged -= longDescTextBox_TextChanged;
            priceDataGridView.CellValueChanged -= priceDataGridView_CellValueChanged;
            priceDataGridView.RowsRemoved -= priceDataGridView_RowsRemoved;
            // Fill in the controls below the itemGridView with the values for the selected row
            DataGridViewRow row = itemGridView.Rows[e.RowIndex];
            //            itemGridView.DefaultCellStyle.BackColor = Color.White;
            bool unsettled = (row.Cells["quantity_returned"].Value == DBNull.Value);
            //    row.DefaultCellStyle.BackColor = Color.LightBlue; // This is for the initial selection of the first row, where the row selection happens before the row is colored
            shortDescription.Text = row.Cells["short_description"].Value.ToString();
            shortDescription.Enabled = unsettled; // Disable this and the other controls if settlement has already been made for the selected item
            seller.SelectedValue = Int32.Parse(row.Cells["seller_id"].Value.ToString());
            seller.Enabled = unsettled;
            locationCB.SelectedValue = Int32.Parse(row.Cells["location_id"].Value.ToString());
            locationCB.Enabled = unsettled;
            qtyForSale.Text = row.Cells["quantity_at_start"].Value.ToString();
            qtyForSale.Enabled = unsettled;
            qtySold.Text = row.Cells["num_sold"].Value.ToString();
            longDescTextBox.Text = row.Cells["long_description"].Value.ToString();
            longDescTextBox.Enabled = unsettled;
            modifiedPricing.Text = row.Cells["pricing"].Value.ToString(); // The modifiedPricing control is an invisible label holding the encoded current contents of the priceDataGridView control
            // Fill the pricing grid - can take as a given that there's legitimate pricing information either from the database initially or the prior edit
            string quantityString, priceString, pricingContents;
            decimal price;
            int startingPoint = 0, rowNo = 0, quantity;
            pricingContents = itemGridView.Rows[e.RowIndex].Cells["pricing"].Value.ToString();
            int length = pricingContents.Length;
            int nextComma = pricingContents.IndexOf(',', startingPoint);
            if (itemGridView.Rows[e.RowIndex].Cells["quantity_at_start"].Value.ToString().Trim() == "1")
            {
                priceDataGridView.AllowUserToAddRows = false;
                priceDataGridView.AllowUserToDeleteRows = false;
                priceDataGridView.Columns["quantity_break"].ReadOnly = true;
            }
            else
            {
                priceDataGridView.AllowUserToAddRows = true;
                priceDataGridView.AllowUserToDeleteRows = true;
                priceDataGridView.Columns["quantity_break"].ReadOnly = false;
            }
            do
            {
                quantityString = pricingContents.Substring(startingPoint, nextComma - startingPoint);
                startingPoint = nextComma + 1;
                nextComma = pricingContents.IndexOf(',', startingPoint);
                priceString = pricingContents.Substring(startingPoint, (nextComma == -1 ? length : nextComma) - startingPoint);
                if (nextComma != -1)
                {
                    startingPoint = nextComma + 1;
                    nextComma = pricingContents.IndexOf(',', startingPoint);
                }
                if (!int.TryParse(quantityString, out quantity) || !decimal.TryParse(priceString, out price))
                {
                    MessageBox.Show("Error in the way price breaks were saved in row " + (rowNo + 1).ToString() + "Please re-enter");
                    break;
                }
                priceDataGridView.RowCount = rowNo + (priceDataGridView.AllowUserToAddRows ? 2 : 1);
                priceDataGridView.Rows[rowNo].Cells[0].Value = quantityString;
                priceDataGridView.Rows[rowNo].Cells[1].Value = priceString;
                rowNo++;
            } while (nextComma > 0);
            priceDataGridView.Enabled = unsettled;
            // Re-enable event handling once programmatic changes are done
            shortDescription.TextChanged += shortDescription_TextChanged;
            seller.SelectedIndexChanged += seller_SelectedIndexChanged;
            locationCB.SelectedIndexChanged += locationCB_SelectedIndexChanged;
            qtyForSale.TextChanged += qtyForSale_TextChanged;
            qtyForSale.Validating += qtyForSale_Validating;
            longDescTextBox.TextChanged += longDescTextBox_TextChanged;
            priceDataGridView.CellValueChanged += priceDataGridView_CellValueChanged;
            priceDataGridView.RowsRemoved += priceDataGridView_RowsRemoved;
            // Enable Delete if there were no sales of this item yet and settlement's not yet beenmade, disable it if there were or it has
            deleteButton.Enabled = (Int32.Parse(qtySold.Text) == 0 && unsettled);
        }

        private void shortDescription_TextChanged(object sender, EventArgs e)
        {
            //if (itemGridView.CurrentRow == null) return; // This can be called when first populating the item grid before there's a current row established
            // Enable the Save and Discard buttons and disable the item grid if the new description differs from the existing one
            if (shortDescription.Text.Trim() != itemGridView.CurrentRow.Cells["short_description"].Value.ToString()) 
            {
                saveButton.Enabled = (shortDescription.Text.Trim().Length > 0); // Disallow saving an item with no short decription
                discardButton.Enabled = true;
                itemGridView.Enabled = false;
                itemGridView.DefaultCellStyle.BackColor = Color.LightGray;
            }
            else if ( // If all the other controls also hold the same value as the row in the grid, disable the Save and Discard buttons and enable the item grid
                (int)seller.SelectedValue == (int)itemGridView.CurrentRow.Cells["seller_id"].Value &&
                (int)locationCB.SelectedValue == (int)itemGridView.CurrentRow.Cells["location_id"].Value &&
                qtyForSale.Text.Trim() == itemGridView.CurrentRow.Cells["quantity_at_start"].Value.ToString() &&
                longDescTextBox.Text.Trim() == itemGridView.CurrentRow.Cells["long_description"].Value.ToString() &&
                modifiedPricing.Text == itemGridView.CurrentRow.Cells["pricing"].Value.ToString())
            {
                saveButton.Enabled = false;
                discardButton.Enabled = false;
                itemGridView.Enabled = true;
                itemGridView.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void seller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemGridView.CurrentRow == null) return;
            // Enable the Save and Discard buttons and disable the item grid if the new seller differs from the existing one
            if ((int)seller.SelectedValue != (int)itemGridView.CurrentRow.Cells["seller_id"].Value)
            {
                saveButton.Enabled = true;
                discardButton.Enabled = true;
                itemGridView.Enabled = false;
                itemGridView.DefaultCellStyle.BackColor = Color.LightGray;
            }
            else if ( // If all the other editable controls also hold the same value as the row in the grid, disable the Save and Discard buttons and enable the item grid
                shortDescription.Text.Trim() == itemGridView.CurrentRow.Cells["short_description"].Value.ToString() &&
                (int)locationCB.SelectedValue == (int)itemGridView.CurrentRow.Cells["location_id"].Value &&
                qtyForSale.Text.Trim() == itemGridView.CurrentRow.Cells["quantity_at_start"].Value.ToString() &&
                longDescTextBox.Text.Trim() == itemGridView.CurrentRow.Cells["long_description"].Value.ToString() &&
                modifiedPricing.Text == itemGridView.CurrentRow.Cells["pricing"].Value.ToString())
            {
                saveButton.Enabled = false;
                discardButton.Enabled = false;
                itemGridView.Enabled = true;
                itemGridView.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void locationCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemGridView.CurrentRow == null) return;
            // Enable the Save and Discard buttons and disable the item grid if the new location differs from the existing one
            if ((int)locationCB.SelectedValue != (int)itemGridView.CurrentRow.Cells["location_id"].Value)
            {
                saveButton.Enabled = true;
                discardButton.Enabled = true;
                itemGridView.Enabled = false;
                itemGridView.DefaultCellStyle.BackColor = Color.LightGray;
            }
            else if ( // If all the other controls also hold the same value as the row in the grid, disable the Save and Discard buttons and enable the item grid
                shortDescription.Text.Trim() == itemGridView.CurrentRow.Cells["short_description"].Value.ToString() &&
                (int)seller.SelectedValue == (int)itemGridView.CurrentRow.Cells["seller_id"].Value &&
                qtyForSale.Text.Trim() == itemGridView.CurrentRow.Cells["quantity_at_start"].Value.ToString() &&
                longDescTextBox.Text.Trim() == itemGridView.CurrentRow.Cells["long_description"].Value.ToString() &&
                modifiedPricing.Text == itemGridView.CurrentRow.Cells["pricing"].Value.ToString())
            {
                saveButton.Enabled = false;
                discardButton.Enabled = false;
                itemGridView.Enabled = true;
                itemGridView.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void qtyForSale_TextChanged(object sender, EventArgs e)
        {
            //if (itemGridView.CurrentRow == null) return;
            // Enable the Save and Discard buttons and disable the item grid if the new quantity for sale differs from the existing one
            if (qtyForSale.Text.Trim() != itemGridView.CurrentRow.Cells["quantity_at_start"].Value.ToString())
            {
                saveButton.Enabled = true;
                discardButton.Enabled = true;
                itemGridView.Enabled = false;
                itemGridView.DefaultCellStyle.BackColor = Color.LightGray;
            }
            else if ( // If all the other controls also hold the same value as the row in the grid, disable the Save and Discard buttons and enable the item grid
                shortDescription.Text.Trim() == itemGridView.CurrentRow.Cells["short_description"].Value.ToString() &&
                (int)seller.SelectedValue == (int)itemGridView.CurrentRow.Cells["seller_id"].Value &&
                (int)locationCB.SelectedValue == (int)itemGridView.CurrentRow.Cells["location_id"].Value &&
                longDescTextBox.Text.Trim() == itemGridView.CurrentRow.Cells["long_description"].Value.ToString() &&
                modifiedPricing.Text == itemGridView.CurrentRow.Cells["pricing"].Value.ToString())
            {
                saveButton.Enabled = false;
                discardButton.Enabled = false;
                itemGridView.Enabled = true;
                itemGridView.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void qtyForSale_Validating(object sender, CancelEventArgs e)
        {
            if (qtyForSaleLabel.Text.Trim().Length == 0)
            {
                saveButton.Enabled = false; // An item must have a Qty. for Sale
                return;
            }
            int quantityForSale;
            if (!Int32.TryParse(qtyForSale.Text, out quantityForSale) || quantityForSale < 1)
            {
                MessageBox.Show(qtyForSale.Text + " is not a legitimate value for Qty. for Sale - please correct this.",
                    "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                qtyForSaleLabel.Text = "";
                saveButton.Enabled = false; // An item must have a Qty. for Sale
                e.Cancel = true;
                return;
            }
            else if (quantityForSale < Int32.Parse(qtySold.Text))
            {
                MessageBox.Show("Qty. for Sale may not be less than Qty. Sold - resetting to the original value.",
                    "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                qtyForSale.Text = itemGridView.CurrentRow.Cells["num_sold"].Value.ToString();
                if ( // If all the other controls also hold the same value as the row in the grid, disable the Save and Discard buttons and enable the item grid
                    shortDescription.Text.Trim() == itemGridView.CurrentRow.Cells["short_description"].Value.ToString() &&
                    (int)seller.SelectedValue == (int)itemGridView.CurrentRow.Cells["seller_id"].Value &&
                    (int)locationCB.SelectedValue == (int)itemGridView.CurrentRow.Cells["location_id"].Value &&
                    longDescTextBox.Text.Trim() == itemGridView.CurrentRow.Cells["long_description"].Value.ToString() &&
                    modifiedPricing.Text == itemGridView.CurrentRow.Cells["pricing"].Value.ToString())
                {
                    saveButton.Enabled = false;
                    discardButton.Enabled = false;
                    itemGridView.Enabled = true;
                    itemGridView.DefaultCellStyle.BackColor = Color.White;
                }
                e.Cancel = true;
                return;
            }
            priceDataGridView.RowsRemoved -= priceDataGridView_RowsRemoved;
            if (quantityForSale == 1)
            {
                priceDataGridView.AllowUserToAddRows = false; // Need to do this before trying to remove extra rows as "new" row can't be removed using RemoveAt
                priceDataGridView.AllowUserToDeleteRows = false;
                priceDataGridView.Columns["quantity_break"].ReadOnly = true;
                if (priceDataGridView.RowCount == 0) priceDataGridView.Rows.Add(); // But this is then needed in case only the new row existed when the Qty. for Sale is changed to 1
            }
            else
            {
                priceDataGridView.Columns["quantity_break"].ReadOnly = false;
                priceDataGridView.AllowUserToAddRows = true;
                priceDataGridView.AllowUserToDeleteRows = true;
            }
            // If there are one or more quantity breaks above the new Qty. for Sale value, ask user to confirm their erasure
            int row = priceDataGridView.RowCount - 2; // Ignore the "new" row
            bool minQuantAboveQtyForSaleFound = false;
            while (row > 0)
            {
                if (priceDataGridView.Rows[row].Cells["quantity_break"].Value.ToString() == "")  // Ignore rows with blank Minimum Qty.
                {
                    row--;
                    continue;
                }
                if (Int32.Parse(priceDataGridView.Rows[row].Cells["quantity_break"].Value.ToString()) > quantityForSale)
                    minQuantAboveQtyForSaleFound = true;
                break;
            }
            if (minQuantAboveQtyForSaleFound)
            {
                if (MessageBox.Show("There is at least one row in the Price Breaks grid having a Minimum Qty. greater than the new Qty. for Sale.  Do you want to keep this new value and erase such rows in the Price Breaks grid?",
                        "Confirm action", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    // Remove any rows from the Price Breaks grid with a Minimum Qty. greater than the (new) Qty. for Sale, or blank
                    while (row > 0)
                    {
                        if ((string)priceDataGridView.Rows[row].Cells["quantity_break"].Value == "") priceDataGridView.Rows.RemoveAt(row); // Remove rows with no Minimum Quantity value
                        else if (int.Parse((string)priceDataGridView.Rows[row].Cells["quantity_break"].Value) > quantityForSale) priceDataGridView.Rows.RemoveAt(row);
                        else break;
                        row--;
                    }
                else
                {
                    qtyForSale.Text = itemGridView.CurrentRow.Cells["num_sold"].Value.ToString();
                    if ( // If all the other controls also hold the same value as the row in the grid, disable the Save and Discard buttons and enable the item grid
                        shortDescription.Text == itemGridView.CurrentRow.Cells["short_description"].Value.ToString() &&
                        (int)seller.SelectedValue == (int)itemGridView.CurrentRow.Cells["seller_id"].Value &&
                        (int)locationCB.SelectedValue == (int)itemGridView.CurrentRow.Cells["location_id"].Value &&
                        longDescTextBox.Text == itemGridView.CurrentRow.Cells["long_description"].Value.ToString() &&
                        modifiedPricing.Text == itemGridView.CurrentRow.Cells["pricing"].Value.ToString())
                    {
                        saveButton.Enabled = false;
                        discardButton.Enabled = false;
                        itemGridView.Enabled = true;
                        itemGridView.DefaultCellStyle.BackColor = Color.White;
                    }
                    e.Cancel = true;
                }
            }
            priceDataGridView.RowsRemoved += priceDataGridView_RowsRemoved;
        } // End of qtyForSale_Validating

        private void longDescTextBox_TextChanged(object sender, EventArgs e)
        {
            //if (itemGridView.CurrentRow == null) return;
            // Enable the Save and Discard buttons and disable the item grid if the new quantity for sale differs from the existing one
            if (longDescTextBox.Text.Trim() != itemGridView.CurrentRow.Cells["long_description"].Value.ToString())
            {
                saveButton.Enabled = true;
                discardButton.Enabled = true;
                itemGridView.Enabled = false;
                itemGridView.DefaultCellStyle.BackColor = Color.LightGray;
            }
            else if ( // If all the other controls also hold the same value as the row in the grid, disable the Save and Discard buttons and enable the item grid
                shortDescription.Text.Trim() == itemGridView.CurrentRow.Cells["short_description"].Value.ToString() &&
                (int)seller.SelectedValue == (int)itemGridView.CurrentRow.Cells["seller_id"].Value &&
                (int)locationCB.SelectedValue == (int)itemGridView.CurrentRow.Cells["location_id"].Value &&
                qtyForSale.Text.Trim() == itemGridView.CurrentRow.Cells["quantity_at_start"].Value.ToString() &&
                modifiedPricing.Text == itemGridView.CurrentRow.Cells["pricing"].Value.ToString())
            {
                saveButton.Enabled = false;
                discardButton.Enabled = false;
                itemGridView.Enabled = true;
                itemGridView.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void priceDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (itemGridView.CurrentRow == null) return;
            // If this event is fired when the grid is empty, or when the new value is null or blank, do nothing
            if (priceDataGridView.CurrentRow != null &&
                    priceDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null &&
                    (string)priceDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != "")
            {
                // If the new value is in the Minimum Qty. column 
                if (e.ColumnIndex == 0)
                {
                    // Make sure it's an integer greater than 0
                    int newMinQty;
                    if (!int.TryParse((string)priceDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value, out newMinQty))
                    {
                        MessageBox.Show("New minimum quantity must be an integer greater than 0 - please correct this");
                        priceDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        return;
                    }
                    // Make sure it's not greater than the Qty. for Sale
                    if (newMinQty > int.Parse(qtyForSale.Text))
                    {
                        MessageBox.Show("New minimum quantity must not be larger that the total Qty. for Sale - please correct this");
                        priceDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        return;
                    }
                    // If it's not in the first row, make sure it's larger than that in the row above
                    int otherRowQty;
                    if (e.RowIndex > 0 &&
                        int.TryParse((string)priceDataGridView.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value, out otherRowQty) &&
                        newMinQty <= otherRowQty)
                    {
                        MessageBox.Show("New minimum quantity must be greater than the preceding minimum quantity - please correct this");
                        priceDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                    // If the selected row in the Items grid has Qty. for Sale > 1 there will be a row after this but maybe it's the "new" row
                    // Only check on the following row's value if it's not, but if it's not, make sure the new value is smaller
                    if (int.Parse(qtyForSale.Text) > 1 &&
                        e.RowIndex < (priceDataGridView.RowCount - 2) &&  // i.e. there's a committed row after the one whose value changed
                        int.TryParse((string)priceDataGridView.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value, out otherRowQty) &&
                        newMinQty >= otherRowQty)
                    {
                        MessageBox.Show("New minimum quantity must be greater than the following minimum quantity - please correct this");
                        priceDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                }
                // The new value is in the Price Each column
                else
                {
                    // Make sure the new price is a number > 0 (no freebies)
                    double newPrice;
                    if (!double.TryParse((string)priceDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value, out newPrice))
                    {
                        MessageBox.Show("New price must be a number greater than 0 - please correct this");
                        priceDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        return;
                    }
                    // If it's not in the first row, make sure the price is less than that in the row above
                    double otherRowPrice;
                    if (e.RowIndex > 0 &&
                        double.TryParse((string)priceDataGridView.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value, out otherRowPrice) &&
                        newPrice >= otherRowPrice)
                    {
                        MessageBox.Show("New price must be less than the price for the preceding minimum quantity - please correct this");
                        priceDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                    // If the selected row in the Items grid has Qty. for Sale > 1 there will be a row after this but maybe it's the "new" row
                    // Only check on the following row's value if it's not, but if it's not, make sure the new value is larger
                    // There may be multiple empty rows after this
                    if (int.Parse(qtyForSale.Text) > 1 &&
                       e.RowIndex < (priceDataGridView.RowCount - 2) &&  // i.e. there's a committed row after the one whose value changed
                       double.TryParse((string)priceDataGridView.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value, out otherRowPrice) &&
                       newPrice <= otherRowPrice)
                    {
                        MessageBox.Show("New price must be greater than the price for the following minimum quantity - please correct this");
                        priceDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                }
                // If all rows in the price grid have both a quantity and a price, update the Pricing cell for the current row in the items grid
                bool allPriceBreakRowsOK = true;
                // If there's only 1 of the currrent item for sale, there won't be a new row, because the price breaks grid won't allow adding in that case
                for (int i = 0; i < priceDataGridView.RowCount - (priceDataGridView.AllowUserToAddRows ? 1 : 0); i++)
                {
                    if (priceDataGridView.Rows[i].Cells[0].Value != null && priceDataGridView.Rows[i].Cells[1].Value != null &&
                        priceDataGridView.Rows[i].Cells[0].Value.ToString() != "" && priceDataGridView.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        if (i == 0) modifiedPricing.Text = priceDataGridView.Rows[i].Cells[0].Value.ToString() + "," + priceDataGridView.Rows[i].Cells[1].Value.ToString();
                        else modifiedPricing.Text += "," + priceDataGridView.Rows[i].Cells[0].Value.ToString() + "," + priceDataGridView.Rows[i].Cells[1].Value.ToString();
                    }
                    else
                    {
                        // Do not complain in this case since the user may still be editing the rows, but record discrepany
                        allPriceBreakRowsOK = false;
                        break;
                    }
                }
                if (allPriceBreakRowsOK)
                {
                    if (modifiedPricing.Text != itemGridView.CurrentRow.Cells["pricing"].Value.ToString())
                    {
                        saveButton.Enabled = true;
                        discardButton.Enabled = true;
                        itemGridView.Enabled = false;
                        itemGridView.DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else if ( // If all the other controls also hold the same value as the row in the grid, disable the Save and Discard buttons and enable the item grid
                        shortDescription.Text.Trim() == itemGridView.CurrentRow.Cells["short_description"].Value.ToString() &&
                        (int)seller.SelectedValue == (int)itemGridView.CurrentRow.Cells["seller_id"].Value &&
                        (int)locationCB.SelectedValue == (int)itemGridView.CurrentRow.Cells["location_id"].Value &&
                        qtyForSale.Text.Trim() == itemGridView.CurrentRow.Cells["quantity_at_start"].Value.ToString() &&
                        longDescTextBox.Text.Trim() == itemGridView.CurrentRow.Cells["long_description"].Value.ToString())
                    {
                        saveButton.Enabled = false;
                        discardButton.Enabled = false;
                        itemGridView.Enabled = true;
                        itemGridView.DefaultCellStyle.BackColor = Color.White;
                    }
                }
                else // Price Breaks information is incomplete, disallow saving
                {
                    saveButton.Enabled = false;
                    discardButton.Enabled = true;
                    itemGridView.Enabled = false;
                    itemGridView.DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }

        private void priceDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // Re-save remaining complete rows to the Items grid's pricing column
            modifiedPricing.Text = "";
            // If there's only 1 of the currrent item for sale, there won't be a new row, because the price breaks grid won't allow adding in that case
            for (int i = 0; i < priceDataGridView.RowCount - (priceDataGridView.AllowUserToAddRows ? 1 : 0); i++)
            {
                if (priceDataGridView.Rows[i].Cells[0].Value.ToString() != "" && priceDataGridView.Rows[i].Cells[1].Value.ToString() != ""
                    && priceDataGridView.Rows[i].Cells[0].Value.ToString() != null && priceDataGridView.Rows[i].Cells[1].Value.ToString() != null)
                {
                    if (i == 0) modifiedPricing.Text = priceDataGridView.Rows[i].Cells[0].Value.ToString() + "," + priceDataGridView.Rows[i].Cells[1].Value.ToString();
                    else modifiedPricing.Text += "," + priceDataGridView.Rows[i].Cells[0].Value.ToString() + "," + priceDataGridView.Rows[i].Cells[1].Value.ToString();
                }
                else
                {
                    MessageBox.Show("At least one of the remaining rows in the Price Breaks grid is missing information and that row plus those following it can't be saved - please correct this");
                    saveButton.Enabled = false;
                    break;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Update the item record and price records - use a stored procedure so it can all be in a transaction
            SqlCommand cmd = new SqlCommand("change_item", DataManager.dbc);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // Add parameters
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Int32.Parse(itemGridView.CurrentRow.Cells["id"].Value.ToString());
            cmd.Parameters.Add("@seller_id", SqlDbType.Int).Value = Int32.Parse(seller.SelectedValue.ToString());
            cmd.Parameters.Add("@short_description", SqlDbType.NVarChar).Value = shortDescription.Text.Trim();
            if ((longDescTextBox.Text.Trim()).Length == 0)
                cmd.Parameters.Add("@long_description", SqlDbType.NVarChar).Value = DBNull.Value;
            else
                cmd.Parameters.Add("@long_description", SqlDbType.NVarChar).Value = longDescTextBox.Text.Trim();
            cmd.Parameters.Add("@location_id", SqlDbType.Int).Value = (int)locationCB.SelectedValue;
            cmd.Parameters.Add("@quantity_at_start", SqlDbType.Int).Value = Int32.Parse(qtyForSale.Text);
            cmd.Parameters.Add("@pricing", SqlDbType.NVarChar).Value = modifiedPricing.Text;
            int numRows = cmd.ExecuteNonQuery();
            // If successful
            if (numRows > 0)
            {
                // update the row in the item grid
                itemGridView.CurrentRow.Cells["short_description"].Value = shortDescription.Text.Trim();
                itemGridView.CurrentRow.Cells["long_description"].Value = longDescTextBox.Text.Trim();
                itemGridView.CurrentRow.Cells["seller_id"].Value = Int32.Parse(seller.SelectedValue.ToString());
                itemGridView.CurrentRow.Cells["location_id"].Value = (int)locationCB.SelectedValue;
                itemGridView.CurrentRow.Cells["description"].Value = locationCB.Text;
                itemGridView.CurrentRow.Cells["quantity_at_start"].Value = qtyForSale.Text.Trim();
                itemGridView.CurrentRow.Cells["pricing"].Value = modifiedPricing.Text;
                // and enable the item grid and disable Save and Discard buttons
                saveButton.Enabled = false;
                discardButton.Enabled = false;
                itemGridView.Enabled = true;
                itemGridView.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void discardButton_Click(object sender, EventArgs e)
        {
            // Reload the editing controls by calling itemGridView_RowEnter
            DataGridViewCellEventArgs ex = new DataGridViewCellEventArgs(0, itemGridView.CurrentRow.Index); 
            itemGridView_RowEnter(discardButton, ex);
            // Disable the Save and Discard buttons, enable the item grid
            saveButton.Enabled = false;
            discardButton.Enabled = false;
            itemGridView.Enabled = true;
            itemGridView.DefaultCellStyle.BackColor = Color.White;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Delete the currently selected item from the database, using a stored procedure since FK_price_item is not cascade-delete
            SqlCommand cmd = new SqlCommand("delete_item", DataManager.dbc);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // Add parameter
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Int32.Parse(itemGridView.CurrentRow.Cells["id"].Value.ToString());
            int numRows = cmd.ExecuteNonQuery();
            // If successful remove this row from the item grid
            if (numRows != 0)
                itemGridView.Rows.Remove(itemGridView.CurrentRow);
            else
                MessageBox.Show("Failed to detete item " + itemGridView.CurrentRow.Cells["id"].Value.ToString() + " and/or its price information",
                    "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    } // End of partial class ChangeExistingItems
} // End of namespace
