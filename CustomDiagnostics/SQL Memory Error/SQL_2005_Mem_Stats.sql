
-- We'll be querying indexed views; make sure the appropriate options are set. 
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET NUMERIC_ROUNDABORT OFF
GO

SET NOCOUNT ON
IF (CHARINDEX ('9.00', @@VERSION) = 0) BEGIN
  PRINT ''
  PRINT 'NOTE: This script is for SQL Server 2005.  Errors are expected when run on earlier versions.'
  PRINT ''
END
GO

DECLARE @runtime datetime
DECLARE @lastruntime datetime
SET @lastruntime = '19000101'

WHILE (1=1)
BEGIN

SET @runtime = GETDATE()
PRINT ''
PRINT 'Start time: ' + CONVERT (varchar (50), GETDATE(), 121)
PRINT ''


print '-- query execution memory --'
SELECT    CONVERT (varchar(30), @runtime, 121) as runtime, 
		r.session_id
         , r.blocking_session_id
         , r.cpu_time
         , r.total_elapsed_time
         , r.reads
         , r.writes
         , r.logical_reads
         , r.row_count
         , wait_time
         , wait_type
         , r.command
         , ltrim(rtrim(replace(replace (substring (q.text, 1, 1000), char(10), ' '), char(13), ' '))) [text]
         --, REPLACE (REPLACE (SUBSTRING (q.[text] COLLATE Latin1_General_BIN, CHARINDEX (''CREATE '', SUBSTRING (q.[text] COLLATE Latin1_General_BIN, 1, 1000)), 50), CHAR(10), '' ''), CHAR(13), '' '')
         --, q.TEXT  --Full SQL Text
         , s.login_time
         , d.name
         , s.login_name
         , s.host_name
         , s.nt_domain
         , s.nt_user_name
         , s.status
         , c.client_net_address
         , s.program_name
         , s.client_interface_name
--         , s.total_elapsed_time
         , s.last_request_start_time
         , s.last_request_end_time
         , c.connect_time
         , c.last_read
         , c.last_write
         , mg.dop --Degree of parallelism 
         , mg.request_time  --Date and time when this query requested the memory grant.
         , mg.grant_time --NULL means memory has not been granted
         , mg.requested_memory_kb
          / 1024 requested_memory_mb --Total requested amount of memory in megabytes
         , mg.granted_memory_kb
          / 1024 AS granted_memory_mb --Total amount of memory actually granted in megabytes. NULL if not granted
         , mg.required_memory_kb
          / 1024 AS required_memory_mb--Minimum memory required to run this query in megabytes. 
         , max_used_memory_kb
          / 1024 AS max_used_memory_mb
         , mg.query_cost --Estimated query cost.
         , mg.timeout_sec --Time-out in seconds before this query gives up the memory grant request.
         , mg.resource_semaphore_id --Nonunique ID of the resource semaphore on which this query is waiting.
         , mg.wait_time_ms --Wait time in milliseconds. NULL if the memory is already granted.
         , CASE mg.is_next_candidate --Is this process the next candidate for a memory grant
           WHEN 1 THEN 'Yes'
           WHEN 0 THEN 'No'
           ELSE 'Memory has been granted'
         END AS 'Next Candidate for Memory Grant'
         , rs.target_memory_kb
          / 1024 AS server_target_memory_mb --Grant usage target in megabytes.
         , rs.max_target_memory_kb
          / 1024 AS server_max_target_memory_mb --Maximum potential target in megabytes. NULL for the small-query resource semaphore.
         , rs.total_memory_kb
          / 1024 AS server_total_memory_mb --Memory held by the resource semaphore in megabytes. 
         , rs.available_memory_kb
          / 1024 AS server_available_memory_mb --Memory available for a new grant in megabytes.
         , rs.granted_memory_kb
          / 1024 AS server_granted_memory_mb  --Total granted memory in megabytes.
         , rs.used_memory_kb
          / 1024 AS server_used_memory_mb --Physically used part of granted memory in megabytes.
         , rs.grantee_count --Number of active queries that have their grants satisfied.
         , rs.waiter_count --Number of queries waiting for grants to be satisfied.
         , rs.timeout_error_count --Total number of time-out errors since server startup. NULL for the small-query resource semaphore.
         , rs.forced_grant_count --Total number of forced minimum-memory grants since server startup. NULL for the small-query resource semaphore.
FROM     sys.dm_exec_requests r
         JOIN sys.dm_exec_connections c
           ON r.connection_id = c.connection_id
         JOIN sys.dm_exec_sessions s
           ON c.session_id = s.session_id
         JOIN sys.databases d
           ON r.database_id = d.database_id
         JOIN sys.dm_exec_query_memory_grants mg
           ON s.session_id = mg.session_id
         INNER JOIN sys.dm_exec_query_resource_semaphores rs
           ON mg.resource_semaphore_id = rs.resource_semaphore_id
         CROSS APPLY sys.DM_EXEC_SQL_TEXT (r.sql_handle ) AS q
ORDER BY wait_time DESC
RAISERROR ('', 0, 1) WITH NOWAIT


PRINT '-- dm_os_memory_cache_counters'
SELECT CONVERT (varchar(30), @runtime, 121) as runtime, * FROM sys.dm_os_memory_cache_counters
RAISERROR ('', 0, 1) WITH NOWAIT


PRINT '-- dm_os_memory_clerks'
SELECT CONVERT (varchar(30), @runtime, 121) as runtime, * FROM sys.dm_os_memory_clerks
RAISERROR ('', 0, 1) WITH NOWAIT


PRINT '-- dm_os_memory_cache_clock_hands'
SELECT CONVERT (varchar(30), @runtime, 121) as runtime, * FROM sys.dm_os_memory_cache_clock_hands
RAISERROR ('', 0, 1) WITH NOWAIT


PRINT '-- dm_os_memory_cache_hash_tables'
SELECT CONVERT (varchar(30), @runtime, 121) as runtime, * FROM sys.dm_os_memory_cache_hash_tables
RAISERROR ('', 0, 1) WITH NOWAIT


PRINT '-- dm_os_memory_pools'
SELECT CONVERT (varchar(30), @runtime, 121) as runtime, * FROM sys.dm_os_memory_pools
RAISERROR ('', 0, 1) WITH NOWAIT


PRINT '-- sys.dm_os_loaded_modules (non-Microsoft)'
SELECT CONVERT (varchar(30), @runtime, 121) as runtime, * FROM sys.dm_os_loaded_modules 
WHERE (company NOT LIKE '%Microsoft%' OR company IS NULL)
  AND UPPER (name) NOT LIKE '%_NSTAP_.DLL' -- instapi.dll (MS dll), with "i"'s wildcarded for Turkish systems
  AND UPPER (name) NOT LIKE '%\ODBC32.DLL' -- ODBC32.dll (MS dll)
RAISERROR ('', 0, 1) WITH NOWAIT


PRINT '-- sys.dm_os_sys_info'
SELECT CONVERT (varchar(30), @runtime, 121) as runtime, * 
FROM sys.dm_os_sys_info
RAISERROR ('', 0, 1) WITH NOWAIT



PRINT '-- sys.dm_os_memory_objects (total memory by type, >1MB)'
SELECT CONVERT (varchar(30), @runtime, 121) as runtime, 
  SUM (CONVERT(bigint,(pages_allocated_count * page_size_in_bytes))) AS 'total_bytes_used', type 
FROM sys.dm_os_memory_objects
GROUP BY type 
HAVING SUM (CONVERT(bigint,(pages_allocated_count * page_size_in_bytes))) >= (1024*1024) -- ignore any memobj type that isn't using at least 1MB
ORDER BY SUM (CONVERT(bigint,(pages_allocated_count * page_size_in_bytes))) DESC
RAISERROR ('', 0, 1) WITH NOWAIT



-- -- Check for windows memory notifications
 PRINT '-- memory_workingset_trimming'
SELECT 
CONVERT (varchar(30), @runtime, 121) as runtime,
DATEADD (ms, a.[Record Time] - sys.ms_ticks, @runtime) AS Notification_time, 	
	a.* ,
sys.ms_ticks AS [Current Time]
	FROM 
	(SELECT x.value('(//Record/ResourceMonitor/Notification)[1]', 'varchar(30)') AS [Notification_type], 
	x.value('(//Record/MemoryRecord/MemoryUtilization)[1]', 'int') AS [MemoryUtilization %], 
	x.value('(//Record/MemoryRecord/TotalPhysicalMemory)[1]', 'bigint') AS [TotalPhysicalMemory_KB], 
	x.value('(//Record/MemoryRecord/AvailablePhysicalMemory)[1]', 'bigint') AS [AvailablePhysicalMemory_KB], 
	x.value('(//Record/MemoryRecord/TotalPageFile)[1]', 'bigint') AS [TotalPageFile_KB], 
	x.value('(//Record/MemoryRecord/AvailablePageFile)[1]', 'bigint') AS [AvailablePageFile_KB], 
	x.value('(//Record/MemoryRecord/TotalVirtualAddressSpace)[1]', 'bigint') AS [TotalVirtualAddressSpace_KB], 
	x.value('(//Record/MemoryRecord/AvailableVirtualAddressSpace)[1]', 'bigint') AS [AvailableVirtualAddressSpace_KB], 
	x.value('(//Record/MemoryNode/@id)[1]', 'int') AS [Node Id], 
	x.value('(//Record/MemoryNode/ReservedMemory)[1]', 'bigint') AS [SQL_ReservedMemory_KB], 
	x.value('(//Record/MemoryNode/CommittedMemory)[1]', 'bigint') AS [SQL_CommittedMemory_KB], 
	x.value('(//Record/@id)[1]', 'bigint') AS [Record Id], 
	x.value('(//Record/@type)[1]', 'varchar(30)') AS [Type], 
	x.value('(//Record/ResourceMonitor/Indicators)[1]', 'int') AS [Indicators], 
	x.value('(//Record/@time)[1]', 'bigint') AS [Record Time]
	FROM (SELECT CAST (record as xml) FROM sys.dm_os_ring_buffers 
	WHERE ring_buffer_type = 'RING_BUFFER_RESOURCE_MONITOR') AS R(x)) a 
CROSS JOIN sys.dm_os_sys_info sys
WHERE DATEADD (ms, a.[Record Time] - sys.ms_ticks, @runtime) BETWEEN @lastruntime AND @runtime
ORDER BY DATEADD (ms, a.[Record Time] - sys.ms_ticks, @runtime)
RAISERROR ('', 0, 1) WITH NOWAIT



PRINT '-- sys.dm_os_ring_buffers (RING_BUFFER_RESOURCE_MONITOR and RING_BUFFER_MEMORY_BROKER)'
SELECT CONVERT (varchar(30), @runtime, 121) as runtime, 
  DATEADD (ms, ring.[timestamp] - sys.ms_ticks, GETDATE()) AS record_time, 
  ring.[timestamp] AS record_timestamp, sys.ms_ticks AS cur_timestamp, ring.* 
FROM sys.dm_os_ring_buffers ring
CROSS JOIN sys.dm_os_sys_info sys
WHERE ring.ring_buffer_type IN ( 'RING_BUFFER_RESOURCE_MONITOR' , 'RING_BUFFER_MEMORY_BROKER' )
  AND DATEADD (ms, ring.timestamp - sys.ms_ticks, GETDATE()) BETWEEN @lastruntime AND GETDATE()
RAISERROR ('', 0, 1) WITH NOWAIT


PRINT '-- proccache_summary'
SELECT CONVERT (varchar(30), @runtime, 121) as runtime, 
  SUM (cast (size_in_bytes as bigint)) AS total_size_in_bytes, COUNT(*) AS plan_count, AVG (usecounts) AS avg_usecounts
FROM sys.dm_exec_cached_plans
RAISERROR ('', 0, 1) WITH NOWAIT


-- Check for plans that are "polluting" the proc cache with trivial variations 
-- (typically due to a lack of parameterization)
PRINT '-- proccache_pollution';
WITH cached_plans (cacheobjtype, objtype, usecounts, size_in_bytes, dbid, objectid, short_qry_text) AS 
(
  SELECT p.cacheobjtype, p.objtype, p.usecounts, size_in_bytes, s.dbid, s.objectid, 
    CONVERT (nvarchar(100), REPLACE (REPLACE (
      CASE 
        -- Special cases: handle NULL s.[text] and 'SET NOEXEC'
        WHEN s.[text] IS NULL THEN NULL 
        WHEN CHARINDEX ('noexec', SUBSTRING (s.[text], 1, 200)) > 0 THEN SUBSTRING (s.[text], 1, 40)
        -- CASE #1: sp_executesql (query text passed in as 1st parameter) 
        WHEN (CHARINDEX ('sp_executesql', SUBSTRING (s.[text], 1, 200)) > 0) 
        THEN SUBSTRING (s.[text], CHARINDEX ('exec', SUBSTRING (s.[text], 1, 200)), 60) 
        -- CASE #3: any other stored proc -- strip off any parameters
        WHEN CHARINDEX ('exec ', SUBSTRING (s.[text], 1, 200)) > 0 
        THEN SUBSTRING (s.[text], CHARINDEX ('exec', SUBSTRING (s.[text], 1, 4000)), 
          CHARINDEX (' ', SUBSTRING (SUBSTRING (s.[text], 1, 200) + '   ', CHARINDEX ('exec', SUBSTRING (s.[text], 1, 500)), 200), 9) )
        -- CASE #4: stored proc that starts with common prefix 'sp%' instead of 'exec'
        WHEN SUBSTRING (s.[text], 1, 2) IN ('sp', 'xp', 'usp')
        THEN SUBSTRING (s.[text], 1, CHARINDEX (' ', SUBSTRING (s.[text], 1, 200) + ' '))
        -- CASE #5: ad hoc UPD/INS/DEL query (on average, updates/inserts/deletes usually 
        -- need a shorter substring to avoid hitting parameters)
        WHEN SUBSTRING (s.[text], 1, 30) LIKE '%UPDATE %' OR SUBSTRING (s.[text], 1, 30) LIKE '%INSERT %' 
          OR SUBSTRING (s.[text], 1, 30) LIKE '%DELETE %' 
        THEN SUBSTRING (s.[text], 1, 30)
        -- CASE #6: other ad hoc query
        ELSE SUBSTRING (s.[text], 1, 45)
      END
    , CHAR (10), ' '), CHAR (13), ' ')) AS short_qry_text 
  FROM sys.dm_exec_cached_plans p
  CROSS APPLY sys.dm_exec_sql_text (p.plan_handle) s
) 
SELECT CONVERT (varchar(30), @runtime, 121) as runtime, 
  COUNT(*) AS plan_count, SUM (cast (size_in_bytes as bigint)) AS total_size_in_bytes,
  cacheobjtype, objtype, usecounts, dbid, objectid, short_qry_text 
FROM cached_plans
GROUP BY cacheobjtype, objtype, usecounts, dbid, objectid, short_qry_text
HAVING COUNT(*) > 100
ORDER BY COUNT(*) DESC
RAISERROR ('', 0, 1) WITH NOWAIT


-- -- Check for excessively long hash buckets
-- PRINT '-- proccache_long_hash_buckets'
-- SELECT CONVERT (varchar(30), @runtime, 121) as runtime, bucketid, COUNT(*) AS plan_count
-- FROM sys.dm_exec_cached_plans p
-- GROUP BY bucketid 
-- HAVING COUNT(*) > 100
-- ORDER BY COUNT(*) DESC
-- RAISERROR ('', 0, 1) WITH NOWAIT


  -- Save current runtime -- we'll use it to display only new ring buffer records on the next snapshot
  SET @lastruntime = DATEADD (s, -15, @runtime) -- allow for up to a 15 second snapshot runtime without missing records
  -- flush the buffer
  RAISERROR ('', 0,1) WITH NOWAIT
  WAITFOR DELAY '00:02:00'
END
GO
