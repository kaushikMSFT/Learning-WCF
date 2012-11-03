REM Setting up this application, /WASHost, for TCP, MSMQ, Named Pipes protocols
%windir%\system32\inetsrv\appcmd.exe set app "Default Web Site/WASHost" /enabledProtocols:http
pause
