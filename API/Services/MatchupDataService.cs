using API.Extensions;
using API.Interfaces;
using API.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class MatchupDataService : IMatchupService
    {
        HtmlDocumentService _docService = new();
        public async Task<List<Matchup>> GetSeasonSchedule(int year, string teamName)
        {
            teamName = teamName.ToHtmlteamName();

            var link = $"https://www.footballdb.com/teams/nfl/{teamName}/results/{year}";
            var doc = _docService.GetDocument(link);

            List<Matchup> matchups = new();
            

            if (doc is not null)
            {
                var nodes = doc.DocumentNode.SelectNodes(".//div[@class='lngame']/table");
                var nodeCount = 0;
                if (nodes is not null)
                {

                    for (int i = 0; i < nodes.Count; i++)
                    {
                        Team awayTeam = new();
                        Team homeTeam = new();
                        var node = nodes[i]; 
                        var gameDate = node.SelectSingleNode(".//th[@class='left']").InnerText;
                        var homeTeamName = node.ChildNodes[3].ChildNodes[3].InnerText;
                        var awayTeamName = node.ChildNodes[3].ChildNodes[1].InnerText;

                        var homeTeamNameFinal = homeTeamName.Split("(")[0].Trim();
                        var awayTeamNameFinal = awayTeamName.Split("(")[0].Trim();

                        var homeTeamLogoUri = homeTeamNameFinal.ToLogoUri();
                        var awayTeamLogoUri = awayTeamNameFinal.ToLogoUri();

                        var homeTeamStartIndex = homeTeamName.IndexOf("(");
                        var awayTeamStartIndex = awayTeamName.IndexOf("(");
                        var homeTeamEndIndex = homeTeamName.IndexOf(")");
                        var awayTeamEndIndex = awayTeamName.IndexOf(")");

                        var homeRecordIndex = homeTeamName.IndexOf("(");
                        var homeRecordLength = homeTeamEndIndex - homeTeamStartIndex;
                        var awayRecordIndex = awayTeamName.IndexOf("(");
                        var awayRecordLength = awayTeamEndIndex - awayTeamStartIndex;

                        var homeTeamRecord = homeTeamName.Substring(homeTeamStartIndex, homeRecordLength + 1);
                        var awayTeamRecord = awayTeamName.Substring(awayTeamStartIndex, awayRecordLength + 1);

                        //var awayRecord = awayTeamRecord.Split("\n")[0];
                        //var homeRecord = homeTeamName.Substring(homeRecordIndex - 1);

                        var awayTeamDivision = awayTeamNameFinal.ToDivisionString();
                        var homeTeamDivision = homeTeamNameFinal.ToDivisionString();

                        awayTeam.Name = awayTeamNameFinal;
                        awayTeam.Record = awayTeamRecord;
                        awayTeam.LogoUri = awayTeamLogoUri;
                        awayTeam.Division = awayTeamDivision.ToDivision();

                        homeTeam.Name = homeTeamNameFinal;
                        homeTeam.Record = homeTeamRecord;
                        homeTeam.LogoUri = homeTeamLogoUri;
                        homeTeam.Division = homeTeamDivision.ToDivision();

                        var matchup = new Matchup()
                        {
                            Year = year,
                            GameDate = gameDate,
                            AwayTeam = awayTeam,
                            HomeTeam = homeTeam,

                        };
                        matchups.Add(matchup);
                    }
                }
               
            }

            return matchups;
        }

        public async Task<List<Team>> GetTeamData(string teamName)
        {
            throw new NotImplementedException();
        }
    }
}
