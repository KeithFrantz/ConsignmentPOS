USE [CoStore]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[seller] ******/

CREATE TABLE [dbo].[seller](
	[id] [int] NOT NULL,
	[salutation] [nvarchar](10) NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[middle_name] [nvarchar](50) NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[suffix] [nvarchar](10) NULL,
	[address_1] [nvarchar](80) NULL,
	[address_2] [nvarchar](80) NULL,
	[post_office] [nvarchar](40) NULL,
	[state] [nvarchar](20) NULL,
	[postal_code] [nvarchar](10) NULL,
	[country] [nvarchar](20) NOT NULL,
	[phone_1] [char](15) NULL,
	[phone_2] [char](15) NULL,
	[email] [nvarchar](80) NULL,
	[member_id] [varchar](10) NULL,
	[last_edit_at] [datetime] NULL,
	[last_edit_by] [nvarchar](40) NOT NULL
 CONSTRAINT [PK_seller] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[seller] ADD  CONSTRAINT [DF_seller_country]  DEFAULT (N'USA') FOR [country]
GO

ALTER TABLE [dbo].[seller] ADD  CONSTRAINT [DF_seller_last_edit_at]  DEFAULT (getdate()) FOR [last_edit_at]
GO

ALTER TABLE [dbo].[seller] ADD  CONSTRAINT [DF_seller_last_edit_by]  DEFAULT (N'System') FOR [last_edit_by]
GO

ALTER TABLE [dbo].[seller] ADD CONSTRAINT UK_seller UNIQUE ([first_name], [middle_name], [last_name], [suffix])

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for seller; convention registration number from registrar''s data' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mr./Ms./Mrs./Dr./Rev./etc., for printing/display purposes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'salutation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Seller''s first name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'first_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Seller''s middle name or initial (in case there are multiple John Smiths)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'middle_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Seller''s last name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'last_name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sr., Jr., 3rd., etc.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'suffix'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1st line of address' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'address_1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'2nd line of address, if needed' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'address_2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Post office (typically city or town)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'post_office'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'State/province/region' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'state'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zip code if USA' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'postal_code'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Could be Canada or UK in the case of guests' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'country'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primary phone number, 10 digits, stored without formatting' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'phone_1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Secondary phone number, 10 digits' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'phone_2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'E-mail address' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'email'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'NMRA membership number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'member_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Updated when record is inserted or updated' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'last_edit_at'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID of the person inserting or updating the record, from SQL Server session' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller', @level2type=N'COLUMN',@level2name=N'last_edit_by'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Lists potential and actual sellers with contact information' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'seller'
GO

/****** Object:  Table [dbo].[location] ******/

CREATE TABLE [dbo].[location](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_location] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_location] UNIQUE NONCLUSTERED 
(
	[description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for location' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'location', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description of the location' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'location', @level2type=N'COLUMN',@level2name=N'description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Optional static table of locations, e.g. tables, in the sales room where items to be sold are placed' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'location'
GO

/****** Object:  Table [dbo].[cash] ******/

CREATE TABLE [dbo].[cash](
	[count_at] [datetime] NOT NULL,
	[count_by] [nvarchar](40) NOT NULL,
	[amount_in_store] [decimal](8, 2) NOT NULL,
	[amount_remote] [decimal](8, 2) NOT NULL,
	[total_should_be] [decimal](8, 2) NOT NULL,
	[comment] [nvarchar](1000) NULL,
 CONSTRAINT [PK_cash] PRIMARY KEY CLUSTERED 
(
	[count_at] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[cash] ADD  CONSTRAINT [DF_cash_count_at]  DEFAULT (getdate()) FOR [count_at]
GO

ALTER TABLE [dbo].[cash] ADD  CONSTRAINT [DF_cash_amount_remote]  DEFAULT ((0)) FOR [amount_remote]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'When count was recorded' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cash', @level2type=N'COLUMN',@level2name=N'count_at'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'By whom count was done' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cash', @level2type=N'COLUMN',@level2name=N'count_by'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Amount in the Company Store cash box' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cash', @level2type=N'COLUMN',@level2name=N'amount_in_store'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Amount stored remotely' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cash', @level2type=N'COLUMN',@level2name=N'amount_remote'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total amount of cash that should be present, given the starting amount, and sales and settlements up to this time', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cash', @level2type=N'COLUMN',@level2name=N'total_should_be'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Explanatory text for count' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cash', @level2type=N'COLUMN',@level2name=N'comment'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Records cash count at a point in time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'cash'
GO

/****** Object:  Table [dbo].[sale] ******/

CREATE TABLE [dbo].[sale](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tendered] [decimal](7, 2) NOT NULL,
	[change] [decimal](7, 2) NOT NULL,
	[when_sold] [datetime] NOT NULL,
	[superseded] [bit] NOT NULL,
	[superseding_id] [int] NULL,
	[last_edit_at] [datetime] NOT NULL,
	[last_edit_by] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_sale] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[sale] ADD  CONSTRAINT [DF_sale_superseded]  DEFAULT ((0)) FOR [superseded]
GO

ALTER TABLE [dbo].[sale] ADD  CONSTRAINT [DF_sale_last_edit_at]  DEFAULT (getdate()) FOR [last_edit_at]
GO

ALTER TABLE [dbo].[sale] ADD  CONSTRAINT [DF_sale_last_edit_by]  DEFAULT (N'System') FOR [last_edit_by]
GO

ALTER TABLE [dbo].[sale]  WITH CHECK ADD  CONSTRAINT [FK_sale_sale] FOREIGN KEY([superseding_id])
REFERENCES [dbo].[sale] ([id])
GO

ALTER TABLE [dbo].[sale] CHECK CONSTRAINT [FK_sale_sale]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for each version of each sale' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Amount buyer gave clerk' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale', @level2type=N'COLUMN',@level2name=N'tendered'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Amount of change returned to buyer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale', @level2type=N'COLUMN',@level2name=N'change'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'When sale occurred' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale', @level2type=N'COLUMN',@level2name=N'when_sold'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Set to TRUE for existing record if sale is edited, thereby creating a new record, or if a sale is completely deleted' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale', @level2type=N'COLUMN',@level2name=N'superseded'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Null for records that do not supersede another record' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale', @level2type=N'COLUMN',@level2name=N'superseding_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Updated when record is inserted or superseded' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale', @level2type=N'COLUMN',@level2name=N'last_edit_at'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID of the person inserting or updating the record, from SQL Server session' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale', @level2type=N'COLUMN',@level2name=N'last_edit_by'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Records each instance of a sale being made, which could include multiple items' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'superseding_id must refer to a superseded sale' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale', @level2type=N'CONSTRAINT',@level2name=N'FK_sale_sale'
GO

/****** Object:  Table [dbo].[item] ******/

CREATE TABLE [dbo].[item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[seller_id] [int] NOT NULL,
	[short_description] [nvarchar](40) NOT NULL,
	[long_description] [nvarchar](1000) NULL,
	[location_id] [int] NULL,
	[quantity_at_start] [int] NOT NULL,
	[quantity_returned] [int] NULL,
	[amount_paid] [decimal](7, 2) NULL,
	[commission] [decimal](7, 2) NULL,
	[last_edit_at] [datetime] NOT NULL,
	[last_edit_by] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_item] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_item] UNIQUE NONCLUSTERED 
(
	[seller_id] ASC,
	[short_description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[item] ADD  CONSTRAINT [DF_item_quantity_at_start]  DEFAULT ((1)) FOR [quantity_at_start]
GO

ALTER TABLE [dbo].[item] ADD  CONSTRAINT [DF_item_last_edit_at]  DEFAULT (getdate()) FOR [last_edit_at]
GO

ALTER TABLE [dbo].[item] ADD  CONSTRAINT [DF_item_last_edit_by]  DEFAULT (N'System') FOR [last_edit_by]
GO

ALTER TABLE [dbo].[item]  WITH CHECK ADD  CONSTRAINT [FK_item_seller] FOREIGN KEY([seller_id])
REFERENCES [dbo].[seller] ([id])
GO

ALTER TABLE [dbo].[item] CHECK CONSTRAINT [FK_item_seller]
GO

ALTER TABLE [dbo].[item]  WITH CHECK ADD  CONSTRAINT [FK_item_location] FOREIGN KEY([location_id])
REFERENCES [dbo].[location] ([id])
GO

ALTER TABLE [dbo].[item] CHECK CONSTRAINT [FK_item_location]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for a sort of thing to be sold by a particular seller' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'item', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identify seller' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'item', @level2type=N'COLUMN',@level2name=N'seller_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description by which item may be identified; size must match registration spreadsheet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'item', @level2type=N'COLUMN',@level2name=N'short_description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Additional description as needed; may not be on registration spreadsheet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'item', @level2type=N'COLUMN',@level2name=N'long_description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Optional link to the location in the sales room where the item is locatated, e.g. a particular table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'item', @level2type=N'COLUMN',@level2name=N'location_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total amount initially being offered for sale' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'item', @level2type=N'COLUMN',@level2name=N'quantity_at_start'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unsold quantity returned to the seller; entered when settling up' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'item', @level2type=N'COLUMN',@level2name=N'quantity_returned'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The total amount of money paid to the seller for the quantity sold; entered when settling up' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'item', @level2type=N'COLUMN',@level2name=N'amount_paid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The difference between the sum of sales.amount and item.amount_paid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'item', @level2type=N'COLUMN',@level2name=N'commission'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Updated when record is inserted or updated' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'item', @level2type=N'COLUMN',@level2name=N'last_edit_at'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID of the person inserting or updating the record, from SQL Server session' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'item', @level2type=N'COLUMN',@level2name=N'last_edit_by'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'List of items for each seller' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'item'
GO

/****** Object:  Table [dbo].[price] ******/

CREATE TABLE [dbo].[price](
	[item_id] [int] NOT NULL,
	[quantity_break] [int] NOT NULL,
	[price] [decimal](7, 2) NOT NULL,
	[last_edit_at] [datetime] NOT NULL,
	[last_edit_by] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_price] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC,
	[quantity_break] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[price] ADD CONSTRAINT [DF_price_quantity_break]  DEFAULT ((1)) FOR [quantity_break]
GO

ALTER TABLE [dbo].[price] ADD  CONSTRAINT [DF_price_last_edit_by]  DEFAULT (N'System') FOR [last_edit_by]
GO

ALTER TABLE [dbo].[price]  WITH CHECK ADD CONSTRAINT [FK_price_item] FOREIGN KEY([item_id])
REFERENCES [dbo].[item] ([id])
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identify item' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'price', @level2type=N'COLUMN',@level2name=N'item_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Desxription', @value=N'Amount in a single sale at or above which the price in this record applies, barring a record with a higher quantity_break' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'price', @level2type=N'COLUMN',@level2name=N'quantity_break'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unit price for this quantity_break' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'price', @level2type=N'COLUMN',@level2name=N'price'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Updated when record is inserted or updated' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'price', @level2type=N'COLUMN',@level2name=N'last_edit_at'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID of the person inserting or updating the record, from SQL Server session' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'price', @level2type=N'COLUMN',@level2name=N'last_edit_by'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Quantity prices for each item' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'price'
GO

/****** Object:  Table [dbo].[sale_item] ******/

CREATE TABLE [dbo].[sale_item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sale_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[amount] [decimal](7, 2) NOT NULL,
	[superseded] [bit] NOT NULL,
	[last_edit_at] [datetime] NOT NULL,
	[last_edit_by] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_sale_item] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[sale_item] ADD  CONSTRAINT [DF_sale_item_quantity]  DEFAULT ((1)) FOR [quantity]
GO

ALTER TABLE [dbo].[sale_item] ADD  CONSTRAINT [DF_sale_item_superseded]  DEFAULT ((0)) FOR [superseded]
GO

ALTER TABLE [dbo].[sale_item] ADD  CONSTRAINT [DF_sale_item_last_edit_at]  DEFAULT (getdate()) FOR [last_edit_at]
GO

ALTER TABLE [dbo].[sale_item] ADD  CONSTRAINT [DF_sale_item_last_edit_by]  DEFAULT (N'System') FOR [last_edit_by]
GO

ALTER TABLE [dbo].[sale_item]  WITH CHECK ADD  CONSTRAINT [FK_sale_item_item] FOREIGN KEY([item_id])
REFERENCES [dbo].[item] ([id])
GO

ALTER TABLE [dbo].[sale_item] CHECK CONSTRAINT [FK_sale_item_item]
GO

ALTER TABLE [dbo].[sale_item]  WITH CHECK ADD  CONSTRAINT [FK_sale_item_sale] FOREIGN KEY([sale_id])
REFERENCES [dbo].[sale] ([id])
GO

ALTER TABLE [dbo].[sale_item] CHECK CONSTRAINT [FK_sale_item_sale]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for each version of each sale item' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale_item', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the sale' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale_item', @level2type=N'COLUMN',@level2name=N'sale_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identifies the item in the sale' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale_item', @level2type=N'COLUMN',@level2name=N'item_id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Number of this item in this sale' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale_item', @level2type=N'COLUMN',@level2name=N'quantity'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Total amount charged for this item,  accounting for quantity if > 1, i.e. the Ext. Price column value' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale_item', @level2type=N'COLUMN',@level2name=N'amount'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Set to TRUE for existing record if sale item is edited, thereby creating a new record, or if a sale item is completely deleted' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale_item', @level2type=N'COLUMN',@level2name=N'superseded'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Updated when record is inserted or superseded' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale_item', @level2type=N'COLUMN',@level2name=N'last_edit_at'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID of the person inserting or updating the record, from SQL Server session' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale_item', @level2type=N'COLUMN',@level2name=N'last_edit_by'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Every sale item must be an item that is for sale' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale_item', @level2type=N'CONSTRAINT',@level2name=N'FK_sale_item_item'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Every sale_item must belong to a sale' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sale_item', @level2type=N'CONSTRAINT',@level2name=N'FK_sale_item_sale'
GO

/****** Object:  Table [dbo].[item_import] ******/

CREATE TABLE [dbo].[item_import](
	[seller_id] [int] NOT NULL,
	[short_description] [nchar](40) NOT NULL,
	[long_description] [nchar](1000) NULL,
	[quantity] [int] NOT NULL,
	[price_each] [decimal](7, 2) NOT NULL,
 CONSTRAINT [PK_item_import] PRIMARY KEY CLUSTERED 
(
	[seller_id] ASC,
	[short_description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  StoredProcedure [dbo].[change_item] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 3 July 2023
-- Description:	Updates an existing item in the item table and its associated
--              pricing information (which is passed as a string of pairs of 
--              numbers - quantity_break1,price1,quantity_break2,price2,...,
--              quantity_breakN,priceN) in the price table.  This is all done
--              in a transaction so it all succeeds or fails.  It returns 0
--              if successful, 3 if no new price records were created, or an
--              error code if there was an error (there is no error code 3).
--              quantity_returned, amount_paid, and commission are not updated
--              by this SP as the Change Existing Items screen, that is the only 
--              screen wherein this is called, doesn't allow changes to items 
--              for which settlement has been made.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[change_item]
	@id int,
	@seller_id int,
	@short_description nvarchar(40),
	@long_description nvarchar(1000),
	@location_id int,
	@quantity_at_start int,
	@pricing nvarchar(1000) -- way longer than it'd ever practically be
AS
BEGIN
	DECLARE @error int = 0, @row_count int = 0, @start int = 1, @next_comma int, @num_price_rows int = 0, 
		@quantity_break int, @price decimal(7,2), @done bit = 0, @now datetime = GETDATE()
	BEGIN TRAN
	BEGIN TRY
		IF @location_id = 0 -- The null location is coded as 0 in the location dropdown but there's no entry o in the location table
			UPDATE item SET 
				seller_id = @seller_id, 
				short_description = @short_description, 
				long_description = @long_description, 
				location_id = NULL, 
				quantity_at_start = @quantity_at_start,
				last_edit_at = @now
				WHERE id = @id
		ELSE
			UPDATE item SET 
				seller_id = @seller_id, 
				short_description = @short_description, 
				long_description = @long_description, 
				location_id = @location_id, 
				quantity_at_start = @quantity_at_start,
				last_edit_at = @now
				WHERE id = @id
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			RETURN @error
		END
	END CATCH
	BEGIN TRY
		DELETE FROM price WHERE item_id = @id
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			RETURN @error
		END
	END CATCH
	-- Parse @pricing and create a record for each number pair
	SELECT @next_comma = CHARINDEX(',', @pricing, @start)
	IF @next_comma < 2 SELECT @done = 1 -- @if the @pricing parameter is malformed (has no commas or starts with one) don't try to create price records
	WHILE @done = 0 BEGIN
		--SELECT @length = @next_comma - @start
		SELECT @quantity_break = CAST(SUBSTRING(@pricing, @start, @next_comma - @start) AS int)
		SELECT @start = @next_comma + 1
		SELECT @next_comma = CHARINDEX(',', @pricing, @start)
		IF @next_comma > 1 BEGIN -- Not at the end yet
			SELECT @price = CAST(SUBSTRING(@pricing, @start, @next_comma - @start) AS decimal(7,2))
			-- Get ready to read the next quantity_break value
			SELECT @start = @next_comma + 1
			SELECT @next_comma = CHARINDEX(',', @pricing, @start)
			IF @next_comma < 1 SELECT @done = 1 -- If there's no comma following the next quantity_break in @pricing stop here
		END
		ELSE BEGIN -- At the end of @pricing, handling the last price value 
			SELECT @price = CAST(SUBSTRING(@pricing, @start, LEN(@pricing) + 1 - @start) AS decimal(7,2)) -- LEN(@pricing) + 1 is where the next comma would be if it existed
			SELECT @done = 1
		END
		BEGIN TRY
			INSERT INTO price (item_id, quantity_break, price, last_edit_at) VALUES (@id, @quantity_break, @price, @now)
		END TRY
		BEGIN CATCH
			SELECT @error = @@ERROR
			IF @error <> 0  BEGIN
				ROLLBACK TRAN
				RETURN @error
			END
		END CATCH
		SELECT @num_price_rows = @num_price_rows + 1
	END
	IF @num_price_rows = 0 BEGIN -- If no rows were inserted into the price table, this is not allowed - every item must have at least one price
		ROLLBACK TRAN
		RETURN 3 -- There was no error but neither was a new item inserted (assuming ROLLBACK TRAN did what it should)
	END
	COMMIT TRAN
	RETURN 0
END
GO

/****** Object:  StoredProcedure [dbo].[change_sale_items] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 27 July 2023
-- Description:	Handles changes to the items ina sale that don't result in a 
--              change to the sale itself.  Supersedes deleted and changed 
--              items, and creates new sale_item records for changed items
--              with the new information as well as for inserted items.  It  
--              does this in a transaction so all succeed or fail.  Returns 
--              (via a final SELECT) 0 if successful, 1 if the @sale_items 
--              string was malformed, or @@ERROR number for other errors.
--              (1 is not used for any internal errors in SQL Server 2019 
--              or 2022)
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[change_sale_items]
	@id int, -- The id of the sale whose items are to be altered
	@sale_items nvarchar(1000) -- way longer than it'd ever practically be
AS
BEGIN
	DECLARE @error int = 0, @now datetime = GETDATE(), @row_count int = 0, 
		@start int = 1, @next_comma int, @num_sale_item_rows int = 0, 
		@item_id int, @quantity int, @amount decimal(7,2), @done bit = 0,
		@action_and_item nvarchar(20), -- item_id possibly preceded by I:, C:, or D:
		@action nvarchar(1) -- D = delete, C = change, I = insert, empty = no action
	BEGIN TRAN
	-- Parse @sale_items and do the appropriate action for each number trio 
	-- preceded by D:, C:, or I:
	SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
	-- if the @sale_items parameter is malformed (has no commas or starts with one)
	-- don't try to modify sale_item records
	IF @next_comma < 2 BEGIN
		ROLLBACK TRAN -- Nothing to roll back yet but shouldn't leave transaction open
		SELECT 1
		RETURN
	END
	WHILE @done = 0 BEGIN
		-- Assume no action for each item unless a letter and a colon prefix the trio
		SELECT @action = ''
		SELECT @action_and_item = SUBSTRING(@sale_items, @start, @next_comma - @start)
		IF CHARINDEX (':' , @action_and_item) != 0 BEGIN
			SELECT @action = LEFT(@action_and_item, 1)
			SELECT @item_id = CAST(SUBSTRING(@action_and_item, 3, LEN(@action_and_item) - 1) AS int)
		END
		ELSE SELECT @item_id = CAST(@action_and_item AS int)
		SELECT @start = @next_comma + 1
		SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
		IF @next_comma = 0 BEGIN -- If there's no next comma here,  @sale_items is malformed 
			ROLLBACK TRAN
			SELECT 1
			RETURN
		END
		SELECT @quantity = CAST(SUBSTRING(@sale_items, @start, @next_comma - @start) AS int)
		SELECT @start = @next_comma + 1
		SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
		IF @next_comma > 1 BEGIN -- Not at the end yet
			SELECT @amount = CAST(SUBSTRING(@sale_items, @start, @next_comma - @start) AS decimal(7,2))
			-- Get ready to read the next item_id value
			SELECT @start = @next_comma + 1
			SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
			IF @next_comma < 1 BEGIN -- If there's no comma following the next item_id in @sale_items is malformed
				ROLLBACK TRAN
				SELECT 1 
				RETURN
			END
		END
		ELSE BEGIN -- At the end of @sale_items, handling the amount value
			-- LEN(@sale_items) + 1 is where the next comma would be if it existed
			SELECT @amount = CAST(SUBSTRING(@sale_items, @start, LEN(@sale_items) + 1 - @start) AS decimal(7,2)) 
			SELECT @done = 1
		END
		IF @action = 'D' OR @action = 'C' BEGIN -- "Delete" the existing item (mark it as superseded)
			BEGIN TRY
				UPDATE sale_item SET superseded = 1, last_edit_at = @now WHERE sale_id = @id AND item_id = @item_id AND superseded = 0
			END TRY
			BEGIN CATCH
				SELECT @error = @@ERROR
				IF @error <> 0 BEGIN
					ROLLBACK TRAN
					SELECT @error
					RETURN
				END
			END CATCH
		END
		IF @action = 'I' OR @action = 'C' BEGIN -- Create a new sale_item record
			BEGIN TRY
				INSERT INTO sale_item (sale_id, item_id, quantity, amount, superseded, last_edit_at) VALUES (@id, @item_id, @quantity, @amount, 0, @now)
			END TRY
			BEGIN CATCH
				SELECT @error = @@ERROR
				IF @error <> 0 BEGIN
					ROLLBACK TRAN
					SELECT @error
					RETURN
				END 
			END CATCH
		END
	END
	COMMIT TRAN
	SELECT 0
	RETURN 
END
GO

/****** Object:  StoredProcedure [dbo].[change_sale] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 26 July 2023
-- Description:	Creates a new sale with the modified information, and  
--              supersedes the old sale and all its items.  Sets superseding_id  
--              for the old sale to the id of the new sale.  It does this in a  
--              transaction so all succeed or fail.  Returns (via a final 
--              SELECT) 0 if successful, 5 if no sale items were inserted, 6 if
--              @sale_items is malformed, or @@ERROR number for other errors.
--              (5 and 6 are not used for any internal errors in SQL Server
--              2019 or 2022.)  If unsuccessful for any reason @new_id is 
--              returned as 0, which is not a valid sale id, as that identity 
--              is 1-based.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[change_sale]
	@id int, -- The id of the sale to be superseded
	@when_sold datetime,
	@tendered decimal(7,2),
	@change decimal(7,2),
	@sale_items nvarchar(1000), -- way longer than it'd ever practically be
	@new_id int OUT
AS
BEGIN
	DECLARE @error int = 0, @now datetime = GETDATE(), 
		@start int = 1, @next_comma int, @num_sale_item_rows int = 0, 
		@item_id int, @quantity int, @amount decimal(7,2), @done bit = 0,
		@action_and_item nvarchar(20), -- Item_id possibly preceded by I:, C:, or D:
		@delete_item bit
	BEGIN TRAN
	BEGIN TRY
		INSERT INTO sale (tendered, [change], when_sold, superseded, last_edit_at) 
			VALUES (@tendered, @change, @when_sold, 0, @now)
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			SELECT @new_id = 0
			SELECT @error
			RETURN 
		END
	END CATCH
	SELECT @new_id = @@IDENTITY
	BEGIN TRY
		UPDATE sale SET superseded = 1, superseding_id = @new_id, last_edit_at = @now WHERE id = @id
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			SELECT @new_id = 0
			SELECT @error
			RETURN 
		END
	END CATCH
	BEGIN TRY
		UPDATE sale_item SET superseded = 1, last_edit_at = @now WHERE sale_id = @id
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			SELECT @new_id = 0
			SELECT @error
			RETURN 
		END
	END CATCH
	-- Parse @sale_items and create a record for each number trio
	-- Note that unlike in insert_sale, there may be a letter and a colon before
	-- the item_id value, and if it's D, don't insert tthis item
	SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
	-- if the @sale_items parameter is malformed (has no commas or starts with one) abort
	IF @next_comma < 2 BEGIN
		ROLLBACK TRAN
		SELECT @new_id = 0
		SELECT 6
		RETURN
	END
	WHILE @done = 0 BEGIN
		SELECT @delete_item = 0 -- Assume the item isn't being deleted
		SELECT @action_and_item = SUBSTRING(@sale_items, @start, @next_comma - @start)
		IF CHARINDEX (':' , @action_and_item) != 0 BEGIN
			IF LEFT(@action_and_item, 1) =  'D' SELECT @delete_item = 1 -- unless it is
			SELECT @item_id = CAST(SUBSTRING(@action_and_item, 3, LEN(@action_and_item) - 1) AS int)
			END
		ELSE SELECT @item_id = CAST(@action_and_item AS int)
		SELECT @start = @next_comma + 1
		SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
		IF @next_comma = 0 BEGIN -- If there's no next comma here,  @sale_items is malformed 
			ROLLBACK TRAN
			SELECT @new_id = 0
			SELECT 6
			RETURN
		END
		SELECT @quantity = CAST(SUBSTRING(@sale_items, @start, @next_comma - @start) AS int)
		SELECT @start = @next_comma + 1
		SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
		IF @next_comma > 1 BEGIN -- Not at the end yet
			SELECT @amount = CAST(SUBSTRING(@sale_items, @start, @next_comma - @start) AS decimal(7,2))
			-- Get ready to read the next item_id value
			SELECT @start = @next_comma + 1
			SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
			IF @next_comma < 1 BEGIN -- If there's no comma following the next item_id in @@sale_items abort
				ROLLBACK TRAN
				SELECT @new_id = 0
				SELECT 6
				RETURN
			END
		END
		ELSE BEGIN -- At the end of @sale_items, handling the amount value 
			SELECT @amount = CAST(SUBSTRING(@sale_items, @start, LEN(@sale_items) + 1 - @start) AS decimal(7,2)) -- LEN(@sale_items) + 1 is where the next comma would be if it existed
			SELECT @done = 1
		END
		IF @delete_item = 0 BEGIN
			BEGIN TRY
				INSERT INTO sale_item (sale_id, item_id, quantity, amount, superseded, last_edit_at) VALUES (@new_id, @item_id, @quantity, @amount, 0, @now)
				SELECT @num_sale_item_rows = @num_sale_item_rows + 1
			END TRY
			BEGIN CATCH
				SELECT @error = @@ERROR
				IF @error <> 0 BEGIN
					ROLLBACK TRAN
					SELECT @new_id = 0
					SELECT @error
					RETURN
				END
			END CATCH
		END
	END
	IF @num_sale_item_rows = 0 BEGIN -- If all the items were deleted from a sale, that's not allowed
		ROLLBACK TRAN
		SELECT @new_id = 0
		SELECT 5
		RETURN
	END
	COMMIT TRAN
	SELECT 0
	RETURN
END
GO

/****** Object:  StoredProcedure [dbo].[delete_item] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 19 August 2023
-- Description:	Deletes an item from the item table and its associated
--              price records.  Returns 0 if successful, or the error
--              code if there was an error.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[delete_item]
	@id int 
AS
BEGIN
	DECLARE @error int
	BEGIN TRAN
	BEGIN TRY
		DELETE FROM price WHERE item_id = @id
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			RETURN @error
		END
	END CATCH
	BEGIN TRY
		DELETE FROM item WHERE id  = @id
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			RETURN @error
		END
	END CATCH
	COMMIT TRAN
	RETURN 0
END
GO

/****** Object:  StoredProcedure [dbo].[delete_sale] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 26 July 2023
-- Description:	Marks a sale and all its items as superseded but with no 
--              superseding_id for the sale.  Also updates all the last_edit_at 
--              fields of the affected rows.  It does this in a transaction so 
--              all succeed or fail.  Returns via a final SELECT 0 if  
--              successful, or @@ERROR number if there's an  error.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[delete_sale]
	@id int
AS
BEGIN
	DECLARE @error int = 0, @now datetime = GETDATE(), @row_count int = 0
	BEGIN TRAN
	BEGIN TRY
		UPDATE sale SET superseded = 1, last_edit_at = @now WHERE id = @id
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			SELECT @error
			RETURN 
		END
	END CATCH
	BEGIN TRY
		UPDATE sale_item SET superseded = 1, last_edit_at = @now WHERE sale_id = @id
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			SELECT @error
			RETURN 
		END
	END CATCH
	COMMIT TRAN
	SELECT 0
	RETURN
END
GO

/****** Object:  StoredProcedure [dbo].[insert_item] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 3 July 2023
-- Description:	Inserts a new item into the item table and its associated
--              pricing information (which is a string of pairs of numbers -
--              quantity_break1,price1,quantity_break2,price2,...,
--              quantity_breakN,priceN) into the price table.  This is all done
--              in a transaction so it all succeeds or fails.  It outputs the
--              item's id in @id if successful, or 0 if unsuccessful.  Note that
--              quantity_returned, amount_paid, and commission are all null
--              (not 0) for a new item.  These are only entered upon
--              settlement with the seller.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[insert_item]
	@seller_id int,
	@short_description nvarchar(40),
	@long_description nvarchar(1000),
	@location_id int,
	@quantity_at_start int,
	@pricing nvarchar(1000), -- way longer than it'd ever practically be
	@id int OUT
AS
BEGIN
	DECLARE @error int = 0, @row_count int = 0, @start int = 1, @next_comma int, @num_price_rows int = 0, 
		@quantity_break int, @price decimal(7,2), @done bit = 0, @now datetime = GETDATE()
	BEGIN TRAN
	BEGIN TRY
		INSERT INTO item (seller_id, short_description, long_description, location_id, quantity_at_start, last_edit_at) 
			VALUES (@seller_id, @short_description, @long_description, @location_id, @quantity_at_start, @now)
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			SELECT @id = 0
			RETURN @error
		END
	END CATCH
	-- Parse @pricing and create a record for each number pair
	SELECT @id = @@IDENTITY
	SELECT @next_comma = CHARINDEX(',', @pricing, @start)
	IF @next_comma < 2 SELECT @done = 1 -- @if the @pricing parameter is malformed (has no commas or starts with one) don't try to create price records
	WHILE @done = 0 BEGIN
		--SELECT @length = @next_comma - @start
		SELECT @quantity_break = CAST(SUBSTRING(@pricing, @start, @next_comma - @start) AS int)
		SELECT @start = @next_comma + 1
		SELECT @next_comma = CHARINDEX(',', @pricing, @start)
		IF @next_comma > 1 BEGIN -- Not at the end yet
			SELECT @price = CAST(SUBSTRING(@pricing, @start, @next_comma - @start) AS decimal(7,2))
			-- Get ready to read the next quantity_break value
			SELECT @start = @next_comma + 1
			SELECT @next_comma = CHARINDEX(',', @pricing, @start)
			IF @next_comma < 1 SELECT @done = 1 -- If there's no comma following the next quantity_break in @pricing stop here
		END
		ELSE BEGIN -- At the end of @pricing, handling the last price value 
			SELECT @price = CAST(SUBSTRING(@pricing, @start, LEN(@pricing) + 1 - @start) AS decimal(7,2)) -- LEN(@pricing) + 1 is where the next comma would be if it existed
			SELECT @done = 1
		END
		BEGIN TRY
			INSERT INTO price (item_id, quantity_break, price, last_edit_at) VALUES (@id, @quantity_break, @price, @now)
		END TRY
		BEGIN CATCH
			SELECT @error = @@ERROR
			IF @error <> 0 BEGIN
				ROLLBACK TRAN
				SELECT @id - 0
				RETURN @error
			END
		END CATCH
		SELECT @num_price_rows = @num_price_rows + 1
	END
	IF @num_price_rows = 0 BEGIN -- If no rows were inserted into the price table, this is not allowed - every item must have at least one price
		ROLLBACK TRAN
		SELECT @id = 0
		RETURN 0 -- There was no error but neither was a new item inserted (assuming ROLLBACK TRAN did what it should)
	END
	COMMIT TRAN
	RETURN 0
END
GO

/****** Object:  StoredProcedure [dbo].[insert_sale] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 3 July 2023
-- Description:	Inserts a new sale into the sale table and its associated
--              sale_items information (which is a string of trios of numbers -
--              item_id1,quantity1,amount1,item_id2,quantity2,amount2,...,
--              item_idN,quantityN,amountN) into the sale_item table.  This is all 
--              done in a transaction so it all succeeds or fails.  It outputs the
--              sale's id in @id if successful, or 0 if unsuccessful.  Note that
--              superseded is false for both tables and superseding_id is null 
--              for the sale table since it's a new sale, not a change to an 
--              existing one.  When_sold is filled in by this SP.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[insert_sale]
	@tendered decimal(7,2),
	@change decimal(7,2),
	@sale_items nvarchar(1000), -- way longer than it'd ever practically be
	@id int OUT
AS
BEGIN
	DECLARE @error int = 0, @row_count int = 0, @start int = 1, @next_comma int, @num_sale_item_rows int = 0, 
		@item_id int, @quantity int, @amount decimal(7,2), @done bit = 0, @now datetime = GETDATE()
	SELECT @now = DATETIMEFROMPARTS (DATEPART(year, @now), 
	                                 DATEPART(month, @now), 
	                                 DATEPART(day, @now), 
	                                 DATEPART(hour, @now), 
	                                 DATEPART(minute, @now),
	                                 0,0) -- Truncate seconds and milliseconds as Change Sale doesn't allow them to be entered
	BEGIN TRAN
	BEGIN TRY
		INSERT INTO sale (tendered, [change], when_sold, superseded, last_edit_at) 
			VALUES (@tendered, @change, @now, 0, @now)
	END TRY
	BEGIN CATCH
		SELECT @error = @@ERROR
		IF @error <> 0 BEGIN
			ROLLBACK TRAN
			SELECT @id = 0
			RETURN @error
		END
	END CATCH
	-- Parse @sale_items and create a record for each number trio
	SELECT @id = @@IDENTITY
	SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
	IF @next_comma < 2 SELECT @done = 1 -- if the @sale_items parameter is malformed (has no commas or starts with one) don't try to create sale_item records
	WHILE @done = 0 BEGIN
		SELECT @item_id = CAST(SUBSTRING(@sale_items, @start, @next_comma - @start) AS int)
		SELECT @start = @next_comma + 1
		SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
		IF @next_comma = 0 BEGIN -- If there's no next comma here,  @sale_items is malformed so quit writing to sale_item
			ROLLBACK TRAN
			SELECT @id = 0
			RETURN 0 -- There was no error but neither was a new sale inserted (assuming ROLLBACK TRAN did what it should)
		END
		SELECT @quantity = CAST(SUBSTRING(@sale_items, @start, @next_comma - @start) AS int)
		SELECT @start = @next_comma + 1
		SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
		IF @next_comma > 1 BEGIN -- Not at the end yet
			SELECT @amount = CAST(SUBSTRING(@sale_items, @start, @next_comma - @start) AS decimal(7,2))
			-- Get ready to read the next item_id value
			SELECT @start = @next_comma + 1
			SELECT @next_comma = CHARINDEX(',', @sale_items, @start)
			IF @next_comma < 1 BEGIN -- If there's no comma following the next item_id in @@sale_items abort
				ROLLBACK TRAN
				SELECT @id = 0
				RETURN 0 -- There was no error but neither was a new sale inserted (assuming ROLLBACK TRAN did what it should)
			END
		END
		ELSE BEGIN -- At the end of @sale_items, handling the amount value 
			SELECT @amount = CAST(SUBSTRING(@sale_items, @start, LEN(@sale_items) + 1 - @start) AS decimal(7,2)) -- LEN(@sale_items) + 1 is where the next comma would be if it existed
			SELECT @done = 1
		END
		BEGIN TRY
			INSERT INTO sale_item (sale_id, item_id, quantity, amount, superseded, last_edit_at) VALUES (@id, @item_id, @quantity, @amount, 0, @now)
			SELECT @num_sale_item_rows = @num_sale_item_rows + 1
		END TRY
		BEGIN CATCH
			SELECT @error = @@ERROR
			IF @error <> 0 BEGIN
				ROLLBACK TRAN
				SELECT @id - 0
				RETURN @error
			END
		END CATCH 
	END
	IF @num_sale_item_rows = 0 BEGIN -- If no rows were inserted into the sale_item table, this is not allowed - every sale must have at least one item
		ROLLBACK TRAN
		SELECT @id = 0
		RETURN 0 -- There was no error but neither was a new sale inserted (assuming ROLLBACK TRAN did what it should)
	END
	COMMIT TRAN
	RETURN 0
END
GO

/****** Object:  StoredProcedure [dbo].[select_actual_sellers_as_strings] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 15 August 2023
-- Description:	Return the id and id, salutation, first_name, middle_name,
--              last_name, and suffix in a single string, sname, for all
--              actual sellers (sellers having an item referencing them)
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[select_actual_sellers_as_strings] 
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT s.id, CAST(s.id AS nvarchar) + ' - ' + 
		IIF(LEN(salutation) > 0, salutation + ' ', '') + --LEN(NULL) is NULL and NULL > 0 is false
		first_name + ' ' +-- first_name is guaranteed not to be null/blank
		IIF(LEN(middle_name) > 0, middle_name + ' ', '') +
		last_name + -- last_name is guaranteed not to be null/blank
		IIF(LEN(suffix) > 0, ' ' + suffix + ' ', '') as sname
		FROM seller s JOIN item i on s.id = i.seller_id
	UNION
	SELECT 0 AS id, '' AS sname
	ORDER BY id
END
GO

/****** Object:  StoredProcedure [dbo].[select_item_price] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 5 July 2023
-- Description:	Given the item_id and quantity proposed for a sale,
--              return the quantity of that item that should remain
--              and the price appropriate for that quantity.  It is
--              up to the caller how to respond if the remaining
--              quantity is less than the quantity proposed for sale.
--              This SP does not try to handle the case of an invalid
--              item_id because the program calling it has already
--              validated the item_id, and won't let this SP be called
--              with an invalid value.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[select_item_price]
	@item_id int, @quantity int
AS 
BEGIN
	DECLARE @qty_left int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT @qty_left = MAX(quantity_at_start) - SUM(COALESCE(si.quantity,0)) -- Need to use COALESCE because there might not yet be any sale_item records for this item
		FROM item i LEFT JOIN sale_item si ON i.id = si.item_id AND (si.superseded = 0 OR si.superseded IS NULL)
		WHERE i.id = @item_id 
	SELECT TOP 1 price, @qty_left AS qty_left FROM price WHERE item_id = @item_id AND quantity_break <= @quantity ORDER BY quantity_break DESC
END
GO

/****** Object:  StoredProcedure [dbo].[select_items] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 15 August 2023
-- Description:	Given optional id, short_description, and seller_id filter 
--              parameters, return the qualifying records from the item table 
--              as distinct fields, including (from the sale_item table) the 
--              number sold, and (from the price table) the pricing as a series
--              of comma-separated quantity break and price values, i.e. 
--              quantity_break1,price1,quantity_break2,price2,...,
--              quantity_breakN,priceN
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[select_items]
	@id int = NULL, @short_description nvarchar(40) = NULL, @seller_id int = NULL
AS 
BEGIN
	DECLARE @result TABLE (id int NOT NULL,
	                       seller_id int NOT NULL,
	                       short_description nvarchar(40)NOT NULL,
	                       long_description nvarchar(1000) NULL,
	                       location_id int NULL,
	                       [description] nvarchar(20) NULL, -- This is the location description since the location_id is meaningless to a user
	                       quantity_at_start int NOT NULL,
	                       num_sold int NOT NULL,
	                       quantity_returned int NULL,
	                       pricing nvarchar(1000))
	DECLARE @item_id int, @pricing nvarchar(1000), @price decimal(7,2), @quantity int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Fill @result with everything but the pricing column
	INSERT INTO @result 
		SELECT i.id AS item_id,
		       i.seller_id,
		       i.short_description,
		       i.long_description,
		       COALESCE(i.location_id, 0),
		       l.[description],
		       quantity_at_start,
		       COALESCE(SUM(quantity),0) AS num_sold,
		       quantity_returned,
		       '' AS pricing  
		FROM item i
			LEFT JOIN sale_item si on i.id = si.item_id AND (superseded = 0 OR superseded IS NULL)
			LEFT JOIN location l on i.location_id = l.id
		WHERE (i.id = @id OR @id IS NULL)
			AND (short_description LIKE '%' + @short_description + '%' OR @short_description IS NULL)
			AND (seller_id = @seller_id OR @seller_id IS NULL)
		GROUP BY i.id,
		         i.seller_id,
		         i.short_description,
		         i.long_description,
		         i.location_id,
		         l.[description],
		         quantity_at_start,
		         quantity_returned
		ORDER BY i.id
	-- Then go through the table and create the pricing string for each item
	DECLARE item_cur CURSOR LOCAL FORWARD_ONLY FOR
		SELECT id, pricing FROM @result FOR UPDATE OF pricing
	OPEN item_cur
	FETCH NEXT FROM item_cur INTO @item_id, @pricing
	WHILE @@FETCH_STATUS = 0 BEGIN
		DECLARE price_cur CURSOR LOCAL FAST_FORWARD FOR
			SELECT quantity_break, price FROM price WHERE item_id = @item_id ORDER BY quantity_break
		OPEN price_cur
		FETCH NEXT FROM price_cur INTO @quantity, @price
		WHILE @@FETCH_STATUS = 0 BEGIN
			SELECT @pricing = @pricing + CAST(@quantity AS nvarchar) + ','+ CAST(@price AS nvarchar) + ',' 
			FETCH NEXT FROM price_cur INTO @quantity, @price
		END
		CLOSE price_cur
		DEALLOCATE price_cur
		-- Remove final comma
		SELECT @pricing = LEFT(@pricing, LEN(@pricing) - 1)
		UPDATE @result SET pricing = @pricing WHERE CURRENT OF item_cur
		FETCH NEXT FROM item_cur INTO @item_id, @pricing
	END
	CLOSE item_cur
	DEALLOCATE item_cur
	SELECT * FROM @result ORDER BY id -- Return the @result table's contents to the caller
END
GO

/****** Object:  StoredProcedure [dbo].[select_sales] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 14 July 2023
-- Description:	Given when_sold, number of items, and total sale amount (min and max for all these)
--              and sale ID optional filter parameters, return the qualifying records from the sale
--              table plus the calculated number of items in the sale and the total sale amount,
--              and the information about each item (item_id, quantity, and amount) as trios of
--              comma-separated numbers.  The item short descriptions are not included since they
--              could contain commas (or any other delimiter character that might alternatively
--              be used instead of a comma).  Instead the descriptions will be gotten from the 
--              item table as required by the calling program.
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[select_sales]
	@when_sold_min datetime = NULL,
	@when_sold_max datetime = NULL,
	@no_items_min int = NULL,
	@no_items_max int = NULL,
	@sale_amount_min decimal = NULL,
	@sale_amount_max decimal = NULL,
	@id int = NULL
AS 
BEGIN
	DECLARE @result TABLE (id int NOT NULL, 
	                       when_sold datetime,
	                       num_items int,
	                       sale_amount decimal(7,2),
	                       tendered decimal(7,2),
	                       items nvarchar(max)) 
	DECLARE @sale_id int, @items nvarchar(max), @item_id int, @quantity int, @amount decimal
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Start by inserting all the fields to be returned except items in a table variable
	WITH no_items_cte (id, num_items)
	AS 
	(
		SELECT sale_id, COUNT(item_id) AS num_items FROM sale_item GROUP BY sale_id
	)
	INSERT INTO @result SELECT s.id, s.when_sold, num_items, (s.tendered - s.[change]) AS sale_amount, s.tendered, '' AS items
		FROM sale s JOIN no_items_cte nic ON s.id = nic.id
		WHERE (s.id = @id or @id IS NULL)
			AND (when_sold >= @when_sold_min OR @when_sold_min IS NULL)
			AND (when_sold <= @when_sold_max OR @when_sold_max IS NULL)
			AND (num_items >= @no_items_min OR @no_items_min IS NULL)
			AND (num_items <= @no_items_max OR @no_items_max IS NULL)
			AND ((s.tendered - s.[change]) >= @sale_amount_min OR @sale_amount_min IS NULL)
			AND ((s.tendered - s.[change]) <= @sale_amount_max OR @sale_amount_max IS NULL)
			AND s.superseded = 0 -- Exclude superseded sales
		ORDER BY s.id
	-- Then go through the table and create the items string for each sale
	DECLARE sale_cur CURSOR LOCAL FORWARD_ONLY FOR
		SELECT id, items FROM @result FOR UPDATE OF items
	OPEN sale_cur
	FETCH NEXT FROM sale_cur INTO @sale_id, @items
	WHILE @@FETCH_STATUS = 0 BEGIN

		DECLARE sale_item_cur CURSOR LOCAL FAST_FORWARD FOR
			SELECT item_id, quantity, amount FROM sale_item WHERE sale_id = @sale_id AND superseded = 0 ORDER BY id
		OPEN sale_item_cur
		FETCH NEXT FROM sale_item_cur INTO @item_id, @quantity, @amount
		WHILE @@FETCH_STATUS = 0 BEGIN
			SELECT @items = @items + CAST(@item_id AS nvarchar) + ',' + CAST(@quantity AS nvarchar) + ',' + CAST(@amount AS nvarchar) + ','
			FETCH NEXT FROM sale_item_cur INTO @item_id, @quantity, @amount
		END
		CLOSE sale_item_cur
		DEALLOCATE sale_item_cur
		-- Remove final comma
		SELECT @items = LEFT(@items, LEN(@items) - 1)
		UPDATE @result SET items = @items WHERE CURRENT OF sale_cur
		FETCH NEXT FROM sale_cur INTO @sale_id, @items
	END
	CLOSE sale_cur
	DEALLOCATE sale_cur
	SELECT * FROM @result -- Return the @result table's contents to the caller
END
GO

/****** Object:  StoredProcedure [dbo].[select_sellers_as_strings] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 1 July 2023
-- Description:	Given optional id, first_nname, and last_name filter parameters,
--              return the qualifying records from the seller table, id and
--              id, salutation, first_name, middle_name, last_name, and suffix in a
--              single string, sname (which will be used to choose a particular seller)
-- =============================================
CREATE OR ALTER PROCEDURE select_sellers_as_strings 

	@id int = NULL, @first_name nvarchar(50) = NULL, @last_name nvarchar(50) = NULL
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	SELECT id, CAST(id AS nvarchar) + ' - ' + 
		IIF(LEN(salutation) > 0, salutation + ' ', '') + --LEN(NULL) is NULL and NULL > 0 is false
		-- trims below added in case row delimiter when importing is {LF} instead of {CR}{LF} as it should be,
		-- and thus the first name (or the last name, whichever ends the row) has a carriage return appended to it
		TRIM(char(13) FROM first_name) + ' ' + -- first_name is guaranteed not to be null/blank
		IIF(LEN(middle_name) > 0, middle_name + ' ', '') +
		TRIM(char(13) FROM last_name) + ' ' + -- last_name is guaranteed not to be null/blank
		IIF(LEN(suffix) > 0, ' ' + suffix + ' ', '') AS sname
		FROM seller
		WHERE (id = @id OR @id IS NULL)
			AND (first_name LIKE @first_name + '%' OR @first_name IS NULL)
			AND (last_name LIKE @last_name + '%' OR @last_name IS NULL)
END
GO

/****** Object:  StoredProcedure [dbo].[select_sellers] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 1 July 2023
-- Description:	Given optional id, first_nname, and last_name filter parameters,
--              and a logical field specifying whether to exclude potential sellers,
--              return the qualifying records from the seller table as distinct fields
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[select_sellers]
	@id int = NULL, @first_name nvarchar(50) = NULL, @last_name nvarchar(50) = NULL, @actual_sellers bit = 0
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF @actual_sellers = 0
		SELECT salutation, first_name, middle_name, last_name, suffix, address_1, address_2, post_office, [state], postal_code, country, phone_1, phone_2, email, member_id, id
			FROM seller
			WHERE (id = @id or @id IS NULL)
				AND (first_name LIKE @first_name + '%' OR @first_name IS NULL)
				AND (last_name LIKE @last_name + '%' OR @last_name IS NULL)
	ELSE
		WITH distinct_seller_ids AS (SELECT DISTINCT seller_id FROM item)
		SELECT salutation, first_name, middle_name, last_name, suffix, address_1, address_2, post_office, [state], postal_code, country, phone_1, phone_2, email, member_id, id
			FROM seller JOIN distinct_seller_ids on id = seller_id
			WHERE (id = @id or @id IS NULL)
				AND (first_name LIKE @first_name + '%' OR @first_name IS NULL)
				AND (last_name LIKE @last_name + '%' OR @last_name IS NULL)
END
GO

/****** Object:  StoredProcedure [dbo].[select_unsettled_items] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 7 August 2023
-- Description:	Given the ID of a seller, find all the items for which have a
--              null value in the quantity_returned column. These
--              are the items which yet require settlement.  The returned
--              fields are the item_id, short_description, (location)
--              description, quantity_at_start, (total) num_sold (sum of
--              sale_item.quantity), (total) sales_amount (sum of sale_item.
--              amount), and a pricing field consisting of comma-separated
--              pairs of comma-separated price and quantity values.  These are
--              from the sale_item table, not the price table, meaning they are
--              actual values representing the pricing that was in effect at 
--              the time of the sale, unless there were no sales.  If so the 
--              highest price entry in the price table for that item is used
--              to get the unit price.  Otherwise the price is amount divided 
--              by quantity.   They are aggregated by price, and the quantity 
--              portion is the sum of the quantity fields for a given price.  
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[select_unsettled_items]
	@id int 
AS 
BEGIN
	DECLARE @result TABLE (item_id int NOT NULL,
	                       short_description nvarchar(40),
	                       [description] nvarchar(20),
	                       quantity_at_start int,
	                       num_sold int,
	                       sales_amount decimal(7,2),
	                       pricing nvarchar(1000))
	DECLARE @item_id int, @pricing nvarchar(1000), @price decimal(7,2), @num_sold int, @num_sold_at_price int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- Fill @result with everything but the pricing column
	INSERT INTO @result 
		SELECT i.id AS item_id,
		       i.short_description,
		       l.[description],
		       quantity_at_start,
		       COALESCE(SUM(quantity),0) AS num_sold,
		       COALESCE(SUM(amount),0) AS sales_amount,
		       '' AS pricing  
		FROM item i
			JOIN seller s ON i.seller_id = s.id
			LEFT JOIN sale_item si on i.id = si.item_id
			LEFT JOIN location l on i.location_id = l.id
		WHERE (superseded = 0 OR superseded IS NULL)
			AND seller_id = @id
			AND quantity_returned IS NULL
		GROUP BY i.id,
		         i.short_description,
		         l.[description],
		         quantity_at_start
		ORDER BY i.id
	-- Then go through the table and create the pricing string for each item
	DECLARE item_cur CURSOR LOCAL FORWARD_ONLY FOR
		SELECT item_id, num_sold, pricing FROM @result FOR UPDATE OF pricing
	OPEN item_cur
	FETCH NEXT FROM item_cur INTO @item_id, @num_sold, @pricing
	WHILE @@FETCH_STATUS = 0 BEGIN
		IF @num_sold = 0 BEGIN
			SELECT TOP 1 @price = price FROM price WHERE item_id = @item_id ORDER BY quantity_break
			SELECT @pricing = CAST(@price AS nvarchar) + ',0'
		END
		ELSE BEGIN
			DECLARE price_cur CURSOR LOCAL FAST_FORWARD FOR
				SELECT amount/quantity AS price, SUM(quantity) AS num_sold_at_price 
					FROM sale_item si JOIN item i on si.item_id = i.id
					WHERE superseded = 0 AND item_id = @item_id
					GROUP BY amount/quantity
					ORDER BY amount/quantity DESC
			OPEN price_cur
			FETCH NEXT FROM price_cur INTO @price, @num_sold_at_price
			WHILE @@FETCH_STATUS = 0 BEGIN
				SELECT @pricing = @pricing + CAST(@price AS nvarchar) + ',' + CAST(@num_sold_at_price AS nvarchar) + ','
				FETCH NEXT FROM price_cur INTO @price, @num_sold_at_price
			END
			CLOSE price_cur
			DEALLOCATE price_cur
			-- Remove final comma
			SELECT @pricing = LEFT(@pricing, LEN(@pricing) - 1)
		END
		UPDATE @result SET pricing = @pricing WHERE CURRENT OF item_cur
		FETCH NEXT FROM item_cur INTO @item_id, @num_sold, @pricing
	END
	CLOSE item_cur
	DEALLOCATE item_cur
	SELECT * FROM @result -- Return the @result table's contents to the caller
END
GO

/****** Object:  StoredProcedure [dbo].[select_unsettled_sellers] ******/

-- =============================================
-- Author:      Keith Frantz
-- Create date: 5 August 2023
-- Description:	Given optional id, first_name, and last_name filter parameters,
--              return the qualifying records from the seller table for which
--              there are items for which quantity_returned is null
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[select_unsettled_sellers]
	@id int = NULL, @first_name nvarchar(50) = NULL, @last_name nvarchar(50) = NULL
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT DISTINCT s.id, salutation, TRIM(char(13) FROM first_name) AS first_name, middle_name, TRIM(char(13) FROM last_name) AS last_name, suffix
		FROM seller s join item i on s.id = i.seller_id -- inner join prevents returning potential sellers
		WHERE (s.id = @id OR @id IS NULL)
			AND (first_name LIKE @first_name + '%' OR @first_name IS NULL)
			AND (last_name LIKE @last_name + '%' OR @last_name IS NULL)
			AND quantity_returned IS NULL
		ORDER BY s.id
END
GO
