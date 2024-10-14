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
using System.Data.SqlClient;

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
                // Refresh the table
                SqlCommand cmd = new SqlCommand("SELECT id, description FROM location ORDER BY description", DataManager.dbc);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                {
                    CoStoreDataSet.locationDataTable dt = new CoStoreDataSet.locationDataTable();
                    adap.Fill(dt);
                    locationGridView.DataSource = dt;
                }

            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message); 
            }
        }

        private void MaintainLocations_VisibleChanged(object sender, EventArgs e) 
        {
            /*
            if (Visible) locationGridView.DataSource = locationTableAdapter.GetData(); // Refresh location grid each time control is made visible
            */

            if (Visible) // Refresh location grid each time control is made visible, omitting the empty zero-th non-location
            {
                SqlCommand cmd = new SqlCommand("SELECT id, description FROM location ORDER BY description", DataManager.dbc);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
                using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                {
                    CoStoreDataSet.locationDataTable dt = new CoStoreDataSet.locationDataTable();
                    adap.Fill(dt);
                    locationGridView.DataSource = dt;
                }
            }
        }
    }
}
