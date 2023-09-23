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
        //TODO finish ToHtmlteamName method and ToLogoUri method

        public static string ToStringDivision(this Division division)
        {
            var result = division switch
            {
                Division.AFC_EAST => "AFC EAST",
                Division.AFC_NORTH => "AFC NORTH",
                Division.AFC_WEST => "AFC WEST",
                Division.AFC_SOUTH => "AFC SOUTH",
                Division.NFC_EAST => "NFC EAST",
                Division.NFC_NORTH => "NFC NORTH",
                Division.NFC_WEST => "NFC WEST",
                Division.NFC_SOUTH => "NFC SOUTH",
                _ => "UNKNOWN DIVISION"
            };

            return result;
        }

        public static string ToTeamAbr(this string teamName)
        {
            var name = teamName switch
            {
                "arizona" => "ARI",
                "atlanta" => "ATL",
                "baltimore" => "BAL",
                "buffalo" => "BUF",
                "carolina" => "CAR",
                "chicago" => "CHI",
                "cincinnati" => "CIN",
                "cleveland" => "CLE",
                "dallas" => "DAL",
                "denver" => "DEN",
                "detroit" => "DET",
                "green bay" => "GB",
                "texans" => "HOU",
                "tennessee" => "HOU",
                "indianapolis" => "IND",
                "jacksonville" => "JAC",
                "kansas city" => "KC",
                "las vegas" => "LV",
                "chargers" => "LAC",
                "la rams" => "LAR",
                "miami" => "MIA",
                "minnesota" => "MIN",
                "new england" => "NE",
                "new orleans" => "NO",
                "ny giants" => "NYG",
                "ny jets" => "NYJ",
                "philadelphia" => "PHI",
                "pittsburgh" => "PIT",
                "49ers" => "SF",
                "seattle" => "SEA",
                "tampa bay" => "TB",
                "titans" => "TEN",
                "washington" => "WAS",
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
                "Packers"    => "greenbay-packers",
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
                "arizona-cardinals"     => "Images/Logo/ARI.png",
                "atlanta-falcons"       => "Images/Logo/ATL.png",
                "baltimore-ravens"      => "Images/Logo/BAL.png",
                "buffalo-bills"         => "Images/Logo/BUF.png",
                "carolina-panthers"     => "Images/Logo/CAR.png",
                "chicago-bears"         => "Images/Logo/CHI.png",
                "cincinnati-bengals"    => "Images/Logo/CIN/png",
                "cleveland-browns"      => "Images/Logo/CLE.png",
                "dallas-cowboys"        => "Images/Logo/DAL.png",
                "denver-broncos"        => "Images/Logo/DEN.png",
                "detroit-lions"         => "Images/Logo/DET.png",
                "greenbay-packers"      => "Images/Logo/GB.png",
                "houston-texans"        => "Images/Logo/HOU.png",
                "indianapolis-colts"    => "Images/Logo/IND.png",
                "jacksonville-jaguars"  => "Images/Logo/JAC.png",
                "kansas-city-chiefs"    => "Images/Logo/KC.png",
                "los-angeles--rams"     => "Images/Logo/LAR.png",
                "miami-dolphins"        => "Images/Logo/MIA.png",
                "minnesota-vikings"     => "Images/Logo/MIN.png",
                "new-england-patriots"  => "Images/Logo/NE.png",
                "new-orleans-saints"    => "Images/Logo/NO.png",
                "new-york-giants"       => "Images/Logo/NYG.png",
                "new-york-jets"         => "Images/Logo/NYJ.png",
                "las-vegas-raiders"     => "Images/Logo/LAR.png",
                "philadelphia-eagles"   => "Images/Logo/PHI.png",
                "pittsburgh-steelers"   => "Images/Logo/PIT.png",
                "loa-angeles-chargers"  => "Images/Logo/LAC.png",
                "san-francisco-49ers"   => "Images/Logo/SF.png",
                "seattle-seahawks"      => "Images/Logo/SEA.png",
                "tampa-bay-buccaneers"  => "Images/Logo/TB.png",
                "tennessee-titans"      => "Images/Logo/TEN.png",
                "washington-commanders" => "Images/Logo/WAS.png",
                _ => "Unknown"
            };

            return url;
        }
    }
}
