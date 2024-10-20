USE [CoStore]
GO

/****** Object:  Table [dbo].[seller]    Script Date: 2/1/2023 4:03:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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

