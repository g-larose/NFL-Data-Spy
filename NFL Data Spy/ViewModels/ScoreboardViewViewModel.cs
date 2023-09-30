using API.Data;
using API.Data.Factories;
using API.Interfaces;
using API.Models;
using API.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        private IDataService _dataService = new DataService();
        private INetworkConnection internetConnection = new NetworkConnectionService();

        [ObservableProperty]
        private List<int> _weeks;

        [ObservableProperty]
        private List<int> _seasons;

        [ObservableProperty]
        List<Matchup>? _scores;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SearchCommand))]
        private int _season = 0;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SearchCommand))]
        private int _week = 0;

        public bool CanSearch() => Season != 0 && Week != 0;
        public ScoreboardViewViewModel()
        {
            LoadScoreboard();
            Weeks = _dataService.LoadWeeks();
            Seasons = _dataService.LoadSeasons();
            //TODO: load season list from 2023 - 1966
            //TODO: Load week list. 1 - 17
        }

        private void LoadScoreboard()
        {
            //using var dbFactory = new AppDbContextFactory();
            // var db = dbFactory.CreateDbContext();
            
        }

        [RelayCommand(CanExecute = nameof(CanSearch))]
        private async Task Search()
        {
            Scores = _matchupService.GetWeeklyScoreboard(Season, Week);
            Week = 0;
            Season = 0;
        }
    }
}
