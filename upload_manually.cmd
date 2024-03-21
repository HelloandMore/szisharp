@echo off
pushd %~0\..
set /p comment="Add meg a commentet > "

@echo on
git add .
set adderr=%errorlevel%
@echo off
if not %adderr%==0 (goto :error)

@echo on
git commit -m "%date% - %comment%"
set commiterr=%errorlevel%
@echo off
if not %commiterr%==0 (goto :error)

@echo on
git push
@echo off
timeout 5 /nobreak
exit /b

:error
echo.
echo.
net helpmsg %errorlevel%
timeout 5 /nobreak > nul
pause
exit /b