# Signing XML

Created a self-signed cert with:

    openssl req -nodes -newkey rsa:4096 -x509 -days 1000 -subj '/CN=localhost' -keyout key.pem -out cert.pem -config client_cert_ext.cnf
