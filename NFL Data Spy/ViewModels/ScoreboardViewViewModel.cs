using API.Data;
using API.Data.Factories;
using API.Interfaces;
using API.Models;
using API.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFL_Data_Spy.ViewModels
{
    public partial class ScoreboardViewViewModel : ObservableObject
    {
        private IMatchupService _matchupService = new MatchupDataService();

        [ObservableProperty]
        List<Matchup>? _scores;
        public ScoreboardViewViewModel()
        {
            Scores = _matchupService.GetWeeklyScoreboard(2023, 1);
        }

        private void LoadScoreboard()
        {
            using var dbFactory = new AppDbContextFactory();
            var db = dbFactory.CreateDbContext();
            Scores = _matchupService.GetWeeklyScoreboard(2023, 1);
        }
    }
}
