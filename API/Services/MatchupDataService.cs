using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Models;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace API.Services;

public class MatchupDataService : IMatchupService
{
    HtmlDocumentService _docService = new();
    IDataService _dataService = new DataService();


    public MatchupDataService()
    {

    }

    /// <summary>
    /// Get Current Standings
    /// </summary>
    /// <returns>List</returns>
    #region GET CURRENT STANDINGS
    public async Task<List<TeamStanding>> GetCurrentStandingAsync()
    {
        var link = "https://www.footballdb.com/standings/index.html";
        var doc = _docService.GetDocument(link);

        var standings = new List<TeamStanding>();

        var nodes = doc.DocumentNode.SelectNodes(".//table[@class='statistics']");

        for (int i = 0; i < nodes.Count; i++)
        {
            var node = nodes[i].ChildNodes[3];
            var division = nodes[i].SelectSingleNode(".//thead/tr/td").InnerText;
            for (int x = 1; x < node.ChildNodes.Count; x+= 2)
            {
               
                var detailNodes = node.ChildNodes[x];
                var name = detailNodes.ChildNodes[0].ChildNodes[0].InnerText;
                var wins = detailNodes.ChildNodes[1].InnerText;
                var losses = detailNodes.ChildNodes[2].InnerText;
                var ties = detailNodes.ChildNodes[3].InnerText;

                var standing = new TeamStanding()
                {
                    Teamname = name,
                    Division = division,
                    Wins = wins,
                    Losses = losses,
                    Ties = ties
                };

                standings.Add(standing);
            } 
        }
        return standings;
    }
    #endregion

    /// <summary>
    /// GET SEASON SCHEDULE
    /// </summary>
    /// <param name="year"></param>
    /// <param name="teamName"></param>
    /// <returns>List</Matchup></returns>
    #region GET SEASON SCHEDULE
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

                    var homeRecordLength = homeTeamEndIndex - homeTeamStartIndex;
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
                    awayTeam.Division = awayTeamDivision;

                    homeTeam.Name = homeTeamNameFinal;
                    homeTeam.Record = homeTeamRecord;
                    homeTeam.LogoUri = homeTeamLogoUri;
                    homeTeam.Division = homeTeamDivision;

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

    #endregion

    #region GET WEEKLY SCOREBOARD

    public List<Matchup> GetWeeklyScoreboard(int year, int week)
    {
        List<Matchup> matchups = new();
        var link = $"https://www.footballdb.com/scores/index.html?lg=NFL&yr={year}&type=reg&wk={week}";
        var doc = _docService.GetDocument(link);
        var scoreNodes = _docService.GetNodes(doc, ".//div[@class='lngame']//table");

        var awayName = "";
        var homeName = "";
        foreach (var node in scoreNodes)
        {
            var row = node.ChildNodes[3];

            if (row.HasChildNodes)
            {
                awayName = row.ChildNodes[1].InnerText.Replace("\n", string.Empty).Replace("--", string.Empty).Trim();
                homeName = row.ChildNodes[3].InnerText.Replace("\n", string.Empty).Replace("--", string.Empty).Trim();

                var awayScore = int.TryParse(row.ChildNodes[1].ChildNodes[7].InnerText, out int awayScoreFinal);
                var homeScore = int.TryParse(row.ChildNodes[3].ChildNodes[7].InnerText, out int homeScoreFinal);

                if (awayScoreFinal > homeScoreFinal)
                {
                    var awayTeam = new Team() { Name = awayName, IsWinner = true };
                    var homeTeam = new Team() { Name = homeName, IsWinner = false };
                    var matchup = new Matchup() { AwayTeam = awayTeam, HomeTeam = homeTeam };
                    matchups.Add(matchup);
                }
                else
                {
                    var awayTeam = new Team() { Name = awayName, IsWinner = false };
                    var homeTeam = new Team() { Name = homeName, IsWinner = true };
                    var matchup = new Matchup() { AwayTeam = awayTeam, HomeTeam = homeTeam };
                    matchups.Add(matchup);
                }           
            }  
        }

        return matchups;
    }

    #endregion

    public async Task<List<Team>> GetTeamData(string teamName)
    {
        throw new NotImplementedException();
    }
}
