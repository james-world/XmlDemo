using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.IO;

var cert = X509Certificate2.CreateFromPemFile("cert.pem", "key.pem");
var rsa = cert.GetRSAPrivateKey();

var doc = new XmlDocument();
doc.LoadXml("<root><child>value</child></root>");

SignedXml signedXml = new (doc)
{
    SigningKey = rsa,
};

Reference reference = new ()
{
    Uri = "" 
};

XmlDsigEnvelopedSignatureTransform env = new();
reference.AddTransform(env);

signedXml.AddReference(reference);
signedXml.ComputeSignature();

XmlElement xmlDigitalSignature = signedXml.GetXml();

doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));

// write xml to string
var sw = new StringWriter();
var xw = XmlWriter.Create(sw);
doc.WriteTo(xw);
xw.Flush();

Console.WriteLine(sw.ToString());



