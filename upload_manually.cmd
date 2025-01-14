@echo off
title Auto Git
pushd "%~dp0"

net file 1>nul 2>nul
if %errorlevel%==0 (
    goto :begin
) else (
    powershell.exe Start-Process '%~0' -verb runas
    exit /b %errorlevel%
)

:begin
set /p selection="1. Push vagy 2. Pull > "

if %selection%==1 (
    git add .
    git status
    goto :push
) else if %selection%==2 (
    git pull
    goto :end
) else (
    echo Hibás választás!
    goto :begin
)

:push
set /p commitmessage="Commit message: "
git commit -m "%date% - %commitmessage%"
git push

:end
net helpmsg %errorlevel%
timeout 5 /nobreak > nul
exit /b %errorlevel%githju
