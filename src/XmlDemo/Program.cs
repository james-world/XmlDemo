using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.IO;

var cert = X509Certificate2.CreateFromPemFile("cert.pem", "key.pem");


Console.WriteLine(cert);



