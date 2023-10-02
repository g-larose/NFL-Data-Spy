using API.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IMatchupService
    {
        Task<List<Team>> GetTeamData(string name);
        Task<List<Matchup>> GetSeasonSchedule(int year, string teamName);
        Task<List<TeamStanding>> GetCurrentStandingAsync();
        List<Matchup> GetWeeklyScoreboard(int year, int week = 0);
        int GetCurrentWeek();
    }
}
