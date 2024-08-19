using System.Runtime.CompilerServices;
using System.Xml.Linq;
namespace InsXml;


public static class XMLSaver

{
	// public static XElement CreateXElement<T>(string tagName, T data) // generic method to create XELEMENT, just first opinion, its too complicate to create such long xml one by one
	// {

	// 	return new XElement(tagName, data);
	// }

	//Krajského soudu v Ústí nad Labem - pobočka v Liberci
	public static string SelectJudge(string result) => result switch
	{
		"Městský soud v Praze" => "MSPH",
		"Krajský soud v Praze" => "KSPH",
		"Krajský soud v Českých Budějovicích" => "KSCB",
		"Krajský soud v Plzn" => "KSPL",
		"Krajský soud v Ústí nad Labem" => "KSUL",
		"Krajský soud v Ústí nad Labem – pobočka v Liberci" => "KSLB",
		"Krajský soud v Hradci Králové" => "KSHK",
		"Krajský soud v Hradci Králové – pobočka v Pardubicích" => "KSPA",
		"Krajský soud v Brně" => "KSBR",
		"Krajský soud v Ostravě" => "KSOS",
		"Krajský soud v Ostravě - pobočka v Olomouci" => "KSOL",
		_ => "Midweek day."
	};
	private static string SelectValue(DateOnly dateOnly)
	{
		DateOnly comparisonDate = new DateOnly(2017, 4, 1);
		if (dateOnly > comparisonDate)
		{
			return "6655";
		}
		else return "7865";
	}

	private static string SelectValueText(string value)
	{
		if (value == "6655")
		{
			return "Odměna soudního exekutora ve výši 2.000,00 Kč (§ 6 odst. 3 vyhl. č. 330/2001 Sb.), paušálně určené hotové výdaje ve výši 3.500,00 Kč (§ 13 odst. 1 vyhl. č. 330/2001 Sb.) a DPH 21 % ve výši 1.155,00 Kč (§ 87 odst. 1 zákona č. 120/2001 Sb.), vše dle exekutorského tarifu.&#xD;&#xD;Doposud vymožená částka na náklady exekuce: 0,- Kč.&#xD;&#xD;Dle nálezu Ústavního soudu České republiky, č.j. IV. ÚS 3250/14, ze dne 1.7.2016, Soudní exekutor má vůči povinnému nárok na náhradu nákladů exekuce (tj. na odměnu a náhradu hotových výdajů) v právními předpisy stanovené minimální výši již v době zahájení insolvenčního řízení, jelikož tento nárok mu vznikl již v okamžiku, kdy byla vůči němu exekuce nařízena a exekutor byl pověřen jejím provedením, a to bez ohledu na to, že jím do doby zahájení řízení insolvenčního nebylo v rámci exekuce vymoženo žádné plnění a zároveň nebyl vydán příkaz k úhradě nákladů exekuce. Dle § 11 odst. 2 vyhl. Č. 330/2001 Sb., exekučního tarifu, má exekutor právo na odměnu ( v minimální výši 3 000,- Kč) i v případě, zanikne-li jeho oprávnění k vedení exekuce, náleží tato odměna exekutorovi tím spíše v případe, kdy jeho oprávnění k vedení exekuce nezaniklo, nýbrž ze zákona došlo pouze k tomu, že v provádění exekuce nelze po dobu trvání účinků zahájeného insolvečního řízení pokračovat.&#xD;&#xD;V případě zasílání plateb v insolvenčím řízení, Vás žádáme o uvedení čísla identifikátor platby uvedeného v přihlášce jako variabilní symbol platby.";
		}
		else
			return "Odměna soudního exekutora ve výši 3.000,00 Kč (§ 6 odst. 3 vyhl. č. 330/2001 Sb.), paušálně určené hotové výdaje ve výši 3.500,00 Kč (§ 13 odst. 1 vyhl. č. 330/2001 Sb.) a DPH 21 % ve výši 1.365,00 Kč (§ 87 odst. 1 zákona č. 120/2001 Sb.), vše dle exekutorského tarifu.&#xD;&#xD;Doposud vymožená částka na náklady exekuce: 0,- Kč.&#xD;&#xD;Dle nálezu Ústavního soudu České republiky, č.j. IV. ÚS 3250/14, ze dne 1.7.2016, Soudní exekutor má vůči povinnému nárok na náhradu nákladů exekuce (tj. na odměnu a náhradu hotových výdajů) v právními předpisy stanovené minimální výši již v době zahájení insolvenčního řízení, jelikož tento nárok mu vznikl již v okamžiku, kdy byla vůči němu exekuce nařízena a exekutor byl pověřen jejím provedením, a to bez ohledu na to, že jím do doby zahájení řízení insolvenčního nebylo v rámci exekuce vymoženo žádné plnění a zároveň nebyl vydán příkaz k úhradě nákladů exekuce. Dle § 11 odst. 2 vyhl. Č. 330/2001 Sb., exekučního tarifu, má exekutor právo na odměnu ( v minimální výši 3 000,- Kč) i v případě, zanikne-li jeho oprávnění k vedení exekuce, náleží tato odměna exekutorovi tím spíše v případe, kdy jeho oprávnění k vedení exekuce nezaniklo, nýbrž ze zákona došlo pouze k tomu, že v provádění exekuce nelze po dobu trvání účinků zahájeného insolvečního řízení pokračovat.&#xD;&#xD;V případě zasílání plateb v insolvenčím řízení, Vás žádáme o uvedení čísla identifikátor platby uvedeného v přihlášce jako variabilní symbol platby.";

	}



	public static string CreateXmlFo(DataIsirRC dataIsirRc, DataMsAccess dataMsAccess, string inputExko)
	{
		// System.Console.WriteLine(dataIsirRc.ToString());
		// System.Console.WriteLine(dataMsAccess.ToString());
		// System.Console.WriteLine(inputExko);
		string valueMoney = SelectValue(dataMsAccess.RozhodnutiDatum);
		return new string($"""
<?xml version="1.0" encoding="UTF-8"?>
<ELPP verze="1.4.2">
	<prilohy/>
	<listinne_prilohy/>
	<hlavicka>
		<spisznacka>
			<soud>{SelectJudge(dataIsirRc.NazevOrganizace)}</soud>
			<senat>{dataIsirRc.CisloSenatu}</senat>
			<rejstrik>INS</rejstrik>
			<bc>{dataIsirRc.BcVec}</bc>
			<rocnik>{dataIsirRc.Rocnik}</rocnik>
		</spisznacka>
	</hlavicka>
	<dluznik fo_po_switch="1">
		<fyzicka_osoba>
			<osobni_udaje>
				<osoba>
					<prijmeni>{dataIsirRc.NazevOsoby}</prijmeni>
					<jmeno>{dataIsirRc.Jmeno}</jmeno>
				</osoba>
				<statni_prislusnost/>
				<datum_narozeni>{dataIsirRc.DatumNarozeni}</datum_narozeni>
				<rodne_cislo>{dataIsirRc.Rc}</rodne_cislo>
				<osobni_stav/>
			</osobni_udaje>
			<adresa>
				<ulice>{dataIsirRc.Ulice}</ulice>
				<cpop>{((dataIsirRc.CisloPopisne.IndexOf("/") != -1) ? dataIsirRc.CisloPopisne.Substring(0, dataIsirRc.CisloPopisne.IndexOf('/')) : dataIsirRc.CisloPopisne)}</cpop>
				<cori>{((dataIsirRc.CisloPopisne.IndexOf("/") != -1) ? (dataIsirRc.CisloPopisne.IndexOf('/') + 1) : "")}</cori>
				<psc>{dataIsirRc.Psc}</psc>
				<obec>{dataIsirRc.Mesto}</obec>
			</adresa>
			<koresp_adresa switch="0">
				<ulice/>
				<cpop/>
				<cori/>
				<psc/>
				<obec/>
			</koresp_adresa>
			<kontakt>
				<email/>
				<dat_schr/>
				<tel/>
			</kontakt>
		</fyzicka_osoba>
	</dluznik>
	<veritel_opak>
		<veritel>
			<veritel fo_po_switch="1">
				<fyzicka_osoba>
					<osobni_udaje>
						<osoba>
							<prijmeni>Plášilová Kaufmanová</prijmeni>
							<jmeno>Hana</jmeno>
							<titul_pred>Mgr. Bc.</titul_pred>
							<ico>48963011</ico>
						</osoba>
						<statni_prislusnost/>
						<datum_narozeni/>
						<rodne_cislo/>
						<osobni_stav/>
					</osobni_udaje>
					<adresa>
						<ulice>Jankovcova</ulice>
						<cpop>1055</cpop>
						<cori>13</cori>
						<psc>17000</psc>
						<obec>Praha 7</obec>
						<stat>CZ</stat>
					</adresa>
					<koresp_adresa switch="0">
						<ulice/>
						<cpop/>
						<cori/>
						<psc/>
						<obec/>
					</koresp_adresa>
					<kontakt>
						<email>podatelna@exekutor-plasilova.cz</email>
						<dat_schr>cswtkc2</dat_schr>
						<tel/>
					</kontakt>
				</fyzicka_osoba>
			</veritel>
			<druh_zastupce>0</druh_zastupce>
		</veritel>
		<c_uctu>130208707/0300</c_uctu>
		<identifikator>{inputExko.Substring(0, inputExko.IndexOf('/'))}{inputExko.Substring(inputExko.IndexOf('/') + 1)}</identifikator>
	</veritel_opak>
	<prihlaska_pohledavky>
		<pohledavka_opak>
			<pohledavka>
				<pohledavka_typ>1</pohledavka_typ>
				<pohledavka_cislo>1</pohledavka_cislo>
				<nezajistena_jednotlive>
					<vyse_jistiny>{valueMoney}</vyse_jistiny>
					<puv_vyse_jistiny>{valueMoney}</puv_vyse_jistiny>
					<duvod_vzniku>Náklady exekučního řízení vedené pod sp.zn. 228 EX {inputExko} na základě {dataMsAccess.RozhodnutiTyp}, které vydal {dataMsAccess.RozhodnutiVydal} č. j. {dataMsAccess.RozhodnutiCislo} ze dne {dataMsAccess.RozhodnutiDatum:dd.MM.yyyy}.</duvod_vzniku>
					<vykonatelnost vykonatelnost_switch="0"/>
					<prislusenstvi prislusenstvi_switch="0"/>
					<celk_vyse_pohledavky>{valueMoney}</celk_vyse_pohledavky>
					<vlastnosti podrizena_switch="0" penezita_switch="1" podminena_switch="0" splatna_switch="1" pohledavka_switch="0">
						<splatna_data>
							<splatna_od>{dataMsAccess.RozhodnutiDatum:dd.MM.yyyy}</splatna_od>
							<splatna_v_castce>{valueMoney}</splatna_v_castce>
						</splatna_data>
					</vlastnosti>
					<dalsi_okolnosti>{SelectValueText(valueMoney)}</dalsi_okolnosti>
				</nezajistena_jednotlive>
			</pohledavka>
		</pohledavka_opak>
	</prihlaska_pohledavky>
	<celkem>
		<celk_vyse_prihlasena>0.00</celk_vyse_prihlasena>
		<celk_vyse_nezajistena>0.00</celk_vyse_nezajistena>
		<nezaj_pohl_neporizeno>0.00</nezaj_pohl_neporizeno>
		<celk_vyse_zajistena>0.00</celk_vyse_zajistena>
		<zaj_pohl_neporizeno>0.00</zaj_pohl_neporizeno>
		<pocet_pohledavek>1</pocet_pohledavek>
		<pocet_vlozenych_stran>3</pocet_vlozenych_stran>
	</celkem>
	<podpisy>
		<podpis>
			<podepisujici_osoba>1</podepisujici_osoba>
			<podpis>
				<v_mesto>Praze</v_mesto>
				<dne>{DateTime.Now:dd.MM.yyyy}</dne>
				<osoba>
					<prijmeni>Plášilová Kaufmanová</prijmeni>
					<jmeno>Hana</jmeno>
					<titul_pred>Mgr. Bc.</titul_pred>
				</osoba>
				<epodatelna switch="0"/>
			</podpis>
		</podpis>
	</podpisy>
</ELPP>
""");
	}
	public static string CreateXmlPo(DataIsirIC dataIsirIc, DataMsAccess dataMsAccess, string inputExko)
	{
		string valueMoney = SelectValue(dataMsAccess.RozhodnutiDatum);
		return new string($"""
<?xml version="1.0" encoding="UTF-8"?>
<ELPP verze="1.4.2">
	<prilohy/>
	<listinne_prilohy/>
	<hlavicka>
		<spisznacka>
			<soud>{SelectJudge(dataIsirIc.NazevOrganizace)}</soud>
			<senat>{dataIsirIc.CisloSenatu}</senat>
			<rejstrik>INS</rejstrik>
			<bc>{dataIsirIc.BcVec}</bc>
			<rocnik>{dataIsirIc.Rocnik}</rocnik>
		</spisznacka>
	</hlavicka>
	<dluznik fo_po_switch="2">
		<pravnicka_osoba>
			<firma>
				<nazev>{dataIsirIc.NazevOsoby}</nazev>
				<ico>{dataIsirIc.Ic}</ico>
				<jine_reg_c/>
			</firma>
			<pravni_rad_zalozeni/>
			<adresa>
				<ulice>{dataIsirIc.Ulice}</ulice>
				<cpop>{((dataIsirIc.CisloPopisne.IndexOf("/") != -1) ? (0, dataIsirIc.CisloPopisne.IndexOf('/')) : dataIsirIc.CisloPopisne)}</cpop>
				<cori>{((dataIsirIc.CisloPopisne.IndexOf("/") != -1) ? (dataIsirIc.CisloPopisne.IndexOf('/') + 1) : "")}</cori>
				<psc>{dataIsirIc.Psc}</psc>
				<obec>{dataIsirIc.Mesto}</obec>
			</adresa>
			<koresp_adresa switch="0">
				<ulice/>
				<cpop/>
				<cori/>
				<psc/>
				<obec/>
			</koresp_adresa>
			<kontakt>
				<email/>
				<dat_schr/>
				<tel/>
			</kontakt>
		</pravnicka_osoba>
	</dluznik>
	<veritel_opak>
		<veritel>
			<veritel fo_po_switch="1">
				<fyzicka_osoba>
					<osobni_udaje>
						<osoba>
							<prijmeni>Plášilová Kaufmanová</prijmeni>
							<jmeno>Hana</jmeno>
							<titul_pred>Mgr. Bc.</titul_pred>
							<ico>48963011</ico>
						</osoba>
						<statni_prislusnost/>
						<datum_narozeni/>
						<rodne_cislo/>
						<osobni_stav/>
					</osobni_udaje>
					<adresa>
						<ulice>Jankovcova</ulice>
						<cpop>1055</cpop>
						<cori>13</cori>
						<psc>17000</psc>
						<obec>Praha 7</obec>
						<stat>CZ</stat>
					</adresa>
					<koresp_adresa switch="0">
						<ulice/>
						<cpop/>
						<cori/>
						<psc/>
						<obec/>
					</koresp_adresa>
					<kontakt>
						<email>podatelna@exekutor-plasilova.cz</email>
						<dat_schr>cswtkc2</dat_schr>
						<tel/>
					</kontakt>
				</fyzicka_osoba>
			</veritel>
			<druh_zastupce>0</druh_zastupce>
		</veritel>
		<c_uctu>130208707/0300</c_uctu>
		<identifikator>{inputExko.Substring(0, inputExko.IndexOf('/'))}{inputExko.Substring(inputExko.IndexOf('/') + 1)}</identifikator>
	</veritel_opak>
	<prihlaska_pohledavky>
		<pohledavka_opak>
			<pohledavka>
				<pohledavka_typ>1</pohledavka_typ>
				<pohledavka_cislo>1</pohledavka_cislo>
				<nezajistena_jednotlive>
					<vyse_jistiny>{valueMoney}</vyse_jistiny>
					<puv_vyse_jistiny>{valueMoney}</puv_vyse_jistiny>
					<duvod_vzniku>Náklady exekučního řízení vedené pod sp.zn. 228 EX {inputExko} na základě {dataMsAccess.RozhodnutiTyp}, které vydal {dataMsAccess.RozhodnutiVydal} č. j. {dataMsAccess.RozhodnutiCislo} ze dne {dataMsAccess.RozhodnutiDatum}.</duvod_vzniku>
					<vykonatelnost vykonatelnost_switch="0"/>
					<prislusenstvi prislusenstvi_switch="0"/>
					<celk_vyse_pohledavky>{valueMoney}</celk_vyse_pohledavky>
					<vlastnosti podrizena_switch="0" penezita_switch="1" podminena_switch="0" splatna_switch="1" pohledavka_switch="0">
						<splatna_data>
							<splatna_od>{dataMsAccess.RozhodnutiDatum:dd.MM.yyyy}</splatna_od>
							<splatna_v_castce>{valueMoney}</splatna_v_castce>
						</splatna_data>
					</vlastnosti>
					<dalsi_okolnosti>{SelectValueText(valueMoney)}</dalsi_okolnosti>
				</nezajistena_jednotlive>
			</pohledavka>
		</pohledavka_opak>
	</prihlaska_pohledavky>
	<celkem>
		<celk_vyse_prihlasena>1221.00</celk_vyse_prihlasena>
		<celk_vyse_nezajistena>1221.00</celk_vyse_nezajistena>
		<nezaj_pohl_neporizeno>1221.00</nezaj_pohl_neporizeno>
		<celk_vyse_zajistena>0.00</celk_vyse_zajistena>
		<zaj_pohl_neporizeno>0.00</zaj_pohl_neporizeno>
		<pocet_pohledavek>1</pocet_pohledavek>
		<pocet_vlozenych_stran>3</pocet_vlozenych_stran>
	</celkem>
	<podpisy>
		<podpis>
			<podepisujici_osoba>1</podepisujici_osoba>
			<podpis>
				<v_mesto>Praze</v_mesto>
				<dne>{DateTime.Now:dd.MM.yyyy}</dne>
				<osoba>
					<prijmeni>Plášilová Kaufmanová</prijmeni>
					<jmeno>Hana</jmeno>
					<titul_pred>Mgr. Bc.</titul_pred>
				</osoba>
				<epodatelna switch="0"/>
			</podpis>
		</podpis>
	</podpisy>
</ELPP>
""");
	}
}