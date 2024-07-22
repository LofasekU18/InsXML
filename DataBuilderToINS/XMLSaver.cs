using System.Xml.Linq;
namespace InsXml;

//TODO : Figure out how to use delegates for Create method
public static class XMLSaver

{
	public static XElement CreateXElement<T>(string tagName, T data) // generic method to create XELEMENT, just first opinion, its too complicate to create such long xml one by one
	{

		return new XElement(tagName, data);
	}
	static string SelectJudge(DataIsir dataIsir) => dataIsir.NazevOrganizace switch
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
		"Krajský soud v Ostravě – pobočka v Olomouci" => "KSOL",
		_ => "Midweek day."
	};

	public static string CreateXmlFo(DataIsirRC dataIsirRc, DataMsAccess dataMsAccess)
	{
		return new string($"""
<?xml version="1.0" encoding="UTF-8"?>
<ELPP verze="1.4.2">
	<prilohy/>
	<listinne_prilohy/>
	<hlavicka>
		<spisznacka>
			<soud>{SelectJudge(dataIsirRc)}</soud>
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
				<cpop>{dataIsirRc.CisloPopisne.Substring(0, dataIsirRc.CisloPopisne.IndexOf('/'))}</cpop>
				<cori>{dataIsirRc.CisloPopisne.Substring(dataIsirRc.CisloPopisne.IndexOf('/') + 1)}</cori>
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
			<veritel fo_po_switch="2">
				<pravnicka_osoba>
					<firma>
						<nazev>AAAA</nazev>
						<ico/>
						<jine_reg_c/>
					</firma>
					<pravni_rad_zalozeni/>
					<adresa>
						<ulice>veritelAdresa</ulice>
						<cpop>1055</cpop>
						<cori>13</cori>
						<psc>17000</psc>
						<obec>veritelAdresa</obec>
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
			</veritel>
			<druh_zastupce>0</druh_zastupce>
		</veritel>
		<c_uctu/>
		<identifikator>VS</identifikator>
	</veritel_opak>
	<prihlaska_pohledavky>
		<pohledavka_opak>
			<pohledavka>
				<pohledavka_typ>1</pohledavka_typ>
				<pohledavka_cislo>1</pohledavka_cislo>
				<nezajistena_jednotlive>
					<vyse_jistiny>{dataMsAccess.RozhodnutiVydal}</vyse_jistiny>
					<puv_vyse_jistiny>{dataMsAccess.RozhodnutiVydal}</puv_vyse_jistiny>
					<duvod_vzniku>Duvod vzniku - usn/pov, exko, tady  {dataMsAccess.RozhodnutiVydal} datum vzniku, kde</duvod_vzniku>
					<vykonatelnost vykonatelnost_switch="0"/>
					<prislusenstvi prislusenstvi_switch="0"/>
					<celk_vyse_pohledavky>{dataMsAccess.RozhodnutiVydal}</celk_vyse_pohledavky>
					<vlastnosti podrizena_switch="0" penezita_switch="1" podminena_switch="0" splatna_switch="0" pohledavka_switch="0"/>
					<dalsi_okolnosti>Dalsi okolnosti - vypocet odmeny a staticky text</dalsi_okolnosti>
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
				<dne>2024-02-23</dne>
				<osoba>
					<prijmeni>PodpisVeritelePrijmeni</prijmeni>
					<jmeno>PodpisVeriteleJmeno</jmeno>
					<titul_pred>PodpisVeriteleTitul</titul_pred>
				</osoba>
				<epodatelna switch="0"/>
			</podpis>
		</podpis>
	</podpisy>
</ELPP>
""");
	}
	public static string CreateXmlPo(DataIsirIC dataIsirIc, DataMsAccess dataMsAccess)
	{
		return new string($"""
<?xml version="1.0" encoding="UTF-8"?>
<ELPP verze="1.4.2">
	<prilohy/>
	<listinne_prilohy/>
	<hlavicka>
		<spisznacka>
			<soud>{SelectJudge(dataIsirIc)}</soud>
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
				<cpop>{dataIsirIc.CisloPopisne.Substring(0, dataIsirIc.CisloPopisne.IndexOf('/'))}</cpop>
				<cori>{dataIsirIc.CisloPopisne.Substring(dataIsirIc.CisloPopisne.IndexOf('/') + 1)}</cori>
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
			<veritel fo_po_switch="2">
				<pravnicka_osoba>
					<firma>
						<nazev>AAAA</nazev>
						<ico/>
						<jine_reg_c/>
					</firma>
					<pravni_rad_zalozeni/>
					<adresa>
						<ulice>veritelAdresa</ulice>
						<cpop>1055</cpop>
						<cori>13</cori>
						<psc>17000</psc>
						<obec>veritelAdresa</obec>
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
			</veritel>
			<druh_zastupce>0</druh_zastupce>
		</veritel>
		<c_uctu/>
		<identifikator>VS</identifikator>
	</veritel_opak>
	<prihlaska_pohledavky>
		<pohledavka_opak>
			<pohledavka>
				<pohledavka_typ>1</pohledavka_typ>
				<pohledavka_cislo>1</pohledavka_cislo>
				<nezajistena_jednotlive>
					<vyse_jistiny>1221.00</vyse_jistiny>
					<puv_vyse_jistiny>21212.00</puv_vyse_jistiny>
					<duvod_vzniku>Duvod vzniku - usn/pov, exko, datum vzniku, kde</duvod_vzniku>
					<vykonatelnost vykonatelnost_switch="0"/>
					<prislusenstvi prislusenstvi_switch="0"/>
					<celk_vyse_pohledavky>1221.00</celk_vyse_pohledavky>
					<vlastnosti podrizena_switch="0" penezita_switch="1" podminena_switch="0" splatna_switch="0" pohledavka_switch="0"/>
					<dalsi_okolnosti>Dalsi okolnosti - vypocet odmeny a staticky text</dalsi_okolnosti>
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
				<dne>2024-02-23</dne>
				<osoba>
					<prijmeni>PodpisVeritelePrijmeni</prijmeni>
					<jmeno>PodpisVeriteleJmeno</jmeno>
					<titul_pred>PodpisVeriteleTitul</titul_pred>
				</osoba>
				<epodatelna switch="0"/>
			</podpis>
		</podpis>
	</podpisy>
</ELPP>
""");
	}
}