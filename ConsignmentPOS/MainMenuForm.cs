using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ConsignmentPOS
{
    public partial class MainMenuForm : Form
    {
        private readonly EnterNewSales enterNewSales = new EnterNewSales();
        private readonly ChangeExistingSales changeExistingSales = new ChangeExistingSales();
        private readonly SettleWSellers settleWSellers = new SettleWSellers();
        private readonly CashCount cashCount = new CashCount();
        private readonly EnterNewSellers enterNewSellers = new EnterNewSellers();
        private readonly ChangeExistingSellers changeExistingSellers = new ChangeExistingSellers();
        private readonly MaintainLocations maintainLocations = new MaintainLocations();
        private readonly EnterNewItems enterNewItems = new EnterNewItems();
        private readonly ChangeExistingItems changeExistingItems = new ChangeExistingItems();


        public MainMenuForm()
        {
            InitializeComponent();
            enterNewSales.Parent = this;
            changeExistingSales.Parent = this;
            settleWSellers.Parent = this;
            cashCount.Parent = this;
            enterNewSellers.Parent = this;
            changeExistingSellers.Parent = this;
            maintainLocations.Parent = this;
            enterNewItems.Parent = this;
            changeExistingItems.Parent = this;
            hideOpenUserControl(); // Start with all user controls hidden
            // Show an initial informational message just to verify that the connection string is correct
            int numActualSellers = 0;
            int numTotalSellers = 0;
            using (var command = new SqlCommand())
            {
                command.Connection = DataManager.dbc;
                command.CommandType = CommandType.Text;
                command.CommandText = @"SELECT COUNT(*) FROM seller";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    numTotalSellers = reader.GetInt32(0);
                }
                reader.Close();
                command.CommandText = @"WITH x AS (SELECT DISTINCT seller_id FROM item) SELECT COUNT(*) FROM x";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    numActualSellers = reader.GetInt32(0);
                }
                reader.Close();
                string verb = "are";
                string actualSellersNoun = "sellers";
                string potentialSellersNoun = "sellers";
                if (numActualSellers == 1)
                { 
                    verb = "is";
                    actualSellersNoun = "seller";
                }
                if (numTotalSellers - numActualSellers == 1)
                    potentialSellersNoun = "seller";
                MessageBox.Show(String.Format("Connection check - There {0} currently {1} actual {2} and {3} potential {4}",
                    verb, numActualSellers, actualSellersNoun, (numTotalSellers - numActualSellers), potentialSellersNoun),
                    "ConsignmentPOS V. 1.0 - A GPL Consignment Point Of Sale program");
            }
        }

        private void enterNewSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideOpenUserControl();
            enterNewSales.Show();
            enterNewSales.Size = new System.Drawing.Size(Width, Height);
        }

        private void changeExistingSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideOpenUserControl();
            changeExistingSales.Show();
            changeExistingSales.Size = new System.Drawing.Size(Width, Height);
        }

        private void settleWSellersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideOpenUserControl();
            settleWSellers.Show();
            settleWSellers.Size = new System.Drawing.Size(Width, Height);
        }

        private void cashCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideOpenUserControl();
            cashCount.Show();
            cashCount.Size = new System.Drawing.Size(Width, Height);
        }

        private void maintainSellersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void enterNewSellersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideOpenUserControl();
            enterNewSellers.Show();
            enterNewSellers.Size = new System.Drawing.Size(Width, Height);
        }

        private void changeExistingSellersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideOpenUserControl();
            changeExistingSellers.Show();
            changeExistingSellers.Size = new System.Drawing.Size(Width, Height);
        }

        private void maintainLocationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideOpenUserControl();
            maintainLocations.Show();
            maintainLocations.Size = new System.Drawing.Size(Width, Height);
            //maintainLocations.LocationDataGridView.
        }

        private void maintainItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void enterNewItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideOpenUserControl();
            enterNewItems.Show();
            enterNewItems.Size = new System.Drawing.Size(Width, Height);
        }

        private void changeExistingItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideOpenUserControl();
            changeExistingItems.Show();
            changeExistingItems.Size = new System.Drawing.Size(Width, Height);
        }

        public void hideOpenUserControl() //Hide whatever userControl is currently shown
        {
            enterNewSales.Hide();
            changeExistingSales.Hide();
            settleWSellers.Hide();
            cashCount.Hide();
            enterNewSellers.Hide();
            changeExistingSellers.Hide();
            maintainLocations.Hide();
            enterNewItems.Hide();
            changeExistingItems.Hide();
        }

    }
}
