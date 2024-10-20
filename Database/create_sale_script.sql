USE [CoStore]
GO

/****** Object:  Table [dbo].[sale]    Script Date: 4/16/2023 9:27:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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

