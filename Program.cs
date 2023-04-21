﻿using System;

namespace NMMU_Scraper
{
    internal class Program
    {
        public static string? VolumeNo { get; private set; } = string.Empty;
        public static string? RateNumber { get; private set; } = string.Empty;
        public static string? StreetNo { get; private set; } = string.Empty;
        public static string? StreetName { get; private set; } = string.Empty;
        public static string? Suburb { get; private set; } = string.Empty;
        public static string? ERF { get; private set; } = string.Empty;
        public static string? Portion { get; private set; } = string.Empty;
        public static string? DeedsTown { get; private set; } = string.Empty;
        public static string? SchemeName { get; private set; } = string.Empty;
        public static string? SectionNumber { get; private set; } = string.Empty;

        static async Task Main(string[] args)
        {
            Dictionary<string, string> suburbs = new()
            {
                { "12078", "ADCOCKVALE" },
                { "12079", "ADMIRALTY WAY" },
                { "12080", "ALGOA PARK" },
                { "12081", "ALGOA PARK&amp; NEW BIRG" },
                { "12082", "ALOES" },
                { "12083", "AMSTERDAMHOEK" },
                { "12084", "ARCADIA" },
                { "12085", "BARCELONA" },
                { "12086", "BEACHVIEW" },
                { "12087", "BEN KAMMA" },
                { "12088", "BETHELSDORP" },
                { "12089", "BETHELSDORP EXT 21" },
                { "12090", "BETHELSDORP EXT 22" },
                { "12091", "BETHELSDORP EXT 27" },
                { "12092", "BETHELSDORP EXT 28" },
                { "12093", "BETHELSDORP EXT 30" },
                { "12094", "BETHELSDORP EXT 31" },
                { "12095", "BETHELSDORP EXT 32" },
                { "12096", "BETHELSDORP EXT 33" },
                { "12097", "BETHELSDORP EXT 34" },
                { "12098", "BETHELSDORP EXT 35" },
                { "12099", "BETHELSDORP EXT 36" },
                { "12100", "BETHELSDORP EXT 37" },
                { "12101", "BETHELSDORP X24" },
                { "12102", "BEVERLEY GROVE" },
                { "12103", "BLOEMENDAL" },
                { "12104", "BLOEMENDAL BLOCK 23" },
                { "12105", "BLOEMENDAL EXT 6" },
                { "12106", "BLUE HORIZON BAY" },
                { "12107", "BLUE WATER BAY" },
                { "12108", "BLUEWATER BAY" },
                { "12109", "BOOYSENS PARK" },
                { "12110", "BRAMHOPE" },
                { "12111", "BRENTWOOD PARK" },
                { "12112", "BRIDGEMEAD" },
                { "12113", "BROADWOOD" },
                { "12114", "BUFFELSFONTEIN VILL" },
                { "12115", "BURMAN ROAD" },
                { "12116", "BURT DRIVE" },
                { "12117", "CAMPHER PARK" },
                { "12118", "CANNONVILLE" },
                { "12119", "CAPE ROAD INDUSTRIAL" },
                { "12120", "CENTRAL" },
                { "12121", "CHARLO" },
                { "12122", "CHATTY" },
                { "12123", "CHATTY EXT 17" },
                { "12124", "CHELSEA" },
                { "12125", "CHELSEA FARM" },
                { "12126", "CHURCH ROAD" },
                { "12127", "CLARENDON MARINE" },
                { "12128", "CLEARY ESTATE" },
                { "12129", "CLEARY PARK" },
                { "15565", "Coega" },
                { "12130", "COLCHESTER" },
                { "12131", "COLLEEN GLEN" },
                { "12132", "COTSWOLD" },
                { "12133", "CRADOCK PLACE" },
                { "12134", "CRESC WALMER HEIGHTS" },
                { "12135", "CROCKARTS HOPE" },
                { "12136", "CURRY" },
                { "12137", "DEAL PARTY" },
                { "12138", "DEAPATCH" },
                { "12139", "DENHOLME" },
                { "12140", "DESPATCH" },
                { "12141", "DRIVE BLOEMENDAL" },
                { "12142", "DWADWESI" },
                { "12143", "DYKE ROAD ALGOA PARK" },
                { "12144", "ECHOVALE" },
                { "12145", "EMERALD HILL" },
                { "12146", "FAIRVIEW" },
                { "12147", "FARM DRAAIFONTEIN" },
                { "12148", "FARM KRAGGA KAMMA" },
                { "12149", "FARMS PORT ELIZABETH" },
                { "12150", "FARMS UITENHAGE" },
                { "12151", "FERGUSON TOWNSHIP" },
                { "12152", "FERNGLEN" },
                { "12153", "FERNWOOD PARK" },
                { "12154", "FITCHHOLME" },
                { "12155", "FORDVILLE" },
                { "12156", "FOREST HILL" },
                { "12157", "FOUNTAIN ST WALMER" },
                { "12158", "FRAMESBY" },
                { "12159", "FRAMESBY EXT 1" },
                { "12160", "FRAMESBY NORTH" },
                { "12161", "FRANCIS EVATT PARK" },
                { "12162", "GAP TAP KWAZAKHELE" },
                { "12163", "GELVAN PARK" },
                { "12164", "GELVANDALE" },
                { "12165", "GELVANDALE EXT 12" },
                { "12166", "GLEN HURD" },
                { "12167", "GLENDINNINGVALE" },
                { "12168", "GOLDWATER" },
                { "12169", "GOMERY AVENUE" },
                { "12170", "GREENACRES" },
                { "12171", "GREENBUSHES" },
                { "12172", "GREENFIELDS" },
                { "12173", "GREENSHIELDS PARK" },
                { "12174", "HARBOUR" },
                { "12175", "HELENVALE" },
                { "12176", "HEUWELKRUIN" },
                { "12177", "HILLSIDE" },
                { "12178", "HOETS CRESCENT" },
                { "12179", "HOLLAND PARK" },
                { "12180", "HUMERAIL" },
                { "12181", "HUMEWOOD" },
                { "12182", "HUNTERS" },
                { "12183", "HUNTERS RETREAT" },
                { "12184", "IBHAYI" },
                { "12185", "JACHTVLAKTE" },
                { "12186", "JANSENDAL" },
                { "12187", "JOE SLOVO" },
                { "12188", "KABAH/LANGA" },
                { "12189", "KABEGA" },
                { "12190", "KABEGA PARK" },
                { "12191", "KAMMA CREEK" },
                { "12192", "KAMMA HEIGHTS" },
                { "12193", "KAMMA PARK" },
                { "12194", "KAMMA RIDGE" },
                { "12195", "KEMSLEY PARK" },
                { "12196", "KENSINGTON" },
                { "12197", "KINI BAY" },
                { "12198", "KLEINSKOOL" },
                { "12199", "KORSTEN" },
                { "12200", "KORSTEN/HOLLAND PARK" },
                { "12201", "KRAGGA KAMMA PARK" },
                { "12202", "KUNENE PARK" },
                { "12203", "KUWAIT" },
                { "12204", "KUYGA" },
                { "12205", "KWADESI" },
                { "12206", "KWADWESI" },
                { "12207", "KWAFORD" },
                { "12208", "KWAMAGXAKI" },
                { "12209", "KWANMAGXAKI" },
                { "12210", "KWANOBUHLE" },
                { "12211", "KWAZAKHELE" },
                { "12212", "KWWAZAKHELE" },
                { "12213", "LINKSIDE" },
                { "12214", "LINTON GRANGE" },
                { "12215", "LITTLE CHELSEA NO 10" },
                { "12216", "LONDT PARK" },
                { "12217", "LONGWAY AVENUE" },
                { "12218", "LORRAINE" },
                { "12219", "LOVEMORE CRESCENT" },
                { "12220", "LOVEMORE HEIGHTS" },
                { "12221", "LOVEMORE PARK" },
                { "12222", "MAIN STREET CENTRAL" },
                { "12223", "MALABAR" },
                { "12224", "MANGOLD PARK" },
                { "12225", "MANOR HEIGHTS" },
                { "12226", "MARAIS TOWNSHIP" },
                { "12227", "MARINE DRIVE" },
                { "12228", "MARINER'S ROW" },
                { "12229", "MARKMAN INDUSTRIAL TOWNSHIP" },
                { "12230", "MASANGWANAVILLE" },
                { "12231", "MAY WAY SUNRIDGE PK" },
                { "12232", "MCNAUGHTON" },
                { "12233", "MHLABA VILLAGE" },
                { "12234", "MILL PARK" },
                { "12235", "MILLARD GRANGE" },
                { "12236", "MIRAMAR" },
                { "12237", "MISSIONVALE" },
                { "12238", "MNQUMA STR KWADWESI" },
                { "12239", "MORNINGSIDE" },
                { "12240", "MOSEL" },
                { "12241", "MOTHERWELL" },
                { "12242", "MOUNT CROIX" },
                { "12243", "MOUNT PLEASANT" },
                { "12244", "MURRAY PARK" },
                { "12245", "NEAVE TOWNSHIP" },
                { "12246", "NEW BRIGHTON" },
                { "12247", "NEWTON PARK" },
                { "12248", "NORTH END" },
                { "12249", "NORTHCLIFFE HUMEWOOD" },
                { "12250", "OVERBAAKENS" },
                { "12251", "PAPENKUILSVALLEY" },
                { "12252", "PARI PARK" },
                { "12253", "PARK DRIVE" },
                { "12254", "PARKSIDE" },
                { "12255", "PARSONS HILL" },
                { "12256", "PARSONS VLEI" },
                { "12257", "PATERSON ROAD" },
                { "12258", "PERRIDGEVALE" },
                { "12259", "PERSEVERANCE" },
                { "12260", "POPLAR AVENUE" },
                { "12261", "PORT ELIZABETH" },
                { "12262", "PRIMROSE SQUARS" },
                { "12263", "PRINGLE AVENUE" },
                { "12264", "PROVIDENTIA" },
                { "12265", "REDHOUSE" },
                { "12266", "RENDALLTON" },
                { "12267", "RETIEF" },
                { "12268", "ROADWAYS" },
                { "15522", "Rocklands" },
                { "12269", "ROWALLAN PARK" },
                { "12270", "SALSONEVILLE" },
                { "12271", "SALT LAKE" },
                { "12272", "SANCTOR" },
                { "12273", "SARDINIA BAY" },
                { "12274", "SCHAUDERVILLE" },
                { "12275", "SCHOENMAKKERSKOP" },
                { "12276", "SEAVIEW" },
                { "12277", "SHERWOOD" },
                { "12278", "SIDWELL" },
                { "12279", "SILVERTOWN" },
                { "12280", "SISONKE" },
                { "12281", "SITE &amp; SERVICE" },
                { "12282", "SKEGNESS ROAD" },
                { "12283", "SOUTH END" },
                { "12284", "SOUTH END CEMETERY" },
                { "12285", "SOWETO-ON-SEA" },
                { "12286", "SPORTS CLUB" },
                { "12287", "SPRINGDALE" },
                { "12288", "ST GEORGES PARK" },
                { "12289", "ST GEORGES STRAND" },
                { "12290", "STARLING CRESCENT" },
                { "12291", "STELLA LONDT DRIVE" },
                { "12292", "STEVE TSHWETE VILLAG" },
                { "12293", "STEYTLER TOWNSHIP" },
                { "12294", "STR WALMER HEIGHTS" },
                { "12295", "STRUANDALE" },
                { "12296", "STUART TOWNSHIP" },
                { "12297", "SUMMERSTRAND" },
                { "12298", "SUNRIDGE PARK" },
                { "12299", "SWARTKOPS" },
                { "12300", "SYDENHAM" },
                { "12301", "TAYBANK" },
                { "12302", "THAMBO VILLAGE" },
                { "12303", "THE FARM CHELSEA" },
                { "12304", "THEESCOMBE" },
                { "12305", "THEMBALETHU" },
                { "12306", "THRUSH ROAD" },
                { "12307", "TJOKSVILLE" },
                { "12308", "TJOKSVILLE M/WELL" },
                { "12309", "TREEHAVEN" },
                { "12310", "TUDOR GARDENS" },
                { "12311", "TULBAGH" },
                { "12312", "UITENHAGE" },
                { "12313", "UNKNOWN" },
                { "12314", "VALLEISIG" },
                { "12315", "VAN DER STEL" },
                { "12316", "VAN RIEBEECK HOOGTE" },
                { "12317", "VAN STADENS RIVER" },
                { "12318", "VANES ESTATES" },
                { "12319", "VICTORIA PARK" },
                { "12320", "VIKINGVALE" },
                { "12321", "WALMER" },
                { "12322", "WALMER AREA B" },
                { "12323", "WALMER DOWNS" },
                { "12324", "WALMER DUNES" },
                { "12325", "WALMER HEIGHTS" },
                { "12326", "WALMER LOCATION" },
                { "12327", "WALMER TOWNSHIP" },
                { "12328", "WAY TOWNSHIP" },
                { "15504", "WEDGEWOOD" },
                { "12329", "WELLS ESTATE" },
                { "12330", "WEST END" },
                { "12331", "WESTERING" },
                { "12332", "WESTLANDS" },
                { "12333", "WEYBRIDGE PARK" },
                { "12334", "WHYTELEAF DRIVE" },
                { "12335", "WINCHESTER WAY" },
                { "12336", "WINDVOGEL" },
                { "12337", "WONDERVIEW" },
                { "12338", "WOODLANDS" },
                { "12339", "WOODLANDS PARK" },
                { "12340", "YOUNG PARK" },
                { "12341", "ZWIDE" },
            };

            Suburb = suburbs["ADCOCKVALE"];
            var URL =$"https://www.nelsonmandelabay.gov.za/propertyregister/FramePages/SearchResult.aspx?Roll=1&VolumeNo={VolumeNo}&RateNumber={RateNumber}&StreetNo={StreetNo}&StreetName={StreetName}&Suburb={Suburb}&ERF={ERF}&Portion={Portion}&DeedsTown={DeedsTown}&SchemeName={SchemeName}&SectionNumber={SectionNumber}&All=true";
            HttpClient client = new();
            var response = await  client.GetAsync(URL);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
        }
    }
}