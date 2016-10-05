set nocount on
declare @startup table (ArgsName nvarchar(128), ArgsValue nvarchar(max))

insert into @startup EXEC master..xp_instance_regenumvalues 'HKEY_LOCAL_MACHINE',   'SOFTWARE\Microsoft\MSSQLServer\MSSQLServer\Parameters'
raiserror ('--Startup Parameters--', 0,1) with nowait
select * from @startup
go

declare  @files table (name nvarchar(128), fileid int, filename nvarchar(1024), filegroup nvarchar(128), size nvarchar(50), maxsize nvarchar(50), growth nvarchar(50), usage nvarchar(50))


insert into @files exec sp_msforeachdb 'use [?] exec sp_helpfile'


raiserror ('--database files--', 0,1) with nowait
select * from @files

--sql 11 only
if (charindex ('11.', cast (serverproperty ('ProductVersion') as varchar(20))) > 0)
begin
raiserror ('--Hadron config--', 0,1) with nowait
SELECT 
      ag.name AS ag_name, 
      ar.replica_server_name  ,
      ar_state.is_local AS is_ag_replica_local, 
      ag_replica_role_desc = 
            CASE 
                  WHEN ar_state.role_desc IS NULL THEN N'<unknown>'
                  ELSE ar_state.role_desc 
            END, 
      ag_replica_operational_state_desc = 
            CASE 
                  WHEN ar_state.operational_state_desc IS NULL THEN N'<unknown>'
                  ELSE ar_state.operational_state_desc 
            END, 
      ag_replica_connected_state_desc = 
            CASE 
                  WHEN ar_state.connected_state_desc IS NULL THEN 
                        CASE 
                              WHEN ar_state.is_local = 1 THEN N'CONNECTED'
                              ELSE N'<unknown>'
                        END
                  ELSE ar_state.connected_state_desc 
            END,
      ar.secondary_role_allow_read_desc
FROM 

      sys.availability_groups AS ag 
      JOIN sys.availability_replicas AS ar 
      ON ag.group_id = ar.group_id
 
JOIN sys.dm_hadr_availability_replica_states AS ar_state 
ON  ar.replica_id = ar_state.replica_id;
end

raiserror ('--server property--', 0,1) with nowait
SELECT 
         SERVERPROPERTY ('ComputerNamePhysicalNetBIOS') AS PhysCompName,
         SERVERPROPERTY ('MachineName') AS ServerOrSQLVirtualName,
         SERVERPROPERTY ('InstanceName') AS InstanceName,
         SERVERPROPERTY ('Edition') AS SQLEdition,
         SERVERPROPERTY ('ProductVersion') AS SQLVersion,
         SERVERPROPERTY ('ProductLevel') AS ProductLevel,
         SERVERPROPERTY ('BuildClrVersion') AS CLRVer,
         SERVERPROPERTY ('IsClustered') AS IsClustered,
         SERVERPROPERTY ('IsIntegratedSecurityOnly') AS IsWinAuthOnly,
         SERVERPROPERTY ('IsFullTextInstalled') AS IsFTSInstalled,
         SERVERPROPERTY ('Collation') AS CollationName
