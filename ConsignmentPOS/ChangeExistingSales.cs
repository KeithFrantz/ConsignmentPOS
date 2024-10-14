using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentPOS
{
    public partial class ChangeExistingSales : UserControl
    {
        public ChangeExistingSales()
        {
            InitializeComponent();
            // When this control is initially displayed the datetime filter checkboxes are unchecked so set the display format accordingly
            earliestSaleDateFilter.CustomFormat = " ";
            earliestSaleDateFilter.Format = DateTimePickerFormat.Custom;
            earliestSaleTimeFilter.CustomFormat = " ";
            earliestSaleTimeFilter.Format = DateTimePickerFormat.Custom;
            latestSaleDateFilter.CustomFormat = " ";
            latestSaleDateFilter.Format = DateTimePickerFormat.Custom;
            latestSaleTimeFilter.CustomFormat = " ";
            latestSaleTimeFilter.Format = DateTimePickerFormat.Custom;
            //saleFilterGroupBox.Location = new System.Drawing.Point(132, 37);
        }

        public string GetShortDescFromId(int id)
        {
            string shortDescription = "";
            using (var command = new SqlCommand())
            {
                command.Connection = DataManager.dbc;
                command.CommandType = CommandType.Text;
                command.CommandText = @"SELECT short_description FROM item WHERE id = " + id.ToString();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    shortDescription = reader.GetString(0);
                }
                reader.Close();
            }
            return shortDescription;
        }

        private void FillInPricesFromIdAndQuantity (int id, int quantity, int original_quantity, int rowIndex)
        {
            int qty_left = 0;
            decimal price = 0;
            using (var command = new SqlCommand())
            {
                command.Connection = DataManager.dbc;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = @"dbo.select_item_price";
                SqlParameter parameterItemId = new SqlParameter("@item_id", SqlDbType.Int);
                parameterItemId.Value = id.ToString();
                command.Parameters.Add(parameterItemId);
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
            if (qty_left < quantity - original_quantity)
            {
                if (qty_left > 0)
                    MessageBox.Show(String.Format("The database only shows {0} unit(s) of this item remaining for sale; please check the Item ID and Qty.", qty_left));
                else
                    MessageBox.Show("The database shows no units of this item remaining for sale; please check the Item ID and Qty.");
            }
            changeSaleItemGridView.Rows[rowIndex].Cells["price"].Value = price.ToString("0.00");
            changeSaleItemGridView.Rows[rowIndex].Cells["amount"].Value = (price * quantity).ToString("0.00");
        }

        private void UpdateSaleValuesColorAndSaveSalesState(int rowIndex)
        {
            //
            // This method updates the No. of Items and Total Amount of the indicated row in the changeSaleGridView based on the indicated changes to items in the
            // changeSaleItemGridView, sets the background color of that row, and enables or disables the Save Sales button.  The background color is
            // White if it is unchanged, or Light Yellow if it has been changed.  If the sale row's background is Pink (meaning it is to be deleted) it is left as is.
            // It requires that the colors in the changeSaleItemGridView be set correctly before it is called,
            // and that the values in the When Sold and Tendered columns be legitimate datetime and decimal values respectively (so <Class>.Parse works) if they're not null or empty
            //
            // Assume Save Sales button should be enabled unless shown otherwise
            saveSalesButton.Enabled = true;
            if (changeSaleGridView.Rows[rowIndex].DefaultCellStyle.BackColor == Color.Pink) return; // If a sale is to be deleted, then its When Sold, Amt. Tendered, and items don't matter
            int numItems = 0;
            decimal saleAmount = 0.00M;
            // Assume the sale is unchanged until shown otherwise
            changeSaleGridView.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
            // If the sale is not being deleted, check each of its items 
            foreach (DataGridViewRow row in changeSaleItemGridView.Rows)
            {
                // Count the number of rows that have a non-null/non-blank Short Description, except for items to be deleted
                if (row.Cells["short_description"].Value != null && row.Cells["short_description"].Value.ToString() != "" && row.DefaultCellStyle.BackColor != Color.Pink)
                    numItems++;
                // Add up the non-null/non-blank Ext. Price (amount) values for any item that isn't to be deleted
                if (row.Cells["amount"].Value != null && row.Cells["amount"].Value.ToString() != "" && row.DefaultCellStyle.BackColor != Color.Pink)
                    saleAmount += Decimal.Parse(row.Cells["amount"].Value.ToString());
                // If an item is to be deleted, is changed, or is a new item with a quantity entered (meaning there'll be an Ext. Price)
                if (row.DefaultCellStyle.BackColor == Color.Pink || row.DefaultCellStyle.BackColor == Color.LightYellow ||
                    (row.DefaultCellStyle.BackColor == Color.LightGreen && row.Cells["amount"].Value != null && row.Cells["amount"].Value.ToString() != ""))
                {
                    changeSaleGridView.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                    // If any row that's been marked doesn't have an Ext. Price then disable Save
                    if (row.Cells["amount"].Value == null || row.Cells["amount"].Value.ToString() == "")
                    {
                        saveSalesButton.Enabled = false;
                    }
                }
            }
            // Update the No. of Items and Total Amount in the designated row of the changeSaleGridView
            changeSaleGridView.CellValueChanged -= changeSaleGridView_CellValueChanged;
            changeSaleGridView.Rows[rowIndex].Cells["num_items"].Value = numItems;
            changeSaleGridView.Rows[rowIndex].Cells["sale_amount"].Value = saleAmount;
            changeSaleGridView.CellValueChanged += changeSaleGridView_CellValueChanged;
            // If the modified Total Amount is now more than the Amt. Tendered, complain and disable the Save Sales button, but don't clear Amt. Tendered, as there may be further item changes
            if (saleAmount > Decimal.Parse(changeSaleGridView.Rows[rowIndex].Cells["tendered"].Value.ToString()))
            {
                MessageBox.Show("Amt. Tendered is less than the Sale Amount - please correct this.", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                saveSalesButton.Enabled = false;
            }
            if (saveSalesButton.Enabled == false) return; // The only way the SaveSales button is disabled at this point is if an item row has no Ext. Price, which can only happen if it's changed, and thus the sale would have already been marked as changed
            // Now check the sale's When Sold and Tendered to see if they match their original values - if either is null or blank the sale is changed but not capable of being saved
            if (changeSaleGridView.Rows[rowIndex].Cells["when_sold"].Value == null || changeSaleGridView.Rows[rowIndex].Cells["when_sold"].Value.ToString() == "" ||
                changeSaleGridView.Rows[rowIndex].Cells["tendered"].Value == null || changeSaleGridView.Rows[rowIndex].Cells["tendered"].Value.ToString() == "")
            {
                changeSaleGridView.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                saveSalesButton.Enabled = false;
            }
            // If these values are present but don't match their original values then just mark the sales as having been changed, leaving Save Sales enabled
            else if (DateTime.Parse(changeSaleGridView.Rows[rowIndex].Cells["when_sold"].Value.ToString()) != DateTime.Parse(changeSaleGridView.Rows[rowIndex].Cells["original_when_sold"].Value.ToString()) ||
                Decimal.Parse(changeSaleGridView.Rows[rowIndex].Cells["tendered"].Value.ToString()) != Decimal.Parse(changeSaleGridView.Rows[rowIndex].Cells["original_tendered"].Value.ToString()))
                changeSaleGridView.Rows[rowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            // Disable Save Sales button if all sales are unchanged (i.e. all changeSaleGridViewrows have white backgrounds)
            // Note that this isn't the only reason this button may be disabled - it could be because a sale or item row is missing information
            bool allWhite = true;
            foreach (DataGridViewRow sale in changeSaleGridView.Rows)
            {
                if(sale.DefaultCellStyle.BackColor != Color.White) 
                {
                    allWhite = false;
                    break;
                }
            }
            if (allWhite) saveSalesButton.Enabled = false;
        }

        public string BuildItemsContents()
        {
            string itemsContents = "";
            bool firstLegitRow = true, itemGridComplete = true;
            foreach (DataGridViewRow row in changeSaleItemGridView.Rows)
            {
                // If amount is present then item_id and quantity are also present
                if (row.Cells["amount"].Value != null && row.Cells["amount"].Value.ToString() != "")
                {
                    if (!firstLegitRow) itemsContents += ",";
                    firstLegitRow = false;
                    if (row.DefaultCellStyle.BackColor == Color.Pink)
                    {
                        itemsContents += "D:";
                    }
                    else if (row.DefaultCellStyle.BackColor == Color.LightYellow)
                    {
                        itemsContents += "C:";
                    }
                    else if (row.DefaultCellStyle.BackColor == Color.LightGreen)
                    {
                        itemsContents += "I:";
                    }
                    itemsContents += row.Cells["item_id"].Value.ToString() + "," + row.Cells["quantity"].Value.ToString() + "," + row.Cells["amount"].Value.ToString();
                }
                // If it's not a new row, i.e. has an original item, or it's a new row with either but not both an item and a quantity
                else if ((row.Cells["original_item_id"].Value != null && row.Cells["original_item_id"].Value.ToString() != "") || // New row
                    (row.Cells["item_id"].Value != null && row.Cells["item_id"].Value.ToString() != "" && (row.Cells["quantity"].Value == null || row.Cells["quantity"].Value.ToString() == "")) || // Has item_id, no quantity
                    ((row.Cells["item_id"].Value == null || row.Cells["item_id"].Value.ToString() != "") && row.Cells["quantity"].Value != null && row.Cells["quantity"].Value.ToString() != "")) // Has quantity, no item_id
                {
                    itemGridComplete = false;
                    MessageBox.Show("Row " + (row.Index + 1).ToString() +
                        " in the items grid is missing information.  If the different row in the sales grid is selected all changes made since the current row was selected will be lost.",
                        "Incomplete entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (itemGridComplete) return itemsContents;
            else return "";
        }


        private void earliestSaleDateFilter_ValueChanged(object sender, EventArgs e)  // Validating event doesn't fire when checkbox is checked or unchecked
        {
            if (!earliestSaleDateFilter.Checked)
            {
                // Hide date and time values since it's not checked
                earliestSaleDateFilter.CustomFormat = " ";
                earliestSaleDateFilter.Format = DateTimePickerFormat.Custom;
                earliestSaleTimeFilter.CustomFormat = " ";
                earliestSaleTimeFilter.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                earliestSaleDateFilter.CustomFormat = null;
                earliestSaleDateFilter.Format = DateTimePickerFormat.Short;
                earliestSaleTimeFilter.CustomFormat = null;
                earliestSaleTimeFilter.Format = DateTimePickerFormat.Time;
            }
        }

        private void earliestSaleDateFilter_Validating(object sender, CancelEventArgs e)
        {
            // If the earliest and latest datetime filters are both active and the earliest date filter value is later than the latest date filter value, complain
            if (earliestSaleDateFilter.Checked && latestSaleDateFilter.Checked)
            {
                DateTime dateEarliest, dateLatest, dt;
                CultureInfo inv = new CultureInfo("");
                if (!DateTime.TryParseExact(earliestSaleDateFilter.Value.ToString("yyyy-MM-dd") + " 00:00:00", "yyyy-MM-dd HH:mm:ss", inv, DateTimeStyles.None, out dateEarliest))
                {
                    MessageBox.Show("Cannot convert the text in the earliest filter date control into a date - unable to validate",
                        "Formatting problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    earliestSaleDateFilter.Checked = false;
                    return;
                }
                if (!DateTime.TryParseExact(latestSaleDateFilter.Value.ToString("yyyy-MM-dd") + " 00:00:00", "yyyy-MM-dd HH:mm:ss", inv, DateTimeStyles.None, out dateLatest))
                {
                    MessageBox.Show("Cannot convert the text in the earliest filter date control into a date - unable to validate",
                        "Formatting problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    earliestSaleDateFilter.Checked = false;
                    return;
                }
                if (dateEarliest > dateLatest)
                {
                    MessageBox.Show("The earliest filter date must be earlier than or equal to the latest filter date - please correct this",
                        "Inconsistent filter values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // and set the earliest date filter value to that of the latest,
                    earliestSaleDateFilter.ValueChanged -= earliestSaleDateFilter_ValueChanged;
                    earliestSaleDateFilter.Validating -= earliestSaleDateFilter_Validating;
                    earliestSaleDateFilter.Value = dateLatest;
                    earliestSaleDateFilter.ValueChanged += earliestSaleDateFilter_ValueChanged;
                    earliestSaleDateFilter.Validating += earliestSaleDateFilter_Validating;
                    // and the earliest time filter value to midnight
                    if (DateTime.TryParseExact(latestSaleTimeFilter.Value.ToString("yyyy-MM-dd") + " 00:00:00", "yyyy-MM-dd HH:mm:ss", inv, DateTimeStyles.None, out dt))
                    {
                        earliestSaleTimeFilter.Validating -= earliestSaleTimeFilter_Validating;
                        earliestSaleTimeFilter.Value = dt;
                        earliestSaleTimeFilter.Validating += earliestSaleTimeFilter_Validating;
                    }
                }
                // Also do the same check as when the value of the earliest time filter is being validated
                else if (dateEarliest == dateLatest && earliestSaleTimeFilter.Value > latestSaleTimeFilter.Value) // The date portions of the time filter values should always be the same, today
                {
                    MessageBox.Show("The earliest filter time must be earlier than or equal to the lastest filter time since the dates are the same - please correct this",
                        "Inconsistent filter values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (DateTime.TryParseExact(latestSaleTimeFilter.Value.ToString("yyyy-MM-dd") + " 00:00:00", "yyyy-MM-dd HH:mm:ss", inv, DateTimeStyles.None, out dt))
                    {
                        earliestSaleTimeFilter.Validating -= earliestSaleTimeFilter_Validating;
                        earliestSaleTimeFilter.Value = dt;
                        earliestSaleTimeFilter.Validating += earliestSaleTimeFilter_Validating;
                    }
                    else // if the datetime for midnight on the current date can't be gotten, clear both the earliest date and time filter values
                    {
                        earliestSaleDateFilter.Checked = false;
                    }
                }
            }
        }

        private void earliestSaleTimeFilter_Validating(object sender, CancelEventArgs e)
        {
            // If both filters are active, the dates are the same, and the earliest time is later than the latest time, complain and set earliest time = midnight
            if (earliestSaleDateFilter.Checked && latestSaleDateFilter.Checked)
            {
                DateTime dateEarliest, dateLatest, dt;
                CultureInfo inv = new CultureInfo("");
                if (!DateTime.TryParseExact(earliestSaleDateFilter.Value.ToString("yyyy-MM-dd") + " 00:00:00", "yyyy-MM-dd HH:mm:ss", inv, DateTimeStyles.None, out dateEarliest))
                {
                    MessageBox.Show("Cannot convert the text in the earliest filter date control into a date - unable to validate",
                        "Formatting problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    earliestSaleDateFilter.Checked = false;
                    return;
                }
                if (!DateTime.TryParseExact(latestSaleDateFilter.Value.ToString("yyyy-MM-dd") + " 00:00:00", "yyyy-MM-dd HH:mm:ss", inv, DateTimeStyles.None, out dateLatest))
                {
                    MessageBox.Show("Cannot convert the text in the earliest filter date control into a date - unable to validate",
                        "Formatting problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    earliestSaleDateFilter.Checked = false;
                    return;
                }
                if (dateEarliest == dateLatest && earliestSaleTimeFilter.Value > latestSaleTimeFilter.Value)
                {
                    MessageBox.Show("The earliest filter time must be earlier than or equal to the latest filter time since the dates are the same - please correct this",
                        "Inconsistent filter values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (DateTime.TryParseExact(latestSaleTimeFilter.Value.ToString("yyyy-MM-dd") + " 00:00:00", "yyyy-MM-dd HH:mm:ss", inv, DateTimeStyles.None, out dt))
                    {
                        earliestSaleTimeFilter.Validating -= earliestSaleTimeFilter_Validating;
                        earliestSaleTimeFilter.Value = dt;
                        earliestSaleTimeFilter.Validating += earliestSaleTimeFilter_Validating;
                    }
                    else // if the datetime for midnight on the current date can't be gotten, clear both the earliest date and time filter values
                    {
                        earliestSaleDateFilter.Checked = false;
                    }
                }
            }
        }

        private void latestSaleDateFilter_ValueChanged(object sender, EventArgs e) // Validating event doesn't fire when checkbox is checked or unchecked
        {
            if (!latestSaleDateFilter.Checked)
            {
                // hide date value since it's not checked
                latestSaleDateFilter.CustomFormat = " ";
                latestSaleDateFilter.Format = DateTimePickerFormat.Custom;
                latestSaleTimeFilter.CustomFormat = " ";
                latestSaleTimeFilter.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                latestSaleDateFilter.CustomFormat = null;
                latestSaleDateFilter.Format = DateTimePickerFormat.Short;
                latestSaleTimeFilter.CustomFormat = null;
                latestSaleTimeFilter.Format = DateTimePickerFormat.Time;
            }
        }

        private void latestSaleDateFilter_Validating(object sender, CancelEventArgs e)
        {
            // If the earliest and latest datetime filters are both active and the latest date filter value is earlier than the earliest data filter value, complain
            if (earliestSaleDateFilter.Checked && latestSaleDateFilter.Checked)
            {
                DateTime dateEarliest, dateLatest, dt;
                CultureInfo inv = new CultureInfo("");
                if (!DateTime.TryParseExact(earliestSaleDateFilter.Value.ToString("yyyy-MM-dd") + " 00:00:00", "yyyy-MM-dd HH:mm:ss", inv, DateTimeStyles.None, out dateEarliest))
                {
                    MessageBox.Show("Cannot convert the text in the earliest filter date control into a date - unable to validate",
                        "Formatting problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    earliestSaleDateFilter.Checked = false;
                    return;
                }
                if (!DateTime.TryParseExact(latestSaleDateFilter.Value.ToString("yyyy-MM-dd") + " 00:00:00", "yyyy-MM-dd HH:mm:ss", inv, DateTimeStyles.None, out dateLatest))
                {
                    MessageBox.Show("Cannot convert the text in the earliest filter date control into a date - unable to validate",
                        "Formatting problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    earliestSaleDateFilter.Checked = false;
                    return;
                }
                if (earliestSaleDateFilter.Checked && latestSaleDateFilter.Checked)
                {
                    if (dateLatest < dateEarliest)
                    {
                        MessageBox.Show("The latest filter date must be later than or equal to the earliest filter date - please correct this",
                            "Inconsistent filter values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // and set the latest date filter value to that of the earliest,
                        if (DateTime.TryParseExact(earliestSaleDateFilter.Value.ToString("yyyy-MM-dd") + " 23:59:59", "yyyy-MM-dd HH:mm:ss", inv, DateTimeStyles.None, out dt))
                        {
                            latestSaleDateFilter.ValueChanged -= latestSaleDateFilter_ValueChanged;
                            latestSaleDateFilter.Validating -= latestSaleDateFilter_Validating;
                            latestSaleDateFilter.Value = dt;
                            latestSaleDateFilter.ValueChanged += latestSaleDateFilter_ValueChanged;
                            latestSaleDateFilter.Validating += latestSaleDateFilter_Validating;

                        }
                        // and the earliest time filter value to a second before the next midnight
                        if (DateTime.TryParseExact(earliestSaleTimeFilter.Value.ToString("yyyy-MM-dd") + " 23:59:59", "yyyy-MM-dd HH:mm:ss", inv, DateTimeStyles.None, out dt))
                        {
                            latestSaleDateFilter.ValueChanged -= latestSaleDateFilter_ValueChanged;
                            latestSaleDateFilter.Validating -= latestSaleDateFilter_Validating;
                            latestSaleTimeFilter.Value = dt;
                            latestSaleDateFilter.ValueChanged += latestSaleDateFilter_ValueChanged;
                            latestSaleDateFilter.Validating += latestSaleDateFilter_Validating;
                        }
                    }
                    // Also do the same check as when the value of the latest time filter is being validated
                    else if (dateEarliest == dateLatest && latestSaleTimeFilter.Value < earliestSaleTimeFilter.Value)
                    {
                        MessageBox.Show("The latest filter time must be later than or equal to the earliest filter time since the dates are the same - please correct this",
                            "Inconsistent filter values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (DateTime.TryParseExact(earliestSaleTimeFilter.Value.ToString("yyyy-MM-dd") + " 00:00:00", "yyyy-MM-dd HH:mm:ss", inv, DateTimeStyles.None, out dt))
                        {
                            earliestSaleTimeFilter.Validating -= earliestSaleTimeFilter_Validating;
                            earliestSaleTimeFilter.Value = dt;
                            earliestSaleTimeFilter.Validating += earliestSaleTimeFilter_Validating;
                        }
                        else // if the datetime for midnight on the current date can't be gotten, clear both the earliest date and time filter values
                        {
                            earliestSaleDateFilter.Checked = false;
                        }
                    }
                }
            }
        }

        private void latestSaleTimeFilter_Validating(object sender, CancelEventArgs e)
        {
            // If both filters are active, the dates are the same, and the earliest time is later than the latest time, complain and set earliest time = 11:59:59 PM
            if (earliestSaleDateFilter.Checked && latestSaleDateFilter.Checked)
            {
                DateTime dateEarliest, dateLatest, dt;
                CultureInfo inv = new CultureInfo("");
                if (!DateTime.TryParseExact(earliestSaleDateFilter.Value.ToString("yyyy-MM-dd") + " 00:00:00", "yyyy-MM-dd HH:mm:ss", inv, DateTimeStyles.None, out dateEarliest))
                {
                    MessageBox.Show("Cannot convert the text in the earliest filter date control into a date - unable to validate",
                        "Formatting problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    earliestSaleDateFilter.Checked = false;
                    return;
                }
                if (!DateTime.TryParseExact(latestSaleDateFilter.Value.ToString("yyyy-MM-dd") + " 00:00:00", "yyyy-MM-dd HH:mm:ss", inv, DateTimeStyles.None, out dateLatest))
                {
                    MessageBox.Show("Cannot convert the text in the earliest filter date control into a date - unable to validate",
                        "Formatting problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    earliestSaleDateFilter.Checked = false;
                    return;
                }
                if (dateEarliest == dateLatest && latestSaleTimeFilter.Value < earliestSaleTimeFilter.Value)
                {
                    MessageBox.Show("The latest filter time must be later than or equal to the earliest filter time since the dates are the same  - please correct this",
                        "Inconsistent filter values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (DateTime.TryParseExact(earliestSaleTimeFilter.Value.ToString("yyyy-MM-dd") + " 23:59:59", "yyyy-MM-dd HH:mm:ss", inv, DateTimeStyles.None, out dt))
                    {
                        latestSaleTimeFilter.Validating -= latestSaleDateFilter_Validating;
                        latestSaleTimeFilter.Value = dt;
                        latestSaleTimeFilter.Validating += latestSaleDateFilter_Validating;
                    }
                    else // if the datetime for 11:59:59 on the current date can't be gotten, clear both the earliest date and time filter values
                    {
                        latestSaleDateFilter.Checked = false;
                    }
                }
            }
        }

        private void minItemsFilter_Validating(object sender, EventArgs e)
        {
            int minItems = 1;
            // If there's a minimum entered
            if (!String.IsNullOrEmpty(minItemsFilter.Text))
            {
                // If the value entered is not an integer > 0
                if (!int.TryParse(minItemsFilter.Text, out minItems) || minItems < 1)
                {
                    MessageBox.Show("The minimum number of items must be an integer greater than 0 - please correct this.", 
                        "Inconsistent filter values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    minItemsFilter.Validating -= minItemsFilter_Validating;
                    minItemsFilter.Text = "";
                    minItemsFilter.Validating += minItemsFilter_Validating;
                }
                // Make sure new Min. No. of Items is greater than or equal to Max. No. of Items value
                else if (!String.IsNullOrEmpty(maxItemsFilter.Text) && minItems > int.Parse(maxItemsFilter.Text))
                {
                    MessageBox.Show("The minimum number of items must be equal to or less than the maximum number - please correct this.",
                        "Inconsistent filter values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    minItemsFilter.Validating -= minItemsFilter_Validating;
                    minItemsFilter.Text = maxItemsFilter.Text;
                    minItemsFilter.Validating += minItemsFilter_Validating;
                }
            }
        }

        private void maxItemsFilter_Validating(object sender, EventArgs e)
        {
            int maxItems = 99999;
            // If there's a maximum entered
            if (!String.IsNullOrEmpty(maxItemsFilter.Text))
            {
                // If the value entered is not an integer > 0
                if (!int.TryParse(maxItemsFilter.Text, out maxItems) || maxItems < 1)
                {
                    MessageBox.Show("The maximum number of items must be an integer greater than 0 - please correct this.", 
                        "Inconsistent filter values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maxItemsFilter.Validating -= maxItemsFilter_Validating;
                    maxItemsFilter.Text = "";
                    maxItemsFilter.Validating += maxItemsFilter_Validating;
                }
                // Make sure new Max. No. of Items is greater than or equal to Min. No. of Items value
                else if (!String.IsNullOrEmpty(minItemsFilter.Text) && maxItems < int.Parse(minItemsFilter.Text))
                {
                    MessageBox.Show("The maximum number of items must be equal to or greater than the minimum number - please correct this.",
                        "Inconsistent filter values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maxItemsFilter.Validating -= maxItemsFilter_Validating;
                    maxItemsFilter.Text = minItemsFilter.Text;
                    maxItemsFilter.Validating += maxItemsFilter_Validating;
                }
            }
        }

        private void minAmountFilter_Validating(object sender, EventArgs e)
        {
            decimal minAmount = 0.01M;
            // If there's a minimum entered
            if (!String.IsNullOrEmpty(minAmountFilter.Text))
            {
                // If the value entered is not a number > 0.01
                if (!decimal.TryParse(minAmountFilter.Text, out minAmount) || minAmount < 0.01M)
                {
                    MessageBox.Show("The minimum total amount must be a number greater than or equal to 0.01 - please correct this",
                        "Inconsistent filter values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    minAmountFilter.Validating -= minAmountFilter_Validating;
                    minAmountFilter.Text = "";
                    minAmountFilter.Validating += minAmountFilter_Validating;
                }
                // Make sure new Min. Total Amount is less than or equal to Max. Total Amount value
                else if (!String.IsNullOrEmpty(maxAmountFilter.Text) && decimal.Parse(maxAmountFilter.Text) < minAmount)
                {
                    MessageBox.Show("The minimum total amount must be equal to or less than the maximum total amount - please correct this.",
                        "Inconsistent filter values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    minAmountFilter.Validating -= minAmountFilter_Validating;
                    minAmountFilter.Text = maxAmountFilter.Text;
                    minAmountFilter.Validating += minAmountFilter_Validating;
                }
            }
        }

        private void maxAmountFilter_Validating(object sender, EventArgs e)
        {
            decimal maxAmount = 99999M;
            // If there's a maximum entered
            if (!String.IsNullOrEmpty(maxAmountFilter.Text))
            {
                // If the value entered is not a number > 0.01
                if (!decimal.TryParse(maxAmountFilter.Text, out maxAmount) || maxAmount < 0.01M)
                {
                    MessageBox.Show("The maximum total amount must be a number greater than or equal to 0.01 - please correct this", 
                        "Inconsistent filter values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maxAmountFilter.Validating -= maxAmountFilter_Validating;
                    maxAmountFilter.Text = "";
                    maxAmountFilter.Validating += maxAmountFilter_Validating;
                }
                // Make sure Min. Total Amount is less than or equal to new Max. Total Amount value
                else if (!String.IsNullOrEmpty(minAmountFilter.Text) && decimal.Parse(minAmountFilter.Text) > maxAmount)
                {
                    MessageBox.Show("The maximum total amount must be equal to or greater than the minimum total amount - please correct this.",
                        "Inconsistent filter values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maxAmountFilter.Validating -= maxAmountFilter_Validating;
                    maxAmountFilter.Text = minAmountFilter.Text;
                    maxAmountFilter.Validating += maxAmountFilter_Validating;
                }
            }
        }

        private void saleIDFilter_Validating(object sender, CancelEventArgs e)
        {
            int saleID = 1;
            // If there's a sale ID entered
            if (!String.IsNullOrEmpty(saleIDFilter.Text))
            {
                // If the value entered is not an integer > 0
                if (!int.TryParse(saleIDFilter.Text, out saleID) || saleID < 1)
                {
                    MessageBox.Show("The sale ID must be an integer greater than 0 - please correct this.", 
                        "Inconsistent filter values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    saleIDFilter.Validating -= saleIDFilter_Validating;
                    saleIDFilter.Text = "";
                    saleIDFilter.Validating += saleIDFilter_Validating;
                }
            }
        }

        private void findSalesButton_Click(object sender, EventArgs e)
        {
            DateTime dt;
            CultureInfo inv = new CultureInfo("");
            // Ask for confirmation if there are any modified (thus unsaved) rows or rows to be deleted
            foreach (DataGridViewRow row in changeSaleItemGridView.Rows)
            {
                if (row.DefaultCellStyle.BackColor == Color.LightYellow || row.DefaultCellStyle.BackColor == Color.Pink)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to retrieve the sales from the database and lose the unsaved changes?",
                        "Warning - changes will be lost!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result.Equals(DialogResult.Cancel)) return;
                    break;
                }
            }
            // Disable the Delete Selected Sale and Delete Selected Item buttons in case no sales match the specified filters
            deleteSaleButton.Enabled = false;
            deleteItemButton.Enabled = false;
            // Also hide the changeSaleItemGrid so new items can't be added to a non-existent sale
            changeSaleItemGridView.Visible = false;
            // Load the grid of sales by calling select_sales SP with parameters from filter date pickers and/or textboxes
            SqlCommand cmd = new SqlCommand("select_sales", DataManager.dbc);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            // If a date picker is checked, assemble its datetime from the date portion of the date picker and time portion of the time picker
            if (earliestSaleDateFilter.Checked)
            {
                if (DateTime.TryParseExact(earliestSaleDateFilter.Value.ToString("yyyy-MM-dd") + " " + earliestSaleTimeFilter.Value.ToString("HH:mm:ss"), "yyyy-MM-dd HH:mm:ss",
                    inv, DateTimeStyles.None, out dt))
                {
                    cmd.Parameters.Add("@when_sold_min", SqlDbType.DateTime).Value = dt;
                }
                else
                {
                    MessageBox.Show("Cannot convert the text in the earliest filter date and time controls into a datetime - unable to use to limit displayed sales",
                        "Formatting problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmd.Parameters.Add("@when_sold_min", SqlDbType.DateTime).Value = DBNull.Value;
                }
            }
            else cmd.Parameters.Add("@when_sold_min", SqlDbType.DateTime).Value = DBNull.Value;
            if (latestSaleDateFilter.Checked)
            {
                if (DateTime.TryParseExact(latestSaleDateFilter.Value.ToString("yyyy-MM-dd") + " " + latestSaleTimeFilter.Value.ToString("HH:mm:ss"), "yyyy-MM-dd HH:mm:ss",
                    inv, DateTimeStyles.None, out dt))
                {
                    cmd.Parameters.Add("@when_sold_max", SqlDbType.DateTime).Value = dt;
                }
                else
                {
                    MessageBox.Show("Cannot convert the text in the latest filter date and time controls into a datetime - unable to use to limit displayed sales",
                        "Formatting problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmd.Parameters.Add("@when_sold_max", SqlDbType.DateTime).Value = DBNull.Value;
                }
            }
            else cmd.Parameters.Add("@when_sold_max", SqlDbType.DateTime).Value = DBNull.Value;
            // Add parameters from the other filters only if non-null/empty)
            // No. of Items Min.
            if (!String.IsNullOrEmpty(minItemsFilter.Text))
                cmd.Parameters.Add("@no_items_min", SqlDbType.Int).Value = int.Parse(minItemsFilter.Text);
            else
                cmd.Parameters.Add("@no_items_min", SqlDbType.Int).Value = DBNull.Value;
            // No. of Items Max.
            if (!String.IsNullOrEmpty(maxItemsFilter.Text))
                cmd.Parameters.Add("@no_items_max", SqlDbType.Int).Value = int.Parse(maxItemsFilter.Text);
            else
                cmd.Parameters.Add("@no_items_max", SqlDbType.Int).Value = DBNull.Value;
            // Total Amount Min.
            if (!String.IsNullOrEmpty(minAmountFilter.Text))
                cmd.Parameters.Add("@sale_amount_min", SqlDbType.Decimal).Value = decimal.Parse(minAmountFilter.Text);
            else
                cmd.Parameters.Add("@sale_amount_min", SqlDbType.Decimal).Value = DBNull.Value;
            // Total Amount Max
            if (!String.IsNullOrEmpty(maxAmountFilter.Text))
                cmd.Parameters.Add("@sale_amount_max", SqlDbType.Decimal).Value = decimal.Parse(maxAmountFilter.Text);
            else
                cmd.Parameters.Add("@sale_amount_max", SqlDbType.Decimal).Value = DBNull.Value;
            // Sale ID
            if (!String.IsNullOrEmpty(saleIDFilter.Text))
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(saleIDFilter.Text);
            else
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = DBNull.Value;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
            {
                DataTable dat = new DataTable();
                adap.Fill(dat);
                changeSaleGridView.DataSource = dat;
            }
            changeSaleGridView.CellValueChanged -= changeSaleGridView_CellValueChanged;
            foreach (DataGridViewRow row in changeSaleGridView.Rows)
            {
                //  Save the original values for the 2 user-editable fields so changes can be detected
                row.Cells["original_when_sold"].Value = row.Cells["when_sold"].Value.ToString();
                row.Cells["original_tendered"].Value = row.Cells["tendered"].Value.ToString();
                // Also save original_sale_amount so changes in the change given can be detected
                // This isn't directly editable but the user can change it by altering the items in the sale
                row.Cells["original_sale_amount"].Value = row.Cells["sale_amount"].Value.ToString();
                // Also save a copy of items so changes to the items grid can be detected as the selected row in sales changes
                row.Cells["original_items"].Value = row.Cells["items"].Value.ToString();
                row.DefaultCellStyle.BackColor = Color.White; // Reset background color of each row
            }
            changeSaleGridView.CellValueChanged += changeSaleGridView_CellValueChanged;

            // Select the first row if there is one
            if (changeSaleGridView.RowCount > 0)
            {
                changeSaleGridView.Rows[0].Selected = true; // Make sure this triggers the row selection event to fill the changeSaleItemGridView
                changeSaleGridView.CurrentCell = changeSaleGridView.Rows[0].Cells[0];
                deleteSaleButton.Text = "Delete Selected Sale";
                deleteItemButton.Enabled = true;
                printButton.Enabled = true;
            }
            else
            {
                printButton.Enabled = false;
            }
        }

        private void deleteSaleButton_Click(object sender, EventArgs e)
        {
            if (deleteSaleButton.Text == "Delete Selected Sale")
            {
                changeSaleGridView.CurrentRow.DefaultCellStyle.BackColor = Color.Pink;
                deleteSaleButton.Text = "Undelete Selected Sale";
                saveSalesButton.Enabled = true;
            }
            else
            {
                changeSaleGridView.CurrentRow.DefaultCellStyle.BackColor = Color.White; // It may be that it should actually be Light Yellow, but UpdateSaleValuesColorAndSaveSalesState will fix that; it just can't be Pink for that method to work
                deleteSaleButton.Text = "Delete Selected Sale";
                UpdateSaleValuesColorAndSaveSalesState(changeSaleGridView.CurrentRow.Index);
            }
        }

        private void saveSalesButton_Click(object sender, EventArgs e)
        {
            int retVal = 0;
            SqlCommand delCmd = new SqlCommand("delete_sale", DataManager.dbc);
            delCmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand chgSaleCmd = new SqlCommand("change_sale", DataManager.dbc);
            chgSaleCmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlCommand chgSaleItemCmd = new SqlCommand("change_sale_items", DataManager.dbc);
            chgSaleItemCmd.CommandType = System.Data.CommandType.StoredProcedure;
            changeSaleGridView.RowEnter -= changeSaleGridView_RowEnter;
            changeSaleGridView.CellValueChanged -= changeSaleGridView_CellValueChanged;
            for (int i = changeSaleGridView.RowCount - 1; i >= 0; i--) // Work from the bottom up so deleting a row doesn't cause the row following it to be skipped
            {
                DataGridViewRow row = changeSaleGridView.Rows[i];
                if (row.DefaultCellStyle.BackColor == Color.Pink)
                { // "Delete" the sale (i.e.mark it as superseded but with no superseding_id) by calling the delete_sale SP
                    delCmd.Parameters.Clear();
                    // Add parameter from sale grid
                    delCmd.Parameters.Add("@id", SqlDbType.Int).Value = Int32.Parse(row.Cells["sale_id"].Value.ToString());
                    try
                    {
                        retVal = (Int32)delCmd.ExecuteScalar();
                        if (retVal != 0)
                        {
                            MessageBox.Show("Call to delete_sale stored procedure failed, returning error code " + retVal.ToString(),
                                "SQL Server error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,"SQL Server error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    // Since control made it to this point, delete_sale succeeded, so delete this sale from the grid
                    changeSaleGridView.Rows.Remove(row);
                }
                else if (row.DefaultCellStyle.BackColor == Color.LightYellow)
                { // "Change" the sale
                    // If only the items in the sale changed (unlikely, but could happen if the total sale amount ended up being the same) just call change_sale_items, which doesn't create a new sale
                    // V. 0.4 - added last 2 lines to the following "if" condition to check for changes in tendered - sale_amount, which is the value for the change field in the sale table
                    // Also added the conversion to datetime of decimal values for comparisons, since direct comparisons of values always failed to be equal
                    if (DateTime.Parse(row.Cells["when_sold"].Value.ToString()) == DateTime.Parse(row.Cells["original_when_sold"].Value.ToString()) &&
                        Decimal.Parse(row.Cells["tendered"].Value.ToString()) == Decimal.Parse(row.Cells["original_tendered"].Value.ToString()) &&
                        (Decimal.Parse(row.Cells["tendered"].Value.ToString()) - Decimal.Parse(row.Cells["sale_amount"].Value.ToString())) ==
                        (Decimal.Parse(row.Cells["original_tendered"].Value.ToString()) - Decimal.Parse(row.Cells["original_sale_amount"].Value.ToString())))
                    {
                        chgSaleItemCmd.Parameters.Clear();
                        // Add parameter from sale grid
                        chgSaleItemCmd.Parameters.Add("@id", SqlDbType.Int).Value = Int32.Parse(row.Cells["sale_id"].Value.ToString());
                        chgSaleItemCmd.Parameters.Add("@sale_items", SqlDbType.NVarChar).Value = row.Cells["items"].Value.ToString();
                        try
                        {
                            retVal = (Int32)chgSaleItemCmd.ExecuteScalar();
                            if (retVal != 0 && retVal != 1)
                            {
                                MessageBox.Show("Call to change_sale_items stored procedure failed, returning error code " + retVal.ToString(),
                                    "SQL Server error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else if (retVal == 1)
                            {
                                MessageBox.Show("The items string for sale ID " + row.Cells["sale_id"].Value.ToString() + " is malformed and superseding items could not be created from it.",
                                    "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "SQL Server error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                     }
                    else
                    {
                        // Otherwise call change_sale, which creates a new sale with the modified information, and supersedes the old sale with it
                        chgSaleCmd.Parameters.Clear();
                        // Add parameter from sale grid
                        chgSaleCmd.Parameters.Add("@id", SqlDbType.Int).Value = Int32.Parse(row.Cells["sale_id"].Value.ToString());
                        chgSaleCmd.Parameters.Add("@when_sold", SqlDbType.DateTime).Value = DateTime.Parse(row.Cells["when_sold"].Value.ToString());
                        chgSaleCmd.Parameters.Add("@tendered", SqlDbType.Decimal).Value = Decimal.Parse(row.Cells["tendered"].Value.ToString());
                        chgSaleCmd.Parameters.Add("@change", SqlDbType.Decimal).Value = Decimal.Parse(row.Cells["tendered"].Value.ToString()) - Decimal.Parse(row.Cells["sale_amount"].Value.ToString());
                        chgSaleCmd.Parameters.Add("@sale_items", SqlDbType.NVarChar).Value = row.Cells["items"].Value.ToString();
                        SqlParameter outputIdParam = new SqlParameter("@new_id", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        chgSaleCmd.Parameters.Add(outputIdParam);
                        try
                        {
                            retVal = (Int32)chgSaleCmd.ExecuteScalar();
                            if (retVal != 0 && retVal != 5 && retVal != 6)
                            {
                                MessageBox.Show("Call to change_sale stored procedure failed for sale ID " + row.Cells["sale_id"].Value.ToString() + ", returning error code " + retVal.ToString(),
                                    "SQL Server error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else if (retVal == 5)
                            {
                                MessageBox.Show("No items were added to the new sale that superseded sale ID " + row.Cells["sale_id"].Value.ToString() + " - correct this outside of this program",
                                    "Database error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            else if (retVal == 6)
                            {
                                MessageBox.Show("The items string for sale ID " + row.Cells["sale_id"].Value.ToString() + " is malformed and items for the superseding sale could not be created from it.",
                                    "Program error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "SQL Server error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        int newID = outputIdParam.Value as int? ?? 0; // Shouldn't be possible for this to come back null but handle it just in case
                        if (newID == 0)
                        {
                            MessageBox.Show("Sale ID " + row.Cells["sale_id"].Value.ToString() + " was not successfully changed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        // Since in order to have gotten here the call to change_sale was successful, update sale_id, original_when_sold, and original_tendered to their new values
                        row.Cells["sale_id"].Value = newID; 
                        row.Cells["original_when_sold"].Value = row.Cells["when_sold"].Value;
                        row.Cells["original_tendered"].Value = row.Cells["tendered"].Value;
                    }
                    // In either case, if there were any changes to items,
                    if (row.Cells["items"].Value != row.Cells["original_items"].Value)
                    {
                        // the items column in the current sales row needs to be updated by getting rid of trios preceded with a D:, and removing the I:or C: from the rest
                        string originalItemContents = row.Cells["items"].Value.ToString();
                        char[] newItemContents = new char[1000];
                        int nextDColon, nextIColon, nextCColon;
                        int sourceStartingPoint = 0, destStartingPoint = 0, nextComma, nextIorC;
                        do
                        {
                            nextDColon = originalItemContents.IndexOf("D:", sourceStartingPoint);
                            if (nextDColon == -1) nextDColon = originalItemContents.Length;
                            nextIColon = originalItemContents.IndexOf("I:", sourceStartingPoint);
                            if (nextIColon == -1) nextIColon = originalItemContents.Length;
                            nextCColon = originalItemContents.IndexOf("C:", sourceStartingPoint);
                            if (nextCColon == -1) nextCColon = originalItemContents.Length;
                            // If D is the next letter encountered 
                            if (nextDColon < nextIColon && nextDColon < nextCColon)
                            {
                                // Copy everything from starting point up to and including the comma preceding D from originalItemContents to newItemContents
                                originalItemContents.CopyTo(sourceStartingPoint, newItemContents, destStartingPoint, nextDColon - sourceStartingPoint);
                                // Update the destination's starting point by the number of characters copied (could be 0)
                                destStartingPoint += nextDColon - sourceStartingPoint;
                                // Move the source starting point past the trio that was deleted
                                nextComma = originalItemContents.IndexOf(',', nextDColon); // This is the comma after the item
                                nextComma = originalItemContents.IndexOf(',', nextComma + 1); // This is the comma after the quantity
                                nextComma = originalItemContents.IndexOf(',', nextComma + 1); // This is the comma after the amount, if it exists
                                if (nextComma == -1) // There are no more trios after the one being deleted so copying is finished
                                {
                                    // Remove the last comma from newItemContents
                                    newItemContents[destStartingPoint - 1] = '\0';
                                    break;
                                }
                                else sourceStartingPoint = nextComma + 1;
                            }
                            else //Either a C or an I is the next letter (if there is either), and they are handled the same
                            {
                                nextIorC = Math.Min(nextIColon, nextCColon);
                                if (nextIorC == originalItemContents.Length)
                                {
                                    // Copy everything up to the end of the string
                                    originalItemContents.CopyTo(sourceStartingPoint, newItemContents, destStartingPoint, nextIorC - sourceStartingPoint);
                                    break;
                                }
                                // Copy everything from starting point up to and including the comma preceding I or C from originalItemContents to newItemContents
                                originalItemContents.CopyTo(sourceStartingPoint, newItemContents, destStartingPoint, nextIorC - sourceStartingPoint);
                                // Update the destination's starting point bythe number of characters copied (could be 0)
                                destStartingPoint += nextIorC - sourceStartingPoint;
                                // Move the source starting point past the I: or C:, which is 2 more than the number of characters copied
                                sourceStartingPoint += nextIorC - sourceStartingPoint + 2;
                            }
                        } while (true);
                        // Then set both the items column and the original_items column value equal to the modified items content,
                        // in case further changes are made without Find Sales being clicked
                        string buffer = new string(newItemContents);
                        row.Cells["original_items"].Value = row.Cells["items"].Value = buffer;
                    }
                    // Finally change the yellow background back to white
                    row.DefaultCellStyle.BackColor = Color.White;
                } 
            }
            changeSaleGridView.CellValueChanged += changeSaleGridView_CellValueChanged;
            changeSaleGridView.RowEnter += changeSaleGridView_RowEnter;
            // If there are any sale rows left select the first one
            if (changeSaleGridView.RowCount > 0)
            {
                changeSaleGridView.Rows[0].Selected = true;
                DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(0,0);
                changeSaleGridView_RowEnter((object)changeSaleGridView.Rows[0], ev); // So the changeSaleItemGridView refreshes
                deleteItemButton.Text = "Delete Selected Item"; // Since there's always at least one item in a sale, and it'll be selected, enable Delete Selected Item
                deleteItemButton.Enabled = true;
            }
            // If not, clear all rows from the sale items grid and disable all buttons except Find Sales
            else
            {
                changeSaleItemGridView.Rows.Clear();
                deleteSaleButton.Enabled = false;
                saveSalesButton.Enabled = false;
                deleteItemButton.Enabled = false;
            }
        }

        private void changeSaleGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Load the changeSaleItemGridView with the items for the selected row's sale, color-coding if needed
            if (changeSaleGridView.Rows[e.RowIndex].Cells["items"].Value != null &&
                ((string)changeSaleGridView.Rows[e.RowIndex].Cells["items"].Value).Length != 0)
            {
                string itemIDString, quantityString, colorString, colorItemString, amountString, itemContents, origItemContents, origItemIDString, origQuantityString;
                decimal amount;
                int startingPoint = 0, rowNo = 0, itemID, quantity;
                itemContents = changeSaleGridView.Rows[e.RowIndex].Cells["items"].Value.ToString();
                int length = itemContents.Length;
                int nextComma = itemContents.IndexOf(',', startingPoint);
                if (nextComma > 0)
                {
                    // Disable event handling till programmatic changes are done
                    changeSaleItemGridView.RowEnter -= changeSaleItemGridView_RowEnter;
                    changeSaleItemGridView.CellValueChanged -= changeSaleItemGridView_CellValueChanged;
                    changeSaleItemGridView.Rows.Clear();
                    do
                    {
                        // See if an item's ID is prefixed by "I" (Inserted), "C:" (changed) or "D:" (deleted)
                        colorItemString = itemContents.Substring(startingPoint, nextComma - startingPoint);
                        if (colorItemString.IndexOf(':') != -1) // If colorItemString has a colon then the prefix is there
                        {
                            colorString = colorItemString.Substring(0, 1); // colorString will be just "I", "C" or "D"
                            itemIDString = colorItemString.Substring(2, colorItemString.Length - 2);
                        }
                        else
                        {
                            colorString = ""; // So value isn't retained fromthe previous item
                            itemIDString = colorItemString;
                        }
                        startingPoint = nextComma + 1;
                        nextComma = itemContents.IndexOf(',', startingPoint);
                        quantityString = itemContents.Substring(startingPoint, nextComma - startingPoint);
                        startingPoint = nextComma + 1;
                        nextComma = itemContents.IndexOf(',', startingPoint);
                        amountString = itemContents.Substring(startingPoint, (nextComma == -1 ? length : nextComma) - startingPoint);
                        if (nextComma != -1)
                        {
                            startingPoint = nextComma + 1;
                            nextComma = itemContents.IndexOf(',', startingPoint);
                        }
                        if (!int.TryParse(itemIDString, out itemID) ||
                            !int.TryParse(quantityString, out quantity) ||
                            !decimal.TryParse(amountString, out amount))
                        {
                            MessageBox.Show("Error in the way item information was saved in row " + (rowNo + 1).ToString() + "Please re-enter");
                            break;
                        }
                        rowNo = changeSaleItemGridView.Rows.Add();
                        DataGridViewRow row = changeSaleItemGridView.Rows[rowNo];
                        // Add the data
                        row.Cells["item_id"].Value = itemIDString;
                        row.Cells["short_description"].Value = GetShortDescFromId(itemID);
                        row.Cells["quantity"].Value = quantityString;
                        row.Cells["price"].Value = (amount / quantity).ToString("0.00");
                        row.Cells["amount"].Value = amount.ToString("0.00");
                        if (colorString == "I")
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                        else if (colorString == "C")
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                        else if (colorString == "D")
                            row.DefaultCellStyle.BackColor = Color.Pink;
                        else row.DefaultCellStyle.BackColor = Color.White;
                    } while (nextComma > 0);

                    // May need to add a "new" row, setting its background to white
                    // changeSaleItemGridView.Rows[row].DefaultCellStyle.BackColor = Color.White;

                    // Now load the 2 hidden original_* fields from the sale's original_items field - these will have no "letter colon" prefix
                    // Note that row 0 of the items grid is entered as soon as the data source is set for changeSaleGridView in findSalesButtton_Click,
                    // and at that point the code to initialize the original_items field hasn't been gotten to, so for the first row, it's necessary 
                    // to initialize original_items here if it's null, so the the original_item_id and original_quantity of the first sale's items are set.
                    if (changeSaleGridView.Rows[e.RowIndex].Cells["original_items"].Value == null)
                    {
                        changeSaleGridView.CellValueChanged -= changeSaleGridView_CellValueChanged;
                        changeSaleGridView.Rows[e.RowIndex].Cells["original_items"].Value = changeSaleGridView.Rows[e.RowIndex].Cells["items"].Value.ToString();
                        changeSaleGridView.CellValueChanged += changeSaleGridView_CellValueChanged;
                    }
                    startingPoint = 0;
                    rowNo = 0;
                    origItemContents = changeSaleGridView.Rows[e.RowIndex].Cells["original_items"].Value.ToString();
                    length = origItemContents.Length;
                    nextComma = origItemContents.IndexOf(',', startingPoint); // Since there's a comma in itemContents there must also be one in origItemContents
                    do
                    {
                        origItemIDString = origItemContents.Substring(startingPoint, nextComma - startingPoint);
                        startingPoint = nextComma + 1;
                        nextComma = origItemContents.IndexOf(',', startingPoint);
                        origQuantityString = origItemContents.Substring(startingPoint, nextComma - startingPoint);
                        startingPoint = nextComma + 1;
                        nextComma = origItemContents.IndexOf(',', startingPoint);
                        // Skip over the amount value as there's no hidden field for it
                        if (nextComma != -1)
                        {
                            startingPoint = nextComma + 1;
                            nextComma = origItemContents.IndexOf(',', startingPoint);
                        }
                        changeSaleItemGridView.Rows[rowNo].Cells["original_item_id"].Value = origItemIDString;
                        changeSaleItemGridView.Rows[rowNo].Cells["original_quantity"].Value = origQuantityString;
                        rowNo++;
                    } while (nextComma > 0);
                    if (changeSaleGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Pink) deleteSaleButton.Text = "Undelete Selected Sale";
                    else deleteSaleButton.Text = "Delete Selected Sale";
                    deleteSaleButton.Enabled = true;
                    changeSaleItemGridView.Visible = true;
                    changeSaleItemGridView.Rows[0].Selected = true; // Every sale has at least 1 item so Rows[0] exists
                    // While there's no change in the values or color of a sale row due to switching rows, the Save button may need to be enabled or disabled
                    if (changeSaleGridView.CurrentRow != null) UpdateSaleValuesColorAndSaveSalesState(e.RowIndex); //When first initializing there's no current row and no need to call this
                    // Re-enable event handling once programmatic changes are done
                    changeSaleItemGridView.RowEnter += changeSaleItemGridView_RowEnter;
                    changeSaleItemGridView.CellValueChanged += changeSaleItemGridView_CellValueChanged;
                }
            }
        }

        private void changeSaleItemGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // If there's an item defined for the row, enable the Delete Item button; if not (i.e. it's a new row that was just added), disable it
            if (changeSaleItemGridView.Rows[e.RowIndex].Cells["item_id"].Value != null &&
                ((string)changeSaleItemGridView.Rows[e.RowIndex].Cells["item_id"].Value).Length != 0)
            {
                if (changeSaleItemGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Pink)
                {
                    deleteItemButton.Text = "Undelete Selected Item";
                    //deleteItemButton.Font.Size = new Size.Size()
                }
                else deleteItemButton.Text = "Delete Selected Item";
                deleteItemButton.Enabled = true;
            }
            else // This is the "new" row 
            {
                deleteItemButton.Enabled = false; // Right now there's no item to delete
                changeSaleItemGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                changeSaleItemGridView.CellValueChanged -= changeSaleItemGridView_CellValueChanged;
                changeSaleItemGridView.Rows[e.RowIndex].Cells["original_item_id"].Value = "";
                changeSaleItemGridView.Rows[e.RowIndex].Cells["original_quantity"].Value = "0";
                changeSaleItemGridView.CellValueChanged += changeSaleItemGridView_CellValueChanged;
            }
         }

        private void changeSaleItemGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int itemID, quantity;
            string cellContent, shortDescription;
            if (e.RowIndex < 0) return; // CellValueChanged events with RowIndex = -1 are generated during initialization
            changeSaleItemGridView.CellValueChanged -= changeSaleItemGridView_CellValueChanged;
            // Refuse a change to the ID of an item already in a sale
            bool noItemID = changeSaleItemGridView.Rows[e.RowIndex].Cells["item_id"].Value == null || changeSaleItemGridView.Rows[e.RowIndex].Cells["item_id"].Value.ToString() == "";
            // If the cell being changed is the item ID, it's not a new row, and the item ID has been erased or doesn't match its original value, complain and restore it
            if (e.ColumnIndex == 0 && changeSaleItemGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.LightGreen && (noItemID ||
                changeSaleItemGridView.Rows[e.RowIndex].Cells["item_id"].Value.ToString() != changeSaleItemGridView.Rows[e.RowIndex].Cells["original_item_id"].Value.ToString()))
            {
                MessageBox.Show("Changing the ID of an item already in a sale is not allowed - the existing item must be deleted and a new one added.", "Change disallowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                changeSaleItemGridView.Rows[e.RowIndex].Cells["item_id"].Value = changeSaleItemGridView.Rows[e.RowIndex].Cells["original_item_id"].Value.ToString();
                changeSaleItemGridView.CellValueChanged += changeSaleItemGridView_CellValueChanged;
                return;
            }
            if (changeSaleItemGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null &&
                (cellContent = changeSaleItemGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) != "")
            {
                switch (e.ColumnIndex)
                {
                    case 0: // Item ID - this would be for an item being added to a sale
                        if (Int32.TryParse(cellContent, out itemID) && itemID > 0)
                        {
                            if ((shortDescription = GetShortDescFromId(itemID)) == "")
                            {
                                MessageBox.Show(cellContent + " is not a valid item ID - please correct this",
                                    "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                changeSaleItemGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                                changeSaleItemGridView.Rows[e.RowIndex].Cells["short_description"].Value = "";
                            }
                            else
                            {
                                changeSaleItemGridView.Rows[e.RowIndex].Cells["short_description"].Value = shortDescription;
                                deleteItemButton.Enabled = true;
                                // If there's a quantity already present fill in Unit Price and Ext. Price columns
                                if (changeSaleItemGridView.Rows[e.RowIndex].Cells["quantity"].Value != null &&
                                    changeSaleItemGridView.Rows[e.RowIndex].Cells["quantity"].Value.ToString() != "")
                                {
                                    FillInPricesFromIdAndQuantity(itemID,
                                        int.Parse(changeSaleItemGridView.Rows[e.RowIndex].Cells["quantity"].Value.ToString()), 
                                        int.Parse(changeSaleItemGridView.Rows[e.RowIndex].Cells["original_quantity"].Value.ToString()), e.RowIndex);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(cellContent + " is not an integer greater than 0 and so cannot be a valid item ID - please correct this",
                                "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            changeSaleItemGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                            changeSaleItemGridView.Rows[e.RowIndex].Cells["short_description"].Value = "";
                        }
                        break;
                    case 2:  // Quantity
                        if (!Int32.TryParse(cellContent, out quantity) || quantity < 1)
                        {
                            MessageBox.Show(cellContent + " is not an integer greater than 0 and so cannot be a valid quantity - please correct this",
                                "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            changeSaleItemGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                            changeSaleItemGridView.Rows[e.RowIndex].Cells["price"].Value = "";
                            changeSaleItemGridView.Rows[e.RowIndex].Cells["amount"].Value = "";
                        }
                        // If there's a short description, the item_id is legit, so fill in Unit Price and Ext. Price columns
                        else if (changeSaleItemGridView.Rows[e.RowIndex].Cells["short_description"].Value != null &&
                            changeSaleItemGridView.Rows[e.RowIndex].Cells["short_description"].Value.ToString() != "")
                        {
                            FillInPricesFromIdAndQuantity(int.Parse(changeSaleItemGridView.Rows[e.RowIndex].Cells["item_id"].Value.ToString()),
                                quantity, int.Parse(changeSaleItemGridView.Rows[e.RowIndex].Cells["original_quantity"].Value.ToString()), e.RowIndex);
                        }
                        break;
                }
            }
            else if (e.ColumnIndex == 0) // The item ID became null or blank
            {
                changeSaleItemGridView.Rows[e.RowIndex].Cells["short_description"].Value = "";
                changeSaleItemGridView.Rows[e.RowIndex].Cells["price"].Value = "";
                changeSaleItemGridView.Rows[e.RowIndex].Cells["amount"].Value = "";
                deleteItemButton.Enabled = false;
            }
            else // e.ColumnIndex must be 2, as that's the only other editable column, so the quantity became null or blank
            {
                changeSaleItemGridView.Rows[e.RowIndex].Cells["price"].Value = "";
                changeSaleItemGridView.Rows[e.RowIndex].Cells["amount"].Value = "";
            }
            if (changeSaleGridView.CurrentRow.DefaultCellStyle.BackColor == Color.Pink)
                MessageBox.Show("Note that changes to an item in a sale that is to be deleted are meaningless");
            else if (changeSaleItemGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Pink)
                MessageBox.Show("Note that changes to an item that is to be deleted from a sale are meaningless");
            // Unless this is a new item or an item to be deleted, mark it as being changed, unless the only editable field (quantity) was changed back to its original value
            if (changeSaleItemGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.LightGreen &&
                changeSaleItemGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.Pink)
            {
                if (changeSaleItemGridView.Rows[e.RowIndex].Cells["quantity"].Value == null ||
                    changeSaleItemGridView.Rows[e.RowIndex].Cells["quantity"].Value.ToString() != changeSaleItemGridView.Rows[e.RowIndex].Cells["original_quantity"].Value.ToString())
                {
                    changeSaleItemGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                }
                else
                {
                    changeSaleItemGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
            // Load the information from the changeSaleItemGridView into the items column of the changeSaleGridView
            /* Moved to BuildItemsContents in V. 0.4
            string itemsContents = "";
            bool firstLegitRow = true, itemGridComplete = true;
            foreach (DataGridViewRow row in changeSaleItemGridView.Rows)
            {
                // If amount is present then item_id and quantity are also present
                if (row.Cells["amount"].Value != null && row.Cells["amount"].Value.ToString() != "")
                {
                    if (!firstLegitRow) itemsContents += ",";
                    firstLegitRow = false;
                    if (row.DefaultCellStyle.BackColor == Color.Pink)
                    {
                        itemsContents += "D:";
                    }
                    else if (row.DefaultCellStyle.BackColor == Color.LightYellow)
                    {
                        itemsContents += "C:";
                    }
                    else if (row.DefaultCellStyle.BackColor == Color.LightGreen)
                    {
                        itemsContents += "I:";
                    }
                    itemsContents += row.Cells["item_id"].Value.ToString() + "," + row.Cells["quantity"].Value.ToString() + "," + row.Cells["amount"].Value.ToString();
                }
                // If it's not a new row, i.e. has an original item, or it's a new row with either but not both an item and a quantity
                else if ((row.Cells["original_item_id"].Value != null && row.Cells["original_item_id"].Value.ToString() != "") || // New row
                    (row.Cells["item_id"].Value != null && row.Cells["item_id"].Value.ToString() != "" && (row.Cells["quantity"].Value == null || row.Cells["quantity"].Value.ToString() == "")) || // Has item_id, no quantity
                    ((row.Cells["item_id"].Value == null || row.Cells["item_id"].Value.ToString() != "") && row.Cells["quantity"].Value != null && row.Cells["quantity"].Value.ToString() != "")) // Has quantity, no item_id
                {
                    itemGridComplete = false;
                    MessageBox.Show("Row " + (row.Index + 1).ToString() + 
                        " in the items grid is missing information.  If the different row in the sales grid is selected all changes made since the current row was selected will be lost.",
                        "Incomplete entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            */
            string itemsContents = BuildItemsContents(); // Added for V. 0.4 to fix bug where items column in grid was not being updated when an item was deleted, given no other changes
            if (itemsContents.Length > 0) // Was "if (itemGridComplete)" - changed in V. 0.4
            {
                changeSaleGridView.CellValueChanged -= changeSaleGridView_CellValueChanged;
                changeSaleGridView.CurrentRow.Cells["items"].Value = itemsContents;
                changeSaleGridView.CellValueChanged += changeSaleGridView_CellValueChanged;
            }
            UpdateSaleValuesColorAndSaveSalesState(changeSaleGridView.CurrentRow.Index);
            changeSaleItemGridView.CellValueChanged += changeSaleItemGridView_CellValueChanged;
        }

        private void deleteItemButton_Click(object sender, EventArgs e)
        {
            // If the item being deleted wasn't already in the sale but is being added (i.e. its row is green) delete it immediately
            // Note that it is imposible to Un-delete a new row since deleting it would have removed it immediately
            if (changeSaleItemGridView.CurrentRow.DefaultCellStyle.BackColor == Color.LightGreen)
            {
                changeSaleItemGridView.Rows.Remove(changeSaleItemGridView.CurrentRow);
            }
            // Otherwise just mark it as to be deleted (i.e. make its row pink), or unmark it, depending on whether was already marked (as indicated by the button's label)
            else
            {
                if (deleteItemButton.Text == "Delete Selected Item")
                {
                    changeSaleItemGridView.CurrentRow.DefaultCellStyle.BackColor = Color.Pink;
                    deleteItemButton.Text = "Undelete Selected Item";
                }
                else // Label must be Undelete ...
                { // Since new rows are deleted immediately, the only thing to check about an undeleted row is whether the quantity differs from the original; if so then this row is changed
                    if (changeSaleItemGridView.CurrentRow.Cells["quantity"].Value == null ||
                        (changeSaleItemGridView.CurrentRow.Cells["quantity"].Value.ToString() != changeSaleItemGridView.CurrentRow.Cells["original_quantity"].Value.ToString()))
                        changeSaleItemGridView.CurrentRow.DefaultCellStyle.BackColor = Color.LightYellow;
                    else changeSaleItemGridView.CurrentRow.DefaultCellStyle.BackColor = Color.White;
                    deleteItemButton.Text = "Delete Selected Item";
                }
                // Added following 7 lines in V. 0.4 to fix bug where items column in grid was not being updated when an item was deleted, given no other changes
                string itemsContents = BuildItemsContents(); 
                if (itemsContents.Length > 0)
                {
                    changeSaleGridView.CellValueChanged -= changeSaleGridView_CellValueChanged;
                    changeSaleGridView.CurrentRow.Cells["items"].Value = itemsContents;
                    changeSaleGridView.CellValueChanged += changeSaleGridView_CellValueChanged;
                }
            }
            UpdateSaleValuesColorAndSaveSalesState(changeSaleGridView.CurrentRow.Index);
        }

        private void changeSaleItemGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Try to keep user from trying to change the ID of an item already in a sale
            if (e.ColumnIndex == 0 && e.RowIndex >= 0 && changeSaleItemGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor != Color.LightGreen)
                changeSaleItemGridView.Cursor = Cursors.No;
            else changeSaleItemGridView.Cursor = Cursors.Default;
        }

        private void changeSaleItemGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            changeSaleItemGridView.Cursor = Cursors.Default;
        }

         private void changeSaleGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DateTime dt;
            decimal amtTendered;
            switch (e.ColumnIndex) 
            {
                case 1: // When Sold
                    if (changeSaleGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || changeSaleGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                        MessageBox.Show("When Sold cannot be empty - please fill in a valid date and time.", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (!DateTime.TryParse(changeSaleGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out dt))
                    {
                        MessageBox.Show(changeSaleGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + " is not a valid datetime - please fill in a valid date and time. Format for US is (M)M/(d(d)/yyyy (h)h:mm AM|PM.", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        changeSaleGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                    break;
                case 4: // Tendered
                    if (changeSaleGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || changeSaleGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                        MessageBox.Show("Amt. Tendered cannot be empty - please fill in a amount.", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (!Decimal.TryParse(changeSaleGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out amtTendered) || (amtTendered < 0.01M))
                    {
                        MessageBox.Show(changeSaleGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + " is not a valid amount of money - please correct this.", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        changeSaleGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                    else if (Decimal.Parse(changeSaleGridView.Rows[e.RowIndex].Cells["sale_amount"].Value.ToString()) > amtTendered)
                    { 
                        MessageBox.Show("Amt. Tendered is less than the Sale Amount - please correct this.", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        changeSaleGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    }
                    break;
            }
            UpdateSaleValuesColorAndSaveSalesState(e.RowIndex);
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            ReceiptPrinting instance = new ReceiptPrinting();
            instance.PrintBuyersReceipt(Int32.Parse(changeSaleGridView.CurrentRow.Cells["sale_id"].Value.ToString()), 1) ; // Just print 1 copy
        }

        private void ChangeExistingSales_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) 
            {
                saleFilterGroupBox.Location = new System.Drawing.Point(132, 37);
            }
        }

        private void ChangeExistingSales_SizeChanged(object sender, EventArgs e)
        {
            saleFilterGroupBox.Location = new System.Drawing.Point(132, 37);
        }
    }
}
