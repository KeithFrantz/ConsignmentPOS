USE [CoStore]
GO

/****** Object:  Table [dbo].[item]    Script Date: 2/1/2023 9:33:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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

