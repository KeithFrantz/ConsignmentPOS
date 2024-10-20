USE [CoStore]
GO

/****** Object:  Table [dbo].[item_import]    Script Date: 7/20/2023 11:58:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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


