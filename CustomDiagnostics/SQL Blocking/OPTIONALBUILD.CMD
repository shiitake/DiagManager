REM Make sure we have the most up-to-date set of CloneDB files. 

SETLOCAL
SET PSSDIAG_BUILD_PATH=%1

rem -- Strip off quote delimiters from around PSSDIAG_BUILD_PATH. 
if (^%PSSDIAG_BUILD_PATH:~-1%) == (^") set PSSDIAG_BUILD_PATH=%PSSDIAG_BUILD_PATH:"=%
REM -- Strip out trailing backslash if present at end of PSSDIAG_BUILD_PATH. 
if (^%PSSDIAG_BUILD_PATH:~-1%) == (^\) set PSSDIAG_BUILD_PATH=%PSSDIAG_BUILD_PATH:~0,-1%

echo CALL "%PSSDIAG_BUILD_PATH%\..\SharedDiagnostics\CloneDB\OPTIONALBUILD.CMD" "%PSSDIAG_BUILD_PATH%"
CALL "%PSSDIAG_BUILD_PATH%\..\SharedDiagnostics\CloneDB\OPTIONALBUILD.CMD" "%PSSDIAG_BUILD_PATH%"

ENDLOCAL
