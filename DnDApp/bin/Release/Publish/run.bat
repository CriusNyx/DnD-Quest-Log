SET Line=%~dp0
IF "%Line:~-1%"=="\" SET Line=%Line:~0,-1%
echo %Line% — will output: C:\Windows
iisexpress /path:"%Line%" /port:80