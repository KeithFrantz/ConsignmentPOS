using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsignmentPOS
{
    public partial class MaintainLocations : UserControl
    {
        public MaintainLocations()
        {
            InitializeComponent();
        }

        private void saveLocations_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.locationBindingSource.EndEdit();
                this.locationTableAdapter.Update((ConsignmentPOS.CoStoreDataSet.locationDataTable)locationGridView.DataSource);
            }
            catch (System.Data.NoNullAllowedException ex)
            {
                MessageBox.Show("Location descriptions may not be empty\n" + ex.Message);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    int descStart = ex.Message.LastIndexOf('(') + 1;
                    int descEnd = ex.Message.LastIndexOf(')');
                    MessageBox.Show("There is already a location with the description:\n" +
                        ex.Message.Substring(descStart, descEnd - descStart) + "\nLocation descriptions must all be different");
                }
                else if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    MessageBox.Show("You may not delete a location where items are located - they must be moved elsewhere first");
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message); 
            }
        }

        private void MaintainLocations_VisibleChanged(object sender, EventArgs e) 
        {
            if (Visible) locationGridView.DataSource = locationTableAdapter.Fill(); // Refresh location grid each time control is made visible
        }

        private void locationGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Try to keep user from trying to change the description of the "fake" 0th row
            if (e.RowIndex == 0)
                locationGridView.Cursor = Cursors.No;
            else locationGridView.Cursor = Cursors.Default;
        }

        private void locationGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            locationGridView.Cursor = Cursors.Default;
        }

        private void locationGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0 && locationGridView.Rows[0].Cells["descriptionDataGridViewTextBoxColumn"].Value !=DBNull.Value && 
                locationGridView.Rows[0].Cells["descriptionDataGridViewTextBoxColumn"].Value.ToString().Length > 0)
            {
                MessageBox.Show("The first row in the Location grid needs to remain blank to allow an item to have no location", "Invalid entry",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                locationGridView.Rows[0].Cells["descriptionDataGridViewTextBoxColumn"].Value = "";
            }
        }
    }
}
