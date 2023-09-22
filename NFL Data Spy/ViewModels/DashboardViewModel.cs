using API.Extensions;
using API.Models;
using API.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NFL_Data_Spy.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    [ObservableProperty]
    private List<Team>? _matchups = new();

    public DashboardViewModel()
    {
        LoadMatchups();
    }

    private void LoadMatchups()
    {
        var team = new Team()
        {
            Identifier = Guid.NewGuid(),
            Name = "ARIZONA CARDINALS",
            Division = Division.AFC_EAST,
            Abbr = "ARI",
            Record = "3,0,0"
        };

        for (int i = 0; i < 10; i++)
        {
            Matchups!.Add(team);
        }
    }
}
