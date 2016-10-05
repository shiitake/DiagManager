@ECHO OFF

SETLOCAL
REM ----------------------------------------------------------------------
REM Sample PSSDIAG custom util command line to trigger action when 
REM SQL min free bytes drops below 100MB: 
REM
REM    vmparse.cmd "%output_path%" 100000000 %instance%
REM
REM Customize actions to take when in the ":Notify" section at the bottom of 
REM this file. 
REM 
REM Note: This will only work for monitoring a local SQL instance. 
REM ----------------------------------------------------------------------

REM Default min free bytes is 100MB. 

SET PSSDIAGOUTPUT=%1
IF "%PSSDIAGOUTPUT%" NEQ "" (
  SET PSSDIAGOUTPUT=%PSSDIAGOUTPUT:"=%
)
SET MINFREE=%2
IF "%MINFREE%"=="" SET MINFREE=100000000
SET SQLINSTANCE=%3


ECHO Retrieving PID for SQL instance "%SQLINSTANCE%": 
CALL GetSQLInstancePID.CMD %SQLINSTANCE%
IF "%SQLPID%"=="" (
  ECHO WARNING: Failed to retrieve SQL PID -- using "vmstat sqlservr.exe". 
  SET SQLPID=sqlservr.exe
)

ECHO Minimum free byte threshold: %MINFREE%
ECHO Tracking total free bytes for SQL PID %SQLPID%...
:loop
CALL :GetTotFree
IF %TOTFREE% LSS %MINFREE% (
  ECHO WARNING: Total Free Bytes has dropped below %MINFREE%. 
  REM Take action on first occurrence only. 
  IF "%NOTIFIED%" NEQ "Yes" (
    CALL :Notify
    SET NOTIFIED=Yes
  )
)
sleep 30
GOTO :loop

:GetTotFree
FOR /F "tokens=3-5 delims= " %%I IN ('vmstat %SQLPID% ^| findstr Free') DO (
  SET MAXFREE=%%I
  SET AVGFREE=%%J
  SET BLKCNT=%%K
)
SET /A TOTFREE=%AVGFREE% * %BLKCNT%
Call OutputCurTime.cmd TotalFreeBytes=%TOTFREE%
GOTO :eof

ENDLOCAL



:Notify
REM Insert custom commands here. These will be run when min free condition is met. 
REM Notify admin, collect dump, ...?
GOTO :eof
