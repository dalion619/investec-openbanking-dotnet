using System.Collections.Generic;
using Newtonsoft.Json;

namespace Investec.OpenBanking.RestClient
{
    /// <summary>
    ///     Helper class with basic information on various countries
    /// </summary>
    public static class CountryHelper
    {
        private static string CountriesJson => @"[
    {
        ""Name"": ""Bangladesh"",
        ""ISO2"": ""BD"",
        ""ISO3"": ""BGD"",
        ""CurrencyISO3"": ""BDT"",
        ""PhoneCode"": ""880""
    },
    {
        ""Name"": ""Belgium"",
        ""ISO2"": ""BE"",
        ""ISO3"": ""BEL"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""32""
    },
    {
        ""Name"": ""Burkina Faso"",
        ""ISO2"": ""BF"",
        ""ISO3"": ""BFA"",
        ""CurrencyISO3"": ""XOF"",
        ""PhoneCode"": ""226""
    },
    {
        ""Name"": ""Bulgaria"",
        ""ISO2"": ""BG"",
        ""ISO3"": ""BGR"",
        ""CurrencyISO3"": ""BGN"",
        ""PhoneCode"": ""359""
    },
    {
        ""Name"": ""Bosnia and Herzegovina"",
        ""ISO2"": ""BA"",
        ""ISO3"": ""BIH"",
        ""CurrencyISO3"": ""BAM"",
        ""PhoneCode"": ""387""
    },
    {
        ""Name"": ""Barbados"",
        ""ISO2"": ""BB"",
        ""ISO3"": ""BRB"",
        ""CurrencyISO3"": ""BBD"",
        ""PhoneCode"": ""+1-246""
    },
    {
        ""Name"": ""Wallis and Futuna"",
        ""ISO2"": ""WF"",
        ""ISO3"": ""WLF"",
        ""CurrencyISO3"": ""XPF"",
        ""PhoneCode"": ""681""
    },
    {
        ""Name"": ""Saint Barthelemy"",
        ""ISO2"": ""BL"",
        ""ISO3"": ""BLM"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""590""
    },
    {
        ""Name"": ""Bermuda"",
        ""ISO2"": ""BM"",
        ""ISO3"": ""BMU"",
        ""CurrencyISO3"": ""BMD"",
        ""PhoneCode"": ""+1-441""
    },
    {
        ""Name"": ""Brunei"",
        ""ISO2"": ""BN"",
        ""ISO3"": ""BRN"",
        ""CurrencyISO3"": ""BND"",
        ""PhoneCode"": ""673""
    },
    {
        ""Name"": ""Bolivia"",
        ""ISO2"": ""BO"",
        ""ISO3"": ""BOL"",
        ""CurrencyISO3"": ""BOB"",
        ""PhoneCode"": ""591""
    },
    {
        ""Name"": ""Bahrain"",
        ""ISO2"": ""BH"",
        ""ISO3"": ""BHR"",
        ""CurrencyISO3"": ""BHD"",
        ""PhoneCode"": ""973""
    },
    {
        ""Name"": ""Burundi"",
        ""ISO2"": ""BI"",
        ""ISO3"": ""BDI"",
        ""CurrencyISO3"": ""BIF"",
        ""PhoneCode"": ""257""
    },
    {
        ""Name"": ""Benin"",
        ""ISO2"": ""BJ"",
        ""ISO3"": ""BEN"",
        ""CurrencyISO3"": ""XOF"",
        ""PhoneCode"": ""229""
    },
    {
        ""Name"": ""Bhutan"",
        ""ISO2"": ""BT"",
        ""ISO3"": ""BTN"",
        ""CurrencyISO3"": ""BTN"",
        ""PhoneCode"": ""975""
    },
    {
        ""Name"": ""Jamaica"",
        ""ISO2"": ""JM"",
        ""ISO3"": ""JAM"",
        ""CurrencyISO3"": ""JMD"",
        ""PhoneCode"": ""+1-876""
    },
    {
        ""Name"": ""Bouvet Island"",
        ""ISO2"": ""BV"",
        ""ISO3"": ""BVT"",
        ""CurrencyISO3"": ""NOK"",
        ""PhoneCode"": """"
    },
    {
        ""Name"": ""Botswana"",
        ""ISO2"": ""BW"",
        ""ISO3"": ""BWA"",
        ""CurrencyISO3"": ""BWP"",
        ""PhoneCode"": ""267""
    },
    {
        ""Name"": ""Samoa"",
        ""ISO2"": ""WS"",
        ""ISO3"": ""WSM"",
        ""CurrencyISO3"": ""WST"",
        ""PhoneCode"": ""685""
    },
    {
        ""Name"": ""Bonaire, Saint Eustatius and Saba "",
        ""ISO2"": ""BQ"",
        ""ISO3"": ""BES"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""599""
    },
    {
        ""Name"": ""Brazil"",
        ""ISO2"": ""BR"",
        ""ISO3"": ""BRA"",
        ""CurrencyISO3"": ""BRL"",
        ""PhoneCode"": ""55""
    },
    {
        ""Name"": ""Bahamas"",
        ""ISO2"": ""BS"",
        ""ISO3"": ""BHS"",
        ""CurrencyISO3"": ""BSD"",
        ""PhoneCode"": ""+1-242""
    },
    {
        ""Name"": ""Jersey"",
        ""ISO2"": ""JE"",
        ""ISO3"": ""JEY"",
        ""CurrencyISO3"": ""GBP"",
        ""PhoneCode"": ""+44-1534""
    },
    {
        ""Name"": ""Belarus"",
        ""ISO2"": ""BY"",
        ""ISO3"": ""BLR"",
        ""CurrencyISO3"": ""BYR"",
        ""PhoneCode"": ""375""
    },
    {
        ""Name"": ""Belize"",
        ""ISO2"": ""BZ"",
        ""ISO3"": ""BLZ"",
        ""CurrencyISO3"": ""BZD"",
        ""PhoneCode"": ""501""
    },
    {
        ""Name"": ""Russia"",
        ""ISO2"": ""RU"",
        ""ISO3"": ""RUS"",
        ""CurrencyISO3"": ""RUB"",
        ""PhoneCode"": ""7""
    },
    {
        ""Name"": ""Rwanda"",
        ""ISO2"": ""RW"",
        ""ISO3"": ""RWA"",
        ""CurrencyISO3"": ""RWF"",
        ""PhoneCode"": ""250""
    },
    {
        ""Name"": ""Serbia"",
        ""ISO2"": ""RS"",
        ""ISO3"": ""SRB"",
        ""CurrencyISO3"": ""RSD"",
        ""PhoneCode"": ""381""
    },
    {
        ""Name"": ""East Timor"",
        ""ISO2"": ""TL"",
        ""ISO3"": ""TLS"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""670""
    },
    {
        ""Name"": ""Reunion"",
        ""ISO2"": ""RE"",
        ""ISO3"": ""REU"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""262""
    },
    {
        ""Name"": ""Turkmenistan"",
        ""ISO2"": ""TM"",
        ""ISO3"": ""TKM"",
        ""CurrencyISO3"": ""TMT"",
        ""PhoneCode"": ""993""
    },
    {
        ""Name"": ""Tajikistan"",
        ""ISO2"": ""TJ"",
        ""ISO3"": ""TJK"",
        ""CurrencyISO3"": ""TJS"",
        ""PhoneCode"": ""992""
    },
    {
        ""Name"": ""Romania"",
        ""ISO2"": ""RO"",
        ""ISO3"": ""ROU"",
        ""CurrencyISO3"": ""RON"",
        ""PhoneCode"": ""40""
    },
    {
        ""Name"": ""Tokelau"",
        ""ISO2"": ""TK"",
        ""ISO3"": ""TKL"",
        ""CurrencyISO3"": ""NZD"",
        ""PhoneCode"": ""690""
    },
    {
        ""Name"": ""Guinea-Bissau"",
        ""ISO2"": ""GW"",
        ""ISO3"": ""GNB"",
        ""CurrencyISO3"": ""XOF"",
        ""PhoneCode"": ""245""
    },
    {
        ""Name"": ""Guam"",
        ""ISO2"": ""GU"",
        ""ISO3"": ""GUM"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""+1-671""
    },
    {
        ""Name"": ""Guatemala"",
        ""ISO2"": ""GT"",
        ""ISO3"": ""GTM"",
        ""CurrencyISO3"": ""GTQ"",
        ""PhoneCode"": ""502""
    },
    {
        ""Name"": ""South Georgia and the South Sandwich Islands"",
        ""ISO2"": ""GS"",
        ""ISO3"": ""SGS"",
        ""CurrencyISO3"": ""GBP"",
        ""PhoneCode"": """"
    },
    {
        ""Name"": ""Greece"",
        ""ISO2"": ""GR"",
        ""ISO3"": ""GRC"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""30""
    },
    {
        ""Name"": ""Equatorial Guinea"",
        ""ISO2"": ""GQ"",
        ""ISO3"": ""GNQ"",
        ""CurrencyISO3"": ""XAF"",
        ""PhoneCode"": ""240""
    },
    {
        ""Name"": ""Guadeloupe"",
        ""ISO2"": ""GP"",
        ""ISO3"": ""GLP"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""590""
    },
    {
        ""Name"": ""Japan"",
        ""ISO2"": ""JP"",
        ""ISO3"": ""JPN"",
        ""CurrencyISO3"": ""JPY"",
        ""PhoneCode"": ""81""
    },
    {
        ""Name"": ""Guyana"",
        ""ISO2"": ""GY"",
        ""ISO3"": ""GUY"",
        ""CurrencyISO3"": ""GYD"",
        ""PhoneCode"": ""592""
    },
    {
        ""Name"": ""Guernsey"",
        ""ISO2"": ""GG"",
        ""ISO3"": ""GGY"",
        ""CurrencyISO3"": ""GBP"",
        ""PhoneCode"": ""+44-1481""
    },
    {
        ""Name"": ""French Guiana"",
        ""ISO2"": ""GF"",
        ""ISO3"": ""GUF"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""594""
    },
    {
        ""Name"": ""Georgia"",
        ""ISO2"": ""GE"",
        ""ISO3"": ""GEO"",
        ""CurrencyISO3"": ""GEL"",
        ""PhoneCode"": ""995""
    },
    {
        ""Name"": ""Grenada"",
        ""ISO2"": ""GD"",
        ""ISO3"": ""GRD"",
        ""CurrencyISO3"": ""XCD"",
        ""PhoneCode"": ""+1-473""
    },
    {
        ""Name"": ""United Kingdom"",
        ""ISO2"": ""GB"",
        ""ISO3"": ""GBR"",
        ""CurrencyISO3"": ""GBP"",
        ""PhoneCode"": ""44""
    },
    {
        ""Name"": ""Gabon"",
        ""ISO2"": ""GA"",
        ""ISO3"": ""GAB"",
        ""CurrencyISO3"": ""XAF"",
        ""PhoneCode"": ""241""
    },
    {
        ""Name"": ""El Salvador"",
        ""ISO2"": ""SV"",
        ""ISO3"": ""SLV"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""503""
    },
    {
        ""Name"": ""Guinea"",
        ""ISO2"": ""GN"",
        ""ISO3"": ""GIN"",
        ""CurrencyISO3"": ""GNF"",
        ""PhoneCode"": ""224""
    },
    {
        ""Name"": ""Gambia"",
        ""ISO2"": ""GM"",
        ""ISO3"": ""GMB"",
        ""CurrencyISO3"": ""GMD"",
        ""PhoneCode"": ""220""
    },
    {
        ""Name"": ""Greenland"",
        ""ISO2"": ""GL"",
        ""ISO3"": ""GRL"",
        ""CurrencyISO3"": ""DKK"",
        ""PhoneCode"": ""299""
    },
    {
        ""Name"": ""Gibraltar"",
        ""ISO2"": ""GI"",
        ""ISO3"": ""GIB"",
        ""CurrencyISO3"": ""GIP"",
        ""PhoneCode"": ""350""
    },
    {
        ""Name"": ""Ghana"",
        ""ISO2"": ""GH"",
        ""ISO3"": ""GHA"",
        ""CurrencyISO3"": ""GHS"",
        ""PhoneCode"": ""233""
    },
    {
        ""Name"": ""Oman"",
        ""ISO2"": ""OM"",
        ""ISO3"": ""OMN"",
        ""CurrencyISO3"": ""OMR"",
        ""PhoneCode"": ""968""
    },
    {
        ""Name"": ""Tunisia"",
        ""ISO2"": ""TN"",
        ""ISO3"": ""TUN"",
        ""CurrencyISO3"": ""TND"",
        ""PhoneCode"": ""216""
    },
    {
        ""Name"": ""Jordan"",
        ""ISO2"": ""JO"",
        ""ISO3"": ""JOR"",
        ""CurrencyISO3"": ""JOD"",
        ""PhoneCode"": ""962""
    },
    {
        ""Name"": ""Croatia"",
        ""ISO2"": ""HR"",
        ""ISO3"": ""HRV"",
        ""CurrencyISO3"": ""HRK"",
        ""PhoneCode"": ""385""
    },
    {
        ""Name"": ""Haiti"",
        ""ISO2"": ""HT"",
        ""ISO3"": ""HTI"",
        ""CurrencyISO3"": ""HTG"",
        ""PhoneCode"": ""509""
    },
    {
        ""Name"": ""Hungary"",
        ""ISO2"": ""HU"",
        ""ISO3"": ""HUN"",
        ""CurrencyISO3"": ""HUF"",
        ""PhoneCode"": ""36""
    },
    {
        ""Name"": ""Hong Kong"",
        ""ISO2"": ""HK"",
        ""ISO3"": ""HKG"",
        ""CurrencyISO3"": ""HKD"",
        ""PhoneCode"": ""852""
    },
    {
        ""Name"": ""Honduras"",
        ""ISO2"": ""HN"",
        ""ISO3"": ""HND"",
        ""CurrencyISO3"": ""HNL"",
        ""PhoneCode"": ""504""
    },
    {
        ""Name"": ""Heard Island and McDonald Islands"",
        ""ISO2"": ""HM"",
        ""ISO3"": ""HMD"",
        ""CurrencyISO3"": ""AUD"",
        ""PhoneCode"": "" ""
    },
    {
        ""Name"": ""Venezuela"",
        ""ISO2"": ""VE"",
        ""ISO3"": ""VEN"",
        ""CurrencyISO3"": ""VEF"",
        ""PhoneCode"": ""58""
    },
    {
        ""Name"": ""Puerto Rico"",
        ""ISO2"": ""PR"",
        ""ISO3"": ""PRI"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""+1-787 and 1-939""
    },
    {
        ""Name"": ""Palestinian Territory"",
        ""ISO2"": ""PS"",
        ""ISO3"": ""PSE"",
        ""CurrencyISO3"": ""ILS"",
        ""PhoneCode"": ""970""
    },
    {
        ""Name"": ""Palau"",
        ""ISO2"": ""PW"",
        ""ISO3"": ""PLW"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""680""
    },
    {
        ""Name"": ""Portugal"",
        ""ISO2"": ""PT"",
        ""ISO3"": ""PRT"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""351""
    },
    {
        ""Name"": ""Svalbard and Jan Mayen"",
        ""ISO2"": ""SJ"",
        ""ISO3"": ""SJM"",
        ""CurrencyISO3"": ""NOK"",
        ""PhoneCode"": ""47""
    },
    {
        ""Name"": ""Paraguay"",
        ""ISO2"": ""PY"",
        ""ISO3"": ""PRY"",
        ""CurrencyISO3"": ""PYG"",
        ""PhoneCode"": ""595""
    },
    {
        ""Name"": ""Iraq"",
        ""ISO2"": ""IQ"",
        ""ISO3"": ""IRQ"",
        ""CurrencyISO3"": ""IQD"",
        ""PhoneCode"": ""964""
    },
    {
        ""Name"": ""Panama"",
        ""ISO2"": ""PA"",
        ""ISO3"": ""PAN"",
        ""CurrencyISO3"": ""PAB"",
        ""PhoneCode"": ""507""
    },
    {
        ""Name"": ""French Polynesia"",
        ""ISO2"": ""PF"",
        ""ISO3"": ""PYF"",
        ""CurrencyISO3"": ""XPF"",
        ""PhoneCode"": ""689""
    },
    {
        ""Name"": ""Papua New Guinea"",
        ""ISO2"": ""PG"",
        ""ISO3"": ""PNG"",
        ""CurrencyISO3"": ""PGK"",
        ""PhoneCode"": ""675""
    },
    {
        ""Name"": ""Peru"",
        ""ISO2"": ""PE"",
        ""ISO3"": ""PER"",
        ""CurrencyISO3"": ""PEN"",
        ""PhoneCode"": ""51""
    },
    {
        ""Name"": ""Pakistan"",
        ""ISO2"": ""PK"",
        ""ISO3"": ""PAK"",
        ""CurrencyISO3"": ""PKR"",
        ""PhoneCode"": ""92""
    },
    {
        ""Name"": ""Philippines"",
        ""ISO2"": ""PH"",
        ""ISO3"": ""PHL"",
        ""CurrencyISO3"": ""PHP"",
        ""PhoneCode"": ""63""
    },
    {
        ""Name"": ""Pitcairn"",
        ""ISO2"": ""PN"",
        ""ISO3"": ""PCN"",
        ""CurrencyISO3"": ""NZD"",
        ""PhoneCode"": ""870""
    },
    {
        ""Name"": ""Poland"",
        ""ISO2"": ""PL"",
        ""ISO3"": ""POL"",
        ""CurrencyISO3"": ""PLN"",
        ""PhoneCode"": ""48""
    },
    {
        ""Name"": ""Saint Pierre and Miquelon"",
        ""ISO2"": ""PM"",
        ""ISO3"": ""SPM"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""508""
    },
    {
        ""Name"": ""Zambia"",
        ""ISO2"": ""ZM"",
        ""ISO3"": ""ZMB"",
        ""CurrencyISO3"": ""ZMK"",
        ""PhoneCode"": ""260""
    },
    {
        ""Name"": ""Western Sahara"",
        ""ISO2"": ""EH"",
        ""ISO3"": ""ESH"",
        ""CurrencyISO3"": ""MAD"",
        ""PhoneCode"": ""212""
    },
    {
        ""Name"": ""Estonia"",
        ""ISO2"": ""EE"",
        ""ISO3"": ""EST"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""372""
    },
    {
        ""Name"": ""Egypt"",
        ""ISO2"": ""EG"",
        ""ISO3"": ""EGY"",
        ""CurrencyISO3"": ""EGP"",
        ""PhoneCode"": ""20""
    },
    {
        ""Name"": ""South Africa"",
        ""ISO2"": ""ZA"",
        ""ISO3"": ""ZAF"",
        ""CurrencyISO3"": ""ZAR"",
        ""PhoneCode"": ""27""
    },
    {
        ""Name"": ""Ecuador"",
        ""ISO2"": ""EC"",
        ""ISO3"": ""ECU"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""593""
    },
    {
        ""Name"": ""Italy"",
        ""ISO2"": ""IT"",
        ""ISO3"": ""ITA"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""39""
    },
    {
        ""Name"": ""Vietnam"",
        ""ISO2"": ""VN"",
        ""ISO3"": ""VNM"",
        ""CurrencyISO3"": ""VND"",
        ""PhoneCode"": ""84""
    },
    {
        ""Name"": ""Solomon Islands"",
        ""ISO2"": ""SB"",
        ""ISO3"": ""SLB"",
        ""CurrencyISO3"": ""SBD"",
        ""PhoneCode"": ""677""
    },
    {
        ""Name"": ""Ethiopia"",
        ""ISO2"": ""ET"",
        ""ISO3"": ""ETH"",
        ""CurrencyISO3"": ""ETB"",
        ""PhoneCode"": ""251""
    },
    {
        ""Name"": ""Somalia"",
        ""ISO2"": ""SO"",
        ""ISO3"": ""SOM"",
        ""CurrencyISO3"": ""SOS"",
        ""PhoneCode"": ""252""
    },
    {
        ""Name"": ""Zimbabwe"",
        ""ISO2"": ""ZW"",
        ""ISO3"": ""ZWE"",
        ""CurrencyISO3"": ""ZWL"",
        ""PhoneCode"": ""263""
    },
    {
        ""Name"": ""Saudi Arabia"",
        ""ISO2"": ""SA"",
        ""ISO3"": ""SAU"",
        ""CurrencyISO3"": ""SAR"",
        ""PhoneCode"": ""966""
    },
    {
        ""Name"": ""Spain"",
        ""ISO2"": ""ES"",
        ""ISO3"": ""ESP"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""34""
    },
    {
        ""Name"": ""Eritrea"",
        ""ISO2"": ""ER"",
        ""ISO3"": ""ERI"",
        ""CurrencyISO3"": ""ERN"",
        ""PhoneCode"": ""291""
    },
    {
        ""Name"": ""Montenegro"",
        ""ISO2"": ""ME"",
        ""ISO3"": ""MNE"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""382""
    },
    {
        ""Name"": ""Moldova"",
        ""ISO2"": ""MD"",
        ""ISO3"": ""MDA"",
        ""CurrencyISO3"": ""MDL"",
        ""PhoneCode"": ""373""
    },
    {
        ""Name"": ""Madagascar"",
        ""ISO2"": ""MG"",
        ""ISO3"": ""MDG"",
        ""CurrencyISO3"": ""MGA"",
        ""PhoneCode"": ""261""
    },
    {
        ""Name"": ""Saint Martin"",
        ""ISO2"": ""MF"",
        ""ISO3"": ""MAF"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""590""
    },
    {
        ""Name"": ""Morocco"",
        ""ISO2"": ""MA"",
        ""ISO3"": ""MAR"",
        ""CurrencyISO3"": ""MAD"",
        ""PhoneCode"": ""212""
    },
    {
        ""Name"": ""Monaco"",
        ""ISO2"": ""MC"",
        ""ISO3"": ""MCO"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""377""
    },
    {
        ""Name"": ""Uzbekistan"",
        ""ISO2"": ""UZ"",
        ""ISO3"": ""UZB"",
        ""CurrencyISO3"": ""UZS"",
        ""PhoneCode"": ""998""
    },
    {
        ""Name"": ""Myanmar"",
        ""ISO2"": ""MM"",
        ""ISO3"": ""MMR"",
        ""CurrencyISO3"": ""MMK"",
        ""PhoneCode"": ""95""
    },
    {
        ""Name"": ""Mali"",
        ""ISO2"": ""ML"",
        ""ISO3"": ""MLI"",
        ""CurrencyISO3"": ""XOF"",
        ""PhoneCode"": ""223""
    },
    {
        ""Name"": ""Macao"",
        ""ISO2"": ""MO"",
        ""ISO3"": ""MAC"",
        ""CurrencyISO3"": ""MOP"",
        ""PhoneCode"": ""853""
    },
    {
        ""Name"": ""Mongolia"",
        ""ISO2"": ""MN"",
        ""ISO3"": ""MNG"",
        ""CurrencyISO3"": ""MNT"",
        ""PhoneCode"": ""976""
    },
    {
        ""Name"": ""Marshall Islands"",
        ""ISO2"": ""MH"",
        ""ISO3"": ""MHL"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""692""
    },
    {
        ""Name"": ""Macedonia"",
        ""ISO2"": ""MK"",
        ""ISO3"": ""MKD"",
        ""CurrencyISO3"": ""MKD"",
        ""PhoneCode"": ""389""
    },
    {
        ""Name"": ""Mauritius"",
        ""ISO2"": ""MU"",
        ""ISO3"": ""MUS"",
        ""CurrencyISO3"": ""MUR"",
        ""PhoneCode"": ""230""
    },
    {
        ""Name"": ""Malta"",
        ""ISO2"": ""MT"",
        ""ISO3"": ""MLT"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""356""
    },
    {
        ""Name"": ""Malawi"",
        ""ISO2"": ""MW"",
        ""ISO3"": ""MWI"",
        ""CurrencyISO3"": ""MWK"",
        ""PhoneCode"": ""265""
    },
    {
        ""Name"": ""Maldives"",
        ""ISO2"": ""MV"",
        ""ISO3"": ""MDV"",
        ""CurrencyISO3"": ""MVR"",
        ""PhoneCode"": ""960""
    },
    {
        ""Name"": ""Martinique"",
        ""ISO2"": ""MQ"",
        ""ISO3"": ""MTQ"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""596""
    },
    {
        ""Name"": ""Northern Mariana Islands"",
        ""ISO2"": ""MP"",
        ""ISO3"": ""MNP"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""+1-670""
    },
    {
        ""Name"": ""Montserrat"",
        ""ISO2"": ""MS"",
        ""ISO3"": ""MSR"",
        ""CurrencyISO3"": ""XCD"",
        ""PhoneCode"": ""+1-664""
    },
    {
        ""Name"": ""Mauritania"",
        ""ISO2"": ""MR"",
        ""ISO3"": ""MRT"",
        ""CurrencyISO3"": ""MRO"",
        ""PhoneCode"": ""222""
    },
    {
        ""Name"": ""Isle of Man"",
        ""ISO2"": ""IM"",
        ""ISO3"": ""IMN"",
        ""CurrencyISO3"": ""GBP"",
        ""PhoneCode"": ""+44-1624""
    },
    {
        ""Name"": ""Uganda"",
        ""ISO2"": ""UG"",
        ""ISO3"": ""UGA"",
        ""CurrencyISO3"": ""UGX"",
        ""PhoneCode"": ""256""
    },
    {
        ""Name"": ""Tanzania"",
        ""ISO2"": ""TZ"",
        ""ISO3"": ""TZA"",
        ""CurrencyISO3"": ""TZS"",
        ""PhoneCode"": ""255""
    },
    {
        ""Name"": ""Malaysia"",
        ""ISO2"": ""MY"",
        ""ISO3"": ""MYS"",
        ""CurrencyISO3"": ""MYR"",
        ""PhoneCode"": ""60""
    },
    {
        ""Name"": ""Mexico"",
        ""ISO2"": ""MX"",
        ""ISO3"": ""MEX"",
        ""CurrencyISO3"": ""MXN"",
        ""PhoneCode"": ""52""
    },
    {
        ""Name"": ""Israel"",
        ""ISO2"": ""IL"",
        ""ISO3"": ""ISR"",
        ""CurrencyISO3"": ""ILS"",
        ""PhoneCode"": ""972""
    },
    {
        ""Name"": ""France"",
        ""ISO2"": ""FR"",
        ""ISO3"": ""FRA"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""33""
    },
    {
        ""Name"": ""British Indian Ocean Territory"",
        ""ISO2"": ""IO"",
        ""ISO3"": ""IOT"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""246""
    },
    {
        ""Name"": ""Saint Helena"",
        ""ISO2"": ""SH"",
        ""ISO3"": ""SHN"",
        ""CurrencyISO3"": ""SHP"",
        ""PhoneCode"": ""290""
    },
    {
        ""Name"": ""Finland"",
        ""ISO2"": ""FI"",
        ""ISO3"": ""FIN"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""358""
    },
    {
        ""Name"": ""Fiji"",
        ""ISO2"": ""FJ"",
        ""ISO3"": ""FJI"",
        ""CurrencyISO3"": ""FJD"",
        ""PhoneCode"": ""679""
    },
    {
        ""Name"": ""Falkland Islands"",
        ""ISO2"": ""FK"",
        ""ISO3"": ""FLK"",
        ""CurrencyISO3"": ""FKP"",
        ""PhoneCode"": ""500""
    },
    {
        ""Name"": ""Micronesia"",
        ""ISO2"": ""FM"",
        ""ISO3"": ""FSM"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""691""
    },
    {
        ""Name"": ""Faroe Islands"",
        ""ISO2"": ""FO"",
        ""ISO3"": ""FRO"",
        ""CurrencyISO3"": ""DKK"",
        ""PhoneCode"": ""298""
    },
    {
        ""Name"": ""Nicaragua"",
        ""ISO2"": ""NI"",
        ""ISO3"": ""NIC"",
        ""CurrencyISO3"": ""NIO"",
        ""PhoneCode"": ""505""
    },
    {
        ""Name"": ""Netherlands"",
        ""ISO2"": ""NL"",
        ""ISO3"": ""NLD"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""31""
    },
    {
        ""Name"": ""Norway"",
        ""ISO2"": ""NO"",
        ""ISO3"": ""NOR"",
        ""CurrencyISO3"": ""NOK"",
        ""PhoneCode"": ""47""
    },
    {
        ""Name"": ""Namibia"",
        ""ISO2"": ""NA"",
        ""ISO3"": ""NAM"",
        ""CurrencyISO3"": ""NAD"",
        ""PhoneCode"": ""264""
    },
    {
        ""Name"": ""Vanuatu"",
        ""ISO2"": ""VU"",
        ""ISO3"": ""VUT"",
        ""CurrencyISO3"": ""VUV"",
        ""PhoneCode"": ""678""
    },
    {
        ""Name"": ""New Caledonia"",
        ""ISO2"": ""NC"",
        ""ISO3"": ""NCL"",
        ""CurrencyISO3"": ""XPF"",
        ""PhoneCode"": ""687""
    },
    {
        ""Name"": ""Niger"",
        ""ISO2"": ""NE"",
        ""ISO3"": ""NER"",
        ""CurrencyISO3"": ""XOF"",
        ""PhoneCode"": ""227""
    },
    {
        ""Name"": ""Norfolk Island"",
        ""ISO2"": ""NF"",
        ""ISO3"": ""NFK"",
        ""CurrencyISO3"": ""AUD"",
        ""PhoneCode"": ""672""
    },
    {
        ""Name"": ""Nigeria"",
        ""ISO2"": ""NG"",
        ""ISO3"": ""NGA"",
        ""CurrencyISO3"": ""NGN"",
        ""PhoneCode"": ""234""
    },
    {
        ""Name"": ""New Zealand"",
        ""ISO2"": ""NZ"",
        ""ISO3"": ""NZL"",
        ""CurrencyISO3"": ""NZD"",
        ""PhoneCode"": ""64""
    },
    {
        ""Name"": ""Nepal"",
        ""ISO2"": ""NP"",
        ""ISO3"": ""NPL"",
        ""CurrencyISO3"": ""NPR"",
        ""PhoneCode"": ""977""
    },
    {
        ""Name"": ""Nauru"",
        ""ISO2"": ""NR"",
        ""ISO3"": ""NRU"",
        ""CurrencyISO3"": ""AUD"",
        ""PhoneCode"": ""674""
    },
    {
        ""Name"": ""Niue"",
        ""ISO2"": ""NU"",
        ""ISO3"": ""NIU"",
        ""CurrencyISO3"": ""NZD"",
        ""PhoneCode"": ""683""
    },
    {
        ""Name"": ""Cook Islands"",
        ""ISO2"": ""CK"",
        ""ISO3"": ""COK"",
        ""CurrencyISO3"": ""NZD"",
        ""PhoneCode"": ""682""
    },
    {
        ""Name"": ""Kosovo"",
        ""ISO2"": ""XK"",
        ""ISO3"": ""XKX"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": """"
    },
    {
        ""Name"": ""Ivory Coast"",
        ""ISO2"": ""CI"",
        ""ISO3"": ""CIV"",
        ""CurrencyISO3"": ""XOF"",
        ""PhoneCode"": ""225""
    },
    {
        ""Name"": ""Switzerland"",
        ""ISO2"": ""CH"",
        ""ISO3"": ""CHE"",
        ""CurrencyISO3"": ""CHF"",
        ""PhoneCode"": ""41""
    },
    {
        ""Name"": ""Colombia"",
        ""ISO2"": ""CO"",
        ""ISO3"": ""COL"",
        ""CurrencyISO3"": ""COP"",
        ""PhoneCode"": ""57""
    },
    {
        ""Name"": ""China"",
        ""ISO2"": ""CN"",
        ""ISO3"": ""CHN"",
        ""CurrencyISO3"": ""CNY"",
        ""PhoneCode"": ""86""
    },
    {
        ""Name"": ""Cameroon"",
        ""ISO2"": ""CM"",
        ""ISO3"": ""CMR"",
        ""CurrencyISO3"": ""XAF"",
        ""PhoneCode"": ""237""
    },
    {
        ""Name"": ""Chile"",
        ""ISO2"": ""CL"",
        ""ISO3"": ""CHL"",
        ""CurrencyISO3"": ""CLP"",
        ""PhoneCode"": ""56""
    },
    {
        ""Name"": ""Cocos Islands"",
        ""ISO2"": ""CC"",
        ""ISO3"": ""CCK"",
        ""CurrencyISO3"": ""AUD"",
        ""PhoneCode"": ""61""
    },
    {
        ""Name"": ""Canada"",
        ""ISO2"": ""CA"",
        ""ISO3"": ""CAN"",
        ""CurrencyISO3"": ""CAD"",
        ""PhoneCode"": ""1""
    },
    {
        ""Name"": ""Republic of the Congo"",
        ""ISO2"": ""CG"",
        ""ISO3"": ""COG"",
        ""CurrencyISO3"": ""XAF"",
        ""PhoneCode"": ""242""
    },
    {
        ""Name"": ""Central African Republic"",
        ""ISO2"": ""CF"",
        ""ISO3"": ""CAF"",
        ""CurrencyISO3"": ""XAF"",
        ""PhoneCode"": ""236""
    },
    {
        ""Name"": ""Democratic Republic of the Congo"",
        ""ISO2"": ""CD"",
        ""ISO3"": ""COD"",
        ""CurrencyISO3"": ""CDF"",
        ""PhoneCode"": ""243""
    },
    {
        ""Name"": ""Czech Republic"",
        ""ISO2"": ""CZ"",
        ""ISO3"": ""CZE"",
        ""CurrencyISO3"": ""CZK"",
        ""PhoneCode"": ""420""
    },
    {
        ""Name"": ""Cyprus"",
        ""ISO2"": ""CY"",
        ""ISO3"": ""CYP"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""357""
    },
    {
        ""Name"": ""Christmas Island"",
        ""ISO2"": ""CX"",
        ""ISO3"": ""CXR"",
        ""CurrencyISO3"": ""AUD"",
        ""PhoneCode"": ""61""
    },
    {
        ""Name"": ""Costa Rica"",
        ""ISO2"": ""CR"",
        ""ISO3"": ""CRI"",
        ""CurrencyISO3"": ""CRC"",
        ""PhoneCode"": ""506""
    },
    {
        ""Name"": ""Curacao"",
        ""ISO2"": ""CW"",
        ""ISO3"": ""CUW"",
        ""CurrencyISO3"": ""ANG"",
        ""PhoneCode"": ""599""
    },
    {
        ""Name"": ""Cape Verde"",
        ""ISO2"": ""CV"",
        ""ISO3"": ""CPV"",
        ""CurrencyISO3"": ""CVE"",
        ""PhoneCode"": ""238""
    },
    {
        ""Name"": ""Cuba"",
        ""ISO2"": ""CU"",
        ""ISO3"": ""CUB"",
        ""CurrencyISO3"": ""CUP"",
        ""PhoneCode"": ""53""
    },
    {
        ""Name"": ""Swaziland"",
        ""ISO2"": ""SZ"",
        ""ISO3"": ""SWZ"",
        ""CurrencyISO3"": ""SZL"",
        ""PhoneCode"": ""268""
    },
    {
        ""Name"": ""Syria"",
        ""ISO2"": ""SY"",
        ""ISO3"": ""SYR"",
        ""CurrencyISO3"": ""SYP"",
        ""PhoneCode"": ""963""
    },
    {
        ""Name"": ""Sint Maarten"",
        ""ISO2"": ""SX"",
        ""ISO3"": ""SXM"",
        ""CurrencyISO3"": ""ANG"",
        ""PhoneCode"": ""599""
    },
    {
        ""Name"": ""Kyrgyzstan"",
        ""ISO2"": ""KG"",
        ""ISO3"": ""KGZ"",
        ""CurrencyISO3"": ""KGS"",
        ""PhoneCode"": ""996""
    },
    {
        ""Name"": ""Kenya"",
        ""ISO2"": ""KE"",
        ""ISO3"": ""KEN"",
        ""CurrencyISO3"": ""KES"",
        ""PhoneCode"": ""254""
    },
    {
        ""Name"": ""South Sudan"",
        ""ISO2"": ""SS"",
        ""ISO3"": ""SSD"",
        ""CurrencyISO3"": ""SSP"",
        ""PhoneCode"": ""211""
    },
    {
        ""Name"": ""Suriname"",
        ""ISO2"": ""SR"",
        ""ISO3"": ""SUR"",
        ""CurrencyISO3"": ""SRD"",
        ""PhoneCode"": ""597""
    },
    {
        ""Name"": ""Kiribati"",
        ""ISO2"": ""KI"",
        ""ISO3"": ""KIR"",
        ""CurrencyISO3"": ""AUD"",
        ""PhoneCode"": ""686""
    },
    {
        ""Name"": ""Cambodia"",
        ""ISO2"": ""KH"",
        ""ISO3"": ""KHM"",
        ""CurrencyISO3"": ""KHR"",
        ""PhoneCode"": ""855""
    },
    {
        ""Name"": ""Saint Kitts and Nevis"",
        ""ISO2"": ""KN"",
        ""ISO3"": ""KNA"",
        ""CurrencyISO3"": ""XCD"",
        ""PhoneCode"": ""+1-869""
    },
    {
        ""Name"": ""Comoros"",
        ""ISO2"": ""KM"",
        ""ISO3"": ""COM"",
        ""CurrencyISO3"": ""KMF"",
        ""PhoneCode"": ""269""
    },
    {
        ""Name"": ""Sao Tome and Principe"",
        ""ISO2"": ""ST"",
        ""ISO3"": ""STP"",
        ""CurrencyISO3"": ""STD"",
        ""PhoneCode"": ""239""
    },
    {
        ""Name"": ""Slovakia"",
        ""ISO2"": ""SK"",
        ""ISO3"": ""SVK"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""421""
    },
    {
        ""Name"": ""South Korea"",
        ""ISO2"": ""KR"",
        ""ISO3"": ""KOR"",
        ""CurrencyISO3"": ""KRW"",
        ""PhoneCode"": ""82""
    },
    {
        ""Name"": ""Slovenia"",
        ""ISO2"": ""SI"",
        ""ISO3"": ""SVN"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""386""
    },
    {
        ""Name"": ""North Korea"",
        ""ISO2"": ""KP"",
        ""ISO3"": ""PRK"",
        ""CurrencyISO3"": ""KPW"",
        ""PhoneCode"": ""850""
    },
    {
        ""Name"": ""Kuwait"",
        ""ISO2"": ""KW"",
        ""ISO3"": ""KWT"",
        ""CurrencyISO3"": ""KWD"",
        ""PhoneCode"": ""965""
    },
    {
        ""Name"": ""Senegal"",
        ""ISO2"": ""SN"",
        ""ISO3"": ""SEN"",
        ""CurrencyISO3"": ""XOF"",
        ""PhoneCode"": ""221""
    },
    {
        ""Name"": ""San Marino"",
        ""ISO2"": ""SM"",
        ""ISO3"": ""SMR"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""378""
    },
    {
        ""Name"": ""Sierra Leone"",
        ""ISO2"": ""SL"",
        ""ISO3"": ""SLE"",
        ""CurrencyISO3"": ""SLL"",
        ""PhoneCode"": ""232""
    },
    {
        ""Name"": ""Seychelles"",
        ""ISO2"": ""SC"",
        ""ISO3"": ""SYC"",
        ""CurrencyISO3"": ""SCR"",
        ""PhoneCode"": ""248""
    },
    {
        ""Name"": ""Kazakhstan"",
        ""ISO2"": ""KZ"",
        ""ISO3"": ""KAZ"",
        ""CurrencyISO3"": ""KZT"",
        ""PhoneCode"": ""7""
    },
    {
        ""Name"": ""Cayman Islands"",
        ""ISO2"": ""KY"",
        ""ISO3"": ""CYM"",
        ""CurrencyISO3"": ""KYD"",
        ""PhoneCode"": ""+1-345""
    },
    {
        ""Name"": ""Singapore"",
        ""ISO2"": ""SG"",
        ""ISO3"": ""SGP"",
        ""CurrencyISO3"": ""SGD"",
        ""PhoneCode"": ""65""
    },
    {
        ""Name"": ""Sweden"",
        ""ISO2"": ""SE"",
        ""ISO3"": ""SWE"",
        ""CurrencyISO3"": ""SEK"",
        ""PhoneCode"": ""46""
    },
    {
        ""Name"": ""Sudan"",
        ""ISO2"": ""SD"",
        ""ISO3"": ""SDN"",
        ""CurrencyISO3"": ""SDG"",
        ""PhoneCode"": ""249""
    },
    {
        ""Name"": ""Dominican Republic"",
        ""ISO2"": ""DO"",
        ""ISO3"": ""DOM"",
        ""CurrencyISO3"": ""DOP"",
        ""PhoneCode"": ""+1-809 and 1-829""
    },
    {
        ""Name"": ""Dominica"",
        ""ISO2"": ""DM"",
        ""ISO3"": ""DMA"",
        ""CurrencyISO3"": ""XCD"",
        ""PhoneCode"": ""+1-767""
    },
    {
        ""Name"": ""Djibouti"",
        ""ISO2"": ""DJ"",
        ""ISO3"": ""DJI"",
        ""CurrencyISO3"": ""DJF"",
        ""PhoneCode"": ""253""
    },
    {
        ""Name"": ""Denmark"",
        ""ISO2"": ""DK"",
        ""ISO3"": ""DNK"",
        ""CurrencyISO3"": ""DKK"",
        ""PhoneCode"": ""45""
    },
    {
        ""Name"": ""British Virgin Islands"",
        ""ISO2"": ""VG"",
        ""ISO3"": ""VGB"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""+1-284""
    },
    {
        ""Name"": ""Germany"",
        ""ISO2"": ""DE"",
        ""ISO3"": ""DEU"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""49""
    },
    {
        ""Name"": ""Yemen"",
        ""ISO2"": ""YE"",
        ""ISO3"": ""YEM"",
        ""CurrencyISO3"": ""YER"",
        ""PhoneCode"": ""967""
    },
    {
        ""Name"": ""Algeria"",
        ""ISO2"": ""DZ"",
        ""ISO3"": ""DZA"",
        ""CurrencyISO3"": ""DZD"",
        ""PhoneCode"": ""213""
    },
    {
        ""Name"": ""United States"",
        ""ISO2"": ""US"",
        ""ISO3"": ""USA"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""1""
    },
    {
        ""Name"": ""Uruguay"",
        ""ISO2"": ""UY"",
        ""ISO3"": ""URY"",
        ""CurrencyISO3"": ""UYU"",
        ""PhoneCode"": ""598""
    },
    {
        ""Name"": ""Mayotte"",
        ""ISO2"": ""YT"",
        ""ISO3"": ""MYT"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""262""
    },
    {
        ""Name"": ""United States Minor Outlying Islands"",
        ""ISO2"": ""UM"",
        ""ISO3"": ""UMI"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""1""
    },
    {
        ""Name"": ""Lebanon"",
        ""ISO2"": ""LB"",
        ""ISO3"": ""LBN"",
        ""CurrencyISO3"": ""LBP"",
        ""PhoneCode"": ""961""
    },
    {
        ""Name"": ""Saint Lucia"",
        ""ISO2"": ""LC"",
        ""ISO3"": ""LCA"",
        ""CurrencyISO3"": ""XCD"",
        ""PhoneCode"": ""+1-758""
    },
    {
        ""Name"": ""Laos"",
        ""ISO2"": ""LA"",
        ""ISO3"": ""LAO"",
        ""CurrencyISO3"": ""LAK"",
        ""PhoneCode"": ""856""
    },
    {
        ""Name"": ""Tuvalu"",
        ""ISO2"": ""TV"",
        ""ISO3"": ""TUV"",
        ""CurrencyISO3"": ""AUD"",
        ""PhoneCode"": ""688""
    },
    {
        ""Name"": ""Taiwan"",
        ""ISO2"": ""TW"",
        ""ISO3"": ""TWN"",
        ""CurrencyISO3"": ""TWD"",
        ""PhoneCode"": ""886""
    },
    {
        ""Name"": ""Trinidad and Tobago"",
        ""ISO2"": ""TT"",
        ""ISO3"": ""TTO"",
        ""CurrencyISO3"": ""TTD"",
        ""PhoneCode"": ""+1-868""
    },
    {
        ""Name"": ""Turkey"",
        ""ISO2"": ""TR"",
        ""ISO3"": ""TUR"",
        ""CurrencyISO3"": ""TRY"",
        ""PhoneCode"": ""90""
    },
    {
        ""Name"": ""Sri Lanka"",
        ""ISO2"": ""LK"",
        ""ISO3"": ""LKA"",
        ""CurrencyISO3"": ""LKR"",
        ""PhoneCode"": ""94""
    },
    {
        ""Name"": ""Liechtenstein"",
        ""ISO2"": ""LI"",
        ""ISO3"": ""LIE"",
        ""CurrencyISO3"": ""CHF"",
        ""PhoneCode"": ""423""
    },
    {
        ""Name"": ""Latvia"",
        ""ISO2"": ""LV"",
        ""ISO3"": ""LVA"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""371""
    },
    {
        ""Name"": ""Tonga"",
        ""ISO2"": ""TO"",
        ""ISO3"": ""TON"",
        ""CurrencyISO3"": ""TOP"",
        ""PhoneCode"": ""676""
    },
    {
        ""Name"": ""Lithuania"",
        ""ISO2"": ""LT"",
        ""ISO3"": ""LTU"",
        ""CurrencyISO3"": ""LTL"",
        ""PhoneCode"": ""370""
    },
    {
        ""Name"": ""Luxembourg"",
        ""ISO2"": ""LU"",
        ""ISO3"": ""LUX"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""352""
    },
    {
        ""Name"": ""Liberia"",
        ""ISO2"": ""LR"",
        ""ISO3"": ""LBR"",
        ""CurrencyISO3"": ""LRD"",
        ""PhoneCode"": ""231""
    },
    {
        ""Name"": ""Lesotho"",
        ""ISO2"": ""LS"",
        ""ISO3"": ""LSO"",
        ""CurrencyISO3"": ""LSL"",
        ""PhoneCode"": ""266""
    },
    {
        ""Name"": ""Thailand"",
        ""ISO2"": ""TH"",
        ""ISO3"": ""THA"",
        ""CurrencyISO3"": ""THB"",
        ""PhoneCode"": ""66""
    },
    {
        ""Name"": ""French Southern Territories"",
        ""ISO2"": ""TF"",
        ""ISO3"": ""ATF"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": """"
    },
    {
        ""Name"": ""Togo"",
        ""ISO2"": ""TG"",
        ""ISO3"": ""TGO"",
        ""CurrencyISO3"": ""XOF"",
        ""PhoneCode"": ""228""
    },
    {
        ""Name"": ""Chad"",
        ""ISO2"": ""TD"",
        ""ISO3"": ""TCD"",
        ""CurrencyISO3"": ""XAF"",
        ""PhoneCode"": ""235""
    },
    {
        ""Name"": ""Turks and Caicos Islands"",
        ""ISO2"": ""TC"",
        ""ISO3"": ""TCA"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""+1-649""
    },
    {
        ""Name"": ""Libya"",
        ""ISO2"": ""LY"",
        ""ISO3"": ""LBY"",
        ""CurrencyISO3"": ""LYD"",
        ""PhoneCode"": ""218""
    },
    {
        ""Name"": ""Vatican"",
        ""ISO2"": ""VA"",
        ""ISO3"": ""VAT"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""379""
    },
    {
        ""Name"": ""Saint Vincent and the Grenadines"",
        ""ISO2"": ""VC"",
        ""ISO3"": ""VCT"",
        ""CurrencyISO3"": ""XCD"",
        ""PhoneCode"": ""+1-784""
    },
    {
        ""Name"": ""United Arab Emirates"",
        ""ISO2"": ""AE"",
        ""ISO3"": ""ARE"",
        ""CurrencyISO3"": ""AED"",
        ""PhoneCode"": ""971""
    },
    {
        ""Name"": ""Andorra"",
        ""ISO2"": ""AD"",
        ""ISO3"": ""AND"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""376""
    },
    {
        ""Name"": ""Antigua and Barbuda"",
        ""ISO2"": ""AG"",
        ""ISO3"": ""ATG"",
        ""CurrencyISO3"": ""XCD"",
        ""PhoneCode"": ""+1-268""
    },
    {
        ""Name"": ""Afghanistan"",
        ""ISO2"": ""AF"",
        ""ISO3"": ""AFG"",
        ""CurrencyISO3"": ""AFN"",
        ""PhoneCode"": ""93""
    },
    {
        ""Name"": ""Anguilla"",
        ""ISO2"": ""AI"",
        ""ISO3"": ""AIA"",
        ""CurrencyISO3"": ""XCD"",
        ""PhoneCode"": ""+1-264""
    },
    {
        ""Name"": ""U.S. Virgin Islands"",
        ""ISO2"": ""VI"",
        ""ISO3"": ""VIR"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""+1-340""
    },
    {
        ""Name"": ""Iceland"",
        ""ISO2"": ""IS"",
        ""ISO3"": ""ISL"",
        ""CurrencyISO3"": ""ISK"",
        ""PhoneCode"": ""354""
    },
    {
        ""Name"": ""Iran"",
        ""ISO2"": ""IR"",
        ""ISO3"": ""IRN"",
        ""CurrencyISO3"": ""IRR"",
        ""PhoneCode"": ""98""
    },
    {
        ""Name"": ""Armenia"",
        ""ISO2"": ""AM"",
        ""ISO3"": ""ARM"",
        ""CurrencyISO3"": ""AMD"",
        ""PhoneCode"": ""374""
    },
    {
        ""Name"": ""Albania"",
        ""ISO2"": ""AL"",
        ""ISO3"": ""ALB"",
        ""CurrencyISO3"": ""ALL"",
        ""PhoneCode"": ""355""
    },
    {
        ""Name"": ""Angola"",
        ""ISO2"": ""AO"",
        ""ISO3"": ""AGO"",
        ""CurrencyISO3"": ""AOA"",
        ""PhoneCode"": ""244""
    },
    {
        ""Name"": ""Antarctica"",
        ""ISO2"": ""AQ"",
        ""ISO3"": ""ATA"",
        ""CurrencyISO3"": """",
        ""PhoneCode"": """"
    },
    {
        ""Name"": ""American Samoa"",
        ""ISO2"": ""AS"",
        ""ISO3"": ""ASM"",
        ""CurrencyISO3"": ""USD"",
        ""PhoneCode"": ""+1-684""
    },
    {
        ""Name"": ""Argentina"",
        ""ISO2"": ""AR"",
        ""ISO3"": ""ARG"",
        ""CurrencyISO3"": ""ARS"",
        ""PhoneCode"": ""54""
    },
    {
        ""Name"": ""Australia"",
        ""ISO2"": ""AU"",
        ""ISO3"": ""AUS"",
        ""CurrencyISO3"": ""AUD"",
        ""PhoneCode"": ""61""
    },
    {
        ""Name"": ""Austria"",
        ""ISO2"": ""AT"",
        ""ISO3"": ""AUT"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""43""
    },
    {
        ""Name"": ""Aruba"",
        ""ISO2"": ""AW"",
        ""ISO3"": ""ABW"",
        ""CurrencyISO3"": ""AWG"",
        ""PhoneCode"": ""297""
    },
    {
        ""Name"": ""India"",
        ""ISO2"": ""IN"",
        ""ISO3"": ""IND"",
        ""CurrencyISO3"": ""INR"",
        ""PhoneCode"": ""91""
    },
    {
        ""Name"": ""Aland Islands"",
        ""ISO2"": ""AX"",
        ""ISO3"": ""ALA"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""+358-18""
    },
    {
        ""Name"": ""Azerbaijan"",
        ""ISO2"": ""AZ"",
        ""ISO3"": ""AZE"",
        ""CurrencyISO3"": ""AZN"",
        ""PhoneCode"": ""994""
    },
    {
        ""Name"": ""Ireland"",
        ""ISO2"": ""IE"",
        ""ISO3"": ""IRL"",
        ""CurrencyISO3"": ""EUR"",
        ""PhoneCode"": ""353""
    },
    {
        ""Name"": ""Indonesia"",
        ""ISO2"": ""ID"",
        ""ISO3"": ""IDN"",
        ""CurrencyISO3"": ""IDR"",
        ""PhoneCode"": ""62""
    },
    {
        ""Name"": ""Ukraine"",
        ""ISO2"": ""UA"",
        ""ISO3"": ""UKR"",
        ""CurrencyISO3"": ""UAH"",
        ""PhoneCode"": ""380""
    },
    {
        ""Name"": ""Qatar"",
        ""ISO2"": ""QA"",
        ""ISO3"": ""QAT"",
        ""CurrencyISO3"": ""QAR"",
        ""PhoneCode"": ""974""
    },
    {
        ""Name"": ""Mozambique"",
        ""ISO2"": ""MZ"",
        ""ISO3"": ""MOZ"",
        ""CurrencyISO3"": ""MZN"",
        ""PhoneCode"": ""258""
    }
]";

        /// <summary>
        ///     Returns a collection countries with their basic information
        /// </summary>
        public static IReadOnlyList<CountryModel> GetCountries =>
            JsonConvert.DeserializeObject<List<CountryModel>>(CountriesJson);
    }

    /// <summary>
    ///     Country model
    /// </summary>
    public class CountryModel
    {
        /// <summary>
        ///     Country ISO 3166-1 Alpha-3 code
        /// </summary>
        public string ISO3 { get; set; }

        /// <summary>
        ///     Country ISO 3166-1 Alpha-2 code
        /// </summary>
        public string ISO2 { get; set; }

        /// <summary>
        ///     Country name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Country currency ISO 4217 Alpha-3 code
        /// </summary>
        public string CurrencyISO3 { get; set; }

        /// <summary>
        ///     Country international phone dialing code
        /// </summary>
        public string PhoneCode { get; set; }
    }
}