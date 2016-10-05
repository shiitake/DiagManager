
SET NOCOUNT ON

DECLARE	@cpu_count int,		@file_count int
set @cpu_count=0
set @file_count =0


SELECT	@cpu_count = cpu_count 
FROM	sys.dm_os_sys_info

SELECT	@file_count = COUNT(name)
FROM	tempdb.sys.database_files
WHERE	type = 0

IF NOT (@file_count % @cpu_count = 0)
BEGIN
	PRINT N'CPU count <> FIlE count, CPU count ' + CONVERT(NVARCHAR(10), @cpu_count) + 
          N' FILE count = ' + CONVERT(NVARCHAR(10), @file_count)
END

IF (EXISTS(	SELECT	name,
					size,
					physical_name
			FROM	tempdb.sys.database_files
			WHERE	type = 0
			AND		size <> (SELECT MAX(size) FROM tempdb.sys.database_files WHERE type = 0)))
BEGIN			
	SELECT	name,
			size,
			physical_name
	FROM	tempdb.sys.database_files
	WHERE	type = 0
	AND		size <> (SELECT MAX(size) FROM tempdb.sys.database_files WHERE type = 0)
	ORDER	BY name
END

DECLARE @dbccstatus table
(
	TraceFlag	int,
	Status		int,
	Global		int,
	Session		int
)
INSERT INTO @dbccstatus EXEC(N'dbcc tracestatus(1118) with no_infomsgs')

IF NOT EXISTS(SELECT * FROM	@dbccstatus WHERE TraceFlag = 1118 AND Global = 1)
BEGIN
	PRINT N'-T1118 is not operational'
END

