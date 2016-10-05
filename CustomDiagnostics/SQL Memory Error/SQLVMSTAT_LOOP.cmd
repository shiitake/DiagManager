@ECHO OFF
REM -- Expected input params: 
REM --     %1 - Number of seconds to sleep between iterations
REM --     %2 - Name of the local SQL instance to grab VMSTAT output for
SETLOCAL
SET SLEEPTIME=%1
SET INSTANCE=%2
IF "%SLEEPTIME%"=="" SET SLEEPTIME=15

REM -- GetSQLInstancePID returns the PID of the specified instance as %SQLPID%. 
CALL GetSQLInstancePID %INSTANCE%

IsProcess64bit.exe %SQLPID%
IF %ERRORLEVEL% GTR 2 (
  ECHO VMSTAT.exe does not work against 64-bit processes. Exiting. 
  GOTO :eof
)

:Top
CALL OutputCurTime.cmd
ECHO Executing VMSTAT for SQL instance "%INSTANCE%" (pid %SQLPID%)...
VMSTAT %SQLPID%
ECHO.
sleep %SLEEPTIME%
GOTO :Top



REM -- Old version (below) is invoked once and just dumps for every sqlservr.exe pid. New version 
REM -- (above) is invoked once for every instance, and calls the GetSQLInstancePID to convert an 
REM -- instance name into a PID that VMSTAT can use. 
REM :Top
REM FOR /F "tokens=1 delims= " %%i IN ('tlist -p sqlservr.exe') DO CALL :RunForPid %%i
REM sleep %SLEEPTIME%
REM GOTO Top
REM 
REM :RunForPid
REM SETLOCAL
REM SET SQLSERVRPID=%1
REM 
REM ECHO Executing VMSTAT for SQL pid %SQLSERVRPID%...
REM CALL OutputCurTime.cmd
REM VMSTAT %SQLSERVRPID%
REM ECHO.
REM 
REM ENDLOCAL
REM GOTO :eof
