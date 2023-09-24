using API.Extensions;
using API.Interfaces;
using API.Models;
using API.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NFL_Data_Spy.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    IMatchupService _matchupService = new MatchupDataService();

    [ObservableProperty]
    List<TeamStanding>? _standings;

    public DashboardViewModel()
    {
        LoadStandings();

    }

    private void LoadStandings()
    {
        Task.Run(async () =>
        {
           _standings = await _matchupService.GetCurrentStandingAsync();
        });
    }
}
