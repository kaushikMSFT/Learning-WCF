certmgr -del -r localmachine -s TrustedPeople -c -n MyClientCert
certmgr -del -r localmachine -s TrustedPeople -c -n MyServiceCert
certmgr -del -r localmachine -s My -c -n MyClientCert
certmgr -del -r localmachine -s My -c -n MyServiceCert

makecert.exe  -sr LocalMachine -ss MY  -pe -sky exchange -n "CN=MyClientCert"  MyClientCert.cer
makecert.exe  -sr LocalMachine -ss MY  -pe -sky exchange -n "CN=MyServiceCert" MyServiceCert.cer


certmgr.exe -add -r localmachine -s My -c -n MyClientCert -r  localmachine -s TrustedPeople
certmgr.exe -add -r localmachine -s My -c -n MyServiceCert -r localmachine -s TrustedPeople



