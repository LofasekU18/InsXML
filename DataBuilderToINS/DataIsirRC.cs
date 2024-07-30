public class DataIsirRC : DataIsir
{
    public string Rc { get; set; }
    public string Jmeno { get; set; }

    public DateOnly DatumNarozeni { get; set; }

    public override string ToString()
    {
        return $"{Rc}, Jmeno: {Jmeno}, {DatumNarozeni}  Cislo Senatu: {CisloSenatu}, BcVec: {BcVec}, Rocnik: {Rocnik}, " +
              $"Nazev Organizace: {NazevOrganizace}, Prijmeni: {NazevOsoby}, " +
              $"Mesto: {Mesto}, Ulice: {Ulice}, Cislo Popisne: {CisloPopisne}, PSC: {Psc} \n";
    }
}




