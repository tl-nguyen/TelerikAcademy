USE [Dictionary]
GO
/****** Object:  Table [dbo].[Antonym_BG]    Script Date: 8/21/2014 6:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Antonym_BG](
	[origin_id] [int] NOT NULL,
	[antonym_id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Antonym_EN]    Script Date: 8/21/2014 6:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Antonym_EN](
	[origin_id] [int] NOT NULL,
	[antonym_id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Antonym_ES]    Script Date: 8/21/2014 6:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Antonym_ES](
	[origin_id] [int] NOT NULL,
	[antonym_id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonym]    Script Date: 8/21/2014 6:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonym](
	[origin_id] [int] NOT NULL,
	[synonym_id] [nchar](10) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonym_BG]    Script Date: 8/21/2014 6:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonym_BG](
	[origin_id] [int] NOT NULL,
	[synonym_id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonym_EN]    Script Date: 8/21/2014 6:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonym_EN](
	[origin_id] [int] NOT NULL,
	[synonym_id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonym_ES]    Script Date: 8/21/2014 6:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonym_ES](
	[origin_id] [int] NOT NULL,
	[synonym_id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Word_BG]    Script Date: 8/21/2014 6:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Word_BG](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[explanations] [nchar](50) NULL,
	[word] [nchar](50) NULL,
 CONSTRAINT [PK_Word_BG] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Word_EN]    Script Date: 8/21/2014 6:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Word_EN](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[explanations] [nchar](50) NULL,
	[word] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Word_EN] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Word_ES]    Script Date: 8/21/2014 6:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Word_ES](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[explanations] [nchar](50) NULL,
	[word] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Word_ES] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordAll]    Script Date: 8/21/2014 6:46:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordAll](
	[en_id] [int] NOT NULL,
	[bg_id] [int] NOT NULL,
	[es_id] [int] NOT NULL,
 CONSTRAINT [PK_WordAll] PRIMARY KEY CLUSTERED 
(
	[en_id] ASC,
	[bg_id] ASC,
	[es_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Antonym_BG]  WITH CHECK ADD  CONSTRAINT [FK_Antonym_BG_Word_BG] FOREIGN KEY([origin_id])
REFERENCES [dbo].[Word_BG] ([id])
GO
ALTER TABLE [dbo].[Antonym_BG] CHECK CONSTRAINT [FK_Antonym_BG_Word_BG]
GO
ALTER TABLE [dbo].[Antonym_BG]  WITH CHECK ADD  CONSTRAINT [FK_Antonym_BG_Word_BG1] FOREIGN KEY([antonym_id])
REFERENCES [dbo].[Word_BG] ([id])
GO
ALTER TABLE [dbo].[Antonym_BG] CHECK CONSTRAINT [FK_Antonym_BG_Word_BG1]
GO
ALTER TABLE [dbo].[Antonym_EN]  WITH CHECK ADD  CONSTRAINT [FK_Antonym_EN_Word_EN] FOREIGN KEY([origin_id])
REFERENCES [dbo].[Word_EN] ([id])
GO
ALTER TABLE [dbo].[Antonym_EN] CHECK CONSTRAINT [FK_Antonym_EN_Word_EN]
GO
ALTER TABLE [dbo].[Antonym_EN]  WITH CHECK ADD  CONSTRAINT [FK_Antonym_EN_Word_EN1] FOREIGN KEY([antonym_id])
REFERENCES [dbo].[Word_EN] ([id])
GO
ALTER TABLE [dbo].[Antonym_EN] CHECK CONSTRAINT [FK_Antonym_EN_Word_EN1]
GO
ALTER TABLE [dbo].[Antonym_ES]  WITH CHECK ADD  CONSTRAINT [FK_Antonym_ES_Word_ES] FOREIGN KEY([origin_id])
REFERENCES [dbo].[Word_ES] ([id])
GO
ALTER TABLE [dbo].[Antonym_ES] CHECK CONSTRAINT [FK_Antonym_ES_Word_ES]
GO
ALTER TABLE [dbo].[Antonym_ES]  WITH CHECK ADD  CONSTRAINT [FK_Antonym_ES_Word_ES1] FOREIGN KEY([antonym_id])
REFERENCES [dbo].[Word_ES] ([id])
GO
ALTER TABLE [dbo].[Antonym_ES] CHECK CONSTRAINT [FK_Antonym_ES_Word_ES1]
GO
ALTER TABLE [dbo].[Synonym_BG]  WITH CHECK ADD  CONSTRAINT [FK_Synonym_BG_Word_BG] FOREIGN KEY([origin_id])
REFERENCES [dbo].[Word_BG] ([id])
GO
ALTER TABLE [dbo].[Synonym_BG] CHECK CONSTRAINT [FK_Synonym_BG_Word_BG]
GO
ALTER TABLE [dbo].[Synonym_BG]  WITH CHECK ADD  CONSTRAINT [FK_Synonym_BG_Word_BG1] FOREIGN KEY([synonym_id])
REFERENCES [dbo].[Word_BG] ([id])
GO
ALTER TABLE [dbo].[Synonym_BG] CHECK CONSTRAINT [FK_Synonym_BG_Word_BG1]
GO
ALTER TABLE [dbo].[Synonym_EN]  WITH CHECK ADD  CONSTRAINT [FK_Synonym_EN_Word_EN] FOREIGN KEY([origin_id])
REFERENCES [dbo].[Word_EN] ([id])
GO
ALTER TABLE [dbo].[Synonym_EN] CHECK CONSTRAINT [FK_Synonym_EN_Word_EN]
GO
ALTER TABLE [dbo].[Synonym_EN]  WITH CHECK ADD  CONSTRAINT [FK_Synonym_EN_Word_EN1] FOREIGN KEY([synonym_id])
REFERENCES [dbo].[Word_EN] ([id])
GO
ALTER TABLE [dbo].[Synonym_EN] CHECK CONSTRAINT [FK_Synonym_EN_Word_EN1]
GO
ALTER TABLE [dbo].[Synonym_ES]  WITH CHECK ADD  CONSTRAINT [FK_Synonym_ES_Word_ES] FOREIGN KEY([origin_id])
REFERENCES [dbo].[Word_ES] ([id])
GO
ALTER TABLE [dbo].[Synonym_ES] CHECK CONSTRAINT [FK_Synonym_ES_Word_ES]
GO
ALTER TABLE [dbo].[Synonym_ES]  WITH CHECK ADD  CONSTRAINT [FK_Synonym_ES_Word_ES1] FOREIGN KEY([synonym_id])
REFERENCES [dbo].[Word_ES] ([id])
GO
ALTER TABLE [dbo].[Synonym_ES] CHECK CONSTRAINT [FK_Synonym_ES_Word_ES1]
GO
ALTER TABLE [dbo].[WordAll]  WITH CHECK ADD  CONSTRAINT [FK_WordAll_Word_BG] FOREIGN KEY([bg_id])
REFERENCES [dbo].[Word_BG] ([id])
GO
ALTER TABLE [dbo].[WordAll] CHECK CONSTRAINT [FK_WordAll_Word_BG]
GO
ALTER TABLE [dbo].[WordAll]  WITH CHECK ADD  CONSTRAINT [FK_WordAll_Word_EN] FOREIGN KEY([en_id])
REFERENCES [dbo].[Word_EN] ([id])
GO
ALTER TABLE [dbo].[WordAll] CHECK CONSTRAINT [FK_WordAll_Word_EN]
GO
ALTER TABLE [dbo].[WordAll]  WITH CHECK ADD  CONSTRAINT [FK_WordAll_Word_ES] FOREIGN KEY([es_id])
REFERENCES [dbo].[Word_ES] ([id])
GO
ALTER TABLE [dbo].[WordAll] CHECK CONSTRAINT [FK_WordAll_Word_ES]
GO
