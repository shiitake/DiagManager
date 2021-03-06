PRINT '---------------------------------------'
PRINT '---- sysobjects_sysindexes.sql'
PRINT '----   $Revision: 1 $'
PRINT '----   $Date: 2003/10/16 13:27:05 $'
PRINT '---------------------------------------'
PRINT ''
PRINT 'Start Time: ' + CONVERT (varchar(30), GETDATE(), 121)
GO

PRINT '-- sp_helpdb'
EXEC sp_helpdb
GO

IF (CHARINDEX ('9.00.', @@VERSION) > 0) BEGIN
  PRINT '-- sys.databases (SQL 2005 only)'
  SELECT * FROM sys.databases
END
GO

IF (CHARINDEX ('9.00.', @@VERSION) > 0) 
  EXEC sp_MSforeachdb N'PRINT ''-- [?].sys.partitions'' SELECT DB_ID(''?'') AS database_id, * FROM [?].sys.partitions'
GO

CREATE TABLE ##maxnamewidth (type varchar(30), chars int)
GO
EXEC sp_MSforeachdb '
  INSERT INTO ##maxnamewidth SELECT ''sysobjects'', MAX (LEN(name)) FROM [?].dbo.sysobjects
  INSERT INTO ##maxnamewidth SELECT ''sysindexes'', MAX (LEN(name)) FROM [?].dbo.sysindexes
'
GO
DECLARE @sysobj_width varchar(30)
DECLARE @sysind_width varchar(30)
SELECT @sysobj_width = MAX (chars) FROM ##maxnamewidth WHERE type = 'sysobjects'
SELECT @sysind_width = MAX (chars) FROM ##maxnamewidth WHERE type = 'sysindexes'
IF @sysobj_width = 0 SET @sysobj_width = 128
IF @sysind_width = 0 SET @sysind_width = 128
-- DROP TABLE ##maxnamewidth 
DECLARE @sql varchar(4000)
SET @sql = '
   PRINT ''''
   PRINT ''-- ?.dbo.sysobjects (tables only)'' 
   SELECT db_id(''?'') as dbid, id, type, CONVERT (nvarchar(' + @sysobj_width + '), [name]) AS [name], xtype, uid, status
   FROM [?].dbo.sysobjects
   WHERE type IN (''U'', ''S'')
   PRINT ''''
   PRINT ''-- ?.dbo.sysindexes'' 
   SELECT db_id(''?'') as dbid, id, indid, CONVERT (nvarchar(' + @sysind_width + '), [name]) AS [name], minlen, dpages, reserved, used, rowcnt, rowmodctr
   FROM [?].dbo.sysindexes
'
EXEC sp_MSforeachdb @sql
GO
DROP TABLE ##maxnamewidth
GO

PRINT ''
PRINT 'End Time: ' + CONVERT (varchar(30), GETDATE(), 121)
GO
