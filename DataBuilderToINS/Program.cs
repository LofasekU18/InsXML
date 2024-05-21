using InsXml;
using System.Net.NetworkInformation;
using System.Xml.Linq;
/*TODO:
1. SOAP request to isir
2. Parse answer from XML to object - dluznik
3. Connect to db via EF
4. Parse data from db to object - celkova castka(7865/6655) - vymozna castka, usn/pov, 


*/
string xml = @"<Person>
                           <Name>John Doe</Name>
                           <Age>30</Age>
                           <Gender>Male</Gender>
                       </Person>";

XElement personElement = XElement.Parse(xml);
Person person = new Person
{
    Name = (string)personElement.Element("Name"),
    Age = (int)personElement.Element("Age"),
    Gender = (string)personElement.Element("Gender")
};

Console.WriteLine($"Name: {person.Name}");
Console.WriteLine($"Age: {person.Age}");
Console.WriteLine($"Gender: {person.Gender}");

string result = await SearchSoap.SoapSearchingIC("01881485");
string result2 = await SearchSoap.SoapSearchingRC("750720/0316");



XElement elements = XElement.Parse(result);
DataIsirIC dataIsirIC = new DataIsirIC
{
    // Ic = personElement.Element(XName ic),
};
System.Console.WriteLine(dataIsirIC.Ic);
Console.WriteLine("Hotovo");

// XElement elements2 = XElement.Parse(result2);
// var listOfEllements2 = elements2.Elements().ToList();
// foreach (var item in listOfEllements2)
// {
//     System.Console.WriteLine(item);
// }
// Console.WriteLine("Hotovo");


public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
}
class DataIsir
{
    public int CisloSenatu { get; set; }
    public int DruhVec { get; set; }
    public int BcVec { get; set; }
    public int Rocnik { get; set; }
    public string NazevOrganizace { get; set; }
    public string NazevOsoby { get; set; }
    public string Mesto { get; set; }
    public string Ulice { get; set; }
    public string CisloPopisne { get; set; }
    public string Okres { get; set; }
    public string Psc { get; set; }
}

class DataIsirIC : DataIsir
{
    public string Ic { get; set; }
}
class DataIsirRC : DataIsir
{
    public string Rc { get; set; }
    public string Jmeno { get; set; }
}




