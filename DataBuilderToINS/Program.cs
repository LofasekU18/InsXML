using InsXml;



/*TODO:
1. SOAP request to isir
2. Parse answer from XML to object - dluznik
3. Connect to db via EF
4. Parse data from db to object - celkova castka(7865/6655) - vymozna castka, usn/pov, 


*/
//"01881485"
// "750720/0316"
string a = "750720/031";

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









