using System.Xml.Linq;
namespace InsXml;
public static class ParseXmlToData
{
    public static XElement ResponseParse(string response)
    {
        if (response != null)
        {
            XElement elements = XElement.Parse(response);
            XNamespace soap = "http://schemas.xmlsoap.org/soap/envelope/";
            XNamespace ns2 = "http://isirws.cca.cz/types/";

            XElement responseElement = elements.Element(soap + "Body")?.Element(ns2 + "getIsirWsCuzkDataResponse");
            if (elements.ContainsTag("data"))
            {
                XElement dataElement = responseElement?.Element("data");
                return dataElement;
            }
        }
        else
            System.Console.WriteLine("Nenasel jsem data v odpovedi");
        return null;
        // XElement stavElement = responseElement?.Element("stav");
    }

    public static DataIsirIC CreateDataIC(string response)
    {
        XElement dataElement = ResponseParse(response);
        if (dataElement != null)
        {
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
                Psc = (string)dataElement?.Element("psc"),
            };
        }
        else
            Console.WriteLine("Nenasel jsem na justici povinneho");
        return new DataIsirIC();
    }



    public static DataIsirRC CreateDataRC(string response)
    {
        XElement dataElement = ResponseParse(response);
        if (dataElement != null)
        {

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
                Psc = (string)dataElement?.Element("psc"),
            };
        }
        else
            Console.WriteLine("Nenasel jsem na justici povinneho");
        return new DataIsirRC();


    }
    public static bool ContainsTag(this XElement element, string tagName)
    {
        return element.Descendants(tagName).Any();
    }
}