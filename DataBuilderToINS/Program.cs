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


// var listResultFromDb = OleConnect.GetRowFromDatabase<List<string>>("SELECT TOP 1 * FROM Entry;"); // Querry SELECT Adresy.RC,Adresy.IC FROM Povinni INNER JOIN ADRESY ON Povinni.[Nazov subjektu]=Adresy.[Nazov subjektu] WHERE Povinni.HlavaI=true AND Povinni.HlavaII=true AND Povinni.HlavaIII=true AND Povinni.[Ex cislo] LIKE {inputExko};
string inputExko = null;
while (inputExko == null)
{
    Console.WriteLine("Zadej exko");
    inputExko = Console.ReadLine();
}

// PrimaryData primaryData = OleConnect.GetRowFromDatabase<PrimaryData>("SELECT TOP 1 * FROM Entry;");
PrimaryData primaryData = new("750720/0316", "01881485");
System.Console.WriteLine(primaryData.RC);

if (primaryData.RC is null && primaryData.IC is null)
{
    System.Console.WriteLine("Nenalezen povinny, stiskni ENTER pro ukonceni");
    Console.ReadLine();
    Environment.Exit(0);

}
if (primaryData.RC is not null)
{
    DataIsirRC resultFromIsir2 = ParseXmlToData.CreateDataRC(await SearchSoap.SoapSearchingRC(primaryData.RC));
    if (resultFromIsir2 != null)
        File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "prihlaska.xml"), Test.CreateXmlFo(resultFromIsir2, OleConnect.GetRowFromDatabase<DataMsAccess>("SELECT TOP 1 * FROM Entry;")));
}
else
{
    DataIsirIC resultFromIsir = ParseXmlToData.CreateDataIC(await SearchSoap.SoapSearchingIC(primaryData.IC));
    if (resultFromIsir != null)
        File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "prihlaska.xml"), Test.CreateXmlPo(resultFromIsir, OleConnect.GetRowFromDatabase<DataMsAccess>("SELECT TOP 1 * FROM Entry;")));
}

record PrimaryData(string RC, string IC);







/******************************************************************************
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
*/









