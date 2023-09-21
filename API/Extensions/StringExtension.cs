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
        public static string ToStringDivision(this Division division, Division value)
        {
            var result = value switch
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
    }
}
