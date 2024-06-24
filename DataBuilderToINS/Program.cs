using System.Configuration;
using InsXml;



/*TODO:
1. SOAP request to isir - 1
2. Parse answer from XML to object - dluznik - 1
3. Create method to connect in db and select via string sql, use for everthing from data
4. Parse data from db to xlement - celkova castka(7865/6655) - vymozna castka, usn/pov, and create xml


Create class for IC/RC in first touch
Create class for ExTitul(datum, ex titul cislo, vydal),Money(7865/6655, odecist),...
Write SQL, store to app.config
Class -> method to create xml
Define Main to run all of this shit



*/
//"01881485"
// "750720/0316"

System.Console.WriteLine("Zadej exko");
string a = Console.ReadLine();
var test3 = OleConnect.GetRowFromDatabase<DataMsAccess>("SELECT TOP 3 * FROM Entry;");
// var test4 = OleConnect.GetRowFromDatabase<dluznikB>(ConfigurationManager.AppSettings["Query1"]);
var test5 = OleConnect.GetRowFromDatabase<string>(ConfigurationManager.AppSettings["Query1"]);
System.Console.WriteLine(test3.ToString());
System.Console.WriteLine(test3.GetType());
// System.Console.WriteLine(test4.ToString());
// System.Console.WriteLine(test4.GetType());
System.Console.WriteLine(test5.ToString());
System.Console.WriteLine(test5.GetType());

string a = "750720/0316";

switch (IntendedID.Intended(a))
{
    case 1:
        DataIsirRC test2 = ParseXmlToData.CreateDataRC(await SearchSoap.SoapSearchingRC(a));
        if (test2 != null)
            System.Console.WriteLine(test2.Rc + ", " + test2.Mesto + " " + test2.DatumNarozeni);
        break;

    case 2:
        DataIsirIC test = ParseXmlToData.CreateDataIC(await SearchSoap.SoapSearchingIC(a));
        if (test != null)
            System.Console.WriteLine(test.Ic + ", " + test.Mesto);
        break;
    case 0:
        System.Console.WriteLine("Chyba");
        break;

}









