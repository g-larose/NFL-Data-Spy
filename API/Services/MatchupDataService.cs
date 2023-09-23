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
            var logoUrl = teamName.ToLogoUri();
            var link = $"https://www.footballdb.com/teams/nfl/{teamName}/results/{year}";
            var doc = _docService.GetDocument(link);
            List<Matchup> matchups = new();

            if (doc is not null)
            {
                var nodes = doc.DocumentNode.SelectNodes(".//div[@class='lngame']/table");
                if (nodes is not null)
                {
                    foreach (var node in nodes)
                    {
                        //here is where we get our info for the matchup
                        var homeTeamName = node.ChildNodes[3].ChildNodes[3].ChildNodes[1].InnerText;
                        var awayTeamName = node.ChildNodes[3].ChildNodes[1].ChildNodes[1].InnerText;
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
