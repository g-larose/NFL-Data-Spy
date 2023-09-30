using API.Data;
using API.Data.Factories;
using API.Extensions;
using API.Interfaces;
using API.Models;
using API.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NFL_Data_Spy.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    private IDbContextFactory<AppDbContext> _dbContext;
    private IMatchupService _matchupService;

    [ObservableProperty]
    List<TeamStanding>? _standings;

    public DashboardViewModel()
    {
        LoadStandings();
        _dbContext = new AppDbContextFactory();
        _matchupService = new MatchupDataService();
    }

    private void LoadStandings()
    {
        Task.Run(async () =>
        {
           Standings = await _matchupService.GetCurrentStandingAsync();
        });
    }
}
