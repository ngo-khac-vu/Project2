USE [ShopDB]
GO
SET IDENTITY_INSERT [dbo].[Discount] ON 

INSERT [dbo].[Discount] ([DiscountId], [DiscountPercent], [StartDate], [EndDate]) VALUES (1, 0.05, CAST(N'2021-05-01T00:00:00.000' AS DateTime), CAST(N'2021-05-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Discount] ([DiscountId], [DiscountPercent], [StartDate], [EndDate]) VALUES (2, 0.03, CAST(N'2021-04-01T00:00:00.000' AS DateTime), CAST(N'2021-06-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Discount] ([DiscountId], [DiscountPercent], [StartDate], [EndDate]) VALUES (3, 0.1, CAST(N'2021-01-01T00:00:00.000' AS DateTime), CAST(N'2021-01-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Discount] ([DiscountId], [DiscountPercent], [StartDate], [EndDate]) VALUES (4, 0.15, CAST(N'2021-06-06T00:00:00.000' AS DateTime), CAST(N'2021-06-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Discount] ([DiscountId], [DiscountPercent], [StartDate], [EndDate]) VALUES (5, 0.12, CAST(N'2021-09-01T00:00:00.000' AS DateTime), CAST(N'2021-09-30T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Discount] OFF
SET IDENTITY_INSERT [dbo].[Article] ON 

INSERT [dbo].[Article] ([ArticleId], [Name], [Slogan], [NetPrice], [SalePrice], [VAT_ratio]) VALUES (1, N'Coffe                                             ', N'Trung Nguyen                                      ', 100.0000, 140.0000, 0.1)
INSERT [dbo].[Article] ([ArticleId], [Name], [Slogan], [NetPrice], [SalePrice], [VAT_ratio]) VALUES (2, N'Tea                                               ', N'Tra xanh                                          ', 40.0000, 60.0000, 0.15)
INSERT [dbo].[Article] ([ArticleId], [Name], [Slogan], [NetPrice], [SalePrice], [VAT_ratio]) VALUES (3, N'Sugar                                             ', N'Duong                                             ', 20.0000, 25.0000, 0.05)
INSERT [dbo].[Article] ([ArticleId], [Name], [Slogan], [NetPrice], [SalePrice], [VAT_ratio]) VALUES (4, N'Salt                                              ', N'                                                  ', 25.0000, 35.0000, 0.08)
INSERT [dbo].[Article] ([ArticleId], [Name], [Slogan], [NetPrice], [SalePrice], [VAT_ratio]) VALUES (5, N'Coke                                              ', N'Coca cola                                         ', 30.0000, 25.0000, 0.01)
SET IDENTITY_INSERT [dbo].[Article] OFF
SET IDENTITY_INSERT [dbo].[ArticleDiscount] ON 

INSERT [dbo].[ArticleDiscount] ([Id], [ArticleId], [DiscountId]) VALUES (1, 1, 1)
INSERT [dbo].[ArticleDiscount] ([Id], [ArticleId], [DiscountId]) VALUES (2, 2, 2)
INSERT [dbo].[ArticleDiscount] ([Id], [ArticleId], [DiscountId]) VALUES (3, 3, 2)
INSERT [dbo].[ArticleDiscount] ([Id], [ArticleId], [DiscountId]) VALUES (4, 4, 2)
INSERT [dbo].[ArticleDiscount] ([Id], [ArticleId], [DiscountId]) VALUES (5, 1, 3)
INSERT [dbo].[ArticleDiscount] ([Id], [ArticleId], [DiscountId]) VALUES (6, 3, 3)
INSERT [dbo].[ArticleDiscount] ([Id], [ArticleId], [DiscountId]) VALUES (7, 2, 4)
INSERT [dbo].[ArticleDiscount] ([Id], [ArticleId], [DiscountId]) VALUES (8, 4, 4)
INSERT [dbo].[ArticleDiscount] ([Id], [ArticleId], [DiscountId]) VALUES (9, 1, 5)
INSERT [dbo].[ArticleDiscount] ([Id], [ArticleId], [DiscountId]) VALUES (10, 2, 5)
INSERT [dbo].[ArticleDiscount] ([Id], [ArticleId], [DiscountId]) VALUES (11, 3, 5)
INSERT [dbo].[ArticleDiscount] ([Id], [ArticleId], [DiscountId]) VALUES (12, 4, 5)
SET IDENTITY_INSERT [dbo].[ArticleDiscount] OFF
