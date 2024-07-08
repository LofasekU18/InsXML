using System.Configuration;
using System.Xml.Linq;
using InsXml;



/*TODO:

- choose if is subject FO or PO, use GetRowFromDatabase, store to list of strings or make independent class, fill to 9 values if IC, 
- save to file 1/3
- SQL for GetRowFromDatabase, SELECT SUM of UP, usn/pov(some logic to use right document and right text for 6655 or 7865) 
- Some menu
- test if i need I/O method to db in async

*/
//"01881485"
// "750720/0316"



var listResultFromDb = OleConnect.GetRowFromDatabase<List<string>>("SELECT TOP 1 * FROM Entry;"); // Querry SELECT Adresy.IC, Adresy.RC FROM Povinni INNER JOIN ADRESY WHERE Povinni.HlavaI=true AND Povinni.HlavaII=true AND Povinni.HlavaIII=true
System.Console.WriteLine(listResultFromDb[0] + listResultFromDb[1]);

string a = "01881485";

switch (IntendedID.Intended(a))
{
    case 1:
        DataIsirRC resultFromIsir = ParseXmlToData.CreateDataRC(await SearchSoap.SoapSearchingRC(a));
        if (resultFromIsir != null)
            File.WriteAllText("prihlaska.xml", Test.CreateXmlFo(resultFromIsir, OleConnect.GetRowFromDatabase<DataMsAccess>("SELECT TOP 1 * FROM Entry;")));
        break;

    case 2:
        DataIsirIC resultFromIsir2 = ParseXmlToData.CreateDataIC(await SearchSoap.SoapSearchingIC(a));
        if (resultFromIsir2 != null)
            File.WriteAllText("prihlaska.xml", Test.CreateXmlPo(resultFromIsir2, OleConnect.GetRowFromDatabase<DataMsAccess>("SELECT TOP 1 * FROM Entry;")));
        break;
    case 0:
        System.Console.WriteLine("Chyba");
        break;



}









