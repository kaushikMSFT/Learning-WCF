REM Setting up WAS for TCP, MSMQ, Named Pipes protocols
%windir%\system32\inetsrv\appcmd.exe set site "Default Web Site" -+bindings.[protocol='https',bindingInformation='*:443']
pause
