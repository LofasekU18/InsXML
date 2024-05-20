using InsXml;
using System.IO;
using System.Xml.Linq;
/*TODO:
1. SOAP request to isir
2. Parse answer from XML to object - dluznik
3. Connect to db via EF
4. Parse data from db to object - celkova castka(7865/6655) - vymozna castka, usn/pov, 


*/

string result = await SearchSoap.SoapSearchingIC("01881485");
string resul2 = await SearchSoap.SoapSearchingRC("750720/0316");
XElement elements = XElement.Parse(result);
var listOfEllements = elements.Elements().ToList();
foreach (var item in listOfEllements)
{
    System.Console.WriteLine(item);
}
Console.WriteLine("Hotovo");
XElement elements2 = XElement.Parse(result);
var listOfEllements2 = elements2.Elements().ToList();
foreach (var item in listOfEllements)
{
    System.Console.WriteLine(item);
}
Console.WriteLine("Hotovo");

class Rizeni
{
    public string IC { get; set; }
}



