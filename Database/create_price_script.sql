USE [CoStore]
GO

/****** Object:  Table [dbo].[price]    Script Date: 2/1/2023 9:43:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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

