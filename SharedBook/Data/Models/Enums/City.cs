namespace SharedBook.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum City
    {
        Blagoevgrad = 100,
        Bansko = 101,
        Belitsa = 102,
        [Display(Name = "Gotse Delchev")]
        GotseDelchev = 103,
        Hadzhidimovo = 104,
        Kresna = 105,
        Petrich = 106,
        Razlog = 107,
        Sandanski = 108,
        Simitli = 109,
        Yakoruda = 110,

        Burgas = 200,
        Aytos = 201,
        Kameno = 202,
        Karnobat = 203,
        [Display(Name = "Malko Tarnovo")]
        MalkoTarnovo = 204,
        Nesebar	= 205,
        Pomorie	= 206,
        Primorsko = 207,
        Sozopol = 208,
        Sredets	= 209,
        Sungurlare = 210,
        Tsarevo	= 211,
        
        Varna = 300,
        Aksakovo = 301,
        Beloslav = 302,
        Byala = 303,
        [Display(Name = "Dolni Chiflik")]
        DolniChiflik = 304,
        Devnya = 305,
        Dalgopol = 306,
        Provadia = 307,
        Suvorovo = 308,
        [Display(Name = "Valchi Dol")]
        ValchiDol = 309,

        [Display(Name = "Veliko Tarnovo")]
        VelikoTarnovo = 400,
        Elena = 401,
        [Display(Name = "Gorna Oryahovitsa")]
        GornaOryahovitsa = 402,
        Lyaskovets = 403,
        Pavlikeni = 404,
        [Display(Name = "Polski Trambesh")]
        PolskiTrambesh = 405,
        Strazhitsa = 406,
        Suhindol = 407,
        Svishtov = 408,
        Zlataritsa = 409,
        
        Vidin = 500,
        Belogradchik = 501,
        Bregovo = 502,
        Gramada = 503,
        Dimovo = 504,
        Kula = 505,

        Vratsa = 600,
        [Display(Name = "Byala Slatina")]
        ByalaSlatina = 601,
        Kozloduy = 602,
        Krivodol = 603,
        Mezdra = 604,
        Mizia = 605,
        Oryahovo = 606,
        Roman = 607,

        Gabrovo = 700,
        Dryanovo = 701,
        Sevlievo = 702,
        Tryavna = 703,

        Dobrich = 800,
        Balchik = 801,
        [Display(Name = "General Toshevo")]
        GeneralToshevo = 802,
        Kavarna = 803,
        Shabla = 804,
        Tervel = 805,

        Kardzhali = 900,
        Krumovgrad = 901,
        Momchilgrad = 902,
        Ardino = 903,
        Dzhebel = 904,

        Kyustendil = 1000,
        Boboshevo = 1001,
        [Display(Name = "Bobov dol")]
        Bobovdol = 1002,
        Dupnitsa = 1003,
        Kocherinovo = 1004,
        Rila = 1005,
        [Display(Name = "Sapareva banya")]
        Saparevabanya = 1006,

        Lovech = 1100,
        Apriltsi = 1101,
        Letnitsa = 1102,
        Lukovit = 1103,
        Teteven = 1104,
        Troyan = 1105,
        Ugarchin = 1106,
        Yablanitsa = 1107,

        Montana = 1200,
        Berkovitsa = 1201,
        Boychinovtsi = 1202,
        Brusartsi = 1203,
        Chiprovtsi = 1204,
        Lom = 1205,
        Valchedram = 1206,
        Varshets = 1207,

        Pazardzhik = 1300,
        Velingrad = 1301,
        Septemvri = 1302,
        Panagyurishte = 1303,
        Peshtera = 1304,
        Rakitovo = 1305,
        Bratsigovo = 1306,
        Belovo = 1307,
        Batak = 1308,
        Strelcha = 1309,
        Sarnitsa = 1310,

        Pernik = 1400,
        Radomir = 1401,
        Breznik = 1402,
        Batanovtsi = 1403,
        Divotino = 1404,
        Zemen = 1405,
        Rudartsi = 1406,
        Kladnitsa = 1407,

        Pleven = 1500,
        Belene = 1501,
        Gulyantsi = 1502,
        [Display(Name = "Dolna Mitropoliya")]
        DolnaMitropoliya = 1503,
        [Display(Name = "Dolni Dabnik")]
        DolniDabnik = 1504,
        Levski = 1505,
        Nikopol = 1506,
        Iskar = 1507,
        Pordim = 1508,
        [Display(Name = "Cherven Bryag")]
        ChervenBryag = 1509,
        Knezha = 1510,

        Plovdiv = 1600,
        Asenovgrad = 1601,
        Brezovo = 1602,
        Hisarya = 1603,
        Kaloyanovo = 1604,
        Karlovo = 1605,
        Krichim = 1606,
        Kuklen = 1607,
        Laki = 1608,
        Perushtitsa = 1609,
        Parvomay = 1610,
        Rakovski = 1611,
        Sadovo = 1612,
        Sopot = 1613,
        Stamboliyski = 1614,
        Saedinenie = 1615,

        Razgrad = 1700,
        Isperih = 1701,
        Kubrat = 1702,
        Loznitsa = 1703,
        Samuil = 1704,
        [Display(Name = "Tsar Kaloyan")]
        TsarKaloyan = 1705,
        Zavet = 1706,

        Ruse = 1800,
        Borovo = 1801,
        [Display(Name = "Byala")]
        ByalaRuse = 1802,
        Vetovo = 1803,
        [Display(Name = "Dve Mogili")]
        DveMogili = 1804,
        [Display(Name = "Slivo Pole")]
        SlivoPole = 1805,

        Silistra = 1900,
        Alfatar = 1901,
        Glavinitsa = 1902,
        Dulovo = 1903,
        Tutrakan = 1904,

        Sliven = 2000,
        Kotel = 2001,
        [Display(Name = "Nova Zagora")]
        NovaZagora = 2002,
        Tvarditsa = 2003,

        Smolyan = 2100,
        Chepelare = 2101,
        Devin = 2102,
        Dospat = 2103,
        Madan = 2104,
        Nedelino = 2105,
        Rudozem = 2106,
        Zlatograd = 2107,

        //[Display(Name = "Sofiya-Grad")]
        //SofiyaGrad = 2200,
        Bankya = 2201,
        Buhovo = 2202,
        [Display(Name = "Novi Iskar")]
        NoviIskar = 2203,
        [Display(Name = "Sofiya")]
        SofiyaCity = 2204,

        Sofiya = 2300,
        Botevgrad = 2301,
        Bozhurishte = 2302,
        [Display(Name = "Dolna Banya")]
        DolnaBanya = 2303,
        Dragoman = 2304,
        [Display(Name = "Elin Pelin")]
        ElinPelin = 2305,
        Etropole = 2306,
        Godech = 2307,
        Ihtiman = 2308,
        Koprivshtitsa = 2309,
        Kostenets = 2310,
        Kostinbrod = 2311,
        Pirdop = 2312,
        Pravets = 2313,
        Samokov = 2314,
        Slivnitsa = 2315,
        Svoge = 2316,
        Zlatitsa = 2317,

        [Display(Name = "Stara Zagora")]
        StaraZagora = 2400,
        Chirpan = 2401,
        Gurkovo = 2402,
        Galabovo = 2403,
        Kazanlak = 2404,
        Maglizh = 2405,
        Nikolaevo = 2406,
        [Display(Name = "Pavel Banya")]
        PavelBanya = 2407,
        Radnevo = 2408,

        Targovishte = 2500,
        Popovo = 2501,
        Omurtag = 2502,
        Antonovo = 2503,
        Opaka = 2504,

        Haskovo = 2600,
        Dimitrovgrad = 2601,
        Harmanli = 2602,
        Ivaylovgrad = 2603,
        Lyubimets = 2604,
        Madzharovo = 2605,
        Simeonovgrad = 2606,
        Svilengrad = 2607,
        Topolovgrad = 2608,

        Shumen = 2700,
        Varbitsa = 2701,
        Kaolinovo = 2702,
        Kaspichan = 2703,
        [Display(Name = "Novi Pazar")]
        NoviPazar = 2704,
        [Display(Name = "Veliki Preslav")]
        VelikiPreslav = 2705,
        Smyadovo = 2706,

        Yambol = 2800,
        Bolyarovo = 2801,
        Elhovo = 2802,
        Straldzha = 2803
    }
}
