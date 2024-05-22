using InsXml;
using System.Net.NetworkInformation;
using System.Xml.Linq;
/*TODO:
1. SOAP request to isir
2. Parse answer from XML to object - dluznik
3. Connect to db via EF
4. Parse data from db to object - celkova castka(7865/6655) - vymozna castka, usn/pov, 


*/


string result = await SearchSoap.SoapSearchingIC("01881485");
string result2 = await SearchSoap.SoapSearchingRC("750720/0316");

static XElement ResponseParse(string response)
{
    XElement elements = XElement.Parse(response);
    XNamespace soap = "http://schemas.xmlsoap.org/soap/envelope/";
    XNamespace ns2 = "http://isirws.cca.cz/types/";

    XElement responseElement = elements.Element(soap + "Body")?.Element(ns2 + "getIsirWsCuzkDataResponse");
    XElement dataElement = responseElement?.Element("data");
    return dataElement;
    // XElement stavElement = responseElement?.Element("stav");
}

string date = "1975-07-20Z";


DataIsirIC test = CreateDataIC(result);
DataIsirRC test2 = CreateDataRC(result2);

System.Console.WriteLine(test.Ic + ", " + test.Mesto);
System.Console.WriteLine(test2.Rc + ", " + test2.Mesto + " " + test2.DatumNarozeni);




static DataIsirIC CreateDataIC(string response)
{
    XElement dataElement = ResponseParse(response);
    return new DataIsirIC
    {
        Ic = (string)dataElement?.Element("ic"),
        CisloSenatu = (int)dataElement?.Element("cisloSenatu"),
        BcVec = (int)dataElement?.Element("bcVec"),
        Rocnik = (int)dataElement?.Element("rocnik"),
        NazevOrganizace = (string)dataElement?.Element("nazevOrganizace"),
        NazevOsoby = (string)dataElement?.Element("nazevOsoby"),
        Mesto = (string)dataElement?.Element("mesto"),
        Ulice = (string)dataElement?.Element("ulice"),
        CisloPopisne = (string)dataElement?.Element("cisloPopisne"),
        Okres = (string)dataElement?.Element("okres"),
        Psc = (string)dataElement?.Element("psc"),
    };
};
static DataIsirRC CreateDataRC(string response)
{
    XElement dataElement = ResponseParse(response);
    return new DataIsirRC
    {
        Rc = (string)dataElement?.Element("rc"),
        CisloSenatu = (int)dataElement?.Element("cisloSenatu"),
        BcVec = (int)dataElement?.Element("bcVec"),
        Rocnik = (int)dataElement?.Element("rocnik"),
        NazevOrganizace = (string)dataElement?.Element("nazevOrganizace"),
        DatumNarozeni = DateOnly.Parse(((string)dataElement?.Element("datumNarozeni"))?.Substring(0, ((string)dataElement?.Element("datumNarozeni")).Length - 1)),
        Jmeno = (string)dataElement?.Element("jmeno"),
        NazevOsoby = (string)dataElement?.Element("nazevOsoby"),
        Mesto = (string)dataElement?.Element("mesto"),
        Ulice = (string)dataElement?.Element("ulice"),
        CisloPopisne = (string)dataElement?.Element("cisloPopisne"),
        Okres = (string)dataElement?.Element("okres"),
        Psc = (string)dataElement?.Element("psc"),
    };
};
