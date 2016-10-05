@echo off
rem This is invoked from PSSDIAG with a custom utility command: 
rem
rem      NTFS_Compression_Check.cmd %batchrunner% %server% %server_instance% "%instance%" "%output_path%" %authmode% %ssuser% %sspwd% 
rem
rem %authmode% is either 1 (Windows auth) or 0 (SQL auth).  If %authmode%=0, then 
rem %ssuser% and %sspwd% will be provided. Note carefully which parameters should 
rem be double-quoted. 

SETLOCAL
SET BATCHRUNNER=%1
SET SERVER=%2
SET SQLSERVER=%3
SET INSTANCE=%4
SET INSTANCE=%INSTANCE:"=%
SET OUTPATH=%5
rem Strip off quote delimiters from around directory.
set OUTPATH=%OUTPATH:"=%
rem Strip off any trailing spaces.
if "%OUTPATH:~-1%" == " " set OUTPATH=%OUTPATH:~0,-1%
SET OUTFILE=%OUTPATH%%SERVER%_%INSTANCE%_SQL_filelist.TXT
if (%6)==(0) (
  set SECURITY=-U%7 -P%8
) else (
  set SECURITY=-E
)

ECHO SQL NTFS Compression Check:
ECHO A "c" in mdf/ndf/ldf file attributes indicates that NTFS compression is enabled. 
ECHO.
ECHO Retrieving all paths that contain SQL data and log files...
%BATCHRUNNER% %SECURITY% -h-1 -n -w2000 -S%SQLSERVER% -iNTFS_Compression_Check.sql -o"%OUTFILE%" 

type "%OUTFILE%"
ECHO.

FOR /F "tokens=*" %%I IN ('type "%OUTFILE%"') DO CALL :DumpDir %%I
GOTO :eof

:DumpDir
SET ORIGDIR=%*
REM -- Handle quirk of NT4 cmd.exe -- origdir will inexplicably have a leading space
IF (^%ORIGDIR:~0,1%)==(^ ) SET ORIGDIR=%ORIGDIR:~1%
IF (^%ORIGDIR:~0,1%)==(^\) (
  REM -- Add servername prefix to UNC path
  SET FULLDIR="\\%SERVER%%ORIGDIR%
) ELSE (
  REM -- Non-UNC path
  SET FULLDIR="%ORIGDIR%
)
ECHO odir.exe +p %FULLDIR%
ECHO attrib  size     date                filename
ECHO ------- -------- ------------------- -----------------------------------
odir.exe +p %FULLDIR%
ECHO.
GOTO :eof

ENDLOCAL
