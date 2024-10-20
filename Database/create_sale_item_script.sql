USE [CoStore]
GO

/****** Object:  Table [dbo].[sale_item]    Script Date: 4/16/2023 9:27:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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

