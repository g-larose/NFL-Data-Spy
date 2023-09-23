using API.Models;
using API.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NFL_Data_Spy.ViewModels;

public partial class ScheduleViewViewModel : ObservableObject
{
    private DataService _dataService = new();
    private MatchupDataService _matchupService = new();

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

    public bool CanSearch() => Teamname is not null && Season != 0;

    public ScheduleViewViewModel()
    {
        LoadMatchups(); //TODO: switch this method for the real method in MatchupDataService.
        LoadSeasons();
        TeamNames = _dataService.LoadTeamNames();
    }

    private void LoadSeasons()
    {
        for (int i = 2023; i >= 1966; i--)
        {
            Seasons.Add(i);
        }
    }

    [RelayCommand(CanExecute = nameof(CanSearch))]
    private async Task Search()
    {
         Matchups = await _matchupService.GetSeasonSchedule(Season, Teamname!);
    }

    private void LoadMatchups()
    {
        var team = new Team()
        {
            Identifier = Guid.NewGuid(),
            Name = "ARIZONA CARDINALS",
            Division = Division.AFC_EAST,
            Abbr = "ARI",
            Record = "(3 0 0)",
            LogoUri = "/Images/Logo/ARI.png"
        };

        var matchup = new Matchup()
        {
            Year = Season,
            AwayTeam = team,
            HomeTeam = team
        };

        for (int i = 0; i < 10; i++)
        {
            Matchups!.Add(matchup);
        }
    }
}
