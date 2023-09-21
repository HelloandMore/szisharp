@echo off
set /p comment="Add meg a commentet > "

git add .
if not %errorlevel%==0 (goto :error)

git commit -m "%comment% %date%"
if not %errorlevel%==0 (goto :error)

timeout 5 /nobreak
exit /b

:error
echo.
echo.
net helpmsg %errorlevel%
timeout 5 /nobreak > nul
pause
exit /b