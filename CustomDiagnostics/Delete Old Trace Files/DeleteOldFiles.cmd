@echo off
if (%1)==() goto usage
if (%2)==() goto usage
if (%3)==() goto usage

set directory=%1
set filespec=%2
set filestokeep=%3

rem set directory=this is a test

rem Strip off quote delimiters from around directory.
if (^%directory:~-1%) == (^") set directory=%directory:"=%
rem Strip out trailing backslash if present at end of directory. 
if (%directory:~-1%) == (\) set directory=%directory:~0,-1%

echo.
echo Deleting all but the %filestokeep% newest files matching filespec %filespec% in directory "%directory%". 

set numfiles=0
set filesdeleted=0
rem Find out how many files there are that match %filespec%. 
for /f "tokens=*" %%i in ('dir /b /o-d "%directory%\%filespec%"') do (
	set /a numfiles+=1
	call :process_file "%directory%\%%i"
)
echo Total files matching filespec %directory%\%filespec%: %numfiles%
echo Number of files to keep: %filestokeep%
echo Total files deleted: %filesdeleted%

goto :eof

:process_file
if %numfiles% GTR %filestokeep% (
	echo Deleting file: %*
	del %*
	set /a filesdeleted=%filesdeleted%+1
)
goto :eof


:usage
echo Usage: 
echo.
echo     delete_oldest_files.cmd ^<directory^> ^<filespec^> ^<filestokeep^>
echo.
echo For example, to delete all but the 5 most recent Profiler trace files in C:\trace: 
echo. 
echo     delete_oldest_files.cmd c:\trace *.trc 5
echo.

