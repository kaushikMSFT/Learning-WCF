USE [master]
GO
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Photos')
BEGIN
CREATE DATABASE [Photos] ON  PRIMARY 
( NAME = N'Photos_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\data\Photos_Data.MDF' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Photos_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\data\Photos_Log.LDF' , SIZE = 3072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END

GO
EXEC dbo.sp_dbcmptlevel @dbname=N'Photos', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Photos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Photos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Photos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Photos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Photos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Photos] SET ARITHABORT OFF 
GO
ALTER DATABASE [Photos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Photos] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Photos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Photos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Photos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Photos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Photos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Photos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Photos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Photos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Photos] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Photos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Photos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Photos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Photos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Photos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Photos] SET  READ_WRITE 
GO
ALTER DATABASE [Photos] SET RECOVERY FULL 
GO
ALTER DATABASE [Photos] SET  MULTI_USER 
GO
ALTER DATABASE [Photos] SET PAGE_VERIFY TORN_PAGE_DETECTION  
GO
ALTER DATABASE [Photos] SET DB_CHAINING OFF 
USE [Photos]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procLinkItemsDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/****** Object:  Stored Procedure dbo.procLinkItemsDelete    Script Date: 8/23/2005 1:11:44 AM ******/
CREATE PROCEDURE [dbo].[procLinkItemsDelete]
	(@id 	[int])

AS DELETE [Photos].[dbo].[LinkItems] 

WHERE 
	( [id]	 = @id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procLinkItemsInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/****** Object:  Stored Procedure dbo.procLinkItemsInsert    Script Date: 8/23/2005 1:11:44 AM ******/
CREATE PROCEDURE [dbo].[procLinkItemsInsert]
	(@id			[int] OUTPUT,
	 @title 		[nvarchar](50),
	 @description 	[nvarchar](200),
	 @url 			[nvarchar](2048),
	 @linkitem_date [datetime],
	 @linkitem_dateend 	[datetime],
	 @linkitem_type [int],
	 @date_created 	[datetime],
	 @date_modified [datetime])

AS INSERT INTO [Photos].[dbo].[LinkItems] 
	 ([title],
	 [description],
	 [url],
	 [linkitem_date],
	 [linkitem_dateend],
	 [linkitem_type],
	 [date_created],
	 [date_modified]) 
 
VALUES 
	( @title,
	 @description,
	 @url,
	 @linkitem_date,
	 @linkitem_dateend,
	 @linkitem_type,
	 @date_created,
	 @date_modified)

SET @id = @@IDENTITY
' 
END
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procLinkItemsSelect]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/****** Object:  Stored Procedure dbo.procLinkItemsSelect    Script Date: 8/23/2005 1:11:44 AM ******/
CREATE PROCEDURE [dbo].[procLinkItemsSelect]
AS SELECT * FROM [Photos].[dbo].[LinkItems]
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procLinkItemsUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/****** Object:  Stored Procedure dbo.procLinkItemsUpdate    Script Date: 8/23/2005 1:11:44 AM ******/
CREATE PROCEDURE [dbo].[procLinkItemsUpdate]
	(@id	[int] OUTPUT,
	 @title 	[nvarchar](50),
	 @description 	[nvarchar](200),
	 @url 	[nvarchar](2048),
	 @linkitem_date 	[datetime],
	 @linkitem_dateend 	[datetime],
	 @linkitem_type 	[int],
	 @date_created 	[datetime],
	 @date_modified 	[datetime])

AS UPDATE [Photos].[dbo].[LinkItems] 

SET  
	 [title]	 = @title,
	 [description]	 = @description,
	 [url]	 = @url,
	 [linkitem_date]	 = @linkitem_date,
	 [linkitem_dateend]	 = @linkitem_dateend,
	 [linkitem_type]	 = @linkitem_type,
	 [date_created]	 = @date_created,
	 [date_modified]	 = @date_modified 

WHERE 
	( [id]	 = @id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LinkItems]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LinkItems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[description] [nvarchar](200) NULL,
	[url] [nvarchar](2048) NOT NULL,
	[linkitem_date] [datetime] NOT NULL,
	[linkitem_dateend] [datetime] NULL,
	[linkitem_type] [int] NOT NULL,
	[date_created] [datetime] NOT NULL,
	[date_modified] [datetime] NOT NULL,
 CONSTRAINT [PK_LinkItems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[description] [nvarchar](200) NULL,
	[date_created] [datetime] NOT NULL,
	[date_modified] [datetime] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Categories] UNIQUE NONCLUSTERED 
(
	[title] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LinkItemTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LinkItemTypes](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](200) NULL,
 CONSTRAINT [PK_LinkItemTypes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LinkItem_Category]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LinkItem_Category](
	[linkitem_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
 CONSTRAINT [PK_LinkItem_Category] PRIMARY KEY CLUSTERED 
(
	[linkitem_id] ASC,
	[category_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_FileItem_Category] UNIQUE NONCLUSTERED 
(
	[linkitem_id] ASC,
	[category_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procLinkItem_CategoryDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/****** Object:  Stored Procedure dbo.procLinkItem_CategoryDelete    Script Date: 8/23/2005 1:11:44 AM ******/
CREATE PROCEDURE [dbo].[procLinkItem_CategoryDelete]
	(@linkitem_id 	[int],
	 @category_id 	[int])

AS DELETE [Photos].[dbo].[LinkItem_Category] 

WHERE 
	( [linkitem_id]	 = @linkitem_id AND
	 [category_id]	 = @category_id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procLinkItem_CategoryInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/****** Object:  Stored Procedure dbo.procLinkItem_CategoryInsert    Script Date: 8/23/2005 1:11:44 AM ******/
CREATE PROCEDURE [dbo].[procLinkItem_CategoryInsert]
	(@linkitem_id 	[int],
	 @category_id 	[int])

AS INSERT INTO [Photos].[dbo].[LinkItem_Category] 
	 ( [linkitem_id],
	 [category_id]) 
 
VALUES 
	( @linkitem_id,
	 @category_id)
' 
END
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procLinkItem_CategorySelect]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/****** Object:  Stored Procedure dbo.procLinkItem_CategorySelect    Script Date: 8/23/2005 1:11:44 AM ******/
CREATE PROCEDURE [dbo].[procLinkItem_CategorySelect]
AS SELECT * FROM [Photos].[dbo].[LinkItem_Category]
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procCategoriesDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/****** Object:  Stored Procedure dbo.procCategoriesDelete    Script Date: 8/23/2005 1:11:44 AM ******/
CREATE PROCEDURE [dbo].[procCategoriesDelete]
	(@id 	[int])

AS DELETE [Photos].[dbo].[Categories] 

WHERE 
	( [id]	 = @id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procCategoriesInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/****** Object:  Stored Procedure dbo.procCategoriesInsert    Script Date: 8/23/2005 1:11:44 AM ******/
CREATE PROCEDURE [dbo].[procCategoriesInsert]
	(@id 	[int] OUTPUT,
	 @title 	[nvarchar](50),
	 @description 	[nvarchar](200),
	 @date_created 	[datetime],
	 @date_modified 	[datetime])

AS INSERT INTO [Photos].[dbo].[Categories] 
	 ( 
	 [title],
	 [description],
	 [date_created],
	 [date_modified]) 
 
VALUES 
	( 
	 @title,
	 @description,
	 @date_created,
	 @date_modified)

SET @id=@@IDENTITY
' 
END
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procCategoriesSelect]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/****** Object:  Stored Procedure dbo.procCategoriesSelect    Script Date: 8/23/2005 1:11:44 AM ******/
CREATE PROCEDURE [dbo].[procCategoriesSelect]
AS SELECT * FROM [Photos].[dbo].[Categories]
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procCategoriesUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/****** Object:  Stored Procedure dbo.procCategoriesUpdate    Script Date: 8/23/2005 1:11:44 AM ******/
CREATE PROCEDURE [dbo].[procCategoriesUpdate]
	(@id 	[int],
	 @title 	[nvarchar](50),
	 @description 	[nvarchar](200),
	 @date_created 	[datetime],
	 @date_modified 	[datetime])

AS UPDATE [Photos].[dbo].[Categories] 

SET  
	 [title]	 = @title,
	 [description]	 = @description,
	 [date_created]	 = @date_created,
	 [date_modified]	 = @date_modified 

WHERE 
	( [id]	 = @id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procLinkItemTypesInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/****** Object:  Stored Procedure dbo.procLinkItemTypesInsert    Script Date: 8/23/2005 1:11:44 AM ******/
CREATE PROCEDURE [dbo].[procLinkItemTypesInsert]
	(@id 	[int],
	 @name	[nvarchar](50),
	 @description 	[nvarchar](200))

AS INSERT INTO [Photos].[dbo].[LinkItemTypes] 
	 ( [id],
	 [name],
	 [description]) 
 
VALUES 
	( @id,
	 @name,
	 @description)
' 
END
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procLinkItemTypesSelect]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/****** Object:  Stored Procedure dbo.procLinkItemTypesSelect    Script Date: 8/23/2005 1:11:44 AM ******/
CREATE PROCEDURE [dbo].[procLinkItemTypesSelect]
AS SELECT * FROM [Photos].[dbo].[LinkItemTypes]
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procLinkItemTypesUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/****** Object:  Stored Procedure dbo.procLinkItemTypesUpdate    Script Date: 8/23/2005 1:11:44 AM ******/
CREATE PROCEDURE [dbo].[procLinkItemTypesUpdate]
	(@id 	[int],
	 @name 	[nvarchar](50),
	 @description 	[nvarchar](200))

AS UPDATE [Photos].[dbo].[LinkItemTypes] 

SET 
	 [name]	 = @name,
	 [description]	 = @description 

WHERE 
	( [id]	 = @id)
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[procLinkItemTypesDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
/****** Object:  Stored Procedure dbo.procLinkItemTypesDelete    Script Date: 8/23/2005 1:11:44 AM ******/
CREATE PROCEDURE [dbo].[procLinkItemTypesDelete]
	(@id 	[int])

AS DELETE [Photos].[dbo].[LinkItemTypes] 

WHERE 
	( [id]	 = @id)
' 
END
GO
USE [Photos]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LinkItem_Category_Categories]') AND parent_object_id = OBJECT_ID(N'[dbo].[LinkItem_Category]'))
ALTER TABLE [dbo].[LinkItem_Category]  WITH CHECK ADD  CONSTRAINT [FK_LinkItem_Category_Categories] FOREIGN KEY([category_id])
REFERENCES [dbo].[Categories] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_LinkItem_Category_LinkItems]') AND parent_object_id = OBJECT_ID(N'[dbo].[LinkItem_Category]'))
ALTER TABLE [dbo].[LinkItem_Category]  WITH CHECK ADD  CONSTRAINT [FK_LinkItem_Category_LinkItems] FOREIGN KEY([linkitem_id])
REFERENCES [dbo].[LinkItems] ([id])
