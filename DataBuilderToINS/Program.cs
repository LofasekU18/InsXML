using InsXml;
using System.Net.NetworkInformation;

/*TODO:
1. SOAP request to isir
2. Parse answer from XML to object - dluznik
3. Connect to db via EF
4. Parse data from db to object - celkova castka(7865/6655) - vymozna castka, usn/pov, 


*/



DataIsirIC test = ParseXmlToData.CreateDataIC(await SearchSoap.SoapSearchingIC("01881485"));
DataIsirRC test2 = ParseXmlToData.CreateDataRC(await SearchSoap.SoapSearchingRC("750720/0316"));

System.Console.WriteLine(test.Ic + ", " + test.Mesto);
System.Console.WriteLine(test2.Rc + ", " + test2.Mesto + " " + test2.DatumNarozeni);





