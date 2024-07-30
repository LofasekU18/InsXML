public class DataIsirIC : DataIsir
{
    public string Ic { get; set; }
     public override string ToString()
    {
         return $"{Ic}, Cislo Senatu: {CisloSenatu}, BcVec: {BcVec}, Rocnik: {Rocnik}, " +
               $"Nazev Organizace: {NazevOrganizace}, Nazev Osoby: {NazevOsoby}, " +
               $"Mesto: {Mesto}, Ulice: {Ulice}, Cislo Popisne: {CisloPopisne}, PSC: {Psc} \n";
    }
}






