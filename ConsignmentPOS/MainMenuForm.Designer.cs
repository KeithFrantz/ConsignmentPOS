namespace ConsignmentPOS
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.enterNewSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeExistingSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settleWSellersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintainSellersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterNewSellersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeExistingSellersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintainLocationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintainItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterNewItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeExistingItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterNewSalesToolStripMenuItem,
            this.changeExistingSalesToolStripMenuItem,
            this.settleWSellersToolStripMenuItem,
            this.cashCountToolStripMenuItem,
            this.maintainSellersToolStripMenuItem,
            this.maintainLocationsToolStripMenuItem,
            this.maintainItemsToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1285, 28);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "mainMenuStrip";
            // 
            // enterNewSalesToolStripMenuItem
            // 
            this.enterNewSalesToolStripMenuItem.Name = "enterNewSalesToolStripMenuItem";
            this.enterNewSalesToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.enterNewSalesToolStripMenuItem.Text = "Enter New Sales";
            this.enterNewSalesToolStripMenuItem.Click += new System.EventHandler(this.enterNewSalesToolStripMenuItem_Click);
            // 
            // changeExistingSalesToolStripMenuItem
            // 
            this.changeExistingSalesToolStripMenuItem.Name = "changeExistingSalesToolStripMenuItem";
            this.changeExistingSalesToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.changeExistingSalesToolStripMenuItem.Text = "Change Existing Sales";
            this.changeExistingSalesToolStripMenuItem.Click += new System.EventHandler(this.changeExistingSalesToolStripMenuItem_Click);
            // 
            // settleWSellersToolStripMenuItem
            // 
            this.settleWSellersToolStripMenuItem.Name = "settleWSellersToolStripMenuItem";
            this.settleWSellersToolStripMenuItem.Size = new System.Drawing.Size(126, 24);
            this.settleWSellersToolStripMenuItem.Text = "Settle w. Sellers";
            this.settleWSellersToolStripMenuItem.Click += new System.EventHandler(this.settleWSellersToolStripMenuItem_Click);
            // 
            // cashCountToolStripMenuItem
            // 
            this.cashCountToolStripMenuItem.Name = "cashCountToolStripMenuItem";
            this.cashCountToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.cashCountToolStripMenuItem.Text = "Cash Count";
            this.cashCountToolStripMenuItem.Click += new System.EventHandler(this.cashCountToolStripMenuItem_Click);
            // 
            // maintainSellersToolStripMenuItem
            // 
            this.maintainSellersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterNewSellersToolStripMenuItem,
            this.changeExistingSellersToolStripMenuItem});
            this.maintainSellersToolStripMenuItem.Name = "maintainSellersToolStripMenuItem";
            this.maintainSellersToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.maintainSellersToolStripMenuItem.Text = "Maintain Sellers";
            // 
            // enterNewSellersToolStripMenuItem
            // 
            this.enterNewSellersToolStripMenuItem.Name = "enterNewSellersToolStripMenuItem";
            this.enterNewSellersToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.enterNewSellersToolStripMenuItem.Text = "Enter New Sellers";
            this.enterNewSellersToolStripMenuItem.Click += new System.EventHandler(this.enterNewSellersToolStripMenuItem_Click);
            // 
            // changeExistingSellersToolStripMenuItem
            // 
            this.changeExistingSellersToolStripMenuItem.Name = "changeExistingSellersToolStripMenuItem";
            this.changeExistingSellersToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.changeExistingSellersToolStripMenuItem.Text = "Change Existing Sellers";
            this.changeExistingSellersToolStripMenuItem.Click += new System.EventHandler(this.changeExistingSellersToolStripMenuItem_Click);
            // 
            // maintainLocationsToolStripMenuItem
            // 
            this.maintainLocationsToolStripMenuItem.Name = "maintainLocationsToolStripMenuItem";
            this.maintainLocationsToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.maintainLocationsToolStripMenuItem.Text = "Maintain Locations";
            this.maintainLocationsToolStripMenuItem.Click += new System.EventHandler(this.maintainLocationsToolStripMenuItem_Click);
            // 
            // maintainItemsToolStripMenuItem
            // 
            this.maintainItemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterNewItemsToolStripMenuItem,
            this.changeExistingItemsToolStripMenuItem});
            this.maintainItemsToolStripMenuItem.Name = "maintainItemsToolStripMenuItem";
            this.maintainItemsToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
            this.maintainItemsToolStripMenuItem.Text = "Maintain Items";
            // 
            // enterNewItemsToolStripMenuItem
            // 
            this.enterNewItemsToolStripMenuItem.Name = "enterNewItemsToolStripMenuItem";
            this.enterNewItemsToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.enterNewItemsToolStripMenuItem.Text = "Enter New Items";
            this.enterNewItemsToolStripMenuItem.Click += new System.EventHandler(this.enterNewItemsToolStripMenuItem_Click);
            // 
            // changeExistingItemsToolStripMenuItem
            // 
            this.changeExistingItemsToolStripMenuItem.Name = "changeExistingItemsToolStripMenuItem";
            this.changeExistingItemsToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.changeExistingItemsToolStripMenuItem.Text = "Change Existing Items";
            this.changeExistingItemsToolStripMenuItem.Click += new System.EventHandler(this.changeExistingItemsToolStripMenuItem_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 762);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainMenuForm";
            this.Text = "Consignment POS";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem enterNewSalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeExistingSalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settleWSellersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cashCountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintainSellersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterNewSellersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeExistingSellersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintainLocationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintainItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enterNewItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeExistingItemsToolStripMenuItem;
    }
}

