@ECHO ---- %date% %time% - Starting INITBLD.CMD

@ECHO.
@ECHO ---- Delete all the files in the BUILD dir 
DEL /Q /S ".\build\*.*" 
echo hi >.\build\create.dir
@ECHO.
@ECHO ---- Remove any subdirectories in BUILD dir 
FOR /D %%I IN (".\build\*.*") DO RMDIR /S /Q %%I

@ECHO.
REM SSVER is 7, 8, or 9
SET SSVER=%1
REM Platform is I386, IA64, or X64
SET PLATFORM=%2
SET SSFAMILY=PRE_YUKON
IF %SSVER% GEQ 9 SET SSFAMILY=POST_YUKON

@ECHO.
@ECHO ---- 1. Copy pristine files from root PRISTINE dir 
CALL :CopyDir .\pristine
@ECHO.
@ECHO ---- 2. Copy version-specific files (7/8/9)
CALL :CopyDir .\pristine\%SSVER%
@ECHO.
@ECHO ---- 3. Copy version "family" files (pre-Yukon/post-Yukon)
CALL :CopyDir .\pristine\%SSFAMILY%

copy diagutil.exe .\build

copy pssdiag.cmd .\build
if "%SSVER%" == "10" del .\build\pssdiag.exe
rem if "%SSVER%" == "10" del .\build\MSDiagProcs.sql


GOTO :eof




:CopyDir 
SETLOCAL
SET SRCFILEPATH=%*
xcopy "%SRCFILEPATH%\*.*" ".\build\" /Y /C /I
xcopy "%SRCFILEPATH%\%PLATFORM%\*.*" ".\build\" /Y /C /I

ENDLOCAL
GOTO :eof
