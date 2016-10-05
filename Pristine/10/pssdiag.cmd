@echo off
IF "%1"=="?" GOTO :PrintUsage
IF "%1"=="-?" GOTO :PrintUsage
IF "%1"=="/?" GOTO :PrintUsage


set launchdir=%~dp0
if "%1"=="/R"  goto Register
if "%1"=="/r"  goto Register
if "%1"=="stop" goto ServiceOp
if "%1"=="STOP" goto ServiceOp
if "%1"=="START" goto ServiceOp
if "%1"=="start" goto ServiceOp
if "%1"=="/U" goto ServiceOp
if "%1"=="/u" goto ServiceOp

for /F "tokens=1,2 delims==~"  %%i IN ('diagutil.exe') DO set sqlver=%%i
for /F "tokens=1,2 delims==~"  %%i IN ('diagutil.exe') DO set toolsbin=%%j
if "%toolsbin%"=="" set toolsbin=C:\Program Files\Microsoft SQL Server\100\Tools\Binn

set diagEXE="%toolsbin%sqldiag.exe"
echo sqldiag path:  %diagEXE%

 %diagEXE% /O output /I pssdiag.xml /P %1 %2 %3 %4 %5 %6 %7 %8 %9

goto eof


:Register

 %diagEXE% /R "/O%launchdir%output" "/I%launchdir%pssdiag.xml" "%2" "%3" "%4" "%5" "%6" "%7"
goto EOF

:ServiceOp
	%diagEXE%  %1
@echo off
goto eof



:PrintUsage
@echo off
  echo  . 
  ECHO   1-- to start pssdiag as an application (most frequently used), just type pssdiag.cmd.  Ctrl+C to stop it
  ECHO  2-- to register as a serivce, do "pssdiag.cmd /R"
  echo  3-- to start pssdiag service, do "pssdiag.cmd START
  echo  4-- to stop pssdiag service, do "pssdiag.cmd STOP"
  echo  5-- to unregister pssdiag service, do "pssdiag.cmd /U"



:EOF