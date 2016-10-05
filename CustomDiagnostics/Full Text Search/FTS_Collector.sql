PRINT '---------------------------------------'
PRINT '---- FullText Information Collector'
PRINT '----   $Revision: 1 $'
PRINT '----   $Date: 2010/4/19 09:30:05 $'
PRINT '----   $Comments: Only for SQL 2005 & above'
PRINT '-------------------------------------------'
PRINT ''
PRINT 'Start Time: ' + CONVERT (varchar(30), GETDATE(), 121)
PRINT ''
GO

DECLARE @IsFullTextInstalled int
PRINT ''
PRINT '******** Full-text Service Information ********'
PRINT '***********************************************'
PRINT ''
PRINT '======== FULLTEXTSERVICEPROPERTY (IsFulltextInstalled)'
SET @IsFullTextInstalled = FULLTEXTSERVICEPROPERTY ('IsFulltextInstalled')
PRINT CASE @IsFullTextInstalled 
    WHEN 1 THEN '1 - Yes' 
    WHEN 0 THEN '0 - No' 
    ELSE 'Unknown'
  END
IF (@IsFullTextInstalled = 1)
BEGIN
    PRINT ''
	PRINT '======== FULLTEXTSERVICEPROPERTY (Memory ResourceUsage)'
	PRINT CASE FULLTEXTSERVICEPROPERTY ('ResourceUsage')
		  WHEN 1 THEN '1 - Least Aggressive (Background)'
		  WHEN 2 THEN '2 - Low'
		  WHEN 3 THEN '3 - Normal (Default)'
		  WHEN 4 THEN '4 - High'
		  WHEN 5 THEN '5 - Most Aggressive (Highest)'
		  ELSE CONVERT (varchar, FULLTEXTSERVICEPROPERTY ('ResourceUsage'))
		END

	  PRINT ''
	  PRINT '======== FULLTEXTSERVICEPROPERTY (LoadOSResources)'
	  PRINT CASE FULLTEXTSERVICEPROPERTY ('LoadOSResources')
		  WHEN 1 THEN '1 - Loads OS filters and word breakers.'
		  WHEN 0 THEN '0 - Use only filters and word breakers specific to this instance of SQL Server. Equivalent to ~DOES NOT LOAD OS filters/word-breakers~' 
		  ELSE CONVERT (varchar, FULLTEXTSERVICEPROPERTY ('LoadOSResources'))
		END

	  PRINT ''
	  PRINT '======== FULLTEXTSERVICEPROPERTY (VerifySignature)'
	  PRINT CASE FULLTEXTSERVICEPROPERTY ('VerifySignature')
		  WHEN 1 THEN '1 - Verify that only trusted, signed binaries are loaded.'
		  WHEN 0 THEN '0 - Do not verify whether or not binaries are signed. (Unsigned binaries can be loaded)' 
		  ELSE CONVERT (varchar, FULLTEXTSERVICEPROPERTY ('VerifySignature'))
		END
	  PRINT ''
END

GO
PRINT ''
PRINT '******** MSFTESQL Start-up Account ********'
PRINT '*******************************************'
PRINT ''
declare @instancename nvarchar (128), @key nvarchar(1000)
set @instancename = cast ( serverproperty(N'InstanceName') as nvarchar)
if @instancename  is not null
	set @key='System\CurrentControlSet\Services\MSFTESQL$'+@instancename
else 
	set @key='System\CurrentControlSet\Services\MSFTESQL'	

exec master.dbo.xp_regread N'HKEY_LOCAL_MACHINE',@key,  N'ObjectName'	
GO

PRINT ''
PRINT '******** FTS Group Memebers ********'
PRINT '************************************'
PRINT ''
SET NOCOUNT ON
GO
declare @computername varchar(128)
declare @instancename nvarchar (128)
declare @FTSGroup nvarchar(128)
set @instancename = cast ( serverproperty(N'InstanceName') as nvarchar)
drop table #computername
create table #computername (name varchar(128))
insert into #computername exec master.dbo.xp_cmdshell 'hostname'
delete from #computername where name is null
set @computername = (select name from #computername)
set @FTSGroup = 'net localgroup SQLServer2005MSFTEUser$' + @computername + '$' + @instancename
exec master.dbo.xp_cmdshell @FTSGroup
SET NOCOUNT OFF

GO
PRINT ''
PRINT '******** Full-Text Catalog Information & Properties ********'
PRINT '************************************************************'
PRINT ''
GO
sp_msforeachdb 'IF EXISTS (select * from ?.sys.fulltext_catalogs) BEGIN PRINT ''======== DatabaseName: ?'' SELECT cat.name AS [CatalogName], cat.fulltext_catalog_id AS [CatalogID], 
FULLTEXTCATALOGPROPERTY(cat.name,''LogSize'') AS [ErrorLogSize], 
FULLTEXTCATALOGPROPERTY(cat.name,''IndexSize'') AS [FullTextIndexSize], 
FULLTEXTCATALOGPROPERTY(cat.name,''ItemCount'') AS [ItemCount], 
FULLTEXTCATALOGPROPERTY(cat.name,''UniqueKeyCount'') AS [UniqueKeyCount], 
[PopulationStatus] = CASE 
WHEN FULLTEXTCATALOGPROPERTY(cat.name,''PopulateStatus'') = 0 THEN ''Idle''
WHEN FULLTEXTCATALOGPROPERTY(cat.name,''PopulateStatus'') = 1 THEN ''Full population in progress'' 
WHEN FULLTEXTCATALOGPROPERTY(cat.name,''PopulateStatus'') = 2 THEN ''Paused''
WHEN FULLTEXTCATALOGPROPERTY(cat.name,''PopulateStatus'') = 4 THEN ''Recovering''
WHEN FULLTEXTCATALOGPROPERTY(cat.name,''PopulateStatus'') = 6 THEN ''Incremental population in progress''
WHEN FULLTEXTCATALOGPROPERTY(cat.name,''PopulateStatus'') = 7 THEN ''Building index''
WHEN FULLTEXTCATALOGPROPERTY(cat.name,''PopulateStatus'') = 9 THEN ''Change tracking''
ELSE ''Other Status(0/3/5/8)''END,
tbl.change_tracking_state_desc AS [ChangeTracking],
FULLTEXTCATALOGPROPERTY(cat.name,''MergeStatus'') AS [IsMasterMergeHappening],
tbl.crawl_type_desc AS [LastCrawlType],
tbl.crawl_start_date AS [LastCrawlSTARTDate],
tbl.crawl_end_date AS [LastCrawlENDDate],
ISNULL(cat.path,N'''') AS [CatalogRootPath], 
CAST((select (case when exists(select distinct object_id 
from sys.fulltext_indexes fti 
where cat.fulltext_catalog_id = fti.fulltext_catalog_id and OBJECTPROPERTY(object_id, ''IsTable'')=1) 
then 1 else 0 end)) AS bit) AS [HasFullTextIndexedTables]
FROM ?.sys.fulltext_catalogs AS cat 
LEFT OUTER JOIN ?.sys.filegroups AS fg ON cat.data_space_id = fg.data_space_id 
LEFT OUTER JOIN ?.sys.database_principals AS dp ON cat.principal_id=dp.principal_id 
LEFT OUTER JOIN ?.sys.fulltext_indexes AS tbl ON cat.fulltext_catalog_id = tbl.fulltext_catalog_id PRINT '''' END'
GO

PRINT ''
PRINT '******** Full-text Index Information (for each table)********'
PRINT '*************************************************************'
PRINT ''
GO
sp_msforeachdb 'IF EXISTS (select * from ?.sys.fulltext_indexes where is_enabled=1) BEGIN PRINT ''======== DatabaseName: ?'' 
SELECT
Object_name(fti.object_id) AS ''TableName'',
cat.name AS [CatalogName],
CAST(fti.is_enabled AS bit) AS [IsEnabled],
OBJECTPROPERTY(fti.object_id,''TableFullTextPopulateStatus'') AS [PopulationStatus],
(case change_tracking_state when ''M'' then 1 when ''A'' then 2 else 0 end) AS [ChangeTracking],
OBJECTPROPERTY(fti.object_id,''TableFullTextItemCount'') AS [ItemCount],
OBJECTPROPERTY(fti.object_id,''TableFullTextDocsProcessed'') AS [DocumentsProcessed],
OBJECTPROPERTY(fti.object_id,''TableFullTextPendingChanges'') AS [PendingChanges],
OBJECTPROPERTY(fti.object_id,''TableFullTextFailCount'') AS [NumberOfFailures],
si.name AS [UniqueIndexName]
FROM
?.sys.tables AS tbl
INNER JOIN ?.sys.fulltext_indexes AS fti ON fti.object_id=tbl.object_id
INNER JOIN ?.sys.fulltext_catalogs AS cat ON cat.fulltext_catalog_id = fti.fulltext_catalog_id
INNER JOIN ?.sys.indexes AS si ON si.index_id=fti.unique_index_id and si.object_id=fti.object_id
PRINT '''' END'
GO

PRINT ''
PRINT '******** Full-text Column Information (for each FTEnabled column in a table)********'
PRINT '************************************************************************************'
PRINT ''
GO
sp_msforeachdb 'IF EXISTS (select * from ?.sys.fulltext_index_columns) BEGIN PRINT ''======== DatabaseName: ?'' 
SELECT
col.name AS [ColumnName],
object_name(icol.object_id) AS [TableName]
FROM
?.sys.tables AS tbl
INNER JOIN ?.sys.fulltext_indexes AS fti ON fti.object_id=tbl.object_id
INNER JOIN ?.sys.fulltext_index_columns AS icol ON icol.object_id=fti.object_id
INNER JOIN ?.sys.columns AS col ON col.object_id = icol.object_id and col.column_id = icol.column_id
PRINT '''' END'
GO

PRINT ''
PRINT '******** WordBreaking Language Information ********'
PRINT '***************************************************'
PRINT ''
GO
sp_msforeachdb 'IF EXISTS (select * from ?.sys.fulltext_indexes where is_enabled=1) BEGIN PRINT ''======== DatabaseName: ?'' 
SELECT tbl.object_id as [ObjectID],
tbl.name as [TableName],
col.name AS [ColumnName],
sl.name AS [WordBreaker_Language],
sl.lcid AS [LCID]
FROM
?.sys.tables AS tbl
INNER JOIN ?.sys.fulltext_indexes AS fti ON fti.object_id=tbl.object_id
INNER JOIN ?.sys.fulltext_index_columns AS icol ON icol.object_id=fti.object_id
INNER JOIN ?.sys.columns AS col ON col.object_id = icol.object_id and col.column_id = icol.column_id
INNER JOIN ?.sys.fulltext_languages AS sl ON sl.lcid=icol.language_id
PRINT '''' END'

GO
PRINT ''
PRINT '******** IFilters loaded in SQL Server ********'
PRINT '***********************************************'
PRINT ''

select document_type as [Extension], manufacturer, version, path, Class_ID from sys.fulltext_document_types

GO
PRINT ''
PRINT '******** NON-Microsoft IFilters present ********'
PRINT '************************************************'
PRINT ''

select document_type as [Extension], manufacturer, version, path, Class_ID from sys.fulltext_document_types
where manufacturer not like 'Microsoft Corporation'
and path not like '%offfilt%'

PRINT ''
PRINT 'End Time: ' + CONVERT (varchar(30), GETDATE(), 121)
GO
