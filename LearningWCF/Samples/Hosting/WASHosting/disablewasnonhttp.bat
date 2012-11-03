REM Setting up WAS for TCP, MSMQ, Named Pipes protocols
%windir%\system32\inetsrv\appcmd.exe set site "Default Web Site" -bindings.[protocol='net.pipe',bindingInformation='*']
%windir%\system32\inetsrv\appcmd.exe set site "Default Web Site" -bindings.[protocol='net.tcp',bindingInformation='9200:*']
pause
