PRINT '==== Check for hypothetical indexes'
GO
EXEC master..sp_MSforeachdb @command1 = 'PRINT ''==== Hypothetical indexes in [?]''', 
  @command2 = 'SELECT CASE WHEN i.name LIKE ''hind_c_%'' 
    THEN ''drop index ['' ELSE ''drop statistics ['' END
    + o.name + ''].['' + i.name + '']'' AS [cmd]
    FROM [?].dbo.sysindexes i INNER JOIN [?].dbo.sysobjects o ON i.id = o.id
    WHERE i.name LIKE ''hind_%'' 
    AND ((i.status & 0x40 = 0x40) OR (i.status & (0x4000+0x2000) = 0))'
GO
