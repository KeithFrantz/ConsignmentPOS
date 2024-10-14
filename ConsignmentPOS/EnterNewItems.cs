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
    public partial class EnterNewItems : UserControl
    {
        public EnterNewItems()
        {
            InitializeComponent();
        }

        private void findSellersButton_Click(object sender, EventArgs e)
        {
            // Load the dropdown of sellers by calling select_sellers_as_string SP with parameters from filter textboxes
            SqlCommand cmd = new SqlCommand("select_sellers_as_strings", DataManager.dbc);
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
                seller.DataSource = dt;
            }
            if (seller.Items.Count > 0) // If any sellers were found, one will be selected in the dropdown, so show the Items grid
            {
                itemDataGridView.Visible = true;
                itemDataGridViewLabel.Visible = true;
                printButton.Enabled = true;
            }
            else // No sellers returned, so since new items can't be entered without a seller, hide the Items grid and associated controls
            {
                itemDataGridView.Visible = false;
                itemDataGridViewLabel.Visible = false;
                priceDataGridView.Visible = false;
                priceDataGridViewLabel.Visible = false;
                locationCB.Visible = false;
                locationLabel.Visible = false;
                longDescTextBox.Visible = false;
                longDescTextBoxLabel.Visible = false;
                printButton.Enabled = false;
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("A list of the selected seller's registered items (if any) will be printed");
            ReceiptPrinting instance = new ReceiptPrinting();
            instance.PrintSellersReceipt((int)seller.SelectedValue, seller.Text.Length>67?seller.Text.Remove(67):seller.Text, 1); // Just print 1 copy
        }

        private void EnterNewItems_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) locationCB.DataSource = locationTableAdapter.GetData(); // Refresh location grid each time control is made visible
        }

        private void itemDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (itemDataGridView.RowCount > 0  && itemDataGridView.CurrentRow != null)
            {
                int currentItemRowIndex = itemDataGridView.CurrentRow.Index;
                // If the Short Description is missing in the current item row, hide the Location dropdown and Long Description textbox
                if (itemDataGridView.Rows[currentItemRowIndex].Cells[0].Value == null ||
                    ((string)itemDataGridView.Rows[currentItemRowIndex].Cells[0].Value).Length == 0)
                {
                    locationCB.Visible = false;
                    locationLabel.Visible = false;
                    longDescTextBox.Visible = false;
                    longDescTextBoxLabel.Visible = false;
                }
                else
                {
                    locationCB.Visible = true;
                    locationLabel.Visible = true;
                    longDescTextBox.Visible = true;
                    longDescTextBoxLabel.Visible = true;
                }
                // If either Short Description or Qty. for Sale is missing in the current item row, hide the Price Breaks grid
                if (itemDataGridView.Rows[currentItemRowIndex].Cells[0].Value == null || 
                    ((string)itemDataGridView.Rows[currentItemRowIndex].Cells[0].Value).Length == 0 ||
                    itemDataGridView.Rows[currentItemRowIndex].Cells[1].Value == null  ||
                    ((string)itemDataGridView.Rows[currentItemRowIndex].Cells[1].Value).Length == 0)
                {
                    priceDataGridView.Visible = false;
                    priceDataGridViewLabel.Visible = false;
                }
                else
                {
                    int qtyForSale;
                    // Make sure the Qty. for Sale is an integer > 0
                    if (!int.TryParse((string)itemDataGridView.Rows[currentItemRowIndex].Cells["qtyAtStart"].Value, out qtyForSale)
                        || qtyForSale < 1)
                    {
                        priceDataGridView.Visible = false;
                        priceDataGridViewLabel.Visible = false;
                        MessageBox.Show("Qty. for Sale must be an integer greater than or equal to 1 - please correct this.");
                        itemDataGridView.Rows[itemDataGridView.CurrentRow.Index].Cells["qtyAtStart"].Value = "";
                        return;
                    }
                    priceDataGridView.Visible = true;
                    priceDataGridViewLabel.Visible = true;
                    // If the Qty. for Sale changed and is now 1 (which will usually be the case) disallow multiple quantity breaks and allow just one row  
                    // in the Price Breaks grid with a Minimum Quantity fixed at 1
                    if (e.ColumnIndex == 1)
                    {
                        priceDataGridView.RowsRemoved -= priceDataGridView_RowsRemoved;
                        if (qtyForSale == 1)
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
                        // If there's already pricing info in the item grid,
                        if (itemDataGridView.Rows[itemDataGridView.CurrentRow.Index].Cells["pricing"].Value != null &&
                            itemDataGridView.Rows[itemDataGridView.CurrentRow.Index].Cells["pricing"].Value.ToString() != "")
                        {
                            // Remove any rows from the Price Breaks grid with a Minimum Qty. greater than the (new) Qty. for Sale, or blank
                            int row = priceDataGridView.RowCount - 2; // Ignore the "new" row
                            while (row > 0)
                            {
                                if ((string)priceDataGridView.Rows[row].Cells["quantity_break"].Value == "") priceDataGridView.Rows.RemoveAt(row);
                                else if (int.Parse((string)priceDataGridView.Rows[row].Cells["quantity_break"].Value) > qtyForSale) priceDataGridView.Rows.RemoveAt(row);
                                else break;
                                row--;
                            }
                        }
                        else
                        {
                            // Otherwise start off with a "clean slate" - one row, Minimum Qty. = 1, no Price
                            // Temporarily disable handling cell value change events from the Price Breaks grid while programmatic changes are made
                            priceDataGridView.CellValueChanged -= this.priceDataGridView_CellValueChanged;
                            priceDataGridView.Rows.Clear();
                            priceDataGridView.Rows.Add();
                            priceDataGridView.Rows[0].Cells[0].Value = "1";
                            priceDataGridView.Rows[0].Cells[1].Value = "";
                            priceDataGridView.CellValueChanged += this.priceDataGridView_CellValueChanged;
                        }
                        priceDataGridView.RowsRemoved += priceDataGridView_RowsRemoved;
                    }
                }
            }
        }

        private void priceDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
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
                    if (newMinQty > int.Parse((string)itemDataGridView.Rows[itemDataGridView.CurrentRow.Index].Cells["qtyAtStart"].Value))
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
                    if (itemDataGridView.RowCount > 0 && itemDataGridView.CurrentRow != null &&
                        int.Parse((string)itemDataGridView.Rows[itemDataGridView.CurrentRow.Index].Cells["qtyAtStart"].Value) > 1 &&
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
                    if (itemDataGridView.RowCount > 0 && itemDataGridView.CurrentRow != null &&
                       int.Parse((string)itemDataGridView.Rows[itemDataGridView.CurrentRow.Index].Cells["qtyAtStart"].Value) > 1 &&
                       e.RowIndex < (priceDataGridView.RowCount - 2) &&  // i.e. there's a committed row after the one whose value changed
                       double.TryParse((string)priceDataGridView.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value, out otherRowPrice) &&
                       newPrice <= otherRowPrice)
                    {
                        MessageBox.Show("New price must be greater than the price for the following minimum quantity - please correct this");
                        priceDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                }
                // If all rows in the price grid have both a quantity and a price, update the Pricing cell for the current row in the items grid
                Boolean priceGridComplete = true;
                string pricingContents = "";
                // If there's only 1 of the currrent item for sale, there won't be a new row, because the price breaks grid won't allow adding in that case
                for (int i = 0; i < priceDataGridView.RowCount - (priceDataGridView.AllowUserToAddRows?1:0); i++)
                {
                    if (priceDataGridView.Rows[i].Cells[0].Value != null && priceDataGridView.Rows[i].Cells[1].Value != null &&
                        priceDataGridView.Rows[i].Cells[0].Value.ToString() != "" && priceDataGridView.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        if(i == 0) pricingContents = priceDataGridView.Rows[i].Cells[0].Value.ToString() + "," + priceDataGridView.Rows[i].Cells[1].Value.ToString();
                        else pricingContents = pricingContents + "," + priceDataGridView.Rows[i].Cells[0].Value.ToString() + "," + priceDataGridView.Rows[i].Cells[1].Value.ToString();
                    }
                    else 
                    {
                        priceGridComplete = false;
                        // Do not complain in this case since the user may still be editing the rows
                        break;
                    }
                }
                if (priceGridComplete == true) 
                {
                    itemDataGridView.CellValueChanged -= itemDataGridView_CellValueChanged;
                    itemDataGridView.Rows[itemDataGridView.CurrentRow.Index].Cells["pricing"].Value = pricingContents;
                    itemDataGridView.CellValueChanged += itemDataGridView_CellValueChanged;
                }
            }
        }  // End of priceDataGridView_CellValueChanged

        private void itemDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // If the Short Description is missing in the current item row, hide the Location dropdown and Long Description textbox
            if (itemDataGridView.Rows[e.RowIndex].Cells[0].Value == null ||
                ((string)itemDataGridView.Rows[e.RowIndex].Cells[0].Value).Length == 0)
            {
                locationCB.Visible = false;
                locationLabel.Visible = false;
                longDescTextBox.Visible = false;
                longDescTextBoxLabel.Visible = false;
            }
            else
            {
                locationCB.Visible = true;
                locationLabel.Visible = true;
                longDescTextBox.Visible = true;
                longDescTextBoxLabel.Visible = true;
            }
            // Load the Long Description from the column's value
            longDescTextBox.Text = (string)itemDataGridView.Rows[e.RowIndex].Cells["longDesc"].Value;
            // Select the location in the dropdown from the column's value
            if (itemDataGridView.Rows[e.RowIndex].Cells["location"].Value != null)
                locationCB.SelectedValue = itemDataGridView.Rows[e.RowIndex].Cells["location"].Value;
            else locationCB.SelectedIndex = 0;

            // If either Short Description or Qty. for Sale is missing in the current item row, hide the Price Breaks grid
            if (itemDataGridView.Rows[e.RowIndex].Cells[0].Value == null ||
                ((string)itemDataGridView.Rows[e.RowIndex].Cells[0].Value).Length == 0 ||
                itemDataGridView.Rows[e.RowIndex].Cells[1].Value == null ||
                ((string)itemDataGridView.Rows[e.RowIndex].Cells[1].Value).Length == 0)
            {
                priceDataGridView.Visible = false;
                priceDataGridViewLabel.Visible = false;
            }
            else
            {
                priceDataGridView.Visible = true;
                priceDataGridViewLabel.Visible = true;
            }
            // Load the Price Breaks grid from the column's value, if defined
            if (itemDataGridView.Rows[e.RowIndex].Cells["pricing"].Value != null &&
                itemDataGridView.Rows[e.RowIndex].Cells["pricing"].Value.ToString().Trim() != "")
            {
                string quantityString, priceString, pricingContents;
                decimal price;
                int startingPoint = 0, row = 0, quantity;
                pricingContents = itemDataGridView.Rows[e.RowIndex].Cells["pricing"].Value.ToString();
                int length = pricingContents.Length;
                int nextComma = pricingContents.IndexOf(',', startingPoint);
                if (nextComma > 0)
                {
                    // Disable event handling for programmatic changes to the Price Breaks grid
                    priceDataGridView.CellValueChanged -= priceDataGridView_CellValueChanged;
                    priceDataGridView.RowsRemoved -= priceDataGridView_RowsRemoved;
                    if (itemDataGridView.Rows[e.RowIndex].Cells["qtyAtStart"].Value.ToString().Trim() == "1")
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
                            MessageBox.Show("Error in the way price breaks were saved in row " + (row + 1).ToString() + "Please re-enter");
                            break;
                        }
                        priceDataGridView.RowCount = row + (priceDataGridView.AllowUserToAddRows?2:1);
                        priceDataGridView.Rows[row].Cells[0].Value = quantityString;
                        priceDataGridView.Rows[row].Cells[1].Value = priceString;
                        row++;
                    } while (nextComma > 0);
                    // Re-enable event handling once programmatic changes are done
                    priceDataGridView.CellValueChanged += priceDataGridView_CellValueChanged;
                    priceDataGridView.RowsRemoved += priceDataGridView_RowsRemoved;
                }
            }
            else // There's no pricing defined for this item yet
            {
                string quantityString;
                if (itemDataGridView.Rows[e.RowIndex].Cells["qtyAtStart"].Value!=null &&
                    (quantityString = itemDataGridView.Rows[e.RowIndex].Cells["qtyAtStart"].Value.ToString().Trim())!= "")
                { // If there's a Qty. for Sale defined for the selected item, set the Price Breaks grid up according to whether it's 1 or more
                    priceDataGridView.CellValueChanged -= priceDataGridView_CellValueChanged;
                    priceDataGridView.RowsRemoved -= priceDataGridView_RowsRemoved;
                    priceDataGridView.Rows.Clear();
                    priceDataGridView.Rows.Add();
                    if (quantityString == "1")
                    {
                        priceDataGridView.AllowUserToAddRows = false; 
                        priceDataGridView.AllowUserToDeleteRows = false;
                        //priceDataGridView.RowCount = 1; 
                        priceDataGridView.Rows[0].Cells[0].Value = "1";
                        priceDataGridView.Columns["quantity_break"].ReadOnly = true;
                        priceDataGridView.Rows[0].Cells[1].Value = "";
                    }
                    else
                    {
                        priceDataGridView.AllowUserToAddRows = true;
                        priceDataGridView.AllowUserToDeleteRows = true;
                        //priceDataGridView.RowCount = 2;
                        priceDataGridView.Columns["quantity_break"].ReadOnly = false;
                        priceDataGridView.Rows[0].Cells[0].Value = "";
                        priceDataGridView.Rows[0].Cells[1].Value = "";
                    }
                    priceDataGridView.CellValueChanged += priceDataGridView_CellValueChanged;
                    priceDataGridView.RowsRemoved += priceDataGridView_RowsRemoved;
                }
                // If there's no Qty. for Sale then the Price Breaks grid is hidden, and will be set up when Qty. for Sale is defined
            }
        }

        private void longDescTextBox_Validated(object sender, EventArgs e)
        {
            // Save the Long Description to the hidden column's cell in the Items grid
            itemDataGridView.Rows[itemDataGridView.CurrentRow.Index].Cells["longDesc"].Value = longDescTextBox.Text;
        }

        private void locationCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (locationCB.SelectedIndex == 0) itemDataGridView.Rows[itemDataGridView.CurrentRow.Index].Cells["location"].Value = null;
            else itemDataGridView.Rows[itemDataGridView.CurrentRow.Index].Cells["location"].Value = locationCB.SelectedValue;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Save each row in the Item grid that has a short description, qty. for sale, and pricing information
            // Warn about rows that are missing pricing information since that may be hidden when Save is clicked
            SqlCommand cmd = new SqlCommand("insert_item", DataManager.dbc);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            string shortDesc;
            bool error = false;
            for (int row = 0; row  < itemDataGridView.Rows.Count; row++)
            {
                if (itemDataGridView.Rows[row].Cells["shortDesc"].Value != null &&
                    (shortDesc = itemDataGridView.Rows[row].Cells["shortDesc"].Value.ToString()) != "" &&
                    itemDataGridView.Rows[row].Cells["qtyAtStart"].Value != null &&
                    itemDataGridView.Rows[row].Cells["qtyAtStart"].Value.ToString() != "")
                {
                    if (itemDataGridView.Rows[row].Cells["pricing"].Value == null ||
                        itemDataGridView.Rows[row].Cells["pricing"].Value.ToString() == "")
                        MessageBox.Show(shortDesc + " has no pricing and will not be saved.", "Warning", 0);
                    else // Save this item and its pricing to the database
                    {
                        int newID;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@seller_id", SqlDbType.Int).Value = (int)seller.SelectedValue;
                        cmd.Parameters.Add("@short_description", SqlDbType.NVarChar).Value = shortDesc;
                        // Use long description only if non-null/empty)
                        if (itemDataGridView.Rows[row].Cells["longDesc"].Value != null &&
                            !String.IsNullOrEmpty(itemDataGridView.Rows[row].Cells["longDesc"].Value.ToString()))
                            cmd.Parameters.Add("@long_description", SqlDbType.NVarChar).Value = itemDataGridView.Rows[row].Cells["longDesc"].Value.ToString();
                        else
                            cmd.Parameters.Add("@long_description", SqlDbType.NVarChar).Value = DBNull.Value;
                        // Use location ID only if non-null and non-zero)
                        if (itemDataGridView.Rows[row].Cells["location"].Value != null &&
                            !String.IsNullOrEmpty(itemDataGridView.Rows[row].Cells["location"].Value.ToString()) &&
                            itemDataGridView.Rows[row].Cells["location"].Value.ToString() != "0")
                            cmd.Parameters.Add("@location_id", SqlDbType.Int).Value = int.Parse(itemDataGridView.Rows[row].Cells["location"].Value.ToString());
                        else
                            cmd.Parameters.Add("@location_id", SqlDbType.Int).Value = DBNull.Value;
                        cmd.Parameters.Add("@quantity_at_start", SqlDbType.Int).Value = int.Parse(itemDataGridView.Rows[row].Cells["qtyAtStart"].Value.ToString());
                        cmd.Parameters.Add("@pricing", SqlDbType.NVarChar).Value = itemDataGridView.Rows[row].Cells["pricing"].Value.ToString();
                        SqlParameter outputIdParam = new SqlParameter("@id", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputIdParam);
                        cmd.ExecuteNonQuery();
                        // If it didn't work, tell the user before moving on to saving the next item
                        newID = outputIdParam.Value as int? ?? 0; // Shouldn't be possible for this to come back null but handle it just in case
                        if (newID == 0)
                        {
                            error = true;
                            MessageBox.Show(shortDesc + " was not successfully added", "Warning", 0);
                        }
                    }
                }
            }
            if (!error) clearButton_Click(null, null);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            itemDataGridView.CellValueChanged -= itemDataGridView_CellValueChanged;
            itemDataGridView.Rows.Clear();
            itemDataGridView.CellValueChanged += itemDataGridView_CellValueChanged;
            priceDataGridView.CellValueChanged -= priceDataGridView_CellValueChanged;
            priceDataGridView.RowsRemoved -= priceDataGridView_RowsRemoved;
            priceDataGridView.Rows.Clear();
            priceDataGridView.CellValueChanged += priceDataGridView_CellValueChanged;
            priceDataGridView.RowsRemoved += priceDataGridView_RowsRemoved;
            priceDataGridView.Visible = false;
            longDescTextBox.Clear();
            longDescTextBox.Visible = false;
            longDescTextBoxLabel.Visible = false;
            locationCB.SelectedValue = 0;
            locationCB.Visible = false;
            locationLabel.Visible = false;
        }

        private void priceDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // Re-save remaining complete rows to the Items grid's pricing column
            Boolean priceGridComplete = true;
            string pricingContents = "";
            // If there's only 1 of the currrent item for sale, there won't be a new row, because the price breaks grid won't allow adding in that case
            for (int i = 0; i < priceDataGridView.RowCount - (priceDataGridView.AllowUserToAddRows ? 1 : 0); i++)
            {
                if (priceDataGridView.Rows[i].Cells[0].Value.ToString() != "" && priceDataGridView.Rows[i].Cells[1].Value.ToString() != ""
                    && priceDataGridView.Rows[i].Cells[0].Value.ToString() != null && priceDataGridView.Rows[i].Cells[1].Value.ToString() != null)
                {
                    if (i == 0) pricingContents = priceDataGridView.Rows[i].Cells[0].Value.ToString() + "," + priceDataGridView.Rows[i].Cells[1].Value.ToString();
                    else pricingContents = pricingContents + "," + priceDataGridView.Rows[i].Cells[0].Value.ToString() + "," + priceDataGridView.Rows[i].Cells[1].Value.ToString();
                }
                else
                {
                    priceGridComplete = false;
                    MessageBox.Show("At least one of the remaining rows in the Price Breaks grid is missing information and therefore the Price Breaks information can't be saved - please correct this");
                    break;
                }
            }
            if (priceGridComplete == true)
            {
                itemDataGridView.CellValueChanged -= itemDataGridView_CellValueChanged;
                itemDataGridView.Rows[itemDataGridView.CurrentRow.Index].Cells["pricing"].Value = pricingContents;
                itemDataGridView.CellValueChanged += itemDataGridView_CellValueChanged;
            }
        }

        private void registrationNoFilter_Validating(object sender, CancelEventArgs e)
        {
            registrationNoFilter.Validating -= registrationNoFilter_Validating;
            int value;
            if (registrationNoFilter.Text.Length > 0 && (!Int32.TryParse(registrationNoFilter.Text, out value) || value < 1))
            {
                MessageBox.Show(registrationNoFilter.Text + " is not an integer greater than 0, which all registration numbers are.  Please enter a valid registration number.",
                    "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                registrationNoFilter.Text = "";
                e.Cancel = true;
            }
            registrationNoFilter.Validating += registrationNoFilter_Validating;
        }
    }
}
