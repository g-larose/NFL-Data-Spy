using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class StringExtension
    {

        public static string ToStringDivision(this Division division)
        {
            var result = division switch
            {
                Division.AFC_EAST  => "AFC EAST",
                Division.AFC_NORTH => "AFC NORTH",
                Division.AFC_WEST  => "AFC WEST",
                Division.AFC_SOUTH => "AFC SOUTH",
                Division.NFC_EAST  => "NFC EAST",
                Division.NFC_NORTH => "NFC NORTH",
                Division.NFC_WEST  => "NFC WEST",
                Division.NFC_SOUTH => "NFC SOUTH",
                _ => "UNKNOWN DIVISION"
            };

            return result;
        }

        public static string ToTeamAbr(this string teamName)
        {
            //TODO: fix the names.
            var name = teamName switch
            {
                "arizona"      => "ARI",
                "atlanta"      => "ATL",
                "baltimore"    => "BAL",
                "buffalo"      => "BUF",
                "carolina"     => "CAR",
                "chicago"      => "CHI",
                "cincinnati"   => "CIN",
                "cleveland"    => "CLE",
                "dallas"       => "DAL",
                "denver"       => "DEN",
                "detroit"      => "DET",
                "green bay"   => "GB",
                "texans"       => "HOU",
                "tennessee"    => "HOU",
                "indianapolis" => "IND",
                "jacksonville" => "JAC",
                "kansas city"  => "KC",
                "las vegas"    => "LV",
                "chargers"     => "LAC",
                "la rams"      => "LAR",
                "miami"        => "MIA",
                "minnesota"    => "MIN",
                "new england"  => "NE",
                "new orleans"  => "NO",
                "ny giants"    => "NYG",
                "ny jets"      => "NYJ",
                "philadelphia" => "PHI",
                "pittsburgh"   => "PIT",
                "49ers"        => "SF",
                "seattle"      => "SEA",
                "tampa bay"    => "TB",
                "titans"       => "TEN",
                "washington"   => "WAS",
                _ => "Unknown"
            };

            return name;
        }

        public static string ToHtmlteamName(this string value)
        {
            var name = value switch
            {
                "Cardinals"  => "arizona-cardinals",
                "Falcons"    => "atlanta-falcons",
                "Ravens"     => "baltimore-ravens",
                "Bills"      => "buffalo-bills",
                "Panthers"   => "carolina-panthers",
                "Bears"      => "chicago-bears",
                "Bengals"    => "cincinnati-bengals",
                "Browns"     => "cleveland-browns",
                "Cowboys"    => "dallas-cowboys",
                "Broncos"    => "denver-broncos",
                "Lions"      => "detroit-lions",
                "Packers"    => "green-bay-packers",
                "Texans"     => "houston-texans",
                "Colts"      => "indianapolis-colts",
                "Jaguars"    => "jacksonville-jaguars",
                "Chiefs"     => "kansas-city-chiefs",
                "Rams"       => "los-angeles--rams",
                "Dolphins"   => "miami-dolphins",
                "Vikings"    => "minnesota-vikings",
                "Patriots"   => "new-england-patriots",
                "Saints"     => "new-orleans-saints",
                "Giants"     => "new-york-giants",
                "Jets"       => "new-york-jets",
                "Raiders"    => "las-vegas-raiders",
                "Eagles"     => "philadelphia-eagles",
                "Steelers"   => "pittsburgh-steelers",
                "Chargers"   => "loa-angeles-chargers",
                "49ers"      => "san-francisco-49ers",
                "Seahawks"   => "seattle-seahawks",
                "Buccaneers" => "tampa-bay-buccaneers",
                "Titans"     => "tennessee-titans",
                "Redskins"   => "washington-commanders",
                _ => "Unknown"
            };

            return name;
        }

        public static string ToLogoUri(this string value)
        {
            var url = value switch
            {
                "Arizona"       => "/Images/Logo/ARI.png",
                "Atlanta"       => "/Images/Logo/ATL.png",
                "Baltimore"     => "/Images/Logo/BAL.png",
                "Buffalo"       => "/Images/Logo/BUF.png",
                "Carolina"      => "/Images/Logo/CAR.png",
                "Chicago"       => "/Images/Logo/CHI.png",
                "Cincinnati"    => "/Images/Logo/CIN.png",
                "Cleveland"     => "/Images/Logo/CLE.png",
                "Dallas"        => "/Images/Logo/DAL.png",
                "Denver"        => "/Images/Logo/DEN.png",
                "Detroit"       => "/Images/Logo/DET.png",
                "Green Bay"    => "/Images/Logo/GB.png",
                "Houston"       => "/Images/Logo/HOU.png",
                "Indianapolis"  => "/Images/Logo/IND.png",
                "Jacksonville"  => "/Images/Logo/JAX.png",
                "Kansas City"   => "/Images/Logo/KC.png",
                "LA Rams"       => "/Images/Logo/LAR.png",
                "Miami"         => "/Images/Logo/MIA.png",
                "Minnesota"     => "/Images/Logo/MIN.png",
                "New England"   => "/Images/Logo/NE.png",
                "New Orleans"   => "/Images/Logo/NO.png",
                "NY Giants"     => "/Images/Logo/NYG.png",
                "NY Jets"       => "/Images/Logo/NYJ.png",
                "Las Vegas"     => "/Images/Logo/LV.png",
                "Philadelphia"  => "/Images/Logo/PHI.png",
                "Pittsburgh"    => "/Images/Logo/PIT.png",
                "LA Chargers"   => "/Images/Logo/LAC.png",
                "San Francisco" => "/Images/Logo/SF.png",
                "Seattle"       => "/Images/Logo/SEA.png",
                "Tampa Bay"     => "/Images/Logo/TB.png",
                "Tennessee"     => "/Images/Logo/TEN.png",
                "Washington"    => "/Images/Logo/WAS.png",
                _ => "Unknown"
            };

            return url;
        }

        public static string ToDivisionString(this string value)
        {
            var division = value switch
            {
                "Arizona"       => "NFC WEST",
                "Atlanta"       => "NFC SOUTH",
                "Baltimore"     => "AFC NORTH",
                "Buffalo"       => "AFC EAST",
                "Carolina"      => "NFC SOUTH",
                "Chicago"       => "NFC NORTH",
                "Cincinnati"    => "AFC NORTH",
                "Cleveland"     => "AFC NORTH",
                "Dallas"        => "NFC EAST",
                "Denver"        => "AFC WEST",
                "Detroit"       => "NFC NORTH",
                "Green Bay"    => "NFC NORTH",
                "Houston"       => "AFC SOUTH",
                "Indianapolis"  => "AFC SOUTH",
                "Jacksonville"  => "AFC SOUTH",
                "Kansas City"   => "AFC WEST",
                "LA Rams"       => "NFC WEST",
                "Miami"         => "AFC EAST",
                "Minnesota"     => "NFC NORTH",
                "New England"   => "AFC EAST",
                "New Orleans"   => "NFC SOUTH",
                "NY Giants"     => "NFC EAST",
                "NY Jets"       => "AFC EAST",
                "Las Vegas"     => "AFC WEST",
                "Philadelphia"  => "NFC EAST",
                "Pittsburgh"    => "AFC NORTH",
                "LA Chargers"   => "AFC WEST",
                "San Francisco" => "NFC WEST",
                "Seattle"       => "NFC WEST",
                "Tampa Bay"     => "NFC SOUTH",
                "Tennessee"     => "AFC SOUTH",
                "Washington"    => "NFC EAST",
                _ => "Unknown"

            };

             return division;
        }

        public static Division ToDivision(this string value)
        {
            var result = value switch
            {
                "AFC EAST" => Division.AFC_EAST,
                "AFC WEST" => Division.AFC_WEST,
                "AFC NORTH" => Division.AFC_NORTH,
                "AFC SOUTH" => Division.AFC_SOUTH,
                "NFC EAST" => Division.NFC_EAST,
                "NFC WEST" => Division.NFC_WEST,
                "NFC NORTH" => Division.NFC_NORTH,
                "NFC SOUTH" => Division.NFC_SOUTH,
                _ => Division.UNKNOWN,
            };

            return result;
        }
    }
}
