USE [TinyURL]
GO
/****** Object:  Table [dbo].[tbl_LogMessage]    Script Date: 11/7/2016 8:15:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_LogMessage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Application] [varchar](20) NULL,
	[Summary] [varchar](500) NULL,
	[Exception] [varchar](max) NULL,
	[IP] [varchar](20) NULL,
	[CreationDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_LogMessage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_URLMapping]    Script Date: 11/7/2016 8:15:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_URLMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [varchar](500) NULL,
	[TinyUrl] [varchar](20) NULL,
 CONSTRAINT [PK_tbl_URLMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
