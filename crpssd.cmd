@echo.
@echo ---- %date% %time% CRPSSD.EXE starting

cd %1

..\cabarc -r -p n pssd.cab *.*
copy /b ..\extract.exe+pssd.cab %2


