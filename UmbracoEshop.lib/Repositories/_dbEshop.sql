
/****** Object:  Table [dbo].[eshopVyrobok] ******/
CREATE TABLE [dbo].[eshopVyrobok](
	[pk] [uniqueidentifier] NOT NULL,
    [kodVyrobku] [nvarchar](255) NULL,
	[nazovVyrobku] [nvarchar](255) NULL,
	[cenaVyrobku] [decimal](18, 2) NOT NULL,
	[popisVyrobku] [ntext] NULL,
	
 CONSTRAINT [PK_eshopVyrobok] PRIMARY KEY CLUSTERED 
(
	[pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eshopVyrobca] ******/
CREATE TABLE [dbo].[eshopVyrobca](
	[pk] [uniqueidentifier] NOT NULL,
	[nazovVyrobcu] [nvarchar](255) NULL,
	
 CONSTRAINT [PK_eshopVyrobca] PRIMARY KEY CLUSTERED 
(
	[pk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
