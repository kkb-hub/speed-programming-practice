/****** Object:  StoredProcedure [dbo].[CreateUpdatedOnTriggers]    Script Date: 2022/03/02 9:24:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CreateUpdatedOnTriggers]
AS
SET NOCOUNT ON;
DECLARE @SQL VARCHAR(MAX) = '';
DECLARE @Table TABLE (SchemaName VARCHAR(30), TableName VARCHAR(100))

INSERT @Table
SELECT DISTINCT s.name, t.name FROM sys.columns c
INNER JOIN sys.tables t ON t.object_id = c.object_id
INNER JOIN sys.schemas s ON s.schema_id = t.schema_id
WHERE c.name = 'UpdatedOn';

SELECT @SQL = @SQL + 'EXEC dbo.CreateUpdatedOnTrigger [' + SchemaName + '], [' + TableName + ']' + CHAR(13) FROM @Table

print @SQL