/****** Object:  StoredProcedure [dbo].[CreateUpdatedOnTrigger]    Script Date: 2022/03/02 9:23:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[CreateUpdatedOnTrigger]
@SchemaName VARCHAR(30),
@TableName VARCHAR(100)
AS
DECLARE @TableFullName VARCHAR(200) = '[' + @SchemaName + '].[' + @TableName + ']';
DECLARE @TriggerName VARCHAR(300) = 'tg' + @TableName + '_UpdatedOn';
DECLARE @TriggerFullName VARCHAR(300) = @SchemaName + '.' + @TriggerName;
DECLARE @SQL VARCHAR(MAX);
SET @SQL = '
IF EXISTS(SELECT * FROM sys.triggers tg
	INNER JOIN sys.tables t ON tg.parent_id = t.object_id
	INNER JOIN sys.schemas s ON s.schema_id = t.schema_id 
	WHERE tg.name = ''' + @TriggerName + ''')
	DROP TRIGGER ' + @TriggerFullName + '
'
EXEC (@SQL);

SET @SQL = '
	CREATE TRIGGER ' + @TriggerFullName + ' ON ' + @TableFullName + '
	AFTER UPDATE
	AS 
	BEGIN
		SET NOCOUNT ON;
		UPDATE t SET UpdatedOn = GETUTCDATE()
		FROM ' + @TableFullName + ' t
		INNER JOIN inserted i ON i.PK = t.PK
	END';

--PRINT (@SQL);
EXEC (@SQL);