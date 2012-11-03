REM Installing the 'localhost' SSL certificate for IIS port 80 communications
REM NOTE: Requires 'localhost' certificate to already be installed to the local machine certificate store


netsh http add sslcert ipport=0.0.0.0:443 certhash=c137df009207406b6f262010a87457bb3592e13e appid={BCC1A476-DEC7-4f83-AF47-187DDD81A597}

pause
