using API.Interfaces;
using API.Models;
using API.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NFL_Data_Spy.ViewModels;

public partial class ScheduleViewViewModel : ObservableObject
{
    private IDataService _dataService = new DataService();
    private IMatchupService _matchupService = new MatchupDataService();

    [ObservableProperty]
    private List<Matchup>? _matchups = new();

    [ObservableProperty]
    private List<int>? _seasons = new();

    [ObservableProperty]
    List<string> _teamNames = new();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SearchCommand))]
    private string? _teamname;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SearchCommand))]
    private int _season = 0;

    [ObservableProperty]
    private Matchup _selectedMatchup;

    public bool CanSearch() => Teamname is not null && Season != 0;

    public ScheduleViewViewModel()
    {
        Seasons = _dataService.LoadSeasons();
        TeamNames = _dataService.LoadTeamNames();
    }

    [RelayCommand(CanExecute = nameof(CanSearch))]
    private async Task Search()
    {
         Matchups = await _matchupService.GetSeasonSchedule(Season, Teamname!);
        Teamname = null;
        Season = 0;
    }

    private void LoadMatchups()
    {
        Task.Run(async () =>
        {
            Matchups = await _matchupService.GetSeasonSchedule(Season, Teamname);
        });
    }
}
