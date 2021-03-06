USE [ShopDB]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 5/29/2021 6:18:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[ArticleId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Slogan] [nchar](50) NULL,
	[NetPrice] [money] NOT NULL,
	[SalePrice] [money] NOT NULL,
	[VAT_ratio] [float] NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ArticleDiscount]    Script Date: 5/29/2021 6:18:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleDiscount](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ArticleId] [bigint] NOT NULL,
	[DiscountId] [bigint] NOT NULL,
 CONSTRAINT [PK_ArticleDiscount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Discount]    Script Date: 5/29/2021 6:18:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[DiscountId] [bigint] IDENTITY(1,1) NOT NULL,
	[DiscountPercent] [float] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[DiscountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ArticleDiscount]  WITH CHECK ADD  CONSTRAINT [FK_ArticleDiscount_Article] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Article] ([ArticleId])
GO
ALTER TABLE [dbo].[ArticleDiscount] CHECK CONSTRAINT [FK_ArticleDiscount_Article]
GO
ALTER TABLE [dbo].[ArticleDiscount]  WITH CHECK ADD  CONSTRAINT [FK_ArticleDiscount_Discount] FOREIGN KEY([DiscountId])
REFERENCES [dbo].[Discount] ([DiscountId])
GO
ALTER TABLE [dbo].[ArticleDiscount] CHECK CONSTRAINT [FK_ArticleDiscount_Discount]
GO
