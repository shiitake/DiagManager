:XML ON
go
select xest.target_data 
from sys.dm_xe_session_targets xest
join sys.dm_xe_sessions xes on xes.address = xest.event_session_address
where xest.target_name = 'ring_buffer' and xes.name = 'system_health'
