@ECHO OFF
REM  Deletes all but the 12 most recent Profiler trace files (same for perfmon .BLG 
REM  files). To use this in PSSDIAG, include the following custom utility definition 
REM  in PSSDIAG.INI: 
REM
REM     StartupUtility=1
REM     StartupUtilityTemplate=
REM     StartupUtilityName=start DeleteOldTrcFiles.cmd %output_path%
REM
REM  Be sure to include all of the following files in the PSSDIAG package that you 
REM  send: 
REM     DeleteOldTrcFiles.cmd
REM     DeleteOldFiles.cmd
REM     sleep.exe

set filestokeep=%1
set directory=%2
rem Strip off quote delimiters from around directory.
if (^%directory:~-1%) == (^") set directory=%directory:"=%

:top
call OutputCurTime.cmd
call DeleteOldFiles.cmd "%directory%" *.trc %filestokeep%
call DeleteOldFiles.cmd "%directory%" *.blg %filestokeep%
sleep 30
goto top
