USE [CoStore]
GO

/****** Object:  Table [dbo].[cash]    Script Date: 8/13/2023 8:34:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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

