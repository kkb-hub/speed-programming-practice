USE [JDocHub]
GO
/****** Object:  StoredProcedure [dbo].[CreateTable]    Script Date: 2/22/2022 1:21:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[CreateTable]
@SchemaName VARCHAR(30),
@TableName VARCHAR(100)
AS
--DECLARE @SchemaName VARCHAR(30);
--DECLARE @TableName VARCHAR(100);
DECLARE @FullName VARCHAR(100) = '[' + @SchemaName + '].[' + @TableName + ']'

DECLARE @PKConstraintName VARCHAR(100) = 'PK_' + @TableName;
DECLARE @DFID VARCHAR(100) = 'DF_' + @TableName + '_ID';
DECLARE @DFCreatedOn VARCHAR(100) = 'DF_' + @TableName + '_CreatedOn';
DECLARE @SQL NVARCHAR(MAX) = '';

SET @SQL = '
CREATE TABLE ' + @FullName + ' (
	[PK] [bigint] IDENTITY(1,1) NOT NULL,
	[ID] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[UpdatedOn] [datetime2](7) NULL,
	[DeletedOn] [datetime2](7) NULL,
	[CreatedByName] [nvarchar](50) NULL,
	[CreatedByID] uniqueidentifier NULL,
	[UpdatedByName] [nvarchar](50) NULL,
	[UpdatedByID] uniqueidentifier NULL,
	[DeletedByName] [nvarchar](50) NULL,
	[DeletedByID] uniqueidentifier NULL,
CONSTRAINT [' + @PKConstraintName + '] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]'

EXEC (@SQL)

SET @SQL = 'ALTER TABLE ' + @FullName + ' ADD  CONSTRAINT [' + @DFID + ']  DEFAULT (newid()) FOR [ID]'

EXEC (@SQL)

SET @SQL = 'ALTER TABLE ' + @FullName + ' ADD  CONSTRAINT [' + @DFCreatedOn + ']  DEFAULT (getutcdate()) FOR [CreatedOn]'

EXEC (@SQL)