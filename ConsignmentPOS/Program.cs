using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DT = System.Data;
using QC = System.Data.SqlClient;
using System.Xml;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Drawing.Printing;
using System.Drawing;

public static class DataManager
{
    public static string connString;
    public static SqlConnection dbc;
}


namespace ConsignmentPOS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DataManager.connString = Properties.Settings.Default.CoStoreConnectionString;
            DataManager.dbc = new QC.SqlConnection(DataManager.connString);
            DataManager.dbc.Open();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenuForm());
        }
    }

    public class ReceiptPrinting
    {
        private Font printFont;
        private StreamReader streamToPrint;


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

        public void PrintBuyersReceipt(int saleIDNo, int numCopies = 1)
        {
            // MessageBox.Show(String.Format("A copy of the Buyer's Receipt for sale {0} will be printed", saleIDNo));
            // Get the heading for the report from the ReceiptHeading property, append " Buyer's Receipt "
            string heading = Properties.Settings.Default.ReceiptHeading + " Buyer's Receipt ";
            // Get the (non-superseded) sale information from the database - the date and time, amount tendered, and change
            decimal tendered = 0, change = 0, saleAmount = 0;
            DateTime whenSold = DateTime.Now; // Just to keep VS happy lest it consider whenSold uninitialized when later used;
            using (var command = new SqlCommand())
            {
                command.Connection = DataManager.dbc;
                command.CommandType = DT.CommandType.Text;
                command.CommandText = @"SELECT tendered, change, when_sold FROM sale WHERE id = " + saleIDNo.ToString() + " AND superseded = 0";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tendered = reader.GetDecimal(0);
                    change = reader.GetDecimal(1);
                    whenSold = reader.GetDateTime(2);
                }
                reader.Close();
            }
            // Create a temporary file to hold the receipt text
            string tempFilePath;
            StreamWriter tempFileStream;
            try
            {
                tempFilePath = Path.GetTempFileName();
            }
            catch
            {
                MessageBox.Show("Could not create a temporary file in the " + Path.GetTempPath() + " folder in which to place the receipt text");
                return;
            }
            try
            {
                using (tempFileStream = File.CreateText(tempFilePath))
                {
                    // Append date and time to the heading and write this as the first line of the file, with a blank second line
                    tempFileStream.WriteLine(heading + whenSold.ToString("MM/dd HH:mm") + "\n");
                    // Write labels as third line
                    tempFileStream.WriteLine("Item ID & Description                           Qty.   Price @  Ext. Price");
                    // Get the information for each item in the sale
                    using (var command = new SqlCommand())
                    {
                        int itemID = 0, quantity = 0;
                        string shortDescription = "";
                        decimal amount = 0;
                        command.Connection = DataManager.dbc;
                        command.CommandType = DT.CommandType.Text;
                        command.CommandText = @"SELECT item_id, short_description, quantity, amount FROM sale_item si JOIN item i ON si.item_id = i.id WHERE sale_id = " +
                            saleIDNo.ToString() + " AND si.superseded = 0 ORDER BY item_id";
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            itemID = reader.GetInt32(0);
                            shortDescription = reader.GetString(1);
                            quantity = reader.GetInt32(2);
                            amount = reader.GetDecimal(3);
                            // Write the information for each line item - ID, short description, unit price (calculated), and extended price as lines till reader stops returning data
                            tempFileStream.WriteLine(String.Format("{0,5}: {1,-40} {2,3} {3,10} {4,11}",
                                itemID.ToString(), shortDescription, quantity.ToString(), (amount / quantity).ToString("F2"), amount.ToString("F2")));
                            saleAmount += amount;
                        }
                        reader.Close();
                        if (saleAmount == 0)
                        {
                            MessageBox.Show("Unable to retrieve sale items.");
                            return;
                        }
                    }
                    // Write Sale ID label and number, and Total Sale label and amount as next line
                    tempFileStream.WriteLine(String.Format("\nSale ID {0,-5}                                  Total Sale      {1,11}", saleIDNo.ToString(), saleAmount.ToString("F2")));
                    // Write Amount Tendered label and amount as next line
                    tempFileStream.WriteLine(String.Format("                                               Amount Tendered {0,11}", tendered.ToString("F2")));
                    // Write Change label and amount as last line
                    tempFileStream.WriteLine(String.Format("                                               Change          {0,11}", change.ToString("F2")));
                    tempFileStream.Close();
                } // End of "using ..."
            } // End of "try"
            catch
            {
                MessageBox.Show("Could not create a temporary file " + tempFilePath + " in which to place the receipt text");
                return;
            }
            // Print the temp file
            for (int i = 0; i < numCopies; i++)
            {
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
            }
            // Delete the temp file
            File.Delete(tempFilePath);
        }

        public void PrintSellersReceipt(int sellerIDNo, string sellerIdAndName, int numCopies = 1)
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
                MessageBox.Show("Could not create a temporary file in the " + Path.GetTempPath() + " folder in which to place the receipt text");
                return;
            }
            // Get the heading for the report from the ReceiptHeading property, append " Seller's Receipt " and the current date and time
            string heading = Properties.Settings.Default.ReceiptHeading + " Seller's Receipt " + DateTime.Now.ToString("MM/dd HH:mm");
            int previousItemID = 0;
            try
            {
                using (tempFileStream = File.CreateText(tempFilePath))
                {
                    // Write this as the first line of the file, with a blank second line
                    tempFileStream.WriteLine(heading + "\n");
                    // Write the "Seller" label and the seller's ID and name as the thrid line, and another blank line foilowing
                    tempFileStream.WriteLine("Seller: " + sellerIdAndName + "\n");
                    // Write the header for the items list
                    tempFileStream.WriteLine("Item ID & Description                          Qty. for Sale   Price @ Qty.\n");
                    // Get the information for each item of this seller
                    using (var command = new SqlCommand())
                    {
                        int itemID = 0, quantity_at_start = 0, quantity_break = 0;
                        string shortDescription = "";
                        decimal price = 0M;
                        command.Connection = DataManager.dbc;
                        command.CommandType = DT.CommandType.Text;
                        command.CommandText = @"SELECT item_id, short_description, quantity_at_start, price, quantity_break FROM item i JOIN price p ON p.item_id = i.id WHERE seller_id = " +
                            sellerIDNo.ToString() + " ORDER BY item_id ASC, price DESC";
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            itemID = reader.GetInt32(0);
                            shortDescription = reader.GetString(1);
                            quantity_at_start = reader.GetInt32(2);
                            price = reader.GetDecimal(3);
                            quantity_break = reader.GetInt32(4);
                            if (itemID != previousItemID)
                                // Write the information for each line item - ID, short description, unit price (calculated), and extended price as lines till reader stops returning data
                                tempFileStream.WriteLine(String.Format("{0,5}: {1,-40}       {2,4}  {3,8}  {4,4}\n",
                                    itemID.ToString(), shortDescription, quantity_at_start.ToString(), price.ToString("F2"), quantity_break.ToString()));
                            else
                                // Just write the price information
                                tempFileStream.WriteLine(String.Format("                                                            {0,8}  {1,4}\n",
                                    price.ToString("F2"), quantity_break.ToString()));

                            previousItemID = itemID; // Save the itemID for comparison against the next one
                        }
                        reader.Close();
                    } // End of "using (var command ..."
                    // Write consignment statements - added for V. 0.6
                    if (Properties.Settings.Default.ConsignmentStmt1.Length > 0) 
                    {
                        tempFileStream.WriteLine(Properties.Settings.Default.ConsignmentStmt1);
                        if (Properties.Settings.Default.ConsignmentStmt2.Length > 0)
                            tempFileStream.WriteLine(Properties.Settings.Default.ConsignmentStmt2);
                    }
                }  // End of "using (tempFileStream ..."
            } // End of try
            catch
            {
                MessageBox.Show("Could not create a temporary file " + tempFilePath + " in which to place the receipt text");
                return;
            }
            if (previousItemID == 0)
            {
                MessageBox.Show("There are no items for " + sellerIdAndName + " - nothing will be printed");
                // Delete the temp file
                File.Delete(tempFilePath);
                return;
            }
            // Print the temp file
            for (int i = 0; i < numCopies; i++)
            {
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
            }
            // Delete the temp file
            File.Delete(tempFilePath);
        } // End of PrintSellersReceipt method
    } // End of ReceiptPrinting class
} // End of ConsignmentPOS namespace
