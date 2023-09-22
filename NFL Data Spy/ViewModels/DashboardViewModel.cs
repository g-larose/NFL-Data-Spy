using API.Extensions;
using API.Interfaces;
using API.Models;
using API.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace NFL_Data_Spy.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    private DataService _dataService = new();
    [ObservableProperty]
    private List<Team>? _matchups = new();

    [ObservableProperty]
    List<string> _teamNames = new();

    public DashboardViewModel()
    {
        LoadMatchups();
        TeamNames = _dataService.LoadTeamNames();
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

        for (int i = 0; i < 10; i++)
        {
            Matchups!.Add(team);
        }
    }
}
