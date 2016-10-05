
select m.* from sys.dm_xe_map_values m
	join sys.dm_xe_packages p on m.object_package_guid = p.guid
where p.name = 'sqlos' and m.name = 'wait_types'
	and m.map_value like 'LATCH%'
go


if exists (select * from sys.dm_xe_sessions s where s.name = 'wait_stacks_LATCH_SH')
	drop event session wait_stacks_LATCH_SH on SERVER
go
 
	
CREATE EVENT SESSION wait_stacks_LATCH_SH
ON SERVER
ADD EVENT sqlos.wait_info
(
      action(package0.callstack) 
      where opcode = 1			-- wait completed
		and wait_type = 34		-- LATCH_SH
)
add target package0.asynchronous_bucketizer (SET source_type = 1, source = 'package0.callstack'),
add target package0.ring_buffer (SET max_memory = 4096)
With (MAX_DISPATCH_LATENCY = 1 SECONDS);
go


if exists (select * from sys.dm_xe_sessions s where s.name = 'wait_stacks_LATCH_UP')
	drop event session wait_stacks_LATCH_UP on SERVER
go
 
	
CREATE EVENT SESSION wait_stacks_LATCH_UP
ON SERVER
ADD EVENT sqlos.wait_info
(
      action(package0.callstack) 
      where opcode = 1			-- wait completed
		and wait_type = 35		-- LATCH_UP
)
add target package0.asynchronous_bucketizer (SET source_type = 1, source = 'package0.callstack'),
add target package0.ring_buffer (SET max_memory = 4096)
With (MAX_DISPATCH_LATENCY = 1 SECONDS);
go


if exists (select * from sys.dm_xe_sessions s where s.name = 'wait_stacks_LATCH_EX')
	drop event session wait_stacks_LATCH_EX on SERVER
go
 
	
CREATE EVENT SESSION wait_stacks_LATCH_EX
ON SERVER
ADD EVENT sqlos.wait_info
(
      action(package0.callstack) 
      where opcode = 1			-- wait completed
		and wait_type = 36		-- LATCH_EX
)
add target package0.asynchronous_bucketizer (SET source_type = 1, source = 'package0.callstack'),
add target package0.ring_buffer (SET max_memory = 4096)
With (MAX_DISPATCH_LATENCY = 1 SECONDS);
go



-- Start the XEvent session so we can capture some data
alter event session wait_stacks_LATCH_SH on server state = start
go
alter event session wait_stacks_LATCH_UP on server state = start
go
alter event session wait_stacks_LATCH_EX on server state = start