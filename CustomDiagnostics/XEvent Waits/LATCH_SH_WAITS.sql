:XML ON
go
select target_data  'LATCH_SH bucketizer ' 	from sys.dm_xe_session_targets t 		join sys.dm_xe_sessions s on t.event_session_address = s.address 	where s.name = 'wait_stacks_LATCH_SH' and t.target_name = 'asynchronous_bucketizer'
