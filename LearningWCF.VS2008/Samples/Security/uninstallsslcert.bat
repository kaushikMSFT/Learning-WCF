REM Removing the 'localhost' SSL certificate for IIS port 80 communications

netsh http delete sslcert ipport=0.0.0.0:443 

pause
