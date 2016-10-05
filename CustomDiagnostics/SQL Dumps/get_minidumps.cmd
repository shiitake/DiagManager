@ECHO OFF
SETLOCAL
SET MAXDUMPSIZETOCOLLECT=%1
SET MAXDUMPFILETOTALBYTES=%2
SET DUMPDIR=%3
SET INSTANCE=%4
SET INSTANCE=%INSTANCE:"=%
SET OUTPUTDIR=%5

SET /A DUMPFILETOTALBYTES=0
CALL :CopyDirRecursive SQLD*.mft
CALL :CopyDirRecursive SQLDump*.txt
CALL :CopyDirRecursive SQLDump*.log
CALL :CopyDirRecursive SQLDUMPER_ERRORLOG.log
CALL :CopyDirRecursive SQLDmpr*.txt
CALL :CopyDirRecursive *.mdmp

ENDLOCAL
GOTO :eof




:CopyDirRecursive
FOR /F "tokens=*" %%I IN ('dir /B /S /O:-d "%DUMPDIR:"=%%1" ') DO CALL :CheckFile "%%I"
GOTO :eof


:CheckFile 
FOR %%I IN (%1) DO SET FILESIZE=%%~zI
FOR %%I IN (%1) DO SET FILENAME="%%~nxI"
SET DESTFILENAME="%OUTPUTDIR:"=%%COMPUTERNAME%_%INSTANCE%_%FILENAME:"=%"
SET DESTFILENAME_SKIPPED="%DESTFILENAME:"=%.TXT"

REM Make sure this dump file isn't too large to collect by default
IF %FILESIZE% GTR %MAXDUMPSIZETOCOLLECT% (
  ECHO Dump file %1 skipped due to size ^(%FILESIZE% ^> %MAXDUMPSIZETOCOLLECT%^). 
  ECHO Dump file %1 was not > %DESTFILENAME_SKIPPED%
  ECHO collected by PSSDIAG because the dump file size exceeded the configured maximum ^(%MAXDUMPSIZETOCOLLECT% bytes^). >> %DESTFILENAME_SKIPPED%
  ECHO If you need this dump file, have the customer transfer it to you separately.  >> %DESTFILENAME_SKIPPED%
  ECHO. >> %DESTFILENAME_SKIPPED%
  ECHO    Filename:         %1 >> %DESTFILENAME_SKIPPED%
  ECHO    Dump File Size:   %FILESIZE% bytes >> %DESTFILENAME_SKIPPED%
  ECHO    Configured Dump Size Limit: %MAXDUMPSIZETOCOLLECT% bytes >> %DESTFILENAME_SKIPPED%
  GOTO :eof
)

REM Make sure we haven't exceeded the max dump byte count (cap total collected dump file size in case there are 1000s of smaller dumps)
IF %DUMPFILETOTALBYTES% GTR %MAXDUMPFILETOTALBYTES% (
  ECHO Dump file %1 skipped, total dump quota ^(%MAXDUMPFILETOTALBYTES%^) exceeded. 
  ECHO Dump file %1 was not > %DESTFILENAME_SKIPPED%
  ECHO collected by PSSDIAG because the dump file copy quota ^(%MAXDUMPFILETOTALBYTES% bytes^) has already been exceeded. >> %DESTFILENAME_SKIPPED%
  ECHO If you need this dump file, have the customer transfer it to you separately.  >> %DESTFILENAME_SKIPPED%
  ECHO. >> %DESTFILENAME_SKIPPED%
  ECHO    Filename:         %1 >> %DESTFILENAME_SKIPPED%
  ECHO    Dump File Size:   %FILESIZE% bytes >> %DESTFILENAME_SKIPPED%
  ECHO    Configured Dump Copy Quota: %MAXDUMPFILETOTALBYTES% bytes >> %DESTFILENAME_SKIPPED%
  GOTO :eof
)

SET /A DUMPFILETOTALBYTES=%DUMPFILETOTALBYTES% + %FILESIZE%
copy /y %1 %DESTFILENAME%
del /f /q %DESTFILENAME_SKIPPED% > NUL 2>&1

GOTO :eof
