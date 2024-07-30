namespace InsXml;

public class DataMsAccess
{
    public string RozhodnutiVydal { get; set; }
    public string RozhodnutiTyp { get; set; }
    public string RozhodnutiCislo { get; set; }
    public DateOnly RozhodnutiDatum { get; set; }
    // public int PenizeVymozeno { get; set; }
    public override string ToString()
    {
        return $"Rozhodnutí Vydal: {RozhodnutiVydal}, Rozhodnutí Typ: {RozhodnutiTyp}, " +
               $"Rozhodnutí Číslo: {RozhodnutiCislo}, Rozhodnutí Datum: {RozhodnutiDatum:yyyy-MM-dd} \n";
    }
}




