/****** Object:  Table [dbo].[eshopVyrobok] ******/
CREATE TABLE [dbo].[eshopVyrobok](
	[pk] [uniqueidentifier] NOT NULL,
    [kodVyrobku] [nvarchar](255) NULL,
	[nazovVyrobku] [nvarchar](255) NULL,
	[cenaVyrobku] [decimal](18, 2) NOT NULL,
	[popisVyrobku] [ntext] NULL,
	
 COeshopTRAINT [PK_eshopVyrobok] PRIMARY KEY CLUSTERED 
(
	[pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eshopVyrobca] ******/
CREATE TABLE [dbo].[eshopVyrobca](
	[pk] [uniqueidentifier] NOT NULL,
	[nazovVyrobcu] [nvarchar](255) NULL,
	
 COeshopTRAINT [PK_eshopVyrobca] PRIMARY KEY CLUSTERED 
(
	[pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[eshopQuote] ******/
CREATE TABLE [dbo].[eshopQuote](
	[pk] [uniqueidentifier] NOT NULL,
	[dateCreate] [datetime] NOT NULL,
	[dateFinished] [datetime] NULL,
	[sessionId] [nvarchar](255) NULL,
	[finishedSessionId] [nvarchar](255) NULL,
	[quoteYear] [int] NULL,
	[quoteNumber] [int] NULL,
	[quotePriceNoVat] [decimal](18, 2) NOT NULL,
	[quotePriceWithVat] [decimal](18, 2) NOT NULL,
	[quoteState] [nvarchar](255),
	[quotePriceState] [nvarchar](255),
	[note] [ntext] NULL,
 CONSTRAINT [PK_eshopQuote] PRIMARY KEY CLUSTERED 
(
	[pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[eshopProduct2Quote] ******/
CREATE TABLE [dbo].[eshopProduct2Quote](
	[pk] [uniqueidentifier] NOT NULL,
	[pkQuote] [uniqueidentifier] NOT NULL,
	[pkProduct] [uniqueidentifier] NOT NULL,
	[nonProductId] [nvarchar](255) NULL,
	[itemOrder] [int] NOT NULL,
	[itemPcs] [decimal](18, 3) NOT NULL,
	[unitWeight] [decimal](18, 2) NOT NULL,
	[unitPriceNoVat] [decimal](18, 2) NOT NULL,
	[unitPriceWithVat] [decimal](18, 2) NOT NULL,
	[vatPerc] [decimal](18, 2) NOT NULL,
	[itemCode] [nvarchar](50) NOT NULL,
	[itemName] [nvarchar](255) NOT NULL,
	[unitName] [nvarchar](50) NULL,
	[unitTypeId] [int] NOT NULL,
 CONSTRAINT [PK_eshopProduct2Quote] PRIMARY KEY CLUSTERED 
(
	[pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[eshopProduct2Quote]  WITH CHECK ADD  CONSTRAINT [FK_eshopProduct2Quote_eshopQuote] FOREIGN KEY([pkQuote])
REFERENCES [dbo].[eshopQuote] ([pk]) ON DELETE CASCADE
GO
