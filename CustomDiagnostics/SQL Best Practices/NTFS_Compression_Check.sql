if object_id ('tempdb..#MSdbfilelist') is not null drop table #MSdbfilelist 
go
create table #MSdbfilelist (dbname sysname, [filename] nvarchar (3000))
go
exec sp_MSforeachdb 'insert into #MSdbfilelist (dbname, [filename]) select ''?'', rtrim (filename) from [?].dbo.sysfiles'
go 
-- select * from #MSdbfilelist order by dbname
go
declare @dir nvarchar (4000)
declare @cmd nvarchar (4000)
declare c cursor local read_only for
-- Get a list of distinct directories
select distinct ltrim (rtrim (substring (filename, 1, len (filename) - charindex ('\', reverse (filename))) + '\'))
from #MSdbfilelist 
open c
fetch next from c into @dir
while (@@fetch_status <> -1)
begin
  -- First output the local path that we can be very confident will work on local instances. 
  print @dir 
  -- Now generate an equivalent path using UNC paths that should work for remote servers (if they have admin shares enabled). 
  if (substring (@dir, 2, 1) = ':')
  begin
    set @dir = '\' + substring (@dir, 1, 1) + '$' + substring (@dir, 3, 4000) 
    print @dir
  end
  fetch next from c into @dir
end
go



-- BD 2006/06/05 - Bracket db name placeholder (? --> [?]) for sp_MSforeachdb
