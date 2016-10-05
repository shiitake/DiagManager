declare @dbname sysname 
declare @cmd nvarchar(4000)  
declare db_cursor cursor for 
  select name from master.dbo.sysdatabases for read only  

if 0 = @@ERROR  

begin  	
  open db_cursor 
  if 0 = @@ERROR
  begin 
    fetch db_cursor into @dbname
    while @@fetch_status <> -1 and 0 = @@ERROR
      begin 
        select @cmd = 'Checking database ' + @dbname + ' for pinned tables'
        print @cmd  
        select @cmd = 'select ''' + @dbname + ''' as dbname, name, id, uid, sysstat, status from ' + @dbname
        select @cmd = @cmd + '.dbo.sysobjects where (type = ''S'' OR type = ''U'')
          and (sysstat & 0x200 = 512 or status & 0x100000 = 0x100000)' 
        exec(@cmd) 
        print ''  
        fetch db_cursor into @dbname 
      end  
      close db_cursor
    end 
  deallocate db_cursor 
end
go 
