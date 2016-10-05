/*
this is used to generate profiler trace events automatically
all you need to do is to plug in the template that has enabled events
and this will generate it for you.
*/
create table #t (xmlcol xml)
go
insert into #t select cast (BulkColumn as XMl) xmlcol  from  OPENROWSET(BULK N'\_GeneralPerformance10.xml', SINGLE_BLOB) AS Document
go
with XMLNAMESPACES('http://tempuri.org/pssdiag_trace_schema.xsd' as diag)
select  t1.c1.value('./@id', 'int') 'EventID',
  t1.c1.value('./@enabled', 'nvarchar(10)') 'Enabled'
  into #enabledEvents
from #t 
cross apply xmlcol.nodes ('//diag:Event') t1 (c1)

go




go
select 
1 as Tag,
null as parent,
cat.name as [EventType!1!name],
null as [Event!2!name],
null as [Event!2!id],
null as [Event!2!enabled]
from /*sys.trace_events evt inner join*/ sys.trace_categories cat --on evt.category_id=cat.category_id
union all
select 2 as tag,
1 as parent,
cat.name,
evt.name,
evt.trace_event_id,
case when ena.EventID is null then 'false' else ena.Enabled end
from sys.trace_events evt inner join sys.trace_categories cat on evt.category_id=cat.category_id
left outer join #enabledEvents ena on evt.trace_event_id = ena.EventID 
order by [EventType!1!name], [Event!2!name]
for xml explicit




